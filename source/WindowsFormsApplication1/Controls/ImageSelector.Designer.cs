namespace ShiftOS
{
    partial class ImageSelector
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
            this.label1 = new ShiftUI.Label();
            this.btnselect = new ShiftUI.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = ShiftUI.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnselect
            // 
            this.btnselect.Dock = ShiftUI.DockStyle.Fill;
            this.btnselect.FlatStyle = ShiftUI.FlatStyle.Standard;
            this.btnselect.Location = new System.Drawing.Point(186, 0);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(40, 33);
            this.btnselect.TabIndex = 1;
            this.btnselect.UseVisualStyleBackColor = true;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // ImageSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = ShiftUI.AutoScaleMode.Font;
            this.Widgets.Add(this.btnselect);
            this.Widgets.Add(this.label1);
            this.Name = "ImageSelector";
            this.Size = new System.Drawing.Size(226, 33);
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftUI.Label label1;
        private ShiftUI.Button btnselect;
    }
}
