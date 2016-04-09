using System;

namespace ShiftOS
{
    partial class Terminal
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
            this.components = new System.ComponentModel.Container();
            this.txtterm = new System.Windows.Forms.TextBox();
            this.tmrfirstrun = new System.Windows.Forms.Timer(this.components);
            this.tmrshutdown = new System.Windows.Forms.Timer(this.components);
            this.pullbs = new System.Windows.Forms.Timer(this.components);
            this.pullbottom = new System.Windows.Forms.Timer(this.components);
            this.pullside = new System.Windows.Forms.Timer(this.components);
            this.tmrstorylineupdate = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.tmrsetfont = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtterm
            // 
            this.txtterm.BackColor = System.Drawing.Color.Black;
            this.txtterm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtterm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtterm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtterm.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtterm.ForeColor = System.Drawing.Color.White;
            this.txtterm.Location = new System.Drawing.Point(0, 0);
            this.txtterm.Multiline = true;
            this.txtterm.Name = "txtterm";
            this.txtterm.Size = new System.Drawing.Size(650, 396);
            this.txtterm.TabIndex = 0;
            this.txtterm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ScrollDeactivate);
            this.txtterm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScrollTerm);
            // 
            // tmrfirstrun
            // 
            this.tmrfirstrun.Interval = 1000;
            // 
            // pullbs
            // 
            this.pullbs.Interval = 1;
            // 
            // pullbottom
            // 
            this.pullbottom.Interval = 1;
            // 
            // pullside
            // 
            this.pullside.Interval = 1;
            // 
            // tmrstorylineupdate
            // 
            this.tmrstorylineupdate.Interval = 1000;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtterm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 396);
            this.panel2.TabIndex = 3;
            // 
            // tmrsetfont
            // 
            this.tmrsetfont.Tick += new System.EventHandler(this.tmrsetfont_Tick);
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(650, 396);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "Terminal";
            this.Text = "Terminal";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Terminal_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.TextBox txtterm;
        internal System.Windows.Forms.Timer tmrfirstrun;
        internal System.Windows.Forms.Timer tmrshutdown;
        internal System.Windows.Forms.Timer pullbs;
        internal System.Windows.Forms.Timer pullbottom;
        internal System.Windows.Forms.Timer pullside;
        internal System.Windows.Forms.Timer tmrstorylineupdate;

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer tmrsetfont;
    }
}