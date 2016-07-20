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
// Copyright (c) 2004 Novell, Inc.
//
// Authors:
//	Peter Bartok	pbartok@novell.com
//
//


// COMPLETE

using System.Globalization;
using System;

namespace ShiftUI {
	public class InputLanguageChangedEventArgs : EventArgs {
		private CultureInfo	culture;
		private byte		charset;
		private InputLanguage	input_language;

		#region Public Constructors
		public InputLanguageChangedEventArgs(System.Globalization.CultureInfo culture, byte charSet) {
			this.culture = culture;
			this.charset = charSet;
			this.input_language = InputLanguage.FromCulture(culture);
		}

		public InputLanguageChangedEventArgs(InputLanguage inputLanguage, byte charSet) {
			this.culture = inputLanguage.Culture;
			this.charset = charSet;
			this.input_language = inputLanguage;
		}
		#endregion	// Public Constructors

		#region Public Instance Properties
		public byte CharSet {
			get {
				return this.charset;
			}
		}

		public CultureInfo Culture {
			get {
				return this.culture;
			}
		}

		public InputLanguage InputLanguage {
			get {
				return this.input_language;
			}
		}
		#endregion	// Public Instance Properties
	}
}
