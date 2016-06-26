using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS.Online.Hacking
{
    [Serializable]
    public class Module
    {
        public string Hostname { get; set; }
        public int Grade { get; set; }
        public int HP { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Type { get; set; } //will be converted by the client
    }

    [Serializable]
    public class Network
    {
        public string Name { get; set; }
        public int Codepoints { get; set; }
        public string Description { get; set; }
        public int Losses { get; set; }
        public int Wins { get; set; }
    }
    
    [Serializable]
    public class ServerInfo
    {
        public string ServerName { get; set; }
        public int PlayersAwaitingMatch { get; set; }
        public string IPAddress { get; set; }
    }
}
