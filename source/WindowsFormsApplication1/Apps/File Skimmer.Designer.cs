namespace ShiftOS
{
    partial class File_Skimmer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(File_Skimmer));
            this.toolStripContainer1 = new ShiftUI.ToolStripContainer();
            this.toolStrip2 = new ShiftUI.ToolStrip();
            this.toolStripLabel1 = new ShiftUI.ToolStripLabel();
            this.txtfilename = new ShiftUI.ToolStripTextBox();
            this.cbfiletypes = new ShiftUI.ToolStripComboBox();
            this.btnperformaction = new ShiftUI.ToolStripButton();
            this.btncancel = new ShiftUI.ToolStripButton();
            this.lvfiles = new ShiftUI.ListView();
            this.menuStrip1 = new ShiftUI.MenuStrip();
            this.newFolderToolStripMenuItem = new ShiftUI.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new ShiftUI.ToolStripMenuItem();
            this.toolStrip1 = new ShiftUI.ToolStrip();
            this.lbcurrentfolder = new ShiftUI.ToolStripLabel();
            this.imgtypes = new ShiftUI.ImageList(this.components);
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Widgets.Add(this.toolStrip2);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Widgets.Add(this.lvfiles);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(763, 348);
            this.toolStripContainer1.Dock = ShiftUI.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(763, 413);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Widgets.Add(this.menuStrip1);
            this.toolStripContainer1.TopToolStripPanel.Widgets.Add(this.toolStrip1);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Dock = ShiftUI.DockStyle.None;
            this.toolStrip2.GripStyle = ShiftUI.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new ShiftUI.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtfilename,
            this.cbfiletypes,
            this.btnperformaction,
            this.btncancel});
            this.toolStrip2.LayoutStyle = ShiftUI.ToolStripLayoutStyle.Flow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(763, 23);
            this.toolStrip2.Stretch = true;
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 15);
            this.toolStripLabel1.Text = "File Name:";
            // 
            // txtfilename
            // 
            this.txtfilename.Name = "txtfilename";
            this.txtfilename.Size = new System.Drawing.Size(500, 23);
            // 
            // cbfiletypes
            // 
            this.cbfiletypes.Name = "cbfiletypes";
            this.cbfiletypes.Size = new System.Drawing.Size(75, 23);
            this.cbfiletypes.Text = ".txt";
            this.cbfiletypes.SelectedIndexChanged += new System.EventHandler(this.cbfiletypes_SelectedIndexChanged);
            // 
            // btnperformaction
            // 
            this.btnperformaction.DisplayStyle = ShiftUI.ToolStripItemDisplayStyle.Text;
            this.btnperformaction.Image = ((System.Drawing.Image)(resources.GetObject("btnperformaction.Image")));
            this.btnperformaction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnperformaction.Name = "btnperformaction";
            this.btnperformaction.Size = new System.Drawing.Size(40, 19);
            this.btnperformaction.Text = "Open";
            this.btnperformaction.Click += new System.EventHandler(this.btnperformaction_Click);
            // 
            // btncancel
            // 
            this.btncancel.DisplayStyle = ShiftUI.ToolStripItemDisplayStyle.Text;
            this.btncancel.Image = ((System.Drawing.Image)(resources.GetObject("btncancel.Image")));
            this.btncancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(47, 19);
            this.btncancel.Text = "Cancel";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // lvfiles
            // 
            this.lvfiles.Dock = ShiftUI.DockStyle.Fill;
            this.lvfiles.Location = new System.Drawing.Point(0, 0);
            this.lvfiles.Name = "lvfiles";
            this.lvfiles.Size = new System.Drawing.Size(763, 348);
            this.lvfiles.TabIndex = 0;
            this.lvfiles.UseCompatibleStateImageBehavior = false;
            this.lvfiles.SelectedIndexChanged += new System.EventHandler(this.lvfiles_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = ShiftUI.DockStyle.None;
            this.menuStrip1.Items.AddRange(new ShiftUI.ToolStripItem[] {
            this.newFolderToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(763, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.newFolderToolStripMenuItem.Text = "New Folder";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = ShiftUI.DockStyle.None;
            this.toolStrip1.GripStyle = ShiftUI.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new ShiftUI.ToolStripItem[] {
            this.lbcurrentfolder});
            this.toolStrip1.LayoutStyle = ShiftUI.ToolStripLayoutStyle.Table;
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(763, 18);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            // 
            // lbcurrentfolder
            // 
            this.lbcurrentfolder.Name = "lbcurrentfolder";
            this.lbcurrentfolder.Size = new System.Drawing.Size(12, 15);
            this.lbcurrentfolder.Text = "/";
            // 
            // imgtypes
            // 
            this.imgtypes.TransparentColor = System.Drawing.Color.Transparent;
            //this.imgtypes.Images.SetKeyName(0, "application");
            //this.imgtypes.Images.SetKeyName(1, "package");
            //this.imgtypes.Images.SetKeyName(2, "none");
            //this.imgtypes.Images.SetKeyName(3, "doc");
            //this.imgtypes.Images.SetKeyName(4, "dir");
            //this.imgtypes.Images.SetKeyName(5, "skin");
            // 
            // File_Skimmer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 413);
            this.Widgets.Add(this.toolStripContainer1);
            this.Name = "File_Skimmer";
            this.Text = "File_Skimmer";
            this.Load += new System.EventHandler(this.File_Skimmer_Load);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.ToolStripContainer toolStripContainer1;
        private ShiftUI.MenuStrip menuStrip1;
        private ShiftUI.ToolStripMenuItem newFolderToolStripMenuItem;
        private ShiftUI.ToolStripMenuItem deleteToolStripMenuItem;
        private ShiftUI.ToolStrip toolStrip1;
        private ShiftUI.ListView lvfiles;
        private ShiftUI.ToolStripLabel lbcurrentfolder;
        private ShiftUI.ImageList imgtypes;
        private ShiftUI.ToolStrip toolStrip2;
        private ShiftUI.ToolStripLabel toolStripLabel1;
        private ShiftUI.ToolStripTextBox txtfilename;
        private ShiftUI.ToolStripComboBox cbfiletypes;
        private ShiftUI.ToolStripButton btnperformaction;
        private ShiftUI.ToolStripButton btncancel;
    }
}