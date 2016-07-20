using System;

namespace ShiftOS
{
    partial class SkinLoader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkinLoader));
            this.pgcontents = new ShiftUI.Panel();
            this.label3 = new ShiftUI.Label();
            this.btnapplyskin = new ShiftUI.Button();
            this.btnsaveskin = new ShiftUI.Button();
            this.btnloadskin = new ShiftUI.Button();
            this.Label2 = new ShiftUI.Label();
            this.btnclose = new ShiftUI.Button();
            this.pnldesktoppreview = new ShiftUI.Panel();
            this.predesktoppanel = new ShiftUI.Panel();
            this.prepnlpanelbuttonholder = new ShiftUI.FlowLayoutPanel();
            this.prepnlpanelbutton = new ShiftUI.Panel();
            this.pretbicon = new ShiftUI.PictureBox();
            this.pretbctext = new ShiftUI.Label();
            this.pretimepanel = new ShiftUI.Panel();
            this.prepaneltimetext = new ShiftUI.Label();
            this.preapplaunchermenuholder = new ShiftUI.Panel();
            this.predesktopappmenu = new ShiftUI.MenuStrip();
            this.ApplicationsToolStripMenuItem = new ShiftUI.ToolStripMenuItem();
            this.KnowledgeInputToolStripMenuItem = new ShiftUI.ToolStripMenuItem();
            this.ShiftoriumToolStripMenuItem = new ShiftUI.ToolStripMenuItem();
            this.ClockToolStripMenuItem = new ShiftUI.ToolStripMenuItem();
            this.TerminalToolStripMenuItem = new ShiftUI.ToolStripMenuItem();
            this.ShifterToolStripMenuItem = new ShiftUI.ToolStripMenuItem();
            this.ToolStripSeparator1 = new ShiftUI.ToolStripSeparator();
            this.ShutdownToolStripMenuItem = new ShiftUI.ToolStripMenuItem();
            this.Label1 = new ShiftUI.Label();
            this.pnlwindowpreview = new ShiftUI.Panel();
            this.prepgcontent = new ShiftUI.Panel();
            this.prepgbottom = new ShiftUI.Panel();
            this.prepgleft = new ShiftUI.Panel();
            this.prepgbottomlcorner = new ShiftUI.Panel();
            this.prepgright = new ShiftUI.Panel();
            this.prepgbottomrcorner = new ShiftUI.Panel();
            this.pretitlebar = new ShiftUI.Panel();
            this.preminimizebutton = new ShiftUI.Panel();
            this.prepnlicon = new ShiftUI.PictureBox();
            this.prerollupbutton = new ShiftUI.Panel();
            this.preclosebutton = new ShiftUI.Panel();
            this.pretitletext = new ShiftUI.Label();
            this.prepgtoplcorner = new ShiftUI.Panel();
            this.prepgtoprcorner = new ShiftUI.Panel();
            this.pnlskinpacks = new ShiftUI.Panel();
            this.btnapplypackskin = new ShiftUI.Button();
            this.label6 = new ShiftUI.Label();
            this.cbpackfiles = new ShiftUI.ComboBox();
            this.btnbrowse = new ShiftUI.Button();
            this.txtpackpath = new ShiftUI.TextBox();
            this.btnbacktoskinloader = new ShiftUI.Button();
            this.label5 = new ShiftUI.Label();
            this.label4 = new ShiftUI.Label();
            this.panel1 = new ShiftUI.Panel();
            this.pgcontents.SuspendLayout();
            this.pnldesktoppreview.SuspendLayout();
            this.predesktoppanel.SuspendLayout();
            this.prepnlpanelbuttonholder.SuspendLayout();
            this.prepnlpanelbutton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pretbicon)).BeginInit();
            this.pretimepanel.SuspendLayout();
            this.preapplaunchermenuholder.SuspendLayout();
            this.predesktopappmenu.SuspendLayout();
            this.pnlwindowpreview.SuspendLayout();
            this.prepgleft.SuspendLayout();
            this.prepgright.SuspendLayout();
            this.pretitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prepnlicon)).BeginInit();
            this.pnlskinpacks.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgcontents
            // 
            this.pgcontents.BackColor = System.Drawing.Color.White;
            this.pgcontents.Widgets.Add(this.label3);
            this.pgcontents.Widgets.Add(this.btnapplyskin);
            this.pgcontents.Widgets.Add(this.btnsaveskin);
            this.pgcontents.Widgets.Add(this.btnloadskin);
            this.pgcontents.Widgets.Add(this.Label2);
            this.pgcontents.Widgets.Add(this.btnclose);
            this.pgcontents.Widgets.Add(this.pnldesktoppreview);
            this.pgcontents.Widgets.Add(this.Label1);
            this.pgcontents.Widgets.Add(this.pnlwindowpreview);
            this.pgcontents.Dock = ShiftUI.DockStyle.Fill;
            this.pgcontents.Location = new System.Drawing.Point(0, 0);
            this.pgcontents.Name = "pgcontents";
            this.pgcontents.Size = new System.Drawing.Size(476, 462);
            this.pgcontents.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(10, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(454, 31);
            this.label3.TabIndex = 10;
            this.label3.Text = "The preview is based on the currently loaded skin, not the one selected by the \"L" +
    "oad Skin\" button.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnapplyskin
            // 
            this.btnapplyskin.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.btnapplyskin.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnapplyskin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnapplyskin.Location = new System.Drawing.Point(352, 418);
            this.btnapplyskin.Name = "btnapplyskin";
            this.btnapplyskin.Size = new System.Drawing.Size(107, 32);
            this.btnapplyskin.TabIndex = 9;
            this.btnapplyskin.Text = "Apply Skin";
            this.btnapplyskin.UseVisualStyleBackColor = true;
            this.btnapplyskin.Click += new System.EventHandler(this.btnapplyskin_Click);
            // 
            // btnsaveskin
            // 
            this.btnsaveskin.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Right)));
            this.btnsaveskin.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnsaveskin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsaveskin.Location = new System.Drawing.Point(239, 418);
            this.btnsaveskin.Name = "btnsaveskin";
            this.btnsaveskin.Size = new System.Drawing.Size(107, 32);
            this.btnsaveskin.TabIndex = 8;
            this.btnsaveskin.Text = "Save Skin";
            this.btnsaveskin.UseVisualStyleBackColor = true;
            this.btnsaveskin.Click += new System.EventHandler(this.btnsaveskin_Click);
            // 
            // btnloadskin
            // 
            this.btnloadskin.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.btnloadskin.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnloadskin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnloadskin.Location = new System.Drawing.Point(126, 418);
            this.btnloadskin.Name = "btnloadskin";
            this.btnloadskin.Size = new System.Drawing.Size(107, 32);
            this.btnloadskin.TabIndex = 7;
            this.btnloadskin.Text = "Load Skin";
            this.btnloadskin.UseVisualStyleBackColor = true;
            this.btnloadskin.Click += new System.EventHandler(this.btnloadskin_Click);
            // 
            // Label2
            // 
            this.Label2.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(4, 200);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(464, 30);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Desktop Preview";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.btnclose.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.Location = new System.Drawing.Point(13, 418);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(107, 32);
            this.btnclose.TabIndex = 5;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // pnldesktoppreview
            // 
            this.pnldesktoppreview.Anchor = ((ShiftUI.AnchorStyles)((((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.pnldesktoppreview.Widgets.Add(this.predesktoppanel);
            this.pnldesktoppreview.Location = new System.Drawing.Point(13, 233);
            this.pnldesktoppreview.Name = "pnldesktoppreview";
            this.pnldesktoppreview.Size = new System.Drawing.Size(448, 148);
            this.pnldesktoppreview.TabIndex = 4;
            // 
            // predesktoppanel
            // 
            this.predesktoppanel.BackColor = System.Drawing.Color.Gray;
            this.predesktoppanel.Widgets.Add(this.prepnlpanelbuttonholder);
            this.predesktoppanel.Widgets.Add(this.pretimepanel);
            this.predesktoppanel.Widgets.Add(this.preapplaunchermenuholder);
            this.predesktoppanel.Dock = ShiftUI.DockStyle.Top;
            this.predesktoppanel.Location = new System.Drawing.Point(0, 0);
            this.predesktoppanel.Name = "predesktoppanel";
            this.predesktoppanel.Size = new System.Drawing.Size(448, 25);
            this.predesktoppanel.TabIndex = 1;
            // 
            // prepnlpanelbuttonholder
            // 
            this.prepnlpanelbuttonholder.BackColor = System.Drawing.Color.Transparent;
            this.prepnlpanelbuttonholder.Widgets.Add(this.prepnlpanelbutton);
            this.prepnlpanelbuttonholder.Dock = ShiftUI.DockStyle.Fill;
            this.prepnlpanelbuttonholder.Location = new System.Drawing.Point(116, 0);
            this.prepnlpanelbuttonholder.Name = "prepnlpanelbuttonholder";
            this.prepnlpanelbuttonholder.Padding = new ShiftUI.Padding(2, 0, 0, 0);
            this.prepnlpanelbuttonholder.Size = new System.Drawing.Size(235, 25);
            this.prepnlpanelbuttonholder.TabIndex = 7;
            // 
            // prepnlpanelbutton
            // 
            this.prepnlpanelbutton.BackColor = System.Drawing.Color.Black;
            this.prepnlpanelbutton.Widgets.Add(this.pretbicon);
            this.prepnlpanelbutton.Widgets.Add(this.pretbctext);
            this.prepnlpanelbutton.Location = new System.Drawing.Point(5, 3);
            this.prepnlpanelbutton.Name = "prepnlpanelbutton";
            this.prepnlpanelbutton.Size = new System.Drawing.Size(126, 20);
            this.prepnlpanelbutton.TabIndex = 18;
            this.prepnlpanelbutton.Visible = false;
            // 
            // pretbicon
            // 
            this.pretbicon.BackColor = System.Drawing.Color.Transparent;
            this.pretbicon.BackgroundImageLayout = ShiftUI.ImageLayout.Stretch;
            this.pretbicon.Image = global::ShiftOS.Properties.Resources.iconShifter;
            this.pretbicon.Location = new System.Drawing.Point(4, 2);
            this.pretbicon.Name = "pretbicon";
            this.pretbicon.Size = new System.Drawing.Size(16, 16);
            this.pretbicon.TabIndex = 1;
            this.pretbicon.TabStop = false;
            // 
            // pretbctext
            // 
            this.pretbctext.AutoSize = true;
            this.pretbctext.BackColor = System.Drawing.Color.Transparent;
            this.pretbctext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pretbctext.ForeColor = System.Drawing.Color.White;
            this.pretbctext.Location = new System.Drawing.Point(24, 2);
            this.pretbctext.Name = "pretbctext";
            this.pretbctext.Size = new System.Drawing.Size(45, 16);
            this.pretbctext.TabIndex = 0;
            this.pretbctext.Text = "Shifter";
            // 
            // pretimepanel
            // 
            this.pretimepanel.Widgets.Add(this.prepaneltimetext);
            this.pretimepanel.Dock = ShiftUI.DockStyle.Right;
            this.pretimepanel.Location = new System.Drawing.Point(351, 0);
            this.pretimepanel.Name = "pretimepanel";
            this.pretimepanel.Size = new System.Drawing.Size(97, 25);
            this.pretimepanel.TabIndex = 5;
            // 
            // prepaneltimetext
            // 
            this.prepaneltimetext.AutoSize = true;
            this.prepaneltimetext.BackColor = System.Drawing.Color.Transparent;
            this.prepaneltimetext.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepaneltimetext.Location = new System.Drawing.Point(5, 0);
            this.prepaneltimetext.Name = "prepaneltimetext";
            this.prepaneltimetext.Size = new System.Drawing.Size(80, 24);
            this.prepaneltimetext.TabIndex = 1;
            this.prepaneltimetext.Text = "5000023";
            this.prepaneltimetext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // preapplaunchermenuholder
            // 
            this.preapplaunchermenuholder.Widgets.Add(this.predesktopappmenu);
            this.preapplaunchermenuholder.Dock = ShiftUI.DockStyle.Left;
            this.preapplaunchermenuholder.Location = new System.Drawing.Point(0, 0);
            this.preapplaunchermenuholder.Name = "preapplaunchermenuholder";
            this.preapplaunchermenuholder.Size = new System.Drawing.Size(116, 25);
            this.preapplaunchermenuholder.TabIndex = 4;
            // 
            // predesktopappmenu
            // 
            this.predesktopappmenu.AutoSize = false;
            this.predesktopappmenu.Items.AddRange(new ShiftUI.ToolStripItem[] {
            this.ApplicationsToolStripMenuItem});
            this.predesktopappmenu.LayoutStyle = ShiftUI.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.predesktopappmenu.Location = new System.Drawing.Point(0, 0);
            this.predesktopappmenu.Name = "predesktopappmenu";
            this.predesktopappmenu.Padding = new ShiftUI.Padding(0);
            this.predesktopappmenu.Size = new System.Drawing.Size(116, 24);
            this.predesktopappmenu.TabIndex = 0;
            this.predesktopappmenu.Text = "MenuStrip1";
            // 
            // ApplicationsToolStripMenuItem
            // 
            this.ApplicationsToolStripMenuItem.AutoSize = false;
            this.ApplicationsToolStripMenuItem.DropDownItems.AddRange(new ShiftUI.ToolStripItem[] {
            this.KnowledgeInputToolStripMenuItem,
            this.ShiftoriumToolStripMenuItem,
            this.ClockToolStripMenuItem,
            this.TerminalToolStripMenuItem,
            this.ShifterToolStripMenuItem,
            this.ToolStripSeparator1,
            this.ShutdownToolStripMenuItem});
            this.ApplicationsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationsToolStripMenuItem.Name = "ApplicationsToolStripMenuItem";
            this.ApplicationsToolStripMenuItem.Padding = new ShiftUI.Padding(2, 0, 2, 0);
            this.ApplicationsToolStripMenuItem.ShowShortcutKeys = false;
            this.ApplicationsToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.ApplicationsToolStripMenuItem.Text = "Applications";
            this.ApplicationsToolStripMenuItem.TextDirection = ShiftUI.ToolStripTextDirection.Horizontal;
            this.ApplicationsToolStripMenuItem.TextImageRelation = ShiftUI.TextImageRelation.TextBeforeImage;
            // 
            // KnowledgeInputToolStripMenuItem
            // 
            this.KnowledgeInputToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.KnowledgeInputToolStripMenuItem.Name = "KnowledgeInputToolStripMenuItem";
            this.KnowledgeInputToolStripMenuItem.ShowShortcutKeys = false;
            this.KnowledgeInputToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.KnowledgeInputToolStripMenuItem.Text = "Knowledge Input";
            // 
            // ShiftoriumToolStripMenuItem
            // 
            this.ShiftoriumToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ShiftoriumToolStripMenuItem.Name = "ShiftoriumToolStripMenuItem";
            this.ShiftoriumToolStripMenuItem.ShowShortcutKeys = false;
            this.ShiftoriumToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ShiftoriumToolStripMenuItem.Text = "Shiftorium";
            // 
            // ClockToolStripMenuItem
            // 
            this.ClockToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ClockToolStripMenuItem.Name = "ClockToolStripMenuItem";
            this.ClockToolStripMenuItem.ShowShortcutKeys = false;
            this.ClockToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ClockToolStripMenuItem.Text = "Clock";
            // 
            // TerminalToolStripMenuItem
            // 
            this.TerminalToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.TerminalToolStripMenuItem.Name = "TerminalToolStripMenuItem";
            this.TerminalToolStripMenuItem.ShowShortcutKeys = false;
            this.TerminalToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.TerminalToolStripMenuItem.Text = "Terminal";
            // 
            // ShifterToolStripMenuItem
            // 
            this.ShifterToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ShifterToolStripMenuItem.Name = "ShifterToolStripMenuItem";
            this.ShifterToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ShifterToolStripMenuItem.Text = "Shifter";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.ToolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // ShutdownToolStripMenuItem
            // 
            this.ShutdownToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ShutdownToolStripMenuItem.Name = "ShutdownToolStripMenuItem";
            this.ShutdownToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ShutdownToolStripMenuItem.Text = "Shut Down";
            // 
            // Label1
            // 
            this.Label1.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(4, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(464, 30);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Window Preview";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlwindowpreview
            // 
            this.pnlwindowpreview.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.pnlwindowpreview.Widgets.Add(this.prepgcontent);
            this.pnlwindowpreview.Widgets.Add(this.prepgbottom);
            this.pnlwindowpreview.Widgets.Add(this.prepgleft);
            this.pnlwindowpreview.Widgets.Add(this.prepgright);
            this.pnlwindowpreview.Widgets.Add(this.pretitlebar);
            this.pnlwindowpreview.Location = new System.Drawing.Point(13, 39);
            this.pnlwindowpreview.Name = "pnlwindowpreview";
            this.pnlwindowpreview.Size = new System.Drawing.Size(448, 148);
            this.pnlwindowpreview.TabIndex = 1;
            // 
            // prepgcontent
            // 
            this.prepgcontent.Dock = ShiftUI.DockStyle.Fill;
            this.prepgcontent.Location = new System.Drawing.Point(2, 30);
            this.prepgcontent.Name = "prepgcontent";
            this.prepgcontent.Size = new System.Drawing.Size(444, 116);
            this.prepgcontent.TabIndex = 20;
            // 
            // prepgbottom
            // 
            this.prepgbottom.BackColor = System.Drawing.Color.Gray;
            this.prepgbottom.Dock = ShiftUI.DockStyle.Bottom;
            this.prepgbottom.Location = new System.Drawing.Point(2, 146);
            this.prepgbottom.Name = "prepgbottom";
            this.prepgbottom.Size = new System.Drawing.Size(444, 2);
            this.prepgbottom.TabIndex = 23;
            // 
            // prepgleft
            // 
            this.prepgleft.BackColor = System.Drawing.Color.Gray;
            this.prepgleft.Widgets.Add(this.prepgbottomlcorner);
            this.prepgleft.Dock = ShiftUI.DockStyle.Left;
            this.prepgleft.Location = new System.Drawing.Point(0, 30);
            this.prepgleft.Name = "prepgleft";
            this.prepgleft.Size = new System.Drawing.Size(2, 118);
            this.prepgleft.TabIndex = 21;
            // 
            // prepgbottomlcorner
            // 
            this.prepgbottomlcorner.BackColor = System.Drawing.Color.Red;
            this.prepgbottomlcorner.Dock = ShiftUI.DockStyle.Bottom;
            this.prepgbottomlcorner.Location = new System.Drawing.Point(0, 116);
            this.prepgbottomlcorner.Name = "prepgbottomlcorner";
            this.prepgbottomlcorner.Size = new System.Drawing.Size(2, 2);
            this.prepgbottomlcorner.TabIndex = 14;
            // 
            // prepgright
            // 
            this.prepgright.BackColor = System.Drawing.Color.Gray;
            this.prepgright.Widgets.Add(this.prepgbottomrcorner);
            this.prepgright.Dock = ShiftUI.DockStyle.Right;
            this.prepgright.Location = new System.Drawing.Point(446, 30);
            this.prepgright.Name = "prepgright";
            this.prepgright.Size = new System.Drawing.Size(2, 118);
            this.prepgright.TabIndex = 22;
            // 
            // prepgbottomrcorner
            // 
            this.prepgbottomrcorner.BackColor = System.Drawing.Color.Red;
            this.prepgbottomrcorner.Dock = ShiftUI.DockStyle.Bottom;
            this.prepgbottomrcorner.Location = new System.Drawing.Point(0, 116);
            this.prepgbottomrcorner.Name = "prepgbottomrcorner";
            this.prepgbottomrcorner.Size = new System.Drawing.Size(2, 2);
            this.prepgbottomrcorner.TabIndex = 15;
            // 
            // pretitlebar
            // 
            this.pretitlebar.BackColor = System.Drawing.Color.Gray;
            this.pretitlebar.Widgets.Add(this.preminimizebutton);
            this.pretitlebar.Widgets.Add(this.prepnlicon);
            this.pretitlebar.Widgets.Add(this.prerollupbutton);
            this.pretitlebar.Widgets.Add(this.preclosebutton);
            this.pretitlebar.Widgets.Add(this.pretitletext);
            this.pretitlebar.Widgets.Add(this.prepgtoplcorner);
            this.pretitlebar.Widgets.Add(this.prepgtoprcorner);
            this.pretitlebar.Dock = ShiftUI.DockStyle.Top;
            this.pretitlebar.ForeColor = System.Drawing.Color.White;
            this.pretitlebar.Location = new System.Drawing.Point(0, 0);
            this.pretitlebar.Name = "pretitlebar";
            this.pretitlebar.Size = new System.Drawing.Size(448, 30);
            this.pretitlebar.TabIndex = 19;
            // 
            // preminimizebutton
            // 
            this.preminimizebutton.BackColor = System.Drawing.Color.Black;
            this.preminimizebutton.Location = new System.Drawing.Point(362, 5);
            this.preminimizebutton.Name = "preminimizebutton";
            this.preminimizebutton.Size = new System.Drawing.Size(22, 22);
            this.preminimizebutton.TabIndex = 32;
            // 
            // prepnlicon
            // 
            this.prepnlicon.BackColor = System.Drawing.Color.Transparent;
            this.prepnlicon.Image = global::ShiftOS.Properties.Resources.iconSkinLoader;
            this.prepnlicon.Location = new System.Drawing.Point(8, 8);
            this.prepnlicon.Name = "prepnlicon";
            this.prepnlicon.Size = new System.Drawing.Size(16, 16);
            this.prepnlicon.TabIndex = 32;
            this.prepnlicon.TabStop = false;
            this.prepnlicon.Visible = false;
            // 
            // prerollupbutton
            // 
            this.prerollupbutton.BackColor = System.Drawing.Color.Black;
            this.prerollupbutton.Location = new System.Drawing.Point(390, 5);
            this.prerollupbutton.Name = "prerollupbutton";
            this.prerollupbutton.Size = new System.Drawing.Size(22, 22);
            this.prerollupbutton.TabIndex = 31;
            // 
            // preclosebutton
            // 
            this.preclosebutton.BackColor = System.Drawing.Color.Black;
            this.preclosebutton.Location = new System.Drawing.Point(419, 5);
            this.preclosebutton.Name = "preclosebutton";
            this.preclosebutton.Size = new System.Drawing.Size(22, 22);
            this.preclosebutton.TabIndex = 20;
            // 
            // pretitletext
            // 
            this.pretitletext.AutoSize = true;
            this.pretitletext.BackColor = System.Drawing.Color.Transparent;
            this.pretitletext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pretitletext.Location = new System.Drawing.Point(29, 7);
            this.pretitletext.Name = "pretitletext";
            this.pretitletext.Size = new System.Drawing.Size(77, 18);
            this.pretitletext.TabIndex = 19;
            this.pretitletext.Text = "Template";
            // 
            // prepgtoplcorner
            // 
            this.prepgtoplcorner.BackColor = System.Drawing.Color.Red;
            this.prepgtoplcorner.Dock = ShiftUI.DockStyle.Left;
            this.prepgtoplcorner.Location = new System.Drawing.Point(0, 0);
            this.prepgtoplcorner.Name = "prepgtoplcorner";
            this.prepgtoplcorner.Size = new System.Drawing.Size(2, 30);
            this.prepgtoplcorner.TabIndex = 17;
            // 
            // prepgtoprcorner
            // 
            this.prepgtoprcorner.BackColor = System.Drawing.Color.Red;
            this.prepgtoprcorner.Dock = ShiftUI.DockStyle.Right;
            this.prepgtoprcorner.Location = new System.Drawing.Point(446, 0);
            this.prepgtoprcorner.Name = "prepgtoprcorner";
            this.prepgtoprcorner.Size = new System.Drawing.Size(2, 30);
            this.prepgtoprcorner.TabIndex = 16;
            // 
            // pnlskinpacks
            // 
            this.pnlskinpacks.BackColor = System.Drawing.Color.White;
            this.pnlskinpacks.Widgets.Add(this.btnapplypackskin);
            this.pnlskinpacks.Widgets.Add(this.label6);
            this.pnlskinpacks.Widgets.Add(this.cbpackfiles);
            this.pnlskinpacks.Widgets.Add(this.btnbrowse);
            this.pnlskinpacks.Widgets.Add(this.txtpackpath);
            this.pnlskinpacks.Widgets.Add(this.btnbacktoskinloader);
            this.pnlskinpacks.Widgets.Add(this.label5);
            this.pnlskinpacks.Widgets.Add(this.label4);
            this.pnlskinpacks.Dock = ShiftUI.DockStyle.Fill;
            this.pnlskinpacks.Location = new System.Drawing.Point(0, 0);
            this.pnlskinpacks.Name = "pnlskinpacks";
            this.pnlskinpacks.Size = new System.Drawing.Size(476, 462);
            this.pnlskinpacks.TabIndex = 11;
            // 
            // btnapplypackskin
            // 
            this.btnapplypackskin.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.btnapplypackskin.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnapplypackskin.Location = new System.Drawing.Point(379, 418);
            this.btnapplypackskin.Name = "btnapplypackskin";
            this.btnapplypackskin.Size = new System.Drawing.Size(94, 41);
            this.btnapplypackskin.TabIndex = 7;
            this.btnapplypackskin.Text = "Apply Skin";
            this.btnapplypackskin.UseVisualStyleBackColor = true;
            this.btnapplypackskin.Click += new System.EventHandler(this.btnapplyskin_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Select a skin:";
            // 
            // cbpackfiles
            // 
            this.cbpackfiles.FormattingEnabled = true;
            this.cbpackfiles.Location = new System.Drawing.Point(126, 188);
            this.cbpackfiles.Name = "cbpackfiles";
            this.cbpackfiles.Size = new System.Drawing.Size(328, 21);
            this.cbpackfiles.TabIndex = 5;
            this.cbpackfiles.SelectedIndexChanged += new System.EventHandler(this.cbpackfiles_SelectedIndexChanged);
            // 
            // btnbrowse
            // 
            this.btnbrowse.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Right)));
            this.btnbrowse.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnbrowse.Location = new System.Drawing.Point(389, 138);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(75, 23);
            this.btnbrowse.TabIndex = 4;
            this.btnbrowse.Text = "Browse...";
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // txtpackpath
            // 
            this.txtpackpath.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.txtpackpath.BorderStyle = ShiftUI.BorderStyle.FixedSingle;
            this.txtpackpath.Location = new System.Drawing.Point(13, 141);
            this.txtpackpath.Name = "txtpackpath";
            this.txtpackpath.Size = new System.Drawing.Size(370, 20);
            this.txtpackpath.TabIndex = 3;
            // 
            // btnbacktoskinloader
            // 
            this.btnbacktoskinloader.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Bottom | ShiftUI.AnchorStyles.Left)));
            this.btnbacktoskinloader.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnbacktoskinloader.Location = new System.Drawing.Point(3, 418);
            this.btnbacktoskinloader.Name = "btnbacktoskinloader";
            this.btnbacktoskinloader.Size = new System.Drawing.Size(94, 41);
            this.btnbacktoskinloader.TabIndex = 2;
            this.btnbacktoskinloader.Text = "Back to Skin Loader";
            this.btnbacktoskinloader.UseVisualStyleBackColor = true;
            this.btnbacktoskinloader.Click += new System.EventHandler(this.btnbacktoskinloader_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(5, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(470, 110);
            this.label5.TabIndex = 1;
            this.label5.Text = resources.GetString("label5.Text");
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(470, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Skin Packs";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Widgets.Add(this.pgcontents);
            this.panel1.Widgets.Add(this.pnlskinpacks);
            this.panel1.Dock = ShiftUI.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 462);
            this.panel1.TabIndex = 8;
            // 
            // SkinLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 462);
            this.Widgets.Add(this.panel1);
            this.FormBorderStyle = ShiftUI.FormBorderStyle.None;
            this.Name = "SkinLoader";
            this.Text = "Skin_Loader";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SkinLoader_Load);
            this.pgcontents.ResumeLayout(false);
            this.pnldesktoppreview.ResumeLayout(false);
            this.predesktoppanel.ResumeLayout(false);
            this.prepnlpanelbuttonholder.ResumeLayout(false);
            this.prepnlpanelbutton.ResumeLayout(false);
            this.prepnlpanelbutton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pretbicon)).EndInit();
            this.pretimepanel.ResumeLayout(false);
            this.pretimepanel.PerformLayout();
            this.preapplaunchermenuholder.ResumeLayout(false);
            this.predesktopappmenu.ResumeLayout(false);
            this.predesktopappmenu.PerformLayout();
            this.pnlwindowpreview.ResumeLayout(false);
            this.prepgleft.ResumeLayout(false);
            this.prepgright.ResumeLayout(false);
            this.pretitlebar.ResumeLayout(false);
            this.pretitlebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prepnlicon)).EndInit();
            this.pnlskinpacks.ResumeLayout(false);
            this.pnlskinpacks.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        internal ShiftUI.Panel pgcontents;
        internal ShiftUI.Label Label1;
        internal ShiftUI.Panel pnlwindowpreview;
        internal ShiftUI.Panel prepgcontent;
        internal ShiftUI.Panel prepgbottom;
        internal ShiftUI.Panel prepgleft;
        internal ShiftUI.Panel prepgbottomlcorner;
        internal ShiftUI.Panel prepgright;
        internal ShiftUI.Panel prepgbottomrcorner;
        internal ShiftUI.Panel pretitlebar;
        internal ShiftUI.PictureBox prepnlicon;
        internal ShiftUI.Panel prerollupbutton;
        internal ShiftUI.Panel preclosebutton;
        internal ShiftUI.Label pretitletext;
        internal ShiftUI.Panel prepgtoplcorner;
        internal ShiftUI.Panel prepgtoprcorner;
        internal ShiftUI.Button btnapplyskin;
        internal ShiftUI.Button btnsaveskin;
        internal ShiftUI.Button btnloadskin;
        internal ShiftUI.Label Label2;
        internal ShiftUI.Button btnclose;
        internal ShiftUI.Panel pnldesktoppreview;
        internal ShiftUI.Panel predesktoppanel;
        internal ShiftUI.Panel pretimepanel;
        internal ShiftUI.Label prepaneltimetext;
        internal ShiftUI.Panel preapplaunchermenuholder;
        internal ShiftUI.MenuStrip predesktopappmenu;
        internal ShiftUI.ToolStripMenuItem ApplicationsToolStripMenuItem;
        internal ShiftUI.ToolStripMenuItem KnowledgeInputToolStripMenuItem;
        internal ShiftUI.ToolStripMenuItem ShiftoriumToolStripMenuItem;
        internal ShiftUI.ToolStripMenuItem ClockToolStripMenuItem;
        internal ShiftUI.ToolStripMenuItem TerminalToolStripMenuItem;
        internal ShiftUI.ToolStripMenuItem ShifterToolStripMenuItem;
        internal ShiftUI.ToolStripSeparator ToolStripSeparator1;
        internal ShiftUI.ToolStripMenuItem ShutdownToolStripMenuItem;
        internal ShiftUI.Panel preminimizebutton;
        internal ShiftUI.FlowLayoutPanel prepnlpanelbuttonholder;
        internal ShiftUI.Panel prepnlpanelbutton;
        internal ShiftUI.PictureBox pretbicon;
        internal ShiftUI.Label pretbctext;
        private ShiftUI.Label label3;
        private ShiftUI.Panel pnlskinpacks;
        private ShiftUI.Button btnbacktoskinloader;
        private ShiftUI.Label label5;
        private ShiftUI.Label label4;
        private ShiftUI.Button btnbrowse;
        private ShiftUI.TextBox txtpackpath;
        private ShiftUI.Label label6;
        private ShiftUI.ComboBox cbpackfiles;
        private ShiftUI.Button btnapplypackskin;
        private ShiftUI.Panel panel1;
    }
}