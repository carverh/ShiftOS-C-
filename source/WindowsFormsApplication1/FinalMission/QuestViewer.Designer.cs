namespace ShiftOS.FinalMission
{
    partial class QuestViewer
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
            this.lbobjectives = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbobjectives
            // 
            this.lbobjectives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbobjectives.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic);
            this.lbobjectives.FormattingEnabled = true;
            this.lbobjectives.ItemHeight = 16;
            this.lbobjectives.Location = new System.Drawing.Point(0, 0);
            this.lbobjectives.Name = "lbobjectives";
            this.lbobjectives.Size = new System.Drawing.Size(389, 423);
            this.lbobjectives.TabIndex = 0;
            // 
            // QuestViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 423);
            this.Controls.Add(this.lbobjectives);
            this.Name = "QuestViewer";
            this.Text = "QuestViewer";
            this.Load += new System.EventHandler(this.QuestViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbobjectives;
    }
}