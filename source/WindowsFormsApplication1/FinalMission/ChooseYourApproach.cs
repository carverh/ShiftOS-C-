using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Media;
////using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace ShiftOS.FinalMission
{
    public partial class ChooseYourApproach : Form
    {
        
        public ChooseYourApproach()
        {
            Audio.Play("endgame");
            Audio.Stopped += (o, a) =>
            {
                if (this != null)
                {
                    Audio.Play("endgame");
                }
            };
            InitializeComponent();
            //Music thread.
        }

        private void lbdesc_Click(object sender, EventArgs e)
        {

        }

        private int choice = 0;


        private void ChooseYourApproach_Load(object sender, EventArgs e)
        {
            pnlchoices.Left = (this.Width - pnlchoices.Width) / 2;
        }

        private void cc_sidewithdevx_Selected(object sender, EventArgs e)
        {
            var cc = (ChoiceControl)sender;
            choice = cc.Number;
            SetupUI();
        }

        public void SetupUI()
        {
            switch (choice)
            {
                case 0:
                    choicetitle.Text = "Select a choice";
                    choicedesc.Text = "Select a choice to see more information about it and to begin.";
                    btnbegin.Hide();
                    break;
                case 1:
                    choicetitle.Text = "Side With DevX";
                    choicedesc.Text = "Side with DevX and gain full control of ShiftOS.";
                    btnbegin.Show();
                    break;
                case 2:
                    choicetitle.Text = "Destroy DevX";
                    choicedesc.Text = "DevX put you through digital torture. He stripped you of all your personal files, put you in a barely usable OS and made you make it better. Now it's time to take him down before he can do it to anyone else.";
                    btnbegin.Show();
                    break;
                case 3:
                    choicetitle.Text = "End it all";
                    choicedesc.Text = "It's time to stop dealing with all this stuff and bring you back to your old operating system.";
                    btnbegin.Show();
                    break;

            }
        }

        public void SetupConfirmUI()
        {
            List<string> dependencies = new List<string>();
            panel1.Hide();
            pnlchoices.Hide();
            pnldescription.Hide();
            pnlmain.Hide();
            pnlconfirm.Show();
            switch (choice)
            {
                case 1:
                    dependencies.Add("HoloChat");
                    break;
                case 2:
                    dependencies.Add("HoloChat");
                    dependencies.Add("Network Browser");
                    dependencies.Add("Hacking skills");
                    break;
                case 3:
                    break;
            }
            lbconfirm.Text = "You are about to start a mission. It is worth noting that during the mission you will not be able to shut down ShiftOS, access Shiftnet applications, or access applications like Pong, Knowledge Input, Shifter, Skin Loader, Shiftorium, or other OS-modifying applications.";
            lbconfirm.Text += Environment.NewLine + Environment.NewLine + "The following things will be needed to start this mission:" + Environment.NewLine;
            foreach (var d in dependencies)
            {
                lbconfirm.Text += d + Environment.NewLine;
            }
            lbconfirm.Text += Environment.NewLine + "During the mission, a window will appear near the top of the screen showing you what to do. You can also use the 'quests' Terminal Command to view a list of everything you need to do.";
        }

        private void btnbegin_Click(object sender, EventArgs e)
        {
            API.CreateInfoboxSession("Begin mission", "Are you sure you'd like to start this mission? You will not be able to access many applications or shut down ShiftOS until you have completed the mission.", infobox.InfoboxMode.YesNo);
            API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetInfoboxResult();
                if (res == "Yes")
                {
                    SetupConfirmUI();
                }
            };
        }

        private void onClose(object sender, FormClosingEventArgs e)
        {
            Audio.ForceStop();
        }

        bool musicEnabled = true;

        private void button1_Click(object sender, EventArgs e)
        {
            if (musicEnabled)
            {
                Audio.ForceStop();
            }
            else
            {
                Audio.Play("hackerbattle_ambient");
            }
            musicEnabled = !musicEnabled;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            API.CreateInfoboxSession("Return to Desktop", "You came this far and are ready to stop DevX, but you are really willing to cancel and go to your desktop?", infobox.InfoboxMode.YesNo);
            API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetInfoboxResult();
                if (res == "Yes")
                {
                    this.Close();
                    API.CreateInfoboxSession("Return to Desktop", "Very well, you can have it your way.", infobox.InfoboxMode.Info);
                }
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            API.LimitedMode = true;
            API.CurrentSession.SetupDesktop();
            API.CloseEverything();
            EndGameHandler.Initiate(choice);
        }
    }

}
