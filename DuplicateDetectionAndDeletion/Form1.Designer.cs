namespace DuplicateDetectionAndDeletion
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCRM = new System.Windows.Forms.TabPage();
            this.btnDetectAndDeleteDupes = new System.Windows.Forms.Button();
            this.cbxKeyColumn = new System.Windows.Forms.ComboBox();
            this.lblKeyColumn = new System.Windows.Forms.Label();
            this.btnDetectDuplicates = new System.Windows.Forms.Button();
            this.lblAttributes = new System.Windows.Forms.Label();
            this.clbxAttributes = new System.Windows.Forms.CheckedListBox();
            this.cbxSolution = new System.Windows.Forms.ComboBox();
            this.lblSolution = new System.Windows.Forms.Label();
            this.cbxEntities = new System.Windows.Forms.ComboBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.btnCRMConnect = new System.Windows.Forms.Button();
            this.txtSolutionName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblSolutionName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRetrieveDuplicate = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkFieldList = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTableList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDatabaseList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDatabaseServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDatabaseConnect = new System.Windows.Forms.Button();
            this.rtxtLogs = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnResetAll = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabCRM.SuspendLayout();
            this.tabDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1117, 620);
            this.panel1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCRM);
            this.tabControl1.Controls.Add(this.tabDatabase);
            this.tabControl1.Location = new System.Drawing.Point(6, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1111, 615);
            this.tabControl1.TabIndex = 5;
            // 
            // tabCRM
            // 
            this.tabCRM.Controls.Add(this.btnResetAll);
            this.tabCRM.Controls.Add(this.label7);
            this.tabCRM.Controls.Add(this.rtxtLogs);
            this.tabCRM.Controls.Add(this.btnDetectAndDeleteDupes);
            this.tabCRM.Controls.Add(this.cbxKeyColumn);
            this.tabCRM.Controls.Add(this.lblKeyColumn);
            this.tabCRM.Controls.Add(this.btnDetectDuplicates);
            this.tabCRM.Controls.Add(this.lblAttributes);
            this.tabCRM.Controls.Add(this.clbxAttributes);
            this.tabCRM.Controls.Add(this.cbxSolution);
            this.tabCRM.Controls.Add(this.lblSolution);
            this.tabCRM.Controls.Add(this.cbxEntities);
            this.tabCRM.Controls.Add(this.lblEntity);
            this.tabCRM.Controls.Add(this.txtUrl);
            this.tabCRM.Controls.Add(this.lblUrl);
            this.tabCRM.Controls.Add(this.btnCRMConnect);
            this.tabCRM.Controls.Add(this.txtSolutionName);
            this.tabCRM.Controls.Add(this.txtPassword);
            this.tabCRM.Controls.Add(this.txtUserName);
            this.tabCRM.Controls.Add(this.lblSolutionName);
            this.tabCRM.Controls.Add(this.lblPassword);
            this.tabCRM.Controls.Add(this.lblUserName);
            this.tabCRM.Location = new System.Drawing.Point(4, 22);
            this.tabCRM.Name = "tabCRM";
            this.tabCRM.Padding = new System.Windows.Forms.Padding(3);
            this.tabCRM.Size = new System.Drawing.Size(1103, 589);
            this.tabCRM.TabIndex = 0;
            this.tabCRM.Text = "CRM";
            this.tabCRM.UseVisualStyleBackColor = true;
            // 
            // btnDetectAndDeleteDupes
            // 
            this.btnDetectAndDeleteDupes.Enabled = false;
            this.btnDetectAndDeleteDupes.Location = new System.Drawing.Point(274, 288);
            this.btnDetectAndDeleteDupes.Name = "btnDetectAndDeleteDupes";
            this.btnDetectAndDeleteDupes.Size = new System.Drawing.Size(126, 23);
            this.btnDetectAndDeleteDupes.TabIndex = 14;
            this.btnDetectAndDeleteDupes.Text = "Remove duplicate data";
            this.btnDetectAndDeleteDupes.UseVisualStyleBackColor = true;
            this.btnDetectAndDeleteDupes.Click += new System.EventHandler(this.BtnDetectAndDeleteDupes_Click);
            // 
            // cbxKeyColumn
            // 
            this.cbxKeyColumn.FormattingEnabled = true;
            this.cbxKeyColumn.Location = new System.Drawing.Point(148, 246);
            this.cbxKeyColumn.Name = "cbxKeyColumn";
            this.cbxKeyColumn.Size = new System.Drawing.Size(252, 21);
            this.cbxKeyColumn.TabIndex = 11;
            this.cbxKeyColumn.SelectedIndexChanged += new System.EventHandler(this.CbxKeyColumn_SelectedIndexChanged);
            // 
            // lblKeyColumn
            // 
            this.lblKeyColumn.AutoSize = true;
            this.lblKeyColumn.Location = new System.Drawing.Point(15, 249);
            this.lblKeyColumn.Name = "lblKeyColumn";
            this.lblKeyColumn.Size = new System.Drawing.Size(111, 13);
            this.lblKeyColumn.TabIndex = 17;
            this.lblKeyColumn.Text = "Select Primary column";
            // 
            // btnDetectDuplicates
            // 
            this.btnDetectDuplicates.Enabled = false;
            this.btnDetectDuplicates.Location = new System.Drawing.Point(136, 288);
            this.btnDetectDuplicates.Name = "btnDetectDuplicates";
            this.btnDetectDuplicates.Size = new System.Drawing.Size(132, 23);
            this.btnDetectDuplicates.TabIndex = 13;
            this.btnDetectDuplicates.Text = "Retrieve duplicate data";
            this.btnDetectDuplicates.UseVisualStyleBackColor = true;
            this.btnDetectDuplicates.Click += new System.EventHandler(this.BtnDetectDuplicates_Click);
            // 
            // lblAttributes
            // 
            this.lblAttributes.AutoSize = true;
            this.lblAttributes.Location = new System.Drawing.Point(43, 430);
            this.lblAttributes.Name = "lblAttributes";
            this.lblAttributes.Size = new System.Drawing.Size(127, 13);
            this.lblAttributes.TabIndex = 14;
            this.lblAttributes.Text = "Select Primary Attribute(s)";
            this.lblAttributes.Visible = false;
            // 
            // clbxAttributes
            // 
            this.clbxAttributes.FormattingEnabled = true;
            this.clbxAttributes.Location = new System.Drawing.Point(176, 430);
            this.clbxAttributes.Name = "clbxAttributes";
            this.clbxAttributes.Size = new System.Drawing.Size(252, 79);
            this.clbxAttributes.TabIndex = 12;
            this.clbxAttributes.Visible = false;
            // 
            // cbxSolution
            // 
            this.cbxSolution.FormattingEnabled = true;
            this.cbxSolution.Location = new System.Drawing.Point(148, 180);
            this.cbxSolution.Name = "cbxSolution";
            this.cbxSolution.Size = new System.Drawing.Size(252, 21);
            this.cbxSolution.TabIndex = 9;
            this.cbxSolution.SelectedIndexChanged += new System.EventHandler(this.CbxSolution_SelectedIndexChanged);
            // 
            // lblSolution
            // 
            this.lblSolution.AutoSize = true;
            this.lblSolution.Location = new System.Drawing.Point(15, 180);
            this.lblSolution.Name = "lblSolution";
            this.lblSolution.Size = new System.Drawing.Size(78, 13);
            this.lblSolution.TabIndex = 11;
            this.lblSolution.Text = "Select Solution";
            // 
            // cbxEntities
            // 
            this.cbxEntities.FormattingEnabled = true;
            this.cbxEntities.Location = new System.Drawing.Point(148, 213);
            this.cbxEntities.Name = "cbxEntities";
            this.cbxEntities.Size = new System.Drawing.Size(252, 21);
            this.cbxEntities.TabIndex = 10;
            this.cbxEntities.SelectedIndexChanged += new System.EventHandler(this.CbxEntities_SelectedIndexChanged);
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Location = new System.Drawing.Point(15, 216);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(66, 13);
            this.lblEntity.TabIndex = 9;
            this.lblEntity.Text = "Select Entity";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(147, 78);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(253, 20);
            this.txtUrl.TabIndex = 5;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(15, 81);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(29, 13);
            this.lblUrl.TabIndex = 7;
            this.lblUrl.Text = "URL";
            // 
            // btnCRMConnect
            // 
            this.btnCRMConnect.Location = new System.Drawing.Point(274, 142);
            this.btnCRMConnect.Name = "btnCRMConnect";
            this.btnCRMConnect.Size = new System.Drawing.Size(126, 23);
            this.btnCRMConnect.TabIndex = 7;
            this.btnCRMConnect.Text = "Connect";
            this.btnCRMConnect.UseVisualStyleBackColor = true;
            this.btnCRMConnect.Click += new System.EventHandler(this.BtnCRMConnect_Click);
            // 
            // txtSolutionName
            // 
            this.txtSolutionName.Location = new System.Drawing.Point(148, 110);
            this.txtSolutionName.Name = "txtSolutionName";
            this.txtSolutionName.Size = new System.Drawing.Size(252, 20);
            this.txtSolutionName.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(147, 47);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(253, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(147, 16);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(253, 20);
            this.txtUserName.TabIndex = 3;
            // 
            // lblSolutionName
            // 
            this.lblSolutionName.AutoSize = true;
            this.lblSolutionName.Location = new System.Drawing.Point(15, 113);
            this.lblSolutionName.Name = "lblSolutionName";
            this.lblSolutionName.Size = new System.Drawing.Size(76, 13);
            this.lblSolutionName.TabIndex = 2;
            this.lblSolutionName.Text = "Solution Name";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(15, 50);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(15, 19);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name";
            // 
            // tabDatabase
            // 
            this.tabDatabase.Controls.Add(this.textBox2);
            this.tabDatabase.Controls.Add(this.dataGridView1);
            this.tabDatabase.Controls.Add(this.label6);
            this.tabDatabase.Controls.Add(this.textBox1);
            this.tabDatabase.Controls.Add(this.label5);
            this.tabDatabase.Controls.Add(this.btnRetrieveDuplicate);
            this.tabDatabase.Controls.Add(this.button2);
            this.tabDatabase.Controls.Add(this.chkFieldList);
            this.tabDatabase.Controls.Add(this.label4);
            this.tabDatabase.Controls.Add(this.cbTableList);
            this.tabDatabase.Controls.Add(this.label3);
            this.tabDatabase.Controls.Add(this.cbDatabaseList);
            this.tabDatabase.Controls.Add(this.label1);
            this.tabDatabase.Controls.Add(this.txtDatabaseServerName);
            this.tabDatabase.Controls.Add(this.label2);
            this.tabDatabase.Controls.Add(this.btnDatabaseConnect);
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatabase.Size = new System.Drawing.Size(1103, 589);
            this.tabDatabase.TabIndex = 1;
            this.tabDatabase.Text = "Database";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(162, 72);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(420, 24);
            this.textBox2.TabIndex = 21;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(601, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(496, 573);
            this.dataGridView1.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Password";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(162, 39);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(420, 27);
            this.textBox1.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "User Name";
            // 
            // btnRetrieveDuplicate
            // 
            this.btnRetrieveDuplicate.Location = new System.Drawing.Point(162, 274);
            this.btnRetrieveDuplicate.Name = "btnRetrieveDuplicate";
            this.btnRetrieveDuplicate.Size = new System.Drawing.Size(141, 23);
            this.btnRetrieveDuplicate.TabIndex = 26;
            this.btnRetrieveDuplicate.Text = "Retrieve duplicate data";
            this.btnRetrieveDuplicate.UseVisualStyleBackColor = true;
            this.btnRetrieveDuplicate.Click += new System.EventHandler(this.BtnRetrieveDuplicate_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(309, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "Remove duplicate data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // chkFieldList
            // 
            this.chkFieldList.FormattingEnabled = true;
            this.chkFieldList.Location = new System.Drawing.Point(162, 188);
            this.chkFieldList.Name = "chkFieldList";
            this.chkFieldList.Size = new System.Drawing.Size(420, 79);
            this.chkFieldList.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Select Fields";
            // 
            // cbTableList
            // 
            this.cbTableList.FormattingEnabled = true;
            this.cbTableList.Location = new System.Drawing.Point(162, 158);
            this.cbTableList.Name = "cbTableList";
            this.cbTableList.Size = new System.Drawing.Size(420, 21);
            this.cbTableList.TabIndex = 24;
            this.cbTableList.SelectedIndexChanged += new System.EventHandler(this.CbTableList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Select Table";
            // 
            // cbDatabaseList
            // 
            this.cbDatabaseList.FormattingEnabled = true;
            this.cbDatabaseList.Location = new System.Drawing.Point(162, 131);
            this.cbDatabaseList.Name = "cbDatabaseList";
            this.cbDatabaseList.Size = new System.Drawing.Size(420, 21);
            this.cbDatabaseList.TabIndex = 23;
            this.cbDatabaseList.SelectedIndexChanged += new System.EventHandler(this.CbDatabaseList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Select Database";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // txtDatabaseServerName
            // 
            this.txtDatabaseServerName.Location = new System.Drawing.Point(162, 7);
            this.txtDatabaseServerName.Multiline = true;
            this.txtDatabaseServerName.Name = "txtDatabaseServerName";
            this.txtDatabaseServerName.Size = new System.Drawing.Size(420, 26);
            this.txtDatabaseServerName.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Database Server Name";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // btnDatabaseConnect
            // 
            this.btnDatabaseConnect.Location = new System.Drawing.Point(162, 102);
            this.btnDatabaseConnect.Name = "btnDatabaseConnect";
            this.btnDatabaseConnect.Size = new System.Drawing.Size(75, 23);
            this.btnDatabaseConnect.TabIndex = 22;
            this.btnDatabaseConnect.Text = "Connect";
            this.btnDatabaseConnect.UseVisualStyleBackColor = true;
            this.btnDatabaseConnect.Click += new System.EventHandler(this.BtnDatabaseConnect_Click);
            // 
            // rtxtLogs
            // 
            this.rtxtLogs.Location = new System.Drawing.Point(487, 36);
            this.rtxtLogs.Name = "rtxtLogs";
            this.rtxtLogs.Size = new System.Drawing.Size(604, 538);
            this.rtxtLogs.TabIndex = 15;
            this.rtxtLogs.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(484, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Logs";
            // 
            // btnResetAll
            // 
            this.btnResetAll.Location = new System.Drawing.Point(274, 317);
            this.btnResetAll.Name = "btnResetAll";
            this.btnResetAll.Size = new System.Drawing.Size(126, 23);
            this.btnResetAll.TabIndex = 16;
            this.btnResetAll.Text = "Reset All";
            this.btnResetAll.UseVisualStyleBackColor = true;
            this.btnResetAll.Click += new System.EventHandler(this.BtnResetAll_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 639);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Duplicate Detection & Deletion";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabCRM.ResumeLayout(false);
            this.tabCRM.PerformLayout();
            this.tabDatabase.ResumeLayout(false);
            this.tabDatabase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCRM;
        private System.Windows.Forms.TextBox txtSolutionName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblSolutionName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.Button btnCRMConnect;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblEntity;
        private System.Windows.Forms.ComboBox cbxEntities;
        private System.Windows.Forms.ComboBox cbxSolution;
        private System.Windows.Forms.Label lblSolution;
        private System.Windows.Forms.Label lblAttributes;
        private System.Windows.Forms.CheckedListBox clbxAttributes;
        private System.Windows.Forms.Button btnDetectDuplicates;
        private System.Windows.Forms.ComboBox cbxKeyColumn;
        private System.Windows.Forms.Label lblKeyColumn;
        private System.Windows.Forms.Button btnDetectAndDeleteDupes;
        private System.Windows.Forms.ComboBox cbDatabaseList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDatabaseServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDatabaseConnect;
        private System.Windows.Forms.ComboBox cbTableList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox chkFieldList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnRetrieveDuplicate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtxtLogs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnResetAll;
    }
}

