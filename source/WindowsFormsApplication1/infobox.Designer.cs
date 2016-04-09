using System;

namespace ShiftOS
{
    partial class infobox
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
            this.pgcontents = new System.Windows.Forms.Panel();
            this.txtuserinput = new System.Windows.Forms.TextBox();
            this.btnok = new System.Windows.Forms.Button();
            this.txtmessage = new System.Windows.Forms.Label();
            this.pboximage = new System.Windows.Forms.PictureBox();
            this.lblintructtext = new System.Windows.Forms.Label();
            this.pnlyesno = new System.Windows.Forms.Panel();
            this.btnno = new System.Windows.Forms.Button();
            this.btnyes = new System.Windows.Forms.Button();
            this.pgcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboximage)).BeginInit();
            this.pnlyesno.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgcontents
            // 
            this.pgcontents.BackColor = System.Drawing.Color.White;
            this.pgcontents.Controls.Add(this.txtuserinput);
            this.pgcontents.Controls.Add(this.btnok);
            this.pgcontents.Controls.Add(this.txtmessage);
            this.pgcontents.Controls.Add(this.pboximage);
            this.pgcontents.Controls.Add(this.lblintructtext);
            this.pgcontents.Controls.Add(this.pnlyesno);
            this.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(0, 0);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(371, 154);
            this.pgcontents.TabIndex = 20;
            // 
            // txtuserinput
            // 
            this.txtuserinput.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtuserinput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtuserinput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuserinput.Location = new System.Drawing.Point(103, 86);
            this.txtuserinput.Multiline = true;
            this.txtuserinput.Name = "txtuserinput";
            this.txtuserinput.Size = new System.Drawing.Size(256, 23);
            this.txtuserinput.TabIndex = 8;
            this.txtuserinput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtuserinput.Visible = false;
            // 
            // btnok
            // 
            this.btnok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnok.ForeColor = System.Drawing.Color.Black;
            this.btnok.Location = new System.Drawing.Point(134, 118);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(109, 30);
            this.btnok.TabIndex = 7;
            this.btnok.TabStop = false;
            this.btnok.Text = "Ok";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // txtmessage
            // 
            this.txtmessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmessage.Location = new System.Drawing.Point(102, 7);
            this.txtmessage.Name = "txtmessage";
            this.txtmessage.Size = new System.Drawing.Size(266, 102);
            this.txtmessage.TabIndex = 2;
            this.txtmessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pboximage
            // 
            this.pboximage.Image = global::ShiftOS.Properties.Resources.Symbolinfo1;
            this.pboximage.Location = new System.Drawing.Point(12, 7);
            this.pboximage.Name = "pboximage";
            this.pboximage.Size = new System.Drawing.Size(80, 70);
            this.pboximage.TabIndex = 0;
            this.pboximage.TabStop = false;
            // 
            // lblintructtext
            // 
            this.lblintructtext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblintructtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblintructtext.Location = new System.Drawing.Point(105, 7);
            this.lblintructtext.Name = "lblintructtext";
            this.lblintructtext.Size = new System.Drawing.Size(256, 76);
            this.lblintructtext.TabIndex = 9;
            this.lblintructtext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblintructtext.Visible = false;
            // 
            // pnlyesno
            // 
            this.pnlyesno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlyesno.Controls.Add(this.btnno);
            this.pnlyesno.Controls.Add(this.btnyes);
            this.pnlyesno.Location = new System.Drawing.Point(57, 115);
            this.pnlyesno.Name = "pnlyesno";
            this.pnlyesno.Size = new System.Drawing.Size(269, 33);
            this.pnlyesno.TabIndex = 10;
            this.pnlyesno.Visible = false;
            // 
            // btnno
            // 
            this.btnno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnno.ForeColor = System.Drawing.Color.Black;
            this.btnno.Location = new System.Drawing.Point(142, 2);
            this.btnno.Name = "btnno";
            this.btnno.Size = new System.Drawing.Size(105, 30);
            this.btnno.TabIndex = 9;
            this.btnno.TabStop = false;
            this.btnno.Text = "No";
            this.btnno.UseVisualStyleBackColor = true;
            this.btnno.Click += new System.EventHandler(this.btnno_Click);
            // 
            // btnyes
            // 
            this.btnyes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnyes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnyes.ForeColor = System.Drawing.Color.Black;
            this.btnyes.Location = new System.Drawing.Point(29, 2);
            this.btnyes.Name = "btnyes";
            this.btnyes.Size = new System.Drawing.Size(105, 30);
            this.btnyes.TabIndex = 8;
            this.btnyes.TabStop = false;
            this.btnyes.Text = "Yes";
            this.btnyes.UseVisualStyleBackColor = true;
            this.btnyes.Click += new System.EventHandler(this.btnyes_Click);
            // 
            // infobox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 154);
            this.Controls.Add(this.pgcontents);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "infobox";
            this.Text = "infobox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.infobox_Load);
            this.pgcontents.ResumeLayout(false);
            this.pgcontents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboximage)).EndInit();
            this.pnlyesno.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Panel pgcontents;
        internal System.Windows.Forms.Button btnok;
        internal System.Windows.Forms.Label txtmessage;
        internal System.Windows.Forms.PictureBox pboximage;
        internal System.Windows.Forms.Label lblintructtext;
        internal System.Windows.Forms.TextBox txtuserinput;
        internal System.Windows.Forms.Panel pnlyesno;
        internal System.Windows.Forms.Button btnno;
        internal System.Windows.Forms.Button btnyes;
    }
}