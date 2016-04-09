using NetSockets;
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
            IPs = new Dictionary<string, string>();
            lbrooms.Items.Clear();
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

        private void btnconnect_Click(object sender, EventArgs e)
        {
            if(lbrooms.SelectedItem != null)
            {
                string topic = (string)lbrooms.SelectedItem;
                string ip = "";
                foreach(var obj in IPs)
                {
                    if(obj.Value == topic)
                    {
                        ip = obj.Key;
                    }
                }
                if(ip != "")
                {
                    API.CreateInfoboxSession("Choose a Nickname", "Please enter a nick name.", infobox.InfoboxMode.TextEntry);
                    API.InfoboxSession.FormClosing += (object s, FormClosingEventArgs a) =>
                    {
                        var res = API.GetInfoboxResult();
                        if(res != "fail")
                        {
                            SetupClient(ip, res);
                        }
                    };
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

        private void txtsend_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
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
}
