using NetSockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ShiftUI;

namespace ShiftOS
{
    public partial class HoloChat : Form
    {
        /// <summary>
        /// Front-end for the HoloChat chat system.
        /// </summary>
        public HoloChat()
        {
            InitializeComponent();
        }

        public ChatClient Client = null;
        public Dictionary<string, string> IPs = null;
        
        private void HoloChat_Load(object sender, EventArgs e)
        {
            SetupUI();
            tmrui.Start();
        }

        /// <summary>
        /// Sets up the HoloCHat UI.
        /// </summary>
        public void SetupUI()
        {
            if (!API.LimitedMode)
            {
                IPs = new Dictionary<string, string>();
                lbrooms.Items.Clear();
                this.Invoke(new Action(() =>
                {
                    if (API.Upgrades["networkbrowser"] == false)
                    {
                        lbrooms.Items.Add(Hacker_Alliance.Name);
                    }
                }));

                foreach (var client in Package_Grabber.clients)
                {
                    if (client.Value.IsConnected)
                    {
                        client.Value.OnReceived += (object s, NetReceivedEventArgs<NetObject> a) =>
                        {
                            try
                            {
                                if (!IPs.ContainsKey(client.Key))
                                {
                                    var obj = (ObjectModel)a.Data.Object;
                                    if (obj.Command == "name")
                                    {
                                        string name = (string)obj.OptionalObject;
                                        IPs.Add(client.Key, name);
                                    }
                                }
                                else
                                {
                                    var obj = (ObjectModel)a.Data.Object;
                                    if (obj.Command == "name")
                                    {
                                        string name = (string)obj.OptionalObject;
                                        IPs[client.Key] = name;
                                    }
                                }
                                this.Invoke(new Action(() =>
                                {
                                    string r = "";
                                    foreach (string room in lbrooms.Items)
                                    {
                                        if (room == IPs[client.Key])
                                        {
                                            r = room;
                                        }
                                    }
                                    if (r == "")
                                    {
                                        lbrooms.Items.Add(IPs[client.Key]);
                                    }
                                }));
                            }
                            catch
                            {

                            }
                        };
                        Package_Grabber.SendMessage(client.Key, "chat get_name");
                    }
                }
                
            }
            else
            {
                if (FinalMission.EndGameHandler.FakeHoloChatRoom != null)
                {
                    lbrooms.Items.Clear();
                    lbrooms.Items.Add(FinalMission.EndGameHandler.FakeHoloChatRoom.Name);
                }
            }
        }

        private FakeChatClient Hacker_Alliance
        {
            get
            {
                var r = new FakeChatClient();
                r.Name = "The Hacker Alliance";
                r.OtherCharacters = new List<string>();
                if (!API.Upgrades["networkbrowser"])
                {
                    r.OtherCharacters.Add("Richard Ladouceur"); //Dear djdeedahx0 and other non-ShiftOS members: DEAL with the last name - I'm not creative. - Michael
                    r.OtherCharacters.Add("Hacker101");
                    r.Messages = JsonConvert.DeserializeObject<Dictionary<string, string>>(Properties.Resources.MidGame_Holochat);
                    r.Topic = "The Hacker Alliance - Please welcome our newest user!";
                }
                return r;

            }
        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            if(lbrooms.SelectedItem != null)
            {
                if (!API.LimitedMode)
                {
                    string topic = (string)lbrooms.SelectedItem;
                    if (topic == Hacker_Alliance.Name)
                    {
                        SetupFakeClient(Hacker_Alliance);
                    }
                    else
                    {
                        string ip = "";
                        foreach (var obj in IPs)
                        {
                            if (obj.Value == topic)
                            {
                                ip = obj.Key;
                            }
                        }
                        if (ip != "")
                        {
                            API.CreateInfoboxSession("Choose a Nickname", "Please enter a nick name.", infobox.InfoboxMode.TextEntry);
                            API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
                            {
                                var res = API.GetInfoboxResult();
                                if (res != "fail")
                                {
                                    SetupClient(ip, res);
                                }
                            };
                        }
                    }
                }
                else
                {
                    if((string)lbrooms.SelectedItem == FinalMission.EndGameHandler.FakeHoloChatRoom.Name)
                    {
                        SetupFakeClient(FinalMission.EndGameHandler.FakeHoloChatRoom);
                    }
                }
            }
        }

        /// <summary>
        /// Set up a new client.
        /// </summary>
        /// <param name="address">IP address.</param>
        /// <param name="nick">User nickname.</param>
        public void SetupClient(string address, string nick)
        {
            var c = new ChatClient(address, nick);
            c.OnMessageReceive += (object s, EventArgs a) =>
            {
                var obj = (ChatMessage)s;
                this.Invoke(new Action(() =>
                {
                    txtchat.AppendText(Environment.NewLine + $"<{obj.User.Name}> {obj.Text}");
                }));
                c.GetUsers();
            };
            c.OnUserListReceived += (object s, EventArgs a) =>
            {
                var obj = (List<ChatUser>)s;
                this.Invoke(new Action(() =>
                {
                    lbusers.Items.Clear();
                    foreach (var user in obj)
                    {
                        lbusers.Items.Add(user.Name);
                    }
                }));
            };
            c.OnUserJoin += (object s, EventArgs a) =>
            {
                var obj = (ChatUser)s;
                this.Invoke(new Action(() =>
                {

                    txtchat.AppendText(Environment.NewLine + $"{obj.Name} has joined this room.");
                }));
                c.GetUsers();
            };
            c.OnTopicReceived += (object s, EventArgs a) =>
            {
                string topic = (string)s;
                this.Invoke(new Action(() =>
                {
                    lbtopic.Text = topic;
                }));
            };
            c.OnUserLeave += (object s, EventArgs a) =>
            {
                var obj = (ChatUser)s;
                this.Invoke(new Action(() =>
                {
                    txtchat.AppendText(Environment.NewLine + $"{obj.Name} has left this room.");
                }));
                c.GetUsers();
            };
            c.GetUsers();
            c.GetTopic();
            Client = c;

        }

        public void SetupFakeClient(FakeChatClient fClient)
        {
            lbtopic.Text = fClient.Topic;
            var t = new ShiftUI.Timer();
            t.Interval = 500;
            t.Tick += (object s, EventArgs a) =>
            {
                //userlist
                lbusers.Items.Clear();
                foreach (var user in fClient.OtherCharacters)
                {
                    lbusers.Items.Add(user);
                }
            };
            t.Start();

            int m = 0;
            //message buffer
            var mb = new ShiftUI.Timer();
            mb.Tick += (object s, EventArgs a) =>
            {
                string message = fClient.Messages.Keys.ElementAt(m);
                string user = fClient.Messages[message];
                //show message on textbox
                if (message.StartsWith("install:"))
                {
                    try
                    {
                        string upg = message.Remove(0, 8);
                        API.Upgrades[upg] = true;
                        API.CurrentSession.SetupDesktop();
                    }
                    catch
                    {

                    }
                }
                else
                {
                    txtchat.AppendText(Environment.NewLine + $"<{user}> {message}");
                }
                if (m < fClient.Messages.Count - 1)
                {
                    m += 1;
                }
                else
                {
                    mb.Stop();
                    //Completed the objective!
                    FinalMission.EndGameHandler.GoToNextObjective();
                }
            };
            mb.Interval = 4000;
            mb.Start();
            tmrui.Stop();
            pnlintro.Hide();
        }

        private void txtsend_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (txtsend.Text != "")
                {
                    if (txtsend.Text.ToLower() == "/disconnect")
                    {
                        Client.Leave();
                        Client = null;
                        txtsend.Text = "";
                    }
                    else {
                        Client.Send(txtsend.Text);
                        txtsend.Text = "";
                    }
                }
            }
        }

        private void me_Closing(object sender, FormClosingEventArgs e)
        {
            if(Client != null)
            {
                Client.Leave();
            }
        }

        private void tmrui_Tick(object sender, EventArgs e)
        {
            if(Client == null)
            {
                pnlintro.Show();
                txtsend.Enabled = false;
            }
            else
            {
                pnlintro.Hide();
                txtsend.Enabled = true;
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            SetupUI();
        }

        private void txtchat_TextChanged(object sender, EventArgs e)
        {
            txtchat.Select(txtchat.TextLength, 0);
            txtchat.ScrollToCaret();
            txtsend.Focus();
        }
    }

    public class ChatClient
    {
        #region Constructors

        /// <summary>
        /// Creates a new chat client.
        /// </summary>
        /// <param name="IP">IP address</param>
        /// <param name="nick">User nickname</param>
        public ChatClient(string IP, string nick)
        {
            NetObjectClient c = null;
            foreach(var client in Package_Grabber.clients)
            {
                if(client.Key == IP)
                {
                    if(client.Value.IsConnected == true)
                    {
                        c = client.Value;
                        IP_Address = IP;
                    }
                }
            }
            if(c != null)
            {
                c.OnReceived += (object s, NetReceivedEventArgs<NetObject> a) =>
                {
                    try {
                        var obj = (ObjectModel)a.Data.Object;
                        string[] args = obj.Command.Split(' ');
                        if (args[0] == "chat")
                        {
                            switch (args[1])
                            {
                                case "userbanned":
                                    try
                                    {
                                        var usr = (ChatUser)obj.OptionalObject;
                                        if(usr.Name == nick)
                                        {
                                            API.CurrentSession.Invoke(new Action(() =>
                                            {
                                                API.CreateInfoboxSession("You're banned.", "You have been banned from this chat.", infobox.InfoboxMode.Info);
                                                Leave();
                                            }));
                                        }
                                    }
                                    catch
                                    {

                                    }
                                    break;
                                case "auth_req":
                                    try
                                    {
                                        var usr = (ChatUser)obj.OptionalObject;
                                        if (usr.Name == nick)
                                        {
                                            Thread.Sleep(1000);
                                            API.CurrentSession.Invoke(new Action(() =>
                                            {
                                                API.CreateInfoboxSession("Enter Password", "Please enter your password.", infobox.InfoboxMode.TextEntry);
                                                API.InfoboxSession.FormClosing += (object sen, FormClosingEventArgs arg) =>
                                                {
                                                    var result = API.GetInfoboxResult();
                                                    AuthenticateWithServer(usr.Name, result);
                                                };
                                            }));
                                        }
                                    }
                                    catch
                                    {

                                    }
                                    break;
                                case "auth_fail":
                                    try
                                    {
                                        var usr = (ChatUser)obj.OptionalObject;
                                        if (usr.Name == nick)
                                        {
                                            API.CurrentSession.Invoke(new Action(() =>
                                            {
                                                API.CreateInfoboxSession("Error", "You have entered an incorrect password.", infobox.InfoboxMode.Info);
                                            }));
                                        }
                                    }
                                    catch
                                    {

                                    }

                                    break;
                                case "joined":
                                    try
                                    {
                                        var usr = (ChatUser)obj.OptionalObject;
                                        if (usr.Name == nick)
                                        {
                                            if (_User == null)
                                            {
                                                _User = usr;
                                            }
                                        }
                                        if (_User != usr)
                                        {
                                            var h = OnUserJoin;
                                            if (h != null)
                                            {
                                                h(usr, new EventArgs());
                                            }
                                        }
                                    }
                                    catch
                                    {

                                    }
                                    break;
                                case "userlist":
                                    try
                                    {
                                        var lst = (List<ChatUser>)obj.OptionalObject;
                                        var h = OnUserListReceived;
                                        if (h != null)
                                        {
                                            h(lst, new EventArgs());
                                        }
                                    }
                                    catch
                                    {

                                    }
                                    break;
                                case "left":
                                    try
                                    {
                                        var usr = (ChatUser)obj.OptionalObject;
                                        var h = OnUserLeave;
                                        if (h != null)
                                        {
                                            h(usr, new EventArgs());
                                        }
                                    }
                                    catch
                                    {

                                    }
                                    break;
                                case "message_received":
                                    try
                                    {
                                        var usr = (ChatMessage)obj.OptionalObject;
                                        var h = OnMessageReceive;
                                        if (h != null)
                                        {
                                            h(usr, new EventArgs());
                                        }
                                    }
                                    catch
                                    {

                                    }
                                    break;
                            }
                        }
                        else if (args[0] == "topic")
                        {
                            try
                            {
                                string name = (string)obj.OptionalObject;
                                var h = OnTopicReceived;
                                if(h != null)
                                {
                                    h(name, new EventArgs());
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    catch
                    {

                    }
                };
                Join(nick);
            }
            else
            {
                throw new ArgumentException("IP Address not found.");
            }
        }
        #endregion

        #region Events

        public event EventHandler OnUserJoin;
        public event EventHandler OnUserLeave;
        public event EventHandler OnMessageReceive;
        public event EventHandler OnUserListReceived;
        public event EventHandler OnTopicReceived;


        #endregion

        #region Variables

        private string IP_Address = null;
        public ChatUser User { get { return _User; } }
        private ChatUser _User = null;
        #endregion

        #region Methods

        /// <summary>
        /// Authenticates with the server.
        /// </summary>
        /// <param name="password">Password to authenticate using.</param>
        public void AuthenticateWithServer(string nick, string password)
        {
            var usr = new ChatUser();
            usr.Name = nick;
            var msg = new ChatMessage();
            msg.Text = password;
            msg.User = usr;
            Package_Grabber.SendMessage(IP_Address, "chat authenticate", msg);
        }

        /// <summary>
        /// Joins the server.
        /// </summary>
        /// <param name="nick">Nickname.</param>
        public void Join(string nick)
        {
            var usr = new ChatUser();
            usr.Name = nick;
            var msg = new ChatMessage();
            msg.User = usr;
            Package_Grabber.SendMessage(IP_Address, "chat join", msg);
        }

        /// <summary>
        /// Leaves the server.
        /// </summary>
        public void Leave()
        {
            if (_User != null)
            {
                var msg = new ChatMessage();
                msg.User = _User;
                Package_Grabber.SendMessage(IP_Address, "chat leave", msg);
            }
        }

        /// <summary>
        /// Requests a list of online users.
        /// </summary>
        public void GetUsers()
        {
            try
            {
                Package_Grabber.SendMessage(IP_Address, "chat get_users");
            }
            catch
            {

            }
        }

        /// <summary>
        /// Requests the topic string of the server.
        /// </summary>
        public void GetTopic()
        {
            try
            {
                Package_Grabber.SendMessage(IP_Address, "chat get_topic");
            }
            catch
            {

            }
        }

        /// <summary>
        /// Sends a message to the server.
        /// </summary>
        /// <param name="Text">Message text.</param>
        public void Send(string Text)
        {
            if (_User != null)
            {
                var msg = new ChatMessage();
                msg.User = _User;
                msg.Text = Text;
                Package_Grabber.SendMessage(IP_Address, "chat normal", msg);

            }
        }

        #endregion
    }

    public class FakeChatClient
    {
        public string Name { get; set; }
        public string Topic { get; set; }
        public List<string> OtherCharacters { get; set; }
        public Dictionary<string, string> Messages { get; set; }
    }
}
