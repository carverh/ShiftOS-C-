// WARNING: This thing likes leaking memory.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NAudio;
using NAudio.Wave;
using System.Threading;

namespace ShiftOS
{
    public class Audio
    {
        public static List<AudioResourceClient> Clients = null;
        internal static bool Enabled = false;

        public static void DisposeAll()
        {
            if(Clients != null)
            {
                foreach(var client in Clients)
                {
                    client.Dispose();
                }
            }
        }
    }

    public class AudioResourceClient
    {


        public AudioResourceClient(string folder)
        {
            if (Audio.Enabled)
            {
                if (Audio.Clients == null)
                {
                    Audio.Clients = new List<AudioResourceClient>();
                }
                Audio.Clients.Add(this);
                string real = folder.Replace(";", OSInfo.DirectorySeparator);
                real_path = "resources" + OSInfo.DirectorySeparator + real;
                soundPlayer = new WaveOut();
                var t = new Thread(new ThreadStart(new Action(() =>
                {
                    while (disposed == false)
                    {
                        switch (soundPlayer.PlaybackState)
                        {
                            case PlaybackState.Stopped:
                                if (fireEvents)
                                {
                                    if (currentStream != null)
                                        currentStream.Dispose();
                                    currentStream = null;
                                    currentProvider = null;
                                    var h = SongFinished;
                                    if (h != null)
                                    {
                                        API.CurrentSession.Invoke(new Action(() =>
                                        {
                                            h(this, new EventArgs());
                                        }));
                                    }

                                }

                                break;
                        }
                    }
                })));
                t.Start();
            }
        }

        public string CurrentSong
        {
            get { return currentSong; }
        }

        private string real_path = null;
        private WaveOut soundPlayer = null;
        private bool disposed = false;
        private bool playing = false;
        private bool loopActive = false;
        private string currentSong = "";
        protected Thread soundThread;
        private Stream currentStream = null;
        private IWaveProvider currentProvider = null;
        private bool fireEvents = false;

        public event EventHandler SongFinished;

        public void Play(byte[] songbytes)
        {
            if (Audio.Enabled)
            {
                var t = new Thread(new ThreadStart(new Action(() =>
                {
                    try
                    {
                        if (disposed == false)
                        {
                            if (currentProvider != null)
                            {
                                currentProvider = null;
                            }
                            if (currentStream != null)
                            {
                                currentStream.Dispose();
                                currentStream = null;
                            }
                            Stream s = new MemoryStream(songbytes);
                            IWaveProvider provider = new RawSourceWaveStream(s, new WaveFormat());
                            soundPlayer.Init(provider);
                            soundPlayer.Play();
                            fireEvents = true;
                            currentStream = s;
                            currentProvider = provider;
                        }
                    }
                    catch
                    {

                    }
                })));
                soundThread = t;
                t.Start();
            }
        }

        public void PlayMP3(byte[] songbytes)
        {
            if (Audio.Enabled)
            {
                var t = new Thread(new ThreadStart(new Action(() =>
                {
                    if (currentProvider != null)
                    {
                        currentProvider = null;
                    }
                    if (currentStream != null)
                    {
                        currentStream.Dispose();
                        currentStream = null;
                    }
                    Stream s = new MemoryStream(songbytes);
                    IWaveProvider provider = new Mp3FileReader(s);
                    soundPlayer.Init(provider);
                    soundPlayer.Play();
                    currentStream = s;
                    currentProvider = provider;
                })));
                soundThread = t;
                t.Start();
            }
        }


        public void Play(string file)
        {
            if (Audio.Enabled)
            {
                if (File.Exists(real_path + OSInfo.DirectorySeparator + file + ".wav"))
                {
                    currentSong = file;
                    Play(File.ReadAllBytes(real_path + OSInfo.DirectorySeparator + file + ".wav"));
                }
                else if (File.Exists(real_path + OSInfo.DirectorySeparator + file + ".mp3"))
                {
                    currentSong = file;
                    PlayMP3(File.ReadAllBytes(real_path + OSInfo.DirectorySeparator + file + ".mp3"));
                }
            }
        }

        public void Stop()
        {
            if (Audio.Enabled)
            {
                var t = new Thread(new ThreadStart(new Action(() =>
                {
                    fireEvents = false;
                    soundPlayer.Stop();
                    if (currentProvider != null)
                    {
                        currentProvider = null;
                    }
                    if (currentStream != null)
                    {
                        currentStream.Dispose();
                        currentStream = null;
                    }
                })));
                t.Start();
            }
        }

        public void Pause()
        {
            if (Audio.Enabled)
            {
                if (soundPlayer.PlaybackState == PlaybackState.Playing)
                {
                    soundPlayer.Pause();
                }
                else if (soundPlayer.PlaybackState == PlaybackState.Paused)
                {
                    soundPlayer.Resume();
                }
            }
        }

        public void PlayRandom()
        {
            if (Audio.Enabled)
            {
                int r = new Random().Next(0, Directory.GetFiles(real_path).Length);
                var files = Directory.GetFiles(real_path);
                FileInfo finf = new FileInfo(files[r]);
                string name = finf.Name.Replace(finf.Extension, "");
                Play(name);

            }
        }

        public void Dispose()
        {
            if (Audio.Enabled)
            {
                if (currentProvider != null)
                {
                    currentProvider = null;
                }
                if (currentStream != null)
                {
                    currentStream.Dispose();
                    currentStream = null;
                }
                soundPlayer.Dispose();
                disposed = true;
            }
        }
    }
}
