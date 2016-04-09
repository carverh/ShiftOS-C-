namespace ShiftOS
{
    partial class IconControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pblarge = new System.Windows.Forms.PictureBox();
            this.lbname = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblarge)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pblarge);
            this.panel1.Controls.Add(this.lbname);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 56);
            this.panel1.TabIndex = 0;
            // 
            // pblarge
            // 
            this.pblarge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pblarge.Location = new System.Drawing.Point(135, 3);
            this.pblarge.Name = "pblarge";
            this.pblarge.Size = new System.Drawing.Size(32, 32);
            this.pblarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pblarge.TabIndex = 2;
            this.pblarge.TabStop = false;
            this.pblarge.Click += new System.EventHandler(this.pblarge_Click);
            // 
            // lbname
            // 
            this.lbname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbname.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbname.Location = new System.Drawing.Point(0, 0);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(154, 54);
            this.lbname.TabIndex = 0;
            this.lbname.Text = "Icon Name";
            this.lbname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IconControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "IconControl";
            this.Size = new System.Drawing.Size(171, 56);
            this.Load += new System.EventHandler(this.IconControl_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pblarge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbname;
        private System.Windows.Forms.PictureBox pblarge;
    }
}
