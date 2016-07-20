using System;

namespace ShiftOS
{
    partial class Graphic_Picker
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
            this.pgcontents = new ShiftUI.Panel();
            this.btncancel = new ShiftUI.Button();
            this.btnreset = new ShiftUI.Button();
            this.btnapply = new ShiftUI.Button();
            this.Label4 = new ShiftUI.Label();
            this.btnmousedownbrowse = new ShiftUI.Button();
            this.txtmousedownfile = new ShiftUI.TextBox();
            this.picmousedown = new ShiftUI.PictureBox();
            this.Label3 = new ShiftUI.Label();
            this.btnmouseoverbrowse = new ShiftUI.Button();
            this.txtmouseoverfile = new ShiftUI.TextBox();
            this.picmouseover = new ShiftUI.PictureBox();
            this.Label2 = new ShiftUI.Label();
            this.Label1 = new ShiftUI.Label();
            this.btnidlebrowse = new ShiftUI.Button();
            this.txtidlefile = new ShiftUI.TextBox();
            this.picidle = new ShiftUI.PictureBox();
            this.btnzoom = new ShiftUI.Button();
            this.btnstretch = new ShiftUI.Button();
            this.btncentre = new ShiftUI.Button();
            this.btntile = new ShiftUI.Button();
            this.pnlgraphicholder = new ShiftUI.Panel();
            this.picgraphic = new ShiftUI.PictureBox();
            this.lblobjecttoskin = new ShiftUI.Label();
            this.pgcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picmousedown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picmouseover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picidle)).BeginInit();
            this.pnlgraphicholder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picgraphic)).BeginInit();
            this.SuspendLayout();
            // 
            // pgcontents
            // 
            this.pgcontents.BackColor = System.Drawing.Color.White;
            this.pgcontents.Widgets.Add(this.btncancel);
            this.pgcontents.Widgets.Add(this.btnreset);
            this.pgcontents.Widgets.Add(this.btnapply);
            this.pgcontents.Widgets.Add(this.Label4);
            this.pgcontents.Widgets.Add(this.btnmousedownbrowse);
            this.pgcontents.Widgets.Add(this.txtmousedownfile);
            this.pgcontents.Widgets.Add(this.picmousedown);
            this.pgcontents.Widgets.Add(this.Label3);
            this.pgcontents.Widgets.Add(this.btnmouseoverbrowse);
            this.pgcontents.Widgets.Add(this.txtmouseoverfile);
            this.pgcontents.Widgets.Add(this.picmouseover);
            this.pgcontents.Widgets.Add(this.Label2);
            this.pgcontents.Widgets.Add(this.Label1);
            this.pgcontents.Widgets.Add(this.btnidlebrowse);
            this.pgcontents.Widgets.Add(this.txtidlefile);
            this.pgcontents.Widgets.Add(this.picidle);
            this.pgcontents.Widgets.Add(this.btnzoom);
            this.pgcontents.Widgets.Add(this.btnstretch);
            this.pgcontents.Widgets.Add(this.btncentre);
            this.pgcontents.Widgets.Add(this.btntile);
            this.pgcontents.Widgets.Add(this.pnlgraphicholder);
            this.pgcontents.Widgets.Add(this.lblobjecttoskin);
            this.pgcontents.Dock = ShiftUI.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(0, 0);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(390, 594);
            this.pgcontents.TabIndex = 20;
            // 
            // btncancel
            // 
            this.btncancel.Anchor = ShiftUI.AnchorStyles.Bottom;
            this.btncancel.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btncancel.Location = new System.Drawing.Point(21, 546);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(109, 32);
            this.btncancel.TabIndex = 23;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnreset
            // 
            this.btnreset.Anchor = ShiftUI.AnchorStyles.Bottom;
            this.btnreset.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnreset.Location = new System.Drawing.Point(136, 546);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(109, 32);
            this.btnreset.TabIndex = 22;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnapply
            // 
            this.btnapply.Anchor = ShiftUI.AnchorStyles.Bottom;
            this.btnapply.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnapply.Location = new System.Drawing.Point(251, 546);
            this.btnapply.Name = "btnapply";
            this.btnapply.Size = new System.Drawing.Size(118, 32);
            this.btnapply.TabIndex = 21;
            this.btnapply.Text = "Apply";
            this.btnapply.UseVisualStyleBackColor = true;
            this.btnapply.Click += new System.EventHandler(this.btnapply_Click);
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(125, 411);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(163, 28);
            this.Label4.TabIndex = 20;
            this.Label4.Text = "Mouse Down";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnmousedownbrowse
            // 
            this.btnmousedownbrowse.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnmousedownbrowse.Location = new System.Drawing.Point(295, 411);
            this.btnmousedownbrowse.Name = "btnmousedownbrowse";
            this.btnmousedownbrowse.Size = new System.Drawing.Size(73, 60);
            this.btnmousedownbrowse.TabIndex = 19;
            this.btnmousedownbrowse.Text = "Browse";
            this.btnmousedownbrowse.UseVisualStyleBackColor = true;
            this.btnmousedownbrowse.Click += new System.EventHandler(this.btnmousedownbrowse_Click);
            // 
            // txtmousedownfile
            // 
            this.txtmousedownfile.BackColor = System.Drawing.Color.White;
            this.txtmousedownfile.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.txtmousedownfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtmousedownfile.Location = new System.Drawing.Point(125, 442);
            this.txtmousedownfile.Multiline = true;
            this.txtmousedownfile.Name = "txtmousedownfile";
            this.txtmousedownfile.Size = new System.Drawing.Size(163, 29);
            this.txtmousedownfile.TabIndex = 18;
            this.txtmousedownfile.Text = "None";
            this.txtmousedownfile.TextAlign = ShiftUI.HorizontalAlignment.Center;
            // 
            // picmousedown
            // 
            this.picmousedown.BackgroundImageLayout = ShiftUI.ImageLayout.Stretch;
            this.picmousedown.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.picmousedown.Location = new System.Drawing.Point(19, 411);
            this.picmousedown.Name = "picmousedown";
            this.picmousedown.Size = new System.Drawing.Size(100, 60);
            this.picmousedown.TabIndex = 17;
            this.picmousedown.TabStop = false;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(125, 336);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(163, 28);
            this.Label3.TabIndex = 16;
            this.Label3.Text = "Mouse Over";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnmouseoverbrowse
            // 
            this.btnmouseoverbrowse.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnmouseoverbrowse.Location = new System.Drawing.Point(295, 336);
            this.btnmouseoverbrowse.Name = "btnmouseoverbrowse";
            this.btnmouseoverbrowse.Size = new System.Drawing.Size(73, 60);
            this.btnmouseoverbrowse.TabIndex = 15;
            this.btnmouseoverbrowse.Text = "Browse";
            this.btnmouseoverbrowse.UseVisualStyleBackColor = true;
            this.btnmouseoverbrowse.Click += new System.EventHandler(this.btnmouseoverbrowse_Click);
            // 
            // txtmouseoverfile
            // 
            this.txtmouseoverfile.BackColor = System.Drawing.Color.White;
            this.txtmouseoverfile.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.txtmouseoverfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtmouseoverfile.Location = new System.Drawing.Point(125, 367);
            this.txtmouseoverfile.Multiline = true;
            this.txtmouseoverfile.Name = "txtmouseoverfile";
            this.txtmouseoverfile.Size = new System.Drawing.Size(163, 29);
            this.txtmouseoverfile.TabIndex = 14;
            this.txtmouseoverfile.Text = "None";
            this.txtmouseoverfile.TextAlign = ShiftUI.HorizontalAlignment.Center;
            // 
            // picmouseover
            // 
            this.picmouseover.BackgroundImageLayout = ShiftUI.ImageLayout.Stretch;
            this.picmouseover.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.picmouseover.Location = new System.Drawing.Point(19, 336);
            this.picmouseover.Name = "picmouseover";
            this.picmouseover.Size = new System.Drawing.Size(100, 60);
            this.picmouseover.TabIndex = 13;
            this.picmouseover.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(125, 260);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(163, 28);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "Idle";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(17, 228);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(70, 23);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "States";
            // 
            // btnidlebrowse
            // 
            this.btnidlebrowse.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnidlebrowse.Location = new System.Drawing.Point(295, 260);
            this.btnidlebrowse.Name = "btnidlebrowse";
            this.btnidlebrowse.Size = new System.Drawing.Size(73, 60);
            this.btnidlebrowse.TabIndex = 10;
            this.btnidlebrowse.Text = "Browse";
            this.btnidlebrowse.UseVisualStyleBackColor = true;
            this.btnidlebrowse.Click += new System.EventHandler(this.btnidlebrowse_Click);
            // 
            // txtidlefile
            // 
            this.txtidlefile.BackColor = System.Drawing.Color.White;
            this.txtidlefile.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.txtidlefile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidlefile.Location = new System.Drawing.Point(125, 291);
            this.txtidlefile.Multiline = true;
            this.txtidlefile.Name = "txtidlefile";
            this.txtidlefile.Size = new System.Drawing.Size(163, 29);
            this.txtidlefile.TabIndex = 9;
            this.txtidlefile.Text = "None";
            this.txtidlefile.TextAlign = ShiftUI.HorizontalAlignment.Center;
            // 
            // picidle
            // 
            this.picidle.BackgroundImageLayout = ShiftUI.ImageLayout.Stretch;
            this.picidle.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.picidle.Location = new System.Drawing.Point(19, 260);
            this.picidle.Name = "picidle";
            this.picidle.Size = new System.Drawing.Size(100, 60);
            this.picidle.SizeMode = ShiftUI.PictureBoxSizeMode.Zoom;
            this.picidle.TabIndex = 8;
            this.picidle.TabStop = false;
            // 
            // btnzoom
            // 
            this.btnzoom.BackgroundImage = global::ShiftOS.Properties.Resources.zoombutton;
            this.btnzoom.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnzoom.FlatAppearance.BorderSize = 0;
            this.btnzoom.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnzoom.Location = new System.Drawing.Point(286, 144);
            this.btnzoom.Name = "btnzoom";
            this.btnzoom.Size = new System.Drawing.Size(82, 65);
            this.btnzoom.TabIndex = 7;
            this.btnzoom.UseVisualStyleBackColor = true;
            this.btnzoom.Click += new System.EventHandler(this.btnzoom_Click);
            // 
            // btnstretch
            // 
            this.btnstretch.BackgroundImage = global::ShiftOS.Properties.Resources.stretchbutton;
            this.btnstretch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnstretch.FlatAppearance.BorderSize = 0;
            this.btnstretch.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnstretch.Location = new System.Drawing.Point(197, 144);
            this.btnstretch.Name = "btnstretch";
            this.btnstretch.Size = new System.Drawing.Size(82, 65);
            this.btnstretch.TabIndex = 6;
            this.btnstretch.UseVisualStyleBackColor = true;
            this.btnstretch.Click += new System.EventHandler(this.btnstretch_Click);
            // 
            // btncentre
            // 
            this.btncentre.BackgroundImage = global::ShiftOS.Properties.Resources.centrebutton;
            this.btncentre.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btncentre.FlatAppearance.BorderSize = 0;
            this.btncentre.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btncentre.Location = new System.Drawing.Point(108, 144);
            this.btncentre.Name = "btncentre";
            this.btncentre.Size = new System.Drawing.Size(82, 65);
            this.btncentre.TabIndex = 5;
            this.btncentre.UseVisualStyleBackColor = true;
            this.btncentre.Click += new System.EventHandler(this.btncentre_Click);
            // 
            // btntile
            // 
            this.btntile.BackgroundImage = global::ShiftOS.Properties.Resources.tilebutton;
            this.btntile.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btntile.FlatAppearance.BorderSize = 0;
            this.btntile.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btntile.Location = new System.Drawing.Point(19, 144);
            this.btntile.Name = "btntile";
            this.btntile.Size = new System.Drawing.Size(82, 65);
            this.btntile.TabIndex = 4;
            this.btntile.UseVisualStyleBackColor = true;
            this.btntile.Click += new System.EventHandler(this.btntile_Click);
            // 
            // pnlgraphicholder
            // 
            this.pnlgraphicholder.Widgets.Add(this.picgraphic);
            this.pnlgraphicholder.Location = new System.Drawing.Point(19, 38);
            this.pnlgraphicholder.Name = "pnlgraphicholder";
            this.pnlgraphicholder.Size = new System.Drawing.Size(350, 100);
            this.pnlgraphicholder.TabIndex = 3;
            // 
            // picgraphic
            // 
            this.picgraphic.BackgroundImageLayout = ShiftUI.ImageLayout.Center;
            this.picgraphic.Location = new System.Drawing.Point(0, 0);
            this.picgraphic.Name = "picgraphic";
            this.picgraphic.Size = new System.Drawing.Size(350, 100);
            this.picgraphic.TabIndex = 0;
            this.picgraphic.TabStop = false;
            // 
            // lblobjecttoskin
            // 
            this.lblobjecttoskin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblobjecttoskin.Location = new System.Drawing.Point(19, 9);
            this.lblobjecttoskin.Name = "lblobjecttoskin";
            this.lblobjecttoskin.Size = new System.Drawing.Size(350, 23);
            this.lblobjecttoskin.TabIndex = 2;
            this.lblobjecttoskin.Text = "Close Button";
            this.lblobjecttoskin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Graphic_Picker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 594);
            this.Widgets.Add(this.pgcontents);
            this.FormBorderStyle = ShiftUI.FormBorderStyle.None;
            this.Name = "Graphic_Picker";
            this.Text = "Graphic_Picker";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Graphic_Picker_Load);
            this.pgcontents.ResumeLayout(false);
            this.pgcontents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picmousedown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picmouseover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picidle)).EndInit();
            this.pnlgraphicholder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picgraphic)).EndInit();
            this.ResumeLayout(false);

        }
        internal ShiftUI.Panel pgcontents;
        internal ShiftUI.Button btncancel;
        internal ShiftUI.Button btnreset;
        internal ShiftUI.Button btnapply;
        internal ShiftUI.Label Label4;
        internal ShiftUI.Button btnmousedownbrowse;
        internal ShiftUI.TextBox txtmousedownfile;
        internal ShiftUI.PictureBox picmousedown;
        internal ShiftUI.Label Label3;
        internal ShiftUI.Button btnmouseoverbrowse;
        internal ShiftUI.TextBox txtmouseoverfile;
        internal ShiftUI.PictureBox picmouseover;
        internal ShiftUI.Label Label2;
        internal ShiftUI.Label Label1;
        internal ShiftUI.Button btnidlebrowse;
        internal ShiftUI.TextBox txtidlefile;
        internal ShiftUI.PictureBox picidle;
        internal ShiftUI.Button btnzoom;
        internal ShiftUI.Button btnstretch;
        internal ShiftUI.Button btncentre;
        internal ShiftUI.Button btntile;
        internal ShiftUI.Panel pnlgraphicholder;
        internal ShiftUI.PictureBox picgraphic;
        internal ShiftUI.Label lblobjecttoskin;
    }
}