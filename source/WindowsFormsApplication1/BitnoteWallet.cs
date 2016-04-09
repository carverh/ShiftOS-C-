using NetSockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class BitnoteWallet : Form
    {
        /// <summary>
        /// GUI for the Bitnote Wallet package.
        /// </summary>
        public BitnoteWallet()
        {
            InitializeComponent();
            Clients = new List<BitnoteClient>();
            foreach(var c in Package_Grabber.clients)
            {
                if(c.Value.IsConnected)
                {
                    var client = new BitnoteClient(c.Key);
                    client.GetBank();
                    Clients.Add(client);
                }
            }
        }

        public List<BitnoteClient> Clients = null;

        public bool AddBitnotesToAddress(string addr, decimal amount)
        {
            bool res = false;
            foreach(var c in Clients)
            {
                if(c.Addresses != null)
                {
                    foreach(var a in c.Addresses)
                    {
                        if(a.Address == addr)
                        {
                            if (res == false)
                            {
                                a.Bitnotes += amount;
                                res = true;
                            }
                        }
                    }
                    c.UploadBank(c.Addresses);
                }
            }
            return res;
        }

        private void btnsync_Click(object sender, EventArgs e)
        {
            try
            {
                var t = new BackgroundWorker();
                t.DoWork += (object s, DoWorkEventArgs a) =>
                {

                    foreach(var c in Clients)
                    {
                        SyncBitnotes(c.Addresses);
                        c.UploadBank(c.Addresses);
                    }
                };
                t.RunWorkerAsync();
            }
            catch(Exception ex)
            {
                SyncBitnotes(new List<SaveSystem.PrivateBitnoteAddress>());
                API.CreateInfoboxSession("Error", "You cannot sync your Bitnotes as the connection to the server has failed.", infobox.InfoboxMode.Info);
            }
        }

        /// <summary>
        /// Syncs your private address with the provided list IF yours exists in there. If not, it'll add it.
        /// </summary>
        /// <param name="lst">The list to sync.</param>
        public void SyncBitnotes(List<SaveSystem.PrivateBitnoteAddress> lst)
        {
            bool cont = false;
            int my_itm = 0;
            foreach (var itm in lst)
            {
                if(itm.Address == API.BitnoteAddress.Address)
                {
                    cont = true;
                    my_itm = lst.IndexOf(itm);
                }
            }
            if(cont == true)
            {
                if(lst[my_itm].Bitnotes < API.BitnoteAddress.Bitnotes)
                {
                    lst[my_itm].Bitnotes = API.BitnoteAddress.Bitnotes;
                }
                else
                {
                    API.BitnoteAddress.Bitnotes = lst[my_itm].Bitnotes;
                }
            }
            else
            {
                lst.Add(API.BitnoteAddress);
            }
        }

        public void UploadList(BitnoteClient client, List<SaveSystem.PrivateBitnoteAddress> lst)
        {
            client.UploadBank(lst);
        }

        
        private void btnsend_Click(object sender, EventArgs e)
        {
            sendpanel.Show();
        }

        public void Info(string message) => API.CreateInfoboxSession("Error", message, infobox.InfoboxMode.Info);

        private void btnconfirmsend_Click(object sender, EventArgs e)
        {
            if (txtrecipient.Text != "")
            {
                if (AddBitnotesToAddress(txtrecipient.Text, Convert.ToDecimal(Convert.ToDecimal(txtamount.Text).ToString("#.#####"))))
                {
                    Info("The Bitnotes have been sent successfully.");
                }
                else
                {
                    Info("That address doesn't exist in the database.");
                }
            }
            else
            {
                Info("You must enter a recipient Bitnote address!");
            }
            sendpanel.Hide();
        }

        private void tmrrefresh_Tick(object sender, EventArgs e)
        {
            if(API.BitnoteAddress == null)
            {
                SaveSystem.Utilities.BitnoteAddress = new SaveSystem.PrivateBitnoteAddress();
                SaveSystem.Utilities.BitnoteAddress.Bitnotes = 0;
                SaveSystem.Utilities.BitnoteAddress.Address = SaveSystem.Utilities.GenerateNewBitnoteAddress();
            }
            txtmyaddress.Text = API.BitnoteAddress.Address;
            if(API.BitnoteAddress.Bitnotes == 0)
            {
                lbmybitnotes.Text = "0 BTN";
            }
            else
            {
                lbmybitnotes.Text = API.BitnoteAddress.Bitnotes.ToString("#.#####") + " BTN";
            }
        }

        private void BitnoteWallet_Load(object sender, EventArgs e)
        {
            fltopbar.BackColor = API.CurrentSkin.titlebarcolour;
            fltopbar.ForeColor = API.CurrentSkin.titletextcolour;
        }
    }

    public class BitnoteClient
    {
        /// <summary>
        /// Creates a new Bitnote Client.
        /// </summary>
        /// <param name="IP">IP address of the server to look at.</param>
        public BitnoteClient(string IP)
        {
            try
            {
                var c = Package_Grabber.clients[IP];
                c.OnReceived += (object s, NetReceivedEventArgs<NetObject> a) =>
                {
                    var obj = (ObjectModel)a.Data.Object;
                    switch (obj.Command)
                    {
                        case "fail":
                            Addresses = new List<SaveSystem.PrivateBitnoteAddress>();
                            break;
                        case "bitnote_bank":
                            try
                            {
                                Addresses = JsonConvert.DeserializeObject<List<SaveSystem.PrivateBitnoteAddress>>(API.BitnoteEncryption.Decrypt((string)obj.OptionalObject));
                                if(Addresses == null)
                                {
                                    Addresses = new List<SaveSystem.PrivateBitnoteAddress>();
                                }
                            }
                            catch {
                                Addresses = new List<SaveSystem.PrivateBitnoteAddress>();
                            }
                            break;
                    }
                };
                _IP = IP;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("IP address not found in client list.");
            }
        }

        private string _IP = "";
        public List<SaveSystem.PrivateBitnoteAddress> Addresses = null;

        public void GetBank()
        {
            try
            {
                Package_Grabber.SendMessage(_IP, "btn getbank");
            }
            catch
            {
                
            }
        }

        public void UploadBank(List<SaveSystem.PrivateBitnoteAddress> bank)
        {
            try
            {
                Package_Grabber.SendMessage(_IP, "btn setbank", API.BitnoteEncryption.Encrypt(JsonConvert.SerializeObject(bank)));
            }
            catch
            {

            }
        }
    }
}
