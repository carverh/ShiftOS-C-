/* Cosmos XplatUI driver
 * 
 * Author: Michael VanOverbeek
 * Based off: XplatUIWin32 driver (ShiftUI\Internal\XplatUIWin32.cs), copyright info can be found there.
 * 
 * Cosmos is a C# open source managed operating system, capable of basic graphics using either
 * VGA or VESA BIOS Extensions, it can do full console IO, has a working FAT driver, and is
 * written entirely in C# and their homebrewed high-level assembly language, X#.
 * 
 * ShiftUI cannot access Cosmos APIs directly, so to compensate, the CosmosInterface
 * class exists. This is an interface between ShiftUI and Cosmos, and it is used
 * to tell the operating system where to draw pixels, what colors to use, and when
 * something happens, like a window opening or closing, or an error occurring.
 * 
 * This makes it so that ShiftUI doesn't care what graphics driver you use, as long as it
 * supports 32bit RGB and you are capable of converting RGB values thrown by ShiftUI
 * to the values that your graphics driver wants.
 * 
 * This also means that your OS can deal with actually drawing windows, much like how
 * Win32 and X11 does it. It's sort of a "you be the puppet, ShiftUI'll pull the strings"
 * situation.
 * 
 * The Cosmos driver is UNFINISHED, and many Win32 code remains. So, if you can continue
 * on, or you want to use Cosmos features when I'm done, simply uncomment this:
 */

 //#define COSMOS

 /*
  * and the C# compiler and Visual Studio will compile all of the Cosmos stuff.
  * 
  * If you're planning on using ShiftUI for a Windows application or even Linux/Mac,
  * DO NOT UNCOMMENT THAT #DEFINE. YOU WILL BREAK LOTS OF THINGS. There is a lot of
  * platform-dependent stuff in Mono Winforms which is what ShiftUI is HEAVILY based
  * off of, for example, when the app starts, it detects if you're on Windows, Mac or
  * Linux, so that it knows whether to use Win32, X11, or Carbon. Cosmos can't really
  * determine what OS it's running on because it IS an OS, so the COSMOS #define is
  * used to bypass the platform-dependent stuff and make ShiftUI work specifically on
  * Cosmos.
  * 
  * Michael VanOverbeek out. 
  */

#if COSMOS
using ShiftUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShiftUI.Internal
{
    public struct CosmosScreen
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public CosmosGfxDriver Driver { get; set; }
    }

    public enum CosmosGfxDriver
    {
        VGA,
        VESA,
        VMware,
        Dummy
    }

    public enum CosmosWindowState
    {
        Maximized,
        Minimized,
        Normal,
    }

    public enum CosmosWindowHint
    {
        MESSAGEBOX,
        TOPLEVEL,
        DEFAULT,
        BORDERLESS,
        DESKTOP,
        TOOL,
    }

    public class CosmosWindow
    {
        public IntPtr Handle { get; set; }
        public Hwnd Hwnd { get; set; }
        public string Title { get; set; }
        public CosmosWindowState WindowState { get; set; }
        public CosmosWindowHint Style { get; set; }
    }

    /// <summary>
    /// Because Cosmos cannot do dynamic loading and therefore
    /// can't do P/Invokes, I'll let the operating system developer
    /// use this interface as a backbone for letting XplatUI actually
    /// interact with their operating system.
    /// 
    /// ShiftOS won't use this, however Memphis will, and it's entire window manager
    /// will reside in a class deriving from this class.
    /// </summary>
    public abstract class CosmosInterface
    {
        public abstract void SetPixel(int x, int y, Color col);
        public abstract Color GetPixel(int x, int y);
        public abstract CosmosScreen GetScreenInfo();
        public abstract int MouseX { get; }
        public abstract int MouseY { get; }
        public abstract bool MouseWheelPressed { get; }
        internal List<CosmosWindow> Windows = null;
        public abstract void Redraw();



        public bool IsWindow(IntPtr handle)
        {
            if(Windows == null)
            {
                Windows = new List<Hwnd>();
                return false;
            }
            foreach(var win in Windows)
            {
                if (win.Handle == handle)
                    return true;
            }
            return false;
        }
        
        /// <summary>
        /// Clears the screen with a specified color.
        /// </summary>
        /// <param name="c">The color to clear to.</param>
        public void Clear(Color c) {
            var scr = GetScreenInfo();
            int w = scr.Width;
            int h = scr.Height;
            DrawRectangle(c, new Rectangle(0, 0, w, h));
        }

        /// <summary>
        /// Draws a rectangle with the specified Rectangle and color.
        /// </summary>
        /// <param name="c">The color to use. (Note that depending on the graphics config of the current OS, color quality may be reduced.</param>
        /// <param name="rect">The Rectangle struct containing the X and Y coordinates and the width and height.</param>
        public void DrawRectangle(Color c, Rectangle rect)
        {
            int x = rect.X;
            int y = rect.Y;
            int max_width = rect.Width;
            int max_height = rect.Height;
            for(int i = x; i < max_width; i++)
            {
                for(int i2 = y; i2 < max_height; i2++)
                {
                    if (GetPixel(i, i2) != c)
                        SetPixel(i, i2, c);
                }
            }
        }

        /// <summary>
        /// Draws an unfilled rectangle using the specified Rectangle, line width and color.
        /// </summary>
        public void DrawUnfilledRectangle(Rectangle rect, int width, Color c)
        {
            //top & bottom border
            for(int x = rect.X; x < rect.Width; x++)
            {
                //top
                for(int y = rect.Y; y < rect.Y + width; y++)
                {
                    if (GetPixel(x, y) != c)
                        SetPixel(x, y, c);
                }

                //bottom
                for(int y = rect.Height - width; y < rect.Height; y++)
                {
                    if (GetPixel(x, y) != c)
                        SetPixel(x, y, c);
                }
            }

            //In theory that code should work for left & right.
            for (int y = rect.Y; y < rect.Height; y++)
            {
                //left
                for (int x = rect.X; x < rect.X + width; x++)
                {
                    if (GetPixel(x, y) != c)
                        SetPixel(x, y, c);
                }

                //right
                for (int x = rect.Width - width; x < rect.Width; x++)
                {
                    if (GetPixel(x, y) != c)
                        SetPixel(x, y, c);
                }
            }

        }
    }

    public class DefaultCosmosInterface : CosmosInterface
    {
        public const string SUI_ERR_NODRIVER = "[ShiftUI] You cannot use ShiftUI yet. You still need to load in a proper CosmosInterface.";

        public override bool MouseWheelPressed
        {
            get
            {
                Console.WriteLine(SUI_ERR_NODRIVER);
            }
        }

        public override int MouseX
        {
            get
            {
                Console.WriteLine(SUI_ERR_NODRIVER);
            }
        }

        public override int MouseY
        {
            get
            {
                Console.WriteLine(SUI_ERR_NODRIVER);
            }
        }

        public override Color GetPixel(int x, int y)
        {
            Console.WriteLine(SUI_ERR_NODRIVER);
            return Color.Empty;
        }

        public override CosmosScreen GetScreenInfo()
        {
            Console.WriteLine(SUI_ERR_NODRIVER);
            var s = new CosmosScreen();
            s.Driver = CosmosGfxDriver.Dummy;
            s.Width = 0;
            s.Height = 0;
            return s;
        }

        public override void Redraw()
        {
            Console.WriteLine(SUI_ERR_NODRIVER);
        }

        public override void SetPixel(int x, int y, Color col)
        {
            Console.WriteLine(SUI_ERR_NODRIVER);
        }
    }

    internal class XplatUICosmos : XplatUIDriver
    {
#region Local Variables
        private CosmosInterface cosmos = new DefaultCosmosInterface();
        private static XplatUICosmos instance;
        private static int ref_count;
        private static IntPtr FosterParentLast;

        internal static MouseButtons mouse_state;
        internal static Point mouse_position;
        internal static bool grab_confined;
        internal static IntPtr grab_hwnd;
        internal static Rectangle grab_area;
        internal static WndProc wnd_proc;
        internal static IntPtr prev_mouse_hwnd;
        internal static bool caret_visible;

        internal static bool themes_enabled;
        private Hashtable timer_list;
        private static Queue message_queue;
        private static IntPtr clip_magic = new IntPtr(27051977);
        private static int scroll_width;
        private static int scroll_height;
        private static Hashtable wm_nc_registered;
        private static Rectangle clipped_cursor_rect;
        private Hashtable registered_classes;
        private Hwnd HwndCreating; // the Hwnd we are currently creating (see CreateWindow)

#endregion    // Local Variables

#region Constructor & Destructor
        private XplatUICosmos()
        {
            // Handle singleton stuff first
            ref_count = 0;

            mouse_state = MouseButtons.None;
            mouse_position = Point.Empty;

            grab_confined = false;
            grab_area = Rectangle.Empty;

            message_queue = new List<CosmosMessage>();

            themes_enabled = true;

            FosterParentLast = IntPtr.Zero;

            scroll_height = 25;
            scroll_width = 25;

            timer_list = new Hashtable();
            registered_classes = new Hashtable();
        }
#endregion // Constructor & Destructor

#region Private Support Methods

        private IntPtr GetFosterParent()
        {
            if (!cosmos.IsWindow(FosterParentLast))
            {
                FosterParentLast = cosmos.CreateWindow("Foster Parent", BorderStyle.None, 0, 0, 0, 0, IntPtr.Zero);

                if (FosterParentLast == IntPtr.Zero)
                {
                    MessageBox.Show("Could not create foster window, system error \"" + cosmos.GetLastError().ToString() = "\".", "Fatal error.");
                }
            }
            return FosterParentLast;
        }

#region Static Properties
        internal override int ActiveWindowTrackingDelay
        {
            get { return 0; }
        }

        internal override int CaretWidth
        {
            get
            {
                return Application.CurrentSkin.CaretWidth;
            }
        }

        internal override int FontSmoothingContrast
        {
            get
            {
                return 0;
            }
        }

        internal override int FontSmoothingType
        {
            get
            {
                return 0;
            }
        }

        internal override int HorizontalResizeBorderThickness
        {
            get { return 5; }
        }

        internal override bool IsActiveWindowTrackingEnabled
        {
            get { return false; }
        }

        internal override bool IsComboBoxAnimationEnabled
        {
            get { return false; }
        }

        internal override bool IsDropShadowEnabled
        {
            get
            {
                return false;
            }
        }

        internal override bool IsFontSmoothingEnabled
        {
            get { return false; }
        }

        internal override bool IsHotTrackingEnabled
        {
            get { return true; }
        }

        internal override bool IsIconTitleWrappingEnabled
        {
            get { return true; }
        }

        internal override bool IsKeyboardPreferred
        {
            get { return false; }
        }

        internal override bool IsListBoxSmoothScrollingEnabled
        {
            get { return false; }
        }

        internal override bool IsMenuAnimationEnabled
        {
            get { return false; }
        }

        internal override bool IsMenuFadeEnabled
        {
            get { return false; }
        }

        internal override bool IsMinimizeRestoreAnimationEnabled
        {
            get
            {
                return false;
            }
        }

        internal override bool IsSelectionFadeEnabled
        {
            get { return false; }
        }

        internal override bool IsSnapToDefaultEnabled
        {
            get { return false; }
        }

        internal override bool IsTitleBarGradientEnabled
        {
            get { return false; }
        }

        internal override bool IsToolTipAnimationEnabled
        {
            get { return false; }
        }

        internal override Size MenuBarButtonSize
        {
            get
            {
                return new Size(32, 32);
            }
        }

        public override Size MenuButtonSize
        {
            get
            {
                return new Size(32, 32);
            }
        }

        internal override int MenuShowDelay
        {
            get { return 0; }
        }

        internal override int MouseSpeed
        {
            get { return Application.CurrentSkin.MouseSpeed; }
        }

        internal override LeftRightAlignment PopupMenuAlignment
        {
            get { return LeftRightAlignment.Left; }
        }

        internal override PowerStatus PowerStatus
        {
            get
            {
                //Cosmos doesn't have power management. Sadly.
                return new PowerStatus(BatteryChargeStatus.Unknown, "No power status for you.".Length, 0.0, 0, PowerLineStatus.Unknown);
            }
        }

        internal override int SizingBorderWidth
        {
            get { return Application.CurrentSkin.SizeBorderWidth; }
        }

        internal override Size SmallCaptionButtonSize
        {
            get
            {
                return new Size(32, 32);
            }
        }

        internal override bool UIEffectsEnabled
        {
            get { return false; }
        }

        internal override int VerticalResizeBorderThickness
        {
            get { return 5; }
        }

        internal override void RaiseIdle(EventArgs e)
        {
            if (Idle != null)
                Idle(this, e);
        }

        internal override Keys ModifierKeys
        {
            get
            {
                short state;
                Keys key_state;

                key_state = Keys.None;
                
                return key_state;
            }
        }

        internal override MouseButtons MouseButtons
        {
            get
            {
                return cosmos.MouseState;
            }
        }

        internal override Point MousePosition
        {
            get
            {
                return new Point(cosmos.MouseX, cosmos.MouseY);
            }
        }

        internal override Size MouseHoverSize
        {
            get
            {
                int width = 4;
                int height = 4;
                return new Size(width, height);
            }
        }

        internal override int MouseHoverTime
        {
            get
            {
                int time = 500;
                return time;
            }
        }

        internal override int MouseWheelScrollDelta
        {
            get
            {
                int delta = 120;
                return delta;
            }
        }

        internal override int HorizontalScrollBarHeight
        {
            get
            {
                return scroll_height;
            }
        }

        internal override bool UserClipWontExposeParent
        {
            get
            {
                return false;
            }
        }


        internal override int VerticalScrollBarWidth
        {
            get
            {
                return scroll_width;
            }
        }

        internal override int MenuHeight
        {
            get
            {
                return 32;
            }
        }

        internal override Size Border3DSize
        {
            get
            {
                return new Size(2, 2);
            }
        }

        internal override Size BorderSize
        {
            get
            {
                return new Size(2, 2);
            }
        }

        internal override bool DropTarget
        {
            get
            {
                return false;
            }

            set
            {
                if (value)
                {
                    //throw new NotImplementedException("Need to figure out D'n'D for Win32");
                }
            }
        }

        internal override Size CaptionButtonSize
        {
            get
            {
                return new Size(64, 32);
            }
        }

        internal override int CaptionHeight
        {
            get
            {
                return 35;
            }
        }

        internal override Size CursorSize
        {
            get
            {
                return new Size(32, 32);
            }
        }

        internal override bool DragFullWindows
        {
            get
            {
                return false;
            }
        }

        internal override Size DragSize
        {
            get
            {
                return new Size(32, 32);
            }
        }

        internal override Size DoubleClickSize
        {
            get
            {
                return new Size(36, 36); //thanks to @InternetUnexploder from the Cosmos Gitter chat, I know the raw value I need to put here :P
            }
        }

        internal override int DoubleClickTime
        {
            get
            {
                return 1000;
            }
        }

        internal override Size FixedFrameBorderSize
        {
            get
            {
                return new Size(2, 2);
            }
        }

        internal override Size FrameBorderSize
        {
            get
            {
                return new Size(4, 4);
            }
        }

        internal override Size IconSize
        {
            get
            {
                return new Size(16, 16);
            }
        }

        internal override Size MaxWindowTrackSize
        {
            get
            {
                return new Size(59, 60);
            }
        }

        internal override bool MenuAccessKeysUnderlined
        {
            get
            {
                return false;
            }
        }

        internal override Size MinimizedWindowSize
        {
            get
            {
                return new Size(0, 0);
            }
        }

        internal override Size MinimizedWindowSpacingSize
        {
            get
            {
                return new Size(0, 0);
            }
        }

        internal override Size MinimumWindowSize
        {
            get
            {
                return new Size(50, 50);
            }
        }

        internal override Size MinWindowTrackSize
        {
            get
            {
                return new Size(50, 50);
            }
        }

        internal override Size SmallIconSize
        {
            get
            {
                return new Size(8, 8);
            }
        }

        internal override int MouseButtonCount
        {
            get
            {
                return 3;
            }
        }

        internal override bool MouseButtonsSwapped
        {
            get
            {
                return false;
            }
        }

        internal override bool MouseWheelPresent
        {
            get
            {
                return cosmos.MouseWheelPressed;
            }
        }

        internal override Rectangle VirtualScreen
        {
            get
            {
                var s = cosmos.GetScreenInfo();
                return new Rectangle(s.X, s.Y, s.Width, s.Height);
            }
        }

        internal override Rectangle WorkingArea
        {
            get
            {
                return VirtualScreen;
            }
        }

        [MonoTODO]
        internal override Screen[] AllScreens
        {
            get
            {
                // Can't use this sadly.
                return null;
            }
        }

        internal override bool ThemesEnabled
        {
            get
            {
                return true;
            }
        }

        internal override bool RequiresPositiveClientAreaSize
        {
            get
            {
                return false;
            }
        }

        public override int ToolWindowCaptionHeight
        {
            get
            {
                return 35; //Drawing will be done entirely by the developer itself. Do we really care about the tool window size?
            }
        }

        public override Size ToolWindowCaptionButtonSize
        {
            get
            {
                return new Size(32, 32);
            }
        }
#endregion // Static Properties

#region Singleton Specific Code
        public static XplatUICosmos GetInstance()
        {
            if (instance == null)
            {
                instance = new XplatUICosmos();
            }
            ref_count++;
            return instance;
        }

        public int Reference
        {
            get
            {
                return ref_count;
            }
        }
#endregion

#region Public Static Methods
        internal override IntPtr InitializeDriver()
        {
            cosmos.OnInit();
            return IntPtr.Zero;
        }

        internal override void ShutdownDriver(IntPtr token)
        {
            Console.WriteLine("[ShiftUI] Stopping Cosmos driver...");
            cosmos.OnShutdown();
        }


        internal void Version()
        {
            Console.WriteLine($"ShiftUI version {Application.ShiftUIVersionString}, running in the cosmos, on {cosmos.OSName} version {cosmos.OSVersionString}.");
        }

        string GetSoundAlias(AlertType alert)
        {
            return "";
        }

        internal override void AudibleAlert(AlertType alert)
        {
            //Cosmos cannot do audio.
        }

        internal override void BeginMoveResize(IntPtr handle)
        {
            //If the Mono devs that worked on the Win32 driver didn't know what this did, what
            //makes you think I will?
        }

        internal override void GetDisplaySize(out Size size)
        {
            //get screen metrics from OS
            var screen = cosmos.GetScreenInfo();
            //push the data out.
            size = new Size(screen.Width, screen.Height);
        }

        internal override void EnableThemes()
        {
            //Themes will forever be enabled.
        }

        //[MichaelComment(Message = "Yay. I just LOVE messing with Win32 stuff and porting it to Cosmos.")]
        internal override IntPtr CreateWindow(CreateParams cp)
        {
            //I think I'll let this do it's thing it's own way but just change where the new Hwnd gets placed.
            if (cosmos.Windows == null)
                cosmos.Windows = new List<Hwnd>();
            IntPtr WindowHandle;
            IntPtr ParentHandle;
            Hwnd hwnd;

            hwnd = new Hwnd();

            ParentHandle = cp.Parent;

            if ((ParentHandle == IntPtr.Zero) && (cp.Style & (int)(WindowStyles.WS_CHILD)) != 0)
            {
                // We need to use our foster parent window until this poor child gets it's parent assigned
                ParentHandle = GetFosterParent();
            }

            if (((cp.Style & (int)(WindowStyles.WS_CHILD | WindowStyles.WS_POPUP)) == 0) && ((cp.ExStyle & (int)WindowExStyles.WS_EX_APPWINDOW) == 0))
            {
                // If we want to be hidden from the taskbar we need to be 'owned' by 
                // something not on the taskbar. FosterParent is just that
                ParentHandle = GetFosterParent();
            }

            Point location;
            if (cp.HasWindowManager)
            {
                location = Hwnd.GetNextStackedFormLocation(cp, Hwnd.ObjectFromHandle(cp.Parent));
            }
            else
            {
                location = new Point(cp.X, cp.Y);
            }

            string class_name = RegisterWindowClass(cp.ClassStyle);
            HwndCreating = hwnd;

            // We cannot actually send the WS_EX_MDICHILD flag to Windows because we
            // are faking MDI, not uses Windows' version.
            if ((cp.WindowExStyle & WindowExStyles.WS_EX_MDICHILD) == WindowExStyles.WS_EX_MDICHILD)
                cp.WindowExStyle ^= WindowExStyles.WS_EX_MDICHILD;

            WindowHandle = cosmos.Windows.Count + 1;

            HwndCreating = null;

            if (WindowHandle == IntPtr.Zero)
            {
                MessageBox.Show("An error happened while showing a window... Fascinating.", "Fatal error.");
            }

            hwnd.ClientWindow = WindowHandle;
            hwnd.Mapped = true;
            cosmos.Windows.Add(hwnd);
            
            return WindowHandle;
        }

        internal override IntPtr CreateWindow(IntPtr Parent, int X, int Y, int Width, int Height)
        {
            CreateParams create_params = new CreateParams();

            create_params.Caption = "";
            create_params.X = X;
            create_params.Y = Y;
            create_params.Width = Width;
            create_params.Height = Height;

            create_params.ClassName = XplatUI.GetDefaultClassName(GetType());
            create_params.ClassStyle = 0;
            create_params.ExStyle = 0;
            create_params.Parent = IntPtr.Zero;
            create_params.Param = 0;

            return CreateWindow(create_params);
        }

        internal override void DestroyWindow(IntPtr handle)
        {
            Hwnd hwnd;

            foreach(var win in cosmos.Windows)
            {
                if (win.Handle == handle)
                    hwnd = win;
            }
            if (hwnd == null)
                MessageBox.Show("An error occurred while destroying a window.", "Fatal error.");
            cosmos.Windows.Remove(hwnd);
            cosmos.OnDestroyWindow(hwnd); //tell the OS to redraw that area...
            hwnd.Dispose();
            return;
        }

        internal override void SetWindowMinMax(IntPtr handle, Rectangle maximized, Size min, Size max)
        {
            // We do nothing, Form has to handle WM_GETMINMAXINFO
        }


        internal override FormWindowState GetWindowState(IntPtr handle)
        {
            CosmosWindowStyle style;

            style = cosmos.GetWindowState(handle);
            switch(style)
            {
                case CosmosWindowStyle.Maximized:
                    return FormWindowState.Maximized;
                case CosmosWindowStyle.Minimized:
                    return FormWindowState.Minimized;
            }
            return FormWindowState.Normal;
        }

        internal override void SetWindowState(IntPtr hwnd, FormWindowState state)
        {
            switch (state)
            {
                case FormWindowState.Normal:
                    {
                        Win32ShowWindow(hwnd, WindowPlacementFlags.SW_RESTORE);
                        return;
                    }

                case FormWindowState.Minimized:
                    {
                        Win32ShowWindow(hwnd, WindowPlacementFlags.SW_MINIMIZE);
                        return;
                    }

                case FormWindowState.Maximized:
                    {
                        Win32ShowWindow(hwnd, WindowPlacementFlags.SW_MAXIMIZE);
                        return;
                    }
            }
        }

        internal override void SetWindowStyle(IntPtr handle, CreateParams cp)
        {

            Win32SetWindowLong(handle, WindowLong.GWL_STYLE, (uint)cp.Style);
            Win32SetWindowLong(handle, WindowLong.GWL_EXSTYLE, (uint)cp.ExStyle);

            // From MSDN:
            // Certain window data is cached, so changes you make using SetWindowLong
            // will not take effect until you call the SetWindowPos function. Specifically, 
            // if you change any of the frame styles, you must call SetWindowPos with
            // the SWP_FRAMECHANGED flag for the cache to be updated properly.
            if (cp.control is Form)
                XplatUI.RequestNCRecalc(handle);
        }

        internal override double GetWindowTransparency(IntPtr handle)
        {
            LayeredWindowAttributes lwa;
            COLORREF clrRef;
            byte alpha;

            if (0 == Win32GetLayeredWindowAttributes(handle, out clrRef, out alpha, out lwa))
                return 1.0;

            return ((double)alpha) / 255.0;
        }

        internal override void SetWindowTransparency(IntPtr handle, double transparency, Color key)
        {
            LayeredWindowAttributes lwa = LayeredWindowAttributes.LWA_ALPHA;
            byte opacity = (byte)(transparency * 255);
            COLORREF clrRef = new COLORREF();
            if (key != Color.Empty)
            {
                clrRef.R = key.R;
                clrRef.G = key.G;
                clrRef.B = key.B;
                lwa = (LayeredWindowAttributes)((int)lwa | (int)LayeredWindowAttributes.LWA_COLORKEY);
            }
            RECT rc;
            rc.right = 1000;
            rc.bottom = 1000;
            Win32SetLayeredWindowAttributes(handle, clrRef, opacity, lwa);
        }

        TransparencySupport support;
        bool queried_transparency_support;
        internal override TransparencySupport SupportsTransparency()
        {
            if (queried_transparency_support)
                return support;

            bool flag;
            support = TransparencySupport.None;

            flag = true;
            try
            {
                Win32SetLayeredWindowAttributes(IntPtr.Zero, new COLORREF(), 255, LayeredWindowAttributes.LWA_ALPHA);
            }
            catch (EntryPointNotFoundException) { flag = false; }
            catch { /* swallow everything else */ }

            if (flag) support |= TransparencySupport.Set;

            flag = true;
            try
            {
                LayeredWindowAttributes lwa;
                COLORREF clrRef;
                byte alpha;

                Win32GetLayeredWindowAttributes(IntPtr.Zero, out clrRef, out alpha, out lwa);
            }
            catch (EntryPointNotFoundException) { flag = false; }
            catch { /* swallow everything else */ }

            if (flag) support |= TransparencySupport.Get;

            queried_transparency_support = true;
            return support;
        }

        internal override void UpdateWindow(IntPtr handle)
        {
            Win32UpdateWindow(handle);
        }

        internal override PaintEventArgs PaintEventStart(ref Message msg, IntPtr handle, bool client)
        {
            IntPtr hdc;
            PAINTSTRUCT ps;
            PaintEventArgs paint_event;
            RECT rect;
            Rectangle clip_rect;
            Hwnd hwnd;

            clip_rect = new Rectangle();
            rect = new RECT();
            ps = new PAINTSTRUCT();

            hwnd = Hwnd.ObjectFromHandle(msg.HWnd);

            if (client)
            {
                if (Win32GetUpdateRect(msg.HWnd, ref rect, false))
                {
                    if (handle != msg.HWnd)
                    {
                        // We need to validate the window where the paint message
                        // was generated, otherwise we'll never stop getting paint 
                        // messages.
                        Win32GetClientRect(msg.HWnd, out rect);
                        Win32ValidateRect(msg.HWnd, ref rect);
                        hdc = Win32GetDC(handle);
                    }
                    else
                    {
                        hdc = Win32BeginPaint(handle, ref ps);
                        rect = ps.rcPaint;
                    }
                }
                else
                {
                    hdc = Win32GetDC(handle);
                }
                clip_rect = rect.ToRectangle();
            }
            else
            {
                hdc = Win32GetWindowDC(handle);

                // HACK this in for now
                Win32GetWindowRect(handle, out rect);
                clip_rect = new Rectangle(0, 0, rect.Width, rect.Height);
            }

            // If we called BeginPaint, store the PAINTSTRUCT,
            // otherwise store hdc, so that PaintEventEnd can know
            // whether to call EndPaint or ReleaseDC.
            if (ps.hdc != IntPtr.Zero)
            {
                hwnd.drawing_stack.Push(ps);
            }
            else
            {
                hwnd.drawing_stack.Push(hdc);
            }

            Graphics dc = Graphics.FromHdc(hdc);
            hwnd.drawing_stack.Push(dc);

            paint_event = new PaintEventArgs(dc, clip_rect);

            return paint_event;
        }

        internal override void PaintEventEnd(ref Message m, IntPtr handle, bool client)
        {
            Hwnd hwnd;

            hwnd = Hwnd.ObjectFromHandle(m.HWnd);

            Graphics dc = (Graphics)hwnd.drawing_stack.Pop();
            dc.Dispose();

            object o = hwnd.drawing_stack.Pop();
            if (o is IntPtr)
            {
                IntPtr hdc = (IntPtr)o;
                Win32ReleaseDC(handle, hdc);
            }
            else if (o is PAINTSTRUCT)
            {
                PAINTSTRUCT ps = (PAINTSTRUCT)o;
                Win32EndPaint(handle, ref ps);
            }
        }


        internal override void SetWindowPos(IntPtr handle, int x, int y, int width, int height)
        {
            Win32MoveWindow(handle, x, y, width, height, true);
            return;
        }

        internal override void GetWindowPos(IntPtr handle, bool is_toplevel, out int x, out int y, out int width, out int height, out int client_width, out int client_height)
        {
            IntPtr parent;
            RECT rect;
            POINT pt;

            Win32GetWindowRect(handle, out rect);
            width = rect.right - rect.left;
            height = rect.bottom - rect.top;

            pt.x = rect.left;
            pt.y = rect.top;

            parent = Win32GetAncestor(handle, AncestorType.GA_PARENT);
            if (parent != IntPtr.Zero && parent != Win32GetDesktopWindow())
                Win32ScreenToClient(parent, ref pt);

            x = pt.x;
            y = pt.y;

            Win32GetClientRect(handle, out rect);
            client_width = rect.right - rect.left;
            client_height = rect.bottom - rect.top;
            return;
        }

        internal override void Activate(IntPtr handle)
        {
            Win32SetActiveWindow(handle);
            // delayed timer enabled
            lock (timer_list)
            {
                foreach (Timer t in timer_list.Values)
                {
                    if (t.Enabled && t.window == IntPtr.Zero)
                    {
                        t.window = handle;
                        int id = t.GetHashCode();
                        Win32SetTimer(handle, id, (uint)t.Interval, IntPtr.Zero);
                    }
                }
            }
        }

        internal override void Invalidate(IntPtr handle, Rectangle rc, bool clear)
        {
            cosmos.Redraw(); //I don't want to make it too hard for devs to deal with this...
        }


        internal override void InvalidateNC(IntPtr handle)
        {
            cosmos.Redraw();
        }

        private IntPtr InternalWndProc(IntPtr hWnd, Msg msg, IntPtr wParam, IntPtr lParam)
        {
            if (HwndCreating != null && HwndCreating.ClientWindow == IntPtr.Zero)
                HwndCreating.ClientWindow = hWnd;
            return NativeWindow.WndProc(hWnd, msg, wParam, lParam);
        }

        internal override IntPtr DefWndProc(ref Message msg)
        {
            msg.Result = Win32DefWindowProc(msg.HWnd, (Msg)msg.Msg, msg.WParam, msg.LParam);
            return msg.Result;
        }

        internal override void HandleException(Exception e)
        {
            StackTrace st = new StackTrace(e);
            Win32MessageBox(IntPtr.Zero, e.Message + st.ToString(), "Exception", 0);
            Console.WriteLine("{0}{1}", e.Message, st.ToString());
        }

        internal override void DoEvents()
        {
            MSG msg = new MSG();

            while (GetMessage(ref msg, IntPtr.Zero, 0, 0, false))
            {
                Message m = Message.Create(msg.hwnd, (int)msg.message, msg.wParam, msg.lParam);

                if (Application.FilterMessage(ref m))
                    continue;

                XplatUI.TranslateMessage(ref msg);
                XplatUI.DispatchMessage(ref msg);
            }
        }

        internal override bool PeekMessage(Object queue_id, ref MSG msg, IntPtr hWnd, int wFilterMin, int wFilterMax, uint flags)
        {
            return Win32PeekMessage(ref msg, hWnd, wFilterMin, wFilterMax, flags);
        }

        internal override void PostQuitMessage(int exitCode)
        {
            Win32PostQuitMessage(exitCode);
        }

        internal override void RequestAdditionalWM_NCMessages(IntPtr hwnd, bool hover, bool leave)
        {
            if (wm_nc_registered == null)
                wm_nc_registered = new Hashtable();

            TMEFlags flags = TMEFlags.TME_NONCLIENT;
            if (hover)
                flags |= TMEFlags.TME_HOVER;
            if (leave)
                flags |= TMEFlags.TME_LEAVE;

            if (flags == TMEFlags.TME_NONCLIENT)
            {
                if (wm_nc_registered.Contains(hwnd))
                {
                    wm_nc_registered.Remove(hwnd);
                }
            }
            else
            {
                if (!wm_nc_registered.Contains(hwnd))
                {
                    wm_nc_registered.Add(hwnd, flags);
                }
                else
                {
                    wm_nc_registered[hwnd] = flags;
                }
            }
        }

        internal override void RequestNCRecalc(IntPtr handle)
        {
            Win32SetWindowPos(handle, IntPtr.Zero, 0, 0, 0, 0, SetWindowPosFlags.SWP_FRAMECHANGED | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOACTIVATE);
        }

        internal override void ResetMouseHover(IntPtr handle)
        {
            TRACKMOUSEEVENT tme;

            tme = new TRACKMOUSEEVENT();
            tme.size = Marshal.SizeOf(tme);
            tme.hWnd = handle;
            tme.dwFlags = TMEFlags.TME_LEAVE | TMEFlags.TME_HOVER;
            Win32TrackMouseEvent(ref tme);
        }


        internal override bool GetMessage(Object queue_id, ref MSG msg, IntPtr hWnd, int wFilterMin, int wFilterMax)
        {
            return GetMessage(ref msg, hWnd, wFilterMin, wFilterMax, true);
        }

        private bool GetMessage(ref MSG msg, IntPtr hWnd, int wFilterMin, int wFilterMax, bool blocking)
        {
            bool result;

            msg.refobject = 0;
            if (RetrieveMessage(ref msg))
            {
                return true;
            }

            if (blocking)
            {
                result = Win32GetMessage(ref msg, hWnd, wFilterMin, wFilterMax);
            }
            else
            {
                result = Win32PeekMessage(ref msg, hWnd, wFilterMin, wFilterMax, (uint)PeekMessageFlags.PM_REMOVE);
                if (!result)
                {
                    return false;
                }
            }

            // We need to fake WM_MOUSE_ENTER
            switch (msg.message)
            {
                case Msg.WM_LBUTTONDOWN:
                    {
                        mouse_state |= MouseButtons.Left;
                        break;
                    }

                case Msg.WM_MBUTTONDOWN:
                    {
                        mouse_state |= MouseButtons.Middle;
                        break;
                    }

                case Msg.WM_RBUTTONDOWN:
                    {
                        mouse_state |= MouseButtons.Right;
                        break;
                    }

                case Msg.WM_LBUTTONUP:
                    {
                        mouse_state &= ~MouseButtons.Left;
                        break;
                    }

                case Msg.WM_MBUTTONUP:
                    {
                        mouse_state &= ~MouseButtons.Middle;
                        break;
                    }

                case Msg.WM_RBUTTONUP:
                    {
                        mouse_state &= ~MouseButtons.Right;
                        break;
                    }

                case Msg.WM_ASYNC_MESSAGE:
                    {
                        XplatUIDriverSupport.ExecuteClientMessage((GCHandle)msg.lParam);
                        break;
                    }

                case Msg.WM_MOUSEMOVE:
                    {
                        if (msg.hwnd != prev_mouse_hwnd)
                        {
                            TRACKMOUSEEVENT tme;

                            mouse_state = Widget.FromParamToMouseButtons((int)msg.lParam.ToInt32());

                            // The current message will be sent out next time around
                            StoreMessage(ref msg);

                            // This is the message we want to send at this point
                            msg.message = Msg.WM_MOUSE_ENTER;

                            prev_mouse_hwnd = msg.hwnd;

                            tme = new TRACKMOUSEEVENT();
                            tme.size = Marshal.SizeOf(tme);
                            tme.hWnd = msg.hwnd;
                            tme.dwFlags = TMEFlags.TME_LEAVE | TMEFlags.TME_HOVER;
                            Win32TrackMouseEvent(ref tme);
                            return result;
                        }
                        break;
                    }

                case Msg.WM_NCMOUSEMOVE:
                    {
                        if (wm_nc_registered == null || !wm_nc_registered.Contains(msg.hwnd))
                            break;

                        mouse_state = Widget.FromParamToMouseButtons((int)msg.lParam.ToInt32());

                        TRACKMOUSEEVENT tme;

                        tme = new TRACKMOUSEEVENT();
                        tme.size = Marshal.SizeOf(tme);
                        tme.hWnd = msg.hwnd;
                        tme.dwFlags = (TMEFlags)wm_nc_registered[msg.hwnd];
                        Win32TrackMouseEvent(ref tme);
                        return result;
                    }

                case Msg.WM_DROPFILES:
                    {
                        return Win32DnD.HandleWMDropFiles(ref msg);
                    }

                case Msg.WM_MOUSELEAVE:
                    {
                        prev_mouse_hwnd = IntPtr.Zero;
                        break;
                    }

                case Msg.WM_TIMER:
                    {
                        Timer timer = (Timer)timer_list[(int)msg.wParam];

                        if (timer != null)
                        {
                            timer.FireTick();
                        }
                        break;
                    }
            }

            return result;
        }

        internal override bool TranslateMessage(ref MSG msg)
        {
            return Win32TranslateMessage(ref msg);
        }

        internal override IntPtr DispatchMessage(ref MSG msg)
        {
            return Win32DispatchMessage(ref msg);
        }

        internal override bool SetZOrder(IntPtr hWnd, IntPtr AfterhWnd, bool Top, bool Bottom)
        {
            if (Top)
            {
                Win32SetWindowPos(hWnd, SetWindowPosZOrder.HWND_TOP, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE);
                return true;
            }
            else if (!Bottom)
            {
                Win32SetWindowPos(hWnd, AfterhWnd, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE);
            }
            else
            {
                Win32SetWindowPos(hWnd, (IntPtr)SetWindowPosZOrder.HWND_BOTTOM, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE);
                return true;
            }
            return false;
        }

        internal override bool SetTopmost(IntPtr hWnd, bool Enabled)
        {
            if (Enabled)
            {
                Win32SetWindowPos(hWnd, SetWindowPosZOrder.HWND_TOPMOST, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOACTIVATE);
                return true;
            }
            else
            {
                Win32SetWindowPos(hWnd, SetWindowPosZOrder.HWND_NOTOPMOST, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOACTIVATE);
                return true;
            }
        }

        internal override bool SetOwner(IntPtr hWnd, IntPtr hWndOwner)
        {
            Win32SetWindowLong(hWnd, WindowLong.GWL_HWNDPARENT, (uint)hWndOwner);
            return true;
        }

        internal override bool Text(IntPtr handle, string text)
        {
            Win32SetWindowText(handle, text);
            return true;
        }

        internal override bool GetText(IntPtr handle, out string text)
        {
            StringBuilder sb;

            sb = new StringBuilder(256);
            Win32GetWindowText(handle, sb, sb.Capacity);
            text = sb.ToString();
            return true;
        }

        internal override bool SetVisible(IntPtr handle, bool visible, bool activate)
        {
            if (visible)
            {
                Widget c = Widget.FromHandle(handle);
                if (c is Form)
                {
                    Form f;

                    f = (Form)Widget.FromHandle(handle);
                    WindowPlacementFlags flags = WindowPlacementFlags.SW_SHOWNORMAL;
                    switch (f.WindowState)
                    {
                        case FormWindowState.Normal: flags = WindowPlacementFlags.SW_SHOWNORMAL; break;
                        case FormWindowState.Minimized: flags = WindowPlacementFlags.SW_MINIMIZE; break;
                        case FormWindowState.Maximized: flags = WindowPlacementFlags.SW_MAXIMIZE; break;
                    }

                    if (!f.ActivateOnShow)
                        flags = WindowPlacementFlags.SW_SHOWNOACTIVATE;

                    Win32ShowWindow(handle, flags);
                }
                else
                {
                    if (c.ActivateOnShow)
                        Win32ShowWindow(handle, WindowPlacementFlags.SW_SHOWNORMAL);
                    else
                        Win32ShowWindow(handle, WindowPlacementFlags.SW_SHOWNOACTIVATE);
                }
            }
            else
            {
                Win32ShowWindow(handle, WindowPlacementFlags.SW_HIDE);
            }
            return true;
        }

        internal override bool IsEnabled(IntPtr handle)
        {
            return IsWindowEnabled(handle);
        }

        internal override bool IsKeyLocked(VirtualKeys key)
        {
            return (Win32GetKeyState(key) & 1) == 1;
        }

        internal override bool IsVisible(IntPtr handle)
        {
            return IsWindowVisible(handle);
        }

        internal override IntPtr SetParent(IntPtr handle, IntPtr parent)
        {
            Widget c = Widget.FromHandle(handle);
            if (parent == IntPtr.Zero)
            {
                if (!(c is Form))
                {
                    Win32ShowWindow(handle, WindowPlacementFlags.SW_HIDE);
                }
            }
            else
            {
                if (!(c is Form))
                {
                    SetVisible(handle, c.is_visible, true);
                }
            }
            // The Win32SetParent is lame, it can very well move the window
            // ref: http://groups.google.com/group/microsoft.public.vb.winapi/browse_thread/thread/1b82ccc54231ecee/afa82835bfc0422a%23afa82835bfc0422a
            // Here we save the position before changing the parent, and if it has changed afterwards restore it.
            // Another possibility would be to intercept WM_WINDOWPOSCHANGING and restore the coords there, but this would require plumbing in weird places
            // (either inside Widget or add handling to InternalWndProc)
            // We also need to remove WS_CHILD if making the window parent-less, and add it if we're parenting it.
            RECT rect, rect2;
            IntPtr result;
            WindowStyles style, new_style;

            Win32GetWindowRect(handle, out rect);
            style = (WindowStyles)Win32GetWindowLong(handle, WindowLong.GWL_STYLE);

            if (parent == IntPtr.Zero)
            {
                new_style = style & ~WindowStyles.WS_CHILD;
                result = Win32SetParent(handle, GetFosterParent());
            }
            else
            {
                new_style = style | WindowStyles.WS_CHILD;
                result = Win32SetParent(handle, parent);
            }
            if (style != new_style && c is Form)
            {
                Win32SetWindowLong(handle, WindowLong.GWL_STYLE, (uint)new_style);
            }
            Win32GetWindowRect(handle, out rect2);
            if (rect.top != rect2.top && rect.left != rect2.left && c is Form)
            {
                Win32SetWindowPos(handle, IntPtr.Zero, rect.top, rect.left, rect.Width, rect.Height, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOREDRAW | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOENDSCHANGING | SetWindowPosFlags.SWP_NOACTIVATE);
            }
            return result;
        }

        // If we ever start using this, we should probably replace FosterParent with IntPtr.Zero
        internal override IntPtr GetParent(IntPtr handle)
        {
            return Win32GetParent(handle);
        }

        // This is a nop on win32 and x11
        internal override IntPtr GetPreviousWindow(IntPtr handle)
        {
            return handle;
        }

        internal override void GrabWindow(IntPtr hWnd, IntPtr ConfineToHwnd)
        {
            grab_hwnd = hWnd;
            Win32SetCapture(hWnd);

            if (ConfineToHwnd != IntPtr.Zero)
            {
                RECT window_rect;
                Win32GetWindowRect(ConfineToHwnd, out window_rect);
                Win32GetClipCursor(out clipped_cursor_rect);
                Win32ClipCursor(ref window_rect);
            }
        }

        internal override void GrabInfo(out IntPtr hWnd, out bool GrabConfined, out Rectangle GrabArea)
        {
            hWnd = grab_hwnd;
            GrabConfined = grab_confined;
            GrabArea = grab_area;
        }

        internal override void UngrabWindow(IntPtr hWnd)
        {
            if (!(clipped_cursor_rect.top == 0 && clipped_cursor_rect.bottom == 0 && clipped_cursor_rect.left == 0 && clipped_cursor_rect.right == 0))
            {
                Win32ClipCursor(ref clipped_cursor_rect);
                clipped_cursor_rect = new RECT();
            }

            Win32ReleaseCapture();
            grab_hwnd = IntPtr.Zero;
        }

        internal override bool CalculateWindowRect(ref Rectangle ClientRect, CreateParams cp, Menu menu, out Rectangle WindowRect)
        {
            RECT rect;

            rect.left = ClientRect.Left;
            rect.top = ClientRect.Top;
            rect.right = ClientRect.Right;
            rect.bottom = ClientRect.Bottom;

            if (!Win32AdjustWindowRectEx(ref rect, cp.Style, menu != null, cp.ExStyle))
            {
                WindowRect = new Rectangle(ClientRect.Left, ClientRect.Top, ClientRect.Width, ClientRect.Height);
                return false;
            }

            WindowRect = new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
            return true;
        }

        internal override void SetCursor(IntPtr window, IntPtr cursor)
        {
            Win32SetCursor(cursor);
            return;
        }

        internal override void ShowCursor(bool show)
        {
            Win32ShowCursor(show);
        }

        internal override void OverrideCursor(IntPtr cursor)
        {
            Win32SetCursor(cursor);
        }

        internal override IntPtr DefineCursor(Bitmap bitmap, Bitmap mask, Color cursor_pixel, Color mask_pixel, int xHotSpot, int yHotSpot)
        {
            IntPtr cursor;
            Bitmap cursor_bitmap;
            Bitmap cursor_mask;
            Byte[] cursor_bits;
            Byte[] mask_bits;
            Color pixel;
            int width;
            int height;

            // Win32 only allows creation cursors of a certain size
            if ((bitmap.Width != Win32GetSystemMetrics(SystemMetrics.SM_CXCURSOR)) || (bitmap.Width != Win32GetSystemMetrics(SystemMetrics.SM_CXCURSOR)))
            {
                cursor_bitmap = new Bitmap(bitmap, new Size(Win32GetSystemMetrics(SystemMetrics.SM_CXCURSOR), Win32GetSystemMetrics(SystemMetrics.SM_CXCURSOR)));
                cursor_mask = new Bitmap(mask, new Size(Win32GetSystemMetrics(SystemMetrics.SM_CXCURSOR), Win32GetSystemMetrics(SystemMetrics.SM_CXCURSOR)));
            }
            else
            {
                cursor_bitmap = bitmap;
                cursor_mask = mask;
            }

            width = cursor_bitmap.Width;
            height = cursor_bitmap.Height;

            cursor_bits = new Byte[(width / 8) * height];
            mask_bits = new Byte[(width / 8) * height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    pixel = cursor_bitmap.GetPixel(x, y);

                    if (pixel == cursor_pixel)
                    {
                        cursor_bits[y * width / 8 + x / 8] |= (byte)(0x80 >> (x % 8));
                    }

                    pixel = cursor_mask.GetPixel(x, y);

                    if (pixel == mask_pixel)
                    {
                        mask_bits[y * width / 8 + x / 8] |= (byte)(0x80 >> (x % 8));
                    }
                }
            }

            cursor = Win32CreateCursor(IntPtr.Zero, xHotSpot, yHotSpot, width, height, mask_bits, cursor_bits);

            return cursor;
        }

        internal override Bitmap DefineStdCursorBitmap(StdCursor id)
        {
            // We load the cursor, create a bitmap, draw the cursor onto the bitmap and return the bitmap.
            IntPtr cursor = DefineStdCursor(id);
            // Windows only have one possible cursor size!
            int width = Win32GetSystemMetrics(SystemMetrics.SM_CXCURSOR);
            int height = Win32GetSystemMetrics(SystemMetrics.SM_CYCURSOR);
            Bitmap bmp = new Bitmap(width, height);
            Graphics gc = Graphics.FromImage(bmp);
            IntPtr hdc = gc.GetHdc();
            Win32DrawIcon(hdc, 0, 0, cursor);
            gc.ReleaseHdc(hdc);
            gc.Dispose();
            return bmp;
        }

        [MonoTODO("Define the missing cursors")]
        internal override IntPtr DefineStdCursor(StdCursor id)
        {
            switch (id)
            {
                case StdCursor.AppStarting: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_APPSTARTING);
                case StdCursor.Arrow: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);
                case StdCursor.Cross: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_CROSS);
                case StdCursor.Default: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);
                case StdCursor.Hand: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_HAND);
                case StdCursor.Help: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_HELP);
                case StdCursor.HSplit: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);       // FIXME
                case StdCursor.IBeam: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_IBEAM);
                case StdCursor.No: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_NO);
                case StdCursor.NoMove2D: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);     // FIXME
                case StdCursor.NoMoveHoriz: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);      // FIXME
                case StdCursor.NoMoveVert: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);       // FIXME
                case StdCursor.PanEast: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);      // FIXME
                case StdCursor.PanNE: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);        // FIXME
                case StdCursor.PanNorth: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);     // FIXME
                case StdCursor.PanNW: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);        // FIXME
                case StdCursor.PanSE: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);        // FIXME
                case StdCursor.PanSouth: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);     // FIXME
                case StdCursor.PanSW: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);        // FIXME
                case StdCursor.PanWest: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);      // FIXME
                case StdCursor.SizeAll: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_SIZEALL);
                case StdCursor.SizeNESW: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_SIZENESW);
                case StdCursor.SizeNS: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_SIZENS);
                case StdCursor.SizeNWSE: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_SIZENWSE);
                case StdCursor.SizeWE: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_SIZEWE);
                case StdCursor.UpArrow: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_UPARROW);
                case StdCursor.VSplit: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_ARROW);       // FIXME
                case StdCursor.WaitCursor: return Win32LoadCursor(IntPtr.Zero, LoadCursorType.IDC_WAIT);
            }
            throw new NotImplementedException();
        }

        internal override void DestroyCursor(IntPtr cursor)
        {
            if ((cursor.ToInt32() < (int)LoadCursorType.First) || (cursor.ToInt32() > (int)LoadCursorType.Last))
            {
                Win32DestroyCursor(cursor);
            }
        }

        [MonoTODO]
        internal override void GetCursorInfo(IntPtr cursor, out int width, out int height, out int hotspot_x, out int hotspot_y)
        {
            ICONINFO ii = new ICONINFO();

            if (!Win32GetIconInfo(cursor, out ii))
                throw new Win32Exception();

            width = 20;
            height = 20;
            hotspot_x = ii.xHotspot;
            hotspot_y = ii.yHotspot;
        }

        internal override void SetCursorPos(IntPtr handle, int x, int y)
        {
            Win32SetCursorPos(x, y);
        }

        internal override Region GetClipRegion(IntPtr hwnd)
        {
            Region region;

            region = new Region();

            Win32GetWindowRgn(hwnd, region.GetHrgn(Graphics.FromHwnd(hwnd)));

            return region;
        }

        internal override void SetClipRegion(IntPtr hwnd, Region region)
        {
            if (region == null)
                Win32SetWindowRgn(hwnd, IntPtr.Zero, true);
            else
                Win32SetWindowRgn(hwnd, region.GetHrgn(Graphics.FromHwnd(hwnd)), true);
        }

        internal override void EnableWindow(IntPtr handle, bool Enable)
        {
            Win32EnableWindow(handle, Enable);
        }

        internal override void EndLoop(System.Threading.Thread thread)
        {
            // Nothing to do
        }

        internal override object StartLoop(System.Threading.Thread thread)
        {
            return null;
        }

        internal override void SetModal(IntPtr handle, bool Modal)
        {
            // we do nothing on Win32
        }

        internal override void GetCursorPos(IntPtr handle, out int x, out int y)
        {
            POINT pt;

            Win32GetCursorPos(out pt);

            if (handle != IntPtr.Zero)
            {
                Win32ScreenToClient(handle, ref pt);
            }

            x = pt.x;
            y = pt.y;
        }

        internal override void ScreenToClient(IntPtr handle, ref int x, ref int y)
        {
            POINT pnt = new POINT();

            pnt.x = x;
            pnt.y = y;
            Win32ScreenToClient(handle, ref pnt);

            x = pnt.x;
            y = pnt.y;
        }

        internal override void ClientToScreen(IntPtr handle, ref int x, ref int y)
        {
            POINT pnt = new POINT();

            pnt.x = x;
            pnt.y = y;

            Win32ClientToScreen(handle, ref pnt);

            x = pnt.x;
            y = pnt.y;
        }

        internal override void ScreenToMenu(IntPtr handle, ref int x, ref int y)
        {
            RECT rect;

            Win32GetWindowRect(handle, out rect);
            x -= rect.left + SystemInformation.FrameBorderSize.Width;
            y -= rect.top + SystemInformation.FrameBorderSize.Height;

            WindowStyles style = (WindowStyles)Win32GetWindowLong(handle, WindowLong.GWL_STYLE);
            if (CreateParams.IsSet(style, WindowStyles.WS_CAPTION))
            {
                y -= ThemeEngine.Current.CaptionHeight;
            }
        }

        internal override void MenuToScreen(IntPtr handle, ref int x, ref int y)
        {
            RECT rect;

            Win32GetWindowRect(handle, out rect);
            x += rect.left + SystemInformation.FrameBorderSize.Width;
            y += rect.top + SystemInformation.FrameBorderSize.Height + ThemeEngine.Current.CaptionHeight;
            return;
        }

        internal override void SendAsyncMethod(AsyncMethodData method)
        {
            Win32PostMessage(GetFosterParent(), Msg.WM_ASYNC_MESSAGE, IntPtr.Zero, (IntPtr)GCHandle.Alloc(method));
        }

        internal override void SetTimer(Timer timer)
        {
            IntPtr FosterParent = GetFosterParent();
            int index;

            index = timer.GetHashCode();

            lock (timer_list)
            {
                timer_list[index] = timer;
            }

            if (Win32SetTimer(FosterParent, index, (uint)timer.Interval, IntPtr.Zero) != IntPtr.Zero)
                timer.window = FosterParent;
            else
                timer.window = IntPtr.Zero;
        }

        internal override void KillTimer(Timer timer)
        {
            int index;

            index = timer.GetHashCode();

            Win32KillTimer(timer.window, index);

            lock (timer_list)
            {
                timer_list.Remove(index);
            }
        }

        internal override void CreateCaret(IntPtr hwnd, int width, int height)
        {
            Win32CreateCaret(hwnd, IntPtr.Zero, width, height);
            caret_visible = false;
        }

        internal override void DestroyCaret(IntPtr hwnd)
        {
            Win32DestroyCaret();
        }

        internal override void SetCaretPos(IntPtr hwnd, int x, int y)
        {
            Win32SetCaretPos(x, y);
        }

        internal override void CaretVisible(IntPtr hwnd, bool visible)
        {
            if (visible)
            {
                if (!caret_visible)
                {
                    Win32ShowCaret(hwnd);
                    caret_visible = true;
                }
            }
            else
            {
                if (caret_visible)
                {
                    Win32HideCaret(hwnd);
                    caret_visible = false;
                }
            }
        }

        internal override IntPtr GetFocus()
        {
            return Win32GetFocus();
        }

        internal override void SetFocus(IntPtr hwnd)
        {
            Win32SetFocus(hwnd);
        }

        internal override IntPtr GetActive()
        {
            return Win32GetActiveWindow();
        }

        internal override bool GetFontMetrics(Graphics g, Font font, out int ascent, out int descent)
        {
            IntPtr dc;
            IntPtr prevobj;
            TEXTMETRIC tm;

            tm = new TEXTMETRIC();

            dc = Win32GetDC(IntPtr.Zero);
            prevobj = Win32SelectObject(dc, font.ToHfont());

            if (Win32GetTextMetrics(dc, ref tm) == false)
            {
                prevobj = Win32SelectObject(dc, prevobj);
                Win32DeleteObject(prevobj);
                Win32ReleaseDC(IntPtr.Zero, dc);
                ascent = 0;
                descent = 0;
                return false;
            }
            prevobj = Win32SelectObject(dc, prevobj);
            Win32DeleteObject(prevobj);
            Win32ReleaseDC(IntPtr.Zero, dc);

            ascent = tm.tmAscent;
            descent = tm.tmDescent;

            return true;
        }

        internal override void ScrollWindow(IntPtr hwnd, Rectangle rectangle, int XAmount, int YAmount, bool with_children)
        {
            RECT rect;

            rect = new RECT();
            rect.left = rectangle.X;
            rect.top = rectangle.Y;
            rect.right = rectangle.Right;
            rect.bottom = rectangle.Bottom;

            Win32ScrollWindowEx(hwnd, XAmount, YAmount, IntPtr.Zero, ref rect, IntPtr.Zero, IntPtr.Zero, ScrollWindowExFlags.SW_INVALIDATE | ScrollWindowExFlags.SW_ERASE | (with_children ? ScrollWindowExFlags.SW_SCROLLCHILDREN : ScrollWindowExFlags.SW_NONE));
            Win32UpdateWindow(hwnd);
        }

        internal override void ScrollWindow(IntPtr hwnd, int XAmount, int YAmount, bool with_children)
        {
            Win32ScrollWindowEx(hwnd, XAmount, YAmount, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ScrollWindowExFlags.SW_INVALIDATE | ScrollWindowExFlags.SW_ERASE | (with_children ? ScrollWindowExFlags.SW_SCROLLCHILDREN : ScrollWindowExFlags.SW_NONE));
        }

        internal override bool SystrayAdd(IntPtr hwnd, string tip, Icon icon, out ToolTip tt)
        {
            NOTIFYICONDATA nid;

            nid = new NOTIFYICONDATA();

            nid.cbSize = (uint)Marshal.SizeOf(nid);
            nid.hWnd = hwnd;
            nid.uID = 1;
            nid.uCallbackMessage = (uint)Msg.WM_USER;
            nid.uFlags = NotifyIconFlags.NIF_MESSAGE;

            if (tip != null)
            {
                nid.szTip = tip;
                nid.uFlags |= NotifyIconFlags.NIF_TIP;
            }

            if (icon != null)
            {
                nid.hIcon = icon.Handle;
                nid.uFlags |= NotifyIconFlags.NIF_ICON;
            }

            tt = null;

            return Win32Shell_NotifyIcon(NotifyIconMessage.NIM_ADD, ref nid);
        }

        internal override bool SystrayChange(IntPtr hwnd, string tip, Icon icon, ref ToolTip tt)
        {
            NOTIFYICONDATA nid;

            nid = new NOTIFYICONDATA();

            nid.cbSize = (uint)Marshal.SizeOf(nid);
            nid.hIcon = icon.Handle;
            nid.hWnd = hwnd;
            nid.uID = 1;
            nid.uCallbackMessage = (uint)Msg.WM_USER;
            nid.uFlags = NotifyIconFlags.NIF_MESSAGE;

            if (tip != null)
            {
                nid.szTip = tip;
                nid.uFlags |= NotifyIconFlags.NIF_TIP;
            }

            if (icon != null)
            {
                nid.hIcon = icon.Handle;
                nid.uFlags |= NotifyIconFlags.NIF_ICON;
            }

            return Win32Shell_NotifyIcon(NotifyIconMessage.NIM_MODIFY, ref nid);
        }

        internal override void SystrayRemove(IntPtr hwnd, ref ToolTip tt)
        {
            NOTIFYICONDATA nid;

            nid = new NOTIFYICONDATA();

            nid.cbSize = (uint)Marshal.SizeOf(nid);
            nid.hWnd = hwnd;
            nid.uID = 1;
            nid.uFlags = 0;

            Win32Shell_NotifyIcon(NotifyIconMessage.NIM_DELETE, ref nid);
        }

        internal override void SystrayBalloon(IntPtr hwnd, int timeout, string title, string text, ToolTipIcon icon)
        {
            NOTIFYICONDATA nid;

            nid = new NOTIFYICONDATA();

            nid.cbSize = (uint)Marshal.SizeOf(nid);
            nid.hWnd = hwnd;
            nid.uID = 1;
            nid.uFlags = NotifyIconFlags.NIF_INFO;
            nid.uTimeoutOrVersion = timeout;
            nid.szInfoTitle = title;
            nid.szInfo = text;
            nid.dwInfoFlags = icon;

            Win32Shell_NotifyIcon(NotifyIconMessage.NIM_MODIFY, ref nid);
        }

        internal override void SetBorderStyle(IntPtr handle, FormBorderStyle border_style)
        {
            // Nothing to do on Win32
        }

        internal override void SetMenu(IntPtr handle, Menu menu)
        {
            // Trigger WM_NCCALC
            Win32SetWindowPos(handle, IntPtr.Zero, 0, 0, 0, 0, SetWindowPosFlags.SWP_FRAMECHANGED | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE);
        }

        internal override Point GetMenuOrigin(IntPtr handle)
        {
            Form form = Widget.FromHandle(handle) as Form;

            if (form != null)
            {
                if (form.FormBorderStyle == FormBorderStyle.None)
                    return Point.Empty;

                int bordersize = (form.Width - form.ClientSize.Width) / 2;

                if (form.FormBorderStyle == FormBorderStyle.FixedToolWindow || form.FormBorderStyle == FormBorderStyle.SizableToolWindow)
                    return new Point(bordersize, bordersize + SystemInformation.ToolWindowCaptionHeight);
                else
                    return new Point(bordersize, bordersize + SystemInformation.CaptionHeight);
            }

            return new Point(SystemInformation.FrameBorderSize.Width, SystemInformation.FrameBorderSize.Height + ThemeEngine.Current.CaptionHeight);
        }

        internal override void SetIcon(IntPtr hwnd, Icon icon)
        {
            Win32SendMessage(hwnd, Msg.WM_SETICON, (IntPtr)1, icon == null ? IntPtr.Zero : icon.Handle);    // 1 = large icon (0 would be small)
        }

        internal override void ClipboardClose(IntPtr handle)
        {
            if (handle != clip_magic)
            {
                throw new ArgumentException("handle is not a valid clipboard handle");
            }
            Win32CloseClipboard();
        }

        internal override int ClipboardGetID(IntPtr handle, string format)
        {
            if (handle != clip_magic)
            {
                throw new ArgumentException("handle is not a valid clipboard handle");
            }
            if (format == "Text") return 1;
            else if (format == "Bitmap") return 2;
            else if (format == "MetaFilePict") return 3;
            else if (format == "SymbolicLink") return 4;
            else if (format == "DataInterchangeFormat") return 5;
            else if (format == "Tiff") return 6;
            else if (format == "OEMText") return 7;
            else if (format == "DeviceIndependentBitmap") return 8;
            else if (format == "Palette") return 9;
            else if (format == "PenData") return 10;
            else if (format == "RiffAudio") return 11;
            else if (format == "WaveAudio") return 12;
            else if (format == "UnicodeText") return 13;
            else if (format == "EnhancedMetafile") return 14;
            else if (format == "FileDrop") return 15;
            else if (format == "Locale") return 16;

            return (int)Win32RegisterClipboardFormat(format);
        }

        internal override IntPtr ClipboardOpen(bool primary_selection)
        {
            // Win32 does not have primary selection
            Win32OpenClipboard(GetFosterParent());
            return clip_magic;
        }

        internal override int[] ClipboardAvailableFormats(IntPtr handle)
        {
            uint format;
            int[] result;
            int count;

            if (handle != clip_magic)
            {
                return null;
            }

            // Count first
            count = 0;
            format = 0;
            do
            {
                format = Win32EnumClipboardFormats(format);
                if (format != 0)
                {
                    count++;
                }
            } while (format != 0);

            // Now assign
            result = new int[count];
            count = 0;
            format = 0;
            do
            {
                format = Win32EnumClipboardFormats(format);
                if (format != 0)
                {
                    result[count++] = (int)format;
                }
            } while (format != 0);

            return result;
        }


        internal override object ClipboardRetrieve(IntPtr handle, int type, XplatUI.ClipboardToObject converter)
        {
            IntPtr hmem;
            IntPtr data;
            object obj;

            if (handle != clip_magic)
            {
                throw new ArgumentException("handle is not a valid clipboard handle");
            }

            hmem = Win32GetClipboardData((uint)type);
            if (hmem == IntPtr.Zero)
            {
                return null;
            }

            data = Win32GlobalLock(hmem);
            if (data == IntPtr.Zero)
            {
                uint error = Win32GetLastError();
                Console.WriteLine("Error: {0}", error);
                return null;
            }

            obj = null;

            if (type == DataFormats.GetFormat(DataFormats.Rtf).Id)
            {
                obj = AnsiToString(data);
            }
            else switch ((ClipboardFormats)type)
                {
                    case ClipboardFormats.CF_TEXT:
                        {
                            obj = AnsiToString(data);
                            break;
                        }

                    case ClipboardFormats.CF_DIB:
                        {
                            obj = DIBtoImage(data);
                            break;
                        }

                    case ClipboardFormats.CF_UNICODETEXT:
                        {
                            obj = UnicodeToString(data);
                            break;
                        }

                    default:
                        {
                            if (converter != null && !converter(type, data, out obj))
                            {
                                obj = null;
                            }
                            break;
                        }
                }
            Win32GlobalUnlock(hmem);

            return obj;

        }

        internal override void ClipboardStore(IntPtr handle, object obj, int type, XplatUI.ObjectToClipboard converter, bool copy)
        {
            byte[] data = null;

            if (handle != clip_magic)
            {
                throw new ArgumentException("handle is not a valid clipboard handle");
            }

            if (obj == null)
            {
                // Just clear it
                if (!Win32EmptyClipboard())
                    throw new ExternalException("Win32EmptyClipboard");
                return;
            }

            if (type == -1)
            {
                if (obj is string)
                {
                    type = (int)ClipboardFormats.CF_UNICODETEXT;
                }
                else if (obj is Image)
                {
                    type = (int)ClipboardFormats.CF_DIB;
                }
            }

            if (type == DataFormats.GetFormat(DataFormats.Rtf).Id)
            {
                data = StringToAnsi((string)obj);
            }
            else switch ((ClipboardFormats)type)
                {
                    case ClipboardFormats.CF_UNICODETEXT:
                        {
                            data = StringToUnicode((string)obj);
                            break;
                        }

                    case ClipboardFormats.CF_TEXT:
                        {
                            data = StringToAnsi((string)obj);
                            break;
                        }

                    case ClipboardFormats.CF_BITMAP:
                    case ClipboardFormats.CF_DIB:
                        {
                            data = ImageToDIB((Image)obj);
                            type = (int)ClipboardFormats.CF_DIB;
                            break;
                        }

                    default:
                        {
                            if (converter != null && !converter(ref type, obj, out data))
                            {
                                data = null; // ensure that a failed conversion leaves null.
                            }
                            break;
                        }
                }
            if (data != null)
            {
                SetClipboardData((uint)type, data);
            }
        }

        internal static byte[] StringToUnicode(string text)
        {
            return Encoding.Unicode.GetBytes(text + "\0");
        }

        internal static byte[] StringToAnsi(string text)
        {
            // FIXME, follow the behaviour of the previous code using UTF-8,
            // but this should be 'ANSI' on Windows, i.e. the current code page.
            // Does Encoding.Default work on Windows?
            return Encoding.UTF8.GetBytes(text + "\0");
        }

        private void SetClipboardData(uint type, byte[] data)
        {
            if (data.Length == 0)
                // Shouldn't call Win32SetClipboard with NULL, as, from MSDN:
                // "This parameter can be NULL, indicating that the window provides data 
                //  in the specified clipboard format (renders the format) upon request."
                // and I don't think we support that...
                // Note this is unrelated to the fact that passing a null obj to 
                // ClipboardStore is actually a request to empty the clipboard!
                return;
            IntPtr hmem = CopyToMoveableMemory(data);
            if (hmem == IntPtr.Zero)
                // As above, should not call with null.
                // (Not that CopyToMoveableMemory should ever return null!)
                throw new ExternalException("CopyToMoveableMemory failed.");
            if (Win32SetClipboardData(type, hmem) == IntPtr.Zero)
                throw new ExternalException("Win32SetClipboardData");
        }

        /// <summary>
        /// Creates a memory block with GlobalAlloc(GMEM_MOVEABLE), copies the data 
        /// into it, and returns the handle to the memory.
        /// </summary>
        /// -
        /// <param name="data">The data.  Must not be null or zero-length &#x2014; 
        /// see the exception notes.</param>
        /// -
        /// <returns>The *handle* to the allocated GMEM_MOVEABLE block.</returns>
        /// -
        /// <exception cref="T:System.ArgumentException">The data was null or zero 
        /// length.  This is disallowed since a zero length allocation can't be made
        /// </exception>
        /// <exception cref="T:System.ComponentModel.Win32Exception">The allocation, 
        /// or locking (handle->pointer) failed.
        /// Either out of memory or the handle table is full (256 max currently).
        /// Note Win32Exception is a subclass of ExternalException so this is OK in 
        /// the documented Clipboard interface.
        /// </exception>
        internal static IntPtr CopyToMoveableMemory(byte[] data)
        {
            if (data == null || data.Length == 0)
                // detect this before GlobalAlloc does.
                throw new ArgumentException("Can't create a zero length memory block.");

            IntPtr hmem = Win32GlobalAlloc(GAllocFlags.GMEM_MOVEABLE | GAllocFlags.GMEM_DDESHARE, data.Length);
            if (hmem == IntPtr.Zero)
                throw new Win32Exception();
            IntPtr hmem_ptr = Win32GlobalLock(hmem);
            if (hmem_ptr == IntPtr.Zero) // If the allocation was valid this shouldn't occur.
                throw new Win32Exception();
            Marshal.Copy(data, 0, hmem_ptr, data.Length);
            Win32GlobalUnlock(hmem);
            return hmem;
        }


        internal override void SetAllowDrop(IntPtr hwnd, bool allowed)
        {
            if (allowed)
            {
                Win32DnD.RegisterDropTarget(hwnd);
            }
            else
            {
                Win32DnD.UnregisterDropTarget(hwnd);
            }
        }

        internal override DragDropEffects StartDrag(IntPtr hwnd, object data, DragDropEffects allowedEffects)
        {
            return Win32DnD.StartDrag(hwnd, data, allowedEffects);
        }

        // XXX this doesn't work at all for FrameStyle.Dashed - it draws like Thick, and in the Thick case
        // the corners are drawn incorrectly.
        internal override void DrawReversibleFrame(Rectangle rectangle, Color backColor, FrameStyle style)
        {
            IntPtr hdc;
            IntPtr pen;
            IntPtr oldpen;
            COLORREF clrRef = new COLORREF();

            // If we want the standard hatch pattern we would
            // need to create a brush

            clrRef.R = backColor.R;
            clrRef.G = backColor.G;
            clrRef.B = backColor.B;

            // Grab a pen
            pen = Win32CreatePen(style == FrameStyle.Thick ? PenStyle.PS_SOLID : PenStyle.PS_DASH,
                          style == FrameStyle.Thick ? 4 : 2, ref clrRef);

            hdc = Win32GetDC(IntPtr.Zero);
            Win32SetROP2(hdc, ROP2DrawMode.R2_NOT);
            oldpen = Win32SelectObject(hdc, pen);

            Win32MoveToEx(hdc, rectangle.Left, rectangle.Top, IntPtr.Zero);
            if ((rectangle.Width > 0) && (rectangle.Height > 0))
            {
                Win32LineTo(hdc, rectangle.Right, rectangle.Top);
                Win32LineTo(hdc, rectangle.Right, rectangle.Bottom);
                Win32LineTo(hdc, rectangle.Left, rectangle.Bottom);
                Win32LineTo(hdc, rectangle.Left, rectangle.Top);
            }
            else
            {
                if (rectangle.Width > 0)
                {
                    Win32LineTo(hdc, rectangle.Right, rectangle.Top);
                }
                else
                {
                    Win32LineTo(hdc, rectangle.Left, rectangle.Bottom);
                }
            }

            Win32SelectObject(hdc, oldpen);
            Win32DeleteObject(pen);

            Win32ReleaseDC(IntPtr.Zero, hdc);
        }

        internal override void DrawReversibleLine(Point start, Point end, Color backColor)
        {
            IntPtr hdc;
            IntPtr pen;
            IntPtr oldpen;
            POINT pt;
            COLORREF clrRef = new COLORREF();

            pt = new POINT();
            pt.x = 0;
            pt.y = 0;
            Win32ClientToScreen(IntPtr.Zero, ref pt);

            // If we want the standard hatch pattern we would
            // need to create a brush

            clrRef.R = backColor.R;
            clrRef.G = backColor.G;
            clrRef.B = backColor.B;

            // Grab a pen
            pen = Win32CreatePen(PenStyle.PS_SOLID, 1, ref clrRef);

            hdc = Win32GetDC(IntPtr.Zero);
            Win32SetROP2(hdc, ROP2DrawMode.R2_NOT);
            oldpen = Win32SelectObject(hdc, pen);

            Win32MoveToEx(hdc, pt.x + start.X, pt.y + start.Y, IntPtr.Zero);
            Win32LineTo(hdc, pt.x + end.X, pt.y + end.Y);

            Win32SelectObject(hdc, oldpen);
            Win32DeleteObject(pen);

            Win32ReleaseDC(IntPtr.Zero, hdc);
        }

        internal override void FillReversibleRectangle(Rectangle rectangle, Color backColor)
        {
            RECT rect;

            rect = new RECT();
            rect.left = rectangle.Left;
            rect.top = rectangle.Top;
            rect.right = rectangle.Right;
            rect.bottom = rectangle.Bottom;

            IntPtr hdc;
            IntPtr brush;
            IntPtr oldbrush;
            COLORREF clrRef = new COLORREF();

            clrRef.R = backColor.R;
            clrRef.G = backColor.G;
            clrRef.B = backColor.B;

            // Grab a brush
            brush = Win32CreateSolidBrush(clrRef);

            hdc = Win32GetDC(IntPtr.Zero);
            oldbrush = Win32SelectObject(hdc, brush);

            Win32PatBlt(hdc, rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height, PatBltRop.DSTINVERT);

            Win32SelectObject(hdc, oldbrush);
            Win32DeleteObject(brush);

            Win32ReleaseDC(IntPtr.Zero, hdc);
        }

        internal override void DrawReversibleRectangle(IntPtr handle, Rectangle rect, int line_width)
        {
            IntPtr hdc;
            IntPtr pen;
            IntPtr oldpen;
            POINT pt;

            pt = new POINT();
            pt.x = 0;
            pt.y = 0;
            Win32ClientToScreen(handle, ref pt);

            // If we want the standard hatch pattern we would
            // need to create a brush

            // Grab a pen
            pen = Win32CreatePen(PenStyle.PS_SOLID, line_width, IntPtr.Zero);

            hdc = Win32GetDC(IntPtr.Zero);
            Win32SetROP2(hdc, ROP2DrawMode.R2_NOT);
            oldpen = Win32SelectObject(hdc, pen);

            Widget c = Widget.FromHandle(handle);
            if (c != null)
            {
                RECT window_rect;
                Win32GetWindowRect(c.Handle, out window_rect);
                Region r = new Region(new Rectangle(window_rect.left, window_rect.top, window_rect.right - window_rect.left, window_rect.bottom - window_rect.top));
                Win32ExtSelectClipRgn(hdc, r.GetHrgn(Graphics.FromHdc(hdc)), (int)ClipCombineMode.RGN_AND);
            }

            Win32MoveToEx(hdc, pt.x + rect.Left, pt.y + rect.Top, IntPtr.Zero);
            if ((rect.Width > 0) && (rect.Height > 0))
            {
                Win32LineTo(hdc, pt.x + rect.Right, pt.y + rect.Top);
                Win32LineTo(hdc, pt.x + rect.Right, pt.y + rect.Bottom);
                Win32LineTo(hdc, pt.x + rect.Left, pt.y + rect.Bottom);
                Win32LineTo(hdc, pt.x + rect.Left, pt.y + rect.Top);
            }
            else
            {
                if (rect.Width > 0)
                {
                    Win32LineTo(hdc, pt.x + rect.Right, pt.y + rect.Top);
                }
                else
                {
                    Win32LineTo(hdc, pt.x + rect.Left, pt.y + rect.Bottom);
                }
            }

            Win32SelectObject(hdc, oldpen);
            Win32DeleteObject(pen);
            if (c != null)
                Win32ExtSelectClipRgn(hdc, IntPtr.Zero, (int)ClipCombineMode.RGN_COPY);

            Win32ReleaseDC(IntPtr.Zero, hdc);
        }

        internal override SizeF GetAutoScaleSize(Font font)
        {
            Graphics g;
            float width;
            string magic_string = "The quick brown fox jumped over the lazy dog.";
            double magic_number = 44.549996948242189;

            g = Graphics.FromHwnd(GetFosterParent());

            width = (float)(g.MeasureString(magic_string, font).Width / magic_number);
            return new SizeF(width, font.Height);
        }

        internal override IntPtr SendMessage(IntPtr hwnd, Msg message, IntPtr wParam, IntPtr lParam)
        {
            return Win32SendMessage(hwnd, message, wParam, lParam);
        }

        internal override bool PostMessage(IntPtr hwnd, Msg message, IntPtr wParam, IntPtr lParam)
        {
            return Win32PostMessage(hwnd, message, wParam, lParam);
        }

        internal override int SendInput(IntPtr hwnd, Queue keys)
        {
            INPUT[] inputs = new INPUT[keys.Count];
            const Int32 INPUT_KEYBOARD = 1;
            uint returns = 0;
            int i = 0;
            while (keys.Count > 0)
            {
                MSG msg = (MSG)keys.Dequeue();


                inputs[i].ki.wScan = 0;
                inputs[i].ki.time = 0;
                inputs[i].ki.dwFlags = (Int32)(msg.message == Msg.WM_KEYUP ? InputFlags.KEYEVENTF_KEYUP : 0);
                inputs[i].ki.wVk = (short)msg.wParam.ToInt32();
                inputs[i].type = INPUT_KEYBOARD;
                i++;
            }
            returns = Win32SendInput((UInt32)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));

            return (int)returns;
        }

        internal override int KeyboardSpeed
        {
            get
            {
                int speed = 0;
                Win32SystemParametersInfo(SPIAction.SPI_GETKEYBOARDSPEED, 0, ref speed, 0);
                //
                // Return values range from 0 to 31 which map to 2.5 to 30 repetitions per second.
                //
                return speed;
            }
        }

        internal override int KeyboardDelay
        {
            get
            {
                int delay = 1;
                Win32SystemParametersInfo(SPIAction.SPI_GETKEYBOARDDELAY, 0, ref delay, 0);
                //
                // Return values must range from 0 to 4, 0 meaning 250ms,
                // and 4 meaning 1000 ms.
                //
                return delay;
            }
        }

        private class WinBuffer
        {
            public IntPtr hdc;
            public IntPtr bitmap;

            public WinBuffer(IntPtr hdc, IntPtr bitmap)
            {
                this.hdc = hdc;
                this.bitmap = bitmap;
            }
        }

        internal override void CreateOffscreenDrawable(IntPtr handle, int width, int height, out object offscreen_drawable)
        {
            Graphics destG = Graphics.FromHwnd(handle);
            IntPtr destHdc = destG.GetHdc();

            IntPtr srcHdc = Win32CreateCompatibleDC(destHdc);
            IntPtr srcBmp = Win32CreateCompatibleBitmap(destHdc, width, height);
            Win32SelectObject(srcHdc, srcBmp);

            offscreen_drawable = new WinBuffer(srcHdc, srcBmp);

            destG.ReleaseHdc(destHdc);
        }

        internal override Graphics GetOffscreenGraphics(object offscreen_drawable)
        {
            return Graphics.FromHdc(((WinBuffer)offscreen_drawable).hdc);
        }

        internal override void BlitFromOffscreen(IntPtr dest_handle, Graphics dest_dc, object offscreen_drawable, Graphics offscreen_dc, Rectangle r)
        {
            WinBuffer wb = (WinBuffer)offscreen_drawable;

            IntPtr destHdc = dest_dc.GetHdc();
            Win32BitBlt(destHdc, r.Left, r.Top, r.Width, r.Height, wb.hdc, r.Left, r.Top, TernaryRasterOperations.SRCCOPY);
            dest_dc.ReleaseHdc(destHdc);
        }

        internal override void DestroyOffscreenDrawable(object offscreen_drawable)
        {
            WinBuffer wb = (WinBuffer)offscreen_drawable;

            Win32DeleteObject(wb.bitmap);
            Win32DeleteDC(wb.hdc);
        }

        internal override void SetForegroundWindow(IntPtr handle)
        {
            Win32SetForegroundWindow(handle);
        }

        internal override event EventHandler Idle;
#endregion    // Public Static Methods
        
    }
}
#endregion
#endif