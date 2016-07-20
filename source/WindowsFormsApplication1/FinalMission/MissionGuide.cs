using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;

namespace ShiftOS.FinalMission
{
    public partial class MissionGuide : Form
    {
        public MissionGuide()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        public Action OnButtonClick = null;

        public bool ShowButton
        {
            get { return btnstart.Visible; }
            set { btnstart.Visible = value; }
        }

        public string ButtonText
        {
            get { return btnstart.Text; }
            set { btnstart.Text = value; }
        }

        

        private void btnstart_Click(object sender, EventArgs e)
        {
            OnButtonClick.Invoke();
        }

        private void tmr_setupui_Tick(object sender, EventArgs e)
        {
            lbprompt.Text = EndGameHandler.CurrentObjective.ToUpper() + Environment.NewLine + Environment.NewLine;
            lbprompt.Text += EndGameHandler.CurrentObjectivePrompt;
            this.Location = new Point(15, 45);
        }
    }
}
