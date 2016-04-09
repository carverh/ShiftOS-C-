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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlbuttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btndone = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.cbpanel = new System.Windows.Forms.ComboBox();
            this.txtwidth = new System.Windows.Forms.TextBox();
            this.lbwidth = new System.Windows.Forms.Label();
            this.txtx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbtitle = new System.Windows.Forms.Label();
            this.lvwidgets = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.tmrcheckvalid = new System.Windows.Forms.Timer(this.components);
            this.btninstallwidgets = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlbuttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pnlbuttons);
            this.panel1.Controls.Add(this.lbtitle);
            this.panel1.Controls.Add(this.lvwidgets);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 459);
            this.panel1.TabIndex = 0;
            // 
            // pnlbuttons
            // 
            this.pnlbuttons.BackColor = System.Drawing.Color.Gray;
            this.pnlbuttons.Controls.Add(this.btndone);
            this.pnlbuttons.Controls.Add(this.btnadd);
            this.pnlbuttons.Controls.Add(this.cbpanel);
            this.pnlbuttons.Controls.Add(this.txtwidth);
            this.pnlbuttons.Controls.Add(this.lbwidth);
            this.pnlbuttons.Controls.Add(this.txtx);
            this.pnlbuttons.Controls.Add(this.label1);
            this.pnlbuttons.Controls.Add(this.btninstallwidgets);
            this.pnlbuttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlbuttons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlbuttons.ForeColor = System.Drawing.Color.White;
            this.pnlbuttons.Location = new System.Drawing.Point(0, 429);
            this.pnlbuttons.Name = "pnlbuttons";
            this.pnlbuttons.Size = new System.Drawing.Size(697, 30);
            this.pnlbuttons.TabIndex = 3;
            // 
            // btndone
            // 
            this.btndone.AutoSize = true;
            this.btndone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btndone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btnadd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.cbpanel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbpanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.lbtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lvwidgets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwidgets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwidgets.FullRowSelect = true;
            this.lvwidgets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwidgets.Location = new System.Drawing.Point(12, 44);
            this.lvwidgets.Name = "lvwidgets";
            this.lvwidgets.Size = new System.Drawing.Size(673, 381);
            this.lvwidgets.TabIndex = 1;
            this.lvwidgets.UseCompatibleStateImageBehavior = false;
            this.lvwidgets.View = System.Windows.Forms.View.Details;
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
            this.btninstallwidgets.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btninstallwidgets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 459);
            this.Controls.Add(this.panel1);
            this.Name = "WidgetManager";
            this.Text = "WidgetManager";
            this.Load += new System.EventHandler(this.WidgetManager_Load);
            this.panel1.ResumeLayout(false);
            this.pnlbuttons.ResumeLayout(false);
            this.pnlbuttons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.FlowLayoutPanel pnlbuttons;
        private System.Windows.Forms.Button btndone;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.ComboBox cbpanel;
        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.ListView lvwidgets;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtwidth;
        private System.Windows.Forms.Label lbwidth;
        private System.Windows.Forms.TextBox txtx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrcheckvalid;
        private System.Windows.Forms.Button btninstallwidgets;
    }
}