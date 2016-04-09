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
    public partial class AlternateDesktop : Form
    {
        public AlternateDesktop()
        {
            InitializeComponent();
        }

        private void ClockTick_Tick(object sender, EventArgs e)
        {
            lbclock.Text = API.GetTime();
            
        }

        public void GetApps()
        {
            pnlsidebar.Controls.Clear();
            API.GetAppLauncherItems();
            Panel appbtn = new Panel();
            appbtn.BackColor = Color.Black;
            appbtn.Size = new Size(32, 32);
            appbtn.Visible = true;
            appbtn.Name = "ashow";
            appbtn.Click += new EventHandler(this.SidebarButton_Click);

            pnlsidebar.Controls.Add(appbtn);
            foreach(ApplauncherItem itm in API.AppLauncherItems)
            {
                if(itm.Display == true)
                {
                    Panel btn = new Panel();
                    btn.BackColor = Color.Gray;
                    btn.BackgroundImage = itm.Icon;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.Size = new Size(32, 32);
                    btn.Name = $"al_{new Random().Next(1000, 9999)}";
                    btn.Tag = itm;
                    btn.MouseMove += new MouseEventHandler(this.SidebarButton_Hover);
                    btn.MouseLeave += new EventHandler(this.SidebarButton_Leave);
                    btn.Click += new EventHandler(this.SidebarButton_Click);
                    pnlsidebar.Controls.Add(btn);
                    btn.Show();
                }
            }
            foreach(PanelButton pbtn in API.PanelButtons)
            {
                Panel btn = new Panel();
                btn.Tag = pbtn;
                btn.Name = $"pnl_{new Random().Next(1000, 9999)}";
                btn.BackgroundImage = pbtn.Icon;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.BackColor = Color.Black;
                btn.Size = new Size(32, 32);
                btn.MouseMove += new MouseEventHandler(this.SidebarButton_Hover);
                btn.MouseLeave += new EventHandler(this.SidebarButton_Leave);
                btn.Click += new EventHandler(this.SidebarButton_Click);
                pnlsidebar.Controls.Add(btn);
                btn.Show();
            }
        }

        public void SidebarButton_Hover(object sender, MouseEventArgs e)
        {
            Panel s = (Panel)sender;
            int labelLoc = pnlcontext.Height + (s.Bottom - (s.Height / 2));
            lblapplabel.Location = new Point(pnlsidebar.Width + 5, labelLoc);
            if(s.Name.Contains("al"))
            {
                var itm = (ApplauncherItem)s.Tag;
                lblapplabel.Text = itm.Name;
            }
            else
            {
                var itm = (PanelButton)s.Tag;
                lblapplabel.Text = itm.Name;
            }
            lblapplabel.Visible = true;
        }

        public void SidebarButton_Click(object sender, EventArgs e)
        {
            var s = (Panel)sender;
            if (s.Name.Contains("al"))
            {
                var itm = (ApplauncherItem)s.Tag;
                var li = new LuaInterpreter();
                li.mod(itm.Lua);
                li = null;
            }
            else if(s.Name.Contains("ashow"))
            {
                pnlapplauncher.Show();
                foreach(Control ctrl in this.Controls)
                {
                    ctrl.MouseDown += (object se, MouseEventArgs a) =>
                    {
                        pnlapplauncher.Hide();
                    };
                }
            }
            else
            {
                try
                {
                    PanelButton pbtn = (PanelButton)s.Tag;
                    API.ToggleMinimized(pbtn.FormToManage);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void SidebarButton_Leave(object sender, EventArgs e)
        {
            lblapplabel.Hide();
        }

        private void AlternateDesktop_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            GetApps();
        }

        private void apptick_Tick(object sender, EventArgs e)
        {
            //GetApps();
        }

        private bool unity = false;

        public void ToggleUnityMode()
        {
            if (unity == false)
            {
                unity = true;
                this.BackColor = Skinning.Utilities.globaltransparencycolour;
                this.BackgroundImage = null;
                this.TransparencyKey = Skinning.Utilities.globaltransparencycolour;
            }
            else
            {
                unity = false;
                this.BackColor = API.CurrentSkin.desktopbackgroundcolour;
                this.BackgroundImage = API.CurrentSkinImages.desktopbackground;
                this.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.desktopbackgroundlayout;
                this.TransparencyKey = Skinning.Utilities.globaltransparencycolour;
            }
        }
    }
}
