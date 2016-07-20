namespace ShiftOS
{
    partial class CreditScroller
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
            this.panel1 = new ShiftUI.Panel();
            this.pnlscroll = new ShiftUI.Panel();
            this.btnclose = new ShiftUI.Button();
            this.lbcreditstext = new ShiftUI.Label();
            this.lbgametitle = new ShiftUI.Label();
            this.tmrredraw = new ShiftUI.Timer(this.components);
            this.pgcontents = new ShiftUI.Panel();
            this.lblcountdown = new ShiftUI.Label();
            this.ball = new ShiftUI.Panel();
            this.paddleHuman = new ShiftUI.PictureBox();
            this.paddleComputer = new ShiftUI.Panel();
            this.lbllevelandtime = new ShiftUI.Label();
            this.lblstatsY = new ShiftUI.Label();
            this.lblstatsX = new ShiftUI.Label();
            this.pongGameTimer = new ShiftUI.Timer(this.components);
            this.counter = new ShiftUI.Timer(this.components);
            this.tmrcountdown = new ShiftUI.Timer(this.components);
            this.panel1.SuspendLayout();
            this.pnlscroll.SuspendLayout();
            this.pgcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paddleHuman)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Widgets.Add(this.pnlscroll);
            this.panel1.Widgets.Add(this.lbgametitle);
            this.panel1.Dock = ShiftUI.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 528);
            this.panel1.TabIndex = 0;
            // 
            // pnlscroll
            // 
            this.pnlscroll.Widgets.Add(this.btnclose);
            this.pnlscroll.Widgets.Add(this.lbcreditstext);
            this.pnlscroll.Widgets.Add(this.pgcontents);
            this.pnlscroll.Dock = ShiftUI.DockStyle.Fill;
            this.pnlscroll.Location = new System.Drawing.Point(0, 66);
            this.pnlscroll.Name = "pnlscroll";
            this.pnlscroll.Size = new System.Drawing.Size(916, 462);
            this.pnlscroll.TabIndex = 1;
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.btnclose.AutoSize = true;
            this.btnclose.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btnclose.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnclose.Location = new System.Drawing.Point(843, 418);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(61, 32);
            this.btnclose.TabIndex = 1;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // lbcreditstext
            // 
            this.lbcreditstext.AutoSize = true;
            this.lbcreditstext.BackColor = System.Drawing.Color.Transparent;
            this.lbcreditstext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lbcreditstext.Location = new System.Drawing.Point(0, 138);
            this.lbcreditstext.MaximumSize = new System.Drawing.Size(916, 0);
            this.lbcreditstext.Name = "lbcreditstext";
            this.lbcreditstext.Size = new System.Drawing.Size(0, 25);
            this.lbcreditstext.TabIndex = 0;
            this.lbcreditstext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbgametitle
            // 
            this.lbgametitle.Dock = ShiftUI.DockStyle.Top;
            this.lbgametitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lbgametitle.Location = new System.Drawing.Point(0, 0);
            this.lbgametitle.Name = "lbgametitle";
            this.lbgametitle.Size = new System.Drawing.Size(916, 66);
            this.lbgametitle.TabIndex = 0;
            this.lbgametitle.Text = "ShiftOS Credits";
            this.lbgametitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrredraw
            // 
            this.tmrredraw.Enabled = true;
            this.tmrredraw.Tick += new System.EventHandler(this.tmrredraw_Tick);
            // 
            // pgcontents
            // 
            this.pgcontents.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.pgcontents.BackColor = System.Drawing.Color.Black;
            this.pgcontents.Widgets.Add(this.lblcountdown);
            this.pgcontents.Widgets.Add(this.ball);
            this.pgcontents.Widgets.Add(this.paddleHuman);
            this.pgcontents.Widgets.Add(this.paddleComputer);
            this.pgcontents.Widgets.Add(this.lbllevelandtime);
            this.pgcontents.Widgets.Add(this.lblstatsY);
            this.pgcontents.Widgets.Add(this.lblstatsX);
            this.pgcontents.ForeColor = System.Drawing.Color.Gray;
            this.pgcontents.Location = new System.Drawing.Point(0, 0);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(700, 400);
            this.pgcontents.TabIndex = 21;
            // 
            // lblcountdown
            // 
            this.lblcountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcountdown.Location = new System.Drawing.Point(187, 152);
            this.lblcountdown.Name = "lblcountdown";
            this.lblcountdown.Size = new System.Drawing.Size(315, 49);
            this.lblcountdown.TabIndex = 7;
            this.lblcountdown.Text = "3";
            this.lblcountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblcountdown.Visible = false;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Gray;
            this.ball.Location = new System.Drawing.Point(300, 152);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(20, 20);
            this.ball.TabIndex = 2;
            // 
            // paddleHuman
            // 
            this.paddleHuman.BackColor = System.Drawing.Color.Gray;
            this.paddleHuman.Location = new System.Drawing.Point(10, 134);
            this.paddleHuman.Name = "paddleHuman";
            this.paddleHuman.Size = new System.Drawing.Size(20, 100);
            this.paddleHuman.TabIndex = 3;
            this.paddleHuman.TabStop = false;
            // 
            // paddleComputer
            // 
            this.paddleComputer.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Right)));
            this.paddleComputer.BackColor = System.Drawing.Color.Gray;
            this.paddleComputer.Location = new System.Drawing.Point(666, 134);
            this.paddleComputer.MaximumSize = new System.Drawing.Size(20, 100);
            this.paddleComputer.Name = "paddleComputer";
            this.paddleComputer.Size = new System.Drawing.Size(20, 100);
            this.paddleComputer.TabIndex = 1;
            // 
            // lbllevelandtime
            // 
            this.lbllevelandtime.Dock = ShiftUI.DockStyle.Top;
            this.lbllevelandtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllevelandtime.Location = new System.Drawing.Point(0, 0);
            this.lbllevelandtime.Name = "lbllevelandtime";
            this.lbllevelandtime.Size = new System.Drawing.Size(700, 22);
            this.lbllevelandtime.TabIndex = 4;
            this.lbllevelandtime.Text = "Level: 1";
            this.lbllevelandtime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblstatsY
            // 
            this.lblstatsY.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.lblstatsY.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatsY.Location = new System.Drawing.Point(542, 356);
            this.lblstatsY.Name = "lblstatsY";
            this.lblstatsY.Size = new System.Drawing.Size(144, 35);
            this.lblstatsY.TabIndex = 11;
            this.lblstatsY.Text = "Yspeed:";
            this.lblstatsY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblstatsX
            // 
            this.lblstatsX.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.lblstatsX.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatsX.Location = new System.Drawing.Point(3, 356);
            this.lblstatsX.Name = "lblstatsX";
            this.lblstatsX.Size = new System.Drawing.Size(144, 35);
            this.lblstatsX.TabIndex = 5;
            this.lblstatsX.Text = "Xspeed: ";
            this.lblstatsX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pongGameTimer
            // 
            this.pongGameTimer.Interval = 30;
            this.pongGameTimer.Tick += new System.EventHandler(this.pongGameTimer_Tick);
            // 
            // counter
            // 
            this.counter.Interval = 1000;
            this.counter.Tick += new System.EventHandler(this.counter_Tick);
            // 
            // tmrcountdown
            // 
            this.tmrcountdown.Interval = 1000;
            this.tmrcountdown.Tick += new System.EventHandler(this.tmrcountdown_Tick);
            // 
            // CreditScroller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(916, 528);
            this.Widgets.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "CreditScroller";
            this.Text = "CreditScroller";
            this.Load += new System.EventHandler(this.CreditScroller_Load);
            this.panel1.ResumeLayout(false);
            this.pnlscroll.ResumeLayout(false);
            this.pnlscroll.PerformLayout();
            this.pgcontents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paddleHuman)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.Panel panel1;
        private ShiftUI.Panel pnlscroll;
        private ShiftUI.Label lbcreditstext;
        private ShiftUI.Label lbgametitle;
        private ShiftUI.Timer tmrredraw;
        private ShiftUI.Button btnclose;
        internal ShiftUI.Panel pgcontents;
        internal ShiftUI.Label lblcountdown;
        internal ShiftUI.Panel ball;
        internal ShiftUI.PictureBox paddleHuman;
        internal ShiftUI.Panel paddleComputer;
        internal ShiftUI.Label lbllevelandtime;
        internal ShiftUI.Label lblstatsY;
        internal ShiftUI.Label lblstatsX;
        internal ShiftUI.Timer pongGameTimer;
        internal ShiftUI.Timer counter;
        internal ShiftUI.Timer tmrcountdown;
    }
}