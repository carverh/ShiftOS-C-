using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShiftOS
{
    class MountMgr
    {
        public static Dictionary<string, string> links = null;

        public static void Init()
        {
            links = new Dictionary<string, string>();
            if (API.Upgrades["fsexternaldevices"] == true)
            {
                var drives = DriveInfo.GetDrives();
                foreach (var drive in drives)
                {
                    try
                    {
                        if (!Paths.SaveRoot.Contains(drive.Name))
                        {
                            links.Add(drive.Name, drive.VolumeLabel);
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
