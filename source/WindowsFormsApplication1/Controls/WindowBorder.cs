using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;

namespace ShiftOS
{
    public partial class WindowBorder : UserWidget
    {
        public Timer updater = new Timer();

        private List<BorderWidget> _widgets = new List<BorderWidget>();

        //Lua Methods

        public void RegisterWidget(string ident, Widget ctrl)
        {
            _widgets.Add(new BorderWidget { Identifier = ident, Widget = ctrl });
            resettitlebar();
        }

        public Widget GetWidget(string ident)
        {
            Widget ctrl = null;
            foreach(var widget in _widgets)
            {
                if(widget.Identifier == ident)
                {
                    ctrl = widget.Widget;
                }
            }
            if (ctrl == null)
                throw new Exception($"The identifier {ident} was not found.");
            return ctrl;
        }

        public void RemoveWidget(string ident)
        {
            BorderWidget ctrl = null;
            foreach (var widget in _widgets)
            {
                if (widget.Identifier == ident)
                {
                    ctrl = widget;
                }
            }
            if (ctrl == null)
                throw new Exception($"The identifier {ident} was not found.");
            var wWidget = ctrl.Widget;
            wWidget.Parent.Widgets.Remove(wWidget);
            wWidget.Hide();
            _widgets.Remove(ctrl);
            wWidget.Dispose();
        }


        public Panel GetTitlebar()
        {
            return titlebar;
        }

        public Panel GetBorder(string side)
        {
            switch(side)
            {
                case "left":
                    return pgleft;
                case "right":
                    return pgright;
                case "bottom":
                    return pgbottom;
                default:
                    return null;
            }
        }

        public Panel GetCloseButton() { return closebutton; }
        public Panel GetRollupButton() { return this.rollupbutton; }
        public Panel GetMinimizeButton() { return minimizebutton; }

        private bool _closeEnabled = true;
        private bool _minimizeEnabled = true;
        private bool _rollupEnabled = true;

        public bool CloseEnabled { get { return _closeEnabled; } set { _closeEnabled = value;  resettitlebar(); } }
        public bool MinimizeEnabled { get { return _minimizeEnabled; } set { _minimizeEnabled = value; resettitlebar(); } }
        public bool RollupEnabled { get { return _rollupEnabled; } set { _rollupEnabled = value; resettitlebar(); } }


        public Panel GetCorner(string position, string side)
        {
            switch(position)
            {
                case "top":
                    switch(side)
                    {
                        case "left":
                            return pgtoplcorner;
                        case "right":
                            return pgtoprcorner;
                        default:
                            return null;
                    }
                case "bottom":
                    switch(side)
                    {
                        case "left":
                            return pgbottomlcorner;
                        case "right":
                            return pgbottomlcorner;
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }

        public WindowBorder(string aname, Image aicon)
        {
            AppName = aname;
            AppIcon = aicon;
            InitializeComponent();
        }

        public Image AppIcon = null;
        public string AppName = null;

        public void HideAll()
        {
            titlebar.Hide();
            pgleft.Hide();
            pgright.Hide();
            pgbottom.Hide();
        }

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
            setupall();
            if (ParentForm.Name == "Terminal" && API.Upgrades["windowedterminal"] == false)
            {
                HideAll();
            }
            string x = ParentForm.Width.ToString();
            string y = ParentForm.Height.ToString();
            ParentForm.MinimumSize = new Size(Convert.ToInt16(x), Convert.ToInt16(y));
            string mx = ParentForm.MinimumSize.Width.ToString();
            string my = ParentForm.MinimumSize.Height.ToString();
            Form frm = ParentForm;
            pbtn = new PanelButton(AppName, AppIcon, ref frm);
            API.PanelButtons.Add(pbtn);
            if (API.CurrentSession != null)
            {
                API.CurrentSession.SetupPanelButtons();
            }
            ParentForm.FormClosing += new FormClosingEventHandler(this.Clock_FormClosing);
            var vtimer = new Timer();
            vtimer.Interval = 1000;
            vtimer.Tick += (object s, EventArgs a) =>
            {
                try {
                    if (API.Upgrades["titlebar"] == true)
                    {
                        titlebar.Show();
                    }
                    else {
                        titlebar.Hide();
                    }
                    
                }
                catch(Exception ex)
                {
                    API.LogException(ex.Message, false);
                }
                if (Viruses.InfectedWith("windowmicrofier"))
                {
                    if (this.Width > 0)
                    {
                        this.ParentForm.MinimumSize = new Size(0, 0);
                        this.ParentForm.Width -= 1;
                    }
                    if (this.Height > 0)
                    {
                        this.ParentForm.Height -= 1;
                    }
                }
                try {
                    if (this.ParentForm.TopMost == API.CurrentSession.UnityEnabled)
                    {
                        this.ParentForm.TopMost = !this.ParentForm.TopMost;
                    }
                }
                catch
                {
                    //FAIL.
                }
            };
            vtimer.Start();
            //try {
                ParentForm.Name = AppName.ToLower().Replace(" ", "_");
            /*}
            catch(Exception ex)
            {
                ParentForm.Name = "null";
            }*/
            ParentForm.Tag = ParentForm.Location;
            WindowComposition.WindowsEverywhere(this.ParentForm);
            ParentForm.Text = this.AppName;
        }

        private PanelButton pbtn = null;

        public void setupall()
        {
            setuptitlebar();
            setupborders();
            setskin();
            
        }



        private void titlebar_MouseDown(object sender, MouseEventArgs e)
        {
            // Handle Draggable Windows
            if (API.Upgrades["draggablewindows"] == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    WindowComposition.AnimateDragWindow(this.ParentForm, API.CurrentSkin.DragAnimation, true);
                    LastMouseX = e.X;
                    LastMouseY = e.Y;
                    Resizing = true;
                }
                //ShiftOSDesktop.log = //ShiftOSDesktop.log + My.Computer.Clock.LocalTime + " User dragged " + this.Name + " to " + this.Location.ToString + Environment.NewLine;
            }
        }

        private bool Resizing = false;
        private int LastMouseX = 0;
        private int LastMouseY = 0;

        private void titlebar_MouseMove(object sender, MouseEventArgs e)
        {
            if(Resizing == true)
            {
                    int left = 0;
                    int top = 0;
                    if (e.X < LastMouseX)
                    {
                        left = -1;
                    }
                    else if (e.X > LastMouseX)
                    {
                        left = 1;
                    }
                    if (e.Y < LastMouseY)
                    {
                        top = -1;
                    }
                    else if (e.Y > LastMouseY)
                    {
                        top = 1;
                    }
                if (API.CurrentSkin.DragAnimation == WindowDragEffect.Shake)
                {
                    WindowComposition.AnimateDragWindow(this.ParentForm, API.CurrentSkin.DragAnimation, true, left, top);
                }
                else {

                    ParentForm.Left += left;
                    ParentForm.Top += top;
                    ParentForm.Tag = ParentForm.Location;
                }
            }
            if(Viruses.InfectedWith("windowspazzer"))
            {
                int left = 0;
                int top = 0;
                if (e.X < LastMouseX)
                {
                    left = -1;
                }
                else if (e.X > LastMouseX)
                {
                    left = 1;
                }
                if (e.Y < LastMouseY)
                {
                    top = -1;
                }
                else if (e.Y > LastMouseY)
                {
                    top = 1;
                }
                WindowComposition.AnimateDragWindow(this.ParentForm, API.CurrentSkin.DragAnimation, true, left, top);

            }
        }

        private void titlebar_MouseUp(object s, MouseEventArgs e)
        {
            WindowComposition.AnimateDragWindow(this.ParentForm, API.CurrentSkin.DragAnimation, false);

            Resizing = false;
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
            API.CurrentSession.InvokeWindowOp("brdr_redraw", this.ParentForm);
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void closebutton_MouseEnter(object sender, EventArgs e)
        {
            closebutton.BackgroundImage = API.CurrentSkinImages.closebtnhover;
        }

        private void closebutton_MouseLeave(object sender, EventArgs e)
        {
            closebutton.BackgroundImage = API.CurrentSkinImages.closebtn;
        }

        private void closebutton_MouseDown(object sender, EventArgs e)
        {
            closebutton.BackgroundImage = API.CurrentSkinImages.closebtnclick;
        }

        public Point OldLoc = new Point(0, 0);
        public bool Minimized = false;

        private void minimizebutton_Click(object sender, EventArgs e)
        {
            API.MinimizeForm(ParentForm);
        }

        private void rollupbutton_Click(object sender, EventArgs e)
        {
            rollupanddown();
        }

        private void rollupbutton_MouseEnter(object sender, EventArgs e)
        {
            rollupbutton.BackgroundImage = API.CurrentSkinImages.rollbtnhover;
        }

        private void rollupbutton_MouseLeave(object sender, EventArgs e)
        {
            rollupbutton.BackgroundImage = API.CurrentSkinImages.rollbtn;
        }

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

            if (_closeEnabled == false)
                closebutton.Hide();
            if (_rollupEnabled == false)
                rollupbutton.Hide();
            if (_minimizeEnabled == false)
                minimizebutton.Hide();


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
            API.CurrentSession.InvokeWindowOp("tbar_redraw", this.ParentForm);
        }

        public void rollupanddown()
        {
            API.RollForm(this.ParentForm);
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
            if (_closeEnabled == false)
                closebutton.Hide();
            if (_rollupEnabled == false)
                rollupbutton.Hide();
            if (_minimizeEnabled == false)
                minimizebutton.Hide();
            API.CurrentSession.InvokeWindowOp("tbar_redraw", this.ParentForm);
        }

        // ERROR: Handles clauses are not supported in C#
        private void pullside_Tick(System.Object sender, System.EventArgs e)
        {
            this.ParentForm.Width = Cursor.Position.X - this.ParentForm.Location.X;
            resettitlebar();
        }

        // ERROR: Handles clauses are not supported in C#
        private void pullbottom_Tick(System.Object sender, System.EventArgs e)
        {
            this.ParentForm.Height = Cursor.Position.Y - this.ParentForm.Location.Y;
            resettitlebar();
        }

        // ERROR: Handles clauses are not supported in C#
        private void pullbs_Tick(object sender, System.EventArgs e)
        {
            this.ParentForm.Width = Cursor.Position.X - this.ParentForm.Location.X;
            this.ParentForm.Height = Cursor.Position.Y - this.ParentForm.Location.Y;
            resettitlebar();
        }

        //delete this for non-resizable windows
        // ERROR: Handles clauses are not supported in C#
        private void Rightpull_MouseDown(object sender, ShiftUI.MouseEventArgs e)
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
        private void rightpull_MouseUp(object sender, ShiftUI.MouseEventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                pullside.Stop();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void bottompull_MouseDown(object sender, ShiftUI.MouseEventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                pullbottom.Start();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void bottompull_MouseUp(object sender, ShiftUI.MouseEventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                pullbottom.Stop();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void bspull_MouseDown(object sender, ShiftUI.MouseEventArgs e)
        {
            if (API.Upgrades["resizablewindows"] == true)
            {
                pullbs.Start();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void bspull_MouseUp(object sender, ShiftUI.MouseEventArgs e)
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

            //I don't know if this already happens...
            pgright.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.borderrightlayout;
            pgbottomrcorner.BackgroundImage = API.CurrentSkinImages.bottomrightcorner;
            pgbottomlcorner.BackgroundImage = API.CurrentSkinImages.bottomleftcorner;
            pgbottomrcorner.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.bottomrightcornerlayout;
            pgbottomlcorner.BackgroundImageLayout = (ImageLayout)API.CurrentSkin.bottomleftcornerlayout;

            API.CurrentSession.InvokeWindowOp("redraw", this.ParentForm);
        }

        // ERROR: Handles clauses are not supported in C#
        private void Clock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowComposition.ShuttingDown == false)
            {
                e.Cancel = true;
                WindowComposition.CloseForm(this.ParentForm, pbtn, API.CurrentSkin.WindowCloseAnimation);
            }
            API.CurrentSession.InvokeWindowOp("close", this.ParentForm);
            API.OpenGUIDs.Remove(this.ParentForm);
        }
    }
    #endregion

    public class BorderWidget
    {
        public string Identifier { get; set; }
        public Widget Widget { get; set; }
    }
}

