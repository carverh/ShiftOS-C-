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
            this.txtterm = new ShiftUI.TextBox();
            this.tmrfirstrun = new ShiftUI.Timer(this.components);
            this.tmrshutdown = new ShiftUI.Timer(this.components);
            this.pullbs = new ShiftUI.Timer(this.components);
            this.pullbottom = new ShiftUI.Timer(this.components);
            this.pullside = new ShiftUI.Timer(this.components);
            this.tmrstorylineupdate = new ShiftUI.Timer(this.components);
            this.panel2 = new ShiftUI.Panel();
            this.tmrsetfont = new ShiftUI.Timer(this.components);
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtterm
            // 
            this.txtterm.BackColor = System.Drawing.Color.Black;
            this.txtterm.BorderStyle = ShiftUI.BorderStyle.None;
            this.txtterm.Cursor = ShiftUI.Cursors.IBeam;
            this.txtterm.Dock = ShiftUI.DockStyle.Fill;
            this.txtterm.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtterm.ForeColor = System.Drawing.Color.White;
            this.txtterm.Location = new System.Drawing.Point(0, 0);
            this.txtterm.Multiline = true;
            this.txtterm.Name = "txtterm";
            this.txtterm.Size = new System.Drawing.Size(650, 396);
            this.txtterm.TabIndex = 0;
            this.txtterm.KeyUp += new ShiftUI.KeyEventHandler(this.ScrollDeactivate);
            this.txtterm.MouseMove += new ShiftUI.MouseEventHandler(this.ScrollTerm);
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
            this.panel2.Widgets.Add(this.txtterm);
            this.panel2.Dock = ShiftUI.DockStyle.Fill;
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
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(650, 396);
            this.Widgets.Add(this.panel2);
            this.FormBorderStyle = ShiftUI.FormBorderStyle.None;
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
        internal ShiftUI.TextBox txtterm;
        internal ShiftUI.Timer tmrfirstrun;
        internal ShiftUI.Timer tmrshutdown;
        internal ShiftUI.Timer pullbs;
        internal ShiftUI.Timer pullbottom;
        internal ShiftUI.Timer pullside;
        internal ShiftUI.Timer tmrstorylineupdate;

        #endregion
        private ShiftUI.Panel panel2;
        private ShiftUI.Timer tmrsetfont;
    }
}