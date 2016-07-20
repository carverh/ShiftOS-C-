using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;

namespace ShiftOS
{
    public partial class GameSettings : Form
    {
        public GameSettings()
        {
            InitializeComponent();
            SetupUI();
        }

        public void SetupUI()
        {
            pgsound.MaxValue = 100;
            pgsound.Value = Audio._wmp.settings.volume;
        }

        bool moving = false;

        private void set_music_volume(object sender, MouseEventArgs e)
        {
            Audio._wmp.settings.volume = MathEx.LinearInterpolate(0, pgsound.Width, e.X, 0, 100);
            moving = true;
            SetupUI();
        }

        private void pgsound_MouseLeave(object sender, EventArgs e)
        {
            moving = false;
        }

        private void pgsound_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving == true)
            {
                Audio._wmp.settings.volume = MathEx.LinearInterpolate(0, pgsound.Width, e.X, 0, 100);
                SetupUI();
            }
        }
    }
}
