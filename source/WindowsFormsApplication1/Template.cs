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
    public partial class Template : Form
    {
        public List<Control> NewControls = new List<Control>();
        public Form ManagedForm = null;
        public Template(string aname, Image aicon, Form frmToTake)
        {
            AppName = aname;
            AppIcon = aicon;
            foreach(Control ctrl in frmToTake.Controls)
            {
                NewControls.Add(ctrl);
                ctrl.Show();
            }
            ManagedForm = frmToTake;
            InitializeComponent();
        }

        public Image AppIcon { get; set; }
        public string AppName { get; set; }

        #region "Template Code"
        public int rolldownsize;
        public int oldbordersize;
        public int oldtitlebarheight;
        public bool justopened = false;
        public bool needtorollback = false;
        //replace with minimum size
        public int minimumsizewidth = 0;
        //replace with minimum size
        public int minimumsizeheight = 0;

        // ERROR: Handles clauses are not supported in C#
        private void Template_Load(object sender, EventArgs e)
        {
            justopened = true;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            setupall();
            foreach(Control ctrl in NewControls)
            {
                this.pgcontents.Controls.Add(ctrl);
            }
            
            //CHANGE NAME
            //modify to proper name
        }

        public void setupall()
        {
            setuptitlebar();
            setupborders();
            setskin();
        }

        // ERROR: Handles clauses are not supported in C#
        private void ShiftOSDesktop_keydown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //Make terminal appear
            if (e.KeyCode == Keys.T && e.Control)
            {
                API.CreateForm(new Terminal(), API.CurrentSave.TerminalName, Properties.Resources.iconTerminal);
            }

            //Movable Windows
            if (API.Upgrades["movablewindows"] == true)
            {
                if (e.KeyCode == Keys.A && e.Control)
                {
                    e.Handled = true;
                    this.Location = new Point(this.Location.X - 30, this.Location.Y);
                }
                if (e.KeyCode == Keys.D && e.Control)
                {
                    e.Handled = true;
                    this.Location = new Point(this.Location.X + 30, this.Location.Y);
                }
                if (e.KeyCode == Keys.W && e.Control)
                {
                    e.Handled = true;
                    this.Location = new Point(this.Location.X, this.Location.Y - 30);
                }
                if (e.KeyCode == Keys.S && e.Control)
                {
                    e.Handled = true;
                    this.Location = new Point(this.Location.X, this.Location.Y + 30);
                }
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void titlebar_MouseDown(object sender, MouseEventArgs e)
        {
            // Handle Draggable Windows
            if (API.Upgrades["draggablewindows"] == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    titlebar.Capture = false;
                    lbtitletext.Capture = false;
                    pnlicon.Capture = false;
                    pgtoplcorner.Capture = false;
                    pgtoprcorner.Capture = false;
                    const int WM_NCLBUTTONDOWN = 0xa1;
                    const int HTCAPTION = 2;
                    Message msg = Message.Create(this.Handle, WM_NCLBUTTONDOWN, new IntPtr(HTCAPTION), IntPtr.Zero);
                    this.DefWndProc(ref msg);
                }
                //ShiftOSDesktop.log = //ShiftOSDesktop.log + My.Computer.Clock.LocalTime + " User dragged " + this.Name + " to " + this.Location.ToString + Environment.NewLine;
            }
        }

        public void setupborders()
        {
            if (API.Upgrades["windowborders"] == false)
            {
                pgleft.Hide();
                pgbottom.Hide();
                pgright.Hide();
                this.Size = new Size(this.Width - pgleft.Width - pgright.Width, this.Height - pgbottom.Height);
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ERROR: Handles clauses are not supported in C#
        private void closebutton_MouseEnter(object sender, EventArgs e)
        {
            closebutton.BackgroundImage = API.CurrentSkinImages.closebtnhover;
        }

        // ERROR: Handles clauses are not supported in C#
        private void closebutton_MouseLeave(object sender, EventArgs e)
        {
            closebutton.BackgroundImage = API.CurrentSkinImages.closebtn;
        }

        // ERROR: Handles clauses are not supported in C#
        private void closebutton_MouseDown(object sender, EventArgs e)
        {
            closebutton.BackgroundImage = API.CurrentSkinImages.closebtnclick;
        }

        public Point OldLoc = new Point(0, 0);
        public bool Minimized = false;

        // ERROR: Handles clauses are not supported in C#
        private void minimizebutton_Click(object sender, EventArgs e)
        {
            OldLoc = this.Location;
            Minimized = true;
            this.Location = new Point(99999, 99999);
        }

        // ERROR: Handles clauses are not supported in C#
        private void rollupbutton_Click(object sender, EventArgs e)
        {
            rollupanddown();
        }

        // ERROR: Handles clauses are not supported in C#
        private void rollupbutton_MouseEnter(object sender, EventArgs e)
        {
            rollupbutton.BackgroundImage = API.CurrentSkinImages.rollbtnhover;
        }

        // ERROR: Handles clauses are not supported in C#
        private void rollupbutton_MouseLeave(object sender, EventArgs e)
        {
            rollupbutton.BackgroundImage = API.CurrentSkinImages.rollbtn;
        }

        // ERROR: Handles clauses are not supported in C#
        private void rollupbutton_MouseDown(object sender, EventArgs e)
        {
            rollupbutton.BackgroundImage = API.CurrentSkinImages.rollbtnclick;
        }


        public void setuptitlebar()
        {
            setupborders();

            if (this.Height == this.titlebar.Height) { pgleft.Show(); pgbottom.Show(); pgright.Show(); this.Height = rolldownsize; needtorollback = true; }
            pgleft.Width = API.CurrentSkin.borderwidth;
            pgright.Width = API.CurrentSkin.borderwidth;
            pgbottom.Height = API.CurrentSkin.borderwidth;
            titlebar.Height = API.CurrentSkin.titlebarheight;

            if (justopened == true)
            {
                this.Size = new Size(420, 510);
                //put the default size of your window here
                this.Size = new Size(this.Width, this.Height + API.CurrentSkin.titlebarheight - 30);
                this.Size = new Size(this.Width + API.CurrentSkin.borderwidth + API.CurrentSkin.borderwidth, this.Height + API.CurrentSkin.borderwidth);
                oldbordersize = API.CurrentSkin.borderwidth;
                oldtitlebarheight = API.CurrentSkin.titlebarheight;
                justopened = false;
            }
            else {
                if (this.Visible == true)
                {
                    this.Size = new Size(this.Width - (2 * oldbordersize) + (2 * API.CurrentSkin.borderwidth), (this.Height - oldtitlebarheight - oldbordersize) + API.CurrentSkin.titlebarheight + API.CurrentSkin.borderwidth);
                    oldbordersize = API.CurrentSkin.borderwidth;
                    oldtitlebarheight = API.CurrentSkin.titlebarheight;
                    rolldownsize = this.Height;
                    if (needtorollback == true) { this.Height = titlebar.Height; pgleft.Hide(); pgbottom.Hide(); pgright.Hide(); }
                }
            }

            if (API.CurrentSkin.enablecorners == true)
            {
                pgtoplcorner.Show();
                pgtoprcorner.Show();
                pgtoprcorner.Width = API.CurrentSkin.titlebarcornerwidth;
                pgtoplcorner.Width = API.CurrentSkin.titlebarcornerwidth;
            }
            else {
                pgtoplcorner.Hide();
                pgtoprcorner.Hide();
            }

            if (API.Upgrades["titlebar"] == false)
            {
                titlebar.Hide();
                this.Size = new Size(this.Width, this.Size.Height - titlebar.Height);
            }

            if (API.Upgrades["titletext"] == false)
            {
                lbtitletext.Hide();
            }
            else {
                lbtitletext.Font = new Font(API.CurrentSkin.titletextfontfamily, API.CurrentSkin.titletextfontsize, API.CurrentSkin.titletextfontstyle, GraphicsUnit.Point);
                lbtitletext.Text = this.AppName;
                //Remember to change to name of program!!!!
                lbtitletext.Show();
            }

            if (API.Upgrades["closebutton"] == false)
            {
                closebutton.Hide();
            }
            else {
                closebutton.BackColor = API.CurrentSkin.closebtncolour;
                closebutton.Size = API.CurrentSkin.closebtnsize;
                closebutton.Show();
            }

            if (API.Upgrades["rollupbutton"] == false)
            {
                rollupbutton.Hide();
            }
            else {
                rollupbutton.BackColor = API.CurrentSkin.rollbtncolour;
                rollupbutton.Size = API.CurrentSkin.rollbtnsize;
                rollupbutton.Show();
            }

            if (API.Upgrades["minimizebutton"] == false)
            {
                minimizebutton.Hide();
            }
            else {
                minimizebutton.BackColor = API.CurrentSkin.minbtncolour;
                minimizebutton.Size = API.CurrentSkin.minbtnsize;
                minimizebutton.Show();
            }

            if (API.Upgrades["windowborders"] == true)
            {
                closebutton.Location = new Point(titlebar.Size.Width - API.CurrentSkin.closebtnfromside - closebutton.Size.Width, API.CurrentSkin.closebtnfromtop);
                rollupbutton.Location = new Point(titlebar.Size.Width - API.CurrentSkin.rollbtnfromside - rollupbutton.Size.Width, API.CurrentSkin.rollbtnfromtop);
                minimizebutton.Location = new Point(titlebar.Size.Width - API.CurrentSkin.minbtnfromside - minimizebutton.Size.Width, API.CurrentSkin.minbtnfromtop);
                switch (API.CurrentSkin.titletextpos)
                {
                    case "Left":
                        lbtitletext.Location = new Point(API.CurrentSkin.titletextfromside, API.CurrentSkin.titletextfromtop);
                        break;
                    case "Centre":
                        lbtitletext.Location = new Point((titlebar.Width / 2) - lbtitletext.Width / 2, API.CurrentSkin.titletextfromtop);
                        break;
                }
                lbtitletext.ForeColor = API.CurrentSkin.titletextcolour;
            }
            else {
                closebutton.Location = new Point(titlebar.Size.Width - API.CurrentSkin.closebtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - closebutton.Size.Width, API.CurrentSkin.closebtnfromtop);
                rollupbutton.Location = new Point(titlebar.Size.Width - API.CurrentSkin.rollbtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - rollupbutton.Size.Width, API.CurrentSkin.rollbtnfromtop);
                minimizebutton.Location = new Point(titlebar.Size.Width - API.CurrentSkin.minbtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - minimizebutton.Size.Width, API.CurrentSkin.minbtnfromtop);
                switch (API.CurrentSkin.titletextpos)
                {
                    case "Left":
                        lbtitletext.Location = new Point(API.CurrentSkin.titletextfromside + pgtoplcorner.Width, API.CurrentSkin.titletextfromtop);
                        break;
                    case "Centre":
                        lbtitletext.Location = new Point((titlebar.Width / 2) - lbtitletext.Width / 2, API.CurrentSkin.titletextfromtop);
                        break;
                }
                lbtitletext.ForeColor = API.CurrentSkin.titletextcolour;
            }

            //Change when Icon skinning complete
            // Change to program's icon
            if (API.Upgrades["appicons"] == true)
            {
                pnlicon.Visible = true;
                pnlicon.Location = new Point(API.CurrentSkin.titleiconfromside, API.CurrentSkin.titleiconfromtop);
                pnlicon.Size = new Size(API.CurrentSkin.titlebariconsize, API.CurrentSkin.titlebariconsize);
                pnlicon.Image = this.AppIcon;
                //Replace with the correct icon for the program.
            }

        }

        public void rollupanddown()
        {
            if (this.Height == this.titlebar.Height)
            {
                pgleft.Show();
                pgbottom.Show();
                pgright.Show();
                this.Height = rolldownsize;
                this.MinimumSize = new Size(minimumsizewidth, minimumsizeheight);
            }
            else {
                this.MinimumSize = new Size(0, 0);
                pgleft.Hide();
                pgbottom.Hide();
                pgright.Hide();
                rolldownsize = this.Height;
                this.Height = this.titlebar.Height;
            }
        }

        public void resettitlebar()
        {
            if (API.Upgrades["windowborders"] == true)
            {
                closebutton.Location = new Point(titlebar.Size.Width - API.CurrentSkin.closebtnfromside - closebutton.Size.Width, API.CurrentSkin.closebtnfromtop);
                rollupbutton.Location = new Point(titlebar.Size.Width - API.CurrentSkin.rollbtnfromside - rollupbutton.Size.Width, API.CurrentSkin.rollbtnfromtop);
                minimizebutton.Location = new Point(titlebar.Size.Width - API.CurrentSkin.minbtnfromside - minimizebutton.Size.Width, API.CurrentSkin.minbtnfromtop);
                switch (API.CurrentSkin.titletextpos)
                {
                    case "Left":
                        lbtitletext.Location = new Point(API.CurrentSkin.titletextfromside, API.CurrentSkin.titletextfromtop);
                        break;
                    case "Centre":
                        lbtitletext.Location = new Point((titlebar.Width / 2) - lbtitletext.Width / 2, API.CurrentSkin.titletextfromtop);
                        break;
                }
                lbtitletext.ForeColor = API.CurrentSkin.titletextcolour;
            }
            else {
                closebutton.Location = new Point(titlebar.Size.Width - API.CurrentSkin.closebtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - closebutton.Size.Width, API.CurrentSkin.closebtnfromtop);
                rollupbutton.Location = new Point(titlebar.Size.Width - API.CurrentSkin.rollbtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - rollupbutton.Size.Width, API.CurrentSkin.rollbtnfromtop);
                minimizebutton.Location = new Point(titlebar.Size.Width - API.CurrentSkin.minbtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - minimizebutton.Size.Width, API.CurrentSkin.minbtnfromtop);
                switch (API.CurrentSkin.titletextpos)
                {
                    case "Left":
                        lbtitletext.Location = new Point(API.CurrentSkin.titletextfromside + pgtoplcorner.Width, API.CurrentSkin.titletextfromtop);
                        break;
                    case "Centre":
                        lbtitletext.Location = new Point((titlebar.Width / 2) - lbtitletext.Width / 2, API.CurrentSkin.titletextfromtop);
                        break;
                }
                lbtitletext.ForeColor = API.CurrentSkin.titletextcolour;
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void pullside_Tick(System.Object sender, System.EventArgs e)
        {
            this.Width = Cursor.Position.X - this.Location.X;
            resettitlebar();
        }

        // ERROR: Handles clauses are not supported in C#
        private void pullbottom_Tick(System.Object sender, System.EventArgs e)
        {
            this.Height = Cursor.Position.Y - this.Location.Y;
            resettitlebar();
        }

        // ERROR: Handles clauses are not supported in C#
        private void pullbs_Tick(object sender, System.EventArgs e)
        {
            this.Width = Cursor.Position.X - this.Location.X;
            this.Height = Cursor.Position.Y - this.Location.Y;
            resettitlebar();
        }

        //delete this for non-resizable windows
        // ERROR: Handles clauses are not supported in C#
        private void Rightpull_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                pullside.Start();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void RightCursorOn_MouseDown(object sender, System.EventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                Cursor = Cursors.SizeWE;
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void bottomCursorOn_MouseDown(object sender, System.EventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                Cursor = Cursors.SizeNS;
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void CornerCursorOn_MouseDown(object sender, System.EventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                Cursor = Cursors.SizeNWSE;
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void SizeCursoroff_MouseDown(object sender, System.EventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                Cursor = Cursors.Default;
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void rightpull_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                pullside.Stop();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void bottompull_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                pullbottom.Start();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void buttompull_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                pullbottom.Stop();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void bspull_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                pullbs.Start();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void bspull_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                pullbs.Stop();
            }
        }

        public void setskin()
        {
            //disposals
            closebutton.BackgroundImage = null;
            titlebar.BackgroundImage = null;
            rollupbutton.BackgroundImage = null;
            pgtoplcorner.BackgroundImage = null;
            pgtoprcorner.BackgroundImage = null;
            minimizebutton.BackgroundImage = null;
            //apply new skin
            if (API.CurrentSkinImages.closebtn == null)
                closebutton.BackColor = API.CurrentSkin.closebtncolour;
            else
                closebutton.BackgroundImage = API.CurrentSkinImages.closebtn;
            closebutton.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.closebtnlayout;
            if (API.CurrentSkinImages.titlebar == null)
                titlebar.BackColor = API.CurrentSkin.titlebarcolour;
            else
                titlebar.BackgroundImage = API.CurrentSkinImages.titlebar;
            titlebar.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.titlebarlayout;
            if (API.CurrentSkinImages.rollbtn == null)
                rollupbutton.BackColor = API.CurrentSkin.rollbtncolour;
            else
                rollupbutton.BackgroundImage = API.CurrentSkinImages.rollbtn;
            rollupbutton.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.rollbtnlayout;
            if (API.CurrentSkinImages.leftcorner == null)
                pgtoplcorner.BackColor = API.CurrentSkin.leftcornercolour;
            else
                pgtoplcorner.BackgroundImage = API.CurrentSkinImages.leftcorner;
            pgtoplcorner.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.leftcornerlayout;
            if (API.CurrentSkinImages.rightcorner == null)
                pgtoprcorner.BackColor = API.CurrentSkin.rightcornercolour;
            else
                pgtoprcorner.BackgroundImage = API.CurrentSkinImages.rightcorner;
            pgtoprcorner.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.rightcornerlayout;
            if (API.CurrentSkinImages.minbtn == null)
                minimizebutton.BackColor = API.CurrentSkin.minbtncolour;
            else
                minimizebutton.BackgroundImage = API.CurrentSkinImages.minbtn;
            minimizebutton.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.minbtnlayout;
            if (API.CurrentSkinImages.borderleft == null)
                pgleft.BackColor = API.CurrentSkin.borderleftcolour;
            else
                pgleft.BackgroundImage = API.CurrentSkinImages.borderleft;
            pgleft.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.borderleftlayout;
            if (API.CurrentSkinImages.borderright == null)
                pgright.BackColor = API.CurrentSkin.borderrightcolour;
            else
                pgright.BackgroundImage = API.CurrentSkinImages.borderright;
            pgleft.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.borderrightlayout;
            if (API.CurrentSkinImages.borderbottom == null)
                pgbottom.BackColor = API.CurrentSkin.borderbottomcolour;
            else
                pgbottom.BackgroundImage = API.CurrentSkinImages.borderbottom;
            pgbottom.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.borderbottomlayout;
            if (API.CurrentSkin.enablebordercorners == true)
            {
                if (API.CurrentSkinImages.bottomleftcorner == null)
                    pgbottomlcorner.BackColor = API.CurrentSkin.bottomleftcornercolour;
                else
                    pgbottomlcorner.BackgroundImage = API.CurrentSkinImages.bottomleftcorner;
                pgbottomlcorner.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.bottomleftcornerlayout;
                if (API.CurrentSkinImages.bottomrightcorner == null)
                    pgbottomrcorner.BackColor = API.CurrentSkin.bottomrightcornercolour;
                else
                    pgbottomrcorner.BackgroundImage = API.CurrentSkinImages.bottomrightcorner;
                pgbottomrcorner.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.bottomrightcornerlayout;
            }
            else {
                pgbottomlcorner.BackColor = API.CurrentSkin.borderrightcolour;
                pgbottomrcorner.BackColor = API.CurrentSkin.borderrightcolour;
                pgbottomlcorner.BackgroundImage = null;
                pgbottomrcorner.BackgroundImage = null;
            }

            //set bottom border corner size
            pgbottomlcorner.Size = new Size(API.CurrentSkin.borderwidth, API.CurrentSkin.borderwidth);
            pgbottomrcorner.Size = new Size(API.CurrentSkin.borderwidth, API.CurrentSkin.borderwidth);
            pgbottomlcorner.Location = new Point(0, this.Height - API.CurrentSkin.borderwidth);
            pgbottomrcorner.Location = new Point(this.Width, this.Height - API.CurrentSkin.borderwidth);

            this.TransparencyKey = Skinning.Utilities.globaltransparencycolour;
        }

        // ERROR: Handles clauses are not supported in C#
        private void Clock_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    }
    #endregion
}
