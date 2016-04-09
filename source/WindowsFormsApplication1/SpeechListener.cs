using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace ShiftOS
{
    public class SpeechListener
    {
        private SpeechRecognitionEngine _recognizer = null;
        public SpeechRecognitionEngine Engine
        {
            get
            {
                return _recognizer;
            }
        }

        public SpeechListener()
        {
            _recognizer = new SpeechRecognitionEngine();
            var g = new DictationGrammar();
            _recognizer.LoadGrammar(g);
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.SpeechRecognized += (object s, SpeechRecognizedEventArgs a) =>
            {
                try {
                    var h = OnRecognize;
                    if (h != null)
                    {
                        h(a.Result.Text, new EventArgs());
                    }
                }
                catch
                {

                }
            };
            _recognizer.AudioStateChanged += (object s, AudioStateChangedEventArgs a) =>
            {
                if(a.AudioState == AudioState.Stopped)
                {
                    _recognizer.RecognizeAsync();
                }
            };
            
        }

        public event EventHandler OnRecognize;
    }
}
