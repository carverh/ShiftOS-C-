using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI.Theming.Default;
using System.Drawing;
using ShiftUI.ShiftOS;
using System.Drawing.Drawing2D;

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

        public override CheckBoxPainter CheckBoxPainter
        {
            get
            {
                return new Memphis.CheckBoxPainter();
            }
        }
    }

    namespace Memphis
    {
        internal class CheckBoxPainter : Default.CheckBoxPainter
        {
            #region Standard
            public override void DrawNormalCheckBox(Graphics g, Rectangle bounds, Color backColor, Color foreColor, CheckState state)
            {
                int check_box_visible_size = (bounds.Height > bounds.Width) ? bounds.Width : bounds.Height;
                int x_pos = Math.Max(0, bounds.X + (bounds.Width / 2) - check_box_visible_size / 2);
                int y_pos = Math.Max(0, bounds.Y + (bounds.Height / 2) - check_box_visible_size / 2);

                Rectangle rect = new Rectangle(x_pos, y_pos, check_box_visible_size, check_box_visible_size);

                g.FillRectangle(new SolidBrush(Application.CurrentSkin.CheckBoxBackgroundColor), rect.X + 2, rect.Y + 2, rect.Width - 3, rect.Height - 3);

                Pen pen = new Pen(Application.CurrentSkin.Border3DTopLeftInner, 1);
                g.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Bottom - 2);
                g.DrawLine(pen, rect.X + 1, rect.Y, rect.Right - 2, rect.Y);

                pen = new Pen(Application.CurrentSkin.Border3DBottomRight, 1);
                g.DrawLine(pen, rect.X + 1, rect.Y + 1, rect.X + 1, rect.Bottom - 3);
                g.DrawLine(pen, rect.X + 2, rect.Y + 1, rect.Right - 3, rect.Y + 1);

                pen = new Pen(Application.CurrentSkin.Border3DTopLeftInner, 1);
                g.DrawLine(pen, rect.Right - 1, rect.Y, rect.Right - 1, rect.Bottom - 1);
                g.DrawLine(pen, rect.X, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);

                // oh boy, matching ms is like fighting against windmills
                using (Pen h_pen = new Pen(Application.CurrentSkin.CheckBoxCheckColor))
                {
                    g.DrawLine(h_pen, rect.X + 1, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 2);
                    g.DrawLine(h_pen, rect.Right - 2, rect.Y + 1, rect.Right - 2, rect.Bottom - 2);
                }

                if (state == CheckState.Checked)
                    DrawCheck(g, bounds, Application.CurrentSkin.CheckBoxCheckColor);
                else if (state == CheckState.Indeterminate)
                    DrawCheck(g, bounds, Application.CurrentSkin.CheckBoxCheckColor);
            }

            public override void DrawHotCheckBox(Graphics g, Rectangle bounds, Color backColor, Color foreColor, CheckState state)
            {
                DrawNormalCheckBox(g, bounds, backColor, foreColor, state);
            }

            public override void DrawPressedCheckBox(Graphics g, Rectangle bounds, Color backColor, Color foreColor, CheckState state)
            {
                int check_box_visible_size = (bounds.Height > bounds.Width) ? bounds.Width : bounds.Height;
                int x_pos = Math.Max(0, bounds.X + (bounds.Width / 2) - check_box_visible_size / 2);
                int y_pos = Math.Max(0, bounds.Y + (bounds.Height / 2) - check_box_visible_size / 2);

                Rectangle rect = new Rectangle(x_pos, y_pos, check_box_visible_size, check_box_visible_size);

                g.FillRectangle(new SolidBrush(Application.CurrentSkin.CheckBoxCheckColor), rect.X + 2, rect.Y + 2, rect.Width - 3, rect.Height - 3);

                Pen pen = new Pen(Application.CurrentSkin.Border3DBottomRightInner, 1);
                g.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Bottom - 2);
                g.DrawLine(pen, rect.X + 1, rect.Y, rect.Right - 2, rect.Y);

                pen = new Pen(Application.CurrentSkin.Border3DBottomRight, 1);
                g.DrawLine(pen, rect.X + 1, rect.Y + 1, rect.X + 1, rect.Bottom - 3);
                g.DrawLine(pen, rect.X + 2, rect.Y + 1, rect.Right - 3, rect.Y + 1);

                pen = new Pen(Application.CurrentSkin.Border3DTopLeftInner, 1);
                g.DrawLine(pen, rect.Right - 1, rect.Y, rect.Right - 1, rect.Bottom - 1);
                g.DrawLine(pen, rect.X, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);

                // oh boy, matching ms is like fighting against windmills
                using (Pen h_pen = new Pen(Application.CurrentSkin.CheckBoxCheckColor))
                {
                    g.DrawLine(h_pen, rect.X + 1, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 2);
                    g.DrawLine(h_pen, rect.Right - 2, rect.Y + 1, rect.Right - 2, rect.Bottom - 2);
                }

                if (state == CheckState.Checked)
                    DrawCheck(g, bounds, Application.CurrentSkin.CheckBoxCheckColor);
                else if (state == CheckState.Indeterminate)
                    DrawCheck(g, bounds, Application.CurrentSkin.CheckBoxCheckColor);
            }

            public override void DrawDisabledCheckBox(Graphics g, Rectangle bounds, Color backColor, Color foreColor, CheckState state)
            {
                DrawPressedCheckBox(g, bounds, backColor, foreColor, CheckState.Unchecked);

                if (state == CheckState.Checked || state == CheckState.Indeterminate)
                    DrawCheck(g, bounds, SystemColors.ControlDark);
            }
            #endregion

            #region FlatStyle
            public override void DrawFlatNormalCheckBox(Graphics g, Rectangle bounds, Color backColor, Color foreColor, CheckState state)
            {
                DrawNormalCheckBox(g, bounds, backColor, foreColor, state);
            }

            public override void DrawFlatHotCheckBox(Graphics g, Rectangle bounds, Color backColor, Color foreColor, CheckState state)
            {
                DrawFlatNormalCheckBox(g, bounds, backColor, foreColor, state);
            }

            public override void DrawFlatPressedCheckBox(Graphics g, Rectangle bounds, Color backColor, Color foreColor, CheckState state)
            {
                DrawPressedCheckBox(g, bounds, backColor, foreColor, state);
            }

/*            public override void DrawFlatDisabledCheckBox(Graphics g, Rectangle bounds, Color backColor, Color foreColor, CheckState state)
            {
                Rectangle checkbox_rectangle;

                checkbox_rectangle = new Rectangle(bounds.X, bounds.Y, Math.Max(bounds.Width - 2, 0), Math.Max(bounds.Height - 2, 0));

                WidgetPaint.DrawBorder(g, checkbox_rectangle, foreColor, ButtonBorderStyle.Solid);

                bounds.Offset(-1, 0);

                if (state == CheckState.Checked || state == CheckState.Indeterminate)
                    DrawCheck(g, bounds, SystemColors.ControlDarkDark);
            }*/
            #endregion

            #region Popup
            public override void DrawPopupNormalCheckBox(Graphics g, Rectangle bounds, Color backColor, Color foreColor, CheckState state)
            {
                DrawFlatNormalCheckBox(g, bounds, backColor, foreColor, state);
            }

            public override void DrawPopupHotCheckBox(Graphics g, Rectangle bounds, Color backColor, Color foreColor, CheckState state)
            {
                DrawFlatNormalCheckBox(g, bounds, backColor, foreColor, state);
            }

            public override void DrawPopupPressedCheckBox(Graphics g, Rectangle bounds, Color backColor, Color foreColor, CheckState state)
            {
                DrawFlatPressedCheckBox(g, bounds, backColor, foreColor, state);
            }

            public override void DrawPopupDisabledCheckBox(Graphics g, Rectangle bounds, Color backColor, Color foreColor, CheckState state)
            {
            }
            #endregion

            #region Check
            public override void DrawCheck(Graphics g, Rectangle bounds, Color checkColor)
            {
                int check_size = (bounds.Height > bounds.Width) ? bounds.Width / 2 : bounds.Height / 2;

                Pen check_pen = ResPool.GetPen(checkColor);

                if (check_size < 7)
                {
                    int lineWidth = Math.Max(3, check_size / 3);
                    int Scale = Math.Max(1, check_size / 9);

                    Rectangle rect = new Rectangle(bounds.X + (bounds.Width / 2) - (check_size / 2) - 1, bounds.Y + (bounds.Height / 2) - (check_size / 2) - 1,
                                    check_size, check_size);

                    for (int i = 0; i < lineWidth; i++)
                    {
                        g.DrawLine(check_pen, rect.Left + lineWidth / 2, rect.Top + lineWidth + i, rect.Left + lineWidth / 2 + 2 * Scale, rect.Top + lineWidth + 2 * Scale + i);
                        g.DrawLine(check_pen, rect.Left + lineWidth / 2 + 2 * Scale, rect.Top + lineWidth + 2 * Scale + i, rect.Left + lineWidth / 2 + 6 * Scale, rect.Top + lineWidth - 2 * Scale + i);
                    }
                }
                else
                {
                    int lineWidth = Math.Max(3, check_size / 3) + 1;

                    int x_half = bounds.Width / 2;
                    int y_half = bounds.Height / 2;

                    Rectangle rect = new Rectangle(bounds.X + x_half - (check_size / 2) - 1, bounds.Y + y_half - (check_size / 2),
                                    check_size, check_size);

                    int gradient_left = check_size / 3;
                    int gradient_right = check_size - gradient_left - 1;

                    for (int i = 0; i < lineWidth; i++)
                    {
                        g.DrawLine(check_pen, rect.X, rect.Bottom - 1 - gradient_left - i, rect.X + gradient_left, rect.Bottom - 1 - i);
                        g.DrawLine(check_pen, rect.X + gradient_left, rect.Bottom - 1 - i, rect.Right - 1, rect.Bottom - i - 1 - gradient_right);
                    }
                }
            }
            #endregion

        }
        
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
