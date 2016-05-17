namespace ShiftOS.FinalMission
{
    partial class ChoiceControl
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
            this.lbnumber = new System.Windows.Forms.Label();
            this.lbdescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbnumber
            // 
            this.lbnumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.lbnumber.Location = new System.Drawing.Point(0, 0);
            this.lbnumber.Name = "lbnumber";
            this.lbnumber.Size = new System.Drawing.Size(112, 75);
            this.lbnumber.TabIndex = 0;
            this.lbnumber.Text = "1";
            this.lbnumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbnumber.Click += new System.EventHandler(this.lbdescription_Click);
            // 
            // lbdescription
            // 
            this.lbdescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbdescription.Location = new System.Drawing.Point(0, 75);
            this.lbdescription.Name = "lbdescription";
            this.lbdescription.Size = new System.Drawing.Size(112, 27);
            this.lbdescription.TabIndex = 1;
            this.lbdescription.Text = "Stop DevX";
            this.lbdescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbdescription.Click += new System.EventHandler(this.lbdescription_Click);
            // 
            // ChoiceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbnumber);
            this.Controls.Add(this.lbdescription);
            this.Name = "ChoiceControl";
            this.Size = new System.Drawing.Size(112, 102);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbnumber;
        private System.Windows.Forms.Label lbdescription;
    }
}
