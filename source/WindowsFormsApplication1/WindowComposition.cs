using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public class WindowComposition
    {
        private static bool _CanClose = true;
        public static bool ShuttingDown = false;
        public static bool SafeToAddControls = true;

        public static bool CanClose
        {
            get
            {
                return _CanClose;
            }
        }

        public static void WindowsEverywhere(Form formToInfect)
        {
            var t = new Timer();
            t.Interval = 100;
            int yvel = 1;
            int xvel = 1;
            t.Tick += (object s, EventArgs a) =>
            {
                if (Viruses.InfectedWith("windowseverywhere"))
                {
                    formToInfect.Left += xvel * 10;
                    formToInfect.Top += yvel * 10;

                    if (formToInfect.Top >= API.CurrentSession.Height - formToInfect.Height)
                    {
                        yvel = -1;
                    }
                    if (formToInfect.Top <= 0)
                    {
                        yvel = 1;
                    }
                    if (formToInfect.Left >= API.CurrentSession.Width - formToInfect.Width)
                    {
                        xvel = -1;
                    }
                    if (formToInfect.Left <= 0)
                    {
                        xvel = 1;
                    }
                }
            };
            t.Start();
        }

        public static void ScaleWidget(Control ctrl, int width, int height)
        {
            ctrl.Size = new Size(0, 0);
            var t = new Timer();
            t.Interval = 25;
            t.Tick += (object s, EventArgs a) =>
            {
                if(ctrl.Width <= width)
                {
                    
                }
            };
        }

        public static void ShowForm(Form formToShow, WindowAnimationStyle style)
        {
            var t = new Timer();
            switch(style)
            {
                case WindowAnimationStyle.Fade:
                    var bw = new BackgroundWorker();
                    bw.DoWork += (object se, DoWorkEventArgs ea) =>
                    {
                        //The form's handle has not been created so we just invoke
                        //the action on the desktop thread.
                        API.CurrentSession.Invoke(new Action(() =>
                        {
                            try {
                                formToShow.Opacity = 0;
                                formToShow.Show();
                                formToShow.Left = (Screen.PrimaryScreen.Bounds.Width - formToShow.Width) / 2;
                                formToShow.Top = (Screen.PrimaryScreen.Bounds.Height - formToShow.Height) / 2;
                            }
                            catch
                            {

                            }
                        }));
                        t.Interval = API.CurrentSkin.WindowFadeTime;
                        t.Tick += (object s, EventArgs a) =>
                        {
                            if (API.Upgrades["fancyeffects"] == true)
                            {
                                API.CurrentSession.Invoke(new Action(() =>
                                {

                                    if (formToShow.Opacity < 1)
                                    {
                                        formToShow.Opacity += Convert.ToDouble(API.CurrentSkin.WindowFadeSpeed);
                                        formToShow.Refresh();

                                    }
                                    else
                                    {
                                        t.Stop();
                                    }
                                }));
                            }
                            else
                            {
                                API.CurrentSession.Invoke(new Action(() =>
                                {
                                    formToShow.Opacity = 1;
                                }));
                            }
                        };
                        API.CurrentSession.Invoke(new Action(() =>
                        {
                            t.Start();
                        }));
                    };
                    bw.RunWorkerAsync();
                    break;
                default:
                    var bwork = new BackgroundWorker();
                    bwork.DoWork += (object s, DoWorkEventArgs a) =>
                    {
                        API.CurrentSession.Invoke(new Action(() =>
                        {
                            formToShow.Show();
                            formToShow.Left = (Screen.PrimaryScreen.Bounds.Width - formToShow.Width) / 2;
                            formToShow.Top = (Screen.PrimaryScreen.Bounds.Height - formToShow.Height) / 2;

                            formToShow.Show();
                        }));

                    };
                    bwork.RunWorkerAsync();
                    break;
                    
            }
        }

        public static void CloseForm(Form formToClose, PanelButton pbtn, WindowAnimationStyle style)
        {
            var t = new Timer();
            switch(style)
            {
                case WindowAnimationStyle.Fade:
                    _CanClose = false;
                    t.Interval = API.CurrentSkin.WindowFadeTime;
                    t.Tick += (object s, EventArgs a) =>
                    {
                        if (API.Upgrades["fancyeffects"] == true)
                        {
                            try
                            {

                                if (formToClose.Opacity > 0)
                                {
                                    formToClose.Invoke(new Action(() =>
                                    {
                                        formToClose.Opacity -= Convert.ToDouble(API.CurrentSkin.WindowFadeSpeed);
                                        formToClose.Refresh();
                                    }));
                                }
                                else
                                {
                                    API.PanelButtons.Remove(pbtn);
                                    API.CurrentSession.SetupPanelButtons();
                                    API.UpdateWindows();
                                    formToClose.Dispose();
                                    t.Stop();
                                }
                            }
                            catch (Exception ex)
                            {
                                formToClose = null;
                            }
                        }
                        else
                        {
                            API.PanelButtons.Remove(pbtn);
                            API.CurrentSession.SetupPanelButtons();
                            API.UpdateWindows();
                            formToClose.Dispose();
                            t.Stop();

                        }
                    };
                    t.Start();
                    break;
                case WindowAnimationStyle.Zoom:
                    _CanClose = false;
                    t.Interval = 1;
                    int w = formToClose.Width;
                    int h = formToClose.Height;
                    int maxw = w / 2;
                    int maxh = h / 2;
                    t.Tick += (object s, EventArgs a) =>
                    {
                        if (API.Upgrades["fancyeffects"] == true)
                        {
                            formToClose.MinimumSize = new Size(maxw, maxh);
                            formToClose.Opacity -= 0.1;
                            formToClose.Left += 50;
                            formToClose.Top += 50;

                            formToClose.Width -= 50;
                            formToClose.Height -= 50;
                            if (formToClose.Size == formToClose.MinimumSize)
                            {
                                API.PanelButtons.Remove(pbtn);
                                API.CurrentSession.SetupPanelButtons();
                                API.UpdateWindows();
                                formToClose.Dispose();
                                t.Stop();
                            }
                        }
                        else
                        {
                            API.PanelButtons.Remove(pbtn);
                            API.CurrentSession.SetupPanelButtons();
                            API.UpdateWindows();
                            formToClose.Dispose();
                            t.Stop();

                        }
                    };
                    t.Start();
                    break;
                    break;
                case WindowAnimationStyle.ToAppLauncher:
                    _CanClose = false;
                    t.Interval = 1;
                    int w2 = formToClose.Width;
                    int h2 = formToClose.Height;
                    int maxw2 = w2 / 2;
                    int maxh2 = h2 / 2;
                    t.Tick += (object s, EventArgs a) =>
                    {
                        formToClose.MinimumSize = new Size(maxw2, maxh2);
                        formToClose.Opacity -= 0.1;
                        if (API.Upgrades["fancyeffects"] == true)
                        {
                            switch (API.CurrentSkin.desktoppanelposition)
                            {
                                case "Bottom":
                                    formToClose.Left += 50;
                                    formToClose.Top += 50;
                                    break;
                                case "Top":
                                    formToClose.Left -= 50;
                                    formToClose.Top -= 50;
                                    break;

                            }

                            formToClose.Width -= 50;
                            formToClose.Height -= 50;
                            if (formToClose.Size == formToClose.MinimumSize)
                            {
                                API.PanelButtons.Remove(pbtn);
                                API.CurrentSession.SetupPanelButtons();
                                API.UpdateWindows();
                                formToClose.Dispose();
                                t.Stop();
                            }
                        }
                        else
                        {
                            API.PanelButtons.Remove(pbtn);
                            API.CurrentSession.SetupPanelButtons();
                            API.UpdateWindows();
                            formToClose.Dispose();
                            t.Stop();

                        }
                    };
                    t.Start();
                    break;
                default:
                    API.PanelButtons.Remove(pbtn);
                    API.CurrentSession.SetupPanelButtons();
                    API.UpdateWindows();
                    formToClose.Dispose();
                    //Room for more animations, but just close the form if none is selected.
                    break;
            }
        }

        public static void AnimateDragWindow(Form form, WindowDragEffect effect, bool Dragging)
        {
            var t = new Timer();
            switch(effect)
            {
                case WindowDragEffect.Fade:
                    t.Interval = API.CurrentSkin.DragFadeInterval;
                    t.Tick += (object s, EventArgs a) =>
                    {
                        if (API.Upgrades["fancyeffects"] == true)
                        {
                            if (Dragging == true)
                            {
                                if (form.Opacity >= API.CurrentSkin.DragFadeLevel)
                                {
                                    form.Opacity -= API.CurrentSkin.DragFadeSpeed;
                                }
                                else
                                {
                                    t.Stop();
                                }
                            }
                            else
                            {
                                if (form.Opacity < 1)
                                {
                                    form.Opacity += API.CurrentSkin.DragFadeSpeed;
                                }
                                else
                                {
                                    t.Stop();
                                }
                            }
                        }
                    };
                    t.Start();
                    break;
                
            }
        }

        public static void AnimateDragWindow(Form form, WindowDragEffect effect, bool Dragging, int MouseX, int MouseY)
        {
            var t = new Timer();
            switch(effect)
            {
            
                case WindowDragEffect.Shake:
                    var rnd = new Random();
                    int xOffset = 0;
                    int yOffset = 0;

                    xOffset = rnd.Next(API.CurrentSkin.ShakeMinOffset, API.CurrentSkin.ShakeMaxOffset);
                    yOffset = rnd.Next(API.CurrentSkin.ShakeMinOffset, API.CurrentSkin.ShakeMaxOffset);
                    int leftright = rnd.Next(0, 1);
                    if (API.Upgrades["fancyeffects"] == true)
                    {
                        form.Left += MouseX * xOffset;
                        form.Top += MouseY * yOffset;
                    }
                    else
                    {
                        form.Left += MouseX;
                        form.Top += MouseY;
                    }
                   
                    break;
            }
        }
    }

    public enum WindowAnimationStyle
    {
        Fade,
        Default,
        Zoom,
        ToAppLauncher
    }

    public enum WindowDragEffect
    {
        Fade,
        Default,
        Shake
    }
}
