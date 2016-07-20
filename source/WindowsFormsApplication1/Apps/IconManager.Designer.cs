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
            this.pnlactions = new ShiftUI.Panel();
            this.pnlicons = new ShiftUI.FlowLayoutPanel();
            this.panel1 = new ShiftUI.Panel();
            this.btnsave = new ShiftUI.Button();
            this.button1 = new ShiftUI.Button();
            this.button2 = new ShiftUI.Button();
            this.pnlactions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlactions
            // 
            this.pnlactions.BackColor = System.Drawing.Color.Gray;
            this.pnlactions.Widgets.Add(this.button2);
            this.pnlactions.Widgets.Add(this.button1);
            this.pnlactions.Widgets.Add(this.btnsave);
            this.pnlactions.Dock = ShiftUI.DockStyle.Bottom;
            this.pnlactions.ForeColor = System.Drawing.Color.White;
            this.pnlactions.Location = new System.Drawing.Point(0, 511);
            this.pnlactions.Name = "pnlactions";
            this.pnlactions.Size = new System.Drawing.Size(720, 41);
            this.pnlactions.TabIndex = 0;
            // 
            // pnlicons
            // 
            this.pnlicons.BackColor = System.Drawing.Color.White;
            this.pnlicons.Dock = ShiftUI.DockStyle.Fill;
            this.pnlicons.FlowDirection = ShiftUI.FlowDirection.TopDown;
            this.pnlicons.ForeColor = System.Drawing.Color.Black;
            this.pnlicons.Location = new System.Drawing.Point(0, 0);
            this.pnlicons.Name = "pnlicons";
            this.pnlicons.Size = new System.Drawing.Size(720, 511);
            this.pnlicons.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Widgets.Add(this.pnlicons);
            this.panel1.Widgets.Add(this.pnlactions);
            this.panel1.Dock = ShiftUI.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 552);
            this.panel1.TabIndex = 0;
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom)));
            this.btnsave.FlatStyle = ShiftUI.FlatStyle.Standard;
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
            this.button1.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom)));
            this.button1.FlatStyle = ShiftUI.FlatStyle.Standard;
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
            this.button2.Anchor = ((ShiftUI.AnchorStyles)((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom)));
            this.button2.FlatStyle = ShiftUI.FlatStyle.Standard;
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
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 552);
            this.Widgets.Add(this.panel1);
            this.Name = "IconManager";
            this.Text = "IconManager";
            this.Load += new System.EventHandler(this.IconManager_Load);
            this.pnlactions.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.Panel pnlactions;
        private ShiftUI.FlowLayoutPanel pnlicons;
        private ShiftUI.Panel panel1;
        private ShiftUI.Button button2;
        private ShiftUI.Button button1;
        private ShiftUI.Button btnsave;
    }
}