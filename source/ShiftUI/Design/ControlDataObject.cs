using System;
using ShiftUI;

namespace ShiftUI.Design
{
	// A IDataObject that supports Widget and Widget[] format
	//
	internal class WidgetDataObject : IDataObject
	{
		private object _data = null;
		private string _format = null;

		public WidgetDataObject ()
		{
			_data = null;
			_format = null;
		}

		public WidgetDataObject (Widget control)
		{
			SetData (control);
		}

		public WidgetDataObject (Widget[] controls)
		{
			SetData (controls);
		}

		public object GetData (Type format)
		{
			return this.GetData (format.ToString ());
		}

		public object GetData (string format)
		{
			return this.GetData (format, true);
		}

		public object GetData (string format, bool autoConvert)
		{
			if (format == _format) {
				return _data;
			}
			return null;
		}

		public bool GetDataPresent (Type format)
		{
			return this.GetDataPresent (format.ToString());
		}

		public bool GetDataPresent (string format)
		{
			return this.GetDataPresent (format, true);
		}

		public bool GetDataPresent (string format, bool autoConvert)
		{
			if (format == _format) {
				return true;
			}
			return false;
		}

		public string[] GetFormats ()
		{
			return this.GetFormats (true);
		}

		public string[] GetFormats (bool autoConvert)
		{
			string[] formats = new string[2];
			formats[0] = typeof (Widget).ToString ();
			formats[1] = typeof (Widget[]).ToString ();
			return formats;
		}

		public void SetData (object data)
		{
			if (data is Widget)
				this.SetData (typeof (Widget), data);
			else if (data is Widget[])
				this.SetData (typeof (Widget[]), data);
		}

		public void SetData (Type format, object data)
		{
			this.SetData (format.ToString (), data);
		}

		public void SetData (string format, object data)
		{
			this.SetData (format, true, data);
		}

		public void SetData (string format, bool autoConvert, object data)
		{
			if (ValidateFormat (format)) {
				_data = data;
				_format = format;
			}
		}

		private bool ValidateFormat (string format)
		{
			bool valid = false;

			string[] formats = GetFormats ();
			foreach (string f in formats) {
				if (f == format) {
					valid = true;
					break;
				}
			}

			return valid;
		}
	}
}

