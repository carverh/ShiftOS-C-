using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS.Online.Hacking
{
    public class Matchmaker
    {
        public static List<ServerInfo> Servers = null;
        public static List<Network> Players = null;

        public static ServerInfo SelectedServer = null;
        public static Network SelectedNetwork = null;
        public static NetListener SelectedNetworkListener = null;
        public static NetTransmitter SelectedNetworkTransmitter = null;

        public static Timer MakerTimer = null;

        public static void Initiate()
        {
            MakerTimer = new Timer();
            MakerTimer.Interval = 100;

            Servers = new List<ServerInfo>();
            foreach(var c in Package_Grabber.clients)
            {
                c.Value.OnReceived += (o, e) =>
                {
                    var om = (e.Data.Object as ObjectModel);
                    if(om.Command == "server_info")
                    {
                        var si = JsonConvert.DeserializeObject<ServerInfo>(om.OptionalObject as string);
                        si.IPAddress = c.Value.RemoteHost;
                        Servers.Add(si);
                        invoke(() =>
                        {
                            Initiated?.Invoke(null, new EventArgs());
                        });
                    }
                };
                Package_Grabber.SendMessage(c.Value.RemoteHost, "get_info");
            }
        }

        public static void Matchmake(ServerInfo si)
        {
            SelectedServer = si;
            var rnd = new Random();
            Players = new List<Network>();
            var server = Package_Grabber.clients[si.IPAddress];
            server.OnReceived += (o, e) =>
            {
                var om = e.Data.Object as ObjectModel;
                if (om.Command == "matchmaking")
                {
                    Players = JsonConvert.DeserializeObject<List<Network>>(om.OptionalObject as string);
                    invoke(() =>
                    {
                        MorePlayersFound?.Invoke(null, new EventArgs());
                    });
                }
            };
            Package_Grabber.SendMessage(si.IPAddress, "get_matchmaking");
            int index = 0;
            MakerTimer.Tick += (o, e) =>
            {
                try
                {
                    if (Players[index].Name != API.CurrentSave.MyOnlineNetwork.Name && Players[index].Name != null)
                    {
                        SelectedNetwork = Players[index];
                        MakerTimer.Stop();
                        SelectedNetworkListener = new NetListener(si, SelectedNetwork);
                        SelectedNetworkTransmitter = new NetTransmitter(si, SelectedNetwork);
                        Package_Grabber.SendMessage(SelectedServer.IPAddress, $"leave_lobby {JsonConvert.SerializeObject(API.CurrentSave.MyOnlineNetwork)}");
                    }
                    else
                    {
                        index += 1;
                    }
                }
                catch (Exception ex)
                {
                }
            };
            MakerTimer.Interval = 50;
            MakerTimer.Start();
        }



        public static event EventHandler Initiated;
        public static event EventHandler MorePlayersFound;
        public static void invoke(Action method)
        {
            API.CurrentSession.Invoke(method);
        }

    }

    public class NetListener
    {
        public NetListener(ServerInfo si, Network net)
        {
            register_events(si, net);
            
        }

        public List<Module> MyModules = null;

        private void register_events(ServerInfo si, Network net)
        {
            MyModules = new List<Module>();
            var server = Package_Grabber.clients[si.IPAddress];
            server.OnReceived += (o, e) =>
            {
                if(e.Data.Object is string)
                {
                    var data = JsonConvert.DeserializeObject<ObjectModel>(e.Data.Object as string);
                    string[] args = data.Command.Split(' ');
                    if ((data.OptionalObject as Network) == net) {
                        switch (args[0].ToLower())
                        {
                            case "set_health":
                                string hn = args[1];
                                int hp = Convert.ToInt32(args[2]);
                                invoke(() => { ModuleHealthSet?.Invoke(this, new Events.Health { host_name = hn, health = hp }); });
                                break;
                            case "place_module":
                                string hostname = args[1];
                                int grade = Convert.ToInt32(args[2]);
                                int newhp = Convert.ToInt32(args[3]);
                                int x = Convert.ToInt32(args[4]);
                                int y = Convert.ToInt32(args[5]);
                                int type = Convert.ToInt32(args[6]);
                                var moduleToPlace = new Module { Grade = grade, Hostname = hostname, HP = newhp, Type = type, X = x, Y = y };
                                MyModules.Add(moduleToPlace);
                                invoke(() => { ModulePlaced?.Invoke(this, new Events.ModulePlaced { new_module = moduleToPlace }); });
                                break;
                            case "remove_module":
                                string hostnametoremove = args[1];
                                var m = new Module();
                                foreach (var mod in MyModules)
                                {
                                    if (mod.Hostname == hostnametoremove)
                                    {
                                        m = mod;
                                    }
                                }
                                MyModules.Remove(m);

                                invoke(() => { ModuleRemoved?.Invoke(this, new Events.ModuleRemoved { new_module = hostnametoremove }); });
                                break;
                            case "upgrade":
                                invoke(() =>
                                {
                                    string hostnametoupgrade = args[1];
                                    int newgrade = Convert.ToInt32(args[2]);
                                    ModuleUpgraded?.Invoke(this, new Events.ModuleUpgraded { hostname = hostnametoupgrade, grade = newgrade });
                                });
                                break;
                            case "disable":
                                invoke(() =>
                                {
                                    string name = args[1];
                                    ModuleDisabled?.Invoke(this, new Events.Disabled { hostName = name });
                                });
                                break;
                        }
                    }
                }
            };
        }

        public void invoke(Action method)
        {
            API.CurrentSession.Invoke(method);
        }

        public event EventHandler<Events.Health> ModuleHealthSet;
        public event EventHandler<Events.ModulePlaced> ModulePlaced;
        public event EventHandler<Events.ModuleRemoved> ModuleRemoved;
        public event EventHandler<Events.ModuleUpgraded> ModuleUpgraded;
        public event EventHandler<Events.Disabled> ModuleDisabled;
    }

    public class NetTransmitter
    {
        public ServerInfo serverInfo = null;
        public Network EnemyIdent = null;

        public NetTransmitter(ServerInfo si, Network enemy)
        {
            EnemyIdent = enemy;
            serverInfo = si;
            var h = new HackUI(this, Matchmaker.SelectedNetworkListener);
            h.Show();
            //HackUI will handle everything else to do with our network.
        }

        public void send_message(Messages msg, object value)
        {
            switch(msg)
            {
                case Messages.PlaceModule:
                    var m = value as Module;
                    Package_Grabber.SendMessage(serverInfo.IPAddress, $"place_module {m.Hostname} {m.Grade} {m.HP} {m.X} {m.Y} {m.Type}", EnemyIdent);
                    break;
                case Messages.Upgrade:
                    string upgradestr = value as string;
                    Package_Grabber.SendMessage(serverInfo.IPAddress, $"upgrade {upgradestr}", EnemyIdent);
                    break;
                case Messages.RemoveModule:
                    string hostnametoremove = value as string;
                    Package_Grabber.SendMessage(serverInfo.IPAddress, $"remove_module {hostnametoremove}", EnemyIdent);
                    break;
                case Messages.SetHealth:
                    string healthsetstr = value as string;
                    Package_Grabber.SendMessage(serverInfo.IPAddress, $"set_health {healthsetstr}", EnemyIdent);
                    break;
                case Messages.Disabled:
                    string hnamestr = value as string;
                    Package_Grabber.SendMessage(serverInfo.IPAddress, $"disable {hnamestr}", EnemyIdent);
                    break;
            }
        }

        public enum Messages
        {
            PlaceModule,
            Upgrade,
            RemoveModule,
            SetHealth,
            Disabled,
        }
    }

    namespace Events
    {
        public class Health : EventArgs
        {
            public string host_name { get; set; }
            public int health { get; set; }
        }

        public class Disabled : EventArgs
        {
            public string hostName { get; set; }
        }

        public class ModulePlaced : EventArgs
        {
            public Module new_module { get; set; }
        }

        public class ModuleRemoved : EventArgs
        {
            public string new_module { get; set; }
        }

        public class ModuleUpgraded : EventArgs
        {
            public string hostname { get; set; }
            public int grade { get; set; }
        }



    }
}
