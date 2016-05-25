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
    public partial class PanelManager : Form
    {
        public PanelManager(Skinning.DesktopPanel newPanel)
        {
            pnl = newPanel;
            InitializeComponent();
        }

        private Skinning.DesktopPanel pnl = null;

        private void setbgcolor(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                API.CreateColorPickerSession("Panel Background", pnl.BackgroundColor);
                API.ColorPickerSession.FormClosing += (s, a) =>
                {
                    var c = API.GetLastColorFromSession();
                    pnl.BackgroundColor = c;
                    pnl.BackgroundImage = null;
                };
            }
            else if(e.Button == MouseButtons.Right)
            {
                API.CreateGraphicPickerSession("Panel Background", false);
                API.GraphicPickerSession.FormClosing += (s, a) =>
                {
                    var img = API.GraphicPickerSession.IdleImage;
                    pnl.BackgroundImage = img;
                };
            }
        }

        private void txtheight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int height = Convert.ToInt32(txtheight.Text);
                pnl.Height = height;
            }
            catch
            {
                txtheight.Text = pnl.Height.ToString();
            }
        }

        private void btndone_Click(object sender, EventArgs e)
        {
            API.CurrentSession.SetupDesktopPanel();
            Skinning.Utilities.saveskin();
            this.Close();
        }

        private void PanelManager_Load(object sender, EventArgs e)
        {
            pnlbgcolor.BackColor = pnl.BackgroundColor;
            pnlbgcolor.BackgroundImage = pnl.BackgroundImage;
            txtheight.Text = pnl.Height.ToString();
        }
    }
}
