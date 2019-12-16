namespace OFX_Sandbox.UserControls
{
    partial class FetchControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splDetails = new CustomControls.SplitContainer2();
            this.rtbRequest = new System.Windows.Forms.RichTextBox();
            this.rtbResponse = new System.Windows.Forms.RichTextBox();
            this.btnFetch = new System.Windows.Forms.Button();
            this.gbCredentials = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtRoutingNo = new System.Windows.Forms.TextBox();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.lblRoutingNo = new System.Windows.Forms.Label();
            this.lblAcctID = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.cmbInstitutions = new System.Windows.Forms.ComboBox();
            this.gbAccount = new System.Windows.Forms.GroupBox();
            this.cmbBankType = new System.Windows.Forms.ComboBox();
            this.lblAccountType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splDetails)).BeginInit();
            this.splDetails.Panel1.SuspendLayout();
            this.splDetails.Panel2.SuspendLayout();
            this.splDetails.SuspendLayout();
            this.gbCredentials.SuspendLayout();
            this.gbAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // splDetails
            // 
            this.splDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splDetails.Location = new System.Drawing.Point(0, 180);
            this.splDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splDetails.Name = "splDetails";
            // 
            // splDetails.Panel1
            // 
            this.splDetails.Panel1.Controls.Add(this.rtbRequest);
            // 
            // splDetails.Panel2
            // 
            this.splDetails.Panel2.Controls.Add(this.rtbResponse);
            this.splDetails.Size = new System.Drawing.Size(942, 296);
            this.splDetails.SplitterDistance = 176;
            this.splDetails.SplitterWidth = 5;
            this.splDetails.TabIndex = 11;
            // 
            // rtbRequest
            // 
            this.rtbRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRequest.Location = new System.Drawing.Point(0, 0);
            this.rtbRequest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbRequest.Name = "rtbRequest";
            this.rtbRequest.Size = new System.Drawing.Size(176, 296);
            this.rtbRequest.TabIndex = 0;
            this.rtbRequest.Text = "";
            // 
            // rtbResponse
            // 
            this.rtbResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbResponse.Location = new System.Drawing.Point(0, 0);
            this.rtbResponse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbResponse.Name = "rtbResponse";
            this.rtbResponse.Size = new System.Drawing.Size(761, 296);
            this.rtbResponse.TabIndex = 0;
            this.rtbResponse.Text = "";
            // 
            // btnFetch
            // 
            this.btnFetch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFetch.Location = new System.Drawing.Point(3, 498);
            this.btnFetch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(935, 60);
            this.btnFetch.TabIndex = 10;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // gbCredentials
            // 
            this.gbCredentials.Controls.Add(this.txtPassword);
            this.gbCredentials.Controls.Add(this.lblPassword);
            this.gbCredentials.Controls.Add(this.txtUsername);
            this.gbCredentials.Controls.Add(this.lblUser);
            this.gbCredentials.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gbCredentials.Location = new System.Drawing.Point(14, 65);
            this.gbCredentials.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbCredentials.Name = "gbCredentials";
            this.gbCredentials.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbCredentials.Size = new System.Drawing.Size(281, 107);
            this.gbCredentials.TabIndex = 8;
            this.gbCredentials.TabStop = false;
            this.gbCredentials.Text = "Credentials";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(107, 63);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(166, 23);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(7, 66);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(80, 16);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(107, 27);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(166, 23);
            this.txtUsername.TabIndex = 1;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(7, 31);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(83, 16);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Username:";
            // 
            // txtRoutingNo
            // 
            this.txtRoutingNo.Location = new System.Drawing.Point(126, 97);
            this.txtRoutingNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRoutingNo.Name = "txtRoutingNo";
            this.txtRoutingNo.Size = new System.Drawing.Size(238, 23);
            this.txtRoutingNo.TabIndex = 5;
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(126, 62);
            this.txtAccountNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(238, 23);
            this.txtAccountNumber.TabIndex = 5;
            // 
            // lblRoutingNo
            // 
            this.lblRoutingNo.AutoSize = true;
            this.lblRoutingNo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblRoutingNo.Location = new System.Drawing.Point(7, 97);
            this.lblRoutingNo.Name = "lblRoutingNo";
            this.lblRoutingNo.Size = new System.Drawing.Size(90, 16);
            this.lblRoutingNo.TabIndex = 4;
            this.lblRoutingNo.Text = "Routing No:";
            // 
            // lblAcctID
            // 
            this.lblAcctID.AutoSize = true;
            this.lblAcctID.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblAcctID.Location = new System.Drawing.Point(7, 62);
            this.lblAcctID.Name = "lblAcctID";
            this.lblAcctID.Size = new System.Drawing.Size(92, 16);
            this.lblAcctID.TabIndex = 4;
            this.lblAcctID.Text = "Account No:";
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblBank.Location = new System.Drawing.Point(6, 16);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(47, 16);
            this.lblBank.TabIndex = 2;
            this.lblBank.Text = "Bank:";
            // 
            // cmbInstitutions
            // 
            this.cmbInstitutions.FormattingEnabled = true;
            this.cmbInstitutions.Location = new System.Drawing.Point(68, 15);
            this.cmbInstitutions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbInstitutions.Name = "cmbInstitutions";
            this.cmbInstitutions.Size = new System.Drawing.Size(227, 24);
            this.cmbInstitutions.TabIndex = 0;
            // 
            // gbAccount
            // 
            this.gbAccount.Controls.Add(this.lblAcctID);
            this.gbAccount.Controls.Add(this.cmbBankType);
            this.gbAccount.Controls.Add(this.lblAccountType);
            this.gbAccount.Controls.Add(this.txtAccountNumber);
            this.gbAccount.Controls.Add(this.txtRoutingNo);
            this.gbAccount.Controls.Add(this.lblRoutingNo);
            this.gbAccount.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gbAccount.Location = new System.Drawing.Point(332, 15);
            this.gbAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbAccount.Name = "gbAccount";
            this.gbAccount.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbAccount.Size = new System.Drawing.Size(372, 158);
            this.gbAccount.TabIndex = 12;
            this.gbAccount.TabStop = false;
            this.gbAccount.Text = "Account";
            // 
            // cmbBankType
            // 
            this.cmbBankType.FormattingEnabled = true;
            this.cmbBankType.Location = new System.Drawing.Point(126, 25);
            this.cmbBankType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBankType.Name = "cmbBankType";
            this.cmbBankType.Size = new System.Drawing.Size(238, 24);
            this.cmbBankType.TabIndex = 0;
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblAccountType.Location = new System.Drawing.Point(7, 25);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(44, 16);
            this.lblAccountType.TabIndex = 2;
            this.lblAccountType.Text = "Type:";
            // 
            // FetchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAccount);
            this.Controls.Add(this.cmbInstitutions);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.splDetails);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.gbCredentials);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FetchControl";
            this.Size = new System.Drawing.Size(942, 562);
            this.splDetails.Panel1.ResumeLayout(false);
            this.splDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splDetails)).EndInit();
            this.splDetails.ResumeLayout(false);
            this.gbCredentials.ResumeLayout(false);
            this.gbCredentials.PerformLayout();
            this.gbAccount.ResumeLayout(false);
            this.gbAccount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.SplitContainer2 splDetails;
        private System.Windows.Forms.RichTextBox rtbRequest;
        private System.Windows.Forms.RichTextBox rtbResponse;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.GroupBox gbCredentials;
        private System.Windows.Forms.TextBox txtRoutingNo;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label lblRoutingNo;
        private System.Windows.Forms.Label lblAcctID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.ComboBox cmbInstitutions;
        private System.Windows.Forms.GroupBox gbAccount;
        private System.Windows.Forms.ComboBox cmbBankType;
        private System.Windows.Forms.Label lblAccountType;
    }
}
