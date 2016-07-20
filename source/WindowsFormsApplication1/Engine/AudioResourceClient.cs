using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NAudio;
using NAudio.Wave;
using System.Threading;
using Newtonsoft.Json;
using AxWMPLib;
using ShiftUI;
using WMPLib;

namespace ShiftOS
{
    public class AudioData
    {
        public string StartURL { get; set; }
        public Dictionary<string, List<string>> Files { get; set; }
        public Dictionary<string, List<Visualizer>> Visualizers = null;
    }

    public class Audio
    {
        public static string Name
        {
            get
            {
                string res = null;
                try
                {
                    if (_wmp != null)
                    {
                        if (_wmp.currentMedia != null)
                        {
                            res = _wmp.currentMedia.name;
                        }

                    }
                }
                catch
                {

                }
                return res;
            }
        }

        private static AudioData _ad = null;
        public static WindowsMediaPlayer _wmp = null;
        public static bool running = true;
        
        public static int CurrentPosition
        {
            get
            {
                try
                {
                    if (_wmp != null)
                    {
                        return (int)_wmp.controls.currentPosition;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static int CurrentPositionMS
        {
            get
            {
                try
                {
                    if (_wmp != null)
                    {
                        return (int)(_wmp.controls.currentPosition * 100);
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch
                {
                    return 0;
                }
            }
        }


        public static void LoadAudioData()
        {
            var t = new Thread(new ThreadStart(() =>
            {
                _wmp = new WindowsMediaPlayer();
                _wmp.settings.autoStart = true;
                _wmp.settings.volume = API.LoadedSettings.MusicVolume;
            }));
            t.Start();
            _ad = JsonConvert.DeserializeObject<AudioData>(Properties.Resources.MusicData);
        }

        public static void Play(string list)
        {
            _forceStop = false;
            var lst = _ad.Files[list];
            var rnd = new Random();
            int i = rnd.Next(0, lst.Count);
            _wmp.URL = _ad.StartURL + list + "/" + _ad.Files[list][i] + ".mp3";
            _wmp.PlayStateChange += (o) =>
            {
                if (o == (int)WMPPlayState.wmppsMediaEnded)
                {
                    var t = new ShiftUI.Timer();
                    t.Interval = 1000;
                    t.Tick += (object s, EventArgs a) =>
                    {
                        t.Stop();
                        Stopped?.Invoke(_wmp, new EventArgs());
                    };
                    t.Start();
                }
            };

        }

        public static event EventHandler Stopped;

        public static bool _forceStop = false;

        public static void Mute()
        {
            _wmp.settings.volume = 0;
        }

        public static void VolumeUp()
        {
            if(_wmp.settings.volume < 90)
            {
                _wmp.settings.volume += 10;
            }
        }

        public static void VolumeDown()
        {
            if(_wmp.settings.volume > 0)
            {
                _wmp.settings.volume -= 10;
            }
        }

        public static void Pause()
        {
            _wmp.controls.pause();
        }

        public static void Unpause()
        {
            _wmp.controls.play();
        }

        public static void ForceStop()
        {
            new Thread(new ThreadStart(() =>
            {
                _forceStop = true;
                _wmp.controls.stop();
            })).Start();
        }

        internal static Visualizer GetVisualizer()
        {
            Visualizer v = null;
            foreach(var vis in _ad.Visualizers[Name])
            {
                if (vis.startTime <= CurrentPosition && vis.endTime >= CurrentPosition)
                    v = vis;
            }
            return v;
        }
    }

    public class Visualizer
    {
        public int startTime { get; set; }
        public int endTime { get; set; }
        public VisualizerType type { get; set; }
        public bool R { get; set; }
        public bool G { get; set; }
        public bool B { get; set; }
    }

    public enum VisualizerType
    {
        Pulse,
        BuildUp,
        CalmDown
    }

}
