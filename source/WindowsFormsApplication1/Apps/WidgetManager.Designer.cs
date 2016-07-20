namespace ShiftOS
{
    partial class WidgetManager
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
            this.pnlbuttons = new ShiftUI.FlowLayoutPanel();
            this.btndone = new ShiftUI.Button();
            this.btnadd = new ShiftUI.Button();
            this.cbpanel = new ShiftUI.ComboBox();
            this.txtwidth = new ShiftUI.TextBox();
            this.lbwidth = new ShiftUI.Label();
            this.txtx = new ShiftUI.TextBox();
            this.label1 = new ShiftUI.Label();
            this.lbtitle = new ShiftUI.Label();
            this.lvwidgets = new ShiftUI.ListView();
            this.columnHeader1 = ((ShiftUI.ColumnHeader)(new ShiftUI.ColumnHeader()));
            this.columnHeader2 = ((ShiftUI.ColumnHeader)(new ShiftUI.ColumnHeader()));
            this.listView1 = new ShiftUI.ListView();
            this.tmrcheckvalid = new ShiftUI.Timer(this.components);
            this.btninstallwidgets = new ShiftUI.Button();
            this.panel1.SuspendLayout();
            this.pnlbuttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Widgets.Add(this.pnlbuttons);
            this.panel1.Widgets.Add(this.lbtitle);
            this.panel1.Widgets.Add(this.lvwidgets);
            this.panel1.Widgets.Add(this.listView1);
            this.panel1.Dock = ShiftUI.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 459);
            this.panel1.TabIndex = 0;
            // 
            // pnlbuttons
            // 
            this.pnlbuttons.BackColor = System.Drawing.Color.Gray;
            this.pnlbuttons.Widgets.Add(this.btndone);
            this.pnlbuttons.Widgets.Add(this.btnadd);
            this.pnlbuttons.Widgets.Add(this.cbpanel);
            this.pnlbuttons.Widgets.Add(this.txtwidth);
            this.pnlbuttons.Widgets.Add(this.lbwidth);
            this.pnlbuttons.Widgets.Add(this.txtx);
            this.pnlbuttons.Widgets.Add(this.label1);
            this.pnlbuttons.Widgets.Add(this.btninstallwidgets);
            this.pnlbuttons.Dock = ShiftUI.DockStyle.Bottom;
            this.pnlbuttons.FlowDirection = ShiftUI.FlowDirection.RightToLeft;
            this.pnlbuttons.ForeColor = System.Drawing.Color.White;
            this.pnlbuttons.Location = new System.Drawing.Point(0, 429);
            this.pnlbuttons.Name = "pnlbuttons";
            this.pnlbuttons.Size = new System.Drawing.Size(697, 30);
            this.pnlbuttons.TabIndex = 3;
            // 
            // btndone
            // 
            this.btndone.AutoSize = true;
            this.btndone.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btndone.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btndone.Location = new System.Drawing.Point(649, 3);
            this.btndone.Name = "btndone";
            this.btndone.Size = new System.Drawing.Size(45, 25);
            this.btndone.TabIndex = 0;
            this.btndone.Text = "Done";
            this.btndone.UseVisualStyleBackColor = true;
            this.btndone.Click += new System.EventHandler(this.btndone_Click);
            // 
            // btnadd
            // 
            this.btnadd.AutoSize = true;
            this.btnadd.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btnadd.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btnadd.Location = new System.Drawing.Point(605, 3);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(38, 25);
            this.btnadd.TabIndex = 2;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // cbpanel
            // 
            this.cbpanel.DropDownStyle = ShiftUI.ComboBoxStyle.DropDownList;
            this.cbpanel.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.cbpanel.FormattingEnabled = true;
            this.cbpanel.Location = new System.Drawing.Point(478, 3);
            this.cbpanel.Name = "cbpanel";
            this.cbpanel.Size = new System.Drawing.Size(121, 21);
            this.cbpanel.TabIndex = 1;
            // 
            // txtwidth
            // 
            this.txtwidth.Location = new System.Drawing.Point(443, 3);
            this.txtwidth.Name = "txtwidth";
            this.txtwidth.Size = new System.Drawing.Size(29, 20);
            this.txtwidth.TabIndex = 3;
            // 
            // lbwidth
            // 
            this.lbwidth.Location = new System.Drawing.Point(393, 0);
            this.lbwidth.Name = "lbwidth";
            this.lbwidth.Size = new System.Drawing.Size(44, 28);
            this.lbwidth.TabIndex = 5;
            this.lbwidth.Text = "Width:";
            this.lbwidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtx
            // 
            this.txtx.Location = new System.Drawing.Point(355, 3);
            this.txtx.Name = "txtx";
            this.txtx.Size = new System.Drawing.Size(32, 20);
            this.txtx.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(246, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Horizontal Location:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbtitle
            // 
            this.lbtitle.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.lbtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lbtitle.Location = new System.Drawing.Point(12, 9);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(673, 32);
            this.lbtitle.TabIndex = 2;
            this.lbtitle.Text = "Desktop Panel Widgets";
            this.lbtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwidgets
            // 
            this.lvwidgets.Anchor = ((ShiftUI.AnchorStyles)((((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.lvwidgets.Columns.AddRange(new ShiftUI.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwidgets.FullRowSelect = true;
            this.lvwidgets.HeaderStyle = ShiftUI.ColumnHeaderStyle.Nonclickable;
            this.lvwidgets.Location = new System.Drawing.Point(12, 44);
            this.lvwidgets.Name = "lvwidgets";
            this.lvwidgets.Size = new System.Drawing.Size(673, 381);
            this.lvwidgets.TabIndex = 1;
            this.lvwidgets.UseCompatibleStateImageBehavior = false;
            this.lvwidgets.View = ShiftUI.View.Details;
            this.lvwidgets.SelectedIndexChanged += new System.EventHandler(this.lvwidgets_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(212, 76);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 97);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tmrcheckvalid
            // 
            this.tmrcheckvalid.Enabled = true;
            this.tmrcheckvalid.Tick += new System.EventHandler(this.tmrcheckvalid_Tick);
            // 
            // btninstallwidgets
            // 
            this.btninstallwidgets.AutoSize = true;
            this.btninstallwidgets.AutoSizeMode = ShiftUI.AutoSizeMode.GrowAndShrink;
            this.btninstallwidgets.FlatStyle = ShiftUI.FlatStyle.Flat;
            this.btninstallwidgets.Location = new System.Drawing.Point(152, 3);
            this.btninstallwidgets.Name = "btninstallwidgets";
            this.btninstallwidgets.Size = new System.Drawing.Size(88, 25);
            this.btninstallwidgets.TabIndex = 7;
            this.btninstallwidgets.Text = "Install Widgets";
            this.btninstallwidgets.UseVisualStyleBackColor = true;
            this.btninstallwidgets.Click += new System.EventHandler(this.btninstallwidgets_Click);
            // 
            // WidgetManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 459);
            this.Widgets.Add(this.panel1);
            this.Name = "WidgetManager";
            this.Text = "WidgetManager";
            this.Load += new System.EventHandler(this.WidgetManager_Load);
            this.panel1.ResumeLayout(false);
            this.pnlbuttons.ResumeLayout(false);
            this.pnlbuttons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.Panel panel1;
        private ShiftUI.ListView listView1;
        private ShiftUI.FlowLayoutPanel pnlbuttons;
        private ShiftUI.Button btndone;
        private ShiftUI.Button btnadd;
        private ShiftUI.ComboBox cbpanel;
        private ShiftUI.Label lbtitle;
        private ShiftUI.ListView lvwidgets;
        private ShiftUI.ColumnHeader columnHeader1;
        private ShiftUI.ColumnHeader columnHeader2;
        private ShiftUI.TextBox txtwidth;
        private ShiftUI.Label lbwidth;
        private ShiftUI.TextBox txtx;
        private ShiftUI.Label label1;
        private ShiftUI.Timer tmrcheckvalid;
        private ShiftUI.Button btninstallwidgets;
    }
}