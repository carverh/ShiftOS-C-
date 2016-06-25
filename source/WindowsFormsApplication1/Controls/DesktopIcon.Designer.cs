namespace ShiftOS
{
    partial class DesktopIcon
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
            this.pbicon = new System.Windows.Forms.PictureBox();
            this.lbiconname = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbicon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbicon
            // 
            this.pbicon.Location = new System.Drawing.Point(4, 4);
            this.pbicon.Name = "pbicon";
            this.pbicon.Size = new System.Drawing.Size(78, 50);
            this.pbicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbicon.TabIndex = 0;
            this.pbicon.TabStop = false;
            this.pbicon.DoubleClick += new System.EventHandler(this.Icon_Click);
            // 
            // lbiconname
            // 
            this.lbiconname.AutoEllipsis = true;
            this.lbiconname.ForeColor = System.Drawing.Color.White;
            this.lbiconname.Location = new System.Drawing.Point(4, 61);
            this.lbiconname.Name = "lbiconname";
            this.lbiconname.Size = new System.Drawing.Size(78, 23);
            this.lbiconname.TabIndex = 1;
            this.lbiconname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbiconname.DoubleClick += new System.EventHandler(this.Icon_Click);
            // 
            // DesktopIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbiconname);
            this.Controls.Add(this.pbicon);
            this.Name = "DesktopIcon";
            this.Size = new System.Drawing.Size(85, 85);
            this.Load += new System.EventHandler(this.DesktopIcon_Load);
            this.DoubleClick += new System.EventHandler(this.Icon_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbicon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbicon;
        private System.Windows.Forms.Label lbiconname;
    }
}
