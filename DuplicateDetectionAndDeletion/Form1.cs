using DuplicateDetectionAndDeletion.ClassLibrary.CRM;
using DuplicateDetectionAndDeletion.ClassLibrary.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DuplicateDetectionAndDeletion
{
    /// <summary>
    /// This windows application will interact with Class Library and uses the results to display it over the form...
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly CRMConnection _service = new CRMConnection();
        private IOrganizationService _context;
        private readonly RetrieveCrmSkeleton _retrieveCrmSkeleton = new RetrieveCrmSkeleton();
        private readonly DatabaseConnection dbConnction = new DatabaseConnection();
        public string ConnectionString { get; set; }
        private string _logFilePath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnCRMConnect_Click(object sender, EventArgs e)
        {
            cbxSolution.Items.Clear();
            cbxEntities.Items.Clear();

            CRMCredential crmCredential = new CRMCredential()
            {
                Url = txtUrl.Text,
                SolutionName = txtSolutionName.Text,
                UserName = txtUserName.Text,
                Password = txtPassword.Text
            };

            // Establishes the CRM connection
            _context = _service.EstablishCRMConnection(crmCredential);

            // Log = "Connected successfully to CRM."

            var solutions = _retrieveCrmSkeleton.GetSolutions(_context, crmCredential.SolutionName);

            if (!solutions.Entities.Any())
            {
                MessageBox.Show("No solution found.\n Please try with other UrlName", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSolutionName.Focus();
                return;
            }

            foreach (var entity in solutions.Entities)
            {
                cbxSolution.Items.Add(entity.Attributes["friendlyname"] + " [" + entity.Attributes["uniquename"] + "]");
            }

            MessageBox.Show("Solution(s) loaded", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CbxSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            var startIndex = cbxSolution.SelectedItem.ToString().IndexOf("[");
            var substringLength = cbxSolution.SelectedItem.ToString().Length - 2 - startIndex;
            var solutionUniqueName = cbxSolution.SelectedItem.ToString().Substring(startIndex + 1, substringLength);

            var allEntities = _retrieveCrmSkeleton.GetEntityList(_context, solutionUniqueName);

            if (!allEntities.Any())
            {
                MessageBox.Show("No entities found for selected solution.\n Please try with other solution.", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSolutionName.Focus();
                return;
            }

            foreach (EntityMetadata entity in allEntities)
            {
                cbxEntities.Items.Add(entity.LogicalName);
            }
            MessageBox.Show("Entity(s) loaded", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CbxEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var attributes = _retrieveCrmSkeleton.GetAttributeList(_context, cbxEntities.SelectedItem.ToString());

            if (!attributes.Any())
            {
                MessageBox.Show("No attributes found.", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSolutionName.Focus();
                return;
            }

            foreach (var attribute in attributes)
            {
                clbxAttributes.Items.Add(attribute.LogicalName);
                cbxKeyColumn.Items.Add(attribute.LogicalName);
            }
            MessageBox.Show("Attribute(s) loaded", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtUrl.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtSolutionName.Clear();
        }

        private void BtnDetectDuplicates_Click(object sender, EventArgs e)
        {
            var keyAttributes = new List<string>();

            int startIndex;
            int substringLength;
            string attributeLogicalName;

            foreach (object itemChecked in clbxAttributes.CheckedItems)
            {
                //startIndex = itemChecked.ToString().IndexOf("[");
                //substringLength = itemChecked.ToString().Length - 2 - startIndex;
                //attributeLogicalName = itemChecked.ToString().Substring(startIndex + 1, substringLength);

                //keyAttributes.Add(attributeLogicalName);
                keyAttributes.Add(itemChecked.ToString());
            }

            DuplicateSearch duplicateSearch = new DuplicateSearch()
            {
                EntityLogicalName = cbxEntities.SelectedItem.ToString(),
                DuplicatedColumnName = cbxKeyColumn.SelectedItem.ToString(),
                ColumnList = keyAttributes
            };

            var (filePath, recordsProcessed) = DuplicateRecords.RetrieveAndDeleteDuplicateRecords(_context, duplicateSearch, false);
            _logFilePath = filePath;

            MessageBox.Show($"Total {recordsProcessed} records detected. Please check the log file.", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDetectAndDeleteDupes_Click(object sender, EventArgs e)
        {
            var keyAttributes = new List<string>();

            foreach (object itemChecked in clbxAttributes.CheckedItems)
            {
                keyAttributes.Add(itemChecked.ToString());
            }

            DuplicateSearch duplicateSearch = new DuplicateSearch()
            {
                EntityLogicalName = cbxEntities.SelectedItem.ToString(),
                DuplicatedColumnName = cbxKeyColumn.SelectedItem.ToString(),
                ColumnList = keyAttributes
            };

            var(filePath, recordsProcessed) = DuplicateRecords.RetrieveAndDeleteDuplicateRecords(_context, duplicateSearch, true);
            _logFilePath = filePath;
            MessageBox.Show($"Total {recordsProcessed} Deleted. Please check the log file.", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDatabaseConnect_Click(object sender, EventArgs e)
        {
            DatabaseCredentials dbCredentials = new DatabaseCredentials();
            dbCredentials = GetDatabaseCredentialsDetails();

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
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            DatabaseCredentials dbCredentials = new DatabaseCredentials();
            string selectedDatabase = string.Empty;
            selectedDatabase = cbDatabaseList.SelectedItem.ToString();
            dbCredentials = GetDatabaseCredentialsDetails();
            dbCredentials.ConnectionString = "Data Source=" + dbCredentials.DatabaseServerName + "; Initial Catalog = " + selectedDatabase  +"; User ID=" + dbCredentials.UserName + ";Password=" + dbCredentials.Password;
            _ = new List<string>();
            List<string> tablesOfDatabase = dbConnction.GetAllTablesOfDatabase(dbCredentials);
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
            if (dataGridView1.Rows.Count > 0)
            {
                DatabaseCredentials dbCredentials = new DatabaseCredentials();
                string selectedDatabase = cbDatabaseList.SelectedItem.ToString();
                dbCredentials = GetDatabaseCredentialsDetails();
                dbCredentials.ConnectionString = "Data Source=" + dbCredentials.DatabaseServerName + "; Initial Catalog = " + selectedDatabase + "; User ID=" + dbCredentials.UserName + ";Password=" + dbCredentials.Password;
                _ = new List<string>();
                _ = dbConnction.GetAllColumnsOfTable(dbCredentials, cbTableList.SelectedItem.ToString());
                List<string> selectedColumnList = new List<string>();
                foreach (object itemChecked in chkFieldList.CheckedItems)
                {
                    selectedColumnList.Add(itemChecked.ToString());
                }
                int numberOfRecordRemoved = dbConnction.RemoveDuplicateData(dbCredentials, cbTableList.SelectedItem.ToString(), selectedColumnList);
                MessageBox.Show(numberOfRecordRemoved + " Records removed");
                if (numberOfRecordRemoved > 0)
                {
                    dataGridView1.DataSource = null;
                }
            }
            else
            {
                MessageBox.Show("No record(s) to removed");
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

        private void BtnOpenLogFile_Click(object sender, EventArgs e)
        {
            File.ReadAllText(_logFilePath);
            Process.Start("notepad.exe", _logFilePath);
        }
    }
}