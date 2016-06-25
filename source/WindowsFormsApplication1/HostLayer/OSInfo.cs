using System;

namespace ShiftOS
{
	public class OSInfo
	{
		
        /// <summary>
        /// System directory separator charactor.
        /// </summary>
        public static string DirectorySeparator
        {
            get
            {
                switch(GetPlatformID())
                {
                    case "microsoft":
                        return "\\";
                    default:
                        return "/";
                }
            }
        }

		/// <summary>
		/// Selects a default, monospace font name from the OS. This is typically used for creating ingame terminals.
		/// </summary>
		/// <returns>The monospace font.</returns>
		public static string GetMonospaceFont() {
			string fname = null;
			switch (GetPlatformID ()) {
			case "microsoft":
				fname = "Lucida Console";
				break;
			case "unix":
				fname = "Monospace";
				break;
			case "macosx":
				fname = "Menlo";
				break;
			}
			return fname;
		}

		/// <summary>
		/// This refers to the Home directory of the current user. For example, if the user's name is 'Michael', and the user is on Windows Vista/7/8/10, this value would be 'C:\Users\Michael'.
		/// </summary>
		public static string homePath ()
		{
			return (Environment.OSVersion.Platform == PlatformID.Unix ||
			Environment.OSVersion.Platform == PlatformID.MacOSX)
			? Environment.GetEnvironmentVariable ("HOME")
			: Environment.ExpandEnvironmentVariables ("%HOMEDRIVE%%HOMEPATH%");
		}

        /// <summary>
        /// Is it Linux? Is it Mac OS? Did Microsoft make it?
        /// </summary>
        /// <returns>The platform ID.</returns>
		public static string GetPlatformID() {
			switch (Environment.OSVersion.Platform) {
			case PlatformID.Unix:
				return "unix";
			case PlatformID.MacOSX:
				return "macosx";
			default:
				return "microsoft";
			}
		}
	}
}

