namespace ShiftOS
{
    partial class IconManager
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
            this.pnlactions = new System.Windows.Forms.Panel();
            this.pnlicons = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnsave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlactions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlactions
            // 
            this.pnlactions.BackColor = System.Drawing.Color.Gray;
            this.pnlactions.Controls.Add(this.button2);
            this.pnlactions.Controls.Add(this.button1);
            this.pnlactions.Controls.Add(this.btnsave);
            this.pnlactions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlactions.ForeColor = System.Drawing.Color.White;
            this.pnlactions.Location = new System.Drawing.Point(0, 511);
            this.pnlactions.Name = "pnlactions";
            this.pnlactions.Size = new System.Drawing.Size(720, 41);
            this.pnlactions.TabIndex = 0;
            // 
            // pnlicons
            // 
            this.pnlicons.BackColor = System.Drawing.Color.White;
            this.pnlicons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlicons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlicons.ForeColor = System.Drawing.Color.Black;
            this.pnlicons.Location = new System.Drawing.Point(0, 0);
            this.pnlicons.Name = "pnlicons";
            this.pnlicons.Size = new System.Drawing.Size(720, 511);
            this.pnlicons.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlicons);
            this.panel1.Controls.Add(this.pnlactions);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 552);
            this.panel1.TabIndex = 0;
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Location = new System.Drawing.Point(3, 3);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 35);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "Done";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(84, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Pack";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(165, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Export";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // IconManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 552);
            this.Controls.Add(this.panel1);
            this.Name = "IconManager";
            this.Text = "IconManager";
            this.Load += new System.EventHandler(this.IconManager_Load);
            this.pnlactions.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlactions;
        private System.Windows.Forms.FlowLayoutPanel pnlicons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnsave;
    }
}