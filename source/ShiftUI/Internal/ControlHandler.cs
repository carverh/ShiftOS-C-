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
// Copyright (c) 2007 Novell, Inc.
//
// Authors:
//	Geoff Norton  <gnorton@novell.com>
//
//

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ShiftUI.CarbonInternal {
	internal class WidgetHandler : EventHandlerBase, IEventHandler {
		internal const uint kEventWidgetInitialize = 1000;
		internal const uint kEventWidgetDispose = 1001;
		internal const uint kEventWidgetGetOptimalBounds = 1003;
		internal const uint kEventWidgetDefInitialize = kEventWidgetInitialize;
		internal const uint kEventWidgetDefDispose = kEventWidgetDispose;
		internal const uint kEventWidgetHit = 1;
		internal const uint kEventWidgetsimulateHit = 2;
		internal const uint kEventWidgetHitTest = 3;
		internal const uint kEventWidgetDraw = 4;
		internal const uint kEventWidgetApplyBackground = 5;
		internal const uint kEventWidgetApplyTextColor = 6;
		internal const uint kEventWidgetsetFocusPart = 7;
		internal const uint kEventWidgetGetFocusPart = 8;
		internal const uint kEventWidgetActivate = 9;
		internal const uint kEventWidgetDeactivate = 10;
		internal const uint kEventWidgetsetCursor = 11;
		internal const uint kEventWidgetContextualMenuClick = 12;
		internal const uint kEventWidgetClick = 13;
		internal const uint kEventWidgetGetNextFocusCandidate = 14;
		internal const uint kEventWidgetGetAutoToggleValue = 15;
		internal const uint kEventWidgetInterceptSubviewClick = 16;
		internal const uint kEventWidgetGetClickActivation = 17;
		internal const uint kEventWidgetDragEnter = 18;
		internal const uint kEventWidgetDragWithin = 19;
		internal const uint kEventWidgetDragLeave = 20;
		internal const uint kEventWidgetDragReceive = 21;
		internal const uint kEventWidgetInvalidateForSizeChange = 22;
		internal const uint kEventWidgetTrackingAreaEntered = 23;
		internal const uint kEventWidgetTrackingAreaExited = 24;
		internal const uint kEventWidgetTrack = 51;
		internal const uint kEventWidgetGetScrollToHereStartPoint = 52;
		internal const uint kEventWidgetGetIndicatorDragConstraint = 53;
		internal const uint kEventWidgetIndicatorMoved = 54;
		internal const uint kEventWidgetGhostingFinished = 55;
		internal const uint kEventWidgetGetActionProcPart = 56;
		internal const uint kEventWidgetGetPartRegion = 101;
		internal const uint kEventWidgetGetPartBounds = 102;
		internal const uint kEventWidgetsetData = 103;
		internal const uint kEventWidgetGetData = 104;
		internal const uint kEventWidgetGetSizeConstraints= 105;
		internal const uint kEventWidgetGetFrameMetrics = 106;
		internal const uint kEventWidgetValueFieldChanged = 151;
		internal const uint kEventWidgetAddedSubWidget = 152;
		internal const uint kEventWidgetRemovingSubWidget = 153;
		internal const uint kEventWidgetBoundsChanged = 154;
		internal const uint kEventWidgetVisibilityChanged = 157;
		internal const uint kEventWidgetTitleChanged = 158;
		internal const uint kEventWidgetOwningWindowChanged = 159;
		internal const uint kEventWidgetHiliteChanged = 160;
		internal const uint kEventWidgetEnabledStateChanged = 161;
		internal const uint kEventWidgetLayoutInfoChanged = 162;
		internal const uint kEventWidgetArbitraryMessage = 201;

		internal const uint kEventParamCGContextRef = 1668183160;
		internal const uint kEventParamDirectObject = 757935405;
		internal const uint kEventParamWidgetPart = 1668313716;
		internal const uint kEventParamWidgetLikesDrag = 1668047975;
		internal const uint kEventParamRgnHandle = 1919381096;
		internal const uint typeWidgetRef = 1668575852;
		internal const uint typeCGContextRef = 1668183160;
		internal const uint typeQDPoint = 1363439732;
		internal const uint typeQDRgnHandle = 1919381096;
		internal const uint typeWidgetPartCode = 1668313716;
		internal const uint typeBoolean = 1651470188;

		internal WidgetHandler (XplatUICarbon driver) : base (driver) {}

		public bool ProcessEvent (IntPtr callref, IntPtr eventref, IntPtr handle, uint kind, ref MSG msg) {
			Hwnd hwnd;
			bool client;

			GetEventParameter (eventref, kEventParamDirectObject, typeWidgetRef, IntPtr.Zero, (uint) Marshal.SizeOf (typeof (IntPtr)), IntPtr.Zero, ref handle);
			hwnd = Hwnd.ObjectFromHandle (handle);

			if (hwnd == null)
				return false;

			msg.hwnd = hwnd.Handle;
			client = (hwnd.ClientWindow == handle ? true : false);

			switch (kind) {
				case kEventWidgetDraw: {
					IntPtr rgn = IntPtr.Zero;
					HIRect bounds = new HIRect ();
				
					GetEventParameter (eventref, kEventParamRgnHandle, typeQDRgnHandle, IntPtr.Zero, (uint) Marshal.SizeOf (typeof (IntPtr)), IntPtr.Zero, ref rgn);

					if (rgn != IntPtr.Zero) {
						Rect rbounds = new Rect ();
						
						GetRegionBounds (rgn, ref rbounds);
						
						bounds.origin.x = rbounds.left;
						bounds.origin.y = rbounds.top;
						bounds.size.width = rbounds.right - rbounds.left;
						bounds.size.height = rbounds.bottom - rbounds.top;
					} else {
						HIViewGetBounds (handle, ref bounds);
					}

					if (!hwnd.visible) {
						if (client) {
							hwnd.expose_pending = false;
						} else {
							hwnd.nc_expose_pending = false;
						}
                                                return false;
					}

					if (!client) {
						DrawBorders (hwnd);
					}

					Driver.AddExpose (hwnd, client, bounds);

					return true;
				}
				case kEventWidgetVisibilityChanged: {
					if (client) {
						msg.message = Msg.WM_SHOWWINDOW;
						msg.lParam = (IntPtr) 0;
						msg.wParam = (HIViewIsVisible (handle) ? (IntPtr)1 : (IntPtr)0);
						return true;
					}
					return false;
				}
				case kEventWidgetBoundsChanged: {
					HIRect view_frame = new HIRect ();

					HIViewGetFrame (handle, ref view_frame);
					if (!client) {
						hwnd.X = (int) view_frame.origin.x;
						hwnd.Y = (int) view_frame.origin.y;
						hwnd.Width = (int) view_frame.size.width;
						hwnd.Height = (int) view_frame.size.height;
						Driver.PerformNCCalc (hwnd);
					}

					msg.message = Msg.WM_WINDOWPOSCHANGED;
					msg.hwnd = hwnd.Handle;

					return true;
				}
				case kEventWidgetGetFocusPart: {
					short pcode = 0;
					SetEventParameter (eventref, kEventParamWidgetPart, typeWidgetPartCode, (uint)Marshal.SizeOf (typeof (short)), ref pcode);
					return false;
				}
				case kEventWidgetDragEnter: 
				case kEventWidgetDragWithin: 
				case kEventWidgetDragLeave: 
				case kEventWidgetDragReceive: 
					return Dnd.HandleEvent (callref, eventref, handle, kind, ref msg);
			}
			return false;
		}

		private void DrawBorders (Hwnd hwnd) {
			switch (hwnd.border_style) {
				case FormBorderStyle.Fixed3D: {
					Graphics g;

					g = Graphics.FromHwnd(hwnd.whole_window);
					if (hwnd.border_static)
						WidgetPaint.DrawBorder3D(g, new Rectangle(0, 0, hwnd.Width, hwnd.Height), Border3DStyle.SunkenOuter);
					else
						WidgetPaint.DrawBorder3D(g, new Rectangle(0, 0, hwnd.Width, hwnd.Height), Border3DStyle.Sunken);
					g.Dispose();
					break;
				}

				case FormBorderStyle.FixedSingle: {
					Graphics g;

					g = Graphics.FromHwnd(hwnd.whole_window);
					WidgetPaint.DrawBorder(g, new Rectangle(0, 0, hwnd.Width, hwnd.Height), Color.Black, ButtonBorderStyle.Solid);
					g.Dispose();
					break;
				}
			}
		}
			
		[DllImport ("/System/Library/Frameworks/Carbon.framework/Versions/Current/Carbon")]
		static extern int GetRegionBounds (IntPtr rgnhandle, ref Rect region);
		[DllImport ("/System/Library/Frameworks/Carbon.framework/Versions/Current/Carbon")]
		static extern int GetEventParameter (IntPtr eventref, uint name, uint type, IntPtr outtype, uint size, IntPtr outsize, ref IntPtr data);
		[DllImport ("/System/Library/Frameworks/Carbon.framework/Versions/Current/Carbon")]
		static extern int SetEventParameter (IntPtr eventref, uint name, uint type, uint size, ref short data);

		[DllImport("/System/Library/Frameworks/Carbon.framework/Versions/Current/Carbon")]
		static extern int HIViewGetBounds (IntPtr handle, ref HIRect rect);
		[DllImport("/System/Library/Frameworks/Carbon.framework/Versions/Current/Carbon")]
		static extern int HIViewGetFrame (IntPtr handle, ref HIRect rect);
		[DllImport("/System/Library/Frameworks/Carbon.framework/Versions/Current/Carbon")]
		extern static bool HIViewIsVisible (IntPtr vHnd);
	}
}
