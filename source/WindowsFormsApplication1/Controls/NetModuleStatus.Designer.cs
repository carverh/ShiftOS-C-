namespace ShiftOS
{
    partial class NetModuleStatus
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbinfo = new ShiftUI.Label();
            this.pghealth = new ShiftOS.ProgressBarEX();
            this.SuspendLayout();
            // 
            // lbinfo
            // 
            this.lbinfo.Anchor = ((ShiftUI.AnchorStyles)(((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left)));
            this.lbinfo.Location = new System.Drawing.Point(4, 4);
            this.lbinfo.Name = "lbinfo";
            this.lbinfo.Size = new System.Drawing.Size(102, 22);
            this.lbinfo.TabIndex = 1;
            this.lbinfo.Text = "label1";
            // 
            // pghealth
            // 
            this.pghealth.Anchor = ((ShiftUI.AnchorStyles)((((ShiftUI.AnchorStyles.Top | ShiftUI.AnchorStyles.Bottom) 
            | ShiftUI.AnchorStyles.Left) 
            | ShiftUI.AnchorStyles.Right)));
            this.pghealth.BackColor = System.Drawing.Color.Black;
            this.pghealth.BlockSeparation = 3;
            this.pghealth.BlockWidth = 5;
            this.pghealth.Color = System.Drawing.Color.Gray;
            this.pghealth.ForeColor = System.Drawing.Color.White;
            this.pghealth.Location = new System.Drawing.Point(112, 4);
            this.pghealth.MaxValue = 100;
            this.pghealth.MinValue = 0;
            this.pghealth.Name = "pghealth";
            this.pghealth.Orientation = ShiftOS.ProgressBarEX.ProgressBarOrientation.Horizontal;
            this.pghealth.ShowValue = true;
            this.pghealth.Size = new System.Drawing.Size(227, 22);
            this.pghealth.Step = 10;
            this.pghealth.Style = ShiftOS.ProgressBarEX.ProgressBarExStyle.Continuous;
            this.pghealth.TabIndex = 0;
            this.pghealth.Value = 0;
            // 
            // NetModuleStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.Widgets.Add(this.lbinfo);
            this.Widgets.Add(this.pghealth);
            this.Name = "NetModuleStatus";
            this.Size = new System.Drawing.Size(352, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private ProgressBarEX pghealth;
        private ShiftUI.Label lbinfo;
    }
}
