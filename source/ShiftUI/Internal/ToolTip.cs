// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (c) 2004 Novell, Inc. (http://www.novell.com)
//
// Authors:
//	Peter Bartok	pbartok@novell.com
//
//

using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using ShiftUI;
using System;

namespace ShiftUI {
	[DefaultEvent ("Popup")]
	[ProvideProperty ("ToolTip", typeof(Widget))]
	[ToolboxItemFilter("ShiftUI", ToolboxItemFilterType.Allow)]
	public class ToolTip : System.ComponentModel.Component, System.ComponentModel.IExtenderProvider {
		#region Local variables
		internal bool		is_active;
		internal int		automatic_delay;
		internal int		autopop_delay;
		internal int		initial_delay;
		internal int		re_show_delay;
		internal bool		show_always;

		internal Color		back_color;
		internal Color		fore_color;
		
		internal ToolTipWindow	tooltip_window;			// The actual tooltip window
		internal Hashtable	tooltip_strings;		// List of strings for each Widget, indexed by Widget
		internal ArrayList	Widgets;
		internal Widget	active_Widget;			// Widget for which the tooltip is currently displayed
		internal Widget	last_Widget;			// last Widget the mouse was in
		internal Timer		timer;				// Used for the various intervals
		private Form		hooked_form;

		private bool isBalloon;
		private bool owner_draw;
		private bool stripAmpersands;
		private ToolTipIcon tool_tip_icon;
		private bool useAnimation;
		private bool useFading;
		private object tag;

		#endregion	// Local variables

		#region ToolTipWindow Class
		internal class ToolTipWindow : Widget {
			#region ToolTipWindow Class Local Variables
			private Widget associated_Widget;
			internal Icon icon;
			internal string title = String.Empty;
			internal Rectangle icon_rect;
			internal Rectangle title_rect;
			internal Rectangle text_rect;
			#endregion	// ToolTipWindow Class Local Variables
			
			#region ToolTipWindow Class Constructor
			internal ToolTipWindow() {
				Visible = false;
				Size = new Size(100, 20);
				ForeColor = ThemeEngine.Current.ColorInfoText;
				BackColor = ThemeEngine.Current.ColorInfo;

				VisibleChanged += new EventHandler(ToolTipWindow_VisibleChanged);

				// UIA Framework: Used to generate UnPopup
				VisibleChanged += new EventHandler (OnUIAToolTip_VisibleChanged);

				SetStyle (Widgetstyles.UserPaint | Widgetstyles.AllPaintingInWmPaint, true);
				SetStyle (Widgetstyles.ResizeRedraw, true);
				if (ThemeEngine.Current.ToolTipTransparentBackground) {
					SetStyle (Widgetstyles.SupportsTransparentBackColor, true);
					BackColor = Color.Transparent;
				} else
					SetStyle (Widgetstyles.Opaque, true);
			}

			#endregion	// ToolTipWindow Class Constructor

			#region ToolTipWindow Class Protected Instance Methods
			protected override void OnCreateWidget() {
				base.OnCreateWidget ();
				XplatUI.SetTopmost(this.window.Handle, true);
			}

			protected override CreateParams CreateParams {
				get {
					CreateParams cp;

					cp = base.CreateParams;

					cp.Style = (int)WindowStyles.WS_POPUP;
					cp.Style |= (int)WindowStyles.WS_CLIPSIBLINGS;

					cp.ExStyle = (int)(WindowExStyles.WS_EX_TOOLWINDOW | WindowExStyles.WS_EX_TOPMOST);

					return cp;
				}
			}

			protected override void OnPaint(PaintEventArgs pevent) {
				// We don't do double-buffering on purpose:
				// 1) we'd have to meddle with is_visible, it destroys the buffers if !visible
				// 2) We don't draw much, no need to double buffer
				base.OnPaint(pevent);

				OnDraw (new DrawToolTipEventArgs (pevent.Graphics, associated_Widget, associated_Widget, ClientRectangle, this.Text, this.BackColor, this.ForeColor, this.Font));
			}

			protected override void OnTextChanged (EventArgs args)
			{
				Invalidate ();
				base.OnTextChanged (args); 
			}

			protected override void WndProc(ref Message m) {
				if (m.Msg == (int)Msg.WM_SETFOCUS) {
					if (m.WParam != IntPtr.Zero) {
						XplatUI.SetFocus(m.WParam);
					}
				}
				base.WndProc (ref m);
			}


			#endregion	// ToolTipWindow Class Protected Instance Methods

			#region ToolTipWindow Class Private Methods
			internal virtual void OnDraw (DrawToolTipEventArgs e)
			{
				DrawToolTipEventHandler eh = (DrawToolTipEventHandler)(Events[DrawEvent]);
				if (eh != null)
					eh (this, e);
				else
					ThemeEngine.Current.DrawToolTip (e.Graphics, e.Bounds, this);
			}
			
			internal virtual void OnPopup (PopupEventArgs e)
			{
				PopupEventHandler eh = (PopupEventHandler)(Events[PopupEvent]);
				if (eh != null)
					eh (this, e);
				else
					e.ToolTipSize = ThemeEngine.Current.ToolTipSize (this, Text);
			}

			private void ToolTipWindow_VisibleChanged(object sender, EventArgs e) {
				Widget Widget = (Widget)sender;

				if (Widget.is_visible) {
					XplatUI.SetTopmost(Widget.window.Handle, true);
				} else {
					XplatUI.SetTopmost(Widget.window.Handle, false);
				}
			}

			// UIA Framework
			private void OnUIAToolTip_VisibleChanged (object sender, EventArgs e)
			{
				if (Visible == false) 
					OnUnPopup (new PopupEventArgs (associated_Widget, associated_Widget, false, Size.Empty));
			}

			private void OnUnPopup (PopupEventArgs e)
			{
				PopupEventHandler eh = (PopupEventHandler) (Events [UnPopupEvent]);
				if (eh != null)
					eh (this, e);
			}


			#endregion	// ToolTipWindow Class Protected Instance Methods

			#region Internal Properties
			internal override bool ActivateOnShow { get { return false; } }
			#endregion

			// This Present is used when we are using the expicit Show methods for 2.0.
			// It will not reposition the window.
			public void PresentModal (Widget Widget, string text)
			{
				if (IsDisposed)
					return;

				Size display_size;
				XplatUI.GetDisplaySize (out display_size);

				associated_Widget = Widget;

				Text = text;

				PopupEventArgs pea = new PopupEventArgs (Widget, Widget, false, Size.Empty);
				OnPopup (pea);

				if (pea.Cancel)
					return;

				Size = pea.ToolTipSize;

				Visible = true;
			}
		
			public void Present (Widget Widget, string text)
			{
				if (IsDisposed)
					return;

				Size display_size;
				XplatUI.GetDisplaySize (out display_size);

				associated_Widget = Widget;

				Text = text;

				PopupEventArgs pea = new PopupEventArgs (Widget, Widget, false, Size.Empty);
				OnPopup (pea);
				
				if (pea.Cancel)
					return;
					
				Size size = pea.ToolTipSize;

				Width = size.Width;
				Height = size.Height;

				int cursor_w, cursor_h, hot_x, hot_y;
				XplatUI.GetCursorInfo (Widget.Cursor.Handle, out cursor_w, out cursor_h, out hot_x, out hot_y);
				Point loc = Widget.MousePosition;
				loc.Y += (cursor_h - hot_y);

				if ((loc.X + Width) > display_size.Width)
					loc.X = display_size.Width - Width;

				if ((loc.Y + Height) > display_size.Height)
					loc.Y = Widget.MousePosition.Y - Height - hot_y;
				
				Location = loc;
				Visible = true;
				BringToFront ();
			}


			#region Internal Events
			static object DrawEvent = new object ();
			static object PopupEvent = new object ();
	
			// UIA Framework
			static object UnPopupEvent = new object ();

			public event DrawToolTipEventHandler Draw {
				add { Events.AddHandler (DrawEvent, value); }
				remove { Events.RemoveHandler (DrawEvent, value); }
			}

			public event PopupEventHandler Popup {
				add { Events.AddHandler (PopupEvent, value); }
				remove { Events.RemoveHandler (PopupEvent, value); }
			}

			internal event PopupEventHandler UnPopup {
				add { Events.AddHandler (UnPopupEvent, value); }
				remove { Events.RemoveHandler (UnPopupEvent, value); }
			}
			#endregion
		}
		#endregion	// ToolTipWindow Class

		#region Public Constructors & Destructors
		public ToolTip() {

			// Defaults from MS
			is_active = true;
			automatic_delay = 500;
			autopop_delay = 5000;
			initial_delay = 500;
			re_show_delay = 100;
			show_always = false;
			back_color = SystemColors.Info;
			fore_color = SystemColors.InfoText;
			
			isBalloon = false;
			stripAmpersands = false;
			useAnimation = true;
			useFading = true;
			tooltip_strings = new Hashtable(5);
			Widgets = new ArrayList(5);

			tooltip_window = new ToolTipWindow();
			tooltip_window.MouseLeave += new EventHandler(Widget_MouseLeave);
			tooltip_window.Draw += new DrawToolTipEventHandler (tooltip_window_Draw);
			tooltip_window.Popup += new PopupEventHandler (tooltip_window_Popup);

			// UIA Framework: Static event handlers
			tooltip_window.UnPopup += delegate (object sender, PopupEventArgs args) {
				OnUnPopup (args);
			};
			UnPopup += new PopupEventHandler (OnUIAUnPopup);

			timer = new Timer();
			timer.Enabled = false;
			timer.Tick +=new EventHandler(timer_Tick);

		}


		#region UIA Framework: Events, Delegates and Methods
		// NOTE: 
		//	We are using Reflection to add/remove internal events.
		//      Class ToolTipListener uses the events.
		//
		//	- UIAUnPopup. Event used to generate ChildRemoved in ToolTip
		//	- UIAToolTipHookUp. Event used to keep track of associated Widgets
		//	- UIAToolTipUnhookUp. Event used to remove track of associated Widgets
		static object UnPopupEvent = new object ();

		internal event PopupEventHandler UnPopup {
			add { Events.AddHandler (UnPopupEvent, value); }
			remove { Events.RemoveHandler (UnPopupEvent, value); }
		}

		internal static event PopupEventHandler UIAUnPopup;
		internal static event WidgetEventHandler UIAToolTipHookUp;
		internal static event WidgetEventHandler UIAToolTipUnhookUp;

		internal Rectangle UIAToolTipRectangle {
			get { return tooltip_window.Bounds; }
		}

		internal static void OnUIAUnPopup (object sender, PopupEventArgs args)
		{
			if (UIAUnPopup != null)
				UIAUnPopup (sender, args);
		}

		internal static void OnUIAToolTipHookUp (object sender, WidgetEventArgs args)
		{
			if (UIAToolTipHookUp != null)
				UIAToolTipHookUp (sender, args);
		}

		internal static void OnUIAToolTipUnhookUp (object sender, WidgetEventArgs args)
		{
			if (UIAToolTipUnhookUp != null)
				UIAToolTipUnhookUp (sender, args);
		}

		#endregion

		public ToolTip(System.ComponentModel.IContainer cont) : this() {
			cont.Add (this);
		}

		~ToolTip() {
		}
		#endregion	// Public Constructors & Destructors

		#region Public Instance Properties
		[DefaultValue (true)]
		public bool Active {
			get {
				return is_active;
			}

			set {
				if (is_active != value) {
					is_active = value;

					if (tooltip_window.Visible) {
						tooltip_window.Visible = false;
						active_Widget = null;
					}
				}
			}
		}

		[DefaultValue (500)]
		[RefreshProperties (RefreshProperties.All)]
		public int AutomaticDelay {
			get {
				return automatic_delay;
			}

			set {
				if (automatic_delay != value) {
					automatic_delay = value;
					autopop_delay = automatic_delay * 10;
					initial_delay = automatic_delay;
					re_show_delay = automatic_delay / 5;
				}
			}
		}

		[RefreshProperties (RefreshProperties.All)]
		public int AutoPopDelay {
			get {
				return autopop_delay;
			}

			set {
				if (autopop_delay != value) {
					autopop_delay = value;
				}
			}
		}

		[DefaultValue ("Color [Info]")]
		public Color BackColor {
			get { return this.back_color; }
			set { this.back_color = value; tooltip_window.BackColor = value; }
		}

		[DefaultValue ("Color [InfoText]")]
		public Color ForeColor
		{
			get { return this.fore_color; }
			set { this.fore_color = value; tooltip_window.ForeColor = value; }
		}

		[RefreshProperties (RefreshProperties.All)]
		public int InitialDelay {
			get {
				return initial_delay;
			}

			set {
				if (initial_delay != value) {
					initial_delay = value;
				}
			}
		}

		[DefaultValue (false)]
		public bool OwnerDraw {
			get { return this.owner_draw; }
			set { this.owner_draw = value; }
		}

		[RefreshProperties (RefreshProperties.All)]
		public int ReshowDelay {
			get {
				return re_show_delay;
			}

			set {
				if (re_show_delay != value) {
					re_show_delay = value;
				}
			}
		}

		[DefaultValue (false)]
		public bool ShowAlways {
			get {
				return show_always;
			}

			set {
				if (show_always != value) {
					show_always = value;
				}
			}
		}


		[DefaultValue (false)]
		public bool IsBalloon {
			get { return isBalloon; }
			set { isBalloon = value; }
		}

		[Browsable (true)]
		[DefaultValue (false)]
		public bool StripAmpersands {
			get { return stripAmpersands; }
			set { stripAmpersands = value; }
		}

		[Localizable (false)]
		[Bindable (true)]
		[TypeConverter (typeof (StringConverter))]
		[DefaultValue (null)]
		public object Tag {
			get { return tag; }
			set { tag = value; }
		}

		[DefaultValue (ToolTipIcon.None)]
		public ToolTipIcon ToolTipIcon {
			get { return this.tool_tip_icon; }
			set {
				switch (value) {
					case ToolTipIcon.None:
						tooltip_window.icon = null;
						break;
					case ToolTipIcon.Error:
						tooltip_window.icon = SystemIcons.Error;
						break;
					case ToolTipIcon.Warning:
						tooltip_window.icon = SystemIcons.Warning;
						break;
					case ToolTipIcon.Info:
						tooltip_window.icon = SystemIcons.Information;
						break;
				}

				tool_tip_icon = value;
		       	}
		}
		
		[DefaultValue ("")]
		public string ToolTipTitle {
			get { return tooltip_window.title; }
			set {
			       if (value == null)
				       value = String.Empty;
			       
			       tooltip_window.title = value; 
			}
		}
		
		[Browsable (true)]
		[DefaultValue (true)]
		public bool UseAnimation {
			get { return useAnimation; }
			set { useAnimation = value; }
		}

		[Browsable (true)]
		[DefaultValue (true)]
		public bool UseFading {
			get { return useFading; }
			set { useFading = value; }
		}

		#endregion	// Public Instance Properties

		#region Protected Properties
		protected virtual CreateParams CreateParams
		{
			get
			{
				CreateParams cp = new CreateParams ();

				cp.Style = 2;

				return cp;
			}
		}
		#endregion

		#region Public Instance Methods
		public bool CanExtend(object target) {
			return false;
		}

		[Localizable (true)]
		[DefaultValue ("")]
		public string GetToolTip (Widget Widget)
		{
			string tooltip = (string)tooltip_strings[Widget];
			if (tooltip == null)
				return "";
			return tooltip;
		}

		public void RemoveAll() {
			tooltip_strings.Clear();
			//UIA Framework: ToolTip isn't associated anymore
			foreach (Widget Widget in Widgets)
				OnUIAToolTipUnhookUp (this, new WidgetEventArgs (Widget));

			Widgets.Clear();
		}

		public void SetToolTip(Widget Widget, string caption) {
			// UIA Framework
			OnUIAToolTipHookUp (this, new WidgetEventArgs (Widget));
			tooltip_strings[Widget] = caption;

			// no need for duplicates
			if (!Widgets.Contains(Widget)) {
				Widget.MouseEnter += new EventHandler(Widget_MouseEnter);
				Widget.MouseMove += new MouseEventHandler(Widget_MouseMove);
				Widget.MouseLeave += new EventHandler(Widget_MouseLeave);
				Widget.MouseDown += new MouseEventHandler (Widget_MouseDown);
				Widgets.Add(Widget);
			}
			
			// if SetToolTip is called from a Widget and the mouse is currently over that Widget,
			// make sure that tooltip_window.Text gets updated if it's being shown,
			// or show the tooltip for it if is not
			if (active_Widget == Widget && caption != null && state == TipState.Show) {
				Size size = ThemeEngine.Current.ToolTipSize(tooltip_window, caption);
				tooltip_window.Width = size.Width;
				tooltip_window.Height = size.Height;
				tooltip_window.Text = caption;
				timer.Stop ();
				timer.Start ();
			} else if (Widget.IsHandleCreated && MouseInWidget (Widget, false))
				ShowTooltip (Widget);
		}

		public override string ToString() {
			return base.ToString() + " InitialDelay: " + initial_delay + ", ShowAlways: " + show_always;
		}

		public void Show (string text, IWin32Window window)
		{
			Show (text, window, 0);
		}

		public void Show (string text, IWin32Window window, int duration)
		{
			if (window == null)
				throw new ArgumentNullException ("window");
			if (duration < 0)
				throw new ArgumentOutOfRangeException ("duration", "duration cannot be less than zero");

			if (!Active)
				return;
				
			timer.Stop ();
			
			Widget c = (Widget)window;

			XplatUI.SetOwner (tooltip_window.Handle, c.TopLevelWidget.Handle);
			
			// If the mouse is in the requested window, use that position
			// Else, center in the requested window
			if (c.ClientRectangle.Contains (c.PointToClient (Widget.MousePosition))) {
				tooltip_window.Location = Widget.MousePosition;
				tooltip_strings[c] = text;
				HookupWidgetEvents (c);
			}
			else
				tooltip_window.Location = c.PointToScreen (new Point (c.Width / 2, c.Height / 2));
			
			// We need to hide our tooltip if the form loses focus, is closed, or is minimized
			HookupFormEvents ((Form)c.TopLevelWidget);
			
			tooltip_window.PresentModal ((Widget)window, text);
			
			state = TipState.Show;
			
			if (duration > 0) {
				timer.Interval = duration;
				timer.Start ();
			}
		}
		
		public void Show (string text, IWin32Window window, Point point)
		{
			Show (text, window, point, 0);
		}

		public void Show (string text, IWin32Window window, int x, int y)
		{
			Show (text, window, new Point (x, y), 0);
		}
		
		public void Show (string text, IWin32Window window, Point point, int duration)
		{
			if (window == null)
				throw new ArgumentNullException ("window");
			if (duration < 0)
				throw new ArgumentOutOfRangeException ("duration", "duration cannot be less than zero");

			if (!Active)
				return;

			timer.Stop ();

			Widget c = (Widget)window;
			
			Point display_point = c.PointToScreen (Point.Empty);
			display_point.X += point.X;
			display_point.Y += point.Y;

			XplatUI.SetOwner (tooltip_window.Handle, c.TopLevelWidget.Handle);

			// We need to hide our tooltip if the form loses focus, is closed, or is minimized
			HookupFormEvents ((Form)c.TopLevelWidget);

			tooltip_window.Location = display_point;
			tooltip_window.PresentModal ((Widget)window, text);

			state = TipState.Show;
			
			if (duration > 0) {
				timer.Interval = duration;
				timer.Start ();
			}
		}
		
		public void Show (string text, IWin32Window window, int x, int y, int duration)
		{
			Show (text, window, new Point (x, y), duration);
		}
		
		public void Hide (IWin32Window win)
 		{
			timer.Stop ();
			state = TipState.Initial;

			UnhookFormEvents ();
			tooltip_window.Visible = false;
		}
		#endregion	// Public Instance Methods

		#region Protected Instance Methods
		protected override void Dispose(bool disposing) {
			// call the base impl first to avoid conflicts with any parent's events
			base.Dispose (disposing);

			if (disposing) {
				// Mop up the mess; or should we wait for the GC to kick in?
				timer.Stop();
				timer.Dispose();

				// Not sure if we should clean up tooltip_window
				tooltip_window.Dispose();

				tooltip_strings.Clear();
				
				//UIA Framework: ToolTip isn't associated anymore
				foreach (Widget Widget in Widgets)
					OnUIAToolTipUnhookUp (this, new WidgetEventArgs (Widget));
				Widgets.Clear();
			}
		}

		protected void StopTimer ()
		{
			timer.Stop ();
		}
		#endregion	// Protected Instance Methods

		internal enum TipState {
			Initial,
			Show,
			Down
		}

		TipState state = TipState.Initial;

		#region Private Methods

		private void HookupFormEvents (Form form)
		{
			hooked_form = form;

			form.Deactivate += new EventHandler (Form_Deactivate);
			form.Closed += new EventHandler (Form_Closed);
			form.Resize += new EventHandler (Form_Resize);
		}

		private void HookupWidgetEvents (Widget widget)
		{
			if (!Widgets.Contains (widget)) {
				widget.MouseEnter += new EventHandler (Widget_MouseEnter);
				widget.MouseMove += new MouseEventHandler (Widget_MouseMove);
				widget.MouseLeave += new EventHandler (Widget_MouseLeave);
				widget.MouseDown += new MouseEventHandler (Widget_MouseDown);
				Widgets.Add (widget);
			}
		}

		private void UnhookWidgetEvents (Widget widget)
		{
			widget.MouseEnter -= new EventHandler (Widget_MouseEnter);
			widget.MouseMove -= new MouseEventHandler (Widget_MouseMove);
			widget.MouseLeave -= new EventHandler (Widget_MouseLeave);
			widget.MouseDown -= new MouseEventHandler (Widget_MouseDown);
		}
		private void UnhookFormEvents ()
		{
			if (hooked_form == null)
				return;

			hooked_form.Deactivate -= new EventHandler (Form_Deactivate);
			hooked_form.Closed -= new EventHandler (Form_Closed);
			hooked_form.Resize -= new EventHandler (Form_Resize);

			hooked_form = null;
		}


		private void Form_Resize (object sender, EventArgs e)
		{
			Form f = (Form)sender;

			if (f.WindowState == FormWindowState.Minimized)
				tooltip_window.Visible = false;
		}

		private void Form_Closed (object sender, EventArgs e)
		{
			tooltip_window.Visible = false;
		}

		private void Form_Deactivate (object sender, EventArgs e)
		{
			tooltip_window.Visible = false;
		}

		internal void Present (Widget Widget, string text)
		{
			tooltip_window.Present (Widget, text);
		}
		
		private void Widget_MouseEnter (object sender, EventArgs e) 
		{
			ShowTooltip (sender as Widget);
		}

		private void ShowTooltip (Widget Widget) 
		{
			last_Widget = Widget;

			// Whatever we're displaying right now, we don't want it anymore
			tooltip_window.Visible = false;
			timer.Stop();
			state = TipState.Initial;

			if (!is_active)
				return;

			// ShowAlways Widgets whether the Widgets in non-active forms
			// can display its tooltips, even if they are not current active Widget.
			if (!show_always && Widget.FindForm () != Form.ActiveForm)
				return;

			string text = (string)tooltip_strings[Widget];
			if (text != null && text.Length > 0) {
				if (active_Widget == null) {
					timer.Interval = Math.Max (initial_delay, 1);
				} else {
					timer.Interval = Math.Max (re_show_delay, 1);
				}

				active_Widget = Widget;
				timer.Start ();
			}
		}

		private void timer_Tick(object sender, EventArgs e) {
			timer.Stop();

			switch (state) {
			case TipState.Initial:
				if (active_Widget == null)
					return;
				tooltip_window.Present (active_Widget, (string)tooltip_strings[active_Widget]);
				state = TipState.Show;
				timer.Interval = autopop_delay;
				timer.Start();
				break;

			case TipState.Show:
				tooltip_window.Visible = false;
				state = TipState.Down;
				break;

			default:
				throw new Exception ("Timer shouldn't be running in state: " + state);
			}
		}

		private void tooltip_window_Popup (object sender, PopupEventArgs e)
		{
			e.ToolTipSize = ThemeEngine.Current.ToolTipSize (tooltip_window, tooltip_window.Text);
			OnPopup (e);
		}

		private void tooltip_window_Draw (object sender, DrawToolTipEventArgs e)
		{
			if (OwnerDraw)
				OnDraw (e);
			else
				ThemeEngine.Current.DrawToolTip (e.Graphics, e.Bounds, tooltip_window);
		}
		
		private bool MouseInWidget (Widget Widget, bool fuzzy) {
			Point	m;
			Point	c;
			Size	cw;

			if (Widget == null) {
				return false;
			}

			m = Widget.MousePosition;
			c = new Point(Widget.Bounds.X, Widget.Bounds.Y);
			if (Widget.Parent != null) {
				c = Widget.Parent.PointToScreen(c);
			}
			cw = Widget.ClientSize;


			Rectangle rect = new Rectangle (c, cw);
			
			//
			// We won't get mouse move events on all platforms with the exact same
			// frequency, so cheat a bit.
			if (fuzzy)
				rect.Inflate (2, 2);

			return rect.Contains (m);
		}

		private void Widget_MouseLeave(object sender, EventArgs e) 
		{
			timer.Stop ();

			active_Widget = null;
			tooltip_window.Visible = false;

			if (last_Widget == sender)
				last_Widget = null;
		}


		void Widget_MouseDown (object sender, MouseEventArgs e)
		{
			timer.Stop();

			active_Widget = null;
			tooltip_window.Visible = false;
			
			if (last_Widget == sender)
				last_Widget = null;
		}

		private void Widget_MouseMove(object sender, MouseEventArgs e) {
			if (state != TipState.Down) {
				timer.Stop();
				timer.Start();
			}
		}

		internal void OnDraw (DrawToolTipEventArgs e)
		{
			DrawToolTipEventHandler eh = (DrawToolTipEventHandler)(Events[DrawEvent]);
			if (eh != null)
				eh (this, e);
		}

		internal void OnPopup (PopupEventArgs e)
		{
			PopupEventHandler eh = (PopupEventHandler) (Events [PopupEvent]);
			if (eh != null)
				eh (this, e);
		}

		internal void OnUnPopup (PopupEventArgs e)
		{
			PopupEventHandler eh = (PopupEventHandler) (Events [UnPopupEvent]);
			if (eh != null)
				eh (this, e);
		}
		
		internal bool Visible {
			get { return tooltip_window.Visible; }
		}
		#endregion	// Private Methods

		#region Events
		static object PopupEvent = new object ();
		static object DrawEvent = new object ();
		
		public event PopupEventHandler Popup {
			add { Events.AddHandler (PopupEvent, value); }
			remove { Events.RemoveHandler (PopupEvent, value); }
		}

		public event DrawToolTipEventHandler Draw {
			add { Events.AddHandler (DrawEvent, value); }
			remove { Events.RemoveHandler (DrawEvent, value); }
		}
		#endregion
	}
}
