using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;
using System.IO;

namespace ShiftOS
{
    public partial class DesktopIcon : UserWidget
    {
        /// <summary>
        /// User control for a desktop icon.
        /// </summary>
        public DesktopIcon()
        {
            InitializeComponent();
        }

        public string IconName
        {
            set
            {
                lbiconname.Text = value;
            }
            get
            {
                return lbiconname.Text;
            }
        }

        public Image Icon
        {
            set
            {
                pbicon.Image = value;
            }
            get
            {
                return pbicon.Image;
            }
        }

        //public string LuaAction { get; set; }
        public string LuaAction = "open_program(\"shiftorium\")";
        private void Icon_Click(object sender, EventArgs e)
        {
            if (File.Exists(Paths.Desktop + IconName))
            {
                var fs = new File_Skimmer();
                fs.OpenFile(Paths.Desktop + IconName);
            }
            else
            {
                var li = new LuaInterpreter();
                li.mod(LuaAction);
                lbiconname.BackColor = Color.White;
                t.Start();
            }
        }

        public Timer t = new Timer();


        private void DesktopIcon_Load(object sender, EventArgs e)
        {
            t.Interval = 5000;
            t.Tick += (object s, EventArgs a) =>
            {
                lbiconname.BackColor = Color.Transparent;
            };
            var st = new Timer();
            st.Interval = 200;
            st.Tick += (object s, EventArgs a) => {
                lbiconname.ForeColor = API.CurrentSkin.IconTextColor;
            };
        }
    }
}
