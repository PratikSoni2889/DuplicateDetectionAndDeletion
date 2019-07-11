using DuplicateDetectionAndDeletion.ClassLibrary.CRM;
using DuplicateDetectionAndDeletion.ClassLibrary.Models;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DuplicateDetectionAndDeletion
{
    public partial class MainForm : Form
    {
        private readonly CRMConnection _service = new CRMConnection();
        private readonly DatabaseConnection dbConnction = new DatabaseConnection();
        public string ConnectionString { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnCRMConnect_Click(object sender, EventArgs e)
        {
            CRMCredential crmCredential = new CRMCredential()
            {
                Url = "https://talentlink365dev.api.crm11.dynamics.com/XRMServices/2011/Organization.svc",  //txtUrl.Text
                UrlName = "TALENTLink",                                                              //txtSolutionName.Text
                UserName = "d365integration@advanceddynamics3.onmicrosoft.com",                             //txtUserName.Text,
                Password = "Nas30032",                                                                      //txtPassword.Text
            };

            var context = _service.EstablishCRMConnection(crmCredential);

            RetrieveCrmSkeleton retrieveCrmSkeleton = new RetrieveCrmSkeleton();
            retrieveCrmSkeleton.GetSolutions(context, crmCredential.UrlName);
            var allEntities = retrieveCrmSkeleton.GetEntityList(context);
            foreach (EntityMetadata Entity in allEntities)
            {
                cbxEntities.Items.Add(Entity.LogicalName);
            }
        }

        private void BtnDatabaseConnect_Click(object sender, EventArgs e)
        {
            DatabaseCredentials dbCredentials = new DatabaseCredentials()
            {
                DatabaseServerName = txtDatabaseServerName.Text,
                UserName = textBox1.Text,
                Password = textBox2.Text
                
            };
            dbCredentials.ConnectionString = "Data Source=" + dbCredentials.DatabaseServerName + ";User ID="+ dbCredentials.UserName+ ";Password="+dbCredentials.Password;
            bool isConnected = dbConnction.EstablishDatabaseConnection(dbCredentials);

            List<string> databaseList = new List<string>();
            if (isConnected)
            {
                MessageBox.Show("Database connected successfully");
                databaseList = dbConnction.GetAllDatabasesOfServer(dbCredentials);
                if (databaseList != null && databaseList.Count > 0)
                {
                    // ======= Fill Database drop down list
                    foreach (var item in databaseList)
                    {
                        cbDatabaseList.Items.Add(item);
                    }                    
                }
            }
            else
            {
                MessageBox.Show("Failed to connect to database");
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void CbDatabaseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTableList.Items.Clear();
            cbTableList.Refresh();
            DatabaseCredentials dbCredentials = new DatabaseCredentials();
            string selectedDatabase = string.Empty;
            selectedDatabase = cbDatabaseList.SelectedItem.ToString();
            dbCredentials = GetDatabaseCredentialsDetails();
            dbCredentials.ConnectionString = "Data Source=" + dbCredentials.DatabaseServerName + "; Initial Catalog = " + selectedDatabase  +"; User ID=" + dbCredentials.UserName + ";Password=" + dbCredentials.Password;
            //dbCredentials.ConnectionString = "Data Source=localhost;Initial Catalog=" + selectedDatabase + ";Integrated Security=True";
            List<string> tablesOfDatabase = new List<string>();
            tablesOfDatabase = dbConnction.GetAllTablesOfDatabase(dbCredentials);
            if (tablesOfDatabase != null && tablesOfDatabase.Count > 0)
            {
                // ======= Fill Database drop down list
                foreach (var item in tablesOfDatabase)
                {
                    cbTableList.Items.Add(item);
                }
            }
        }

        private void CbTableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseCredentials dbCredentials = new DatabaseCredentials();
            string selectedDatabase = string.Empty;
            selectedDatabase = cbDatabaseList.SelectedItem.ToString();
            dbCredentials = GetDatabaseCredentialsDetails();
            dbCredentials.ConnectionString = "Data Source=" + dbCredentials.DatabaseServerName + "; Initial Catalog = " + selectedDatabase + "; User ID=" + dbCredentials.UserName + ";Password=" + dbCredentials.Password;
            //dbCredentials.ConnectionString = "Data Source=localhost;Initial Catalog=" + selectedDatabase + ";Integrated Security=True";
            List<string> fieldsOfTable = new List<string>();
            fieldsOfTable = dbConnction.GetAllColumnsOfTable(dbCredentials, cbTableList.SelectedItem.ToString());
            if (fieldsOfTable != null && fieldsOfTable.Count > 0)
            {
                // ======= Fill Database drop down list
                chkFieldList.DataSource = fieldsOfTable;
            }
        }

        private void BtnRetrieveDuplicate_Click(object sender, EventArgs e)
        {
            if (chkFieldList.CheckedItems.Count > 0)
            {
                DatabaseCredentials dbCredentials = new DatabaseCredentials();
                string selectedDatabase = string.Empty;
                selectedDatabase = cbDatabaseList.SelectedItem.ToString();
                dbCredentials = GetDatabaseCredentialsDetails();
                dbCredentials.ConnectionString = "Data Source=" + dbCredentials.DatabaseServerName + "; Initial Catalog = " + selectedDatabase + "; User ID=" + dbCredentials.UserName + ";Password=" + dbCredentials.Password;
                //dbCredentials.ConnectionString = "Data Source=localhost;Initial Catalog=" + selectedDatabase + ";Integrated Security=True";
                List<string> fieldsOfTable = new List<string>();
                fieldsOfTable = dbConnction.GetAllColumnsOfTable(dbCredentials, cbTableList.SelectedItem.ToString());
                List<string> selectedColumnList = new List<string>();
                foreach (object itemChecked in chkFieldList.CheckedItems)
                {
                    selectedColumnList.Add(itemChecked.ToString());
                }
                dataGridView1.DataSource = dbConnction.GetDuplicateRecords(dbCredentials, cbTableList.SelectedItem.ToString(), selectedColumnList);
                MessageBox.Show(dataGridView1.Rows.Count - 1 + " Records retrieved");
            }
            else
            {
                MessageBox.Show("Please select at least one column");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DatabaseCredentials dbCredentials = new DatabaseCredentials();
            string selectedDatabase = string.Empty;
            selectedDatabase = cbDatabaseList.SelectedItem.ToString();
            dbCredentials = GetDatabaseCredentialsDetails();
            dbCredentials.ConnectionString = "Data Source=" + dbCredentials.DatabaseServerName + "; Initial Catalog = " + selectedDatabase + "; User ID=" + dbCredentials.UserName + ";Password=" + dbCredentials.Password;
            //dbCredentials.ConnectionString = "Data Source=localhost;Initial Catalog=" + selectedDatabase + ";Integrated Security=True";
            List<string> fieldsOfTable = new List<string>();
            fieldsOfTable = dbConnction.GetAllColumnsOfTable(dbCredentials, cbTableList.SelectedItem.ToString());
            List<string> selectedColumnList = new List<string>();
            foreach (object itemChecked in chkFieldList.CheckedItems)
            {
                selectedColumnList.Add(itemChecked.ToString());
            }
            int numberOfRecordRemoved = dbConnction.RemoveDuplicateData(dbCredentials, cbTableList.SelectedItem.ToString(), selectedColumnList);
            MessageBox.Show(numberOfRecordRemoved + " Records removed");
            if(numberOfRecordRemoved > 0)
            {
                dataGridView1.DataSource = null;
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
        private DatabaseCredentials GetDatabaseCredentialsDetails()
        {
            DatabaseCredentials dbCredentials = new DatabaseCredentials()
            {
                DatabaseServerName = txtDatabaseServerName.Text,
                UserName = textBox1.Text,
                Password = textBox2.Text

            };

            return dbCredentials;
        }
    }
}
