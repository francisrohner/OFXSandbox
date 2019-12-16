namespace OFX_Sandbox
{
    partial class OFXMain
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
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabpageFetch = new System.Windows.Forms.TabPage();
            this.tabpageResponse = new System.Windows.Forms.TabPage();
            this.lblBalance = new System.Windows.Forms.Label();
            this.gridTransactions = new System.Windows.Forms.DataGridView();
            this.tabpageRaw = new System.Windows.Forms.TabPage();
            this.rtbRaw = new System.Windows.Forms.RichTextBox();
            this.fetchControl = new OFX_Sandbox.UserControls.FetchControl();
            this.tcMain.SuspendLayout();
            this.tabpageFetch.SuspendLayout();
            this.tabpageResponse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactions)).BeginInit();
            this.tabpageRaw.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabpageFetch);
            this.tcMain.Controls.Add(this.tabpageResponse);
            this.tcMain.Controls.Add(this.tabpageRaw);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1024, 864);
            this.tcMain.TabIndex = 0;
            // 
            // tabpageFetch
            // 
            this.tabpageFetch.Controls.Add(this.fetchControl);
            this.tabpageFetch.Location = new System.Drawing.Point(4, 25);
            this.tabpageFetch.Name = "tabpageFetch";
            this.tabpageFetch.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageFetch.Size = new System.Drawing.Size(1016, 835);
            this.tabpageFetch.TabIndex = 0;
            this.tabpageFetch.Text = "Request";
            this.tabpageFetch.UseVisualStyleBackColor = true;
            // 
            // tabpageResponse
            // 
            this.tabpageResponse.Controls.Add(this.lblBalance);
            this.tabpageResponse.Controls.Add(this.gridTransactions);
            this.tabpageResponse.Location = new System.Drawing.Point(4, 25);
            this.tabpageResponse.Name = "tabpageResponse";
            this.tabpageResponse.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageResponse.Size = new System.Drawing.Size(1016, 835);
            this.tabpageResponse.TabIndex = 1;
            this.tabpageResponse.Text = "Response";
            this.tabpageResponse.UseVisualStyleBackColor = true;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblBalance.Location = new System.Drawing.Point(8, 3);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(82, 16);
            this.lblBalance.TabIndex = 10;
            this.lblBalance.Text = "Balance: --";
            // 
            // gridTransactions
            // 
            this.gridTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTransactions.Location = new System.Drawing.Point(0, 22);
            this.gridTransactions.Name = "gridTransactions";
            this.gridTransactions.Size = new System.Drawing.Size(1013, 810);
            this.gridTransactions.TabIndex = 9;
            // 
            // tabpageRaw
            // 
            this.tabpageRaw.Controls.Add(this.rtbRaw);
            this.tabpageRaw.Location = new System.Drawing.Point(4, 25);
            this.tabpageRaw.Name = "tabpageRaw";
            this.tabpageRaw.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageRaw.Size = new System.Drawing.Size(1016, 835);
            this.tabpageRaw.TabIndex = 2;
            this.tabpageRaw.Text = "ResponseRaw";
            this.tabpageRaw.UseVisualStyleBackColor = true;
            // 
            // rtbRaw
            // 
            this.rtbRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRaw.Location = new System.Drawing.Point(3, 3);
            this.rtbRaw.Name = "rtbRaw";
            this.rtbRaw.Size = new System.Drawing.Size(1010, 832);
            this.rtbRaw.TabIndex = 0;
            this.rtbRaw.Text = "";
            // 
            // fetchControl
            // 
            this.fetchControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fetchControl.Font = new System.Drawing.Font("Arial", 10F);
            this.fetchControl.Location = new System.Drawing.Point(3, 4);
            this.fetchControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fetchControl.Name = "fetchControl";
            this.fetchControl.Size = new System.Drawing.Size(1010, 824);
            this.fetchControl.TabIndex = 0;
            // 
            // OFXMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 864);
            this.Controls.Add(this.tcMain);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OFXMain";
            this.Text = "OFX Sandbox";
            this.tcMain.ResumeLayout(false);
            this.tabpageFetch.ResumeLayout(false);
            this.tabpageResponse.ResumeLayout(false);
            this.tabpageResponse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactions)).EndInit();
            this.tabpageRaw.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabpageFetch;
        private System.Windows.Forms.TabPage tabpageResponse;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.DataGridView gridTransactions;
        private System.Windows.Forms.TabPage tabpageRaw;
        private System.Windows.Forms.RichTextBox rtbRaw;
        private UserControls.FetchControl fetchControl;
    }
}

