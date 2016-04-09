using System;

namespace ShiftOS
{
    partial class Template
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Load += new EventHandler(this.Template_Load);
            this.pgleft = new System.Windows.Forms.Panel();
            this.pgbottomlcorner = new System.Windows.Forms.Panel();
            this.pgright = new System.Windows.Forms.Panel();
            this.pgbottomrcorner = new System.Windows.Forms.Panel();
            this.titlebar = new System.Windows.Forms.Panel();
            this.minimizebutton = new System.Windows.Forms.Panel();
            this.pnlicon = new System.Windows.Forms.PictureBox();
            this.rollupbutton = new System.Windows.Forms.Panel();
            this.closebutton = new System.Windows.Forms.Panel();
            this.lbtitletext = new System.Windows.Forms.Label();
            this.pgtoplcorner = new System.Windows.Forms.Panel();
            this.pgtoprcorner = new System.Windows.Forms.Panel();
            this.pgbottom = new System.Windows.Forms.Panel();
            this.pgcontents = new System.Windows.Forms.Panel();
            this.pullbs = new System.Windows.Forms.Timer(this.components);
            this.pullbottom = new System.Windows.Forms.Timer(this.components);
            this.pullside = new System.Windows.Forms.Timer(this.components);
            this.pgleft.SuspendLayout();
            this.pgright.SuspendLayout();
            this.titlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlicon)).BeginInit();
            this.SuspendLayout();
            // 
            // pgleft
            // 
            this.pgleft.BackColor = System.Drawing.Color.Gray;
            this.pgleft.Controls.Add(this.pgbottomlcorner);
            this.pgleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pgleft.Location = new System.Drawing.Point(0, 30);
            this.pgleft.Name = "pgleft";
            this.pgleft.Size = new System.Drawing.Size(2, 345);
            this.pgleft.TabIndex = 16;
            // 
            // pgbottomlcorner
            // 
            this.pgbottomlcorner.BackColor = System.Drawing.Color.Red;
            this.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbottomlcorner.Location = new System.Drawing.Point(0, 343);
            this.pgbottomlcorner.Name = "pgbottomlcorner";
            this.pgbottomlcorner.Size = new System.Drawing.Size(2, 2);
            this.pgbottomlcorner.TabIndex = 14;
            // 
            // pgright
            // 
            this.pgright.BackColor = System.Drawing.Color.Gray;
            this.pgright.Controls.Add(this.pgbottomrcorner);
            this.pgright.Dock = System.Windows.Forms.DockStyle.Right;
            this.pgright.Location = new System.Drawing.Point(545, 30);
            this.pgright.Name = "pgright";
            this.pgright.Size = new System.Drawing.Size(2, 345);
            this.pgright.TabIndex = 17;
            // 
            // pgbottomrcorner
            // 
            this.pgbottomrcorner.BackColor = System.Drawing.Color.Red;
            this.pgbottomrcorner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbottomrcorner.Location = new System.Drawing.Point(0, 343);
            this.pgbottomrcorner.Name = "pgbottomrcorner";
            this.pgbottomrcorner.Size = new System.Drawing.Size(2, 2);
            this.pgbottomrcorner.TabIndex = 15;
            // 
            // titlebar
            // 
            this.titlebar.BackColor = System.Drawing.Color.Gray;
            this.titlebar.Controls.Add(this.minimizebutton);
            this.titlebar.Controls.Add(this.pnlicon);
            this.titlebar.Controls.Add(this.rollupbutton);
            this.titlebar.Controls.Add(this.closebutton);
            this.titlebar.Controls.Add(this.lbtitletext);
            this.titlebar.Controls.Add(this.pgtoplcorner);
            this.titlebar.Controls.Add(this.pgtoprcorner);
            this.titlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlebar.ForeColor = System.Drawing.Color.White;
            this.titlebar.Location = new System.Drawing.Point(0, 0);
            this.titlebar.Name = "titlebar";
            this.titlebar.Size = new System.Drawing.Size(547, 30);
            this.titlebar.TabIndex = 14;
            // 
            // minimizebutton
            // 
            this.minimizebutton.BackColor = System.Drawing.Color.Black;
            this.minimizebutton.Location = new System.Drawing.Point(246, 5);
            this.minimizebutton.Name = "minimizebutton";
            this.minimizebutton.Size = new System.Drawing.Size(22, 22);
            this.minimizebutton.Click += new EventHandler(this.minimizebutton_Click);
            this.minimizebutton.TabIndex = 24;
            // 
            // pnlicon
            // 
            this.pnlicon.BackColor = System.Drawing.Color.Transparent;
            this.pnlicon.Location = new System.Drawing.Point(8, 8);
            this.pnlicon.Name = "pnlicon";
            this.pnlicon.Size = new System.Drawing.Size(16, 16);
            this.pnlicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pnlicon.TabIndex = 24;
            this.pnlicon.TabStop = false;
            this.pnlicon.Visible = false;
            // 
            // rollupbutton
            // 
            this.rollupbutton.BackColor = System.Drawing.Color.Black;
            this.rollupbutton.Location = new System.Drawing.Point(274, 3);
            this.rollupbutton.Name = "rollupbutton";
            this.rollupbutton.Click += new EventHandler(this.rollupbutton_Click);
            this.rollupbutton.Size = new System.Drawing.Size(22, 22);
            this.rollupbutton.TabIndex = 22;
            // 
            // closebutton
            // 
            this.closebutton.BackColor = System.Drawing.Color.Black;
            this.closebutton.Location = new System.Drawing.Point(302, 3);
            this.closebutton.Name = "closebutton";
            this.closebutton.Click += new EventHandler(this.closebutton_Click);
            this.closebutton.Size = new System.Drawing.Size(22, 22);
            this.closebutton.TabIndex = 20;
            // 
            // lbtitletext
            // 
            this.lbtitletext.AutoSize = true;
            this.lbtitletext.BackColor = System.Drawing.Color.Transparent;
            this.lbtitletext.Font = new System.Drawing.Font("Felix Titling", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtitletext.Location = new System.Drawing.Point(26, 7);
            this.lbtitletext.Name = "lbtitletext";
            this.lbtitletext.Size = new System.Drawing.Size(89, 18);
            this.lbtitletext.TabIndex = 19;
            this.lbtitletext.Text = "Template";
            // 
            // pgtoplcorner
            // 
            this.pgtoplcorner.BackColor = System.Drawing.Color.Red;
            this.pgtoplcorner.Dock = System.Windows.Forms.DockStyle.Left;
            this.pgtoplcorner.Location = new System.Drawing.Point(0, 0);
            this.pgtoplcorner.Name = "pgtoplcorner";
            this.pgtoplcorner.Size = new System.Drawing.Size(2, 30);
            this.pgtoplcorner.TabIndex = 17;
            // 
            // pgtoprcorner
            // 
            this.pgtoprcorner.BackColor = System.Drawing.Color.Red;
            this.pgtoprcorner.Dock = System.Windows.Forms.DockStyle.Right;
            this.pgtoprcorner.Location = new System.Drawing.Point(545, 0);
            this.pgtoprcorner.Name = "pgtoprcorner";
            this.pgtoprcorner.Size = new System.Drawing.Size(2, 30);
            this.pgtoprcorner.TabIndex = 16;
            // 
            // pgbottom
            // 
            this.pgbottom.BackColor = System.Drawing.Color.Gray;
            this.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbottom.Location = new System.Drawing.Point(2, 373);
            this.pgbottom.Name = "pgbottom";
            this.pgbottom.Size = new System.Drawing.Size(543, 2);
            this.pgbottom.TabIndex = 18;
            // 
            // pgcontents
            // 
            this.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(2, 30);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(543, 343);
            this.pgcontents.TabIndex = 15;
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
            // Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 375);
            this.Controls.Add(this.pgcontents);
            this.Controls.Add(this.pgbottom);
            this.Controls.Add(this.pgright);
            this.Controls.Add(this.pgleft);
            this.Controls.Add(this.titlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Template";
            this.Text = "template";
            this.TopMost = true;
            this.pgleft.ResumeLayout(false);
            this.pgright.ResumeLayout(false);
            this.titlebar.ResumeLayout(false);
            this.titlebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlicon)).EndInit();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Panel pgleft;
        internal System.Windows.Forms.Panel pgbottomlcorner;
        internal System.Windows.Forms.Panel pgright;
        internal System.Windows.Forms.Panel pgbottomrcorner;
        internal System.Windows.Forms.Panel titlebar;
        internal System.Windows.Forms.Panel pgtoplcorner;
        internal System.Windows.Forms.Panel pgtoprcorner;
        internal System.Windows.Forms.Panel pgbottom;
        internal System.Windows.Forms.Panel pgcontents;
        internal System.Windows.Forms.Label lbtitletext;
        internal System.Windows.Forms.Panel closebutton;
        internal System.Windows.Forms.Panel rollupbutton;
        internal System.Windows.Forms.PictureBox pnlicon;
        internal System.Windows.Forms.Panel minimizebutton;
        internal System.Windows.Forms.Timer pullbs;
        internal System.Windows.Forms.Timer pullbottom;
        internal System.Windows.Forms.Timer pullside;
    }
}