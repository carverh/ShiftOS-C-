using System;

namespace ShiftOS
{
    partial class WindowBorder
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
            this.pgleft = new ShiftUI.Panel();
            this.pgbottomlcorner = new ShiftUI.Panel();
            this.pgright = new ShiftUI.Panel();
            this.pgbottomrcorner = new ShiftUI.Panel();
            this.titlebar = new ShiftUI.Panel();
            this.minimizebutton = new ShiftUI.Panel();
            this.pnlicon = new ShiftUI.PictureBox();
            this.rollupbutton = new ShiftUI.Panel();
            this.closebutton = new ShiftUI.Panel();
            this.lbtitletext = new ShiftUI.Label();
            this.pgtoplcorner = new ShiftUI.Panel();
            this.pgtoprcorner = new ShiftUI.Panel();
            this.pgbottom = new ShiftUI.Panel();
            this.pgcontents = new ShiftUI.Panel();
            this.pullbs = new ShiftUI.Timer(this.components);
            this.pullbottom = new ShiftUI.Timer(this.components);
            this.pullside = new ShiftUI.Timer(this.components);
            this.pgleft.SuspendLayout();
            this.pgright.SuspendLayout();
            this.titlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlicon)).BeginInit();
            this.SuspendLayout();
            // 
            // pgleft
            // 
            this.pgleft.BackColor = System.Drawing.Color.Gray;
            this.pgleft.Widgets.Add(this.pgbottomlcorner);
            this.pgleft.Dock = ShiftUI.DockStyle.Left;
            this.pgleft.Location = new System.Drawing.Point(0, 30);
            this.pgleft.Name = "pgleft";
            this.pgleft.Size = new System.Drawing.Size(2, 345);
            this.pgleft.TabIndex = 16;
            this.pgleft.MouseDown += new ShiftUI.MouseEventHandler(this.Rightpull_MouseDown);
            this.pgleft.MouseEnter += new System.EventHandler(this.RightCursorOn_MouseDown);
            this.pgleft.MouseLeave += new System.EventHandler(this.SizeCursoroff_MouseDown);
            this.pgleft.MouseUp += new ShiftUI.MouseEventHandler(this.rightpull_MouseUp);
            // 
            // pgbottomlcorner
            // 
            this.pgbottomlcorner.BackColor = System.Drawing.Color.Red;
            this.pgbottomlcorner.Dock = ShiftUI.DockStyle.Bottom;
            this.pgbottomlcorner.Location = new System.Drawing.Point(0, 343);
            this.pgbottomlcorner.Name = "pgbottomlcorner";
            this.pgbottomlcorner.Size = new System.Drawing.Size(2, 2);
            this.pgbottomlcorner.TabIndex = 14;
            this.pgbottomlcorner.MouseDown += new ShiftUI.MouseEventHandler(this.bspull_MouseDown);
            this.pgbottomlcorner.MouseEnter += new System.EventHandler(this.CornerCursorOn_MouseDown);
            this.pgbottomlcorner.MouseLeave += new System.EventHandler(this.SizeCursoroff_MouseDown);
            this.pgbottomlcorner.MouseUp += new ShiftUI.MouseEventHandler(this.bspull_MouseUp);
            // 
            // pgright
            // 
            this.pgright.BackColor = System.Drawing.Color.Gray;
            this.pgright.Widgets.Add(this.pgbottomrcorner);
            this.pgright.Dock = ShiftUI.DockStyle.Right;
            this.pgright.Location = new System.Drawing.Point(545, 30);
            this.pgright.Name = "pgright";
            this.pgright.Size = new System.Drawing.Size(2, 345);
            this.pgright.TabIndex = 17;
            this.pgright.MouseDown += new ShiftUI.MouseEventHandler(this.Rightpull_MouseDown);
            this.pgright.MouseEnter += new System.EventHandler(this.RightCursorOn_MouseDown);
            this.pgright.MouseLeave += new System.EventHandler(this.SizeCursoroff_MouseDown);
            this.pgright.MouseUp += new ShiftUI.MouseEventHandler(this.rightpull_MouseUp);
            // 
            // pgbottomrcorner
            // 
            this.pgbottomrcorner.BackColor = System.Drawing.Color.Red;
            this.pgbottomrcorner.Dock = ShiftUI.DockStyle.Bottom;
            this.pgbottomrcorner.Location = new System.Drawing.Point(0, 343);
            this.pgbottomrcorner.Name = "pgbottomrcorner";
            this.pgbottomrcorner.Size = new System.Drawing.Size(2, 2);
            this.pgbottomrcorner.TabIndex = 15;
            this.pgbottomrcorner.MouseDown += new ShiftUI.MouseEventHandler(this.bspull_MouseDown);
            this.pgbottomrcorner.MouseEnter += new System.EventHandler(this.CornerCursorOn_MouseDown);
            this.pgbottomrcorner.MouseLeave += new System.EventHandler(this.SizeCursoroff_MouseDown);
            this.pgbottomrcorner.MouseUp += new ShiftUI.MouseEventHandler(this.bspull_MouseUp);
            // 
            // titlebar
            // 
            this.titlebar.BackColor = System.Drawing.Color.Gray;
            this.titlebar.Widgets.Add(this.minimizebutton);
            this.titlebar.Widgets.Add(this.pnlicon);
            this.titlebar.Widgets.Add(this.rollupbutton);
            this.titlebar.Widgets.Add(this.closebutton);
            this.titlebar.Widgets.Add(this.lbtitletext);
            this.titlebar.Widgets.Add(this.pgtoplcorner);
            this.titlebar.Widgets.Add(this.pgtoprcorner);
            this.titlebar.Dock = ShiftUI.DockStyle.Top;
            this.titlebar.ForeColor = System.Drawing.Color.White;
            this.titlebar.Location = new System.Drawing.Point(0, 0);
            this.titlebar.Name = "titlebar";
            this.titlebar.Size = new System.Drawing.Size(547, 30);
            this.titlebar.TabIndex = 14;
            this.titlebar.MouseDown += new ShiftUI.MouseEventHandler(this.titlebar_MouseDown);
            this.titlebar.MouseMove += new ShiftUI.MouseEventHandler(this.titlebar_MouseMove);
            this.titlebar.MouseUp += new ShiftUI.MouseEventHandler(this.titlebar_MouseUp);
            // 
            // minimizebutton
            // 
            this.minimizebutton.BackColor = System.Drawing.Color.Black;
            this.minimizebutton.Location = new System.Drawing.Point(246, 5);
            this.minimizebutton.Name = "minimizebutton";
            this.minimizebutton.Size = new System.Drawing.Size(22, 22);
            this.minimizebutton.TabIndex = 24;
            this.minimizebutton.Click += new System.EventHandler(this.minimizebutton_Click);
            // 
            // pnlicon
            // 
            this.pnlicon.BackColor = System.Drawing.Color.Transparent;
            this.pnlicon.Location = new System.Drawing.Point(8, 8);
            this.pnlicon.Name = "pnlicon";
            this.pnlicon.Size = new System.Drawing.Size(16, 16);
            this.pnlicon.SizeMode = ShiftUI.PictureBoxSizeMode.StretchImage;
            this.pnlicon.TabIndex = 24;
            this.pnlicon.TabStop = false;
            this.pnlicon.Visible = false;
            // 
            // rollupbutton
            // 
            this.rollupbutton.BackColor = System.Drawing.Color.Black;
            this.rollupbutton.Location = new System.Drawing.Point(274, 3);
            this.rollupbutton.Name = "rollupbutton";
            this.rollupbutton.Size = new System.Drawing.Size(22, 22);
            this.rollupbutton.TabIndex = 22;
            this.rollupbutton.Click += new System.EventHandler(this.rollupbutton_Click);
            // 
            // closebutton
            // 
            this.closebutton.BackColor = System.Drawing.Color.Black;
            this.closebutton.Location = new System.Drawing.Point(302, 3);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(22, 22);
            this.closebutton.TabIndex = 20;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // lbtitletext
            // 
            this.lbtitletext.AutoSize = true;
            this.lbtitletext.BackColor = System.Drawing.Color.Transparent;
            this.lbtitletext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtitletext.Location = new System.Drawing.Point(26, 7);
            this.lbtitletext.Name = "lbtitletext";
            this.lbtitletext.Size = new System.Drawing.Size(77, 18);
            this.lbtitletext.TabIndex = 19;
            this.lbtitletext.Text = "Template";
            this.lbtitletext.MouseDown += new ShiftUI.MouseEventHandler(this.titlebar_MouseDown);
            this.lbtitletext.MouseMove += new ShiftUI.MouseEventHandler(this.titlebar_MouseMove);
            this.lbtitletext.MouseUp += new ShiftUI.MouseEventHandler(this.titlebar_MouseUp);
            // 
            // pgtoplcorner
            // 
            this.pgtoplcorner.BackColor = System.Drawing.Color.Red;
            this.pgtoplcorner.Dock = ShiftUI.DockStyle.Left;
            this.pgtoplcorner.Location = new System.Drawing.Point(0, 0);
            this.pgtoplcorner.Name = "pgtoplcorner";
            this.pgtoplcorner.Size = new System.Drawing.Size(2, 30);
            this.pgtoplcorner.TabIndex = 17;
            // 
            // pgtoprcorner
            // 
            this.pgtoprcorner.BackColor = System.Drawing.Color.Red;
            this.pgtoprcorner.Dock = ShiftUI.DockStyle.Right;
            this.pgtoprcorner.Location = new System.Drawing.Point(545, 0);
            this.pgtoprcorner.Name = "pgtoprcorner";
            this.pgtoprcorner.Size = new System.Drawing.Size(2, 30);
            this.pgtoprcorner.TabIndex = 16;
            // 
            // pgbottom
            // 
            this.pgbottom.BackColor = System.Drawing.Color.Gray;
            this.pgbottom.Dock = ShiftUI.DockStyle.Bottom;
            this.pgbottom.Location = new System.Drawing.Point(2, 373);
            this.pgbottom.Name = "pgbottom";
            this.pgbottom.Size = new System.Drawing.Size(543, 2);
            this.pgbottom.TabIndex = 18;
            this.pgbottom.MouseDown += new ShiftUI.MouseEventHandler(this.bottompull_MouseDown);
            this.pgbottom.MouseEnter += new System.EventHandler(this.bottomCursorOn_MouseDown);
            this.pgbottom.MouseLeave += new System.EventHandler(this.SizeCursoroff_MouseDown);
            this.pgbottom.MouseUp += new ShiftUI.MouseEventHandler(this.bottompull_MouseUp);
            // 
            // pgcontents
            // 
            this.pgcontents.Dock = ShiftUI.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(2, 30);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(543, 343);
            this.pgcontents.TabIndex = 15;
            // 
            // pullbs
            // 
            this.pullbs.Interval = 1;
            this.pullbs.Tick += new System.EventHandler(this.pullbs_Tick);
            // 
            // pullbottom
            // 
            this.pullbottom.Interval = 1;
            this.pullbottom.Tick += new System.EventHandler(this.pullbottom_Tick);
            // 
            // pullside
            // 
            this.pullside.Interval = 1;
            this.pullside.Tick += new System.EventHandler(this.pullside_Tick);
            // 
            // WindowBorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.Widgets.Add(this.pgcontents);
            this.Widgets.Add(this.pgbottom);
            this.Widgets.Add(this.pgright);
            this.Widgets.Add(this.pgleft);
            this.Widgets.Add(this.titlebar);
            this.Name = "WindowBorder";
            this.Size = new System.Drawing.Size(547, 375);
            this.Load += new System.EventHandler(this.Template_Load);
            this.pgleft.ResumeLayout(false);
            this.pgright.ResumeLayout(false);
            this.titlebar.ResumeLayout(false);
            this.titlebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlicon)).EndInit();
            this.ResumeLayout(false);

        }
        internal ShiftUI.Panel pgleft;
        internal ShiftUI.Panel pgbottomlcorner;
        internal ShiftUI.Panel pgright;
        internal ShiftUI.Panel pgbottomrcorner;
        internal ShiftUI.Panel titlebar;
        internal ShiftUI.Panel pgtoplcorner;
        internal ShiftUI.Panel pgtoprcorner;
        internal ShiftUI.Panel pgbottom;
        internal ShiftUI.Panel pgcontents;
        internal ShiftUI.Label lbtitletext;
        internal ShiftUI.Panel closebutton;
        internal ShiftUI.Panel rollupbutton;
        internal ShiftUI.PictureBox pnlicon;
        internal ShiftUI.Panel minimizebutton;
        internal ShiftUI.Timer pullbs;
        internal ShiftUI.Timer pullbottom;
        internal ShiftUI.Timer pullside;

    }
}
