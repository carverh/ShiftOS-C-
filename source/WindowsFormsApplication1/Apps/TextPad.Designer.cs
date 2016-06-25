using System;
using System.Windows.Forms;

namespace ShiftOS
{
    partial class TextPad
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
            this.txtuserinput = new System.Windows.Forms.TextBox();
            this.pnlbreak = new System.Windows.Forms.Panel();
            this.pnloptions = new System.Windows.Forms.Panel();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnopen = new System.Windows.Forms.Button();
            this.btnnew = new System.Windows.Forms.Button();
            this.tmrcodepointcooldown = new System.Windows.Forms.Timer(this.components);
            this.tmrshowearnedcodepoints = new System.Windows.Forms.Timer(this.components);
            this.pgcontents.SuspendLayout();
            this.pnloptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgcontents
            // 
            this.pgcontents.Controls.Add(this.txtuserinput);
            this.pgcontents.Controls.Add(this.pnlbreak);
            this.pgcontents.Controls.Add(this.pnloptions);
            this.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(0, 0);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(530, 330);
            this.pgcontents.TabIndex = 20;
            // 
            // txtuserinput
            // 
            this.txtuserinput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtuserinput.BackColor = System.Drawing.Color.White;
            this.txtuserinput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtuserinput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuserinput.ForeColor = System.Drawing.Color.Black;
            this.txtuserinput.Location = new System.Drawing.Point(4, 2);
            this.txtuserinput.Multiline = true;
            this.txtuserinput.Name = "txtuserinput";
            this.txtuserinput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtuserinput.Size = new System.Drawing.Size(528, 272);
            this.txtuserinput.TabIndex = 0;
            // 
            // pnlbreak
            // 
            this.pnlbreak.BackColor = System.Drawing.Color.White;
            this.pnlbreak.BackgroundImage = global::ShiftOS.Properties.Resources.uparrow;
            this.pnlbreak.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlbreak.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlbreak.ForeColor = System.Drawing.Color.Black;
            this.pnlbreak.Location = new System.Drawing.Point(0, 277);
            this.pnlbreak.Name = "pnlbreak";
            this.pnlbreak.Size = new System.Drawing.Size(530, 15);
            this.pnlbreak.TabIndex = 2;
            // 
            // pnloptions
            // 
            this.pnloptions.BackColor = System.Drawing.Color.White;
            this.pnloptions.Controls.Add(this.btnsave);
            this.pnloptions.Controls.Add(this.btnopen);
            this.pnloptions.Controls.Add(this.btnnew);
            this.pnloptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnloptions.Location = new System.Drawing.Point(0, 292);
            this.pnloptions.Name = "pnloptions";
            this.pnloptions.Size = new System.Drawing.Size(530, 38);
            this.pnloptions.TabIndex = 1;
            this.pnloptions.Visible = false;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.White;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Image = global::ShiftOS.Properties.Resources.saveicon;
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(168, 4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(76, 31);
            this.btnsave.TabIndex = 2;
            this.btnsave.Text = "Save";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            // 
            // btnopen
            // 
            this.btnopen.BackColor = System.Drawing.Color.White;
            this.btnopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnopen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnopen.Image = global::ShiftOS.Properties.Resources.openicon;
            this.btnopen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnopen.Location = new System.Drawing.Point(86, 4);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(76, 31);
            this.btnopen.TabIndex = 1;
            this.btnopen.Text = "Open";
            this.btnopen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnopen.UseVisualStyleBackColor = false;
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.White;
            this.btnnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnew.Location = new System.Drawing.Point(4, 4);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(76, 31);
            this.btnnew.TabIndex = 0;
            this.btnnew.Text = "New";
            this.btnnew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnew.UseVisualStyleBackColor = false;
            // 
            // tmrcodepointcooldown
            // 
            this.tmrcodepointcooldown.Interval = 10000;
            // 
            // tmrshowearnedcodepoints
            // 
            this.tmrshowearnedcodepoints.Interval = 3000;
            // 
            // TextPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(530, 330);
            this.Controls.Add(this.pgcontents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(230, 230);
            this.Name = "TextPad";
            this.Text = "TextPad";
            this.TopMost = true;
            this.pgcontents.ResumeLayout(false);
            this.pgcontents.PerformLayout();
            this.pnloptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.txtuserinput.TextChanged += new EventHandler(this.txtuserinput_TextChanged);
            this.btnsave.Click += new EventHandler(this.btnsave_Click);
            this.btnnew.Click += new EventHandler(this.btnnew_Click);
            this.btnopen.Click += new EventHandler(this.btnopen_Click);
            this.Load += new EventHandler(this.TextPad_Load);
            this.tmrcodepointcooldown.Tick += new EventHandler(tmrcodepointcooldown_Tick);
            this.tmrshowearnedcodepoints.Tick += new EventHandler(tmrshowearnedcodepoints_Tick);
            this.pnlbreak.MouseEnter += new EventHandler(this.pnlbreak_MouseEnter);
        }
        internal System.Windows.Forms.Panel pgcontents;
        internal System.Windows.Forms.TextBox txtuserinput;
        internal System.Windows.Forms.Panel pnloptions;
        internal System.Windows.Forms.Button btnnew;
        internal System.Windows.Forms.Button btnsave;
        internal System.Windows.Forms.Button btnopen;
        internal System.Windows.Forms.Panel pnlbreak;
        internal System.Windows.Forms.Timer tmrcodepointcooldown;
        internal System.Windows.Forms.Timer tmrshowearnedcodepoints;
    }
}