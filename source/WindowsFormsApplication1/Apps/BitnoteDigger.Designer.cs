using System;

namespace ShiftOS
{
    partial class BitnoteDigger
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
            this.pgcontents = new System.Windows.Forms.Panel();
            this.Label10 = new System.Windows.Forms.Label();
            this.btnsend = new System.Windows.Forms.Button();
            this.txtsendaddress = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.lbltotalbitcoinsmined = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.turbomodespeed = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.lbldiggerstatsspeed = new System.Windows.Forms.Label();
            this.lbldiggerstatsgrade = new System.Windows.Forms.Label();
            this.lbldiggerstatsname = new System.Windows.Forms.Label();
            this.btnturbomode = new System.Windows.Forms.Button();
            this.btnstop = new System.Windows.Forms.Button();
            this.btnstart = new System.Windows.Forms.Button();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.tmrcalcbitnotesmined = new System.Windows.Forms.Timer(this.components);
            this.tmrturbomode = new System.Windows.Forms.Timer(this.components);
            this.btnupgrade = new System.Windows.Forms.Button();
            this.pgcontents.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pgcontents
            // 
            this.pgcontents.BackColor = System.Drawing.Color.White;
            this.pgcontents.Controls.Add(this.Label10);
            this.pgcontents.Controls.Add(this.btnsend);
            this.pgcontents.Controls.Add(this.txtsendaddress);
            this.pgcontents.Controls.Add(this.Label7);
            this.pgcontents.Controls.Add(this.lbltotalbitcoinsmined);
            this.pgcontents.Controls.Add(this.Panel1);
            this.pgcontents.Controls.Add(this.Label1);
            this.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(0, 0);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(560, 297);
            this.pgcontents.TabIndex = 20;
            // 
            // Label10
            // 
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(205, 182);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(261, 35);
            this.Label10.TabIndex = 6;
            this.Label10.Text = "Insert your Bitnote wallet address above then click send to transfer your earning" +
    "s";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnsend
            // 
            this.btnsend.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnsend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsend.Location = new System.Drawing.Point(472, 181);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(73, 36);
            this.btnsend.TabIndex = 5;
            this.btnsend.Text = "Send";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // txtsendaddress
            // 
            this.txtsendaddress.BackColor = System.Drawing.Color.White;
            this.txtsendaddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsendaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsendaddress.Location = new System.Drawing.Point(205, 155);
            this.txtsendaddress.Multiline = true;
            this.txtsendaddress.Name = "txtsendaddress";
            this.txtsendaddress.Size = new System.Drawing.Size(340, 21);
            this.txtsendaddress.TabIndex = 4;
            this.txtsendaddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(203, 128);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(350, 27);
            this.Label7.TabIndex = 3;
            this.Label7.Text = "Send Bitnotes To:";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotalbitcoinsmined
            // 
            this.lbltotalbitcoinsmined.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalbitcoinsmined.Location = new System.Drawing.Point(206, 57);
            this.lbltotalbitcoinsmined.Name = "lbltotalbitcoinsmined";
            this.lbltotalbitcoinsmined.Size = new System.Drawing.Size(344, 51);
            this.lbltotalbitcoinsmined.TabIndex = 2;
            this.lbltotalbitcoinsmined.Text = "0.00000";
            this.lbltotalbitcoinsmined.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.btnupgrade);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Controls.Add(this.Label8);
            this.Panel1.Controls.Add(this.turbomodespeed);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.lbldiggerstatsspeed);
            this.Panel1.Controls.Add(this.lbldiggerstatsgrade);
            this.Panel1.Controls.Add(this.lbldiggerstatsname);
            this.Panel1.Controls.Add(this.btnturbomode);
            this.Panel1.Controls.Add(this.btnstop);
            this.Panel1.Controls.Add(this.btnstart);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(199, 297);
            this.Panel1.TabIndex = 1;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(2, 88);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(157, 20);
            this.Label6.TabIndex = 13;
            this.Label6.Text = "Turbo Mode Stats:";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(3, 126);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(162, 16);
            this.Label8.TabIndex = 11;
            this.Label8.Text = "Codepoint Cost: 1CP / 10s";
            // 
            // turbomodespeed
            // 
            this.turbomodespeed.AutoSize = true;
            this.turbomodespeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turbomodespeed.Location = new System.Drawing.Point(3, 109);
            this.turbomodespeed.Name = "turbomodespeed";
            this.turbomodespeed.Size = new System.Drawing.Size(183, 16);
            this.turbomodespeed.TabIndex = 10;
            this.turbomodespeed.Text = "Turbo Speed: 0.00002 BTN/S";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(5, 5);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(115, 20);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "Digger Stats:";
            // 
            // lbldiggerstatsspeed
            // 
            this.lbldiggerstatsspeed.AutoSize = true;
            this.lbldiggerstatsspeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldiggerstatsspeed.Location = new System.Drawing.Point(6, 60);
            this.lbldiggerstatsspeed.Name = "lbldiggerstatsspeed";
            this.lbldiggerstatsspeed.Size = new System.Drawing.Size(144, 16);
            this.lbldiggerstatsspeed.TabIndex = 8;
            this.lbldiggerstatsspeed.Text = "Speed: 0.00001 BTN/S";
            // 
            // lbldiggerstatsgrade
            // 
            this.lbldiggerstatsgrade.AutoSize = true;
            this.lbldiggerstatsgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldiggerstatsgrade.Location = new System.Drawing.Point(6, 43);
            this.lbldiggerstatsgrade.Name = "lbldiggerstatsgrade";
            this.lbldiggerstatsgrade.Size = new System.Drawing.Size(103, 16);
            this.lbldiggerstatsgrade.TabIndex = 7;
            this.lbldiggerstatsgrade.Text = "Digger Grade: 1";
            // 
            // lbldiggerstatsname
            // 
            this.lbldiggerstatsname.AutoSize = true;
            this.lbldiggerstatsname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldiggerstatsname.Location = new System.Drawing.Point(6, 26);
            this.lbldiggerstatsname.Name = "lbldiggerstatsname";
            this.lbldiggerstatsname.Size = new System.Drawing.Size(157, 16);
            this.lbldiggerstatsname.TabIndex = 6;
            this.lbldiggerstatsname.Text = "Name: Surface Scratcher";
            // 
            // btnturbomode
            // 
            this.btnturbomode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnturbomode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnturbomode.Location = new System.Drawing.Point(6, 188);
            this.btnturbomode.Name = "btnturbomode";
            this.btnturbomode.Size = new System.Drawing.Size(186, 29);
            this.btnturbomode.TabIndex = 5;
            this.btnturbomode.Text = "Activate Turbo Mode";
            this.btnturbomode.UseVisualStyleBackColor = true;
            this.btnturbomode.Click += new System.EventHandler(this.btnturbomode_Click);
            // 
            // btnstop
            // 
            this.btnstop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstop.Location = new System.Drawing.Point(101, 156);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(91, 29);
            this.btnstop.TabIndex = 4;
            this.btnstop.Text = "Stop";
            this.btnstop.UseVisualStyleBackColor = true;
            this.btnstop.Click += new System.EventHandler(this.btnstop_Click);
            // 
            // btnstart
            // 
            this.btnstart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstart.Location = new System.Drawing.Point(6, 156);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(91, 29);
            this.btnstart.TabIndex = 3;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Black;
            this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.PictureBox1.Location = new System.Drawing.Point(198, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(1, 297);
            this.PictureBox1.TabIndex = 2;
            this.PictureBox1.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(205, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(345, 43);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Bitnotes Found";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrcalcbitnotesmined
            // 
            this.tmrcalcbitnotesmined.Interval = 1000;
            this.tmrcalcbitnotesmined.Tick += new System.EventHandler(this.tmrcalcbitnotesmined_Tick);
            // 
            // tmrturbomode
            // 
            this.tmrturbomode.Interval = 10000;
            this.tmrturbomode.Tick += new System.EventHandler(this.tmrturbomode_Tick);
            // 
            // btnupgrade
            // 
            this.btnupgrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupgrade.Location = new System.Drawing.Point(6, 223);
            this.btnupgrade.Name = "btnupgrade";
            this.btnupgrade.Size = new System.Drawing.Size(186, 29);
            this.btnupgrade.TabIndex = 14;
            this.btnupgrade.Text = "Upgrade My Digger";
            this.btnupgrade.UseVisualStyleBackColor = true;
            this.btnupgrade.Click += new System.EventHandler(this.btnupgrade_Click);
            // 
            // BitnoteDigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 297);
            this.Controls.Add(this.pgcontents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BitnoteDigger";
            this.Text = "Bitnote_Digger";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BitnoteDigger_Load);
            this.pgcontents.ResumeLayout(false);
            this.pgcontents.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Panel pgcontents;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lbltotalbitcoinsmined;
        internal System.Windows.Forms.Button btnturbomode;
        internal System.Windows.Forms.Button btnstop;
        internal System.Windows.Forms.Button btnstart;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label turbomodespeed;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label lbldiggerstatsspeed;
        internal System.Windows.Forms.Label lbldiggerstatsgrade;
        internal System.Windows.Forms.Label lbldiggerstatsname;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Button btnsend;
        internal System.Windows.Forms.TextBox txtsendaddress;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Timer tmrcalcbitnotesmined;
        internal System.Windows.Forms.Timer tmrturbomode;
        internal System.Windows.Forms.Button btnupgrade;
    }
}