namespace ShiftOS
{
    partial class Notification
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
            this.lbtitle = new System.Windows.Forms.Label();
            this.lbmessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbtitle
            // 
            this.lbtitle.AutoSize = true;
            this.lbtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbtitle.Location = new System.Drawing.Point(3, 9);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(135, 20);
            this.lbtitle.TabIndex = 0;
            this.lbtitle.Text = "Package Installed";
            // 
            // lbmessage
            // 
            this.lbmessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbmessage.Location = new System.Drawing.Point(7, 33);
            this.lbmessage.Name = "lbmessage";
            this.lbmessage.Size = new System.Drawing.Size(345, 67);
            this.lbmessage.TabIndex = 1;
            this.lbmessage.Text = "The package \"shiftnet\" has been successfully installed.";
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.lbmessage);
            this.Controls.Add(this.lbtitle);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Notification";
            this.Size = new System.Drawing.Size(355, 100);
            this.Load += new System.EventHandler(this.Notification_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.Label lbmessage;
    }
}
