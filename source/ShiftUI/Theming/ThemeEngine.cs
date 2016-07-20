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
//	Jordi Mas i Hernandez, jordi@ximian.com
//
//


using ShiftUI.Theming;
using System;

namespace ShiftUI
{
	internal class ThemeEngine
	{
		static private Theme theme = null;
		
		static ThemeEngine ()
		{
			string theme_var;

			theme_var = Environment.GetEnvironmentVariable("MONO_THEME");

			if (theme_var == null) {
				theme_var = "memphis"; //Screw win32. Memphis all the way!
			} else {
				theme_var = theme_var.ToLower ();
			}

			if (Application.VisualStylesEnabled) {
				theme = new ThemeSkinnable(); //ShiftOS skin engine will be moved into here, possibly.
			} else {
				theme = new ThemeWin32Classic ();
			}
		}
		
			
		public static Theme Current {
			get { return theme; }
		}
		
	}
}