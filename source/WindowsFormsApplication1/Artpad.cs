using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ShiftOS
{
    public partial class Artpad : Form
    {
        /// <summary>
        /// Artpad's GUI.
        /// </summary>
        public Artpad()
        {
            InitializeComponent();
        }

        #region Variables

        public int rolldownsize;
        public int oldbordersize;
        public int oldtitlebarheight;
        public bool justopened = false;
        public bool needtorollback = false;
        public int minimumsizewidth = 502;

        public int minimumsizeheight = 398;
        public int codepointsearned;
        public bool codepointscooldown = false;

        public bool needtosave = false;
        int canvaswidth = 150;
        int canvasheight = 100;
        public Bitmap canvasbitmap;

        Color canvascolor = Color.White;

        Bitmap previewcanvasbitmap;
        int magnificationlevel = 1;
        Rectangle magnifyRect;
        Graphics graphicsbitmap;
        public Color drawingcolour = Color.Black;
        string selectedtool = "Pixel Setter";
        bool pixalplacermovable = false;
        public string savelocation;
        System.Drawing.Drawing2D.GraphicsPath mousePath = new System.Drawing.Drawing2D.GraphicsPath();
        int pencilwidth = 1;
        undo undo = new undo();
        Point thisPoint;
        int eracerwidth = 15;

        string eracertype = "square";
        int paintbrushwidth = 15;

        string paintbrushtype = "circle";
        float rectanglestartpointx;
        float rectanglestartpointy;
        bool currentlydrawingsquare;
        int squarewidth = 1;
        bool squarefillon = false;

        Color fillsquarecolor = Color.Black;
        float ovalstartpointx;
        float ovalstartpointy;
        bool currentlydrawingoval;
        int ovalwidth = 2;
        bool ovalfillon = false;

        Color fillovalcolor = Color.Black;
        float linestartpointx;
        float linestartpointy;
        bool currentlydrawingline;

        int linewidth = 2;
        bool currentlydrawingtext;
        System.Drawing.Font drawtextfont = new System.Drawing.Font("Microsoft Sans Serif", 16);
        int drawtextsize;
        string drawtextfontname;

        FontStyle drawtextfontstyle;

        #endregion

        #region Setup

        private void Template_Load(object sender, EventArgs e)
        {
            justopened = true;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;

            setuppreview();
            settoolcolours();
            loadcolors();
            AddFonts();
            setuptoolbox();
            determinevisiblepallets();
            tmrsetupui.Start();
        }

        

        public void setupcanvas()
        {
            canvasbitmap = new Bitmap(canvaswidth, canvasheight);
            previewcanvasbitmap = new Bitmap(canvaswidth, canvasheight);
            picdrawingdisplay.Size = new Size(canvaswidth, canvasheight);
            picdrawingdisplay.Location = new Point((pnldrawingbackground.Width - canvaswidth) / 2, (pnldrawingbackground.Height - canvasheight) / 2);
            graphicsbitmap = Graphics.FromImage(canvasbitmap);
            SolidBrush canvasbrush = new SolidBrush(canvascolor);
            graphicsbitmap.FillRectangle(canvasbrush, 0, 0, canvaswidth, canvasheight);
            magnificationlevel = 1;
            lblzoomlevel.Text = magnificationlevel + "X";
            setuppreview();
            needtosave = false;
        }

        public void setuptoolbox()
        {
            btnpixelplacer.Hide();
            btnpencil.Hide();
            btnfloodfill.Hide();
            btnoval.Hide();
            btnsquare.Hide();
            btnlinetool.Hide();
            btnpaintbrush.Hide();
            btntexttool.Hide();
            btneracer.Hide();
            btnnew.Hide();
            btnopen.Hide();
            btnsave.Hide();
            btnundo.Hide();
            btnredo.Hide();
            btnpixelplacermovementmode.Hide();

            if (API.Upgrades["artpadpixelplacer"] == true)
                btnpixelplacer.Show();
            if (API.Upgrades["artpadpencil"] == true)
                btnpencil.Show();
            if (API.Upgrades["artpadfilltool"] == true)
                btnfloodfill.Show();
            if (API.Upgrades["artpadovaltool"] == true)
                btnoval.Show();
            if (API.Upgrades["artpadrectangletool"] == true)
                btnsquare.Show();
            if (API.Upgrades["artpadlinetool"] == true)
                btnlinetool.Show();
            if (API.Upgrades["artpadpaintbrush"] == true)
                btnpaintbrush.Show();
            if (API.Upgrades["artpadtexttool"] == true)
                btntexttool.Show();
            if (API.Upgrades["artpaderaser"] == true)
                btneracer.Show();
            if (API.Upgrades["artpadnew"] == true)
                btnnew.Show();
            if (API.Upgrades["artpadload"] == true)
                btnopen.Show();
            if (API.Upgrades["artpadsave"] == true)
                btnsave.Show();
            if (API.Upgrades["artpadundo"] == true)
                btnundo.Show();
            if (API.Upgrades["artpadredo"] == true)
                btnredo.Show();
            if (API.Upgrades["artpadppmovementmode"] == true)
                btnpixelplacermovementmode.Show();

        }

        private void AddFonts()
        {
            // Get the installed fonts collection.
            InstalledFontCollection allFonts = new InstalledFontCollection();

            // Get an array of the system's font familiies.
            FontFamily[] fontFamilies = allFonts.Families;

            // Display the font families.
            foreach (FontFamily myFont in fontFamilies)
            {
                combodrawtextfont.Items.Add(myFont.Name);
            }
            //font_family

            combodrawtextfont.SelectedItem = combodrawtextfont.Items[1];
            combofontstyle.Text = "Regular";
            txtdrawtextsize.Text = "16";
        }

        #endregion

        #region General

        // ERROR: Handles clauses are not supported in C#
        private void btnpixelsetter_Click(object sender, EventArgs e)
        {
            selectedtool = "Pixel Setter";
            gettoolsettings(pnlpixelsettersettings);
        }

        private void gettoolsettings(Panel toolpanel)
        {
            //hide all properties panels
            pnlpixelsettersettings.Hide();
            pnlmagnifiersettings.Hide();

            //show chosen panel
            toolpanel.Dock = DockStyle.Fill;
            toolpanel.BringToFront();
            toolpanel.Show();

            setuppreview();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnpixelsettersetpixel_Click(object sender, EventArgs e)
        {
            try
            {
                undo.undoStack.Push((Image)canvasbitmap.Clone());
                undo.redoStack.Clear();
                canvasbitmap.SetPixel(Convert.ToInt32(txtpixelsetterxcoordinate.Text), Convert.ToInt32(txtpixelsetterycoordinate.Text), drawingcolour);
                picdrawingdisplay.Invalidate();
            }
            catch 
            {
                API.CreateInfoboxSession("ArtPad - Placement Error!", "You have specified invalid coordinates for the pixel setter." + Environment.NewLine + Environment.NewLine + "Remember that the top left pixel has the coordinates 0, 0", infobox.InfoboxMode.Info);
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnmagnify_Click(object sender, EventArgs e)
        {
            selectedtool = "Magnifier";
            gettoolsettings(pnlmagnifiersettings);
        }

        #endregion

        #region Drawing Display

        // ERROR: Handles clauses are not supported in C#
        private void picdrawingdisplay_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, 0, 0, canvaswidth * magnificationlevel, canvasheight * magnificationlevel);
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.ScaleTransform(magnificationlevel, magnificationlevel);

            if (currentlydrawingsquare == true)
            {
                GC.Collect();
                Graphics g = Graphics.FromImage(previewcanvasbitmap);
                previewcanvasbitmap = new Bitmap(canvasbitmap.Width, canvasbitmap.Height);
                g = Graphics.FromImage(previewcanvasbitmap);
                var CurrentPen = new Pen(Color.FromArgb(255, drawingcolour), squarewidth);
                var CurrentBrush = new SolidBrush(Color.FromArgb(255, fillsquarecolor));
                RectangleF rectdraw = new RectangleF(rectanglestartpointx, rectanglestartpointy, thisPoint.X - rectanglestartpointx, thisPoint.Y - rectanglestartpointy);
                int heightamount;
                int widthamount;
                if (rectdraw.Height < 0)
                    heightamount = (int)Math.Abs(rectdraw.Height);
                else
                    heightamount = 0;
                if (rectdraw.Width < 0)
                    widthamount = (int)Math.Abs(rectdraw.Width);
                else
                    widthamount = 0;
                if (squarewidth > 0)
                {
                    g.DrawRectangle(CurrentPen, rectdraw.X - widthamount, rectdraw.Y - heightamount, Math.Abs(rectdraw.Width), Math.Abs(rectdraw.Height));
                }
                if (squarefillon == true)
                {
                    float correctionamount = squarewidth / 2;
                    int addfillamount;
                    if (squarewidth > 0)
                        addfillamount = squarewidth;
                    else
                        addfillamount = -1;
                    g.FillRectangle(CurrentBrush, (rectdraw.X - widthamount) + correctionamount, (rectdraw.Y - heightamount) + correctionamount, Math.Abs(rectdraw.Width) - addfillamount, Math.Abs(rectdraw.Height) - addfillamount);
                }
            }

            if (currentlydrawingoval == true)
            {
                GC.Collect();
                Graphics g = Graphics.FromImage(previewcanvasbitmap);
                previewcanvasbitmap = new Bitmap(canvasbitmap.Width, canvasbitmap.Height);
                g = Graphics.FromImage(previewcanvasbitmap);
                var CurrentPen = new Pen(Color.FromArgb(255, drawingcolour), ovalwidth);
                var CurrentBrush = new SolidBrush(Color.FromArgb(255, fillovalcolor));
                RectangleF ovaldraw = new RectangleF(ovalstartpointx, ovalstartpointy, thisPoint.X - ovalstartpointx, thisPoint.Y - ovalstartpointy);
                int heightamount;
                int widthamount;
                if (ovaldraw.Height < 0)
                    heightamount = (int)Math.Abs(ovaldraw.Height);
                else
                    heightamount = 0;
                if (ovaldraw.Width < 0)
                    widthamount = (int)Math.Abs(ovaldraw.Width);
                else
                    widthamount = 0;
                if (ovalwidth > 0)
                {
                    g.DrawEllipse(CurrentPen, ovaldraw.X - widthamount, ovaldraw.Y - heightamount, Math.Abs(ovaldraw.Width), Math.Abs(ovaldraw.Height));
                }
                if (ovalfillon == true)
                {
                    g.FillEllipse(CurrentBrush, (ovaldraw.X - widthamount), (ovaldraw.Y - heightamount), Math.Abs(ovaldraw.Width), Math.Abs(ovaldraw.Height));
                }
            }

            if (currentlydrawingline == true)
            {
                GC.Collect();
                Graphics g = Graphics.FromImage(previewcanvasbitmap);
                previewcanvasbitmap = new Bitmap(canvasbitmap.Width, canvasbitmap.Height);
                g = Graphics.FromImage(previewcanvasbitmap);
                var CurrentPen = new Pen(Color.FromArgb(255, drawingcolour), linewidth);
                g.DrawLine(CurrentPen, linestartpointx, linestartpointy, thisPoint.X, thisPoint.Y);
            }

            if (currentlydrawingtext == true)
            {
                GC.Collect();
                Graphics g = Graphics.FromImage(previewcanvasbitmap);
                previewcanvasbitmap = new Bitmap(canvasbitmap.Width, canvasbitmap.Height);
                g = Graphics.FromImage(previewcanvasbitmap);
                var CurrentBrush = new SolidBrush(Color.FromArgb(255, drawingcolour));
                g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                drawtextfont = new System.Drawing.Font(drawtextfontname, drawtextsize, drawtextfontstyle);
                g.DrawString(txtdrawstringtext.Text, drawtextfont, CurrentBrush, thisPoint.X, thisPoint.Y);
            }
            try
            {
                e.Graphics.DrawImage(canvasbitmap, 0, 0);
                e.Graphics.DrawImage(previewcanvasbitmap, 0, 0);
            }
            catch 
            {
                
            }
        }



        // ERROR: Handles clauses are not supported in C#
        private void picdrawingdisplay_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            undo.undoStack.Push((Image)canvasbitmap.Clone());
            undo.redoStack.Clear();


            thisPoint.X = (int)(e.Location.X - (magnificationlevel / 2)) / magnificationlevel;
            thisPoint.Y = (int)(e.Location.Y - (magnificationlevel / 2)) / magnificationlevel;

            if (selectedtool == "Pixel Placer")
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (thisPoint.X < canvasbitmap.Width && thisPoint.X > -1)
                    {
                        if (thisPoint.Y < canvasbitmap.Height && thisPoint.Y > -1)
                        {
                            canvasbitmap.SetPixel(thisPoint.X, thisPoint.Y, drawingcolour);
                            //set the pixel on the canvas
                            picdrawingdisplay.Invalidate();
                            //refresh the picture from the canvas
                        }
                    }
                }
            }

            if (selectedtool == "Pencil")
            {
                if (e.Button == MouseButtons.Left)
                {
                    mousePath.StartFigure();
                    picdrawingdisplay.Invalidate();
                }
            }

            if (selectedtool == "Flood Fill")
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (thisPoint.X < canvasbitmap.Width && thisPoint.X > -1)
                    {
                        if (thisPoint.Y < canvasbitmap.Height && thisPoint.Y > -1)
                        {
                            SafeFloodFill(canvasbitmap, thisPoint.X, thisPoint.Y, drawingcolour);
                            graphicsbitmap = Graphics.FromImage(canvasbitmap);
                            picdrawingdisplay.Invalidate();
                        }
                    }
                }
            }

            if (selectedtool == "Square Tool")
            {
                if (e.Button == MouseButtons.Left)
                {
                    rectanglestartpointx = thisPoint.X;
                    rectanglestartpointy = thisPoint.Y;
                    currentlydrawingsquare = true;
                    picdrawingdisplay.Invalidate();
                }
            }

            if (selectedtool == "Oval Tool")
            {
                if (e.Button == MouseButtons.Left)
                {
                    ovalstartpointx = thisPoint.X;
                    ovalstartpointy = thisPoint.Y;
                    currentlydrawingoval = true;
                    picdrawingdisplay.Invalidate();
                }
            }

            if (selectedtool == "Line Tool")
            {
                if (e.Button == MouseButtons.Left)
                {
                    linestartpointx = thisPoint.X;
                    linestartpointy = thisPoint.Y;
                    currentlydrawingline = true;
                    picdrawingdisplay.Invalidate();
                }
            }

            if (selectedtool == "Text Tool")
            {
                if (e.Button == MouseButtons.Left)
                {
                    currentlydrawingtext = true;
                    picdrawingdisplay.Invalidate();
                }
            }

            if (selectedtool == "Eracer")
            {
                var CurrentPen = new Pen(Color.FromArgb(255, canvascolor), eracerwidth);
                float halfsize = eracerwidth / 2;
                if (eracertype == "circle")
                {
                    graphicsbitmap.DrawEllipse(CurrentPen, thisPoint.X - halfsize, thisPoint.Y - halfsize, eracerwidth, eracerwidth);
                }
                else {
                    graphicsbitmap.DrawRectangle(CurrentPen, thisPoint.X - halfsize, thisPoint.Y - halfsize, eracerwidth, eracerwidth);
                }
                picdrawingdisplay.Invalidate();
            }

            if (selectedtool == "Paint Brush")
            {
                var CurrentBrush = new SolidBrush(Color.FromArgb(255, drawingcolour));
                float halfsize = paintbrushwidth / 2;
                if (paintbrushtype == "circle")
                {
                    graphicsbitmap.FillEllipse(CurrentBrush, thisPoint.X - halfsize, thisPoint.Y - halfsize, paintbrushwidth, paintbrushwidth);
                }
                else {
                    graphicsbitmap.FillRectangle(CurrentBrush, thisPoint.X - halfsize, thisPoint.Y - halfsize, paintbrushwidth, paintbrushwidth);
                }
                picdrawingdisplay.Invalidate();
                CurrentBrush.Dispose();
            }
            preparecooldown();
        }

        // ERROR: Handles clauses are not supported in C#
        private void picdrawingdisplay_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Point lastpoint;

            thisPoint.X = (int)(e.Location.X - (magnificationlevel / 2)) / magnificationlevel;
            thisPoint.Y = (int)(e.Location.Y - (magnificationlevel / 2)) / magnificationlevel;


            if (e.Button == MouseButtons.Left)
            {
                undo.redoStack.Clear();
                lastpoint = thisPoint;
                preparecooldown();

                if (selectedtool == "Pixel Placer" && pixalplacermovable == true)
                {
                    if (thisPoint.X < canvasbitmap.Width && thisPoint.X > -1)
                    {
                        if (thisPoint.Y < canvasbitmap.Height && thisPoint.Y > -1)
                        {
                            canvasbitmap.SetPixel(thisPoint.X, thisPoint.Y, drawingcolour);
                            //set the pixel on the canvas
                            picdrawingdisplay.Invalidate();
                            //refresh the picture from the canvas
                        }
                    }
                }

                if (selectedtool == "Pencil")
                {
                    mousePath.AddLine(thisPoint.X, thisPoint.Y, thisPoint.X, thisPoint.Y);
                    var CurrentPen = new Pen(Color.FromArgb(255, drawingcolour), pencilwidth);
                    graphicsbitmap.DrawPath(CurrentPen, mousePath);
                    picdrawingdisplay.Invalidate();
                }

                if (selectedtool == "Square Tool")
                {
                    picdrawingdisplay.Invalidate();
                }

                if (selectedtool == "Oval Tool")
                {
                    picdrawingdisplay.Invalidate();
                }

                if (selectedtool == "Line Tool")
                {
                    picdrawingdisplay.Invalidate();
                }

                if (selectedtool == "Text Tool")
                {
                    picdrawingdisplay.Invalidate();
                }

                if (selectedtool == "Eracer")
                {
                    var CurrentPen = new Pen(Color.FromArgb(255, canvascolor), eracerwidth);
                    float halfsize = eracerwidth / 2;
                    if (eracertype == "circle")
                    {
                        graphicsbitmap.DrawEllipse(CurrentPen, thisPoint.X - halfsize, thisPoint.Y - halfsize, eracerwidth, eracerwidth);
                    }
                    else {
                        graphicsbitmap.DrawRectangle(CurrentPen, thisPoint.X - halfsize, thisPoint.Y - halfsize, eracerwidth, eracerwidth);
                    }
                    picdrawingdisplay.Invalidate();
                }

                if (selectedtool == "Paint Brush")
                {
                    var CurrentBrush = new SolidBrush(Color.FromArgb(255, drawingcolour));
                    float halfsize = paintbrushwidth / 2;
                    if (paintbrushtype == "circle")
                    {
                        graphicsbitmap.FillEllipse(CurrentBrush, thisPoint.X - halfsize, thisPoint.Y - halfsize, paintbrushwidth, paintbrushwidth);
                    }
                    else {
                        graphicsbitmap.FillRectangle(CurrentBrush, thisPoint.X - halfsize, thisPoint.Y - halfsize, paintbrushwidth, paintbrushwidth);
                    }
                    picdrawingdisplay.Invalidate();
                }
            }

        }


        // ERROR: Handles clauses are not supported in C#
        private void picdrawingdisplay_MouseUp(object sender, MouseEventArgs e)
        {
            thisPoint.X = (int)(e.Location.X - (magnificationlevel / 2)) / magnificationlevel;
            thisPoint.Y = (int)(e.Location.Y - (magnificationlevel / 2)) / magnificationlevel;

            if (selectedtool == "Pencil")
            {
                if (e.Button == MouseButtons.Left)
                {
                    mousePath.Reset();
                }
            }

            if (selectedtool == "Square Tool")
            {
                picdrawingdisplay.Invalidate();
                currentlydrawingsquare = false;
            }

            if (selectedtool == "Oval Tool")
            {
                picdrawingdisplay.Invalidate();
                currentlydrawingoval = false;
            }


            if (selectedtool == "Line Tool")
            {
                picdrawingdisplay.Invalidate();
                currentlydrawingline = false;
            }

            if (selectedtool == "Text Tool")
            {
                picdrawingdisplay.Invalidate();
                currentlydrawingtext = false;
            }

            using (Graphics g = Graphics.FromImage(canvasbitmap))
            {
                g.DrawImage(previewcanvasbitmap, 0, 0);
            }
            previewcanvasbitmap = new Bitmap(canvasbitmap.Width, canvasbitmap.Height);
            picdrawingdisplay.Invalidate();
            preparecooldown();

        }

        #endregion

        #region Color Palettes
        // ERROR: Handles clauses are not supported in C#
        private void colourpallet1_MouseClick(object sender, MouseEventArgs e)
        {
            var s = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                drawingcolour = s.BackColor;
                setuppreview();
                settoolcolours();
            }
            else {
                API.CreateColorPickerSession("Artpad Pallete Color", s.BackColor);
                API.ColorPickerSession.FormClosing += (object se, FormClosingEventArgs a) =>
                {
                    s.BackColor = API.GetLastColorFromSession();
                };
            }
        }

        //<unused>
        public void loadcolors()
        {
            /*bool allwhite = true;
            for (int i = 0; i <= 127; i++)
            {
                if (ShiftOSDesktop.artpadcolourpallets(i) == null)
                {
                }
                else {
                    allwhite = false;
                }
            }
            if (allwhite == true)
            {
                for (i = 0; i <= 127; i++)
                {
                    ShiftOSDesktop.artpadcolourpallets(i) = Color.Black;
                }
            }
            colourpallet1.BackColor = ShiftOSDesktop.artpadcolourpallets(0);
            colourpallet2.BackColor = ShiftOSDesktop.artpadcolourpallets(1);
            colourpallet3.BackColor = ShiftOSDesktop.artpadcolourpallets(2);
            colourpallet4.BackColor = ShiftOSDesktop.artpadcolourpallets(3);
            colourpallet5.BackColor = ShiftOSDesktop.artpadcolourpallets(4);
            colourpallet6.BackColor = ShiftOSDesktop.artpadcolourpallets(5);
            colourpallet7.BackColor = ShiftOSDesktop.artpadcolourpallets(6);
            colourpallet8.BackColor = ShiftOSDesktop.artpadcolourpallets(7);
            colourpallet9.BackColor = ShiftOSDesktop.artpadcolourpallets(8);
            colourpallet10.BackColor = ShiftOSDesktop.artpadcolourpallets(9);
            colourpallet11.BackColor = ShiftOSDesktop.artpadcolourpallets(10);
            colourpallet12.BackColor = ShiftOSDesktop.artpadcolourpallets(11);
            colourpallet13.BackColor = ShiftOSDesktop.artpadcolourpallets(12);
            colourpallet14.BackColor = ShiftOSDesktop.artpadcolourpallets(13);
            colourpallet15.BackColor = ShiftOSDesktop.artpadcolourpallets(14);
            colourpallet16.BackColor = ShiftOSDesktop.artpadcolourpallets(15);
            colourpallet17.BackColor = ShiftOSDesktop.artpadcolourpallets(16);
            colourpallet18.BackColor = ShiftOSDesktop.artpadcolourpallets(17);
            colourpallet19.BackColor = ShiftOSDesktop.artpadcolourpallets(18);
            colourpallet20.BackColor = ShiftOSDesktop.artpadcolourpallets(19);
            colourpallet21.BackColor = ShiftOSDesktop.artpadcolourpallets(20);
            colourpallet22.BackColor = ShiftOSDesktop.artpadcolourpallets(21);
            colourpallet23.BackColor = ShiftOSDesktop.artpadcolourpallets(22);
            colourpallet24.BackColor = ShiftOSDesktop.artpadcolourpallets(23);
            colourpallet25.BackColor = ShiftOSDesktop.artpadcolourpallets(24);
            colourpallet26.BackColor = ShiftOSDesktop.artpadcolourpallets(25);
            colourpallet27.BackColor = ShiftOSDesktop.artpadcolourpallets(26);
            colourpallet28.BackColor = ShiftOSDesktop.artpadcolourpallets(27);
            colourpallet29.BackColor = ShiftOSDesktop.artpadcolourpallets(28);
            colourpallet30.BackColor = ShiftOSDesktop.artpadcolourpallets(29);
            colourpallet31.BackColor = ShiftOSDesktop.artpadcolourpallets(30);
            colourpallet32.BackColor = ShiftOSDesktop.artpadcolourpallets(31);
            colourpallet33.BackColor = ShiftOSDesktop.artpadcolourpallets(32);
            colourpallet34.BackColor = ShiftOSDesktop.artpadcolourpallets(33);
            colourpallet35.BackColor = ShiftOSDesktop.artpadcolourpallets(34);
            colourpallet36.BackColor = ShiftOSDesktop.artpadcolourpallets(35);
            colourpallet37.BackColor = ShiftOSDesktop.artpadcolourpallets(36);
            colourpallet38.BackColor = ShiftOSDesktop.artpadcolourpallets(37);
            colourpallet39.BackColor = ShiftOSDesktop.artpadcolourpallets(38);
            colourpallet40.BackColor = ShiftOSDesktop.artpadcolourpallets(39);
            colourpallet41.BackColor = ShiftOSDesktop.artpadcolourpallets(40);
            colourpallet42.BackColor = ShiftOSDesktop.artpadcolourpallets(41);
            colourpallet43.BackColor = ShiftOSDesktop.artpadcolourpallets(42);
            colourpallet44.BackColor = ShiftOSDesktop.artpadcolourpallets(43);
            colourpallet45.BackColor = ShiftOSDesktop.artpadcolourpallets(44);
            colourpallet46.BackColor = ShiftOSDesktop.artpadcolourpallets(45);
            colourpallet47.BackColor = ShiftOSDesktop.artpadcolourpallets(46);
            colourpallet48.BackColor = ShiftOSDesktop.artpadcolourpallets(47);
            colourpallet49.BackColor = ShiftOSDesktop.artpadcolourpallets(48);
            colourpallet50.BackColor = ShiftOSDesktop.artpadcolourpallets(49);
            colourpallet51.BackColor = ShiftOSDesktop.artpadcolourpallets(50);
            colourpallet52.BackColor = ShiftOSDesktop.artpadcolourpallets(51);
            colourpallet53.BackColor = ShiftOSDesktop.artpadcolourpallets(52);
            colourpallet54.BackColor = ShiftOSDesktop.artpadcolourpallets(53);
            colourpallet55.BackColor = ShiftOSDesktop.artpadcolourpallets(54);
            colourpallet56.BackColor = ShiftOSDesktop.artpadcolourpallets(55);
            colourpallet57.BackColor = ShiftOSDesktop.artpadcolourpallets(56);
            colourpallet58.BackColor = ShiftOSDesktop.artpadcolourpallets(57);
            colourpallet59.BackColor = ShiftOSDesktop.artpadcolourpallets(58);
            colourpallet60.BackColor = ShiftOSDesktop.artpadcolourpallets(59);
            colourpallet61.BackColor = ShiftOSDesktop.artpadcolourpallets(60);
            colourpallet62.BackColor = ShiftOSDesktop.artpadcolourpallets(61);
            colourpallet63.BackColor = ShiftOSDesktop.artpadcolourpallets(62);
            colourpallet64.BackColor = ShiftOSDesktop.artpadcolourpallets(63);
            colourpallet65.BackColor = ShiftOSDesktop.artpadcolourpallets(64);
            colourpallet66.BackColor = ShiftOSDesktop.artpadcolourpallets(65);
            colourpallet67.BackColor = ShiftOSDesktop.artpadcolourpallets(66);
            colourpallet68.BackColor = ShiftOSDesktop.artpadcolourpallets(67);
            colourpallet69.BackColor = ShiftOSDesktop.artpadcolourpallets(68);
            colourpallet70.BackColor = ShiftOSDesktop.artpadcolourpallets(69);
            colourpallet71.BackColor = ShiftOSDesktop.artpadcolourpallets(70);
            colourpallet72.BackColor = ShiftOSDesktop.artpadcolourpallets(71);
            colourpallet73.BackColor = ShiftOSDesktop.artpadcolourpallets(72);
            colourpallet74.BackColor = ShiftOSDesktop.artpadcolourpallets(73);
            colourpallet75.BackColor = ShiftOSDesktop.artpadcolourpallets(74);
            colourpallet76.BackColor = ShiftOSDesktop.artpadcolourpallets(75);
            colourpallet77.BackColor = ShiftOSDesktop.artpadcolourpallets(76);
            colourpallet78.BackColor = ShiftOSDesktop.artpadcolourpallets(77);
            colourpallet79.BackColor = ShiftOSDesktop.artpadcolourpallets(78);
            colourpallet80.BackColor = ShiftOSDesktop.artpadcolourpallets(79);
            colourpallet81.BackColor = ShiftOSDesktop.artpadcolourpallets(80);
            colourpallet82.BackColor = ShiftOSDesktop.artpadcolourpallets(81);
            colourpallet83.BackColor = ShiftOSDesktop.artpadcolourpallets(82);
            colourpallet84.BackColor = ShiftOSDesktop.artpadcolourpallets(83);
            colourpallet85.BackColor = ShiftOSDesktop.artpadcolourpallets(84);
            colourpallet86.BackColor = ShiftOSDesktop.artpadcolourpallets(85);
            colourpallet87.BackColor = ShiftOSDesktop.artpadcolourpallets(86);
            colourpallet88.BackColor = ShiftOSDesktop.artpadcolourpallets(87);
            colourpallet89.BackColor = ShiftOSDesktop.artpadcolourpallets(88);
            colourpallet90.BackColor = ShiftOSDesktop.artpadcolourpallets(89);
            colourpallet91.BackColor = ShiftOSDesktop.artpadcolourpallets(90);
            colourpallet92.BackColor = ShiftOSDesktop.artpadcolourpallets(91);
            colourpallet93.BackColor = ShiftOSDesktop.artpadcolourpallets(92);
            colourpallet94.BackColor = ShiftOSDesktop.artpadcolourpallets(93);
            colourpallet95.BackColor = ShiftOSDesktop.artpadcolourpallets(94);
            colourpallet96.BackColor = ShiftOSDesktop.artpadcolourpallets(95);
            colourpallet97.BackColor = ShiftOSDesktop.artpadcolourpallets(96);
            colourpallet98.BackColor = ShiftOSDesktop.artpadcolourpallets(97);
            colourpallet99.BackColor = ShiftOSDesktop.artpadcolourpallets(98);
            colourpallet100.BackColor = ShiftOSDesktop.artpadcolourpallets(99);
            colourpallet101.BackColor = ShiftOSDesktop.artpadcolourpallets(100);
            colourpallet102.BackColor = ShiftOSDesktop.artpadcolourpallets(101);
            colourpallet103.BackColor = ShiftOSDesktop.artpadcolourpallets(102);
            colourpallet104.BackColor = ShiftOSDesktop.artpadcolourpallets(103);
            colourpallet105.BackColor = ShiftOSDesktop.artpadcolourpallets(104);
            colourpallet106.BackColor = ShiftOSDesktop.artpadcolourpallets(105);
            colourpallet107.BackColor = ShiftOSDesktop.artpadcolourpallets(106);
            colourpallet108.BackColor = ShiftOSDesktop.artpadcolourpallets(107);
            colourpallet109.BackColor = ShiftOSDesktop.artpadcolourpallets(108);
            colourpallet110.BackColor = ShiftOSDesktop.artpadcolourpallets(109);
            colourpallet111.BackColor = ShiftOSDesktop.artpadcolourpallets(110);
            colourpallet112.BackColor = ShiftOSDesktop.artpadcolourpallets(111);
            colourpallet113.BackColor = ShiftOSDesktop.artpadcolourpallets(112);
            colourpallet114.BackColor = ShiftOSDesktop.artpadcolourpallets(113);
            colourpallet115.BackColor = ShiftOSDesktop.artpadcolourpallets(114);
            colourpallet116.BackColor = ShiftOSDesktop.artpadcolourpallets(115);
            colourpallet117.BackColor = ShiftOSDesktop.artpadcolourpallets(116);
            colourpallet118.BackColor = ShiftOSDesktop.artpadcolourpallets(117);
            colourpallet119.BackColor = ShiftOSDesktop.artpadcolourpallets(118);
            colourpallet120.BackColor = ShiftOSDesktop.artpadcolourpallets(119);
            colourpallet121.BackColor = ShiftOSDesktop.artpadcolourpallets(120);
            colourpallet122.BackColor = ShiftOSDesktop.artpadcolourpallets(121);
            colourpallet123.BackColor = ShiftOSDesktop.artpadcolourpallets(122);
            colourpallet124.BackColor = ShiftOSDesktop.artpadcolourpallets(123);
            colourpallet125.BackColor = ShiftOSDesktop.artpadcolourpallets(124);
            colourpallet126.BackColor = ShiftOSDesktop.artpadcolourpallets(125);
            colourpallet127.BackColor = ShiftOSDesktop.artpadcolourpallets(126);
            colourpallet128.BackColor = ShiftOSDesktop.artpadcolourpallets(127);
        */}

        public void savecolors()
        {/*
            ShiftOSDesktop.artpadcolourpallets(0) = colourpallet1.BackColor;
            ShiftOSDesktop.artpadcolourpallets(1) = colourpallet2.BackColor;
            ShiftOSDesktop.artpadcolourpallets(2) = colourpallet3.BackColor;
            ShiftOSDesktop.artpadcolourpallets(3) = colourpallet4.BackColor;
            ShiftOSDesktop.artpadcolourpallets(4) = colourpallet5.BackColor;
            ShiftOSDesktop.artpadcolourpallets(5) = colourpallet6.BackColor;
            ShiftOSDesktop.artpadcolourpallets(6) = colourpallet7.BackColor;
            ShiftOSDesktop.artpadcolourpallets(7) = colourpallet8.BackColor;
            ShiftOSDesktop.artpadcolourpallets(8) = colourpallet9.BackColor;
            ShiftOSDesktop.artpadcolourpallets(9) = colourpallet10.BackColor;
            ShiftOSDesktop.artpadcolourpallets(10) = colourpallet11.BackColor;
            ShiftOSDesktop.artpadcolourpallets(11) = colourpallet12.BackColor;
            ShiftOSDesktop.artpadcolourpallets(12) = colourpallet13.BackColor;
            ShiftOSDesktop.artpadcolourpallets(13) = colourpallet14.BackColor;
            ShiftOSDesktop.artpadcolourpallets(14) = colourpallet15.BackColor;
            ShiftOSDesktop.artpadcolourpallets(15) = colourpallet16.BackColor;
            ShiftOSDesktop.artpadcolourpallets(16) = colourpallet17.BackColor;
            ShiftOSDesktop.artpadcolourpallets(17) = colourpallet18.BackColor;
            ShiftOSDesktop.artpadcolourpallets(18) = colourpallet19.BackColor;
            ShiftOSDesktop.artpadcolourpallets(19) = colourpallet20.BackColor;
            ShiftOSDesktop.artpadcolourpallets(20) = colourpallet21.BackColor;
            ShiftOSDesktop.artpadcolourpallets(21) = colourpallet22.BackColor;
            ShiftOSDesktop.artpadcolourpallets(22) = colourpallet23.BackColor;
            ShiftOSDesktop.artpadcolourpallets(23) = colourpallet24.BackColor;
            ShiftOSDesktop.artpadcolourpallets(24) = colourpallet25.BackColor;
            ShiftOSDesktop.artpadcolourpallets(25) = colourpallet26.BackColor;
            ShiftOSDesktop.artpadcolourpallets(26) = colourpallet27.BackColor;
            ShiftOSDesktop.artpadcolourpallets(27) = colourpallet28.BackColor;
            ShiftOSDesktop.artpadcolourpallets(28) = colourpallet29.BackColor;
            ShiftOSDesktop.artpadcolourpallets(29) = colourpallet30.BackColor;
            ShiftOSDesktop.artpadcolourpallets(30) = colourpallet31.BackColor;
            ShiftOSDesktop.artpadcolourpallets(31) = colourpallet32.BackColor;
            ShiftOSDesktop.artpadcolourpallets(32) = colourpallet33.BackColor;
            ShiftOSDesktop.artpadcolourpallets(33) = colourpallet34.BackColor;
            ShiftOSDesktop.artpadcolourpallets(34) = colourpallet35.BackColor;
            ShiftOSDesktop.artpadcolourpallets(35) = colourpallet36.BackColor;
            ShiftOSDesktop.artpadcolourpallets(36) = colourpallet37.BackColor;
            ShiftOSDesktop.artpadcolourpallets(37) = colourpallet38.BackColor;
            ShiftOSDesktop.artpadcolourpallets(38) = colourpallet39.BackColor;
            ShiftOSDesktop.artpadcolourpallets(39) = colourpallet40.BackColor;
            ShiftOSDesktop.artpadcolourpallets(40) = colourpallet41.BackColor;
            ShiftOSDesktop.artpadcolourpallets(41) = colourpallet42.BackColor;
            ShiftOSDesktop.artpadcolourpallets(42) = colourpallet43.BackColor;
            ShiftOSDesktop.artpadcolourpallets(43) = colourpallet44.BackColor;
            ShiftOSDesktop.artpadcolourpallets(44) = colourpallet45.BackColor;
            ShiftOSDesktop.artpadcolourpallets(45) = colourpallet46.BackColor;
            ShiftOSDesktop.artpadcolourpallets(46) = colourpallet47.BackColor;
            ShiftOSDesktop.artpadcolourpallets(47) = colourpallet48.BackColor;
            ShiftOSDesktop.artpadcolourpallets(48) = colourpallet49.BackColor;
            ShiftOSDesktop.artpadcolourpallets(49) = colourpallet50.BackColor;
            ShiftOSDesktop.artpadcolourpallets(50) = colourpallet51.BackColor;
            ShiftOSDesktop.artpadcolourpallets(51) = colourpallet52.BackColor;
            ShiftOSDesktop.artpadcolourpallets(52) = colourpallet53.BackColor;
            ShiftOSDesktop.artpadcolourpallets(53) = colourpallet54.BackColor;
            ShiftOSDesktop.artpadcolourpallets(54) = colourpallet55.BackColor;
            ShiftOSDesktop.artpadcolourpallets(55) = colourpallet56.BackColor;
            ShiftOSDesktop.artpadcolourpallets(56) = colourpallet57.BackColor;
            ShiftOSDesktop.artpadcolourpallets(57) = colourpallet58.BackColor;
            ShiftOSDesktop.artpadcolourpallets(58) = colourpallet59.BackColor;
            ShiftOSDesktop.artpadcolourpallets(59) = colourpallet60.BackColor;
            ShiftOSDesktop.artpadcolourpallets(60) = colourpallet61.BackColor;
            ShiftOSDesktop.artpadcolourpallets(61) = colourpallet62.BackColor;
            ShiftOSDesktop.artpadcolourpallets(62) = colourpallet63.BackColor;
            ShiftOSDesktop.artpadcolourpallets(63) = colourpallet64.BackColor;
            ShiftOSDesktop.artpadcolourpallets(64) = colourpallet65.BackColor;
            ShiftOSDesktop.artpadcolourpallets(65) = colourpallet66.BackColor;
            ShiftOSDesktop.artpadcolourpallets(66) = colourpallet67.BackColor;
            ShiftOSDesktop.artpadcolourpallets(67) = colourpallet68.BackColor;
            ShiftOSDesktop.artpadcolourpallets(68) = colourpallet69.BackColor;
            ShiftOSDesktop.artpadcolourpallets(69) = colourpallet70.BackColor;
            ShiftOSDesktop.artpadcolourpallets(70) = colourpallet71.BackColor;
            ShiftOSDesktop.artpadcolourpallets(71) = colourpallet72.BackColor;
            ShiftOSDesktop.artpadcolourpallets(72) = colourpallet73.BackColor;
            ShiftOSDesktop.artpadcolourpallets(73) = colourpallet74.BackColor;
            ShiftOSDesktop.artpadcolourpallets(74) = colourpallet75.BackColor;
            ShiftOSDesktop.artpadcolourpallets(75) = colourpallet76.BackColor;
            ShiftOSDesktop.artpadcolourpallets(76) = colourpallet77.BackColor;
            ShiftOSDesktop.artpadcolourpallets(77) = colourpallet78.BackColor;
            ShiftOSDesktop.artpadcolourpallets(78) = colourpallet79.BackColor;
            ShiftOSDesktop.artpadcolourpallets(79) = colourpallet80.BackColor;
            ShiftOSDesktop.artpadcolourpallets(80) = colourpallet81.BackColor;
            ShiftOSDesktop.artpadcolourpallets(81) = colourpallet82.BackColor;
            ShiftOSDesktop.artpadcolourpallets(82) = colourpallet83.BackColor;
            ShiftOSDesktop.artpadcolourpallets(83) = colourpallet84.BackColor;
            ShiftOSDesktop.artpadcolourpallets(84) = colourpallet85.BackColor;
            ShiftOSDesktop.artpadcolourpallets(85) = colourpallet86.BackColor;
            ShiftOSDesktop.artpadcolourpallets(86) = colourpallet87.BackColor;
            ShiftOSDesktop.artpadcolourpallets(87) = colourpallet88.BackColor;
            ShiftOSDesktop.artpadcolourpallets(88) = colourpallet89.BackColor;
            ShiftOSDesktop.artpadcolourpallets(89) = colourpallet90.BackColor;
            ShiftOSDesktop.artpadcolourpallets(90) = colourpallet91.BackColor;
            ShiftOSDesktop.artpadcolourpallets(91) = colourpallet92.BackColor;
            ShiftOSDesktop.artpadcolourpallets(92) = colourpallet93.BackColor;
            ShiftOSDesktop.artpadcolourpallets(93) = colourpallet94.BackColor;
            ShiftOSDesktop.artpadcolourpallets(94) = colourpallet95.BackColor;
            ShiftOSDesktop.artpadcolourpallets(95) = colourpallet96.BackColor;
            ShiftOSDesktop.artpadcolourpallets(96) = colourpallet97.BackColor;
            ShiftOSDesktop.artpadcolourpallets(97) = colourpallet98.BackColor;
            ShiftOSDesktop.artpadcolourpallets(98) = colourpallet99.BackColor;
            ShiftOSDesktop.artpadcolourpallets(99) = colourpallet100.BackColor;
            ShiftOSDesktop.artpadcolourpallets(100) = colourpallet101.BackColor;
            ShiftOSDesktop.artpadcolourpallets(101) = colourpallet102.BackColor;
            ShiftOSDesktop.artpadcolourpallets(102) = colourpallet103.BackColor;
            ShiftOSDesktop.artpadcolourpallets(103) = colourpallet104.BackColor;
            ShiftOSDesktop.artpadcolourpallets(104) = colourpallet105.BackColor;
            ShiftOSDesktop.artpadcolourpallets(105) = colourpallet106.BackColor;
            ShiftOSDesktop.artpadcolourpallets(106) = colourpallet107.BackColor;
            ShiftOSDesktop.artpadcolourpallets(107) = colourpallet108.BackColor;
            ShiftOSDesktop.artpadcolourpallets(108) = colourpallet109.BackColor;
            ShiftOSDesktop.artpadcolourpallets(109) = colourpallet110.BackColor;
            ShiftOSDesktop.artpadcolourpallets(110) = colourpallet111.BackColor;
            ShiftOSDesktop.artpadcolourpallets(111) = colourpallet112.BackColor;
            ShiftOSDesktop.artpadcolourpallets(112) = colourpallet113.BackColor;
            ShiftOSDesktop.artpadcolourpallets(113) = colourpallet114.BackColor;
            ShiftOSDesktop.artpadcolourpallets(114) = colourpallet115.BackColor;
            ShiftOSDesktop.artpadcolourpallets(115) = colourpallet116.BackColor;
            ShiftOSDesktop.artpadcolourpallets(116) = colourpallet117.BackColor;
            ShiftOSDesktop.artpadcolourpallets(117) = colourpallet118.BackColor;
            ShiftOSDesktop.artpadcolourpallets(118) = colourpallet119.BackColor;
            ShiftOSDesktop.artpadcolourpallets(119) = colourpallet120.BackColor;
            ShiftOSDesktop.artpadcolourpallets(120) = colourpallet121.BackColor;
            ShiftOSDesktop.artpadcolourpallets(121) = colourpallet122.BackColor;
            ShiftOSDesktop.artpadcolourpallets(122) = colourpallet123.BackColor;
            ShiftOSDesktop.artpadcolourpallets(123) = colourpallet124.BackColor;
            ShiftOSDesktop.artpadcolourpallets(124) = colourpallet125.BackColor;
            ShiftOSDesktop.artpadcolourpallets(125) = colourpallet126.BackColor;
            ShiftOSDesktop.artpadcolourpallets(126) = colourpallet127.BackColor;
            ShiftOSDesktop.artpadcolourpallets(127) = colourpallet128.BackColor;
        */}
        //</unused>

        public void settoolcolours()
        {
            btnpixelsetter.BackColor = drawingcolour;
            btnpixelplacer.BackColor = drawingcolour;
            btnpencil.BackColor = drawingcolour;
            btnfloodfill.BackColor = drawingcolour;
            btnsquare.BackColor = drawingcolour;
            btnoval.BackColor = drawingcolour;
            btnlinetool.BackColor = drawingcolour;
            btnpaintbrush.BackColor = drawingcolour;
            btntexttool.BackColor = drawingcolour;
        }
        #endregion

        #region Zooming

        // ERROR: Handles clauses are not supported in C#
        private void btnzoomin_Click(object sender, EventArgs e)
        {
            if (magnificationlevel < 256)
            {
                magnificationlevel *= 2;
            }
            else {
                API.CreateInfoboxSession("ArtPad - Magnification Error!"
                , "You are unable to increase the magnification level any further." + Environment.NewLine + Environment.NewLine + "256x is the highest level of magnification supported by ArtPad!", infobox.InfoboxMode.Info);
            }
            setmagnification();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnzoomout_Click(object sender, EventArgs e)
        {
            if (magnificationlevel > 1)
            {
                magnificationlevel /= 2;
                pnldrawingbackground.AutoScrollPosition = new Point(0, 0);
            }
            else {
                API.CreateInfoboxSession("ArtPad - Magnification Error!"
                ,"You are unable to decrease the magnification level any further." + Environment.NewLine + Environment.NewLine + "Artpad is unable to scale pixels at a level smaller than their actual size!", infobox.InfoboxMode.Info);
            }
            setmagnification();
        }

        private void setmagnification()
        {
            magnifyRect.Width = (int)canvaswidth / magnificationlevel;
            magnifyRect.Height = (int)canvasheight / magnificationlevel;
            picdrawingdisplay.Size = new Size(canvaswidth * magnificationlevel, canvasheight * magnificationlevel);
            if (picdrawingdisplay.Height > 468 && picdrawingdisplay.Width > 676)
            {
                picdrawingdisplay.Location = new Point(0, 0);
            }
            else {
                picdrawingdisplay.Location = new Point((pnldrawingbackground.Width - canvaswidth * magnificationlevel) / 2, (pnldrawingbackground.Height - canvasheight * magnificationlevel) / 2);
            }
            picdrawingdisplay.Invalidate();
            lblzoomlevel.Text = magnificationlevel + "X";
        }

        #endregion

        #region Pixel Placer

        // ERROR: Handles clauses are not supported in C#
        private void pnlpixelplacer_Click(object sender, EventArgs e)
        {
            selectedtool = "Pixel Placer";
            gettoolsettings(pnlpixelplacersettings);
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnpixelplacermovementmode_Click(object sender, EventArgs e)
        {
            if (pixalplacermovable == false)
            {
                pixalplacermovable = true;
                btnpixelplacermovementmode.ForeColor = Color.White;
                btnpixelplacermovementmode.BackColor = Color.Black;
                btnpixelplacermovementmode.Text = "Deactivate Movement Mode";
                lblpixelplacerhelp.Text = "Movement mode is enabled. Click and drag on the canvas to place pixels as you move the mouse. Please use 4x magnification or greater and move the mouse very slowly.";
            }
            else {
                pixalplacermovable = false;
                btnpixelplacermovementmode.ForeColor = Color.Black;
                btnpixelplacermovementmode.BackColor = Color.White;
                btnpixelplacermovementmode.Text = "Activate Movement Mode";
                lblpixelplacerhelp.Text = "This tool does not contain any alterable settings. Simply click on the canvas and a pixel will be placed in the spot you click.";
            }
        }

        #endregion

        #region Saving

        // ERROR: Handles clauses are not supported in C#
        private void btnsave_Click(object sender, EventArgs e)
        {
            showsavedialog();
        }

        public void showsavedialog()
        {
            API.CreateFileSkimmerSession(".pic", File_Skimmer.FileSkimmerMode.Save);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                var res = API.GetFSResult();
                if(res != "fail")
                {
                    savelocation = res;
                    saveimage();
                }
            };
        }

        public void saveimage()
        {
            canvasbitmap.Save(savelocation, ImageFormat.Bmp);
        }
        #endregion

        #region New Canvas

        // ERROR: Handles clauses are not supported in C#
        private void txtnewcanvaswidth_TextChanged(object sender, EventArgs e)
        {
            if (txtnewcanvaswidth.Text == "" | txtnewcanvasheight.Text == "")
            {
                if(txtnewcanvasheight.Text == "")
                {
                    txtnewcanvasheight.Text = "0";
                }
                if (txtnewcanvaswidth.Text == "")
                {
                    txtnewcanvaswidth.Text = "0";
                }
            }
            else {
                try {
                    lbltotalpixels.Text = (Convert.ToInt32(txtnewcanvaswidth.Text) * Convert.ToInt32(txtnewcanvasheight.Text)).ToString();
                    if (API.Upgrades["artpadlimitlesspixels"] == true)
                    {
                        lbltotalpixels.ForeColor = Color.Black;
                    }
                    else {
                        if ((Convert.ToInt32(txtnewcanvaswidth.Text) * Convert.ToInt32(txtnewcanvasheight.Text)) > GetPixelLimit())
                        {
                            lbltotalpixels.ForeColor = Color.Red;
                        }
                        else {
                            lbltotalpixels.ForeColor = Color.Black;
                        }
                    }
                }
                catch
                {

                }
            }

        }

        public int GetPixelLimit()
        {
            int value = 2;

            
            if(API.Upgrades["artpadpixellimit4"])
            {
                value = 4;
                if (API.Upgrades["artpadpixellimit8"])
                {
                    value = 8;
                    if (API.Upgrades["artpadpixellimit16"])
                    {
                        value = 16;
                        if (API.Upgrades["artpadpixellimit64"])
                        {
                            value = 64;
                            if (API.Upgrades["artpadpixellimit256"])
                            {
                                value = 256;
                                if (API.Upgrades["artpadpixellimit1024"])
                                {
                                    value = 1024;
                                    if (API.Upgrades["artpadpixellimit4096"])
                                    {
                                        value = 4096;
                                        if (API.Upgrades["artpadpixellimit16384"])
                                        {
                                            value = 16384;
                                            if (API.Upgrades["artpadpixellimit65536"])
                                            {
                                                value = 65536;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return value;
        }

        // ERROR: Handles clauses are not supported in C#
        private void btncreate_Click(object sender, EventArgs e)
        {
            if (lbltotalpixels.ForeColor == Color.Red)
            {
                API.CreateInfoboxSession("Artpad - Error", "Artpad cannot create the image. It is too big.", infobox.InfoboxMode.Info);
            }
            else {
                if (lbltotalpixels.Text == "0")
                {
                }
                else {
                    canvaswidth = Convert.ToInt32(txtnewcanvaswidth.Text);
                    canvasheight = Convert.ToInt32(txtnewcanvasheight.Text);
                    picdrawingdisplay.Show();
                    setupcanvas();
                    pnlinitialcanvassettings.Hide();
                }
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void btncancel_Click(object sender, EventArgs e)
        {
            pnlinitialcanvassettings.Hide();
            picdrawingdisplay.Show();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnnew_Click(object sender, EventArgs e)
        {
            pnlinitialcanvassettings.Show();
            picdrawingdisplay.Hide();
        }

        #endregion

        #region Preview

        public void setuppreview()
        {
            lbltoolselected.Text = selectedtool;
            picpreview.CreateGraphics().FillRectangle(Brushes.White, 0, 0, 70, 50);
            switch (selectedtool)
            {
                case "Square Tool":
                    var CurrentPen = new Pen(Color.FromArgb(255, drawingcolour), squarewidth);
                    var CurrentBrush = new SolidBrush(Color.FromArgb(255, fillsquarecolor));
                    RectangleF rectdraw = new RectangleF(0, 0, picpreview.Width, picpreview.Height);
                    float correctionamount = squarewidth / 2;
                    if (squarewidth > 0)
                    {
                        picpreview.CreateGraphics().DrawRectangle(CurrentPen, rectdraw.X + correctionamount, rectdraw.Y + correctionamount, rectdraw.Width - squarewidth, rectdraw.Height - squarewidth);
                    }
                    if (squarefillon == true)
                    {
                        picpreview.CreateGraphics().FillRectangle(CurrentBrush, rectdraw.X + squarewidth, rectdraw.Y + squarewidth, rectdraw.Width - squarewidth - squarewidth, rectdraw.Height - squarewidth - squarewidth);
                    }
                    break;
                case "Oval Tool":
                    var ovalCurrentPen = new Pen(Color.FromArgb(255, drawingcolour), ovalwidth);
                    var ovalCurrentBrush = new SolidBrush(Color.FromArgb(255, fillovalcolor));
                    RectangleF ovalrectdraw = new RectangleF(0, 0, picpreview.Width, picpreview.Height);
                    float ovalcorrectionamount = ovalwidth / 2;
                    if (ovalwidth > 0)
                    {
                        picpreview.CreateGraphics().DrawEllipse(ovalCurrentPen, ovalrectdraw.X + ovalcorrectionamount, ovalrectdraw.Y + ovalcorrectionamount, ovalrectdraw.Width - ovalwidth, ovalrectdraw.Height - ovalwidth);
                    }
                    if (ovalfillon == true)
                    {
                        float fixer = ovalwidth / 2;
                        picpreview.CreateGraphics().FillEllipse(ovalCurrentBrush, (ovalrectdraw.X + fixer), (ovalrectdraw.Y + fixer), ovalrectdraw.Width - fixer - fixer, ovalrectdraw.Height - fixer - fixer);
                    }
                    break;
                case "Text Tool":
                    var textCurrentBrush = new SolidBrush(Color.FromArgb(255, drawingcolour));
                    drawtextfont = new System.Drawing.Font(drawtextfontname, 20, drawtextfontstyle);
                    picpreview.CreateGraphics().DrawString("A", drawtextfont, textCurrentBrush, 20, 0);
                    break;
                case "Line Tool":
                    var lineCurrentPen = new Pen(Color.FromArgb(255, drawingcolour), linewidth);
                    picpreview.CreateGraphics().DrawLine(lineCurrentPen, 0, 0, picpreview.Width, picpreview.Height);
                    break;
                case "Pencil":
                    var pencilCurrentPen = new Pen(Color.FromArgb(255, drawingcolour), pencilwidth);
                    picpreview.CreateGraphics().DrawLine(pencilCurrentPen, 0, 25, picpreview.Width, 25);
                    break;
                case "Paint Brush":
                    var pbCurrentBrush = new SolidBrush(Color.FromArgb(255, drawingcolour));
                    float halfsize = paintbrushwidth / 2;
                    float halfwidth = picdrawingdisplay.Width / 2;
                    float halfheight = picdrawingdisplay.Height / 2;
                    if (paintbrushtype == "circle")
                    {
                        picpreview.CreateGraphics().FillEllipse(pbCurrentBrush, halfwidth - 15 - halfsize, halfheight - 1 - halfsize, paintbrushwidth, paintbrushwidth);
                    }
                    else {
                        picpreview.CreateGraphics().FillRectangle(pbCurrentBrush, halfwidth - 15 - halfsize, halfheight - 1 - halfsize, paintbrushwidth, paintbrushwidth);
                    }
                    break;
                case "Eracer":
                    System.Drawing.SolidBrush drawbrush = new System.Drawing.SolidBrush(drawingcolour);
                    picpreview.CreateGraphics().FillRectangle(drawbrush, 0, 0, picpreview.Width, picpreview.Height);
                    var eCurrentBrush = new SolidBrush(Color.FromArgb(255, Color.White));
                    float ehalfsize = eracerwidth / 2;
                    float ehalfwidth = picdrawingdisplay.Width / 2;
                    float ehalfheight = picdrawingdisplay.Height / 2;
                    if (eracertype == "circle")
                    {
                        picpreview.CreateGraphics().FillEllipse(eCurrentBrush, ehalfwidth - 15 - ehalfsize, ehalfheight - ehalfsize, eracerwidth, eracerwidth);
                    }
                    else {
                        picpreview.CreateGraphics().FillRectangle(eCurrentBrush, ehalfwidth - 15 - ehalfsize, ehalfheight - ehalfsize, eracerwidth, eracerwidth);
                    }
                    break;
                default:
                    System.Drawing.SolidBrush ddrawbrush = new System.Drawing.SolidBrush(drawingcolour);
                    picpreview.CreateGraphics().FillRectangle(ddrawbrush, 0, 0, picpreview.Width, picpreview.Height);
                    ddrawbrush.Dispose();
                    break;
            }
        }

        #endregion

        #region Pencil

        // ERROR: Handles clauses are not supported in C#
        private void btnpencil_Click(object sender, EventArgs e)
        {
            selectedtool = "Pencil";
            gettoolsettings(pnlpencilsettings);
        }

        // ERROR: Handles clauses are not supported in C#
        private void ChangePencilSize(object sender, EventArgs e)
        {
            var s = (Control)sender;
            switch (s.Name.ToString())
            {
                case "btnpencilsize1":
                    pencilwidth = 1;
                    break;
                case "btnpencilsize2":
                    pencilwidth = 2;
                    break;
                case "btnpencilsize3":
                    pencilwidth = 3;
                    break;
            }
            setuppreview();
        }

        #endregion

        #region Undo/Redo

        // ERROR: Handles clauses are not supported in C#
        private void btnundo_Click(object sender, EventArgs e)
        {
            try
            {
                undo.redoStack.Push((Image)canvasbitmap.Clone());
                canvasbitmap = (Bitmap)undo.undoStack.Pop();
                graphicsbitmap = Graphics.FromImage(canvasbitmap);
                picdrawingdisplay.Invalidate();
            }
            catch 
            {
                API.CreateInfoboxSession("ArtPad - Undo Error!"
                ,"There doesn't appear to be any more actions to undo." + Environment.NewLine + Environment.NewLine + "One more step back would undo the creation of the canvas. If this is your goal just click new.", infobox.InfoboxMode.Info);
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnredo_Click(object sender, EventArgs e)
        {
            try
            {
                undo.undoStack.Push((Image)canvasbitmap.Clone());
                canvasbitmap = (Bitmap)undo.redoStack.Pop();
                graphicsbitmap = Graphics.FromImage(canvasbitmap);
                picdrawingdisplay.Invalidate();
            }
            catch 
            {
                API.CreateInfoboxSession("ArtPad - Redo Error!"
                , "There doesn't appear to be any more actions to redo." + Environment.NewLine + Environment.NewLine + "If you have drawn on the canvas recently all future history would have been wiped!", infobox.InfoboxMode.Info);
            }
        }

        #endregion

        #region File Loading

        // ERROR: Handles clauses are not supported in C#
        private void btnopen_Click(object sender, EventArgs e)
        {
            API.CreateFileSkimmerSession(".pic", File_Skimmer.FileSkimmerMode.Open);
            API.FileSkimmerSession.FormClosing += (object s, FormClosingEventArgs a) =>
            {
                string res = API.GetFSResult();
                if(res != "fail")
                {
                    savelocation = res;
                    openpic();
                }
            };
        }

        public void openpic()
        {
            pnlinitialcanvassettings.Hide();
            picdrawingdisplay.Show();
            magnificationlevel = 1;
            setmagnification();
            canvasbitmap = (Bitmap)Image.FromFile(savelocation);
            canvasheight = canvasbitmap.Height;
            canvaswidth = canvasbitmap.Width;
            picdrawingdisplay.Size = new Size(canvaswidth, canvasheight);
            picdrawingdisplay.Location = new Point((pnldrawingbackground.Width - canvaswidth) / 2, (pnldrawingbackground.Height - canvasheight) / 2);
            graphicsbitmap = Graphics.FromImage(canvasbitmap);
            picdrawingdisplay.Invalidate();
        }

        #endregion

        #region Flood Fill

        // Flood fill the point.
        public void SafeFloodFill(Bitmap bm, int x, int y, Color new_color)
        {
            // Get the old and new colors.
            Color old_color = bm.GetPixel(x, y);

            // The following "If Then" test was added by Reuben
            // Jollif
            // to protect the code in case the start pixel
            // has the same color as the fill color.
            if (old_color.ToArgb() != new_color.ToArgb())
            {
                // Start with the original point in the stack.
                Stack<Point> pts = new Stack<Point>(1000);
                pts.Push(new Point(x, y));
                bm.SetPixel(x, y, new_color);

                // While the stack is not empty, process a point.
                while (pts.Count > 0)
                {
                    Point pt = (Point)pts.Pop();
                    if (pt.X > 0)
                        SafeCheckPoint(bm, pts, pt.X - 1, pt.Y, old_color, new_color);

                    if (pt.Y > 0)
                        SafeCheckPoint(bm, pts, pt.X, pt.Y - 1, old_color, new_color);
                    if (pt.X < bm.Width - 1)
                        SafeCheckPoint(bm, pts, pt.X + 1, pt.Y, old_color, new_color);
                    if (pt.Y < bm.Height - 1)
                        SafeCheckPoint(bm, pts, pt.X, pt.Y + 1, old_color, new_color);
                }
            }
        }

        // See if this point should be added to the stack.
        private void SafeCheckPoint(Bitmap bm, Stack<Point> pts, int x, int y, Color old_color, Color new_color)
        {
            Color clr = bm.GetPixel(x, y);
            if (clr.Equals(old_color))
            {
                pts.Push(new Point(x, y));
                bm.SetPixel(x, y, new_color);
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnfill_Click(object sender, EventArgs e)
        {
            selectedtool = "Flood Fill";
            gettoolsettings(pnlfloodfillsettings);
        }

        #endregion

        #region Shapes

        // ERROR: Handles clauses are not supported in C#
        private void btnsquare_Click(object sender, EventArgs e)
        {
            selectedtool = "Square Tool";
            gettoolsettings(pnlsquaretoolsettings);
            txtsquareborderwidth.Text = squarewidth.ToString();
        }

        // ERROR: Handles clauses are not supported in C#
        private void txtsquareborderwidth_TextChanged(object sender, EventArgs e)
        {
            if (txtsquareborderwidth.Text == "")
            {
            }
            else {
                squarewidth = (Convert.ToInt32(txtsquareborderwidth.Text));
                setuppreview();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void pnlsquarefillcolour_Click(object sender, EventArgs e)
        {
            pnlsquarefillcolour.BackColor = drawingcolour;
            fillsquarecolor = drawingcolour;
            setuppreview();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnsquarefillonoff_Click(object sender, EventArgs e)
        {
            if (squarefillon == true)
            {
                btnsquarefillonoff.Text = "Fill OFF";
                btnsquarefillonoff.BackColor = Color.White;
                btnsquarefillonoff.ForeColor = Color.Black;
                squarefillon = false;
            }
            else {
                btnsquarefillonoff.Text = "Fill ON";
                btnsquarefillonoff.BackColor = Color.Black;
                btnsquarefillonoff.ForeColor = Color.White;
                squarefillon = true;
            }
            txtsquareborderwidth.Text = squarewidth.ToString();
            setuppreview();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnoval_Click(object sender, EventArgs e)
        {
            selectedtool = "Oval Tool";
            gettoolsettings(pnlovaltoolsettings);
            txtovalborderwidth.Text = ovalwidth.ToString();
        }

        // ERROR: Handles clauses are not supported in C#
        private void txtovalborderwidth_TextChanged(object sender, EventArgs e)
        {
            if (txtovalborderwidth.Text == "")
            {
            }
            else {
                ovalwidth = (Convert.ToInt32(txtovalborderwidth.Text));
                setuppreview();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void pnlovalfillcolour_Click(object sender, EventArgs e)
        {
            pnlovalfillcolour.BackColor = drawingcolour;
            fillovalcolor = drawingcolour;
            setuppreview();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnovalfillonoff_Click(object sender, EventArgs e)
        {
            if (ovalfillon == true)
            {
                btnovalfillonoff.Text = "Fill OFF";
                btnovalfillonoff.BackColor = Color.White;
                btnovalfillonoff.ForeColor = Color.Black;
                ovalfillon = false;
            }
            else {
                btnovalfillonoff.Text = "Fill ON";
                btnovalfillonoff.BackColor = Color.Black;
                btnovalfillonoff.ForeColor = Color.White;
                ovalfillon = true;
            }
            txtovalborderwidth.Text = ovalwidth.ToString();
            setuppreview();
        }
        #endregion

        #region Eraser

        // ERROR: Handles clauses are not supported in C#
        private void btneracer_Click(object sender, EventArgs e)
        {
            selectedtool = "Eracer";
            gettoolsettings(pnleracertoolsettings);
            txteracersize.Text = eracerwidth.ToString();
            setuppreview();
        }

        // ERROR: Handles clauses are not supported in C#
        private void txteracersize_TextChanged(object sender, EventArgs e)
        {
            if (txteracersize.Text == "")
            {
            }
            else {
                eracerwidth = (Convert.ToInt32(txteracersize.Text));
            }
            setuppreview();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btneracercircle_Click(object sender, EventArgs e)
        {
            eracertype = "circle";
            btneracercircle.BackgroundImage = Properties.Resources.ArtPadcirclerubberselected;
            btneracersquare.BackgroundImage = Properties.Resources.ArtPadsquarerubber;
            setuppreview();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btneracersquare_Click(object sender, EventArgs e)
        {
            eracertype = "square";
            btneracercircle.BackgroundImage = Properties.Resources.ArtPadcirclerubber;
            btneracersquare.BackgroundImage = Properties.Resources.ArtPadsquarerubberselected;
            setuppreview();
        }

        #endregion

        #region Line

        // ERROR: Handles clauses are not supported in C#
        private void btnlinetool_Click(object sender, EventArgs e)
        {
            selectedtool = "Line Tool";
            gettoolsettings(pnllinetoolsettings);
            txtlinewidth.Text = linewidth.ToString();
        }

        // ERROR: Handles clauses are not supported in C#
        private void txtlinewidth_TextChanged(object sender, EventArgs e)
        {
            if (txtlinewidth.Text == "")
            {
            }
            else {
                linewidth = (Convert.ToInt32(txtlinewidth.Text));
            }
            setuppreview();
        }

        #endregion

        #region Text

        // ERROR: Handles clauses are not supported in C#
        private void btntexttool_Click(object sender, EventArgs e)
        {
            selectedtool = "Text Tool";
            gettoolsettings(pnltexttoolsettings);
        }

        // ERROR: Handles clauses are not supported in C#
        private void txtdrawtextsize_TextChanged(object sender, EventArgs e)
        {
            if (txtdrawtextsize.Text == "")
            {
            }
            else {
                drawtextsize = Convert.ToInt32(txtdrawtextsize.Text);
            }
            setuppreview();
        }

        // ERROR: Handles clauses are not supported in C#
        private void combodrawtextfont_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawtextfontname = combodrawtextfont.Text;
            txtdrawstringtext.Focus();
            setuppreview();
        }

        // ERROR: Handles clauses are not supported in C#
        private void combofontstyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (combofontstyle.Text)
            {
                case "Bold":
                    drawtextfontstyle = FontStyle.Bold;
                    break;
                case "Italic":
                    drawtextfontstyle = FontStyle.Italic;
                    break;
                case "Regular":
                    drawtextfontstyle = FontStyle.Regular;
                    break;
                case "Strikeout":
                    drawtextfontstyle = FontStyle.Strikeout;
                    break;
                case "Underline":
                    drawtextfontstyle = FontStyle.Underline;
                    break;
            }
            txtdrawstringtext.Focus();
            setuppreview();
        }
        #endregion

        #region Paintbrush

        // ERROR: Handles clauses are not supported in C#
        private void txtpaintbrushsize_TextChanged(object sender, EventArgs e)
        {
            if (txtpaintbrushsize.Text == "")
            {
            }
            else {
                paintbrushwidth = (Convert.ToInt32(txtpaintbrushsize.Text));
            }
            setuppreview();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnpaintsquareshape_Click(object sender, EventArgs e)
        {
            paintbrushtype = "square";
            btnpaintcircleshape.BackgroundImage = Properties.Resources.ArtPadcirclerubber;
            btnpaintsquareshape.BackgroundImage = Properties.Resources.ArtPadsquarerubberselected;
            setuppreview();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnpaintcircleshape_Click(object sender, EventArgs e)
        {
            paintbrushtype = "circle";
            btnpaintcircleshape.BackgroundImage = Properties.Resources.ArtPadcirclerubberselected;
            btnpaintsquareshape.BackgroundImage = Properties.Resources.ArtPadsquarerubber;
            setuppreview();
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnpaintbrush_Click(object sender, EventArgs e)
        {
            selectedtool = "Paint Brush";
            gettoolsettings(pnlpaintbrushtoolsettings);
            txtpaintbrushsize.Text = paintbrushwidth.ToString();
            setuppreview();
        }

        #endregion

        #region Codepoints

        private void preparecooldown()
        {
            needtosave = true;
            if (codepointscooldown == true)
            {
            }
            else {
                codepointsearned = codepointsearned + 1;
                codepointscooldown = true;
                tmrcodepointcooldown.Start();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void tmrcodepointcooldown_Tick(object sender, EventArgs e)
        {
            codepointscooldown = false;
            tmrcodepointcooldown.Stop();
        }

        // ERROR: Handles clauses are not supported in C#
        private void tmrshowearnedcodepoints_Tick(object sender, EventArgs e)
        {
            tmrshowearnedcodepoints.Stop();
        }

        #endregion

        #region More UI stuff

        public void determinevisiblepallets()
        {
            int panelstoadd = 2;
            
            if (API.Upgrades["artpad4colorpallets"] == true)
            {
                panelstoadd = 4;
            }
            if (API.Upgrades["artpad8colorpallets"] == true)
            {
                panelstoadd = 8;
            }
            if (API.Upgrades["artpad16colorpallets"] == true)
            {
                panelstoadd = 16;
            }
            if (API.Upgrades["artpad32colorpallets"] == true)
            {
                panelstoadd = 32;
            }
            if (API.Upgrades["artpad64colorpallets"] == true)
            {
                panelstoadd = 64;
            }
            if (API.Upgrades["artpad128colorpallets"] == true)
            {
                panelstoadd = 128;
            }
            flowcolours.Controls.Clear();
            for(int i = 0; i < panelstoadd; i++)
            {
                Panel pnl = new Panel();
                pnl.BackColor = Color.Black;
                pnl.Size = new Size(12, 8);
                flowcolours.Controls.Add(pnl);
                pnl.Margin = new Padding(1, 0, 0, 1);
                pnl.MouseClick += new MouseEventHandler(this.colourpallet1_MouseClick);
                pnl.Show();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnchangesizecancel_Click(object sender, EventArgs e)
        {
            pnlpalletsize.Hide();
        }

        #endregion

        #region More Text Stuff

        // ERROR: Handles clauses are not supported in C#
        private void txtdrawstringtext_TextChanged(object sender, EventArgs e)
        {
            setuppreview();
        }

        #endregion

        private void tmrsetupui_Tick(object sender, EventArgs e)
        {
            if(API.CurrentSkin != null)
            {
                pnldrawingbackground.BackColor = API.CurrentSkin.titlebarcolour;
            }
        }

        private void btnpixelplacer_Click(object sender, EventArgs e)
        {
            selectedtool = "Pixel Placer";
            gettoolsettings(pnlpixelplacersettings);
        }
    }
}
