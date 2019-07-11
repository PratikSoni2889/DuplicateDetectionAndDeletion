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
            this.cbxKeyColumn = new System.Windows.Forms.ComboBox();
            this.lblKeyColumn = new System.Windows.Forms.Label();
            this.btnDetectDuplicates = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
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
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabCRM.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 440);
            this.panel1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCRM);
            this.tabControl1.Controls.Add(this.tabDatabase);
            this.tabControl1.Location = new System.Drawing.Point(6, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(616, 432);
            this.tabControl1.TabIndex = 5;
            // 
            // tabCRM
            // 
            this.tabCRM.Controls.Add(this.cbxKeyColumn);
            this.tabCRM.Controls.Add(this.lblKeyColumn);
            this.tabCRM.Controls.Add(this.btnDetectDuplicates);
            this.tabCRM.Controls.Add(this.btnClear);
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
            this.tabCRM.Size = new System.Drawing.Size(608, 406);
            this.tabCRM.TabIndex = 0;
            this.tabCRM.Text = "CRM";
            this.tabCRM.UseVisualStyleBackColor = true;
            // 
            // cbxKeyColumn
            // 
            this.cbxKeyColumn.FormattingEnabled = true;
            this.cbxKeyColumn.Location = new System.Drawing.Point(148, 246);
            this.cbxKeyColumn.Name = "cbxKeyColumn";
            this.cbxKeyColumn.Size = new System.Drawing.Size(252, 21);
            this.cbxKeyColumn.TabIndex = 18;
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
            this.btnDetectDuplicates.Location = new System.Drawing.Point(94, 373);
            this.btnDetectDuplicates.Name = "btnDetectDuplicates";
            this.btnDetectDuplicates.Size = new System.Drawing.Size(128, 23);
            this.btnDetectDuplicates.TabIndex = 16;
            this.btnDetectDuplicates.Text = "Detect Duplicates";
            this.btnDetectDuplicates.UseVisualStyleBackColor = true;
            this.btnDetectDuplicates.Click += new System.EventHandler(this.BtnDetectDuplicates_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(239, 144);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // lblAttributes
            // 
            this.lblAttributes.AutoSize = true;
            this.lblAttributes.Location = new System.Drawing.Point(15, 278);
            this.lblAttributes.Name = "lblAttributes";
            this.lblAttributes.Size = new System.Drawing.Size(127, 13);
            this.lblAttributes.TabIndex = 14;
            this.lblAttributes.Text = "Select Primary Attribute(s)";
            // 
            // clbxAttributes
            // 
            this.clbxAttributes.FormattingEnabled = true;
            this.clbxAttributes.Location = new System.Drawing.Point(148, 278);
            this.clbxAttributes.Name = "clbxAttributes";
            this.clbxAttributes.Size = new System.Drawing.Size(236, 79);
            this.clbxAttributes.TabIndex = 13;
            // 
            // cbxSolution
            // 
            this.cbxSolution.FormattingEnabled = true;
            this.cbxSolution.Location = new System.Drawing.Point(148, 180);
            this.cbxSolution.Name = "cbxSolution";
            this.cbxSolution.Size = new System.Drawing.Size(252, 21);
            this.cbxSolution.TabIndex = 12;
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
            this.txtUrl.TabIndex = 8;
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
            this.btnCRMConnect.Location = new System.Drawing.Point(147, 144);
            this.btnCRMConnect.Name = "btnCRMConnect";
            this.btnCRMConnect.Size = new System.Drawing.Size(75, 23);
            this.btnCRMConnect.TabIndex = 6;
            this.btnCRMConnect.Text = "Connect";
            this.btnCRMConnect.UseVisualStyleBackColor = true;
            this.btnCRMConnect.Click += new System.EventHandler(this.BtnCRMConnect_Click);
            // 
            // txtSolutionName
            // 
            this.txtSolutionName.Location = new System.Drawing.Point(148, 110);
            this.txtSolutionName.Name = "txtSolutionName";
            this.txtSolutionName.Size = new System.Drawing.Size(252, 20);
            this.txtSolutionName.TabIndex = 5;
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
            this.lblUserName.Size = new System.Drawing.Size(57, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "UserName";
            // 
            // tabDatabase
            // 
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatabase.Size = new System.Drawing.Size(608, 406);
            this.tabDatabase.TabIndex = 1;
            this.tabDatabase.Text = "Database";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Duplicate Detection & Deletion";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabCRM.ResumeLayout(false);
            this.tabCRM.PerformLayout();
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
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDetectDuplicates;
        private System.Windows.Forms.ComboBox cbxKeyColumn;
        private System.Windows.Forms.Label lblKeyColumn;
    }
}

