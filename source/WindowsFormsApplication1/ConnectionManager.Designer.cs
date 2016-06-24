namespace ShiftOS
{
    partial class ConnectionManager
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbconnections = new System.Windows.Forms.ListBox();
            this.flbuttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnconnect = new System.Windows.Forms.Button();
            this.btndisconnect = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flbuttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flbuttons);
            this.panel1.Controls.Add(this.lbconnections);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 531);
            this.panel1.TabIndex = 0;
            // 
            // lbconnections
            // 
            this.lbconnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbconnections.FormattingEnabled = true;
            this.lbconnections.Location = new System.Drawing.Point(13, 13);
            this.lbconnections.Name = "lbconnections";
            this.lbconnections.Size = new System.Drawing.Size(659, 472);
            this.lbconnections.TabIndex = 0;
            this.lbconnections.SelectedIndexChanged += new System.EventHandler(this.lbconnections_SelectedIndexChanged);
            // 
            // flbuttons
            // 
            this.flbuttons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flbuttons.Controls.Add(this.btnadd);
            this.flbuttons.Controls.Add(this.btnconnect);
            this.flbuttons.Controls.Add(this.btndisconnect);
            this.flbuttons.Location = new System.Drawing.Point(13, 489);
            this.flbuttons.Name = "flbuttons";
            this.flbuttons.Size = new System.Drawing.Size(659, 30);
            this.flbuttons.TabIndex = 1;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(3, 3);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 0;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnconnect
            // 
            this.btnconnect.Location = new System.Drawing.Point(84, 3);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(75, 23);
            this.btnconnect.TabIndex = 1;
            this.btnconnect.Text = "Connect";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // btndisconnect
            // 
            this.btndisconnect.Location = new System.Drawing.Point(165, 3);
            this.btndisconnect.Name = "btndisconnect";
            this.btndisconnect.Size = new System.Drawing.Size(75, 23);
            this.btndisconnect.TabIndex = 2;
            this.btndisconnect.Text = "Disconnect";
            this.btndisconnect.UseVisualStyleBackColor = true;
            this.btndisconnect.Click += new System.EventHandler(this.btndisconnect_Click);
            // 
            // ConnectionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 531);
            this.Controls.Add(this.panel1);
            this.Name = "ConnectionManager";
            this.Text = "ConnectionManager";
            this.Load += new System.EventHandler(this.ConnectionManager_Load);
            this.panel1.ResumeLayout(false);
            this.flbuttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flbuttons;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.Button btndisconnect;
        private System.Windows.Forms.ListBox lbconnections;
    }
}