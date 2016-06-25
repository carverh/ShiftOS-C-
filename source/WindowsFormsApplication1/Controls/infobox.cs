using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class infobox : Form
    {
        /// <summary>
        /// Creates a new Infobox instance.
        /// </summary>
        /// <param name="Message">Message to display.</param>
        /// <param name="mode">UI mode.</param>
        public infobox(string Message, InfoboxMode mode)
        {
            InitializeComponent();
            
            message = Message;
            displayMode = mode;
        }

        public string Result = "Cancelled";
        public enum InfoboxMode
        {
            YesNo,
            TextEntry,
            Info,
        }
        public InfoboxMode displayMode = InfoboxMode.Info;
        private string message = "This is an infobox.";
        public string TextEntry
        {
            get
            {
                return txtuserinput.Text;
            }
        }
        
           

        

        private void btnyes_Click(object sender, EventArgs e)
        {
            Result = "Yes";
            this.Close();
        }

        private void btnno_Click(object sender, EventArgs e)
        {
            Result = "No";
            this.Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            Result = "OK";
            this.Close();
        }

        private void infobox_Load(object sender, EventArgs e)
        {

            switch(displayMode)
            {
                case InfoboxMode.Info:
                    txtmessage.Show();
                    txtmessage.BringToFront();
                    txtmessage.Text = message;
                    this.pnlyesno.Hide();
                    this.txtuserinput.Hide();
                    break;
                case InfoboxMode.YesNo:
                    txtmessage.Show();
                    txtmessage.BringToFront();
                    txtmessage.Text = message;
                    this.pnlyesno.Show();
                    this.pnlyesno.BringToFront();
                    this.txtuserinput.Hide();
                    break;
                case InfoboxMode.TextEntry:
                    txtmessage.Hide();
                    lblintructtext.Show();
                    lblintructtext.BringToFront();
                    lblintructtext.Text = message;
                    this.pnlyesno.Hide();
                    this.txtuserinput.Show();
                    this.txtuserinput.BringToFront();
                    break;
            }
            txtuserinput.KeyDown += (object s, KeyEventArgs a) =>
            {
                if (a.KeyCode == Keys.Enter)
                {
                    a.SuppressKeyPress = true;
                    btnok_Click(s, (EventArgs)a);
                }
            };
            if (API.InfoboxesPlaySounds)
            {
                API.PlaySound(Properties.Resources.infobox);
            }
        }

        
    }
}
