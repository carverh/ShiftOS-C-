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
    public partial class ConnectionManager : Form
    {
        public ConnectionManager()
        {
            InitializeComponent();
        }

        string selectednet = null;

        private void lbconnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectednet = lbconnections.SelectedItem.ToString();
                SetupUI();
            }
            catch
            {
                selectednet = null;
                SetupUI();
            }
        }

        public void SetupUI()
        {
            if(selectednet != null)
            {
                btnconnect.Visible = !Package_Grabber.clients[selectednet].IsConnected;
                btndisconnect.Visible = Package_Grabber.clients[selectednet].IsConnected;
            }
            else
            {
                btnconnect.Hide();
                btndisconnect.Hide();
            }
        }

        private void ConnectionManager_Load(object sender, EventArgs e)
        {
            SetupUI();
            var t = new Timer();
            t.Interval = 500;
            t.Tick += (object s, EventArgs a) =>
            {
                lbconnections.Items.Clear();
                foreach(var itm in Package_Grabber.clients)
                {
                    lbconnections.Items.Add(itm.Key);
                }
            };
            t.Start();
        }

        private void btndisconnect_Click(object sender, EventArgs e)
        {
            Package_Grabber.Disconnect(selectednet);
            SetupUI();
        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            Package_Grabber.ConnectToServer(selectednet, 7429);
            SetupUI();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            API.CreateInfoboxSession("Add connection", "Please type the IP Address or hostname of the server.", infobox.InfoboxMode.TextEntry);
            API.InfoboxSession.FormClosing += (o, a) =>
            {
                var res = API.GetInfoboxResult();
                if(res != "Cancelled")
                {
                    Package_Grabber.ConnectToServer(res, 7429);
                }
            };
        }
    }
}
