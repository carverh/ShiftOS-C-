using System;

namespace Shiftorium
{
    partial class Frontend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frontend));
            this.pgcontents = new System.Windows.Forms.Panel();
            this.lbcodepoints = new System.Windows.Forms.Label();
            this.lbupgrades = new System.Windows.Forms.ListView();
            this.Label1 = new System.Windows.Forms.Label();
            this.pnlinfo = new System.Windows.Forms.Panel();
            this.pnlintro = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnbuy = new System.Windows.Forms.Button();
            this.lbprice = new System.Windows.Forms.Label();
            this.picpreview = new System.Windows.Forms.PictureBox();
            this.lbudescription = new System.Windows.Forms.Label();
            this.lbupgradename = new System.Windows.Forms.Label();
            this.tmrcodepointsupdate = new System.Windows.Forms.Timer(this.components);
            this.btnback = new System.Windows.Forms.Button();
            this.btnforward = new System.Windows.Forms.Button();
            this.lbcategory = new System.Windows.Forms.Label();
            this.btnhack = new System.Windows.Forms.Button();
            this.pgcontents.SuspendLayout();
            this.pnlinfo.SuspendLayout();
            this.pnlintro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picpreview)).BeginInit();
            this.SuspendLayout();
            // 
            // pgcontents
            // 
            this.pgcontents.BackColor = System.Drawing.Color.White;
            this.pgcontents.Controls.Add(this.btnhack);
            this.pgcontents.Controls.Add(this.lbcategory);
            this.pgcontents.Controls.Add(this.btnforward);
            this.pgcontents.Controls.Add(this.btnback);
            this.pgcontents.Controls.Add(this.lbcodepoints);
            this.pgcontents.Controls.Add(this.lbupgrades);
            this.pgcontents.Controls.Add(this.Label1);
            this.pgcontents.Controls.Add(this.pnlinfo);
            this.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(0, 0);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(701, 462);
            this.pgcontents.TabIndex = 0;
            this.pgcontents.TabStop = true;
            // 
            // lbcodepoints
            // 
            this.lbcodepoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcodepoints.ForeColor = System.Drawing.Color.Black;
            this.lbcodepoints.Location = new System.Drawing.Point(16, 372);
            this.lbcodepoints.Name = "lbcodepoints";
            this.lbcodepoints.Size = new System.Drawing.Size(309, 43);
            this.lbcodepoints.TabIndex = 8;
            this.lbcodepoints.Text = "Codepoints: 25";
            this.lbcodepoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbupgrades
            // 
            this.lbupgrades.BackColor = System.Drawing.Color.White;
            this.lbupgrades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbupgrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbupgrades.ForeColor = System.Drawing.Color.Black;
            this.lbupgrades.Location = new System.Drawing.Point(21, 101);
            this.lbupgrades.MultiSelect = false;
            this.lbupgrades.Name = "lbupgrades";
            this.lbupgrades.Size = new System.Drawing.Size(304, 254);
            this.lbupgrades.TabIndex = 0;
            this.lbupgrades.UseCompatibleStateImageBehavior = false;
            this.lbupgrades.View = System.Windows.Forms.View.Details;
            this.lbupgrades.SelectedIndexChanged += new System.EventHandler(this.lbupgrades_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(85, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(175, 39);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Upgrades";
            // 
            // pnlinfo
            // 
            this.pnlinfo.Controls.Add(this.pnlintro);
            this.pnlinfo.Controls.Add(this.btnbuy);
            this.pnlinfo.Controls.Add(this.lbprice);
            this.pnlinfo.Controls.Add(this.picpreview);
            this.pnlinfo.Controls.Add(this.lbudescription);
            this.pnlinfo.Controls.Add(this.lbupgradename);
            this.pnlinfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlinfo.Location = new System.Drawing.Point(332, 0);
            this.pnlinfo.Name = "pnlinfo";
            this.pnlinfo.Size = new System.Drawing.Size(369, 462);
            this.pnlinfo.TabIndex = 0;
            // 
            // pnlintro
            // 
            this.pnlintro.Controls.Add(this.Label4);
            this.pnlintro.Controls.Add(this.Label2);
            this.pnlintro.Controls.Add(this.Label5);
            this.pnlintro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlintro.Location = new System.Drawing.Point(0, 0);
            this.pnlintro.Name = "pnlintro";
            this.pnlintro.Size = new System.Drawing.Size(369, 462);
            this.pnlintro.TabIndex = 8;
            this.pnlintro.TabStop = true;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(-3, 397);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(358, 18);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "Select an upgrade on the left to view its details";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(3, 53);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(340, 341);
            this.Label2.TabIndex = 5;
            this.Label2.Text = resources.GetString("Label2.Text");
            this.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(-4, 14);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(355, 31);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Welcome to the Shiftorium";
            // 
            // btnbuy
            // 
            this.btnbuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuy.ForeColor = System.Drawing.Color.Black;
            this.btnbuy.Location = new System.Drawing.Point(160, 362);
            this.btnbuy.Name = "btnbuy";
            this.btnbuy.Size = new System.Drawing.Size(185, 56);
            this.btnbuy.TabIndex = 7;
            this.btnbuy.Text = "Buy";
            this.btnbuy.UseVisualStyleBackColor = true;
            this.btnbuy.Click += new System.EventHandler(this.btnbuy_Click);
            // 
            // lbprice
            // 
            this.lbprice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lbprice.ForeColor = System.Drawing.Color.Black;
            this.lbprice.Location = new System.Drawing.Point(15, 362);
            this.lbprice.Name = "lbprice";
            this.lbprice.Size = new System.Drawing.Size(127, 59);
            this.lbprice.TabIndex = 6;
            this.lbprice.Text = "50 CP";
            this.lbprice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picpreview
            // 
            this.picpreview.Image = global::ShiftOS.Properties.Resources.upgradegray;
            this.picpreview.Location = new System.Drawing.Point(25, 218);
            this.picpreview.Name = "picpreview";
            this.picpreview.Size = new System.Drawing.Size(320, 130);
            this.picpreview.TabIndex = 5;
            this.picpreview.TabStop = false;
            // 
            // lbudescription
            // 
            this.lbudescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbudescription.ForeColor = System.Drawing.Color.Black;
            this.lbudescription.Location = new System.Drawing.Point(24, 63);
            this.lbudescription.Name = "lbudescription";
            this.lbudescription.Size = new System.Drawing.Size(321, 144);
            this.lbudescription.TabIndex = 4;
            this.lbudescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbupgradename
            // 
            this.lbupgradename.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbupgradename.ForeColor = System.Drawing.Color.Black;
            this.lbupgradename.Location = new System.Drawing.Point(5, 17);
            this.lbupgradename.Name = "lbupgradename";
            this.lbupgradename.Size = new System.Drawing.Size(361, 43);
            this.lbupgradename.TabIndex = 3;
            this.lbupgradename.Text = "Upgradename";
            this.lbupgradename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrcodepointsupdate
            // 
            this.tmrcodepointsupdate.Enabled = true;
            this.tmrcodepointsupdate.Interval = 1000;
            this.tmrcodepointsupdate.Tick += new System.EventHandler(this.tmrcodepointsupdate_Tick);
            // 
            // btnback
            // 
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Location = new System.Drawing.Point(22, 72);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(36, 23);
            this.btnback.TabIndex = 9;
            this.btnback.Text = "<<";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btnforward
            // 
            this.btnforward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnforward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnforward.Location = new System.Drawing.Point(289, 72);
            this.btnforward.Name = "btnforward";
            this.btnforward.Size = new System.Drawing.Size(36, 23);
            this.btnforward.TabIndex = 10;
            this.btnforward.Text = ">>";
            this.btnforward.UseVisualStyleBackColor = true;
            this.btnforward.Click += new System.EventHandler(this.btnforward_Click);
            // 
            // lbcategory
            // 
            this.lbcategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lbcategory.ForeColor = System.Drawing.Color.Black;
            this.lbcategory.Location = new System.Drawing.Point(64, 72);
            this.lbcategory.Name = "lbcategory";
            this.lbcategory.Size = new System.Drawing.Size(219, 26);
            this.lbcategory.TabIndex = 11;
            this.lbcategory.Text = "Upgrades";
            this.lbcategory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnhack
            // 
            this.btnhack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnhack.AutoSize = true;
            this.btnhack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhack.Location = new System.Drawing.Point(143, 218);
            this.btnhack.Name = "btnhack";
            this.btnhack.Size = new System.Drawing.Size(68, 25);
            this.btnhack.TabIndex = 12;
            this.btnhack.Text = "Hack it.";
            this.btnhack.UseVisualStyleBackColor = true;
            this.btnhack.Visible = false;
            this.btnhack.Click += new System.EventHandler(this.btnhack_Click);
            // 
            // Frontend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(701, 462);
            this.Controls.Add(this.pgcontents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frontend";
            this.Text = "Shiftorium";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frontend_Load);
            this.pgcontents.ResumeLayout(false);
            this.pgcontents.PerformLayout();
            this.pnlinfo.ResumeLayout(false);
            this.pnlintro.ResumeLayout(false);
            this.pnlintro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picpreview)).EndInit();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Panel pgcontents;
        internal System.Windows.Forms.ListView lbupgrades;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel pnlinfo;
        internal System.Windows.Forms.Label lbcodepoints;
        internal System.Windows.Forms.Button btnbuy;
        internal System.Windows.Forms.Label lbprice;
        internal System.Windows.Forms.PictureBox picpreview;
        internal System.Windows.Forms.Label lbudescription;
        internal System.Windows.Forms.Label lbupgradename;
        internal System.Windows.Forms.Panel pnlintro;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Timer tmrcodepointsupdate;
        internal System.Windows.Forms.Label lbcategory;
        private System.Windows.Forms.Button btnforward;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnhack;
    }
}