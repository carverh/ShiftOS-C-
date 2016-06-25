using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class ProgressBarEX : UserControl
    {
        public ProgressBarEX()
        {
            InitializeComponent();
        }

        #region " Properties "

        private string _label = "Progress:";
        private bool show_label = false;

        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                this.Invalidate();
            }
        }

        public bool ShowLabel
        {
            get
            {
                return show_label;
            }
            set
            {
                show_label = value;
                this.Invalidate();
            }
        }


        private int _Value = 0;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value >= this.MinValue & value <= this.MaxValue)
                {
                    _Value = value;
                    this.Invalidate();
                }
                else {
                    throw new ArgumentOutOfRangeException("The value must be between the minimum and maximum values.");
                }
            }
        }

        private int _Step = 10;
        public int Step
        {
            get { return _Step; }
            set { _Step = value; }
        }

        private ProgressBarOrientation _Orientation;
        public ProgressBarOrientation Orientation
        {
            get { return _Orientation; }
            set { _Orientation = value; }
        }

        private int _MinValue = 0;
        public int MinValue
        {
            get { return _MinValue; }
            set
            {
                if (value < this.MaxValue)
                {
                    _MinValue = value;
                }
                else {
                    throw new ArgumentOutOfRangeException("The minimum value must be less than the maximum value.");
                }
            }
        }

        private int _MaxValue = 100;
        public int MaxValue
        {
            get { return _MaxValue; }
            set
            {
                if (value > this.MinValue)
                {
                    _MaxValue = value;
                }
                else {
                    throw new ArgumentOutOfRangeException("The maximum value must be more than the minimum value.");
                }
            }
        }

        private Color _Color = Color.Lime;
        public Color Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        private bool _ShowValue = true;
        public bool ShowValue
        {
            get { return _ShowValue; }
            set { _ShowValue = value; }
        }

        private ProgressBarExStyle _Style;
        public ProgressBarExStyle Style
        {
            get { return _Style; }
            set { _Style = value; }
        }

        private int _BlockWidth = 5;
        public int BlockWidth
        {
            get { return _BlockWidth; }
            set { _BlockWidth = value; }
        }

        private int _BlockSeparation = 3;
        public int BlockSeparation
        {
            get { return _BlockSeparation; }
            set { _BlockSeparation = value; }
        }

#endregion

#region " Enums, Variables "

        public enum ProgressBarOrientation
        {
            Horizontal = 0,
            Vertical = 1
        }

        public enum ProgressBarExStyle
        {
            Blocks = 0,
            Continuous = 1,
            Marquee = 2
        }

#endregion

#region " Events "

        public event PaintBackgroundEventHandler PaintBackground;
        public delegate void PaintBackgroundEventHandler(object sender, PaintEventArgs e);
        public event PaintProcessEventHandler PaintProcess;
        public delegate void PaintProcessEventHandler(object sender, ProgressBarProcessPaintEventArgs e);

        public class ProgressBarProcessPaintEventArgs : EventArgs
        {

            public ProgressBarProcessPaintEventArgs(Rectangle bounds, Graphics g, Rectangle[] blocks = null)
            {
                _Bounds = bounds;
                _Graphics = g;
                if (blocks == null)
                {
                    _Blocks = new Rectangle[] {

                };
                }
                else {
                    _Blocks = blocks;
                }
            }

            private Rectangle _Bounds;
            public Rectangle Bounds
            {
                get { return _Bounds; }
            }

            private Rectangle[] _Blocks;
            public Rectangle[] Blocks
            {
                get { return _Blocks; }
            }

            private Graphics _Graphics;
            public Graphics Graphics
            {
                get { return _Graphics; }
            }

        }

#endregion

#region " Methods "

        public void PerformStep()
        {
            if (this.Step > 0)
            {
                this.Value = Math.Min(this.Value + this.Step, this.MaxValue);
            }
            else {
                this.Value = Math.Max(this.Value + this.Step, this.MinValue);
            }
        }

        public void Increment(int value)
        {
            if (value > 0)
            {
                this.Value = Math.Min(this.Value + value, this.MaxValue);
            }
            else {
                this.Value = Math.Max(this.Value + value, this.MinValue);
            }
        }

#endregion

#region " Process Logic "

        private Rectangle GetProcessRect()
        {
            int w = this.Width;
            int h = this.Height;
            int valRel = GetRelativeValue();
            return new Rectangle(0, 0, w * valRel / 100, h);
        }

        private Rectangle[] GetBlocks()
        {
            List<Rectangle> b = new List<Rectangle>();

            int w = this.BlockWidth;
            int h = this.Height;
            Rectangle r;

            int x = 0;
            int stopX = (int)(GetRelativeValue() / 100) * this.Width;
            while ((x + w <= stopX))
            {
                r = new Rectangle(x, 0, w, h);
                b.Add(r);

                x += this.BlockWidth + this.BlockSeparation;
            }

            return b.ToArray();
        }

        private int GetRelativeValue()
        {
            return (int)100 * this.Value / (this.MaxValue - this.MinValue);
        }

#endregion

#region " Drawing "

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            DoPaintBackground(e.Graphics);
            DoPaintProcess(e.Graphics);
            if (this.ShowValue)
                DoPaintValue(e.Graphics);
        }

        private void DoPaintBackground(Graphics g)
        {
            if (PaintBackground != null)
            {
                PaintBackground(this, new PaintEventArgs(g, this.ClientRectangle));
            }
        }

        private void DoPaintProcess(Graphics g)
        {
            Rectangle rect = GetProcessRect();
            Rectangle[] blocks = GetBlocks();
            using (SolidBrush brush = new SolidBrush(this.Color))
            {
                if (this.Style == ProgressBarExStyle.Continuous)
                {
                    g.FillRectangle(brush, rect);
                }
                else if (this.Style == ProgressBarExStyle.Blocks)
                {
                    foreach (Rectangle b in blocks)
                    {
                        g.FillRectangle(brush, b);
                    }
                }
            }

            ProgressBarProcessPaintEventArgs e = new ProgressBarProcessPaintEventArgs(rect, g, blocks);
            if (PaintProcess != null)
            {
                PaintProcess(this, e);
            }
        }

        private void DoPaintValue(Graphics g)
        {
            string valStr = GetRelativeValue().ToString() + "%";
            if (show_label)
                valStr = _label + " " + valStr;

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            SizeF s = g.MeasureString(valStr, this.Font);

            g.DrawString(valStr, this.Font, new SolidBrush(this.ForeColor), (this.Width - s.Width) / 2, (this.Height - s.Height) / 2);
        }

#endregion
    }
}
