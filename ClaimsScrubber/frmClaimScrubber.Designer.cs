namespace ClaimsScrubber
{
    partial class frmClaimScrubber
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
            this.btnScrub = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtbFilePath = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.rtbResults = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnScrub
            // 
            this.btnScrub.Location = new System.Drawing.Point(293, 96);
            this.btnScrub.Name = "btnScrub";
            this.btnScrub.Size = new System.Drawing.Size(75, 23);
            this.btnScrub.TabIndex = 0;
            this.btnScrub.Text = "Scrub";
            this.btnScrub.UseVisualStyleBackColor = true;
            this.btnScrub.Click += new System.EventHandler(this.btnScrub_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(293, 328);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 1;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(9, 69);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(54, 13);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "File Name";
            // 
            // txtbFilePath
            // 
            this.txtbFilePath.Location = new System.Drawing.Point(62, 66);
            this.txtbFilePath.Name = "txtbFilePath";
            this.txtbFilePath.Size = new System.Drawing.Size(221, 20);
            this.txtbFilePath.TabIndex = 3;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(293, 64);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 4;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // rtbResults
            // 
            this.rtbResults.Location = new System.Drawing.Point(12, 125);
            this.rtbResults.Name = "rtbResults";
            this.rtbResults.Size = new System.Drawing.Size(356, 197);
            this.rtbResults.TabIndex = 5;
            this.rtbResults.Text = "";
            // 
            // frmClaimScrubber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 364);
            this.Controls.Add(this.rtbResults);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtbFilePath);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.btnScrub);
            this.Name = "frmClaimScrubber";
            this.Text = "Claim Scrubber";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScrub;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtbFilePath;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.RichTextBox rtbResults;
    }
}

