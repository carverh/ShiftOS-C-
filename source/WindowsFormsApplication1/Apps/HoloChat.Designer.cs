﻿namespace ShiftOS
{
    partial class HoloChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HoloChat));
            this.panel1 = new ShiftUI.Panel();
            this.pnlintro = new ShiftUI.Panel();
            this.flintrobuttons = new ShiftUI.FlowLayoutPanel();
            this.btnconnect = new ShiftUI.Button();
            this.btnrefresh = new ShiftUI.Button();
            this.lbrooms = new ShiftUI.ListBox();
            this.label1 = new ShiftUI.Label();
            this.lblintro = new ShiftUI.Label();
            this.lblheader = new ShiftUI.Label();
            this.txtchat = new ShiftUI.RichTextBox();
            this.txtsend = new ShiftUI.TextBox();
            this.pnlusers = new ShiftUI.Panel();
            this.lbusers = new ShiftUI.ListBox();
            this.lbtopic = new ShiftUI.Label();
            this.tmrui = new ShiftUI.Timer(this.components);
            this.panel1.SuspendLayout();
            this.pnlintro.SuspendLayout();
            this.flintrobuttons.SuspendLayout();
            this.pnlusers.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Widgets.Add(this.pnlintro);
            this.panel1.Widgets.Add(this.txtchat);
            this.panel1.Widgets.Add(this.txtsend);
            this.panel1.Widgets.Add(this.pnlusers);
            this.panel1.Widgets.Add(this.lbtopic);
            this.panel1.Dock = ShiftUI.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 431);
            this.panel1.TabIndex = 0;
            // 
            // pnlintro
            // 
            this.pnlintro.Anchor = ((ShiftUI.AnchorStyles)((((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.pnlintro.Widgets.Add(this.flintrobuttons);
            this.pnlintro.Widgets.Add(this.lbrooms);
            this.pnlintro.Widgets.Add(this.label1);
            this.pnlintro.Widgets.Add(this.lblintro);
            this.pnlintro.Widgets.Add(this.lblheader);
            this.pnlintro.Location = new System.Drawing.Point(36, 35);
            this.pnlintro.Name = "pnlintro";
            this.pnlintro.Size = new System.Drawing.Size(706, 341);
            this.pnlintro.TabIndex = 3;
            // 
            // flintrobuttons
            // 
            this.flintrobuttons.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.flintrobuttons.Widgets.Add(this.btnconnect);
            this.flintrobuttons.Widgets.Add(this.btnrefresh);
            this.flintrobuttons.FlowDirection = ShiftUI.FlowDirection.RightToLeft;
            this.flintrobuttons.Location = new System.Drawing.Point(337, 284);
            this.flintrobuttons.Name = "flintrobuttons";
            this.flintrobuttons.Size = new System.Drawing.Size(350, 42);
            this.flintrobuttons.TabIndex = 4;
            // 
            // btnconnect
            // 
            this.btnconnect.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnconnect.Location = new System.Drawing.Point(272, 3);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(75, 33);
            this.btnconnect.TabIndex = 0;
            this.btnconnect.Text = "Connect";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // btnrefresh
            // 
            this.btnrefresh.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnrefresh.Location = new System.Drawing.Point(191, 3);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(75, 33);
            this.btnrefresh.TabIndex = 1;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // lbrooms
            // 
            this.lbrooms.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Right)));
            this.lbrooms.FormattingEnabled = true;
            this.lbrooms.Location = new System.Drawing.Point(337, 75);
            this.lbrooms.Name = "lbrooms";
            this.lbrooms.Size = new System.Drawing.Size(350, 199);
            this.lbrooms.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(342, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose a Room";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblintro
            // 
            this.lblintro.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left)));
            this.lblintro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblintro.Location = new System.Drawing.Point(4, 38);
            this.lblintro.Name = "lblintro";
            this.lblintro.Size = new System.Drawing.Size(289, 288);
            this.lblintro.TabIndex = 1;
            this.lblintro.Text = resources.GetString("lblintro.Text");
            this.lblintro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblheader
            // 
            this.lblheader.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.lblheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblheader.Location = new System.Drawing.Point(4, 4);
            this.lblheader.Name = "lblheader";
            this.lblheader.Size = new System.Drawing.Size(699, 34);
            this.lblheader.TabIndex = 0;
            this.lblheader.Text = "Welcome to HoloChat!";
            this.lblheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtchat
            // 
            this.txtchat.Dock = ShiftUI.DockStyle.Fill;
            this.txtchat.Location = new System.Drawing.Point(0, 23);
            this.txtchat.Name = "txtchat";
            this.txtchat.ReadOnly = true;
            this.txtchat.Size = new System.Drawing.Size(641, 388);
            this.txtchat.TabIndex = 2;
            this.txtchat.Text = "";
            this.txtchat.TextChanged += new System.EventHandler(this.txtchat_TextChanged);
            // 
            // txtsend
            // 
            this.txtsend.Dock = ShiftUI.DockStyle.Bottom;
            this.txtsend.Location = new System.Drawing.Point(0, 411);
            this.txtsend.Name = "txtsend";
            this.txtsend.Size = new System.Drawing.Size(641, 20);
            this.txtsend.TabIndex = 1;
            this.txtsend.KeyDown += new ShiftUI.KeyEventHandler(this.txtsend_KeyDown);
            // 
            // pnlusers
            // 
            this.pnlusers.Widgets.Add(this.lbusers);
            this.pnlusers.Dock = ShiftUI.DockStyle.Right;
            this.pnlusers.Location = new System.Drawing.Point(641, 23);
            this.pnlusers.Name = "pnlusers";
            this.pnlusers.Size = new System.Drawing.Size(131, 408);
            this.pnlusers.TabIndex = 0;
            // 
            // lbusers
            // 
            this.lbusers.Dock = ShiftUI.DockStyle.Fill;
            this.lbusers.FormattingEnabled = true;
            this.lbusers.Location = new System.Drawing.Point(0, 0);
            this.lbusers.Name = "lbusers";
            this.lbusers.Size = new System.Drawing.Size(131, 408);
            this.lbusers.TabIndex = 0;
            // 
            // lbtopic
            // 
            this.lbtopic.Dock = ShiftUI.DockStyle.Top;
            this.lbtopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbtopic.Location = new System.Drawing.Point(0, 0);
            this.lbtopic.Name = "lbtopic";
            this.lbtopic.Size = new System.Drawing.Size(772, 23);
            this.lbtopic.TabIndex = 4;
            this.lbtopic.Text = "Welcome to HoloChat!";
            this.lbtopic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrui
            // 
            this.tmrui.Tick += new System.EventHandler(this.tmrui_Tick);
            // 
            // HoloChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 431);
            this.Widgets.Add(this.panel1);
            this.Name = "HoloChat";
            this.Text = "HoloChat";
            this.FormClosing += new ShiftUI.FormClosingEventHandler(this.me_Closing);
            this.Load += new System.EventHandler(this.HoloChat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlintro.ResumeLayout(false);
            this.flintrobuttons.ResumeLayout(false);
            this.pnlusers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.Panel panel1;
        private ShiftUI.RichTextBox txtchat;
        private ShiftUI.TextBox txtsend;
        private ShiftUI.Panel pnlusers;
        private ShiftUI.ListBox lbusers;
        private ShiftUI.Panel pnlintro;
        private ShiftUI.FlowLayoutPanel flintrobuttons;
        private ShiftUI.Button btnconnect;
        private ShiftUI.Button btnrefresh;
        private ShiftUI.ListBox lbrooms;
        private ShiftUI.Label label1;
        private ShiftUI.Label lblintro;
        private ShiftUI.Label lblheader;
        private ShiftUI.Timer tmrui;
        private ShiftUI.Label lbtopic;
    }
}