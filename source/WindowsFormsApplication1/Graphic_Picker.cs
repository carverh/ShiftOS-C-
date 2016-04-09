using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{

    public partial class Graphic_Picker : Form
    {
        /// <summary>
        /// Graphic Picker GUI.
        /// </summary>
        /// <param name="elementName">Name of element.</param>
        /// <param name="showMouseImages">Should mouse images be shown?</param>
        public Graphic_Picker(string elementName, bool showMouseImages)
        {
            InitializeComponent();
            ElementName = elementName;
            ShowMouseImages = showMouseImages;
        }

        private string ElementName = "Close Button";
        public ImageLayout ImageLayout = ImageLayout.Stretch;
        public Image IdleImage = null;
        public Image MouseOverImage = null;
        public Image MouseDownImage = null;
        private bool ShowMouseImages = false;

        /// <summary>
        /// Sets up the user interface.
        /// </summary>
        private void SetupGUI()
        {
            lblobjecttoskin.Text = ElementName;
            btnstretch.BackgroundImage = Properties.Resources.stretchbutton;
            btntile.BackgroundImage = Properties.Resources.tilebutton;
            btncentre.BackgroundImage = Properties.Resources.centrebutton;
            btnzoom.BackgroundImage = Properties.Resources.zoombutton;
            switch(this.ImageLayout)
            {
                case ImageLayout.Stretch:
                    btnstretch.BackgroundImage = Properties.Resources.stretchbuttonpressed;
                    break;
                case ImageLayout.Tile:
                    btntile.BackgroundImage = Properties.Resources.tilebuttonpressed;
                    break;
                case ImageLayout.Center:
                    btncentre.BackgroundImage = Properties.Resources.centrebuttonpressed;
                    break;
                default:
                    btnzoom.BackgroundImage = Properties.Resources.zoombuttonpressed;
                    break;
            }
            if(ShowMouseImages == true)
            {
                txtmousedownfile.Show();
                txtmouseoverfile.Show();
                Label3.Show();
                Label4.Show();
                picmousedown.Show();
                picmouseover.Show();
                btnmousedownbrowse.Show();
                btnmouseoverbrowse.Show();
                this.Height = MOUSE_IMAGES_WINDOW_HEIGHT;
            }
            else
            {
                txtmousedownfile.Hide();
                txtmouseoverfile.Hide();
                Label3.Hide();
                Label4.Hide();
                picmousedown.Hide();
                picmouseover.Hide();
                btnmousedownbrowse.Hide();
                btnmouseoverbrowse.Hide();
                this.Height = IDLE_ONLY_WINDOW_HEIGHT;

            }
            picidle.BackgroundImage = IdleImage;
            picidle.BackgroundImageLayout = this.ImageLayout;
            picmousedown.BackgroundImage = MouseDownImage;
            picidle.BackgroundImageLayout = this.ImageLayout;
            picmouseover.BackgroundImage = MouseOverImage;
            picidle.BackgroundImageLayout = this.ImageLayout;
            txtidlefile.Text = idle_filename;
            txtmousedownfile.Text = mousedown_filename;
            txtmouseoverfile.Text = mouseover_filename;
        }

        private const int MOUSE_IMAGES_WINDOW_HEIGHT = 570;
        private const int IDLE_ONLY_WINDOW_HEIGHT = 382;
        private void btntile_Click(object sender, EventArgs e)
        {
            this.ImageLayout = ImageLayout.Tile;
            SetupGUI();
        }

        private void btncentre_Click(object sender, EventArgs e)
        {
            this.ImageLayout = ImageLayout.Center;
            SetupGUI();
        }

        private void btnstretch_Click(object sender, EventArgs e)
        {
            this.ImageLayout = ImageLayout.Stretch;
            SetupGUI();
        }

        private string idle_filename = "None";
        private string mouseover_filename = "None";
        private string mousedown_filename = "None";


        private void btnzoom_Click(object sender, EventArgs e)
        {
            this.ImageLayout = ImageLayout.Zoom;
            SetupGUI();
        }

        private void btnmouseoverbrowse_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".pic;.svg;.png;.bmp;.jpg", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                string result = API.GetFSResult();
                if(result != "fail")
                {
                    var finf = new FileInfo(result);
                    if (finf.Extension == ".svg")
                    {
                        MouseOverImage = SVGtoPNG(finf.FullName);
                    }
                    else {
                        MouseOverImage = Image.FromFile(result);
                    }

                    mouseover_filename = finf.Name;
                    MOFullName = finf.FullName;
                }
                SetupGUI();
            };
        }

        /// <summary>
        /// Scalable Vector Graphics parser.
        /// </summary>
        /// <param name="svg">Path to .svg file.</param>
        /// <returns>The new System.Drawing.Image.</returns>
        private Image SVGtoPNG(string svg)
        {


            var svgDocument = SvgDocument.Open(svg);
            return svgDocument.Draw();
            
        }

        private void btnidlebrowse_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".pic;.svg;.png;.bmp;.jpg", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                string result = API.GetFSResult();
                if (result != "fail")
                {
                    var finf = new FileInfo(result);
                    if (finf.Extension == ".svg")
                    {
                        IdleImage = SVGtoPNG(finf.FullName);
                    }
                    else {
                        IdleImage = Image.FromFile(result);
                    }
                    idle_filename = finf.Name;
                    IdleFullName = finf.FullName;
                }
                SetupGUI();
            };
        }

        private void btnmousedownbrowse_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".pic;.svg;.png;.bmp;.jpg", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                string result = API.GetFSResult();
                if (result != "fail")
                {
                    var finf = new FileInfo(result);
                    if (finf.Extension == ".svg")
                    {
                        MouseDownImage = SVGtoPNG(finf.FullName);
                    }
                    else {
                        MouseDownImage = Image.FromFile(result);
                    }

                    mousedown_filename = finf.Name;
                    MDFullName = finf.FullName;
                }
                SetupGUI();
            };
        }

        public string Result = "Cancelled";

        private void Graphic_Picker_Load(object sender, EventArgs e)
        {

            SetupGUI();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            IdleImage = null;
            MouseOverImage = null;
            MouseDownImage = null;
            idle_filename = "None";
            mouseover_filename = "None";
            mousedown_filename = "None";
            SetupGUI();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Result = "Cancelled";
            this.Close();
        }

        public string IdleFullName = null;
        public string MOFullName = null;
        public string MDFullName = null;

        private void btnapply_Click(object sender, EventArgs e)
        {
            Result = "OK";
            this.Close();
        }
    }
}
