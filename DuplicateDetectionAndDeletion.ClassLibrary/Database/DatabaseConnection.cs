using DuplicateDetectionAndDeletion.ClassLibrary.Models;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.ServiceModel.Description;

namespace DuplicateDetectionAndDeletion.ClassLibrary.CRM
{
    public class DatabaseConnection
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public bool EstablishDatabaseConnection(DatabaseCredentials dbCredential)
        {
            bool isDbConnected = false;
            try
            {

                if (dbCredential == null)
                {
                    _logger.Error("Connection string not found.");
                    return false;
                }

                _logger.Info("Connecting to database..... ");

                DatabaseCredentials credential = dbCredential;

                using (SqlConnection con = new SqlConnection(dbCredential.ConnectionString))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                        isDbConnected = true;
                    }
                }


            }
            catch (Exception)
            {
                return isDbConnected;
                throw;
            }


            return isDbConnected;
        }

        public List<string> GetAllDatabasesOfServer(DatabaseCredentials dbCredential)
        {
            List<string> databaseList = new List<string>();
            //string connectionString = "Data Source=.; Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(dbCredential.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            databaseList.Add(dr[0].ToString());
                        }
                    }
                }
            }

            return databaseList;
        }

        public List<string> GetAllTablesOfDatabase(DatabaseCredentials dbCredential)
        {
            List<string> tablesOfDatabase = new List<string>();
            using (SqlConnection connection = new SqlConnection(dbCredential.ConnectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                foreach (DataRow row in schema.Rows)
                {
                    tablesOfDatabase.Add(row[2].ToString());
                }
            }

            return tablesOfDatabase;
        }

        public List<string> GetAllColumnsOfTable(DatabaseCredentials dbCredential, string selectedTable)
        {
            List<string> listacolumnas = new List<string>();
            using (SqlConnection connection = new SqlConnection(dbCredential.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select c.name from sys.columns c inner join sys.tables t on t.object_id = c.object_id and t.name = '" + selectedTable + "' and t.type = 'U'";
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listacolumnas.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return listacolumnas;
        }

        public DataTable GetDuplicateRecords(DatabaseCredentials dbCredential, string selectedTable, List<string> selectedColumns)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(dbCredential.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    string onStatement = string.Empty;
                    string onStatementB = string.Empty;

                    onStatement = GetOnStatement(selectedColumns, "tableA", "tableB");

                    string columns = string.Join(",", selectedColumns);
                    command.CommandText = "SELECT tableA.* from " + selectedTable + " as tableA INNER JOIN ( SELECT "+ columns +" from  " + selectedTable + " GROUP BY " + columns + " HAVING COUNT(*) > 1 ) as tableB ON " + onStatement; //"select c.name from sys.columns c inner join sys.tables t on t.object_id = c.object_id and t.name = '" + selectedTable + "' and t.type = 'U'";
                    connection.Open();

                        SqlDataAdapter da = new SqlDataAdapter(command);
                        // this will query your database and return the result to your datatable
                        da.Fill(dt);
                }
            }
            return dt;

        }

        private string GetOnStatement(List<string> selectedColumns, string aliasA, string aliasB)
        {
            int count = 0;
            string onStatement = string.Empty;
            foreach (var item in selectedColumns)
            {
                count = count + 1;
                if (count != selectedColumns.Count)
                {
                    onStatement = onStatement + aliasA +"." + item + "=" + aliasB + "." + item +" AND ";
                }
                else
                {
                    onStatement = onStatement + aliasA + "." + item + "=" + aliasB + "." + item;
                }
            }

            return onStatement;
        }

        public int RemoveDuplicateData(DatabaseCredentials dbCredential, string selectedTable, List<string> selectedColumns)
        {
            int numberOfRecordsRemoved = 0;

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(dbCredential.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    string onStatement = string.Empty;
                    string onStatementB = string.Empty;

                    onStatement = GetOnStatement(selectedColumns, "tableA", "tableB");

                    string columns = string.Join(",", selectedColumns);
                    command.CommandText = "DELETE FROM "+ selectedTable + " WHERE ID IN (SELECT tableA.ID from " + selectedTable + " as tableA INNER JOIN ( SELECT " + columns + " from  " + selectedTable + " GROUP BY " + columns + " HAVING COUNT(*) > 1 ) as tableB ON " + onStatement + ")"; 
                    connection.Open();

                    numberOfRecordsRemoved = command.ExecuteNonQuery();
                }
            }

            return numberOfRecordsRemoved;
        }

        #region READING DETAILS       

        #endregion

    }
}