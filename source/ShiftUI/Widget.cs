// The "Widget" class is based off the Windows Forms "Widget" class in
// the Mono framework. As some elements are unchanged, here's a
// copyright statement.

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
// Copyright (c) 2004-2006 Novell, Inc.
//
// Authors:
//	Peter Bartok		pbartok@novell.com
//
// Partially based on work by:
//	Aleksey Ryabchuk	ryabchuk@yahoo.com
//	Alexandre Pigolkine	pigolkine@gmx.de
//	Dennis Hayes		dennish@raytek.com
//	Jaak Simm		jaaksimm@firm.ee
//	John Sohn		jsohn@columbus.rr.com
//

#undef DebugRecreate
#undef DebugFocus
#undef DebugMessages

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using ShiftUI;
using System.Collections.Generic;
using System.Linq;

namespace ShiftUI
{
    public class ToolboxWidgetAttribute : Attribute
    {
        public ToolboxWidgetAttribute()
        {

        }
    }

	[ComVisible(true)]
	[ClassInterface (ClassInterfaceType.AutoDispatch)]
	[DefaultProperty("Text")]
	[DefaultEvent("Click")]
	[ToolboxItemFilter("ShiftUI")]
	public class Widget : Component, ISynchronizeInvoke, IWin32Window
	, IBindableComponent, IDropTarget, IBounds
	{
		#region Local Variables

        public static List<Type> GetAllToolboxWidgets()
        {
            var widget_list = new List<Type>();
            var typesWithToolboxAttribute =
    from a in AppDomain.CurrentDomain.GetAssemblies()
    from t in a.GetTypes()
    let attributes = t.GetCustomAttributes(typeof(ToolboxWidgetAttribute), true)
    where attributes != null && attributes.Length > 0
    select new { Type = t, Attributes = attributes.Cast<ToolboxWidgetAttribute>() };
            foreach (var t in typesWithToolboxAttribute)
            {
                widget_list.Add(t.Type);
            }
            return widget_list;
        }

		// Basic
		internal Rectangle		bounds;			// bounding rectangle for Widget (client area + decorations)
		Rectangle               explicit_bounds; // explicitly set bounds
		internal object			creator_thread;		// thread that created the Widget
		internal                WidgetNativeWindow	window;			// object for native window handle
		private                 IWindowTarget window_target;
		string                  name; // for object naming

		// State
		bool                    is_created; // true if OnCreateWidget has been sent
		internal bool		has_focus;		// true if Widget has focus
		internal bool		is_visible;		// true if Widget is visible
		internal bool		is_entered;		// is the mouse inside the Widget?
		internal bool		is_enabled;		// true if Widget is enabled (usable/not grayed out)
		bool                    is_accessible; // true if the Widget is visible to accessibility applications
		bool                    is_captured; // tracks if the Widget has captured the mouse
		internal bool			is_toplevel;		// tracks if the Widget is a toplevel window
		bool                    is_recreating; // tracks if the handle for the Widget is being recreated
		bool                    causes_validation; // tracks if validation is executed on changes
		bool                    is_focusing; // tracks if Focus has been called on the Widget and has not yet finished
		int                     tab_index; // position in tab order of siblings
		bool                    tab_stop; // is the Widget a tab stop?
		bool                    is_disposed; // has the window already been disposed?
		bool                    is_disposing; // is the window getting disposed?
		Size                    client_size; // size of the client area (window excluding decorations)
		Rectangle               client_rect; // rectangle with the client area (window excluding decorations)
		Widgetstyles           Widget_style; // rather win32-specific, style bits for Widget
		ImeMode                 ime_mode;
		object                  Widget_tag; // object that contains data about our Widget
		internal int			mouse_clicks;		// Counter for mouse clicks
		Cursor                  cursor; // Cursor for the window
		internal bool			allow_drop;		// true if the Widget accepts droping objects on it   
		Region                  clip_region; // User-specified clip region for the window

		// Visuals
		internal Color			foreground_color;	// foreground color for Widget
		internal Color			background_color;	// background color for Widget
		Image                   background_image; // background image for Widget
		internal Font			font;			// font for Widget
		string                  text; // window/title text for Widget
		internal                BorderStyle		border_style;		// Border style of Widget
		bool                    show_keyboard_cues; // Current keyboard cues 
		internal bool           show_focus_cues; // Current focus cues 
		internal bool		force_double_buffer;	// Always doublebuffer regardless of Widgetstyle

		// Layout
		internal enum LayoutType {
			Anchor,
			Dock
		}
		Layout.LayoutEngine layout_engine;
		internal int layout_suspended;
		bool layout_pending; // true if our parent needs to re-layout us
		internal AnchorStyles anchor_style; // anchoring requirements for our Widget
		internal DockStyle dock_style; // docking requirements for our Widget
		LayoutType layout_type;
		private bool recalculate_distances = true;  // Delay anchor calculations

		// Please leave the next 2 as internal until DefaultLayout (2.0) is rewritten
		internal int			dist_right; // distance to the right border of the parent
		internal int			dist_bottom; // distance to the bottom border of the parent

		// to be categorized...
		WidgetCollection       child_Widgets; // our children
		Widget                 parent; // our parent Widget
		BindingContext          binding_context;
		RightToLeft             right_to_left; // drawing direction for Widget
		//ContextMenu             context_menu; // FIXME: No.
		internal bool		use_compatible_text_rendering;
		private bool		use_wait_cursor;

		//accessibility
		string accessible_name;
		string accessible_description;
		string accessible_default_action;
		AccessibleRole accessible_role = AccessibleRole.Default;
		AccessibleObject accessibility_object; // object that contains accessibility information about our Widget

		// double buffering
		DoubleBuffer            backbuffer;

		WidgetBindingsCollection data_bindings;

		static bool verify_thread_handle;
		Padding padding;
		ImageLayout backgroundimage_layout;
		Size maximum_size;
		Size minimum_size;
		Padding margin;
		private ContextMenuStrip context_menu_strip;
		private bool nested_layout = false;
		Point auto_scroll_offset;
		private AutoSizeMode auto_size_mode;
		private bool suppressing_key_press;
		private ContentAlignment alignment;

		#endregion	// Local Variables

		public ContentAlignment Alignment {
			get {
				return alignment;
			}
			set {
				alignment = value;
			}
		}

		#region Private Classes
		// This helper class allows us to dispatch messages to Widget.WndProc
		internal class WidgetNativeWindow : NativeWindow {
			private Widget owner;

			public WidgetNativeWindow(Widget Widget) : base() {
				this.owner=Widget;
			}


			public Widget Owner {
				get {
					return owner;
				}
			}

			protected override void OnHandleChange()
			{
				this.owner.WindowTarget.OnHandleChange(this.owner.Handle);
			}

			static internal Widget WidgetFromHandle(IntPtr hWnd) {
				WidgetNativeWindow	window;

				window = (WidgetNativeWindow)NativeWindow.FromHandle (hWnd);
				if (window != null) {
					return window.owner;
				}

				return null;
			}

			static internal Widget WidgetFromChildHandle (IntPtr handle) {
				WidgetNativeWindow	window;

				Hwnd hwnd = Hwnd.ObjectFromHandle (handle);
				while (hwnd != null) {
					window = (WidgetNativeWindow)NativeWindow.FromHandle (handle);
					if (window != null) {
						return window.owner;
					}
					hwnd = hwnd.Parent;
				}

				return null;
			}

			protected override void WndProc(ref Message m) {
				owner.WindowTarget.OnMessage(ref m);
			}
		}

		private class WidgetWindowTarget : IWindowTarget
		{
			private Widget Widget;

			public WidgetWindowTarget(Widget Widget)
			{
				this.Widget = Widget;
			}

			public void OnHandleChange(IntPtr newHandle) 
			{
			}

			public void OnMessage(ref Message m) 
			{
				Widget.WndProc(ref m);
			}
		}
		#endregion

		#region Public Classes
		[ComVisible(true)]
		public class WidgetAccessibleObject : AccessibleObject {
			IntPtr handle;

			#region WidgetAccessibleObject Constructors
			public WidgetAccessibleObject(Widget ownerWidget)
				: base (ownerWidget)
			{
				if (ownerWidget == null)
					throw new ArgumentNullException ("owner");

				handle = ownerWidget.Handle;
			}
			#endregion	// WidgetAccessibleObject Constructors

			#region WidgetAccessibleObject Public Instance Properties
			public override string DefaultAction {
				get {
					return base.DefaultAction;
				}
			}

			public override string Description {
				get {
					return base.Description;
				}
			}

			public IntPtr Handle {
				get {
					return handle;
				}

				set {
					// We don't want to let them set it
				}
			}

			public override string Help {
				get {
					return base.Help;
				}
			}

			public override string KeyboardShortcut {
				get {
					return base.KeyboardShortcut;
				}
			}

			public override string Name {
				get {
					return base.Name;
				}

				set {
					base.Name = value;
				}
			}

			public Widget Owner {
				get {
					return base.owner;
				}
			}

			public override AccessibleObject Parent {
				get {
					return base.Parent;
				}
			}


			public override AccessibleRole Role {
				get {
					return base.Role;
				}
			}
			#endregion	// WidgetAccessibleObject Public Instance Properties

			#region WidgetAccessibleObject Public Instance Methods
			public override int GetHelpTopic (out string fileName)
			{
				return base.GetHelpTopic (out fileName);
			}

			[MonoTODO ("Stub, does nothing")]
			public void NotifyClients (AccessibleEvents accEvent)
			{
			}

			[MonoTODO ("Stub, does nothing")]
			public void NotifyClients (AccessibleEvents accEvent, int childID)
			{
			}

			[MonoTODO ("Stub, does nothing")]
			public void NotifyClients (AccessibleEvents accEvent, int objectID, int childID)
			{
			}

			public override string ToString() {
				return "WidgetAccessibleObject: Owner = " + owner.ToString() + ", Text: " + owner.text;
			}

			#endregion	// WidgetAccessibleObject Public Instance Methods
		}

		private class DoubleBuffer : IDisposable
		{
			public Region InvalidRegion;
			private Stack real_graphics;
			private object back_buffer;
			private Widget parent;
			private bool pending_disposal;

			public DoubleBuffer (Widget parent) {
				this.parent = parent;
				real_graphics = new Stack ();
				int width = parent.Width;
				int height = parent.Height;

				if (width < 1) width = 1;
				if (height < 1) height = 1;

				XplatUI.CreateOffscreenDrawable (parent.Handle, width, height, out back_buffer);
				Invalidate ();
			}

			public void Blit (PaintEventArgs pe) {
				Graphics buffered_graphics;
				buffered_graphics = XplatUI.GetOffscreenGraphics (back_buffer);
				XplatUI.BlitFromOffscreen (parent.Handle, pe.Graphics, back_buffer, buffered_graphics, pe.ClipRectangle);
				buffered_graphics.Dispose ();
			}

			public void Start (PaintEventArgs pe) {
				// We need to get the graphics for every paint.
				real_graphics.Push(pe.SetGraphics (XplatUI.GetOffscreenGraphics (back_buffer)));
			}

			public void End (PaintEventArgs pe) {
				Graphics buffered_graphics;
				buffered_graphics = pe.SetGraphics ((Graphics) real_graphics.Pop ());

				if (pending_disposal) 
					Dispose ();
				else {
					XplatUI.BlitFromOffscreen (parent.Handle, pe.Graphics, back_buffer, buffered_graphics, pe.ClipRectangle);
					InvalidRegion.Exclude (pe.ClipRectangle);
				}
				buffered_graphics.Dispose ();
			}

			public void Invalidate ()
			{
				if (InvalidRegion != null)
					InvalidRegion.Dispose ();
				InvalidRegion = new Region (parent.ClientRectangle);
			}

			public void Dispose () {
				if (real_graphics.Count > 0) {
					pending_disposal = true;
					return;
				}

				XplatUI.DestroyOffscreenDrawable (back_buffer);

				if (InvalidRegion != null)
					InvalidRegion.Dispose ();
				InvalidRegion = null;
				back_buffer = null;
				GC.SuppressFinalize (this);
			}

			#region IDisposable Members
			void IDisposable.Dispose () {
				Dispose ();
			}
			#endregion

			~DoubleBuffer () {
				Dispose ();
			}
		}

		[ListBindable (false)]
		[ComVisible (false)]
		public class WidgetCollection : Layout.ArrangedElementCollection, IList, ICollection, ICloneable, IEnumerable {
			#region WidgetCollection Local Variables
			ArrayList impl_list;
			Widget [] all_Widgets;
			Widget owner;
			#endregion // WidgetCollection Local Variables

			#region WidgetCollection Public Constructor
			public WidgetCollection (Widget owner)
			{
				this.owner = owner;
			}
			#endregion

			#region WidgetCollection Public Instance Properties


			public Widget Owner {
				get { return this.owner; }
			}

			public virtual Widget this[string key] {
				get { 
					int index = IndexOfKey (key);

					if (index >= 0)
						return this[index];

					return null;
				}
			}

			new public virtual Widget this[int index] {
				get {
					if (index < 0 || index >= list.Count) {
						throw new ArgumentOutOfRangeException("index", index, "WidgetCollection does not have that many Widgets");
					}
					return (Widget)list[index];
				}


			}

			#endregion // WidgetCollection Public Instance Properties

			#region WidgetCollection Instance Methods

			public virtual void Add (Widget value)
			{
				if (value == null)
					return;

				Form form_value = value as Form;
				Form form_owner = owner as Form;
				bool owner_permits_toplevels = (owner is MdiClient) || (form_owner != null && form_owner.IsMdiContainer);
				bool child_is_toplevel = value.GetTopLevel();
				bool child_is_mdichild = form_value != null && form_value.IsMdiChild;

				if (child_is_toplevel && !(owner_permits_toplevels && child_is_mdichild))
					throw new ArgumentException("Cannot add a top level Widget to a Widget.", "value");

				if (child_is_mdichild && form_value.MdiParent != null && form_value.MdiParent != owner && form_value.MdiParent != owner.Parent) {
					throw new ArgumentException ("Form cannot be added to the Widgets collection that has a valid MDI parent.", "value");
				}

				value.recalculate_distances = true;

				if (Contains (value)) {
					owner.PerformLayout();
					return;
				}

				if (value.tab_index == -1) {
					int	end;
					int	index;
					int	use;

					use = 0;
					end = owner.child_Widgets.Count;
					for (int i = 0; i < end; i++) {
						index = owner.child_Widgets[i].tab_index;
						if (index >= use) {
							use = index + 1;
						}
					}
					value.tab_index = use;
				}

				if (value.parent != null) {
					value.parent.Widgets.Remove(value);
				}

				all_Widgets = null;
				list.Add (value);

				value.ChangeParent(owner);

				value.InitLayout();

				if (owner.Visible)
					owner.UpdateChildrenZOrder();
				owner.PerformLayout(value, "Parent");
				owner.OnWidgetAdded(new WidgetEventArgs(value));
			}

			internal void AddToList (Widget c)
			{
				all_Widgets = null;
				list.Add (c);
			}

			internal virtual void AddImplicit (Widget Widget)
			{
				if (impl_list == null)
					impl_list = new ArrayList ();

				if (AllContains (Widget)) {
					owner.PerformLayout ();
					return;
				}

				if (Widget.parent != null) {
					Widget.parent.Widgets.Remove(Widget);
				}

				all_Widgets = null;
				impl_list.Add (Widget);

				Widget.ChangeParent (owner);
				Widget.InitLayout ();
				if (owner.Visible)
					owner.UpdateChildrenZOrder ();

				// If we are adding a new Widget that isn't
				// visible, don't trigger a layout
				if (Widget.VisibleInternal)
					owner.PerformLayout (Widget, "Parent");
			}
			//[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
			public virtual void AddRange (Widget[] Widgets)
			{
				if (Widgets == null)
					throw new ArgumentNullException ("Widgets");

				owner.SuspendLayout ();

				try {
					for (int i = 0; i < Widgets.Length; i++) 
						Add (Widgets[i]);
				} finally {
					owner.ResumeLayout ();
				}
			}

			internal virtual void AddRangeImplicit (Widget [] Widgets)
			{
				if (Widgets == null)
					throw new ArgumentNullException ("Widgets");

				owner.SuspendLayout ();

				try {
					for (int i = 0; i < Widgets.Length; i++)
						AddImplicit (Widgets [i]);
				} finally {
					owner.ResumeLayout (false);
				}
			}

			new 
			public virtual void Clear ()
			{
				all_Widgets = null;

				// MS sends remove events in reverse order
				while (list.Count > 0) {
					Remove((Widget)list[list.Count - 1]);
				}
			}

			internal virtual void ClearImplicit ()
			{
				if (impl_list == null)
					return;
				all_Widgets = null;
				impl_list.Clear ();
			}

			public bool Contains (Widget Widget)
			{
				return list.Contains (Widget);
			}

			internal bool ImplicitContains (Widget value) {
				if (impl_list == null)
					return false;

				return impl_list.Contains (value);
			}

			internal bool AllContains (Widget value) {
				return Contains (value) || ImplicitContains (value);
			}


			public virtual bool ContainsKey (string key)
			{
				return IndexOfKey (key) >= 0;
			}


			// LAMESPEC: MSDN says AE, MS implementation throws ANE
			public Widget[] Find (string key, bool searchAllChildren)
			{
				if (string.IsNullOrEmpty (key))
					throw new ArgumentNullException ("key");

				ArrayList al = new ArrayList ();

				foreach (Widget c in list) {
					if (c.Name.Equals (key, StringComparison.CurrentCultureIgnoreCase))
						al.Add (c);

					if (searchAllChildren)
						al.AddRange (c.Widgets.Find (key, true));
				}

				return (Widget[])al.ToArray (typeof (Widget));
			}

			public int GetChildIndex(Widget child) {
				return GetChildIndex(child, false);
			}

			public virtual int GetChildIndex(Widget child, bool throwException) {
				int index;

				index=list.IndexOf(child);

				if (index==-1 && throwException) {
					throw new ArgumentException("Not a child Widget", "child");
				}
				return index;
			}

			public override IEnumerator
			GetEnumerator () {
				return new WidgetCollectionEnumerator (list);
			}

			internal IEnumerator GetAllEnumerator () {
				Widget [] res = GetAllWidgets ();
				return res.GetEnumerator ();
			}

			internal ArrayList ImplicitWidgets {
				get { return impl_list; }
			}

			internal Widget [] GetAllWidgets () {
				if (all_Widgets != null)
					return all_Widgets;

				if (impl_list == null) {
					all_Widgets = (Widget []) list.ToArray (typeof (Widget));
					return all_Widgets;
				}

				all_Widgets = new Widget [list.Count + impl_list.Count];
				impl_list.CopyTo (all_Widgets);
				list.CopyTo (all_Widgets, impl_list.Count);

				return all_Widgets;
			}

			public int IndexOf (Widget Widget)
			{
				return list.IndexOf (Widget);
			}

			public virtual int IndexOfKey (string key)
			{
				if (string.IsNullOrEmpty (key))
					return -1;

				for (int i = 0; i < list.Count; i++)
					if (((Widget)list[i]).Name.Equals (key, StringComparison.CurrentCultureIgnoreCase))
						return i;

				return -1;
			}

			public virtual void Remove (Widget value)
			{
				if (value == null || !list.Contains(value))
					return;

				all_Widgets = null;
				list.Remove(value);

				owner.PerformLayout(value, "Parent");
				owner.OnWidgetRemoved(new WidgetEventArgs(value));

				ContainerWidget container = owner.InternalGetContainerWidget ();
				if (container != null) { 
					// Inform any container Widgets about the loss of a child Widget
					// so that they can update their active Widget
					container.ChildWidgetRemoved (value);
				}

				value.ChangeParent(null);

				owner.UpdateChildrenZOrder();
			}

			internal virtual void RemoveImplicit (Widget Widget)
			{
				if (impl_list != null) {
					all_Widgets = null;
					impl_list.Remove (Widget);
					owner.PerformLayout (Widget, "Parent");
					owner.OnWidgetRemoved (new WidgetEventArgs (Widget));
				}
				Widget.ChangeParent (null);
				owner.UpdateChildrenZOrder ();
			}

			public void RemoveAt (int index)
			{
				if (index < 0 || index >= list.Count)
					throw new ArgumentOutOfRangeException("index", index, "WidgetCollection does not have that many Widgets");

				Remove ((Widget) list [index]);
			}

			public virtual void RemoveByKey (string key)
			{
				int index = IndexOfKey (key);

				if (index >= 0)
					RemoveAt (index);
			}

			public virtual void SetChildIndex(Widget child, int newIndex)
			{
				if (child == null)
					throw new ArgumentNullException ("child");

				int	old_index;

				old_index=list.IndexOf(child);
				if (old_index==-1) {
					throw new ArgumentException("Not a child Widget", "child");
				}

				if (old_index==newIndex) {
					return;
				}

				all_Widgets = null;
				list.RemoveAt(old_index);

				if (newIndex>list.Count) {
					list.Add(child);
				} else {
					list.Insert(newIndex, child);
				}
				child.UpdateZOrder();
				owner.PerformLayout();
			}

			#endregion // WidgetCollection Private Instance Methods

			#region WidgetCollection Interface Properties

			#endregion // WidgetCollection Interface Properties

			#region WidgetCollection Interface Methods

			int IList.Add (object Widget)
			{
				if (!(Widget is Widget))
					throw new ArgumentException ("Object of type Widget required", "Widget");

				if (Widget == null)
					throw new ArgumentException ("Widget", "Cannot add null Widgets");

				this.Add ((Widget)Widget);
				return this.IndexOf ((Widget)Widget);
			}

			void IList.Remove (object Widget)
			{
				if (!(Widget is Widget))
					throw new ArgumentException ("Object of type Widget required", "Widget");

				this.Remove ((Widget)Widget);
			}

			Object ICloneable.Clone ()
			{
				WidgetCollection clone = new WidgetCollection (this.owner);
				clone.list = (ArrayList)list.Clone ();		// FIXME: Do we need this?
				return clone;
			}

			#endregion // WidgetCollection Interface Methods

			internal class WidgetCollectionEnumerator : IEnumerator
			{
				private ArrayList list;
				int position = -1;

				public WidgetCollectionEnumerator (ArrayList collection)
				{
					list = collection;
				}

				#region IEnumerator Members
				public object Current {
					get {
						try {
							return list[position];
						} catch (IndexOutOfRangeException) {
							throw new InvalidOperationException ();
						}
					}
				}

				public bool MoveNext ()
				{
					position++;
					return (position < list.Count);
				}

				public void Reset ()
				{
					position = -1;
				}

				#endregion
			}
		}
		#endregion	// WidgetCollection Class

		#region Public Constructors
		public Widget ()
		{
			try {
			if (WindowsFormsSynchronizationContext.AutoInstall)
			if (!(SynchronizationContext.Current is WindowsFormsSynchronizationContext))
				SynchronizationContext.SetSynchronizationContext (new WindowsFormsSynchronizationContext ());
			}
			catch(Exception ex) {
				Console.WriteLine ("[ShiftUI] Error: {0}", ex.Message);
			}
			layout_type = LayoutType.Anchor;
			anchor_style = AnchorStyles.Top | AnchorStyles.Left;

			is_created = false;
			is_visible = true;
			is_captured = false;
			is_disposed = false;
			is_enabled = true;
			is_entered = false;
			layout_pending = false;
			is_toplevel = false;
			causes_validation = true;
			has_focus = false;
			layout_suspended = 0;
			mouse_clicks = 1;
			tab_index = -1;
			cursor = null;
			right_to_left = RightToLeft.Inherit;
			border_style = BorderStyle.None;
			background_color = Color.Empty;
			dist_right = 0;
			dist_bottom = 0;
			tab_stop = true;
			ime_mode = ImeMode.Inherit;
			use_compatible_text_rendering = true;
			show_keyboard_cues = false;
			show_focus_cues = SystemInformation.MenuAccessKeysUnderlined;
			use_wait_cursor = false;

			backgroundimage_layout = ImageLayout.Tile;
			use_compatible_text_rendering = Application.use_compatible_text_rendering;
			padding = this.DefaultPadding;
			maximum_size = new Size();
			minimum_size = new Size();
			margin = this.DefaultMargin;
			auto_size_mode = AutoSizeMode.GrowOnly;

			Widget_style = Widgetstyles.UserPaint | Widgetstyles.AllPaintingInWmPaint | 
				Widgetstyles.Selectable | Widgetstyles.StandardClick | 
				Widgetstyles.StandardDoubleClick;
			Widget_style |= Widgetstyles.UseTextForAccessibility;

			parent = null;
			background_image = null;
			text = string.Empty;
			name = string.Empty;

			window_target = new WidgetWindowTarget(this);
			window = new WidgetNativeWindow(this);
			child_Widgets = CreateWidgetsInstance();

			bounds.Size = DefaultSize;
			client_size = ClientSizeFromSize (bounds.Size);
			client_rect = new Rectangle (Point.Empty, client_size);
			explicit_bounds = bounds;
		}

		public Widget (Widget parent, string text) : this()
		{
			Text=text;
			Parent=parent;
		}

		public Widget (Widget parent, string text, int left, int top, int width, int height) : this()
		{
			Parent=parent;
			SetBounds(left, top, width, height, BoundsSpecified.All);
			Text=text;
		}

		public Widget (string text) : this()
		{
			Text=text;
		}

		public Widget (string text, int left, int top, int width, int height) : this()
		{
			SetBounds(left, top, width, height, BoundsSpecified.All);
			Text=text;
		}

		private delegate void RemoveDelegate(object c);

		protected override void Dispose (bool disposing)
		{
			if (!is_disposed && disposing) {
				is_disposing = true;
				Capture = false;

				DisposeBackBuffer ();

				if (this.InvokeRequired) {
					if (Application.MessageLoop && IsHandleCreated) {
						this.BeginInvokeInternal(new MethodInvoker(DestroyHandle), null);
					}
				} else {
					DestroyHandle();
				}

				if (parent != null)
					parent.Widgets.Remove(this);

				Widget [] children = child_Widgets.GetAllWidgets ();
				for (int i=0; i<children.Length; i++) {
					children[i].parent = null;	// Need to set to null or our child will try and remove from ourselves and crash
					children[i].Dispose();
				}
			}
			is_disposed = true;
			base.Dispose(disposing);
		}
		#endregion 	// Public Constructors

		#region Internal Properties

		internal Rectangle PaddingClientRectangle
		{
			get {
				return new Rectangle (
					ClientRectangle.Left   + padding.Left,
					ClientRectangle.Top    + padding.Top, 
					ClientRectangle.Width  - padding.Horizontal, 
					ClientRectangle.Height - padding.Vertical);
			}
		}

		private MenuTracker active_tracker;

		internal MenuTracker ActiveTracker {
			get { return active_tracker; }
			set {
				if (value == active_tracker)
					return;

				Capture = value != null;
				active_tracker = value;
			}
		}

		// Widget is currently selected, like Focused, except maintains state
		// when Form loses focus
		internal bool InternalSelected {
			get {
				IContainerWidget container;

				container = GetContainerWidget();

				if (container != null && container.ActiveWidget == this)
					return true;

				return false;
			}
		}

		// Looks for focus in child Widgets
		// and also in the implicit ones
		internal bool InternalContainsFocus {
			get {
				IntPtr focused_window;

				focused_window = XplatUI.GetFocus();
				if (IsHandleCreated) {
					if (focused_window == Handle)
						return true;

					foreach (Widget child_Widget in child_Widgets.GetAllWidgets ())
						if (child_Widget.InternalContainsFocus)
							return true;
				}

				return false;
			}
		}

		// Mouse is currently within the Widget's bounds
		internal bool Entered {
			get { return this.is_entered; }
		}

		internal bool VisibleInternal {
			get { return is_visible; }
		}

		internal LayoutType WidgetLayoutType {
			get { return layout_type; }
		}

		internal BorderStyle InternalBorderStyle {
			get {
				return border_style;
			}

			set {
				if (!Enum.IsDefined (typeof (BorderStyle), value))
					throw new InvalidEnumArgumentException (string.Format("Enum argument value '{0}' is not valid for BorderStyle", value));

				if (border_style != value) {
					border_style = value;

					if (IsHandleCreated) {
						XplatUI.SetBorderStyle (window.Handle, (FormBorderStyle)border_style);
						RecreateHandle ();
						Refresh ();
					} else
						client_size = ClientSizeFromSize (bounds.Size);
				}
			}
		}

		internal Size InternalClientSize { set { this.client_size = value; } }
		internal virtual bool ActivateOnShow { get { return true; } }
		internal Rectangle ExplicitBounds { get { return this.explicit_bounds; } set { this.explicit_bounds = value; } }

		internal bool ValidationFailed { 
			get { 
				ContainerWidget c = InternalGetContainerWidget ();
				if (c != null)
					return c.validation_failed;
				return false;
			}
			set { 
				ContainerWidget c = InternalGetContainerWidget ();
				if (c != null)
					c.validation_failed = value; 
			}
		}
		#endregion	// Internal Properties

		#region Private & Internal Methods

		void IDropTarget.OnDragDrop (DragEventArgs drgEvent)
		{
			OnDragDrop (drgEvent);
		}

		void IDropTarget.OnDragEnter (DragEventArgs drgEvent)
		{
			OnDragEnter (drgEvent);
		}

		void IDropTarget.OnDragLeave (EventArgs e)
		{
			OnDragLeave (e);
		}

		void IDropTarget.OnDragOver (DragEventArgs drgEvent)
		{
			OnDragOver (drgEvent);
		}

		internal IAsyncResult BeginInvokeInternal (Delegate method, object [] args) {
			return BeginInvokeInternal (method, args, FindWidgetToInvokeOn ());
		}

		internal IAsyncResult BeginInvokeInternal (Delegate method, object [] args, Widget Widget) {
			AsyncMethodResult	result;
			AsyncMethodData		data;

			result = new AsyncMethodResult ();
			data = new AsyncMethodData ();

			data.Handle = Widget.GetInvokableHandle ();
			data.Method = method;
			data.Args = args;
			data.Result = result;

			if (!ExecutionContext.IsFlowSuppressed ()) {
				data.Context = ExecutionContext.Capture ();
			}

			XplatUI.SendAsyncMethod (data);
			return result;
		}

		// The CheckForIllegalCrossThreadCalls in the #if 2.0 of
		// Widget.Handle throws an exception when we are trying
		// to get the Handle to properly invoke on.  This avoids that.
		private IntPtr GetInvokableHandle ()
		{
			if (!IsHandleCreated)
				CreateHandle ();

			return window.Handle;
		}

		internal void PointToClient (ref int x, ref int y) {
			XplatUI.ScreenToClient (Handle, ref x, ref y);
		}

		internal void PointToScreen (ref int x, ref int y) {
			XplatUI.ClientToScreen (Handle, ref x, ref y);
		}

		internal bool IsRecreating {
			get {
				return is_recreating;
			}
		}

		internal Graphics DeviceContext {
			get { return Hwnd.GraphicsContext; }
		}

		// An internal way to have a fixed height
		// Basically for DataTimePicker 2.0
		internal virtual int OverrideHeight (int height)
		{
			return height;
		}

		private void ProcessActiveTracker (ref Message m)
		{
			bool is_up = ((Msg) m.Msg == Msg.WM_LBUTTONUP) ||
				((Msg) m.Msg == Msg.WM_RBUTTONUP);

			MouseButtons mb = FromParamToMouseButtons ((int) m.WParam.ToInt32 ());

			// We add in the button that was released (not sent in WParam)
			if (is_up) {
				switch ((Msg)m.Msg) {
				case Msg.WM_LBUTTONUP:
					mb |= MouseButtons.Left;
					break;
				case Msg.WM_RBUTTONUP:
					mb |= MouseButtons.Right;
					break;
				}
			}

			MouseEventArgs args = new MouseEventArgs (
				mb,
				mouse_clicks,
				Widget.MousePosition.X,
				Widget.MousePosition.Y,
				0);

			if (is_up) {
				active_tracker.OnMouseUp (args);
				mouse_clicks = 1;
			} else {
				if (!active_tracker.OnMouseDown (args)) {
					Widget Widget = GetRealChildAtPoint (Cursor.Position);
					if (Widget != null) {
						Point pt = Widget.PointToClient (Cursor.Position);
						XplatUI.SendMessage (Widget.Handle, 
							(Msg)m.Msg, 
							m.WParam, 
							MakeParam (pt.X, pt.Y));
					}
				}
			}
		}

		private Widget FindWidgetToInvokeOn ()
		{
			Widget p = this;
			do {
				if (p.IsHandleCreated)
					break;
				p = p.parent;
			} while (p != null);

			if (p == null || !p.IsHandleCreated)
				throw new InvalidOperationException ("Cannot call Invoke or BeginInvoke on a Widget until the window handle is created");

			return p;
		}

		private void InvalidateBackBuffer () {
			if (backbuffer != null)
				backbuffer.Invalidate ();
		}

		private DoubleBuffer GetBackBuffer () {
			if (backbuffer == null)
				backbuffer = new DoubleBuffer (this);
			return backbuffer;
		}

		private void DisposeBackBuffer () {
			if (backbuffer != null) {
				backbuffer.Dispose ();
				backbuffer = null;
			}
		}

		internal static void SetChildColor(Widget parent) {
			Widget	child;

			for (int i=0; i < parent.child_Widgets.Count; i++) {
				child=parent.child_Widgets[i];
				if (child.child_Widgets.Count>0) {
					SetChildColor(child);
				}
			}
		}

		internal bool Select(Widget Widget) {
			IContainerWidget	container;

			if (Widget == null) {
				return false;
			}

			container = GetContainerWidget();
			if (container != null && (Widget)container != Widget) {
				container.ActiveWidget = Widget;
				if (container.ActiveWidget == Widget && !Widget.has_focus && Widget.IsHandleCreated)
					XplatUI.SetFocus(Widget.window.Handle);
			}
			else if (Widget.IsHandleCreated) {
				XplatUI.SetFocus(Widget.window.Handle);
			}
			return true;
		}

		internal virtual void DoDefaultAction() {
			// Only here to be overriden by our actual Widgets; this is needed by the accessibility class
		}

		internal static IntPtr MakeParam (int low, int high){
			return new IntPtr (high << 16 | low & 0xffff);
		}

		internal static int LowOrder (int param) {
			return ((int)(short)(param & 0xffff));
		}

		internal static int HighOrder (long param) {
			return ((int)(short)(param >> 16));
		}

		// This method exists so Widgets overriding OnPaintBackground can have default background painting done
		internal virtual void PaintWidgetBackground (PaintEventArgs pevent) {

			bool tbstyle_flat = ((CreateParams.Style & (int) ToolBarStyles.TBSTYLE_FLAT) != 0);

			// If we have transparent background
			if (((BackColor.A != 0xff) && GetStyle(Widgetstyles.SupportsTransparentBackColor)) || tbstyle_flat) {
				if (parent != null) {
					PaintEventArgs	parent_pe;
					GraphicsState	state;

					parent_pe = new PaintEventArgs(pevent.Graphics, new Rectangle(pevent.ClipRectangle.X + Left, pevent.ClipRectangle.Y + Top, pevent.ClipRectangle.Width, pevent.ClipRectangle.Height));

					state = parent_pe.Graphics.Save();
					parent_pe.Graphics.TranslateTransform(-Left, -Top);
					parent.OnPaintBackground(parent_pe);
					parent_pe.Graphics.Restore(state);

					state = parent_pe.Graphics.Save();
					parent_pe.Graphics.TranslateTransform(-Left, -Top);
					parent.OnPaint(parent_pe);
					parent_pe.Graphics.Restore(state);
					parent_pe.SetGraphics(null);
				}
			}

			if ((clip_region != null) && (XplatUI.UserClipWontExposeParent)) {
				if (parent != null) {
					PaintEventArgs	parent_pe;
					Region		region;
					GraphicsState	state;
					Hwnd		hwnd;

					hwnd = Hwnd.ObjectFromHandle(Handle);

					if (hwnd != null) {
						parent_pe = new PaintEventArgs(pevent.Graphics, new Rectangle(pevent.ClipRectangle.X + Left, pevent.ClipRectangle.Y + Top, pevent.ClipRectangle.Width, pevent.ClipRectangle.Height));

						region = new Region ();
						region.MakeEmpty();
						region.Union(ClientRectangle);

						foreach (Rectangle r in hwnd.ClipRectangles) {
							region.Union (r);
						}

						state = parent_pe.Graphics.Save();
						parent_pe.Graphics.Clip = region;

						parent_pe.Graphics.TranslateTransform(-Left, -Top);
						parent.OnPaintBackground(parent_pe);
						parent_pe.Graphics.Restore(state);

						state = parent_pe.Graphics.Save();
						parent_pe.Graphics.Clip = region;

						parent_pe.Graphics.TranslateTransform(-Left, -Top);
						parent.OnPaint(parent_pe);
						parent_pe.Graphics.Restore(state);
						parent_pe.SetGraphics(null);

						region.Intersect(clip_region);
						pevent.Graphics.Clip = region;
					}
				}
			}

			if (background_image == null) {
				if (!tbstyle_flat) {
					Rectangle paintRect = pevent.ClipRectangle;
					Brush pen = ThemeEngine.Current.ResPool.GetSolidBrush(BackColor);
					pevent.Graphics.FillRectangle(pen, paintRect);
				}
				return;
			}

			DrawBackgroundImage (pevent.Graphics);
		}

		void DrawBackgroundImage (Graphics g) {
			Rectangle drawing_rectangle = new Rectangle ();
			g.FillRectangle (ThemeEngine.Current.ResPool.GetSolidBrush (BackColor), ClientRectangle);

			switch (backgroundimage_layout)
			{
			case ImageLayout.Tile:
				using (TextureBrush b = new TextureBrush (background_image, WrapMode.Tile)) {
					g.FillRectangle (b, ClientRectangle);
				}
				return;
			case ImageLayout.Center:
				drawing_rectangle.Location = new Point (ClientSize.Width / 2 - background_image.Width / 2, ClientSize.Height / 2 - background_image.Height / 2);
				drawing_rectangle.Size = background_image.Size;
				break;
			case ImageLayout.None:
				drawing_rectangle.Location = Point.Empty;
				drawing_rectangle.Size = background_image.Size;
				break;
			case ImageLayout.Stretch:
				drawing_rectangle = ClientRectangle;
				break;
			case ImageLayout.Zoom:
				drawing_rectangle = ClientRectangle;
				if ((float)background_image.Width / (float)background_image.Height < (float)drawing_rectangle.Width / (float) drawing_rectangle.Height) {
					drawing_rectangle.Width = (int) (background_image.Width * ((float)drawing_rectangle.Height / (float)background_image.Height));
					drawing_rectangle.X = (ClientRectangle.Width - drawing_rectangle.Width) / 2;
				} else {
					drawing_rectangle.Height = (int) (background_image.Height * ((float)drawing_rectangle.Width / (float)background_image.Width));
					drawing_rectangle.Y = (ClientRectangle.Height - drawing_rectangle.Height) / 2;
				}
				break;
			default:
				return;
			}

			g.DrawImage (background_image, drawing_rectangle);

		}

		internal virtual void DndEnter (DragEventArgs e) {
			try {
				OnDragEnter (e);
			} catch { }
		}

		internal virtual void DndOver (DragEventArgs e) {
			try {
				OnDragOver (e);
			} catch { }
		}

		internal virtual void DndDrop (DragEventArgs e) {
			try {
				OnDragDrop (e);
			} catch (Exception exc) {
				Console.Error.WriteLine ("MWF: Exception while dropping:");
				Console.Error.WriteLine (exc);
			}
		}

		internal virtual void DndLeave (EventArgs e) {
			try {
				OnDragLeave (e);
			} catch { }
		}

		internal virtual void DndFeedback(GiveFeedbackEventArgs e) {
			try {
				OnGiveFeedback(e);
			} catch { }
		}

		internal virtual void DndContinueDrag(QueryContinueDragEventArgs e) {
			try {
				OnQueryContinueDrag(e);
			} catch { }
		}

		internal static MouseButtons FromParamToMouseButtons (long param) {		
			MouseButtons buttons = MouseButtons.None;

			if ((param & (long) MsgButtons.MK_LBUTTON) != 0)
				buttons |= MouseButtons.Left;

			if ((param & (long)MsgButtons.MK_MBUTTON) != 0)
				buttons |= MouseButtons.Middle;

			if ((param & (long)MsgButtons.MK_RBUTTON) != 0)
				buttons |= MouseButtons.Right;

			return buttons;
		}

		internal virtual void FireEnter () {
			OnEnter (EventArgs.Empty);
		}

		internal virtual void FireLeave () {
			OnLeave (EventArgs.Empty);
		}

		internal virtual void FireValidating (CancelEventArgs ce) {
			OnValidating (ce);
		}

		internal virtual void FireValidated () {
			OnValidated (EventArgs.Empty);
		}

		internal virtual bool ProcessWidgetMnemonic(char charCode) {
			return ProcessMnemonic(charCode);
		}

		private static Widget FindFlatForward(Widget container, Widget start) {
			Widget	found;
			int	index;
			int	end;
			bool hit;

			found = null;
			end = container.child_Widgets.Count;
			hit = false;

			if (start != null) {
				index = start.tab_index;
			} else {
				index = -1;
			}

			for (int i = 0; i < end; i++) {
				if (start == container.child_Widgets[i]) {
					hit = true;
					continue;
				}

				if (found == null || found.tab_index > container.child_Widgets[i].tab_index) {
					if (container.child_Widgets[i].tab_index > index || (hit && container.child_Widgets[i].tab_index == index)) {
						found = container.child_Widgets[i];
					}
				}
			}
			return found;
		}

		private static Widget FindWidgetForward(Widget container, Widget start) {
			Widget found;

			found = null;

			if (start == null) {
				return FindFlatForward(container, start);
			}

			if (start.child_Widgets != null && start.child_Widgets.Count > 0 && 
				(start == container || !((start is IContainerWidget) &&  start.GetStyle(Widgetstyles.ContainerWidget)))) {
				return FindWidgetForward(start, null);
			}
			else {
				while (start != container) {
					found = FindFlatForward(start.parent, start);
					if (found != null) {
						return found;
					}
					start = start.parent;
				}
			}
			return null;
		}

		private static Widget FindFlatBackward(Widget container, Widget start) {
			Widget	found;
			int	index;
			int	end;
			bool hit;

			found = null;
			end = container.child_Widgets.Count;
			hit = false;

			if (start != null) {
				index = start.tab_index;
			} else {
				index = int.MaxValue;
			}

			for (int i = end - 1; i >= 0; i--) {
				if (start == container.child_Widgets[i]) {
					hit = true;
					continue;
				}

				if (found == null || found.tab_index < container.child_Widgets[i].tab_index) {
					if (container.child_Widgets[i].tab_index < index || (hit && container.child_Widgets[i].tab_index == index))
						found = container.child_Widgets[i];

				}
			}
			return found;
		}

		private static Widget FindWidgetBackward(Widget container, Widget start) {

			Widget found = null;

			if (start == null) {
				found = FindFlatBackward(container, start);
			}
			else if (start != container) {
				if (start.parent != null) {
					found = FindFlatBackward(start.parent, start);

					if (found == null) {
						if (start.parent != container)
							return start.parent;
						return null;
					}
				}
			}

			if (found == null || start.parent == null)
				found = start;

			while (found != null && (found == container || (!((found is IContainerWidget) && found.GetStyle(Widgetstyles.ContainerWidget))) &&
				found.child_Widgets != null && found.child_Widgets.Count > 0)) {
				//				while (ctl.child_Widgets != null && ctl.child_Widgets.Count > 0 && 
				//					(ctl == this || (!((ctl is IContainerWidget) && ctl.GetStyle(Widgetstyles.ContainerWidget))))) {
				found = FindFlatBackward(found, null);
			}

			return found;

			/*
			Widget found;

			found = null;

			if (start != null) {
				found = FindFlatBackward(start.parent, start);
				if (found == null) {
					if (start.parent != container) {
						return start.parent;
					}
				}
			}
			if (found == null) {
				found = FindFlatBackward(container, start);
			}

			if (container != start) {
				while ((found != null) && (!found.Contains(start)) && found.child_Widgets != null && found.child_Widgets.Count > 0 && !(found is IContainerWidget)) {// || found.GetStyle(Widgetstyles.ContainerWidget))) {
					found = FindWidgetBackward(found, null);
					 if (found != null) {
						return found;
					}
				}
			}
			return found;
*/			
		}

		internal virtual void HandleClick(int clicks, MouseEventArgs me) {
			bool standardclick = GetStyle (Widgetstyles.StandardClick);
			bool standardclickclick = GetStyle (Widgetstyles.StandardDoubleClick);
			if ((clicks > 1) && standardclick && standardclickclick) {
				OnDoubleClick (me);
				OnMouseDoubleClick (me);
			} else if (clicks == 1 && standardclick && !ValidationFailed) {
				OnClick (me);
				OnMouseClick (me);
			}
		}

		internal void CaptureWithConfine (Widget ConfineWindow) {
			if (this.IsHandleCreated && !is_captured) {
				is_captured = true;
				XplatUI.GrabWindow (this.window.Handle, ConfineWindow.Handle);
			}
		}

		private void CheckDataBindings () {
			if (data_bindings == null)
				return;

			foreach (Binding binding in data_bindings) {
				binding.Check ();
			}
		}

		private void ChangeParent(Widget new_parent) {
			bool		pre_enabled;
			bool		pre_visible;
			Font		pre_font;
			Color		pre_fore_color;
			Color		pre_back_color;
			RightToLeft	pre_rtl;

			// These properties are inherited from our parent
			// Get them pre parent-change and then send events
			// if they are changed after we have our new parent
			pre_enabled = Enabled;
			pre_visible = Visible;
			pre_font = Font;
			pre_fore_color = ForeColor;
			pre_back_color = BackColor;
			pre_rtl = RightToLeft;
			// MS doesn't seem to send a CursorChangedEvent

			parent = new_parent;

			Form frm = this as Form;
			if (frm != null) {
				frm.ChangingParent (new_parent);
			} else if (IsHandleCreated) {
				IntPtr parent_handle = IntPtr.Zero;
				if (new_parent != null && new_parent.IsHandleCreated)
					parent_handle = new_parent.Handle;
				XplatUI.SetParent (Handle, parent_handle);
			}

			OnParentChanged(EventArgs.Empty);

			if (pre_enabled != Enabled) {
				OnEnabledChanged(EventArgs.Empty);
			}

			if (pre_visible != Visible) {
				OnVisibleChanged(EventArgs.Empty);
			}

			if (pre_font != Font) {
				OnFontChanged(EventArgs.Empty);
			}

			if (pre_fore_color != ForeColor) {
				OnForeColorChanged(EventArgs.Empty);
			}

			if (pre_back_color != BackColor) {
				OnBackColorChanged(EventArgs.Empty);
			}

			if (pre_rtl != RightToLeft) {
				// MS sneaks a OnCreateWidget and OnHandleCreated in here, I guess
				// because when RTL changes they have to recreate the win32 Widget
				// We don't really need that (until someone runs into compatibility issues)
				OnRightToLeftChanged(EventArgs.Empty);
			}

			if ((new_parent != null) && new_parent.Created && is_visible && !Created) {
				CreateWidget();
			}

			if ((binding_context == null) && Created) {
				OnBindingContextChanged(EventArgs.Empty);
			}
		}

		// Sometimes we need to do this calculation without it being virtual (constructor)
		internal Size InternalSizeFromClientSize (Size clientSize)
		{
			Rectangle ClientRect;
			Rectangle WindowRect;
			CreateParams cp;

			ClientRect = new Rectangle (0, 0, clientSize.Width, clientSize.Height);
			cp = this.CreateParams;

			if (XplatUI.CalculateWindowRect (ref ClientRect, cp, null, out WindowRect))
				return new Size (WindowRect.Width, WindowRect.Height);

			return Size.Empty;
		}

		internal Size ClientSizeFromSize (Size size)
		{
			// Calling this gives us the difference in Size and ClientSize.
			// We just have to apply that difference to our given size.
			Size client_size = this.InternalSizeFromClientSize (size);

			if (client_size == Size.Empty)
				return Size.Empty;

			return new Size (size.Width - (client_size.Width - size.Width), size.Height - (client_size.Height - size.Height));
		}

		internal CreateParams GetCreateParams ()
		{
			return CreateParams;
		}

		internal virtual Size GetPreferredSizeCore (Size proposedSize)
		{
			return this.explicit_bounds.Size;
		}

		private void UpdateDistances() {
			if (parent != null) {
				if (bounds.Width >= 0)
					dist_right = parent.ClientSize.Width - bounds.X - bounds.Width;
				if (bounds.Height >= 0)
					dist_bottom = parent.ClientSize.Height - bounds.Y - bounds.Height;

				recalculate_distances = false;
			}
		}

		private Cursor GetAvailableCursor ()
		{
			if (Cursor != null && Enabled) {
				return Cursor;
			}

			if (Parent != null) {
				return Parent.GetAvailableCursor ();
			}

			return Cursors.Default;
		}

		private void UpdateCursor ()
		{
			if (!IsHandleCreated)
				return;

			if (!Enabled) {
				XplatUI.SetCursor (window.Handle, GetAvailableCursor ().handle);
				return;
			}

			Point pt = PointToClient (Cursor.Position);

			if (!bounds.Contains (pt) && !Capture)
				return;

			if (cursor != null || use_wait_cursor) {
				XplatUI.SetCursor (window.Handle, Cursor.handle);
			} else {
				XplatUI.SetCursor (window.Handle, GetAvailableCursor ().handle);
			}
		}

		private bool UseDoubleBuffering {
			get {
				if (!ThemeEngine.Current.DoubleBufferingSupported)
					return false;

				// Since many of .Net's Widgets are unmanaged, they are doublebuffered
				// even though their bits may not be set in managed land.  This allows
				// us to doublebuffer as well without affecting public style bits.
				if (force_double_buffer)
					return true;

				if (DoubleBuffered)
					return true;
				return (Widget_style & Widgetstyles.DoubleBuffer) != 0;
			}
		}

		internal void OnSizeInitializedOrChanged ()
		{
			Form form = this as Form;
			if (form != null && form.WindowManager != null)
				ThemeEngine.Current.ManagedWindowOnSizeInitializedOrChanged (form);
		}
		#endregion	// Private & Internal Methods

		#region Public Static Properties
		public static Color DefaultBackColor {
			get {
				return ThemeEngine.Current.DefaultControlBackColor;
			}
		}

		public static Font DefaultFont {
			get {
				return ThemeEngine.Current.DefaultFont;
			}
		}

		public static Color DefaultForeColor {
			get {
				return ThemeEngine.Current.DefaultControlForeColor;
			}
		}

		public static Keys ModifierKeys {
			get {
				return XplatUI.State.ModifierKeys;
			}
		}

		public static MouseButtons MouseButtons {
			get {
				return XplatUI.State.MouseButtons;
			}
		}

		public static Point MousePosition {
			get {
				return Cursor.Position;
			}
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		//[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
		[Browsable (false)]
		[MonoTODO ("Stub, value is not used")]
		public static bool CheckForIllegalCrossThreadCalls 
		{
			get {
				return verify_thread_handle;
			}

			set {
				verify_thread_handle = value;
			}
		}
		#endregion	// Public Static Properties

		#region Public Instance Properties
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public AccessibleObject AccessibilityObject {
			get {
				if (accessibility_object==null) {
					accessibility_object=CreateAccessibilityInstance();
				}
				return accessibility_object;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string AccessibleDefaultActionDescription {
			get {
				return accessible_default_action;
			}

			set {
				accessible_default_action = value;
			}
		}

		[Localizable(true)]
		[DefaultValue(null)]
		[MWFCategory("Accessibility")]
		public string AccessibleDescription {
			get {
				return accessible_description;
			}

			set {
				accessible_description = value;
			}
		}

		[Localizable(true)]
		[DefaultValue(null)]
		[MWFCategory("Accessibility")]
		public string AccessibleName {
			get {
				return accessible_name;
			}

			set {
				accessible_name = value;
			}
		}

		[DefaultValue(AccessibleRole.Default)]
		[MWFDescription("Role of the Widget"), MWFCategory("Accessibility")]
		public AccessibleRole AccessibleRole {
			get {
				return accessible_role;
			}

			set {
				accessible_role = value;
			}
		}

		[DefaultValue(false)]
		[MWFCategory("Behavior")]
		public virtual bool AllowDrop {
			get {
				return allow_drop;
			}

			set {
				if (allow_drop == value)
					return;
				allow_drop = value;
				if (IsHandleCreated) {
					UpdateStyles();
					XplatUI.SetAllowDrop (Handle, value);
				}
			}
		}

		[Localizable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[DefaultValue(AnchorStyles.Top | AnchorStyles.Left)]
		[MWFCategory("Layout")]
        [MWFDescription("The sides of the parent widget that this one will bind to.")]
        public virtual AnchorStyles Anchor {
			get {
				return anchor_style;
			}

			set {
				layout_type = LayoutType.Anchor;

				if (anchor_style == value)
					return;

				anchor_style=value;
				dock_style = DockStyle.None;

				UpdateDistances ();

				if (parent != null)
					parent.PerformLayout(this, "Anchor");
			}
		}

		[Browsable (false)]
		[DefaultValue (typeof (Point), "0, 0")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		public virtual Point AutoScrollOffset {
			get {
				return auto_scroll_offset;
			}

			set {
				this.auto_scroll_offset = value;
			}
		}

		// XXX: Implement me!
		bool auto_size;

		[RefreshProperties (RefreshProperties.All)]
		[Localizable (true)]
		[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
		[Browsable (false)]
		[EditorBrowsable (EditorBrowsableState.Never)]
		[DefaultValue (false)]
		public virtual bool AutoSize {
			get { return auto_size; }
			set {
				if (this.auto_size != value) {
					auto_size = value;

					// If we're turning this off, reset our size
					if (!value) {
						Size = explicit_bounds.Size;
					} else {
						if (Parent != null)
							Parent.PerformLayout (this, "AutoSize");
					}

					OnAutoSizeChanged (EventArgs.Empty);
				}
			}
		}

		[AmbientValue ("{Width=0, Height=0}")]
		[MWFCategory("Layout")]
		public virtual Size MaximumSize {
			get {
				return maximum_size;
			}
			set {
				if (maximum_size != value) {
					maximum_size = value;
					Size = PreferredSize;
				}
			}
		}

		internal bool ShouldSerializeMaximumSize ()
		{
			return this.MaximumSize != DefaultMaximumSize;
		}

		[MWFCategory("Layout")]
		public virtual Size MinimumSize {
			get {
				return minimum_size;
			}
			set {
				if (minimum_size != value) {
					minimum_size = value;
					Size = PreferredSize;
				}
			}
		}

		internal bool ShouldSerializeMinimumSize ()
		{
			return this.MinimumSize != DefaultMinimumSize;
		}

		[DispId(-501)]
		[MWFCategory("Appearance")]
		public virtual Color BackColor {
			get {
				if (background_color.IsEmpty) {
					if (parent!=null) {
						Color pcolor = parent.BackColor;
						if (pcolor.A == 0xff || GetStyle(Widgetstyles.SupportsTransparentBackColor))
							return pcolor;
					}
					return DefaultBackColor;
				}
				return background_color;
			}

			set {
				if (!value.IsEmpty && (value.A != 0xff) && !GetStyle(Widgetstyles.SupportsTransparentBackColor)) {
					throw new ArgumentException("Transparent background colors are not supported on this Widget");
				}

				if (background_color != value) {
					background_color=value;
					SetChildColor(this);
					OnBackColorChanged(EventArgs.Empty);
					Invalidate();
				}
			}
		}

		internal bool ShouldSerializeBackColor ()
		{
			return this.BackColor != DefaultBackColor;
		}

		[Localizable(true)]
		[DefaultValue(null)]
		[MWFCategory("Appearance")]
		public virtual Image BackgroundImage {
			get {
				return background_image;
			}

			set {
				if (background_image!=value) {
					background_image=value;
					OnBackgroundImageChanged(EventArgs.Empty);
					Invalidate ();
				}
			}
		}

		[DefaultValue (ImageLayout.Tile)]
		[Localizable (true)]
		[MWFCategory("Appearance")]
		public virtual ImageLayout BackgroundImageLayout {
			get {
				return backgroundimage_layout;
			}
			set {
				if (Array.IndexOf (Enum.GetValues (typeof (ImageLayout)), value) == -1)
					throw new InvalidEnumArgumentException ("value", (int) value, typeof(ImageLayout));

				if (value != backgroundimage_layout) {
					backgroundimage_layout = value;
					Invalidate ();
					OnBackgroundImageLayoutChanged (EventArgs.Empty);
				}

			}
		} 

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BindingContext BindingContext {
			get {
				if (binding_context != null)
					return binding_context;
				if (Parent == null)
					return null;
				binding_context = Parent.BindingContext;
				return binding_context;
			}
			set {
				if (binding_context != value) {
					binding_context = value;
					OnBindingContextChanged(EventArgs.Empty);
				}
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Bottom {
			get {
				return this.bounds.Bottom;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle Bounds {
			get {
				return this.bounds;
			}

			set {
				SetBounds(value.Left, value.Top, value.Width, value.Height, BoundsSpecified.All);
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool CanFocus {
			get {
				if (IsHandleCreated && Visible && Enabled) {
					return true;
				}
				return false;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool CanSelect {
			get {
				Widget	parent;

				if (!GetStyle(Widgetstyles.Selectable)) {
					return false;
				}

				parent = this;
				while (parent != null) {
					if (!parent.is_visible || !parent.is_enabled) {
						return false;
					}

					parent = parent.parent;
				}
				return true;
			}
		}

		internal virtual bool InternalCapture {
			get {
				return Capture;
			}

			set {
				Capture = value;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Capture {
			get {
				return this.is_captured;
			}

			set {
				// Call OnMouseCaptureChanged when we get WM_CAPTURECHANGED.
				if (value != is_captured) {
					if (value) {
						is_captured = true;
						XplatUI.GrabWindow(Handle, IntPtr.Zero);
					} else {
						if (IsHandleCreated)
							XplatUI.UngrabWindow(Handle);
						is_captured = false;
					}
				}
			}
		}

		[DefaultValue(true)]
		[MWFCategory("Focus")]
		public bool CausesValidation {
			get {
				return this.causes_validation;
			}

			set {
				if (this.causes_validation != value) {
					causes_validation = value;
					OnCausesValidationChanged(EventArgs.Empty);
				}
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle ClientRectangle {
			get {
				client_rect.Width = client_size.Width;
				client_rect.Height = client_size.Height;
				return client_rect;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Size ClientSize {
			get {
				#if notneeded
				if ((this is Form) && (((Form)this).form_parent_window != null)) {
				return ((Form)this).form_parent_window.ClientSize;
				}
				#endif

				return client_size;
			}

			set {
				this.SetClientSizeCore(value.Width, value.Height);
				this.OnClientSizeChanged (EventArgs.Empty);
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DescriptionAttribute("WidgetCompanyNameDescr")]
		public String CompanyName {
			get {
				return "Mono Project, Novell, Inc.";
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ContainsFocus {
			get {
				IntPtr focused_window;

				focused_window = XplatUI.GetFocus();
				if (IsHandleCreated) {
					if (focused_window == Handle) {
						return true;
					}

					for (int i=0; i < child_Widgets.Count; i++) {
						if (child_Widgets[i].ContainsFocus) {
							return true;
						}
					}
				}
				return false;
			}
		}
			
		[DefaultValue (null)]
		[MWFCategory("Behavior")]
		public virtual ContextMenuStrip ContextMenuStrip {
			get { return this.context_menu_strip; }
			set { 
				if (this.context_menu_strip != value) {
					this.context_menu_strip = value;
					if (value != null)
						value.container = this;
					OnContextMenuStripChanged (EventArgs.Empty);
				}
			}
		}

		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public WidgetCollection Widgets {
			get {
				return this.child_Widgets;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Created {
			get {
				return (!is_disposed && is_created);
			}
		}

		[AmbientValue(null)]
		[MWFCategory("Appearance")]
		public virtual Cursor Cursor {
			get {
				if (use_wait_cursor)
					return Cursors.WaitCursor;

				if (cursor != null) {
					return cursor;
				}

				if (parent != null) {
					return parent.Cursor;
				}

				return Cursors.Default;
			}

			set {
				if (cursor == value) {
					return;
				}

				cursor = value;
				UpdateCursor ();

				OnCursorChanged (EventArgs.Empty);
			}
		}

		internal bool ShouldSerializeCursor ()
		{
			return this.Cursor != Cursors.Default;
		}

		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[ParenthesizePropertyName(true)]
		[RefreshProperties(RefreshProperties.All)]
		[MWFCategory("Data")]
		public WidgetBindingsCollection DataBindings {
			get {
				if (data_bindings == null)
					data_bindings = new WidgetBindingsCollection (this);
				return data_bindings;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual Rectangle DisplayRectangle {
			get {
				// for the Widget class the DisplayRectangle == ClientRectangle
				return ClientRectangle;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Disposing {
			get {
				return is_disposed;
			}
		}

		[Localizable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[DefaultValue(DockStyle.None)]
		[MWFCategory("Layout")]
		public virtual DockStyle Dock {
			get {
				return dock_style;
			}

			set {
				// If the user sets this to None, we need to still use Anchor layout
				if (value != DockStyle.None)
					layout_type = LayoutType.Dock;

				if (dock_style == value) {
					return;
				}

				if (!Enum.IsDefined (typeof (DockStyle), value)) {
					throw new InvalidEnumArgumentException ("value", (int) value,
						typeof (DockStyle));
				}

				dock_style = value;
				anchor_style = AnchorStyles.Top | AnchorStyles.Left;

				if (dock_style == DockStyle.None) {
					bounds = explicit_bounds;
					layout_type = LayoutType.Anchor;
				}

				if (parent != null)
					parent.PerformLayout(this, "Dock");
				else if (Widgets.Count > 0)
					PerformLayout ();

				OnDockChanged(EventArgs.Empty);
			}
		}

		protected virtual bool DoubleBuffered {
			get {
				return (Widget_style & Widgetstyles.OptimizedDoubleBuffer) != 0;
			}

			set {
				if (value == DoubleBuffered)
					return;
				if (value) {
					SetStyle (Widgetstyles.OptimizedDoubleBuffer | Widgetstyles.AllPaintingInWmPaint, true);
				} else {
					SetStyle (Widgetstyles.OptimizedDoubleBuffer, false);
				}

			}
		}

		public void DrawToBitmap (Bitmap bitmap, Rectangle targetBounds)
		{
			Graphics g = Graphics.FromImage (bitmap);

			// Only draw within the target bouds, and up to the size of the Widget
			g.IntersectClip (targetBounds);
			g.IntersectClip (Bounds);

			// Logic copied from WmPaint
			PaintEventArgs pea = new PaintEventArgs (g, targetBounds);

			if (!GetStyle (Widgetstyles.Opaque))
				OnPaintBackground (pea);

			OnPaintBackgroundInternal (pea);

			OnPaintInternal (pea);

			if (!pea.Handled)
				OnPaint (pea);

			g.Dispose ();
		}

		[DispId(-514)]
		[Localizable(true)]
		[MWFCategory("Behavior")]
		public bool Enabled {
			get {
				if (!is_enabled) {
					return false;
				}

				if (parent != null) {
					return parent.Enabled;
				}

				return true;
			}

			set {
				if (this.is_enabled == value)
					return;

				bool old_value = is_enabled;

				is_enabled = value;

				if (!value)
					UpdateCursor ();

				if (old_value != value && !value && this.has_focus)
					SelectNextWidget(this, true, true, true, true);

				OnEnabledChanged (EventArgs.Empty);
			}
		}

		internal bool ShouldSerializeEnabled ()
		{
			return this.Enabled != true;
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool Focused {
			get {
				return this.has_focus;
			}
		}

		[DispId(-512)]
		[AmbientValue(null)]
		[Localizable(true)]
		[MWFCategory("Appearance")]
		public virtual Font Font {
			[return: MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (Font))]
			get {
				if (font != null)
					return font;

				if (parent != null) {
					Font f = parent.Font;

					if (f != null)
						return f;
				}

				return DefaultFont;
			}

			[param:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Font))]
			set {
				if (font != null && font == value) {
					return;
				}

				font = value;
				Invalidate();
				OnFontChanged (EventArgs.Empty);
				PerformLayout ();
			}
		}

		internal bool ShouldSerializeFont ()
		{
			return !this.Font.Equals (DefaultFont);
		}

		[DispId(-513)]
		[MWFCategory("Appearance")]
		public virtual Color ForeColor {
			get {
				if (foreground_color.IsEmpty) {
					if (parent!=null) {
						return parent.ForeColor;
					}
					return DefaultForeColor;
				}
				return foreground_color;
			}

			set {
				if (foreground_color != value) {
					foreground_color=value;
					Invalidate();
					OnForeColorChanged(EventArgs.Empty);
				}
			}
		}

		internal bool ShouldSerializeForeColor ()
		{
			return this.ForeColor != DefaultForeColor;
		}

		[DispId(-515)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IntPtr Handle {							// IWin32Window
			get {
				if (verify_thread_handle) {
					if (this.InvokeRequired) {
						throw new InvalidOperationException("Cross-thread access of handle detected. Handle access only valid on thread that created the Widget");
					}
				}
				if (!IsHandleCreated) {
					CreateHandle();
				}
				return window.Handle;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool HasChildren {
			get {
				if (this.child_Widgets.Count>0) {
					return true;
				}
				return false;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Height {
			get { return this.bounds.Height; }
			set { SetBounds(bounds.X, bounds.Y, bounds.Width, value, BoundsSpecified.Height); }
		}

		[AmbientValue(ImeMode.Inherit)]
		[Localizable(true)]
		[MWFCategory("Behavior")]
		public ImeMode ImeMode {
			get {
				if (ime_mode == ImeMode.Inherit) {
					if (parent != null)
						return parent.ImeMode;
					else
						return ImeMode.NoControl; // default value
				}
				return ime_mode;
			}

			set {
				if (ime_mode != value) {
					ime_mode = value;

					OnImeModeChanged(EventArgs.Empty);
				}
			}
		}

		internal bool ShouldSerializeImeMode ()
		{
			return this.ImeMode != ImeMode.NoControl;
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool InvokeRequired {						// ISynchronizeInvoke
			get {
				if (creator_thread != null && creator_thread!=Thread.CurrentThread) {
					return true;
				}
				return false;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsAccessible {
			get {
				return is_accessible;
			}

			set {
				is_accessible = value;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsDisposed {
			get {
				return this.is_disposed;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsHandleCreated {
			get {
				if (window == null || window.Handle == IntPtr.Zero)
					return false;

				Hwnd hwnd = Hwnd.ObjectFromHandle (window.Handle);
				if (hwnd != null && hwnd.zombie)
					return false;

				return true;
			}
		}

		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		[MonoNotSupported ("RTL is not supported")]
		public bool IsMirrored {
			get { return false; }
		}

		[Browsable (false)]
		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		public virtual Layout.LayoutEngine LayoutEngine {
			get {
				if (layout_engine == null)
					layout_engine = new Layout.DefaultLayout ();
				return layout_engine;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Left {
			get {
				return this.bounds.Left;
			}

			set {
				SetBounds(value, bounds.Y, bounds.Width, bounds.Height, BoundsSpecified.X);
			}
		}

		[Localizable(true)]
		[MWFCategory("Layout")]
		public Point Location {
			get {
				return this.bounds.Location;
			}

			set {
				SetBounds(value.X, value.Y, bounds.Width, bounds.Height, BoundsSpecified.Location);
			}
		}

		internal bool ShouldSerializeLocation ()
		{
			return this.Location != new Point (0, 0);
		}

		[Localizable (true)]
		[MWFCategory("Layout")]
		public Padding Margin {
			get { return this.margin; }
			set { 
				if (this.margin != value) {
					this.margin = value; 
					if (Parent != null)
						Parent.PerformLayout (this, "Margin");
					OnMarginChanged (EventArgs.Empty);
				}
			}
		}

		internal bool ShouldSerializeMargin ()
		{
			return this.Margin != DefaultMargin;
		}

		[Browsable(false)]
		public string Name {
			get {
				return name;
			}

			set {
				name = value;
			}
		}

		[Localizable(true)]
		[MWFCategory("Layout")]
		public Padding Padding {
			get {
				return padding;
			}

			set {
				if (padding != value) {
					padding = value;
					OnPaddingChanged (EventArgs.Empty);

					// Changing padding generally requires a new size
					if (this.AutoSize && this.Parent != null)
						parent.PerformLayout (this, "Padding");
					else
						PerformLayout (this, "Padding");
				}
			}
		}

		internal bool ShouldSerializePadding ()
		{
			return this.Padding != DefaultPadding;
		}

		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Widget Parent {
			get {
				return this.parent;
			}

			set {
				if (value == this) {
					throw new ArgumentException("A circular Widget reference has been made. A Widget cannot be owned or parented to itself.");
				}

				if (parent!=value) {
					if (value==null) {
						parent.Widgets.Remove(this);
						parent = null;
						return;
					}

					value.Widgets.Add(this);
				}
			}
		}

		[Browsable (false)]
		public Size PreferredSize {
			get { return this.GetPreferredSize (Size.Empty); }
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string ProductName {
			get {
				Type t = typeof (AssemblyProductAttribute);
				Assembly assembly = GetType().Module.Assembly;
				object [] attrs = assembly.GetCustomAttributes (t, false);
				AssemblyProductAttribute a = null;
				// On MS we get a NullRefException if product attribute is not
				// set. 
				if (attrs != null && attrs.Length > 0)
					a = (AssemblyProductAttribute) attrs [0];
				if (a == null) {
					return GetType ().Namespace;
				}
				return a.Product;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string ProductVersion {
			get {
				Type t = typeof (AssemblyVersionAttribute);
				Assembly assembly = GetType().Module.Assembly;
				object [] attrs = assembly.GetCustomAttributes (t, false);
				if (attrs == null || attrs.Length < 1)
					return "1.0.0.0";
				return ((AssemblyVersionAttribute)attrs [0]).Version;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool RecreatingHandle {
			get {
				return is_recreating;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Region Region {
			get {
				return clip_region;
			}

			set {
				if (clip_region != value) {
					if (IsHandleCreated)
						XplatUI.SetClipRegion(Handle, value);

					clip_region = value;

					OnRegionChanged (EventArgs.Empty);
				}
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Right {
			get {
				return this.bounds.Right;
			}
		}

		[AmbientValue(RightToLeft.Inherit)]
		[Localizable(true)]
		[MWFCategory("Appearance")]
		public virtual RightToLeft RightToLeft {
			get {
				if (right_to_left == RightToLeft.Inherit) {
					if (parent != null)
						return parent.RightToLeft;
					else
						return RightToLeft.No; // default value
				}
				return right_to_left;
			}

			set {
				if (value != right_to_left) {
					right_to_left = value;
					OnRightToLeftChanged(EventArgs.Empty);
					PerformLayout ();
				}
			}
		}

		internal bool ShouldSerializeRightToLeft ()
		{
			return this.RightToLeft != RightToLeft.No;
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		public override ISite Site {
			get {
				return base.Site;
			}

			set {
				base.Site = value;

				if (value != null) {
					AmbientProperties ap = (AmbientProperties) value.GetService (typeof (AmbientProperties));
					if (ap != null) {
						BackColor = ap.BackColor;
						ForeColor = ap.ForeColor;
						Cursor = ap.Cursor;
						Font = ap.Font;
					}
				}
			}
		}

		internal bool ShouldSerializeSite ()
		{
			return false;
		}

		[Localizable(true)]
		[MWFCategory("Layout")]
		public Size Size {
			get {
				return new Size(Width, Height);
			}

			set {
				SetBounds(bounds.X, bounds.Y, value.Width, value.Height, BoundsSpecified.Size);
			}
		}

		internal virtual bool ShouldSerializeSize ()
		{
			return this.Size != DefaultSize;
		}

		[Localizable(true)]
		[MergableProperty(false)]
		[MWFCategory("Behavior")]
		public int TabIndex {
			get {
				if (tab_index != -1) {
					return tab_index;
				}
				return 0;
			}

			set {
				if (tab_index != value) {
					tab_index = value;
					OnTabIndexChanged(EventArgs.Empty);
				}
			}
		}

		[DispId(-516)]
		[DefaultValue(true)]
		[MWFCategory("Behavior")]
		public bool TabStop {
			get {
				return tab_stop;
			}

			set {
				if (tab_stop != value) {
					tab_stop = value;
					OnTabStopChanged(EventArgs.Empty);
				}
			}
		}

		[Localizable(false)]
		[Bindable(true)]
		[TypeConverter(typeof(StringConverter))]
		[DefaultValue(null)]
		[MWFCategory("Data")]
		public object Tag {
			get {
				return Widget_tag;
			}

			set {
				Widget_tag = value;
			}
		}

		[DispId(-517)]
		[Localizable(true)]
		[BindableAttribute(true)]
		[MWFCategory("Appearance")]
		public virtual string Text {
			get {
				// Our implementation ignores Widgetstyles.CacheText - we always cache
				return this.text;
			}

			set {
				if (value == null) {
					value = String.Empty;
				}

				if (text!=value) {
					text=value;
					UpdateWindowText ();
					OnTextChanged (EventArgs.Empty);

					// Label has its own AutoSize implementation
					if (AutoSize && Parent != null && (!(this is Label)))
						Parent.PerformLayout (this, "Text");
				}
			}
		}

		internal virtual void UpdateWindowText ()
		{
			if (!IsHandleCreated) {
				return;
			}
			XplatUI.Text (Handle, text);
		}

		//[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Top {
			get {
				return this.bounds.Top;
			}

			set {
				SetBounds(bounds.X, value, bounds.Width, bounds.Height, BoundsSpecified.Y);
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Widget TopLevelWidget {
			get {
				Widget	p = this;

				while (p.parent != null) {
					p = p.parent;
				}

				return p is Form ? p : null;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DefaultValue (false)]
		[MWFCategory("Appearance")]
		public bool UseWaitCursor {
			get { return use_wait_cursor; }
			set {
				if (use_wait_cursor != value) {
					use_wait_cursor = value;
					UpdateCursor ();
					OnCursorChanged (EventArgs.Empty);
				}
			}
		}

		[Localizable(true)]
		[MWFCategory("Behavior")]
		public bool Visible {
			get {
				if (!is_visible) {
					return false;
				} else if (parent != null) {
					return parent.Visible;
				}

				return true;
			}

			set {
				if (this.is_visible != value) {
					SetVisibleCore(value);

					if (parent != null)
						parent.PerformLayout (this, "Visible");
				}
			}
		}

		internal bool ShouldSerializeVisible ()
		{
			return this.Visible != true;
		}

		//[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Width {
			get {
				return this.bounds.Width;
			}

			set {
				SetBounds(bounds.X, bounds.Y, value, bounds.Height, BoundsSpecified.Width);
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IWindowTarget WindowTarget {
			get { return window_target; }
			set { window_target = value; }
		}
		#endregion	// Public Instance Properties

		#region	Protected Instance Properties
		protected virtual bool CanEnableIme {
			get { return false; }
		}

		// Is only false in some ActiveX contexts
		protected override bool CanRaiseEvents {
			get { return true; }
		}

		protected virtual CreateParams CreateParams {
			get {
				CreateParams create_params = new CreateParams();

				try {
					create_params.Caption = Text;
				}
				catch {
					create_params.Caption = text;
				}

				try {
					create_params.X = Left;
				}
				catch {
					create_params.X = this.bounds.X;
				}

				try {
					create_params.Y = Top;
				}
				catch {
					create_params.Y = this.bounds.Y;
				}

				try {
					create_params.Width = Width;
				}
				catch {
					create_params.Width = this.bounds.Width;
				}

				try {
					create_params.Height = Height;
				}
				catch {
					create_params.Height = this.bounds.Height;
				}


				create_params.ClassName = XplatUI.GetDefaultClassName (GetType ());
				create_params.ClassStyle = (int)(XplatUIWin32.ClassStyle.CS_OWNDC | XplatUIWin32.ClassStyle.CS_DBLCLKS);
				create_params.ExStyle = 0;
				create_params.Param = 0;

				if (allow_drop) {
					create_params.ExStyle |= (int)WindowExStyles.WS_EX_ACCEPTFILES;
				}

				if ((parent!=null) && (parent.IsHandleCreated)) {
					create_params.Parent = parent.Handle;
				}

				create_params.Style = (int)WindowStyles.WS_CHILD | (int)WindowStyles.WS_CLIPCHILDREN | (int)WindowStyles.WS_CLIPSIBLINGS;

				if (is_visible) {
					create_params.Style |= (int)WindowStyles.WS_VISIBLE;
				}

				if (!is_enabled) {
					create_params.Style |= (int)WindowStyles.WS_DISABLED;
				}

				switch (border_style) {
				case BorderStyle.FixedSingle:
					create_params.Style |= (int) WindowStyles.WS_BORDER;
					break;
				case BorderStyle.Fixed3D:
					create_params.ExStyle |= (int) WindowExStyles.WS_EX_CLIENTEDGE;
					break;
				}

				create_params.control = this;

				return create_params;
			}
		}

		protected virtual Cursor DefaultCursor { get { return Cursors.Default; } }

		protected virtual ImeMode DefaultImeMode {
			get {
				return ImeMode.Inherit;
			}
		}

		protected virtual Padding DefaultMargin {
			get { return new Padding (3); }
		}

		protected virtual Size DefaultMaximumSize { get { return new Size (); } }
		protected virtual Size DefaultMinimumSize { get { return new Size (); } }
		protected virtual Padding DefaultPadding { get { return new Padding (); } }

		protected virtual Size DefaultSize {
			get {
				return new Size(0, 0);
			}
		}

		protected int FontHeight {
			get {
				return Font.Height;
			}

			set {
				;; // Nothing to do
			}
		}
		[Obsolete ()]
		protected bool RenderRightToLeft {
			get {
				return (this.right_to_left == RightToLeft.Yes);
			}
		}

		protected bool ResizeRedraw {
			get {
				return GetStyle(Widgetstyles.ResizeRedraw);
			}

			set {
				SetStyle(Widgetstyles.ResizeRedraw, value);
			}
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual bool ScaleChildren {
			get { return ScaleChildrenInternal; }
		}

		internal virtual bool ScaleChildrenInternal {
			get { return true; }
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected internal virtual bool ShowFocusCues {
			get {
				if (this is Form)
					return show_focus_cues;

				if (this.parent == null)
					return false;

				Form f = this.FindForm ();

				if (f != null)
					return f.show_focus_cues;

				return false;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal virtual protected bool ShowKeyboardCues {
			get {
				return ShowKeyboardCuesInternal;
			}
		}

		internal bool ShowKeyboardCuesInternal {
			get {
				if (SystemInformation.MenuAccessKeysUnderlined || DesignMode)
					return true; 

				return show_keyboard_cues;
			}
		}

		#endregion	// Protected Instance Properties

		#region Public Static Methods
		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static Widget FromChildHandle(IntPtr handle) {
			return Widget.WidgetNativeWindow.WidgetFromChildHandle (handle);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static Widget FromHandle(IntPtr handle) {
			return Widget.WidgetNativeWindow.WidgetFromHandle(handle);
		}

		[MonoTODO ("Only implemented for Win32, others always return false")]
		public static bool IsKeyLocked (Keys keyVal)
		{
			switch (keyVal) {
			case Keys.CapsLock:
			case Keys.NumLock:
			case Keys.Scroll:
				return XplatUI.IsKeyLocked ((VirtualKeys)keyVal);
			default:
				throw new NotSupportedException ("keyVal must be CapsLock, NumLock, or ScrollLock");
			}
		}

		public static bool IsMnemonic(char charCode, string text) {
			int amp;

			amp = text.IndexOf('&');

			if (amp != -1) {
				if (amp + 1 < text.Length) {
					if (text[amp + 1] != '&') {
						if (Char.ToUpper(charCode) == Char.ToUpper(text.ToCharArray(amp + 1, 1)[0])) {
							return true;
						}	
					}
				}
			}
			return false;
		}
		#endregion

		#region Protected Static Methods
		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected static bool ReflectMessage(IntPtr hWnd, ref Message m) {
			Widget	c;

			c = Widget.FromHandle(hWnd);

			if (c != null) {
				c.WndProc(ref m);
				return true;
			}
			return false;
		}
		#endregion

		#region	Public Instance Methods
		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		public IAsyncResult BeginInvoke(Delegate method) {
			object [] prms = null;
			if (method is EventHandler)
				prms = new object [] { this, EventArgs.Empty };
			return BeginInvokeInternal(method, prms);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		public IAsyncResult BeginInvoke (Delegate method, params object[] args)
		{
			return BeginInvokeInternal (method, args);
		}

		public void BringToFront() {
			if (parent != null) {
				parent.child_Widgets.SetChildIndex(this, 0);
			}
			else if (IsHandleCreated) {
				XplatUI.SetZOrder(Handle, IntPtr.Zero, false, false);
			}
		}

		public bool Contains(Widget ctl) {
			while (ctl != null) {
				ctl = ctl.parent;
				if (ctl == this) {
					return true;
				}
			}
			return false;
		}

		public void CreateWidget () {
			if (is_created) {
				return;
			}

			if (is_disposing) {
				return;
			}

			if (!is_visible) {
				return;
			}

			if (parent != null && !parent.Created) {
				return;
			}

			if (!IsHandleCreated) {
				CreateHandle();
			}

			if (!is_created) {
				is_created = true;

				// Create all of our children (implicit ones as well) when we are created.
				// The child should fire it's OnLoad before the parents, however
				// if the child checks Parent.Created in it's OnCreateWidget, the
				// parent is already created.
				foreach (Widget c in Widgets.GetAllWidgets ())
					if (!c.Created && !c.IsDisposed)
						c.CreateWidget ();

				OnCreateWidget();
			}
		}

		public Graphics CreateGraphics() {
			if (!IsHandleCreated) {
				this.CreateHandle();
			}
			return Graphics.FromHwnd(this.window.Handle);
		}

		public DragDropEffects DoDragDrop(object data, DragDropEffects allowedEffects) {
			DragDropEffects result = DragDropEffects.None;
			if (IsHandleCreated)
				result = XplatUI.StartDrag(Handle, data, allowedEffects);
			OnDragDropEnd (result);
			return result;
		}

		internal virtual void OnDragDropEnd (DragDropEffects effects)
		{
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		public object EndInvoke (IAsyncResult asyncResult) {
			AsyncMethodResult result = (AsyncMethodResult) asyncResult;
			return result.EndInvoke ();
		}

		internal Widget FindRootParent ()
		{
			Widget	c = this;

			while (c.Parent != null)
				c = c.Parent;

			return c;
		}

		public Form FindForm() {
			Widget	c;

			c = this;
			while (c != null) {
				if (c is Form) {
					return (Form)c;
				}
				c = c.Parent;
			}
			return null;
		}
		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		public bool Focus() {
			return FocusInternal (false);
		}

		internal virtual bool FocusInternal (bool skip_check) {
			if (skip_check || (CanFocus && IsHandleCreated && !has_focus && !is_focusing)) {
				is_focusing = true;
				Select(this);
				is_focusing = false;
			}
			return has_focus;
		}

		internal Widget GetRealChildAtPoint (Point pt) {
			if (!IsHandleCreated)
				CreateHandle ();

			foreach (Widget Widget in child_Widgets.GetAllWidgets ()) {
				if (Widget.Bounds.Contains (PointToClient (pt))) {
					Widget child = Widget.GetRealChildAtPoint (pt);
					if (child == null)
						return Widget;
					else
						return child;
				}
			}

			return null;
		}

		public Widget GetChildAtPoint(Point pt)
		{
			return GetChildAtPoint (pt, GetChildAtPointSkip.None);
		}

		public Widget GetChildAtPoint (Point pt, GetChildAtPointSkip skipValue)
		{
			// MS's version causes the handle to be created.  The stack trace shows that get_Handle is called here, but
			// we'll just call CreateHandle instead.
			if (!IsHandleCreated)
				CreateHandle ();

			// Microsoft's version of this function doesn't seem to work, so I can't check
			// if we only consider children or also grandchildren, etc.
			// I'm gonna say 'children only'
			foreach (Widget child in Widgets) {
				if ((skipValue & GetChildAtPointSkip.Disabled) == GetChildAtPointSkip.Disabled && !child.Enabled)
					continue;
				else if ((skipValue & GetChildAtPointSkip.Invisible) == GetChildAtPointSkip.Invisible && !child.Visible)
					continue;
				else if ((skipValue & GetChildAtPointSkip.Transparent) == GetChildAtPointSkip.Transparent && child.BackColor.A == 0x0)
					continue;
				else if (child.Bounds.Contains (pt))
					return child;
			}

			return null;
		}

		public IContainerWidget GetContainerWidget() {
			Widget	current = this;

			while (current!=null) {
				if ((current is IContainerWidget) && ((current.Widget_style & Widgetstyles.ContainerWidget)!=0)) {
					return (IContainerWidget)current;
				}
				current = current.parent;
			}
			return null;
		}

		internal ContainerWidget InternalGetContainerWidget() {
			Widget	current = this;

			while (current!=null) {
				if ((current is ContainerWidget) && ((current.Widget_style & Widgetstyles.ContainerWidget)!=0)) {
					return current as ContainerWidget;
				}
				current = current.parent;
			}
			return null;
		}

		public Widget GetNextWidget(Widget ctl, bool forward) {

			if (!this.Contains(ctl)) {
				ctl = this;
			}

			if (forward) {
				ctl = FindWidgetForward(this, ctl);
			}
			else {
				ctl = FindWidgetBackward(this, ctl);
			}

			if (ctl != this) {
				return ctl;
			}
			return null;
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		public virtual Size GetPreferredSize (Size proposedSize) {
			Size retsize = GetPreferredSizeCore (proposedSize);

			// If we're bigger than the MaximumSize, fix that
			if (this.maximum_size.Width != 0 && retsize.Width > this.maximum_size.Width)
				retsize.Width = this.maximum_size.Width;
			if (this.maximum_size.Height != 0 && retsize.Height > this.maximum_size.Height)
				retsize.Height = this.maximum_size.Height;

			// If we're smaller than the MinimumSize, fix that
			if (this.minimum_size.Width != 0 && retsize.Width < this.minimum_size.Width)
				retsize.Width = this.minimum_size.Width;
			if (this.minimum_size.Height != 0 && retsize.Height < this.minimum_size.Height)
				retsize.Height = this.minimum_size.Height;

			return retsize;
		}

		public void Hide() {
			this.Visible = false;
		}

		public void Invalidate ()
		{
			Invalidate (ClientRectangle, false);
		}

		public void Invalidate (bool invalidateChildren)
		{
			Invalidate (ClientRectangle, invalidateChildren);
		}

		public void Invalidate (Rectangle rc)
		{
			Invalidate (rc, false);
		}

		public void Invalidate (Rectangle rc, bool invalidateChildren)
		{
			// Win32 invalidates Widget including when Width and Height is equal 0
			// or is not visible, only Paint event must be care about this.
			if (!IsHandleCreated)
				return;

			if (rc.IsEmpty)
				rc = ClientRectangle;

			if  (rc.Width > 0 && rc.Height > 0) {

				NotifyInvalidate(rc);

				XplatUI.Invalidate(Handle, rc, false);

				if (invalidateChildren) {
					Widget [] Widgets = child_Widgets.GetAllWidgets ();
					for (int i=0; i<Widgets.Length; i++)
						Widgets [i].Invalidate ();
				} else {
					// If any of our children are transparent, we
					// have to invalidate them anyways
					foreach (Widget c in Widgets)
						if (c.BackColor.A != 255)
							c.Invalidate ();
				}
			}
			OnInvalidated(new InvalidateEventArgs(rc));
		}

		public void Invalidate (Region region)
		{
			Invalidate (region, false);
		}

		public void Invalidate (Region region, bool invalidateChildren)
		{
			using (Graphics g = CreateGraphics ()){
				RectangleF bounds = region.GetBounds (g);
				Invalidate (new Rectangle ((int) bounds.X, (int) bounds.Y, (int) bounds.Width, (int) bounds.Height), invalidateChildren);
			}
		}

		public object Invoke (Delegate method) {
			object [] prms = null;
			if (method is EventHandler)
				prms = new object [] { this, EventArgs.Empty };

			return Invoke(method, prms);
		}
		public object Invoke (Delegate method, params object [] args) {
			Widget Widget = FindWidgetToInvokeOn ();

			if (!this.InvokeRequired) {
				return method.DynamicInvoke(args);
			}

			IAsyncResult result = BeginInvokeInternal (method, args, Widget);
			return EndInvoke(result);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void PerformLayout() {
			PerformLayout(null, null);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void PerformLayout(Widget affectedWidget, string affectedProperty) {
			LayoutEventArgs levent = new LayoutEventArgs(affectedWidget, affectedProperty);

			foreach (Widget c in Widgets.GetAllWidgets ())
				if (c.recalculate_distances)
					c.UpdateDistances ();

			if (layout_suspended > 0) {
				layout_pending = true;
				return;
			}

			layout_pending = false;

			// Prevent us from getting messed up
			layout_suspended++;

			// Perform all Dock and Anchor calculations
			try {
				OnLayout(levent);
			}

			// Need to make sure we decremend layout_suspended
			finally {
				layout_suspended--;
			}
		}

		public Point PointToClient (Point p) {
			int x = p.X;
			int y = p.Y;

			XplatUI.ScreenToClient (Handle, ref x, ref y);

			return new Point (x, y);
		}

		public Point PointToScreen(Point p) {
			int x = p.X;
			int y = p.Y;

			XplatUI.ClientToScreen(Handle, ref x, ref y);

			return new Point(x, y);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		public PreProcessWidgetstate PreProcessWidgetMessage (ref Message msg)
		{
			return PreProcessWidgetMessageInternal (ref msg);
		}

		internal PreProcessWidgetstate PreProcessWidgetMessageInternal (ref Message msg)
		{
			switch ((Msg)msg.Msg) {
			case Msg.WM_KEYDOWN:
			case Msg.WM_SYSKEYDOWN:
				PreviewKeyDownEventArgs e = new PreviewKeyDownEventArgs ((Keys)msg.WParam.ToInt32 () | XplatUI.State.ModifierKeys);
				OnPreviewKeyDown (e);

				if (e.IsInputKey)
					return PreProcessWidgetstate.MessageNeeded;

				if (PreProcessMessage (ref msg))
					return PreProcessWidgetstate.MessageProcessed;

				if (IsInputKey ((Keys)msg.WParam.ToInt32 () | XplatUI.State.ModifierKeys))
					return PreProcessWidgetstate.MessageNeeded;	

				break;
			case Msg.WM_CHAR:
			case Msg.WM_SYSCHAR:
				if (PreProcessMessage (ref msg))
					return PreProcessWidgetstate.MessageProcessed;

				if (IsInputChar ((char)msg.WParam))
					return PreProcessWidgetstate.MessageNeeded;

				break;
			default:
				break;
			}

			return PreProcessWidgetstate.MessageNotNeeded;
		}

		public virtual bool PreProcessMessage (ref Message msg)
		{
			return InternalPreProcessMessage (ref msg);
		}

		internal virtual bool InternalPreProcessMessage (ref Message msg) {
			Keys key_data;

			if ((msg.Msg == (int)Msg.WM_KEYDOWN) || (msg.Msg == (int)Msg.WM_SYSKEYDOWN)) {
				key_data = (Keys)msg.WParam.ToInt32() | XplatUI.State.ModifierKeys;

				if (!ProcessCmdKey(ref msg, key_data)) {
					if (IsInputKey(key_data)) {
						return false;
					}

					return ProcessDialogKey(key_data);
				}

				return true;
			} else if (msg.Msg == (int)Msg.WM_CHAR) {
				if (IsInputChar((char)msg.WParam)) {
					return false;
				}
				return ProcessDialogChar((char)msg.WParam);
			} else if (msg.Msg == (int)Msg.WM_SYSCHAR) {
				if (ProcessDialogChar((char)msg.WParam))
					return true;
				else
					return ToolStripManager.ProcessMenuKey (ref msg);
			}
			return false;
		}

		public Rectangle RectangleToClient(Rectangle r) {
			return new Rectangle(PointToClient(r.Location), r.Size);
		}

		public Rectangle RectangleToScreen(Rectangle r) {
			return new Rectangle(PointToScreen(r.Location), r.Size);
		}

		public virtual void Refresh() {
			if (IsHandleCreated && Visible) {
				Invalidate(true);
				Update ();
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetBackColor() {
			BackColor = Color.Empty;
		}

		//[EditorBrowsable(EditorBrowsableState.Never)]
		public void ResetBindings() {
			if (data_bindings != null)
				data_bindings.Clear();
		}

		//[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetCursor() {
			Cursor = null;
		}

		//[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetFont() {
			font = null;
		}

		//[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetForeColor() {
			foreground_color = Color.Empty;
		}

		//[EditorBrowsable(EditorBrowsableState.Never)]
		public void ResetImeMode() {
			ime_mode = DefaultImeMode;
		}

		//[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetRightToLeft() {
			right_to_left = RightToLeft.Inherit;
		}

		public virtual void ResetText() {
			Text = String.Empty;
		}

		public void ResumeLayout() {
			ResumeLayout (true);
		}

		public void ResumeLayout(bool performLayout) {
			if (layout_suspended > 0) {
				layout_suspended--;
			}

			if (layout_suspended == 0) {
				if (this is ContainerWidget)
					(this as ContainerWidget).PerformDelayedAutoScale();

				if (!performLayout)
					foreach (Widget c in Widgets.GetAllWidgets ())
						c.UpdateDistances ();

				if (performLayout && layout_pending) {
					PerformLayout();
				}
			}
		}
		//[EditorBrowsable (EditorBrowsableState.Never)]
		[Obsolete ()]
		public void Scale(float ratio) {
			ScaleCore(ratio, ratio);
		}

		//[EditorBrowsable (EditorBrowsableState.Never)]
		[Obsolete ()]
		public void Scale(float dx, float dy) {
			ScaleCore(dx, dy);
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		public void Scale (SizeF factor)
		{
			BoundsSpecified bounds_spec = BoundsSpecified.All;

			SuspendLayout ();

			if (this is ContainerWidget) {
				if ((this as ContainerWidget).IsAutoScaling)
					bounds_spec = BoundsSpecified.Size;
				else if (IsContainerAutoScaling (this.Parent))
					bounds_spec = BoundsSpecified.Location;
			}

			ScaleWidget (factor, bounds_spec);

			// Scale children
			if ((bounds_spec != BoundsSpecified.Location) && ScaleChildren) {
				foreach (Widget c in Widgets.GetAllWidgets ()) {
					c.Scale (factor);
					if (c is ContainerWidget) {
						ContainerWidget cc = c as ContainerWidget;
						if ((cc.AutoScaleMode == AutoScaleMode.Inherit) && IsContainerAutoScaling (this))
							cc.PerformAutoScale (true);
					}
				}
			}

			ResumeLayout ();
		}

		internal ContainerWidget FindContainer (Widget c)
		{
			while ((c != null) && !(c is ContainerWidget))
				c = c.Parent;
			return c as ContainerWidget;
		}

		private bool IsContainerAutoScaling (Widget c)
		{
			ContainerWidget cc = FindContainer (c);
			return (cc != null) && cc.IsAutoScaling;
		}

		public void Select() {
			Select(false, false);	
		}

		#if DebugFocus
		private void printTree(Widget c, string t) {
		foreach(Widget i in c.child_Widgets) {
		Console.WriteLine ("{2}{0}.TabIndex={1}", i, i.tab_index, t);
		printTree (i, t+"\t");
		}
		}
		#endif
		public bool SelectNextWidget(Widget ctl, bool forward, bool tabStopOnly, bool nested, bool wrap) {
			Widget c;

			#if DebugFocus
			Console.WriteLine("{0}", this.FindForm());
			printTree(this, "\t");
			#endif

			if (!this.Contains(ctl) || (!nested && (ctl.parent != this))) {
				ctl = null;
			}
			c = ctl;
			do {
				c = GetNextWidget(c, forward);
				if (c == null) {
					if (wrap) {
						wrap = false;
						continue;
					}
					break;
				}

				#if DebugFocus
				Console.WriteLine("{0} {1}", c, c.CanSelect);
				#endif
				if (c.CanSelect && ((c.parent == this) || nested) && (c.tab_stop || !tabStopOnly)) {
					c.Select (true, true);
					return true;
				}
			} while (c != ctl); // If we wrap back to ourselves we stop

			return false;
		}

		public void SendToBack() {
			if (parent != null) {
				parent.child_Widgets.SetChildIndex(this, parent.child_Widgets.Count);
			}
		}

		public void SetBounds(int x, int y, int width, int height) {
			SetBounds(x, y, width, height, BoundsSpecified.All);
		}

		public void SetBounds(int x, int y, int width, int height, BoundsSpecified specified) {
			// Fill in the values that were not specified
			if ((specified & BoundsSpecified.X) == 0)
				x = Left;
			if ((specified & BoundsSpecified.Y) == 0)
				y = Top;
			if ((specified & BoundsSpecified.Width) == 0)
				width = Width;
			if ((specified & BoundsSpecified.Height) == 0)
				height = Height;

			SetBoundsInternal (x, y, width, height, specified);
		}

		internal void SetBoundsInternal (int x, int y, int width, int height, BoundsSpecified specified)
		{
			// SetBoundsCore is really expensive to call, so we want to avoid it if we can.
			// We can avoid it if:
			// - The requested dimensions are the same as our current dimensions
			// AND
			// - Any BoundsSpecified is the same as our current explicit_size
			if (bounds.X != x || (explicit_bounds.X != x && (specified & BoundsSpecified.X) == BoundsSpecified.X))
				SetBoundsCore (x, y, width, height, specified);
			else if (bounds.Y != y || (explicit_bounds.Y != y && (specified & BoundsSpecified.Y) == BoundsSpecified.Y))
				SetBoundsCore (x, y, width, height, specified);
			else if (bounds.Width != width || (explicit_bounds.Width != width && (specified & BoundsSpecified.Width) == BoundsSpecified.Width))
				SetBoundsCore (x, y, width, height, specified);
			else if (bounds.Height != height || (explicit_bounds.Height != height && (specified & BoundsSpecified.Height) == BoundsSpecified.Height))
				SetBoundsCore (x, y, width, height, specified);
			else
				return;

			// If the user explicitly moved or resized us, recalculate our anchor distances
			if (specified != BoundsSpecified.None)
				UpdateDistances ();

			if (parent != null)
				parent.PerformLayout(this, "Bounds");
		}

		public void Show () {
			this.Visible = true;
		}

		public void SuspendLayout() {
			layout_suspended++;
		}

		public void Update() {
			if (IsHandleCreated) {
				XplatUI.UpdateWindow(window.Handle);
			}
		}
		#endregion	// Public Instance Methods

		#region Protected Instance Methods
		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void AccessibilityNotifyClients(AccessibleEvents accEvent, int childID) {
			// turns out this method causes handle
			// creation in 1.1.  at first I thought this
			// would be accomplished just by using
			// get_AccessibilityObject, which would route
			// through CreateAccessibilityInstance, which
			// calls CreateWidget.  This isn't the case,
			// though (as overriding
			// CreateAccessibilityInstance and adding a
			// CWL shows nothing.  So we fudge it and put
			// a CreateHandle here.


			if (accessibility_object != null && accessibility_object is WidgetAccessibleObject)
				((WidgetAccessibleObject)accessibility_object).NotifyClients (accEvent, childID);
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected void AccessibilityNotifyClients (AccessibleEvents accEvent, int objectID, int childID)
		{
			if (accessibility_object != null && accessibility_object is WidgetAccessibleObject)
				((WidgetAccessibleObject)accessibility_object).NotifyClients (accEvent, objectID, childID);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual AccessibleObject CreateAccessibilityInstance() {
			CreateWidget ();
			return new Widget.WidgetAccessibleObject(this);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual WidgetCollection CreateWidgetsInstance() {
			return new WidgetCollection(this);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void CreateHandle() {
			if (IsDisposed) {
				throw new ObjectDisposedException(GetType().FullName);
			}

			if (IsHandleCreated && !is_recreating) {
				return;
			}

			CreateParams create_params = CreateParams;
			window.CreateHandle(create_params);

			if (window.Handle != IntPtr.Zero) {
				creator_thread = Thread.CurrentThread;

				XplatUI.EnableWindow(window.Handle, is_enabled);

				if (clip_region != null) {
					XplatUI.SetClipRegion(window.Handle, clip_region);
				}

				// Set our handle with our parent
				if ((parent != null) && (parent.IsHandleCreated)) {
					XplatUI.SetParent(window.Handle, parent.Handle);
				}

				UpdateStyles();
				XplatUI.SetAllowDrop (window.Handle, allow_drop);

				// Find out where the window manager placed us
				if ((CreateParams.Style & (int)WindowStyles.WS_CHILD) != 0) {
				//	XplatUI.SetBorderStyle(window.Handle, (FormBorderStyle)border_style);
				}

				Rectangle save_bounds = explicit_bounds;
				UpdateBounds ();
				explicit_bounds = save_bounds;
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void DefWndProc(ref Message m) {
			window.DefWndProc(ref m);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void DestroyHandle() {
			if (IsHandleCreated) {
				if (window != null) {
					window.DestroyHandle();
				}
			}
		}

		protected virtual AccessibleObject GetAccessibilityObjectById (int objectId)
		{
			// XXX need to implement this.
			return null;
		}

		protected internal AutoSizeMode GetAutoSizeMode () 
		{
			return auto_size_mode;
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual Rectangle GetScaledBounds (Rectangle bounds, SizeF factor, BoundsSpecified specified)
		{
			// Top level Widgets do not scale location
			if (!is_toplevel) {
				if ((specified & BoundsSpecified.X) == BoundsSpecified.X)
					bounds.X = (int)Math.Round (bounds.X * factor.Width);
				if ((specified & BoundsSpecified.Y) == BoundsSpecified.Y)
					bounds.Y = (int)Math.Round (bounds.Y * factor.Height);
			}

			if ((specified & BoundsSpecified.Width) == BoundsSpecified.Width && !GetStyle (Widgetstyles.FixedWidth)) {
				int border = (this is ComboBox) ? (ThemeEngine.Current.Border3DSize.Width * 2) :
					(this.bounds.Width - this.client_size.Width);
				bounds.Width = (int)Math.Round ((bounds.Width - border) * factor.Width + border);
			}
			if ((specified & BoundsSpecified.Height) == BoundsSpecified.Height && !GetStyle (Widgetstyles.FixedHeight)) {
				int border = (this is ComboBox) ? (ThemeEngine.Current.Border3DSize.Height * 2) :
					(this.bounds.Height - this.client_size.Height);
				bounds.Height = (int)Math.Round ((bounds.Height - border) * factor.Height + border);
			}

			return bounds;
		}

		private Rectangle GetScaledBoundsOld (Rectangle bounds, SizeF factor, BoundsSpecified specified)
		{
			RectangleF new_bounds = new RectangleF(bounds.Location, bounds.Size);

			// Top level Widgets do not scale location
			if (!is_toplevel) {
				if ((specified & BoundsSpecified.X) == BoundsSpecified.X)
					new_bounds.X *= factor.Width;
				if ((specified & BoundsSpecified.Y) == BoundsSpecified.Y)
					new_bounds.Y *= factor.Height;
			}

			if ((specified & BoundsSpecified.Width) == BoundsSpecified.Width && !GetStyle (Widgetstyles.FixedWidth)) {
				int border = (this is Form) ? (this.bounds.Width - this.client_size.Width) : 0;
				new_bounds.Width = ((new_bounds.Width - border) * factor.Width + border);
			}
			if ((specified & BoundsSpecified.Height) == BoundsSpecified.Height && !GetStyle (Widgetstyles.FixedHeight)) {
				int border = (this is Form) ? (this.bounds.Height - this.client_size.Height) : 0;
				new_bounds.Height = ((new_bounds.Height - border) * factor.Height + border);
			}

			bounds.X = (int)Math.Round (new_bounds.X);
			bounds.Y = (int)Math.Round (new_bounds.Y);
			bounds.Width = (int)Math.Round (new_bounds.Right) - bounds.X;
			bounds.Height = (int)Math.Round (new_bounds.Bottom) - bounds.Y;

			return bounds;
		}

		protected internal bool GetStyle(Widgetstyles flag) {
			return (Widget_style & flag) != 0;
		}

		protected bool GetTopLevel() {
			return is_toplevel;
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void InitLayout() {
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void InvokeGotFocus(Widget toInvoke, EventArgs e) {
			toInvoke.OnGotFocus(e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void InvokeLostFocus(Widget toInvoke, EventArgs e) {
			toInvoke.OnLostFocus(e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void InvokeOnClick(Widget toInvoke, EventArgs e) {
			toInvoke.OnClick(e);
		}

		protected void InvokePaint(Widget c, PaintEventArgs e) {
			c.OnPaint (e);
		}

		protected void InvokePaintBackground(Widget c, PaintEventArgs e) {
			c.OnPaintBackground (e);
		}

		protected virtual bool IsInputChar (char charCode) {
			// XXX on MS.NET this method causes the handle to be created..
			if (!IsHandleCreated)
				CreateHandle ();

			return IsInputCharInternal (charCode);
		}

		internal virtual bool IsInputCharInternal (char charCode) {
			return false;
		}

		protected virtual bool IsInputKey (Keys keyData) {
			// Doc says this one calls IsInputChar; not sure what to do with that
			return false;
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void NotifyInvalidate(Rectangle invalidatedArea) {
			// override me?
		}

		protected virtual bool ProcessCmdKey(ref Message msg, Keys keyData) {
			if (parent != null) {
				return parent.ProcessCmdKey(ref msg, keyData);
			}

			return false;
		}

		protected virtual bool ProcessDialogChar(char charCode) {
			if (parent != null) {
				return parent.ProcessDialogChar (charCode);
			}

			return false;
		}

		protected virtual bool ProcessDialogKey (Keys keyData) {
			if (parent != null) {
				return parent.ProcessDialogKey (keyData);
			}

			return false;
		}

		protected virtual bool ProcessKeyEventArgs (ref Message m)
		{
			KeyEventArgs key_event;

			switch (m.Msg) {
			case (int)Msg.WM_SYSKEYDOWN:
			case (int)Msg.WM_KEYDOWN: {
					key_event = new KeyEventArgs (((Keys) m.WParam.ToInt32 ()) | XplatUI.State.ModifierKeys);
					OnKeyDown (key_event);
					suppressing_key_press = key_event.SuppressKeyPress;
					return key_event.Handled;
				}

			case (int)Msg.WM_SYSKEYUP:
			case (int)Msg.WM_KEYUP: {
					key_event = new KeyEventArgs (((Keys) m.WParam.ToInt32 ()) | XplatUI.State.ModifierKeys);
					OnKeyUp (key_event);
					return key_event.Handled;
				}

			case (int)Msg.WM_SYSCHAR:
			case (int)Msg.WM_CHAR: {
					if (suppressing_key_press)
						return true;
					KeyPressEventArgs key_press_event;

					key_press_event = new KeyPressEventArgs ((char) m.WParam);
					OnKeyPress(key_press_event);
					m.WParam = (IntPtr) key_press_event.KeyChar;
					return key_press_event.Handled;
				}

			default: {
					break;
				}
			}

			return false;
		}

		protected internal virtual bool ProcessKeyMessage (ref Message m)
		{
			if (parent != null) {
				if (parent.ProcessKeyPreview (ref m))
					return true;
			}

			return ProcessKeyEventArgs (ref m);
		}

		protected virtual bool ProcessKeyPreview (ref Message m) {
			if (parent != null)
				return parent.ProcessKeyPreview(ref m);

			return false;
		}

		protected virtual bool ProcessMnemonic(char charCode) {
			// override me
			return false;
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void RaiseDragEvent(object key, DragEventArgs e) {
			// MS Internal
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void RaiseKeyEvent(object key, KeyEventArgs e) {
			// MS Internal
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void RaiseMouseEvent(object key, MouseEventArgs e) {
			// MS Internal
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void RaisePaintEvent(object key, PaintEventArgs e) {
			// MS Internal
		}

		private void SetIsRecreating () {
			is_recreating=true;

			foreach (Widget c in Widgets.GetAllWidgets()) {
				c.SetIsRecreating ();
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void RecreateHandle() {
			if (!IsHandleCreated)
				return;

			#if DebugRecreate
			Console.WriteLine("Recreating Widget {0}", XplatUI.Window(window.Handle));
			#endif

			SetIsRecreating ();

			if (IsHandleCreated) {
				#if DebugRecreate
				Console.WriteLine(" + handle is created, destroying it.");
				#endif
				DestroyHandle();
				// WM_DESTROY will CreateHandle for us
			} else {
				#if DebugRecreate
				Console.WriteLine(" + handle is not created, creating it.");
				#endif
				if (!is_created) {
					CreateWidget();
				} else {
					CreateHandle();
				}

				is_recreating = false;
				#if DebugRecreate
				Console.WriteLine (" + new handle = {0:X}", Handle.ToInt32());
				#endif
			}

		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void ResetMouseEventArgs() {
			// MS Internal
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected ContentAlignment RtlTranslateAlignment(ContentAlignment align) {
			if (right_to_left == RightToLeft.No) {
				return align;
			}

			switch (align) {
			case ContentAlignment.TopLeft: {
					return ContentAlignment.TopRight;
				}

			case ContentAlignment.TopRight: {
					return ContentAlignment.TopLeft;
				}

			case ContentAlignment.MiddleLeft: {
					return ContentAlignment.MiddleRight;
				}

			case ContentAlignment.MiddleRight: {
					return ContentAlignment.MiddleLeft;
				}

			case ContentAlignment.BottomLeft: {
					return ContentAlignment.BottomRight;
				}

			case ContentAlignment.BottomRight: {
					return ContentAlignment.BottomLeft;
				}

			default: {
					// if it's center it doesn't change
					return align;
				}
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected HorizontalAlignment RtlTranslateAlignment(HorizontalAlignment align) {
			if ((right_to_left == RightToLeft.No) || (align == HorizontalAlignment.Center)) {
				return align;
			}

			if (align == HorizontalAlignment.Left) {
				return HorizontalAlignment.Right;
			}

			// align must be HorizontalAlignment.Right
			return HorizontalAlignment.Left;
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected LeftRightAlignment RtlTranslateAlignment(LeftRightAlignment align) {
			if (right_to_left == RightToLeft.No) {
				return align;
			}

			if (align == LeftRightAlignment.Left) {
				return LeftRightAlignment.Right;
			}

			// align must be LeftRightAlignment.Right;
			return LeftRightAlignment.Left;
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected ContentAlignment RtlTranslateContent(ContentAlignment align) {
			return RtlTranslateAlignment(align);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected HorizontalAlignment RtlTranslateHorizontal(HorizontalAlignment align) {
			return RtlTranslateAlignment(align);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected LeftRightAlignment RtlTranslateLeftRight(LeftRightAlignment align) {
			return RtlTranslateAlignment(align);
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual void ScaleWidget (SizeF factor, BoundsSpecified specified)
		{
			Rectangle new_bounds = GetScaledBounds (bounds, factor, specified);

			SetBounds (new_bounds.X, new_bounds.Y, new_bounds.Width, new_bounds.Height, specified);
		}

		//[EditorBrowsable (EditorBrowsableState.Never)]
		protected virtual void ScaleCore (float dx, float dy)
		{
			Rectangle new_bounds = GetScaledBoundsOld (bounds, new SizeF (dx, dy), BoundsSpecified.All);

			SuspendLayout ();

			SetBounds (new_bounds.X, new_bounds.Y, new_bounds.Width, new_bounds.Height, BoundsSpecified.All);

			if (ScaleChildrenInternal)
				foreach (Widget c in Widgets.GetAllWidgets ())
					c.Scale (dx, dy);

			ResumeLayout ();
		}

		protected virtual void Select(bool directed, bool forward) {
			IContainerWidget	container;

			container = GetContainerWidget();
			if (container != null && (Widget)container != this)
				container.ActiveWidget = this;
		}

		protected void SetAutoSizeMode (AutoSizeMode mode)
		{
			if (auto_size_mode != mode) {
				auto_size_mode = mode;
				PerformLayout (this, "AutoSizeMode");
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified) {
			SetBoundsCoreInternal (x, y, width, height, specified);
		}

		internal virtual void SetBoundsCoreInternal(int x, int y, int width, int height, BoundsSpecified specified) {
			// Nasty hack for 2.0 DateTimePicker
			height = OverrideHeight (height);

			Rectangle old_explicit = explicit_bounds;
			Rectangle new_bounds = new Rectangle (x, y, width, height);

			// SetBoundsCore updates the Win32 Widget itself. UpdateBounds updates the Widgets variables and fires events, I'm guessing - pdb
			if (IsHandleCreated) {
				XplatUI.SetWindowPos(Handle, x, y, width, height);

				// Win32 automatically changes negative width/height to 0.
				// The Widget has already been sent a WM_WINDOWPOSCHANGED message and it has the correct
				// data, but it'll be overwritten when we call UpdateBounds unless we get the updated
				// size.
				int cw, ch, ix, iy;
				XplatUI.GetWindowPos(Handle, this is Form, out ix, out iy, out width, out height, out cw, out ch);
			}

			// BoundsSpecified tells us which variables were programatic (user-set).
			// We need to store those in the explicit bounds
			if ((specified & BoundsSpecified.X) == BoundsSpecified.X)
				explicit_bounds.X = new_bounds.X;
			else
				explicit_bounds.X = old_explicit.X;

			if ((specified & BoundsSpecified.Y) == BoundsSpecified.Y)
				explicit_bounds.Y = new_bounds.Y;
			else
				explicit_bounds.Y = old_explicit.Y;

			if ((specified & BoundsSpecified.Width) == BoundsSpecified.Width)
				explicit_bounds.Width = new_bounds.Width;
			else
				explicit_bounds.Width = old_explicit.Width;

			if ((specified & BoundsSpecified.Height) == BoundsSpecified.Height)
				explicit_bounds.Height = new_bounds.Height;
			else
				explicit_bounds.Height = old_explicit.Height;

			// We need to store the explicit bounds because UpdateBounds is always going
			// to change it, and we have to fix it.  However, UpdateBounds also calls
			// OnLocationChanged, OnSizeChanged, and OnClientSizeChanged.  The user can
			// override those or use those events to change the size explicitly, and we 
			// can't undo those changes.  So if the bounds after calling UpdateBounds are
			// the same as the ones we sent it, we need to fix the explicit bounds.  If
			// it's not the same as we sent UpdateBounds, then someone else changed it, and
			// we better not mess it up.  Fun stuff.
			Rectangle stored_explicit_bounds = explicit_bounds;

			UpdateBounds(x, y, width, height);

			if (explicit_bounds.X == x)
				explicit_bounds.X = stored_explicit_bounds.X;

			if (explicit_bounds.Y == y)
				explicit_bounds.Y = stored_explicit_bounds.Y;

			if (explicit_bounds.Width == width)
				explicit_bounds.Width = stored_explicit_bounds.Width;

			if (explicit_bounds.Height == height)
				explicit_bounds.Height = stored_explicit_bounds.Height;
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void SetClientSizeCore(int x, int y) {
			Size NewSize = InternalSizeFromClientSize (new Size (x, y));

			if (NewSize != Size.Empty)
				SetBounds (bounds.X, bounds.Y, NewSize.Width, NewSize.Height, BoundsSpecified.Size);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected internal void SetStyle(Widgetstyles flag, bool value) {
			if (value) {
				Widget_style |= flag;
			} else {
				Widget_style &= ~flag;
			}
		}

		protected void SetTopLevel(bool value) {
			if ((GetTopLevel() != value) && (parent != null)) {
				throw new ArgumentException ("Cannot change toplevel style of a parented Widget.");
			}

			if (this is Form) {
				if (IsHandleCreated && value != Visible) {
					Visible = value;
				}
			} else {
				// XXX MS.NET causes handle to be created here
				if (!IsHandleCreated)
					CreateHandle ();
			}
			is_toplevel = value;
		}

		protected virtual void SetVisibleCore(bool value) {
			if (value != is_visible) {
				is_visible = value;

				if (is_visible && ((window.Handle == IntPtr.Zero) || !is_created)) {
					CreateWidget();
					if (!(this is Form))
						UpdateZOrder ();
				}

				if (IsHandleCreated) {
					XplatUI.SetVisible (Handle, is_visible, true);
					if (!is_visible) {
						if (parent != null && parent.IsHandleCreated) {
							parent.Invalidate (bounds);
							parent.Update ();
						} else {
							Refresh ();
						}
					} else if (is_visible && this is Form) {
						// If we are Min or Max, we won't get a WM_SHOWWINDOW from SetWindowState,
						// so we need to manually create our children, and set them visible
						// (This normally happens in WmShowWindow.)
						if ((this as Form).WindowState != FormWindowState.Normal)
							OnVisibleChanged (EventArgs.Empty);
						else
							// Explicitly move Toplevel windows to where we want them;
							// apparently moving unmapped toplevel windows doesn't work
							XplatUI.SetWindowPos(window.Handle, bounds.X, bounds.Y, bounds.Width, bounds.Height);	
					} else {
						// If we are becoming visible, z-order may have changed while
						// we were invisible, so update our z-order position
						if (parent != null)
							parent.UpdateZOrderOfChild (this);
					}

					if (!(this is Form))
						OnVisibleChanged (EventArgs.Empty);
				}
				else {
					OnVisibleChanged(EventArgs.Empty);
				}
			}
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual Size SizeFromClientSize (Size clientSize) {
			return InternalSizeFromClientSize (clientSize);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void UpdateBounds() {
			if (!IsHandleCreated)
				return;

			int	x;
			int	y;
			int	width;
			int	height;
			int	client_width;
			int	client_height;

			XplatUI.GetWindowPos(this.Handle, this is Form, out x, out y, out width, out height, out client_width, out client_height);

			UpdateBounds(x, y, width, height, client_width, client_height);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void UpdateBounds(int x, int y, int width, int height) {
			CreateParams	cp;
			Rectangle	rect;

			// Calculate client rectangle
			rect = new Rectangle(0, 0, 0, 0);
			cp = CreateParams;

			XplatUI.CalculateWindowRect(ref rect, cp, cp.menu, out rect);
			UpdateBounds(x, y, width, height, width - (rect.Right - rect.Left), height - (rect.Bottom - rect.Top));
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void UpdateBounds(int x, int y, int width, int height, int clientWidth, int clientHeight) {
			// UpdateBounds only seems to set our sizes and fire events but not update the GUI window to match
			bool	moved	= false;
			bool	resized	= false;

			// Needed to generate required notifications
			if ((this.bounds.X!=x) || (this.bounds.Y!=y)) {
				moved=true;
			}

			if ((this.Bounds.Width!=width) || (this.Bounds.Height!=height)) {
				resized=true;
			}

			bounds.X=x;
			bounds.Y=y;
			bounds.Width=width;
			bounds.Height=height;

			// Assume explicit bounds set. SetBoundsCore will restore old bounds
			// if needed.
			explicit_bounds = bounds;

			client_size.Width=clientWidth;
			client_size.Height=clientHeight;

			if (moved) {
				OnLocationChanged(EventArgs.Empty);

				if (!background_color.IsEmpty && background_color.A < byte.MaxValue)
					Invalidate ();
			}

			if (resized) {
				OnSizeInitializedOrChanged ();
				OnSizeChanged(EventArgs.Empty);
				OnClientSizeChanged (EventArgs.Empty);
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void UpdateStyles() {
			if (!IsHandleCreated) {
				return;
			}
            XplatUI.SetWindowStyle(window.Handle, CreateParams);
			OnStyleChanged(EventArgs.Empty);
		}

		private void UpdateZOrderOfChild(Widget child) {
			if (IsHandleCreated && child.IsHandleCreated && (child.parent == this) && Hwnd.ObjectFromHandle(child.Handle).Mapped) {
				// Need to take into account all Widgets
				Widget [] all_Widgets = child_Widgets.GetAllWidgets ();

				int index = Array.IndexOf (all_Widgets, child);

				for (; index > 0; index--) {
					if (!all_Widgets [index - 1].IsHandleCreated || !all_Widgets [index - 1].VisibleInternal || !Hwnd.ObjectFromHandle(all_Widgets [index - 1].Handle).Mapped)
						continue;
					break;
				}

				if (index > 0)	{
					XplatUI.SetZOrder(child.Handle, all_Widgets [index - 1].Handle, false, false);
				} else {
					IntPtr after = AfterTopMostWidget ();
					if (after != IntPtr.Zero && after != child.Handle)
						XplatUI.SetZOrder (child.Handle, after, false, false);
					else
						XplatUI.SetZOrder (child.Handle, IntPtr.Zero, true, false);
				}
			}
		}

		// Override this if there is a Widget that shall always remain on
		// top of other Widgets (such as scrollbars). If there are several
		// of these Widgets, the bottom-most should be returned.
		internal virtual IntPtr AfterTopMostWidget () {
			return IntPtr.Zero;
		}

		// internal because we need to call it from ScrollableWidget.OnVisibleChanged
		internal void UpdateChildrenZOrder() {
			Widget [] Widgets;

			if (!IsHandleCreated) {
				return;
			}

			// XXX This code is severely broken.  It leaks
			// the "zero_sized" abstraction out of the X11
			// backend and into Widget.cs.  It'll work on
			// windows simply by virtue of windows never
			// setting that field to true.
			//
			// basically what we need to guard against is
			// calling XplatUI.SetZOrder on an hwnd that
			// corresponds to an unmapped X window.
			//
			// Also, explicitly send implicit Widgets to the back.
			if (child_Widgets.ImplicitWidgets == null) {
				Widgets = new Widget [child_Widgets.Count];
				child_Widgets.CopyTo (Widgets, 0);
			} else {
				Widgets = new Widget [child_Widgets.Count + child_Widgets.ImplicitWidgets.Count];
				child_Widgets.CopyTo (Widgets, 0);
				child_Widgets.ImplicitWidgets.CopyTo (Widgets, child_Widgets.Count);
			}

			ArrayList children_to_order = new ArrayList ();

			for (int i = 0; i < Widgets.Length; i ++) {
				if (!Widgets[i].IsHandleCreated || !Widgets[i].VisibleInternal)
					continue;

				Hwnd hwnd = Hwnd.ObjectFromHandle (Widgets[i].Handle);
				if (hwnd == null || hwnd.zero_sized)
					continue;

				children_to_order.Add (Widgets[i]);
			}

			for (int i = 1; i < children_to_order.Count; i ++) {
				Widget upper = (Widget)children_to_order[i-1];
				Widget lower = (Widget)children_to_order[i];

				XplatUI.SetZOrder(lower.Handle, upper.Handle, false, false);
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void UpdateZOrder() {
			if (parent != null) {
				parent.UpdateZOrderOfChild(this);
			}
		}

		protected virtual void WndProc(ref Message m) {
			#if DebugMessages
			Console.WriteLine("Widget {0} received message {1}", window.Handle == IntPtr.Zero ? this.Text : XplatUI.Window(window.Handle), m.ToString ());
			#endif
			if ((this.Widget_style & Widgetstyles.EnableNotifyMessage) != 0) {
				OnNotifyMessage(m);
			}

			switch((Msg)m.Msg) {
			case Msg.WM_DESTROY: {
					WmDestroy(ref m);
					return;
				}

			case Msg.WM_WINDOWPOSCHANGED: {
					WmWindowPosChanged(ref m);
					return;
				}

				// Nice description of what should happen when handling WM_PAINT
				// can be found here: http://pluralsight.com/wiki/default.aspx/Craig/FlickerFreeWidgetDrawing.html
				// and here http://msdn.microsoft.com/msdnmag/issues/06/03/WindowsFormsPerformance/
			case Msg.WM_PAINT: {
					WmPaint (ref m);
					return;
				}

				// The DefWndProc will never have to handle this, we always paint the background in managed code
				// In theory this code would look at Widgetstyles.AllPaintingInWmPaint and and call OnPaintBackground
				// here but it just makes things more complicated...
			case Msg.WM_ERASEBKGND: {
					WmEraseBackground (ref m);
					return;
				}

			case Msg.WM_LBUTTONUP: {
					WmLButtonUp (ref m);
					return;
				}

			case Msg.WM_LBUTTONDOWN: {
					WmLButtonDown (ref m);
					return;
				}

			case Msg.WM_LBUTTONDBLCLK: {
					WmLButtonDblClick (ref m);
					return;
				}

			case Msg.WM_MBUTTONUP: {
					WmMButtonUp (ref m);
					return;
				}

			case Msg.WM_MBUTTONDOWN: {					
					WmMButtonDown (ref m);
					return;
				}

			case Msg.WM_MBUTTONDBLCLK: {
					WmMButtonDblClick (ref m);
					return;
				}

			case Msg.WM_RBUTTONUP: {
					WmRButtonUp (ref m);
					return;
				}

			case Msg.WM_RBUTTONDOWN: {					
					WmRButtonDown (ref m);
					return;
				}

			case Msg.WM_RBUTTONDBLCLK: {
					WmRButtonDblClick (ref m);
					return;
				}

			case Msg.WM_CONTEXTMENU: {
					WmContextMenu (ref m);
					return;
				}

			case Msg.WM_MOUSEWHEEL: {
					WmMouseWheel (ref m);
					return;
				}

			case Msg.WM_MOUSEMOVE: {
					WmMouseMove (ref m);
					return;
				}

			case Msg.WM_SHOWWINDOW: {
					WmShowWindow (ref m);
					return;
				}

			case Msg.WM_CREATE: {
					WmCreate (ref m);
					return;
				}

			case Msg.WM_MOUSE_ENTER: {
					WmMouseEnter (ref m);
					return;
				}

			case Msg.WM_MOUSELEAVE: {
					WmMouseLeave (ref m);
					return;
				}

			case Msg.WM_MOUSEHOVER:	{
					WmMouseHover (ref m);
					return;
				}

			case Msg.WM_SYSKEYUP: {
					WmSysKeyUp (ref m);
					return;
				}

			case Msg.WM_SYSKEYDOWN:
			case Msg.WM_KEYDOWN:
			case Msg.WM_KEYUP:
			case Msg.WM_SYSCHAR:
			case Msg.WM_CHAR: {
					WmKeys (ref m);
					return;
				}

			case Msg.WM_HELP: {
					WmHelp (ref m);
					return;
				}

			case Msg.WM_KILLFOCUS: {
					WmKillFocus (ref m);
					return;
				}

			case Msg.WM_SETFOCUS: {
					WmSetFocus (ref m);
					return;
				}

			case Msg.WM_SYSCOLORCHANGE: {
					WmSysColorChange (ref m);
					return;
				}

			case Msg.WM_SETCURSOR: {
					WmSetCursor (ref m);
					return;
				}

			case Msg.WM_CAPTURECHANGED: {
					WmCaptureChanged (ref m);
					return;
				}

			case Msg.WM_CHANGEUISTATE: {
					WmChangeUIState (ref m);
					return;
				}

			case Msg.WM_UPDATEUISTATE: {
					WmUpdateUIState (ref m);
					return;
				}

			default:
				DefWndProc(ref m);
				return;
			}
		}

		#endregion	// Public Instance Methods

		#region WM methods

		private void WmDestroy (ref Message m) {
			OnHandleDestroyed(EventArgs.Empty);
			#if DebugRecreate
			IntPtr handle = window.Handle;
			#endif
			window.InvalidateHandle();

			is_created = false;
			if (is_recreating) {
				#if DebugRecreate
				Console.WriteLine ("Creating handle for {0:X}", handle.ToInt32());
				#endif
				CreateHandle();
				#if DebugRecreate
				Console.WriteLine (" + new handle = {0:X}", Handle.ToInt32());
				#endif
				is_recreating = false;
			}

			if (is_disposing) {
				is_disposing = false;
				is_visible = false;
			}
		}

		private void WmWindowPosChanged (ref Message m) {
			if (Visible) {
				Rectangle save_bounds = explicit_bounds;
				UpdateBounds();
				explicit_bounds = save_bounds;
				if (GetStyle(Widgetstyles.ResizeRedraw)) {
					Invalidate();
				}
			}
		}


		// Nice description of what should happen when handling WM_PAINT
		// can be found here: http://pluralsight.com/wiki/default.aspx/Craig/FlickerFreeWidgetDrawing.html
		// and here http://msdn.microsoft.com/msdnmag/issues/06/03/WindowsFormsPerformance/
		private void WmPaint (ref Message m) {
			IntPtr handle = Handle;

			PaintEventArgs paint_event = XplatUI.PaintEventStart (ref m, handle, true);

			if (paint_event == null)
				return;

			DoubleBuffer current_buffer = null;
			if (UseDoubleBuffering) {
				current_buffer = GetBackBuffer ();
				// This optimization doesn't work when the area is invalidated
				// during a paint operation because finishing the paint operation
				// clears the invalidated region and then this thing keeps the new
				// invalidate from working.  To re-enable this, we would need a
				// mechanism to allow for nested invalidates (see bug #328681)
				//if (!current_buffer.InvalidRegion.IsVisible (paint_event.ClipRectangle)) {
				//        // Just blit the previous image
				//        current_buffer.Blit (paint_event);
				//        XplatUI.PaintEventEnd (ref m, handle, true);
				//        return;
				//}
				current_buffer.Start (paint_event);
			}
			// If using OptimizedDoubleBuffer, ensure the clip region gets set
			if (GetStyle (Widgetstyles.OptimizedDoubleBuffer))
				paint_event.Graphics.SetClip (Rectangle.Intersect (paint_event.ClipRectangle, this.ClientRectangle));

			if (!GetStyle(Widgetstyles.Opaque)) {
				OnPaintBackground (paint_event);
			}

			// Button-derived Widgets choose to ignore their Opaque style, give them a chance to draw their background anyways
			OnPaintBackgroundInternal (paint_event);

			OnPaintInternal(paint_event);
			if (!paint_event.Handled) {
				OnPaint (paint_event);
			}

			if (current_buffer != null) {
				current_buffer.End (paint_event);
			}


			XplatUI.PaintEventEnd (ref m, handle, true);
		}

		private void WmEraseBackground (ref Message m) {
			// The DefWndProc will never have to handle this, we always paint the background in managed code
			// In theory this code would look at Widgetstyles.AllPaintingInWmPaint and and call OnPaintBackground
			// here but it just makes things more complicated...
			m.Result = (IntPtr)1;
		}

		private void WmLButtonUp (ref Message m)
		{
			// Menu handle.
			if (XplatUI.IsEnabled (Handle) && active_tracker != null) {
				ProcessActiveTracker (ref m);
				return;
			}

			MouseEventArgs me;

			me = new MouseEventArgs (FromParamToMouseButtons ((int) m.WParam.ToInt32()) | MouseButtons.Left, 
				mouse_clicks, 
				LowOrder ((int) m.LParam.ToInt32 ()), HighOrder ((int) m.LParam.ToInt32 ()), 
				0);

			HandleClick(mouse_clicks, me);
			OnMouseUp (me);

			if (InternalCapture) {
				InternalCapture = false;
			}

			if (mouse_clicks > 1) {
				mouse_clicks = 1;
			}
		}

		private void WmLButtonDown (ref Message m)
		{
			// Menu handle.
			if (XplatUI.IsEnabled (Handle) && active_tracker != null) {
				ProcessActiveTracker (ref m);
				return;
			}

			ValidationFailed = false;
			if (CanSelect) {
				Select (true, true);
			}
			if (!ValidationFailed) {
				InternalCapture = true;
				OnMouseDown (new MouseEventArgs (FromParamToMouseButtons ((int) m.WParam.ToInt32()), 
					mouse_clicks, LowOrder ((int) m.LParam.ToInt32 ()), HighOrder ((int) m.LParam.ToInt32 ()), 
					0));
			}
		}

		private void WmLButtonDblClick (ref Message m) {
			InternalCapture = true;
			mouse_clicks++;
			OnMouseDown (new MouseEventArgs (FromParamToMouseButtons ((int) m.WParam.ToInt32()), 
				mouse_clicks, LowOrder ((int) m.LParam.ToInt32 ()), HighOrder ((int) m.LParam.ToInt32 ()), 
				0));
		}

		private void WmMButtonUp (ref Message m) {
			MouseEventArgs me;

			me = new MouseEventArgs (FromParamToMouseButtons ((int) m.WParam.ToInt32()) | MouseButtons.Middle, 
				mouse_clicks, 
				LowOrder ((int) m.LParam.ToInt32 ()), HighOrder ((int) m.LParam.ToInt32 ()), 
				0);

			HandleClick(mouse_clicks, me);
			OnMouseUp (me);
			if (InternalCapture) {
				InternalCapture = false;
			}
			if (mouse_clicks > 1) {
				mouse_clicks = 1;
			}
		}

		private void WmMButtonDown (ref Message m) {
			InternalCapture = true;
			OnMouseDown (new MouseEventArgs (FromParamToMouseButtons ((int) m.WParam.ToInt32()), 
				mouse_clicks, LowOrder ((int) m.LParam.ToInt32 ()), HighOrder ((int) m.LParam.ToInt32 ()), 
				0));
		}

		private void WmMButtonDblClick (ref Message m) {
			InternalCapture = true;
			mouse_clicks++;
			OnMouseDown (new MouseEventArgs (FromParamToMouseButtons ((int) m.WParam.ToInt32()), 
				mouse_clicks, LowOrder ((int) m.LParam.ToInt32 ()), HighOrder ((int) m.LParam.ToInt32 ()), 
				0));
		}

		private void WmRButtonUp (ref Message m)
		{
			// Menu handle.
			if (XplatUI.IsEnabled (Handle) && active_tracker != null) {
				ProcessActiveTracker (ref m);
				return;
			}

			MouseEventArgs	me;
			Point		pt;

			pt = new Point(LowOrder ((int) m.LParam.ToInt32 ()), HighOrder ((int) m.LParam.ToInt32 ()));
			pt = PointToScreen(pt);

			me = new MouseEventArgs (FromParamToMouseButtons ((int) m.WParam.ToInt32()) | MouseButtons.Right, 
				mouse_clicks, 
				LowOrder ((int) m.LParam.ToInt32 ()), HighOrder ((int) m.LParam.ToInt32 ()), 
				0);

			HandleClick(mouse_clicks, me);

			XplatUI.SendMessage(m.HWnd, Msg.WM_CONTEXTMENU, m.HWnd, (IntPtr)(pt.X + (pt.Y << 16)));
			OnMouseUp (me);

			if (InternalCapture) {
				InternalCapture = false;
			}

			if (mouse_clicks > 1) {
				mouse_clicks = 1;
			}
		}

		private void WmRButtonDown (ref Message m)
		{
			// Menu handle.
			if (XplatUI.IsEnabled (Handle) && active_tracker != null) {
				ProcessActiveTracker (ref m);
				return;
			}

			InternalCapture = true;
			OnMouseDown (new MouseEventArgs (FromParamToMouseButtons ((int) m.WParam.ToInt32()), 
				mouse_clicks, LowOrder ((int) m.LParam.ToInt32 ()), HighOrder ((int) m.LParam.ToInt32 ()), 
				0));
		}

		private void WmRButtonDblClick (ref Message m) {
			InternalCapture = true;
			mouse_clicks++;
			OnMouseDown (new MouseEventArgs (FromParamToMouseButtons ((int) m.WParam.ToInt32()), 
				mouse_clicks, LowOrder ((int) m.LParam.ToInt32 ()), HighOrder ((int) m.LParam.ToInt32 ()), 
				0));
		}

		private void WmContextMenu (ref Message m) {
			// If there isn't a regular context menu, show the Strip version
			if (context_menu_strip != null) {
				Point pt;

				pt = new Point (LowOrder ((int)m.LParam.ToInt32 ()), HighOrder ((int)m.LParam.ToInt32 ()));

				if (pt.X == -1 || pt.Y == -1) { 
					pt.X = (this.Width / 2) + this.Left; 
					pt.Y = (this.Height /2) + this.Top; 
					pt = this.PointToScreen (pt);
				}

				context_menu_strip.SetSourceWidget (this);
				context_menu_strip.Show (this, PointToClient (pt));
				return;
			}
			DefWndProc(ref m);
		}

		private void WmCreate (ref Message m) {
			OnHandleCreated(EventArgs.Empty);
		}

		private void WmMouseWheel (ref Message m) {
			DefWndProc(ref m);
			OnMouseWheel (new MouseEventArgs (FromParamToMouseButtons ((long) m.WParam), 
				mouse_clicks, LowOrder ((int) m.LParam.ToInt32 ()), HighOrder ((int) m.LParam.ToInt32 ()), 
				HighOrder((long)m.WParam)));
		}


		private void WmMouseMove (ref Message m) {
			if (XplatUI.IsEnabled (Handle) && active_tracker != null) {
				MouseEventArgs args = new MouseEventArgs (
					FromParamToMouseButtons ((int)m.WParam.ToInt32 ()),
					mouse_clicks,
					Widget.MousePosition.X,
					Widget.MousePosition.Y,
					0);

				active_tracker.OnMotion (args);
				return;
			}

			OnMouseMove  (new MouseEventArgs (FromParamToMouseButtons ((int) m.WParam.ToInt32()), 
				mouse_clicks, 
				LowOrder ((int) m.LParam.ToInt32 ()), HighOrder ((int) m.LParam.ToInt32 ()), 
				0));
		}

		private void WmMouseEnter (ref Message m) {
			if (is_entered) {
				return;
			}
			is_entered = true;
			OnMouseEnter(EventArgs.Empty);
		}

		private void WmMouseLeave (ref Message m) {
			is_entered=false;
			OnMouseLeave(EventArgs.Empty);
		}

		private void WmMouseHover (ref Message m) {
			OnMouseHover(EventArgs.Empty);
		}

		private void WmShowWindow (ref Message m) {
			if (IsDisposed)
				return;

			Form frm = this as Form;
			if (m.WParam.ToInt32() != 0) {
				if (m.LParam.ToInt32 () == 0) {
					CreateWidget ();

					// Make sure all our children are properly parented to us
					Widget [] Widgets = child_Widgets.GetAllWidgets ();
					//					bool parented = false;
					for (int i=0; i<Widgets.Length; i++) {
						if (Widgets [i].is_visible && Widgets[i].IsHandleCreated)
						if (XplatUI.GetParent (Widgets[i].Handle) != window.Handle) {
							XplatUI.SetParent(Widgets[i].Handle, window.Handle);
							//								parented = true;
						}

					}

					//if (parented)
					UpdateChildrenZOrder ();
				}
			} else {
				if (parent != null && Focused) {
					Widget	container;
					// Need to start at parent, GetContainerWidget might return ourselves if we're a container
					container = (Widget)parent.GetContainerWidget();
					if (container != null && (frm == null || !frm.IsMdiChild)) {
						container.SelectNextWidget(this, true, true, true, true);
					}
				}
			}

			if (frm != null)
				frm.waiting_showwindow = false;

			// If the form is Max/Min, it got its OnVisibleChanged in SetVisibleCore
			if (frm != null) {
				if (!IsRecreating && (frm.IsMdiChild || frm.WindowState == FormWindowState.Normal)) /* XXX make sure this works for mdi forms */
					OnVisibleChanged(EventArgs.Empty);
			} else if (is_toplevel)
				OnVisibleChanged(EventArgs.Empty);
		}

		private void WmSysKeyUp (ref Message m) {
			if (ProcessKeyMessage(ref m)) {
				m.Result = IntPtr.Zero;
				return;
			}

			if ((m.WParam.ToInt32() & (int)Keys.KeyCode) == (int)Keys.Menu) {
				Form	form;

				form = FindForm();
				if (form != null && form.ActiveMenu != null) {
					form.ActiveMenu.ProcessCmdKey(ref m, (Keys)m.WParam.ToInt32());
				}
				else
					if (ToolStripManager.ProcessMenuKey (ref m))
						return;
			}

			DefWndProc (ref m);
		}

		private void WmKeys (ref Message m)
		{
			if (ProcessKeyMessage(ref m)) {
				m.Result = IntPtr.Zero;
				return;
			}
			DefWndProc (ref m);
		}

		private void WmHelp (ref Message m) {
			Point	mouse_pos;
			if (m.LParam != IntPtr.Zero) {
				HELPINFO	hi;

				hi = new HELPINFO();

				hi = (HELPINFO) Marshal.PtrToStructure (m.LParam, typeof (HELPINFO));
				mouse_pos = new Point(hi.MousePos.x, hi.MousePos.y);
			} else {
				mouse_pos = Widget.MousePosition;
			}
			OnHelpRequested(new HelpEventArgs(mouse_pos));
			m.Result = (IntPtr)1;
		}

		private void WmKillFocus (ref Message m) {
			this.has_focus = false;
			OnLostFocus (EventArgs.Empty);
		}

		private void WmSetFocus (ref Message m) {
			if (!has_focus) {
				this.has_focus = true;
				OnGotFocus (EventArgs.Empty);
			}
		}

		private void WmSysColorChange (ref Message m) {
			ThemeEngine.Current.ResetDefaults();
			OnSystemColorsChanged(EventArgs.Empty);
		}

		private void WmSetCursor (ref Message m) {
			if ((cursor == null && use_wait_cursor == false) || ((HitTest)(m.LParam.ToInt32() & 0xffff) != HitTest.HTCLIENT)) {
				DefWndProc(ref m);
				return;
			}

			XplatUI.SetCursor(window.Handle, Cursor.handle);
			m.Result = (IntPtr)1;
		}

		private void WmCaptureChanged (ref Message m) {
			is_captured = false;
			OnMouseCaptureChanged (EventArgs.Empty);
			m.Result = (IntPtr) 0;
		}

		private void WmChangeUIState (ref Message m) {
			foreach (Widget Widget in Widgets) {
				XplatUI.SendMessage (Widget.Handle, Msg.WM_UPDATEUISTATE, m.WParam, m.LParam);
			}
		}

		private void WmUpdateUIState (ref Message m) {
			int action = LowOrder (m.WParam.ToInt32 ());
			int element = HighOrder (m.WParam.ToInt32 ());

			if (action == (int) MsgUIState.UIS_INITIALIZE)
				return;

			UICues cues = UICues.None;

			if ((element & (int) MsgUIState.UISF_HIDEACCEL) != 0) {
				if ((action == (int) MsgUIState.UIS_CLEAR) != show_keyboard_cues) {
					cues |= UICues.ChangeKeyboard;
					show_keyboard_cues = (action == (int) MsgUIState.UIS_CLEAR);
				}
			}

			if ((element & (int) MsgUIState.UISF_HIDEFOCUS) != 0) {
				if ((action == (int) MsgUIState.UIS_CLEAR) != show_focus_cues) {
					cues |= UICues.ChangeFocus;
					show_focus_cues = (action == (int) MsgUIState.UIS_CLEAR);
				}
			}

			if ((cues & UICues.Changed) != UICues.None) {
				OnChangeUICues (new UICuesEventArgs (cues));
				Invalidate ();
			}
		}

		#endregion

		#region OnXXX methods
		protected virtual void OnAutoSizeChanged (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events[AutoSizeChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual void OnBackColorChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [BackColorChangedEvent]);
			if (eh != null)
				eh (this, e);
			for (int i=0; i<child_Widgets.Count; i++) child_Widgets[i].OnParentBackColorChanged(e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnBackgroundImageChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [BackgroundImageChangedEvent]);
			if (eh != null)
				eh (this, e);
			for (int i=0; i<child_Widgets.Count; i++) child_Widgets[i].OnParentBackgroundImageChanged(e);
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual void OnBackgroundImageLayoutChanged (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events[BackgroundImageLayoutChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnBindingContextChanged(EventArgs e) {
			CheckDataBindings ();
			EventHandler eh = (EventHandler)(Events [BindingContextChangedEvent]);
			if (eh != null)
				eh (this, e);
			for (int i=0; i<child_Widgets.Count; i++) child_Widgets[i].OnParentBindingContextChanged(e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnCausesValidationChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [CausesValidationChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnChangeUICues(UICuesEventArgs e) {
			UICuesEventHandler eh = (UICuesEventHandler)(Events [ChangeUICuesEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnClick(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [ClickEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual void OnClientSizeChanged (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events[ClientSizeChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnContextMenuChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [ContextMenuChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual void OnContextMenuStripChanged (EventArgs e) {
			EventHandler eh = (EventHandler)(Events [ContextMenuStripChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnWidgetAdded(WidgetEventArgs e) {
			WidgetEventHandler eh = (WidgetEventHandler)(Events [WidgetAddedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnWidgetRemoved(WidgetEventArgs e) {
			WidgetEventHandler eh = (WidgetEventHandler)(Events [WidgetRemovedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnCreateWidget() {
			// Override me!
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnCursorChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [CursorChangedEvent]);
			if (eh != null)
				eh (this, e);

			for (int i = 0; i < child_Widgets.Count; i++) child_Widgets[i].OnParentCursorChanged (e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDockChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [DockChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDoubleClick(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [DoubleClickEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDragDrop(DragEventArgs drgevent) {
			DragEventHandler eh = (DragEventHandler)(Events [DragDropEvent]);
			if (eh != null)
				eh (this, drgevent);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDragEnter(DragEventArgs drgevent) {
			DragEventHandler eh = (DragEventHandler)(Events [DragEnterEvent]);
			if (eh != null)
				eh (this, drgevent);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDragLeave(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [DragLeaveEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDragOver(DragEventArgs drgevent) {
			DragEventHandler eh = (DragEventHandler)(Events [DragOverEvent]);
			if (eh != null)
				eh (this, drgevent);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnEnabledChanged(EventArgs e) {
			if (IsHandleCreated) {
				if (this is Form) {
					if (((Form)this).context == null) {
						XplatUI.EnableWindow(window.Handle, Enabled);
					}
				} else {
					XplatUI.EnableWindow(window.Handle, Enabled);
				}
				Refresh();
			}

			EventHandler eh = (EventHandler)(Events [EnabledChangedEvent]);
			if (eh != null)
				eh (this, e);

			foreach (Widget c in Widgets.GetAllWidgets ())
				c.OnParentEnabledChanged (e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnEnter(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [EnterEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnFontChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [FontChangedEvent]);
			if (eh != null)
				eh (this, e);
			for (int i=0; i<child_Widgets.Count; i++) child_Widgets[i].OnParentFontChanged(e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnForeColorChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [ForeColorChangedEvent]);
			if (eh != null)
				eh (this, e);
			for (int i=0; i<child_Widgets.Count; i++) child_Widgets[i].OnParentForeColorChanged(e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnGiveFeedback(GiveFeedbackEventArgs gfbevent) {
			GiveFeedbackEventHandler eh = (GiveFeedbackEventHandler)(Events [GiveFeedbackEvent]);
			if (eh != null)
				eh (this, gfbevent);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnGotFocus(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [GotFocusEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnHandleCreated(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [HandleCreatedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnHandleDestroyed(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [HandleDestroyedEvent]);
			if (eh != null)
				eh (this, e);
		}

		internal void RaiseHelpRequested (HelpEventArgs hevent) {
			OnHelpRequested (hevent);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnHelpRequested(HelpEventArgs hevent) {
			HelpEventHandler eh = (HelpEventHandler)(Events [HelpRequestedEvent]);
			if (eh != null)
				eh (this, hevent);
		}

		protected virtual void OnImeModeChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [ImeModeChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnInvalidated(InvalidateEventArgs e) {
			if (UseDoubleBuffering) {
				// should this block be here?  seems like it
				// would be more at home in
				// NotifyInvalidated..
				if (e.InvalidRect == ClientRectangle) {
					InvalidateBackBuffer ();
				} else if (backbuffer != null){
					// we need this Inflate call here so
					// that the border of the rectangle is
					// considered Visible (the
					// invalid_region.IsVisible call) in
					// the WM_PAINT handling below.
					Rectangle r = Rectangle.Inflate(e.InvalidRect, 1,1);
					backbuffer.InvalidRegion.Union (r);
				}
			}

			InvalidateEventHandler eh = (InvalidateEventHandler)(Events [InvalidatedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnKeyDown(KeyEventArgs e) {
			KeyEventHandler eh = (KeyEventHandler)(Events [KeyDownEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnKeyPress(KeyPressEventArgs e) {
			KeyPressEventHandler eh = (KeyPressEventHandler)(Events [KeyPressEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnKeyUp(KeyEventArgs e) {
			KeyEventHandler eh = (KeyEventHandler)(Events [KeyUpEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnLayout(LayoutEventArgs levent) {
			LayoutEventHandler eh = (LayoutEventHandler)(Events [LayoutEvent]);
			if (eh != null)
				eh (this, levent);

			Size s = Size;

			// If our layout changed our PreferredSize, our parent
			// needs to re-lay us out.  However, it's not always possible to
			// be our preferred size, so only try once so we don't loop forever.
			if (Parent != null && AutoSize && !nested_layout && PreferredSize != s) {
				nested_layout = true;
				Parent.PerformLayout ();
				nested_layout = false;
			}

			LayoutEngine.Layout (this, levent);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnLeave(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [LeaveEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnLocationChanged(EventArgs e) {
			OnMove(e);
			EventHandler eh = (EventHandler)(Events [LocationChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnLostFocus(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [LostFocusEvent]);
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnMarginChanged (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events[MarginChangedEvent]);
			if (eh != null)
				eh (this, e);
		}
		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual void OnMouseCaptureChanged (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events [MouseCaptureChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual void OnMouseClick (MouseEventArgs e)
		{
			MouseEventHandler eh = (MouseEventHandler)(Events [MouseClickEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual void OnMouseDoubleClick (MouseEventArgs e)
		{
			MouseEventHandler eh = (MouseEventHandler)(Events [MouseDoubleClickEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMouseDown(MouseEventArgs e) {
			MouseEventHandler eh = (MouseEventHandler)(Events [MouseDownEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMouseEnter(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [MouseEnterEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMouseHover(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [MouseHoverEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMouseLeave(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [MouseLeaveEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMouseMove(MouseEventArgs e) {
			MouseEventHandler eh = (MouseEventHandler)(Events [MouseMoveEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMouseUp(MouseEventArgs e) {
			MouseEventHandler eh = (MouseEventHandler)(Events [MouseUpEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMouseWheel(MouseEventArgs e) {
			MouseEventHandler eh = (MouseEventHandler)(Events [MouseWheelEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMove(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [MoveEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnNotifyMessage(Message m) {
			// Override me!
		}

		protected virtual void OnPaddingChanged (EventArgs e) {
			EventHandler eh = (EventHandler) (Events [PaddingChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnPaint(PaintEventArgs e) {
			PaintEventHandler eh = (PaintEventHandler)(Events [PaintEvent]);
			if (eh != null)
				eh (this, e);
		}

		internal virtual void OnPaintBackgroundInternal(PaintEventArgs e) {
			// Override me
		}

		internal virtual void OnPaintInternal(PaintEventArgs e) {
			// Override me
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnPaintBackground(PaintEventArgs pevent) {
			PaintWidgetBackground (pevent);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentBackColorChanged(EventArgs e) {
			if (background_color.IsEmpty && background_image==null) {
				Invalidate();
				OnBackColorChanged(e);
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentBackgroundImageChanged(EventArgs e) {
			Invalidate();
			OnBackgroundImageChanged(e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentBindingContextChanged(EventArgs e) {
			if (binding_context==null && Parent != null) {
				binding_context=Parent.binding_context;
				OnBindingContextChanged(e);
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [ParentChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual void OnParentCursorChanged (EventArgs e)
		{
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual void OnParentEnabledChanged(EventArgs e) {
			if (is_enabled) {
				OnEnabledChanged(e);
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentFontChanged(EventArgs e) {
			if (font==null) {
				Invalidate();
				OnFontChanged(e);
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentForeColorChanged(EventArgs e) {
			if (foreground_color.IsEmpty) {
				Invalidate();
				OnForeColorChanged(e);
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentRightToLeftChanged(EventArgs e) {
			if (right_to_left==RightToLeft.Inherit) {
				Invalidate();
				OnRightToLeftChanged(e);
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentVisibleChanged(EventArgs e) {
			if (is_visible) {
				OnVisibleChanged(e);
			}
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnQueryContinueDrag (QueryContinueDragEventArgs qcdevent)
		{
			QueryContinueDragEventHandler eh = (QueryContinueDragEventHandler)(Events [QueryContinueDragEvent]);
			if (eh != null)
				eh (this, qcdevent);
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual void OnPreviewKeyDown (PreviewKeyDownEventArgs e)
		{
			PreviewKeyDownEventHandler eh = (PreviewKeyDownEventHandler)(Events[PreviewKeyDownEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual void OnPrint (PaintEventArgs e)
		{
			PaintEventHandler eh = (PaintEventHandler)(Events[PaintEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected virtual void OnRegionChanged (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events[RegionChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnResize(EventArgs e) {
			OnResizeInternal (e);
		}

		internal virtual void OnResizeInternal (EventArgs e) {
			PerformLayout(this, "Bounds");

			EventHandler eh = (EventHandler)(Events [ResizeEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnRightToLeftChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [RightToLeftChangedEvent]);
			if (eh != null)
				eh (this, e);
			for (int i=0; i<child_Widgets.Count; i++) child_Widgets[i].OnParentRightToLeftChanged(e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnSizeChanged(EventArgs e) {
			DisposeBackBuffer ();
			OnResize(e);
			EventHandler eh = (EventHandler)(Events [SizeChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnStyleChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [StyleChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnSystemColorsChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [SystemColorsChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnTabIndexChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [TabIndexChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnTabStopChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [TabStopChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnTextChanged(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [TextChangedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnValidated(EventArgs e) {
			EventHandler eh = (EventHandler)(Events [ValidatedEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnValidating(System.ComponentModel.CancelEventArgs e) {
			CancelEventHandler eh = (CancelEventHandler)(Events [ValidatingEvent]);
			if (eh != null)
				eh (this, e);
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnVisibleChanged(EventArgs e) {
			if (Visible)
				CreateWidget ();

			EventHandler eh = (EventHandler)(Events [VisibleChangedEvent]);
			if (eh != null)
				eh (this, e);

			// We need to tell our kids (including implicit ones)
			foreach (Widget c in Widgets.GetAllWidgets ())
				if (c.Visible)
					c.OnParentVisibleChanged (e);
		}
		#endregion	// OnXXX methods

		#region Events
		static object AutoSizeChangedEvent = new object ();
		static object BackColorChangedEvent = new object ();
		static object BackgroundImageChangedEvent = new object ();
		static object BackgroundImageLayoutChangedEvent = new object ();
		static object BindingContextChangedEvent = new object ();
		static object CausesValidationChangedEvent = new object ();
		static object ChangeUICuesEvent = new object ();
		static object ClickEvent = new object ();
		static object ClientSizeChangedEvent = new object ();
		static object ContextMenuChangedEvent = new object ();
		static object ContextMenuStripChangedEvent = new object ();
		static object WidgetAddedEvent = new object ();
		static object WidgetRemovedEvent = new object ();
		static object CursorChangedEvent = new object ();
		static object DockChangedEvent = new object ();
		static object DoubleClickEvent = new object ();
		static object DragDropEvent = new object ();
		static object DragEnterEvent = new object ();
		static object DragLeaveEvent = new object ();
		static object DragOverEvent = new object ();
		static object EnabledChangedEvent = new object ();
		static object EnterEvent = new object ();
		static object FontChangedEvent = new object ();
		static object ForeColorChangedEvent = new object ();
		static object GiveFeedbackEvent = new object ();
		static object GotFocusEvent = new object ();
		static object HandleCreatedEvent = new object ();
		static object HandleDestroyedEvent = new object ();
		static object HelpRequestedEvent = new object ();
		static object ImeModeChangedEvent = new object ();
		static object InvalidatedEvent = new object ();
		static object KeyDownEvent = new object ();
		static object KeyPressEvent = new object ();
		static object KeyUpEvent = new object ();
		static object LayoutEvent = new object ();
		static object LeaveEvent = new object ();
		static object LocationChangedEvent = new object ();
		static object LostFocusEvent = new object ();
		static object MarginChangedEvent = new object ();
		static object MouseCaptureChangedEvent = new object ();
		static object MouseClickEvent = new object ();
		static object MouseDoubleClickEvent = new object ();
		static object MouseDownEvent = new object ();
		static object MouseEnterEvent = new object ();
		static object MouseHoverEvent = new object ();
		static object MouseLeaveEvent = new object ();
		static object MouseMoveEvent = new object ();
		static object MouseUpEvent = new object ();
		static object MouseWheelEvent = new object ();
		static object MoveEvent = new object ();
		static object PaddingChangedEvent = new object ();
		static object PaintEvent = new object ();
		static object ParentChangedEvent = new object ();
		static object PreviewKeyDownEvent = new object ();
		static object QueryAccessibilityHelpEvent = new object ();
		static object QueryContinueDragEvent = new object ();
		static object RegionChangedEvent = new object ();
		static object ResizeEvent = new object ();
		static object RightToLeftChangedEvent = new object ();
		static object SizeChangedEvent = new object ();
		static object StyleChangedEvent = new object ();
		static object SystemColorsChangedEvent = new object ();
		static object TabIndexChangedEvent = new object ();
		static object TabStopChangedEvent = new object ();
		static object TextChangedEvent = new object ();
		static object ValidatedEvent = new object ();
		static object ValidatingEvent = new object ();
		static object VisibleChangedEvent = new object ();

		[Browsable (false)]
		//[EditorBrowsable (EditorBrowsableState.Never)]
		public event EventHandler AutoSizeChanged {
			add { Events.AddHandler (AutoSizeChangedEvent, value);}
			remove {Events.RemoveHandler (AutoSizeChangedEvent, value);}
		}
		public event EventHandler BackColorChanged {
			add { Events.AddHandler (BackColorChangedEvent, value); }
			remove { Events.RemoveHandler (BackColorChangedEvent, value); }
		}

		public event EventHandler BackgroundImageChanged {
			add { Events.AddHandler (BackgroundImageChangedEvent, value); }
			remove { Events.RemoveHandler (BackgroundImageChangedEvent, value); }
		}

		public event EventHandler BackgroundImageLayoutChanged {
			add {Events.AddHandler (BackgroundImageLayoutChangedEvent, value);}
			remove {Events.RemoveHandler (BackgroundImageLayoutChangedEvent, value);}
		}

		public event EventHandler BindingContextChanged {
			add { Events.AddHandler (BindingContextChangedEvent, value); }
			remove { Events.RemoveHandler (BindingContextChangedEvent, value); }
		}

		public event EventHandler CausesValidationChanged {
			add { Events.AddHandler (CausesValidationChangedEvent, value); }
			remove { Events.RemoveHandler (CausesValidationChangedEvent, value); }
		}

		public event UICuesEventHandler ChangeUICues {
			add { Events.AddHandler (ChangeUICuesEvent, value); }
			remove { Events.RemoveHandler (ChangeUICuesEvent, value); }
		}

		public event EventHandler Click {
			add { Events.AddHandler (ClickEvent, value); }
			remove { Events.RemoveHandler (ClickEvent, value); }
		}

		public event EventHandler ClientSizeChanged {
			add {Events.AddHandler (ClientSizeChangedEvent, value);}
			remove {Events.RemoveHandler (ClientSizeChangedEvent, value);}
		}

		[Browsable (false)]
		public event EventHandler ContextMenuChanged {
			add { Events.AddHandler (ContextMenuChangedEvent, value); }
			remove { Events.RemoveHandler (ContextMenuChangedEvent, value); }
		}

		public event EventHandler ContextMenuStripChanged {
			add { Events.AddHandler (ContextMenuStripChangedEvent, value); }
			remove { Events.RemoveHandler (ContextMenuStripChangedEvent, value);}
		}


		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(true)]
		public event WidgetEventHandler WidgetAdded {
			add { Events.AddHandler (WidgetAddedEvent, value); }
			remove { Events.RemoveHandler (WidgetAddedEvent, value); }
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(true)]
		public event WidgetEventHandler WidgetRemoved {
			add { Events.AddHandler (WidgetRemovedEvent, value); }
			remove { Events.RemoveHandler (WidgetRemovedEvent, value); }
		}

		[MWFDescription("Fired when the cursor for the Widget has been changed"), MWFCategory("PropertyChanged")]
		public event EventHandler CursorChanged {
			add { Events.AddHandler (CursorChangedEvent, value); }
			remove { Events.RemoveHandler (CursorChangedEvent, value); }
		}
		public event EventHandler DockChanged {
			add { Events.AddHandler (DockChangedEvent, value); }
			remove { Events.RemoveHandler (DockChangedEvent, value); }
		}

		public event EventHandler DoubleClick {
			add { Events.AddHandler (DoubleClickEvent, value); }
			remove { Events.RemoveHandler (DoubleClickEvent, value); }
		}

		public event DragEventHandler DragDrop {
			add { Events.AddHandler (DragDropEvent, value); }
			remove { Events.RemoveHandler (DragDropEvent, value); }
		}

		public event DragEventHandler DragEnter {
			add { Events.AddHandler (DragEnterEvent, value); }
			remove { Events.RemoveHandler (DragEnterEvent, value); }
		}

		public event EventHandler DragLeave {
			add { Events.AddHandler (DragLeaveEvent, value); }
			remove { Events.RemoveHandler (DragLeaveEvent, value); }
		}

		public event DragEventHandler DragOver {
			add { Events.AddHandler (DragOverEvent, value); }
			remove { Events.RemoveHandler (DragOverEvent, value); }
		}

		public event EventHandler EnabledChanged {
			add { Events.AddHandler (EnabledChangedEvent, value); }
			remove { Events.RemoveHandler (EnabledChangedEvent, value); }
		}

		public event EventHandler Enter {
			add { Events.AddHandler (EnterEvent, value); }
			remove { Events.RemoveHandler (EnterEvent, value); }
		}

		public event EventHandler FontChanged {
			add { Events.AddHandler (FontChangedEvent, value); }
			remove { Events.RemoveHandler (FontChangedEvent, value); }
		}

		public event EventHandler ForeColorChanged {
			add { Events.AddHandler (ForeColorChangedEvent, value); }
			remove { Events.RemoveHandler (ForeColorChangedEvent, value); }
		}

		public event GiveFeedbackEventHandler GiveFeedback {
			add { Events.AddHandler (GiveFeedbackEvent, value); }
			remove { Events.RemoveHandler (GiveFeedbackEvent, value); }
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public event EventHandler GotFocus {
			add { Events.AddHandler (GotFocusEvent, value); }
			remove { Events.RemoveHandler (GotFocusEvent, value); }
		}


		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public event EventHandler HandleCreated {
			add { Events.AddHandler (HandleCreatedEvent, value); }
			remove { Events.RemoveHandler (HandleCreatedEvent, value); }
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public event EventHandler HandleDestroyed {
			add { Events.AddHandler (HandleDestroyedEvent, value); }
			remove { Events.RemoveHandler (HandleDestroyedEvent, value); }
		}

		public event HelpEventHandler HelpRequested {
			add { Events.AddHandler (HelpRequestedEvent, value); }
			remove { Events.RemoveHandler (HelpRequestedEvent, value); }
		}

		public event EventHandler ImeModeChanged {
			add { Events.AddHandler (ImeModeChangedEvent, value); }
			remove { Events.RemoveHandler (ImeModeChangedEvent, value); }
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public event InvalidateEventHandler Invalidated {
			add { Events.AddHandler (InvalidatedEvent, value); }
			remove { Events.RemoveHandler (InvalidatedEvent, value); }
		}

		public event KeyEventHandler KeyDown {
			add { Events.AddHandler (KeyDownEvent, value); }
			remove { Events.RemoveHandler (KeyDownEvent, value); }
		}

		public event KeyPressEventHandler KeyPress {
			add { Events.AddHandler (KeyPressEvent, value); }
			remove { Events.RemoveHandler (KeyPressEvent, value); }
		}

		public event KeyEventHandler KeyUp {
			add { Events.AddHandler (KeyUpEvent, value); }
			remove { Events.RemoveHandler (KeyUpEvent, value); }
		}

		public event LayoutEventHandler Layout {
			add { Events.AddHandler (LayoutEvent, value); }
			remove { Events.RemoveHandler (LayoutEvent, value); }
		}

		public event EventHandler Leave {
			add { Events.AddHandler (LeaveEvent, value); }
			remove { Events.RemoveHandler (LeaveEvent, value); }
		}

		public event EventHandler LocationChanged {
			add { Events.AddHandler (LocationChangedEvent, value); }
			remove { Events.RemoveHandler (LocationChangedEvent, value); }
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public event EventHandler LostFocus {
			add { Events.AddHandler (LostFocusEvent, value); }
			remove { Events.RemoveHandler (LostFocusEvent, value); }
		}

		public event EventHandler MarginChanged {
			add { Events.AddHandler (MarginChangedEvent, value); }
			remove {Events.RemoveHandler (MarginChangedEvent, value); }
		}

		public event EventHandler MouseCaptureChanged {
			add { Events.AddHandler (MouseCaptureChangedEvent, value); }
			remove { Events.RemoveHandler (MouseCaptureChangedEvent, value); }
		}
		public event MouseEventHandler MouseClick
		{
			add { Events.AddHandler (MouseClickEvent, value); }
			remove { Events.RemoveHandler (MouseClickEvent, value); }
		}
		public event MouseEventHandler MouseDoubleClick
		{
			add { Events.AddHandler (MouseDoubleClickEvent, value); }
			remove { Events.RemoveHandler (MouseDoubleClickEvent, value); }
		}
		public event MouseEventHandler MouseDown {
			add { Events.AddHandler (MouseDownEvent, value); }
			remove { Events.RemoveHandler (MouseDownEvent, value); }
		}

		public event EventHandler MouseEnter {
			add { Events.AddHandler (MouseEnterEvent, value); }
			remove { Events.RemoveHandler (MouseEnterEvent, value); }
		}

		public event EventHandler MouseHover {
			add { Events.AddHandler (MouseHoverEvent, value); }
			remove { Events.RemoveHandler (MouseHoverEvent, value); }
		}

		public event EventHandler MouseLeave {
			add { Events.AddHandler (MouseLeaveEvent, value); }
			remove { Events.RemoveHandler (MouseLeaveEvent, value); }
		}

		public event MouseEventHandler MouseMove {
			add { Events.AddHandler (MouseMoveEvent, value); }
			remove { Events.RemoveHandler (MouseMoveEvent, value); }
		}

		public event MouseEventHandler MouseUp {
			add { Events.AddHandler (MouseUpEvent, value); }
			remove { Events.RemoveHandler (MouseUpEvent, value); }
		}

		//[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public event MouseEventHandler MouseWheel {
			add { Events.AddHandler (MouseWheelEvent, value); }
			remove { Events.RemoveHandler (MouseWheelEvent, value); }
		}

		public event EventHandler Move {
			add { Events.AddHandler (MoveEvent, value); }
			remove { Events.RemoveHandler (MoveEvent, value); }
		}
		public event EventHandler PaddingChanged
		{
			add { Events.AddHandler (PaddingChangedEvent, value); }
			remove { Events.RemoveHandler (PaddingChangedEvent, value); }
		}
		public event PaintEventHandler Paint {
			add { Events.AddHandler (PaintEvent, value); }
			remove { Events.RemoveHandler (PaintEvent, value); }
		}

		public event EventHandler ParentChanged {
			add { Events.AddHandler (ParentChangedEvent, value); }
			remove { Events.RemoveHandler (ParentChangedEvent, value); }
		}

		public event PreviewKeyDownEventHandler PreviewKeyDown {
			add { Events.AddHandler (PreviewKeyDownEvent, value); }
			remove { Events.RemoveHandler (PreviewKeyDownEvent, value); }
		}

		public event QueryAccessibilityHelpEventHandler QueryAccessibilityHelp {
			add { Events.AddHandler (QueryAccessibilityHelpEvent, value); }
			remove { Events.RemoveHandler (QueryAccessibilityHelpEvent, value); }
		}

		public event QueryContinueDragEventHandler QueryContinueDrag {
			add { Events.AddHandler (QueryContinueDragEvent, value); }
			remove { Events.RemoveHandler (QueryContinueDragEvent, value); }
		}

		public event EventHandler RegionChanged {
			add { Events.AddHandler (RegionChangedEvent, value); }
			remove { Events.RemoveHandler (RegionChangedEvent, value); }
		}

		//[EditorBrowsable (EditorBrowsableState.Advanced)]
		public event EventHandler Resize {
			add { Events.AddHandler (ResizeEvent, value); }
			remove { Events.RemoveHandler (ResizeEvent, value); }
		}

		public event EventHandler RightToLeftChanged {
			add { Events.AddHandler (RightToLeftChangedEvent, value); }
			remove { Events.RemoveHandler (RightToLeftChangedEvent, value); }
		}

		public event EventHandler SizeChanged {
			add { Events.AddHandler (SizeChangedEvent, value); }
			remove { Events.RemoveHandler (SizeChangedEvent, value); }
		}

		public event EventHandler StyleChanged {
			add { Events.AddHandler (StyleChangedEvent, value); }
			remove { Events.RemoveHandler (StyleChangedEvent, value); }
		}

		public event EventHandler SystemColorsChanged {
			add { Events.AddHandler (SystemColorsChangedEvent, value); }
			remove { Events.RemoveHandler (SystemColorsChangedEvent, value); }
		}

		public event EventHandler TabIndexChanged {
			add { Events.AddHandler (TabIndexChangedEvent, value); }
			remove { Events.RemoveHandler (TabIndexChangedEvent, value); }
		}

		public event EventHandler TabStopChanged {
			add { Events.AddHandler (TabStopChangedEvent, value); }
			remove { Events.RemoveHandler (TabStopChangedEvent, value); }
		}

		public event EventHandler TextChanged {
			add { Events.AddHandler (TextChangedEvent, value); }
			remove { Events.RemoveHandler (TextChangedEvent, value); }
		}

		public event EventHandler Validated {
			add { Events.AddHandler (ValidatedEvent, value); }
			remove { Events.RemoveHandler (ValidatedEvent, value); }
		}

		public event CancelEventHandler Validating {
			add { Events.AddHandler (ValidatingEvent, value); }
			remove { Events.RemoveHandler (ValidatingEvent, value); }
		}

		public event EventHandler VisibleChanged {
			add { Events.AddHandler (VisibleChangedEvent, value); }
			remove { Events.RemoveHandler (VisibleChangedEvent, value); }
		}

		#endregion	// Events
	}
}
