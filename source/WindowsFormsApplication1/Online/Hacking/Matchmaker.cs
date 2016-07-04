/* ShiftOS Online Hacker Battles - Matchmaker
 * 
 * These classes deal with keeping things in line on the client-side of things.
 * They deal with CSP (Client-Side Prediction), sending and receiving messages to
 * and from the ShiftOS server, as well as making sure that when you join or leave a
 * lobby, the server and other clients actually KNOW you did.
 * 
 * I wouldn't mess with this unless you really, really understand what you're doing,
 * as in most cases, modification to the server is required as well (in the case of
 * adding new commands). I'd leave modification to the system creator (Michael VanOverbeek) who
 * actually wrote this. He's the guy who knows all about how the server works. Wait... why am
 * I talking in third person?
 */

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
        //All available lobbies.
        public static List<ServerInfo> Servers = null;
        
        //All players in the lobby.
        public static List<Network> Players = null;

        //Some useful info about the lobby in which the player is.
        //Also contains server IP to be sent to Package_Grabber.SendMessage().
        public static ServerInfo SelectedServer = null;

        //Enemy network information (name, codepoints, etc)
        public static Network SelectedNetwork = null;

        //There's only one transmitter because generally the player
        //won't be interacting with the enemy playfield enough to
        //warrent a request to the server.
        public static NetListener SelectedNetworkListener = null; //Listen for updates from the opponent.
        public static NetTransmitter SelectedNetworkTransmitter = null; //Send messages to the server for enemy updates on opponent clients.
        public static NetListener PlayerListener = null; //For receiving non-CSP updates from the server.
        public static NetTransmitter SecondaryTransmitter = null; //For sending CSP-created update requests to the opponent (enemy health damage, etc)

        //Timer that'll run during matchmaking.
        public static Timer MakerTimer = null;

        /// <summary>
        /// This either starts matchmaking or grabs server info. Try it out I guess.
        /// 
        /// Fires: Matchmaker.Initiated
        /// </summary>
        public static void Initiate()
        {
            MakerTimer = new Timer();
            MakerTimer.Interval = 100;

            Servers = new List<ServerInfo>();
            foreach(var c in Package_Grabber.clients)
            {
                c.Value.OnReceived += (o, e) =>
                {
                    try
                    {
                        var om = (e.Data.Object as ObjectModel);
                        if (om.Command == "server_info")
                        {
                            var si = JsonConvert.DeserializeObject<ServerInfo>(om.OptionalObject as string);
                            si.IPAddress = c.Value.RemoteHost;
                            Servers.Add(si);
                            invoke(() =>
                            {
                                Initiated?.Invoke(null, new EventArgs());
                            });
                        }
                    }
                    catch
                    {

                    }
                };
                Package_Grabber.SendMessage(c.Value.RemoteHost, "get_info");
            }
        }

        /// <summary>
        /// Matchmake in the supplied lobby.
        /// 
        /// Fires: MorePlayersFound upon player leave/join.
        /// </summary>
        /// <param name="si">The server to matchmake in.</param>
        public static void Matchmake(ServerInfo si)
        {
            SelectedServer = si;
            var rnd = new Random();
            Players = new List<Network>();
            var server = Package_Grabber.clients[si.IPAddress];
            server.OnReceived += (o, e) =>
            {
                try
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
                }
                catch
                {

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
                        PlayerListener = new NetListener(si, SelectedNetwork);
                        SecondaryTransmitter = new NetTransmitter(si, API.CurrentSave.MyOnlineNetwork);
                        SelectedNetworkListener = new NetListener(si, API.CurrentSave.MyOnlineNetwork);
                        SelectedNetworkTransmitter = new NetTransmitter(si, SelectedNetwork);
                        var h = new HackUI(SelectedNetworkTransmitter, SelectedNetworkListener, PlayerListener, SecondaryTransmitter);
                        h.Show();
                        Package_Grabber.SendMessage(SelectedServer.IPAddress, $"leave_lobby {JsonConvert.SerializeObject(API.CurrentSave.MyOnlineNetwork)}");
                    }
                    else
                    {
                        index += 1;
                    }
                }
                catch
                {
                }
            };
            MakerTimer.Interval = 50;
            MakerTimer.Start();
        }


        /// <summary>
        /// Fired when Initiate() finishes.
        /// </summary>
        public static event EventHandler Initiated;

        /// <summary>
        /// Fired when someone enters/exits a lobby that we are in.
        /// </summary>
        public static event EventHandler MorePlayersFound;

        /// <summary>
        /// Helper method to allow me to invoke some code on the ShiftOS desktop thread (for UI access)
        /// </summary>
        /// <param name="method">The code to invoke (use a lambda expression or just pump a void through.)</param>
        public static void invoke(Action method)
        {
            API.CurrentSession.Invoke(method);
        }

        internal static void DestroySession()
        {
            Servers.Clear();
            Players.Clear();
            ClearEvents();
            SelectedNetwork = null;
            SelectedNetworkTransmitter = null;
            SelectedNetworkListener = null;
            PlayerListener = null;
            //Good to go, I guess.
        }

        public static void ClearEvents()
        {
            Initiated = null;
            MorePlayersFound = null;
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
                if (e.Data.Object is ObjectModel)
                {
                    
                    var data = (e.Data.Object as ObjectModel);
                    if (data.Command != null)
                    {
                        string[] args = data.Command.Split(' ');
                        if ((data.OptionalObject as Network)?.Name == net.Name)
                        {
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
                                case "finish":
                                    string json = data.Command.Remove(0, 7);
                                    var winner = JsonConvert.DeserializeObject<Network>(json);
                                    Won?.Invoke(this, new Events.Won(winner));
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
        public event EventHandler<Events.Won> Won;
    }

    public class NetTransmitter
    {
        public ServerInfo serverInfo = null;
        public Network EnemyIdent = null;

        public NetTransmitter(ServerInfo si, Network enemy)
        {
            EnemyIdent = enemy;
            serverInfo = si;
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
                case Messages.FinishBattle:
                    string json = JsonConvert.SerializeObject(value as Network);
                    Package_Grabber.SendMessage(serverInfo.IPAddress, $"finish {json}");
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
            FinishBattle,
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

        public class Won : EventArgs
        {
            public Network Winner { get; private set; }

            public Won(Network winner)
            {
                Winner = winner;
            }
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
