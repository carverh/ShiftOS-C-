namespace ShiftOS
{
    partial class IconWidget
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
            this.panel1 = new ShiftUI.Panel();
            this.pblarge = new ShiftUI.PictureBox();
            this.lbname = new ShiftUI.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblarge)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.panel1.Widgets.Add(this.pblarge);
            this.panel1.Widgets.Add(this.lbname);
            this.panel1.Dock = ShiftUI.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 56);
            this.panel1.TabIndex = 0;
            // 
            // pblarge
            // 
            this.pblarge.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.pblarge.Location = new System.Drawing.Point(135, 3);
            this.pblarge.Name = "pblarge";
            this.pblarge.Size = new System.Drawing.Size(32, 32);
            this.pblarge.SizeMode = ShiftUI.PictureBoxSizeMode.CenterImage;
            this.pblarge.TabIndex = 2;
            this.pblarge.TabStop = false;
            this.pblarge.Click += new System.EventHandler(this.pblarge_Click);
            // 
            // lbname
            // 
            this.lbname.Cursor = ShiftUI.Cursors.IBeam;
            this.lbname.Dock = ShiftUI.DockStyle.Left;
            this.lbname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbname.Location = new System.Drawing.Point(0, 0);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(154, 54);
            this.lbname.TabIndex = 0;
            this.lbname.Text = "Icon Name";
            this.lbname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IconWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.Widgets.Add(this.panel1);
            this.Name = "IconWidget";
            this.Size = new System.Drawing.Size(171, 56);
            this.Load += new System.EventHandler(this.IconWidget_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pblarge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.Panel panel1;
        private ShiftUI.Label lbname;
        private ShiftUI.PictureBox pblarge;
    }
}
