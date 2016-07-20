using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI.Theming.Default;
using System.Drawing;
using ShiftUI.ShiftOS;

namespace ShiftUI.Theming
{
    class ThemeElementsMemphis : ThemeElementsDefault
    {

        public ThemeElementsMemphis()
        {
        }

        public override ButtonPainter ButtonPainter
        {
            get
            {
                return new Memphis.ButtonPainter();
            }
        }
    }

    namespace Memphis
    {
        internal class ButtonPainter : Default.ButtonPainter
        {

            #region Buttons
            #region Standard Button
            public override void Draw(Graphics g, Rectangle bounds, ButtonThemeState state, Color backColor, Color foreColor)
            {
                bool is_themecolor = backColor.ToArgb() == ThemeEngine.Current.ColorControl.ToArgb() || backColor == Color.Empty ? true : false;
                CPColor cpcolor = is_themecolor ? CPColor.Empty : ResPool.GetCPColor(backColor);
                Pen pen;

                switch (state)
                {
                    case ButtonThemeState.Disabled:
                    case ButtonThemeState.Normal:
                    case ButtonThemeState.Entered:
                    case ButtonThemeState.Default:
                        pen = new Pen(foreColor, Application.CurrentSkin.ButtonBorderWidth);
                        g.DrawRectangle(pen, bounds);
                        break;
                    case ButtonThemeState.Pressed:
                        g.FillRectangle(new SolidBrush(backColor), bounds);
                        pen = new Pen(foreColor, Application.CurrentSkin.ButtonBorderWidth);
                        g.DrawRectangle(pen, bounds);
                        break;
                }
            }
            #endregion

            #region FlatStyle Button
            public override void DrawFlat(Graphics g, Rectangle bounds, ButtonThemeState state, Color backColor, Color foreColor, FlatButtonAppearance appearance)
            {
                Draw(g, bounds, state, backColor, foreColor);
            }
            #endregion

            #region Popup Button
            public override void DrawPopup(Graphics g, Rectangle bounds, ButtonThemeState state, Color backColor, Color foreColor)
            {
                Draw(g, bounds, state, backColor, foreColor);
            }
            #endregion
            #endregion

            private static Color ChangeIntensity(Color baseColor, float percent)
            {
                int H, I, S;

                WidgetPaint.Color2HBS(baseColor, out H, out I, out S);
                int NewIntensity = Math.Min(255, (int)(I * percent));

                return WidgetPaint.HBS2Color(H, NewIntensity, S);
            }

        }
    }
}
