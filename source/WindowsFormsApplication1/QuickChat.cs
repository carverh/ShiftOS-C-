using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrcDotNet;

namespace ShiftOS
{
    public partial class QuickChat : Form
    {
        public QuickChat()
        {
            InitializeComponent();
        }

        ShiftOSIrcClient ConnectedClient = null;
        
        private void QuickChat_Load(object sender, EventArgs e)
        {
            pnlsetnick.Show();
            pnlcontrols.Hide();
        }

        
        private void txtmessages_TextChanged(object sender, EventArgs e)
        {
        }

        //I'm fucking lucky I was able to get this working first try.
        private void tmrimfuckinglucky_Tick(object sender, EventArgs e)
        {
            try {
                if (ConnectedClient.CanReceiveMessages == true)
                {
                    if (ConnectedClient.Messages.Count > 20)
                    {
                        ConnectedClient.Messages.Remove(ConnectedClient.Messages[20]);
                    }
                    txtmessages.Lines = ConnectedClient.Messages.ToArray();
                    lbnick.Text = ConnectedClient.LocalUser.NickName;
                    btnsend.Enabled = true;
                }
                if(ConnectedClient.ErrorMessages.Count > 0)
                {
                    API.CreateInfoboxSession("QuickChat error", ConnectedClient.ErrorMessages[0], infobox.InfoboxMode.Info);
                    ConnectedClient.Dispose();
                    this.Close();
                }
            }
            catch
            {

            }
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConnectedClient.CanReceiveMessages == true)
                {
                    if (txtmessage.Text.Length > 0)
                    {
                        ConnectedClient.Messages.Add($"<{ConnectedClient.LocalUser.NickName}> {txtmessage.Text}");
                        ConnectedClient.SendMessage($"{txtmessage.Text}");
                        txtmessage.Text = "";
                    }
                }
            }
            catch
            {

            }
        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            var res = txtsetnick.Text;
            if (res != "")
            {
                ConnectedClient = new ShiftOSIrcClient(res);
                pnlsetnick.Hide();
                pnlcontrols.Show();
            }
            else
            {
                API.CreateInfoboxSession("QuickChat - Nickname not valid.", "That nickname is not valid. Your name will be automatically generated.", infobox.InfoboxMode.Info);
                ConnectedClient = new ShiftOSIrcClient();
                pnlsetnick.Hide();
                pnlcontrols.Show();
            }
        }

        private void txtsetnick_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnconnect_Click(sender, (EventArgs)e);
            }
        }
    }

    public class ShiftOSIrcClient : IrcClient
    {
        public ShiftOSIrcClient()
        {
            var rnd = new Random();
            var nick_id = rnd.Next(10000, 99999);
            this.Connected += (object sender, EventArgs a) =>
            {
                this.MotdReceived += new EventHandler<System.EventArgs>(this.motd_received); 
            };
            this.ConnectFailed += (object s, IrcErrorEventArgs a) =>
            {
                ErrorMessages.Add("Could not connect to the QuickChat chatroom. " + a.Error.Message);
            };
            this.RawMessageReceived += (object s, IrcRawMessageEventArgs a) =>
            {

            };
            this.Connect("irc.playshiftos.ml", 6667, false, new IrcUserRegistrationInfo { NickName = $"shifter_{nick_id}", RealName = $"QuickChat: {API.CurrentSave.username}", UserName = $"shifter_{nick_id}" });

        }
        private List<string> errmsg = new List<string>();

        public List<string> ErrorMessages
        {
            get
            {
                return errmsg;
            }
        }
        private bool running = false;

        public bool CanReceiveMessages
        {
            get
            {
                return running;
            }
        }

        private List<string> msgs = new List<string>();

        public void SendMessage(string msg)
        {
            if(running == true)
            {
                SendRawMessage($"PRIVMSG #shiftos :{msg}");
            }
        }

        public List<string> Messages
        {
            get
            {
                return msgs;
            }
        }

        public void motd_received(object sender, EventArgs a)
        {
            LocalUser.JoinedChannel += (object s, IrcChannelEventArgs e) =>
            {
                running = true;
                msgs.Add("<QuickChat> Welcome to QuickChat!");
                e.Channel.MessageReceived += (object se, IrcMessageEventArgs ea) =>
                {
                    if (!msgs.Contains($"<{ea.Source.Name}> {ea.GetText()}"))
                    {
                        msgs.Add($"<{ea.Source.Name}> {ea.GetText()}");
                    }
                };
            };
            Channels.Join("#shiftos");
        }

        public ShiftOSIrcClient(string nick)
        {
            this.Connected += (object sender, EventArgs a) =>
            {
                this.MotdReceived += new EventHandler<System.EventArgs>(this.motd_received);
            };
            this.ConnectFailed += (object s, IrcErrorEventArgs a) =>
            {
                ErrorMessages.Add("Could not connect to the QuickChat chatroom. " + a.Error.Message);
            };
            this.RawMessageReceived += (object s, IrcRawMessageEventArgs a) =>
            {
                if(a.RawContent.Contains("already in use"))
                {
                    ErrorMessages.Add("That nickname is already in use! Please restart QuickChat and try again.");
                }
            };
            this.Connect("irc.playshiftos.ml", 6667, false, new IrcUserRegistrationInfo { NickName = nick, RealName = $"QuickChat: {nick}", UserName = nick });

        }
    }
}
