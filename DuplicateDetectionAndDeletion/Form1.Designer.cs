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
            this.cbxEntities = new System.Windows.Forms.ComboBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.btnCRMConnect = new System.Windows.Forms.Button();
            this.txtSolutionName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblSolution = new System.Windows.Forms.Label();
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
            this.tabCRM.Controls.Add(this.cbxEntities);
            this.tabCRM.Controls.Add(this.lblEntity);
            this.tabCRM.Controls.Add(this.txtUrl);
            this.tabCRM.Controls.Add(this.lblUrl);
            this.tabCRM.Controls.Add(this.btnCRMConnect);
            this.tabCRM.Controls.Add(this.txtSolutionName);
            this.tabCRM.Controls.Add(this.txtPassword);
            this.tabCRM.Controls.Add(this.txtUserName);
            this.tabCRM.Controls.Add(this.lblSolution);
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
            // cbxEntities
            // 
            this.cbxEntities.FormattingEnabled = true;
            this.cbxEntities.Location = new System.Drawing.Point(79, 158);
            this.cbxEntities.Name = "cbxEntities";
            this.cbxEntities.Size = new System.Drawing.Size(222, 21);
            this.cbxEntities.TabIndex = 10;
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Location = new System.Drawing.Point(15, 161);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(66, 13);
            this.lblEntity.TabIndex = 9;
            this.lblEntity.Text = "Select Entity";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(94, 78);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(100, 20);
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
            this.btnCRMConnect.Location = new System.Drawing.Point(226, 12);
            this.btnCRMConnect.Name = "btnCRMConnect";
            this.btnCRMConnect.Size = new System.Drawing.Size(75, 23);
            this.btnCRMConnect.TabIndex = 6;
            this.btnCRMConnect.Text = "Connect";
            this.btnCRMConnect.UseVisualStyleBackColor = true;
            this.btnCRMConnect.Click += new System.EventHandler(this.BtnCRMConnect_Click);
            // 
            // txtSolutionName
            // 
            this.txtSolutionName.Location = new System.Drawing.Point(95, 110);
            this.txtSolutionName.Name = "txtSolutionName";
            this.txtSolutionName.Size = new System.Drawing.Size(100, 20);
            this.txtSolutionName.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(94, 47);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(94, 16);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 3;
            // 
            // lblSolution
            // 
            this.lblSolution.AutoSize = true;
            this.lblSolution.Location = new System.Drawing.Point(15, 113);
            this.lblSolution.Name = "lblSolution";
            this.lblSolution.Size = new System.Drawing.Size(76, 13);
            this.lblSolution.TabIndex = 2;
            this.lblSolution.Text = "Solution Name";
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
        private System.Windows.Forms.Label lblSolution;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.Button btnCRMConnect;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblEntity;
        private System.Windows.Forms.ComboBox cbxEntities;
    }
}

