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
using ShiftOS.Online.Hacking;

namespace ShiftOS
{
    public partial class NetworkBrowser : Form
    {
        public NetworkBrowser()
        {
            InitializeComponent();
        }

        public Dictionary<string, EnemyHacker> Networks = null;

        private void NetworkBrowser_Load(object sender, EventArgs e)
        {
            Online.Hacking.Matchmaker.Initiated += (o, a) =>
            {
                if (selected_server == null)
                {
                    lbonlineservers.Items.Clear();
                    foreach (var s in Online.Hacking.Matchmaker.Servers)
                    {
                        lbonlineservers.Items.Add(s.ServerName);
                    }
                }
            };
            Online.Hacking.Matchmaker.MorePlayersFound += (o, a) =>
            {
                if(selected_server != null)
                {
                    lbonlineheader.Text = selected_server.ServerName + " - Lobby";
                    lbonlinedesc.Text = $@"Network Browser is waiting for the server to pair you with another network...


Players in lobby: {Online.Hacking.Matchmaker.Players.Count}

{API.CurrentSave.MyOnlineNetwork.Name} - My Network:
 - {Hacking.MyNetwork.Count} available modules
 - {API.Codepoints} codepoints
 - {API.CurrentSave.MyOnlineNetwork.Wins} wins, {API.CurrentSave.MyOnlineNetwork.Losses} losses.

You can set your name and description in the Network Status page.";

                }
            };
            LoadNetworks();
            SetupSidePane();
            pnlmynet.Hide();
        }

        public string CurrentTier = "easy";
        public EnemyHacker SelectedNet = null;

        public void LoadNetworks()
        {
            switch(CurrentTier)
            {
                case "easy":
                    btntier.Text = "1";
                    break;
                case "medium":
                    btntier.Text = "2";
                    break;
                case "hard":
                    btntier.Text = "3";
                    break;
            }
            Networks = JsonConvert.DeserializeObject<Dictionary<string, EnemyHacker>>(Properties.Resources.NetBrowser_Enemies);
            lbnets.Items.Clear();
            var Tier1 = new List<string>();
            var Tier2 = new List<string>();
            var Tier3 = new List<string>();

            foreach (var net in Networks)
            {
                if (!API.CurrentSave.CompletedNets.Contains(net.Key))
                {
                    switch (net.Value.Difficulty)
                    {
                        case "easy":
                            Tier1.Add(net.Key);
                            break;
                        case "medium":
                            Tier2.Add(net.Key);
                            break;
                        case "hard":
                            Tier3.Add(net.Key);
                            break;
                    }
                }
            }

            switch (CurrentTier)
            {
                case "easy":
                    SetupUI(Tier1);
                    break;
                case "medium":
                    SetupUI(Tier2);
                    break;
                case "hard":
                    SetupUI(Tier3);
                    break;
            }
        }

        public void SetupSidePane()
        {
            if(SelectedNet != null)
            {
                lbtitle.Text = SelectedNet.Name;
                lbnetdesc.Text = SelectedNet.Description + @"

Leader hack speed: " + SelectedNet.FriendSpeed.ToString() + @"
Leader hack skill: " + SelectedNet.FriendSkill.ToString() + @"

Those above values only matter if the leader decides to become a friend. If they do, you can hire them for free to hack into certain ShiftOS applications.";
                btnstartbattle.Enabled = true;
            }
            else
            {
                lbtitle.Text = "Network Browser";
                lbnetdesc.Text = "No network selected.";
                btnstartbattle.Enabled = false;
            }
        }

        public void SetupUI(List<string> tier)
        {
            pnlonline.Visible = online_mode;
            pnlonline.BringToFront();
            btnjoinlobby.Enabled = (selected_server != null);
            if (online_mode)
            {
                if(Online.Hacking.Matchmaker.Servers == null)
                {
                    Online.Hacking.Matchmaker.Initiate();
                }
            }
            else
            {
                if (tier.Count > 0)
                {
                    foreach (var t in tier)
                    {
                        lbnets.Items.Add(t);
                    }
                }
                else
                {
                    AddLeader(CurrentTier);
                }
            }
        }

        public void AddLeader(string tier)
        {
            if (API.Upgrades["nb_tier_" + tier] == false)
            {
                var enemy = JsonConvert.DeserializeObject<EnemyHacker>(Get_Leader_JSON(tier));
                Networks.Add(enemy.Name, enemy);
                lbnets.Items.Add(enemy.Name);
            }
        }

        public string Get_Leader_JSON(string tier)
        {
            switch(tier)
            {
                case "easy":
                    return Properties.Resources.Hacker_DanaRoss;
                case "medium":
                    return Properties.Resources.Hacker_AustinWalker;
                case "hard":
                    return Properties.Resources.Hacker_JonathanRivard;
                default:
                    return null;

            }
        }

        private void btntier_Click(object sender, EventArgs e)
        {
            switch(btntier.Text)
            {
                case "1":
                    if(API.Upgrades["nb_tier_easy"] == true)
                    {
                        CurrentTier = "medium";
                    }
                    break;
                case "2":
                    if (API.Upgrades["nb_tier_medium"] == true)
                    {
                        CurrentTier = "hard";
                    }
                    else
                    {
                        CurrentTier = "easy";
                    }
                    break;
                case "3":
                    CurrentTier = "easy";
                    break;
            }
            LoadNetworks();
        }

        private void lbnets_SelectedIndexChanged(object sender, EventArgs e)
        {
            var t = lbnets.SelectedItem as string;
            foreach(var net in Networks)
            {
                if(net.Key == t)
                {
                    SelectedNet = net.Value;
                }
            }
            SetupSidePane();
        }

        private void btnstartbattle_Click(object sender, EventArgs e)
        {
            if (Hacking.MyCore.HP == 0)
            {
                SetupMyNet();
                pnlmynet.Show();
                btnscreen.Text = "My Network";
                API.CreateInfoboxSession("Your Core isn't ready.", "Your Core (hostname \"localhost\") has 0 HP, and cannot fight. Please wait until your Core regenerates.", infobox.InfoboxMode.Info);
            }
            else
            {
                if (online_mode == false)
                {
                    string tier_upgrade = null;
                    if (SelectedNet.IsLeader == true)
                    {
                        tier_upgrade = "nb_tier_" + CurrentTier;
                    }
                    var hui = new HackUI(SelectedNet);
                    hui.OnWin += (object s, EventArgs a) =>
                    {
                        if (tier_upgrade != null)
                        {
                            API.Upgrades[tier_upgrade] = true;
                            if (CurrentTier == "easy")
                            {
                                if (API.Upgrades["midgamebridge"] == false)
                                {
                                    var term = new Terminal();
                                    API.CreateForm(term, API.LoadedNames.TerminalName, API.GetIcon("Terminal"));
                                    term.StartDanaRossStory();
                                }
                            }
                            else if (CurrentTier == "medium")
                            {
                                var h = new HoloChat();
                                var fakeroom = new FakeChatClient();
                                fakeroom.Name = "The Hacker Alliance";
                                fakeroom.Topic = "The Hacker Alliance - We are the masters. DevX cannot control us.";
                                fakeroom.OtherCharacters = new List<string>(new[] { "Richard Ladouceur" });
                                fakeroom.Messages = JsonConvert.DeserializeObject<Dictionary<string, string>>(Properties.Resources.AustinWalkerCompletionStory);
                                API.CreateForm(h, "QuickChat", API.GetIcon("QuickChat"));
                                var t = new Thread(new ThreadStart(new Action(() =>
                                {
                                    Thread.Sleep(200);
                                    h.Invoke(new Action(() =>
                                    {
                                        h.SetupFakeClient(fakeroom);
                                    }));
                                })));

                            }
                            foreach (var mod in SelectedNet.Network)
                            {
                                if (mod.Type != SystemType.Core)
                                {
                                    mod.HP = 0;
                                    Hacking.MyNetwork.Add(mod);
                                }
                            }
                            SetupMyNet();
                        }
                        API.CurrentSave.CompletedNets.Add(SelectedNet.Name);
                        SelectedNet = null;
                        LoadNetworks();
                        SetupSidePane();
                    };
                    hui.Show();
                }
                else
                {
                    //nyi
                }
            }
        }

        public void SetupMyNet()
        {
            flmodules.Widgets.Clear();
            foreach(var m in Hacking.MyNetwork)
            {
                var mStatus = new NetModuleStatus(m);
                flmodules.Widgets.Add(mStatus);
                mStatus.Show();
            }
        }

        private void btnscreen_Click(object sender, EventArgs e)
        {
            switch (btnscreen.Text)
            {
                case "My Network":
                    LoadNetworks();
                    SetupSidePane();
                    pnlmynet.Hide();
                    btnscreen.Text = "Network List";
                    break;
                case "Network List":
                    SetupMyNet();
                    pnlmynet.Show();
                    btnscreen.Text = "My Network";
                    break;
            }
            
        }

        private void tmrcalctotal_Tick(object sender, EventArgs e)
        {
            int total = 0;
            int hp = 0;
            foreach(var mod in Hacking.MyNetwork)
            {
                total += mod.GetTotalHP();
                hp += mod.HP;
            }
            pgtotalhealth.MaxValue = total;
            pgtotalhealth.Value = hp;
        }

        bool online_mode = false;
        
        private void button1_Click(object sender, EventArgs e)
        {
            var me = API.CurrentSave.MyOnlineNetwork;
            if (me.Name == null && me.Description == null)
            {
                pnlmynet.Show();
                pnlmynet.BringToFront();
                SetupMyNet();
                API.CreateInfoboxSession("Make a name for yourself.", "Before you can battle online, please enter a name and a description that people will see when you matchmake. When you're done, click Battle Online again.", infobox.InfoboxMode.Info);
            }
            else
            {
                online_mode = !online_mode;
                LoadNetworks();
            }
        }

        Online.Hacking.ServerInfo selected_server = null;

        private void lbonlineservers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var server_name = lbonlineservers.SelectedItem as string;
            var server = new Online.Hacking.ServerInfo();
            foreach(var srv in Online.Hacking.Matchmaker.Servers)
            {
                if (srv.ServerName == server_name)
                    server = srv;
            }
            selected_server = server;
            LoadNetworks();
        }

        private void btnjoinlobby_Click(object sender, EventArgs e)
        {
            lbonlineservers.Hide();
            API.CurrentSave.MyOnlineNetwork.Codepoints = API.Codepoints;
            Package_Grabber.SendMessage(selected_server.IPAddress, $"join_lobby {JsonConvert.SerializeObject(API.CurrentSave.MyOnlineNetwork)}");
            Online.Hacking.Matchmaker.Matchmake(selected_server);
            var t = new ShiftUI.Timer();
            t.Interval = 5000;
            int sindex = 0;
            t.Tick += (o, a) =>
            {
                try
                {
                    SetupSidePane(Online.Hacking.Matchmaker.Players[sindex]);
                    if (Matchmaker.Players.Count > 1)
                    {
                        if (sindex < Online.Hacking.Matchmaker.Players.Count - 1)
                        {
                            sindex = 0;
                        }
                        else
                        {
                            sindex += 1;
                        }
                    }
                }
                catch
                {

                }
            };
            t.Start();
        }

        private void SetupSidePane(Network network)
        {
            try
            {
                lbtitle.Text = network.Name;
                lbnetdesc.Text = $@"{network.Description}

 - {network.Codepoints} codepoints.
 - {network.Wins} wins, {network.Losses} losses.";
            }
            catch
            {
                lbtitle.Text = "<null>";
                lbnetdesc.Text = @"<no description>

 - unknown codepoints.
 - unknown wins, unknown losses.


If you see this happen, it's a phantom client. The server won't pair you with it.";
            }
        }

        private void stop_matchmake(object sender, FormClosingEventArgs e)
        {
            if(selected_server != null)
            {
                Package_Grabber.SendMessage(selected_server.IPAddress, $"leave_lobby {JsonConvert.SerializeObject(API.CurrentSave.MyOnlineNetwork)}");
            }
        }

        private void txtmydescription_TextChanged(object sender, EventArgs e)
        {
            API.CurrentSave.MyOnlineNetwork.Description = txtmydescription.Text;
        }

        private void txtmyname_TextChanged(object sender, EventArgs e)
        {
            API.CurrentSave.MyOnlineNetwork.Name = txtmyname.Text;
        }
    }
}
