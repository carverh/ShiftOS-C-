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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlscroll = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.Button();
            this.lbcreditstext = new System.Windows.Forms.Label();
            this.lbgametitle = new System.Windows.Forms.Label();
            this.tmrredraw = new System.Windows.Forms.Timer(this.components);
            this.pgcontents = new System.Windows.Forms.Panel();
            this.lblcountdown = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.Panel();
            this.paddleHuman = new System.Windows.Forms.PictureBox();
            this.paddleComputer = new System.Windows.Forms.Panel();
            this.lbllevelandtime = new System.Windows.Forms.Label();
            this.lblstatsY = new System.Windows.Forms.Label();
            this.lblstatsX = new System.Windows.Forms.Label();
            this.pongGameTimer = new System.Windows.Forms.Timer(this.components);
            this.counter = new System.Windows.Forms.Timer(this.components);
            this.tmrcountdown = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.pnlscroll.SuspendLayout();
            this.pgcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paddleHuman)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlscroll);
            this.panel1.Controls.Add(this.lbgametitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 528);
            this.panel1.TabIndex = 0;
            // 
            // pnlscroll
            // 
            this.pnlscroll.Controls.Add(this.btnclose);
            this.pnlscroll.Controls.Add(this.lbcreditstext);
            this.pnlscroll.Controls.Add(this.pgcontents);
            this.pnlscroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlscroll.Location = new System.Drawing.Point(0, 66);
            this.pnlscroll.Name = "pnlscroll";
            this.pnlscroll.Size = new System.Drawing.Size(916, 462);
            this.pnlscroll.TabIndex = 1;
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.AutoSize = true;
            this.btnclose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.lbgametitle.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.pgcontents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pgcontents.BackColor = System.Drawing.Color.Black;
            this.pgcontents.Controls.Add(this.lblcountdown);
            this.pgcontents.Controls.Add(this.ball);
            this.pgcontents.Controls.Add(this.paddleHuman);
            this.pgcontents.Controls.Add(this.paddleComputer);
            this.pgcontents.Controls.Add(this.lbllevelandtime);
            this.pgcontents.Controls.Add(this.lblstatsY);
            this.pgcontents.Controls.Add(this.lblstatsX);
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
            this.paddleComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paddleComputer.BackColor = System.Drawing.Color.Gray;
            this.paddleComputer.Location = new System.Drawing.Point(666, 134);
            this.paddleComputer.MaximumSize = new System.Drawing.Size(20, 100);
            this.paddleComputer.Name = "paddleComputer";
            this.paddleComputer.Size = new System.Drawing.Size(20, 100);
            this.paddleComputer.TabIndex = 1;
            // 
            // lbllevelandtime
            // 
            this.lbllevelandtime.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.lblstatsY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lblstatsX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(916, 528);
            this.Controls.Add(this.panel1);
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

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlscroll;
        private System.Windows.Forms.Label lbcreditstext;
        private System.Windows.Forms.Label lbgametitle;
        private System.Windows.Forms.Timer tmrredraw;
        private System.Windows.Forms.Button btnclose;
        internal System.Windows.Forms.Panel pgcontents;
        internal System.Windows.Forms.Label lblcountdown;
        internal System.Windows.Forms.Panel ball;
        internal System.Windows.Forms.PictureBox paddleHuman;
        internal System.Windows.Forms.Panel paddleComputer;
        internal System.Windows.Forms.Label lbllevelandtime;
        internal System.Windows.Forms.Label lblstatsY;
        internal System.Windows.Forms.Label lblstatsX;
        internal System.Windows.Forms.Timer pongGameTimer;
        internal System.Windows.Forms.Timer counter;
        internal System.Windows.Forms.Timer tmrcountdown;
    }
}