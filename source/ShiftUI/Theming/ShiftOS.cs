using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftUI.ShiftOS
{
    public abstract class Skin
    {
        #region Button
        public int ButtonBorderWidth = 2;
        public Color ButtonBorderColor = Color.Black;
        public Color ButtonBackColor = Color.White;
        public Color ButtonBackColor_Pressed = Color.Gray;
        public Color ButtonBackColor_Checked = Color.Black;
        #endregion

        #region Global
        public Color SelectionHighlight = Color.Black;
        public string DefaultFont = "Microsoft Sans Serif";
        public Color VisualStyleBorderColor = Color.Black;
        public int VisualStyleBorderWidth = 2;
        public int DefaultFontSize = 9;
        public FontStyle DefaultFontStyle = FontStyle.Regular;
        public Color WindowBackColor = Color.Gray;
        public Color DefaultForeColor = Color.Black;
        #endregion

        #region ScrollBar
        public int ScrollbarWidth = 24;
        #endregion

        #region 3D borders
        public Color Border3DTopLeftInner = Color.LightGray;
        public Color Border3DBottomRight = Color.DarkGray;
        public Color Border3DBottomRightInner = Color.Gray;
        #endregion

        #region CheckBox
        public Color CheckBoxCheckColor = Color.Black;
        public Color CheckBoxBorderColor = Color.Black;
        public Color CheckBoxBackgroundColor = Color.White;
        public int CheckBoxBorderWidth = 2;
        #endregion

        #region MessageBox
        public Color MessageBox_BottomPanel = Color.Gray;
        #endregion

        #region ProgressBar

        public Color ProgressBar_BackgroundColor = Color.Gray;
        public Color ProgressBar_BlockColor = Color.Black;

        #endregion

        #region ListView
        public Color ListViewBackground = Color.White;
        #endregion

        // No reason to have ShiftOS deal with window borders itself
        // when I can do it inside ShiftUI.
        #region Form
        public int titlebarlayout = 3;
        public int borderleftlayout = 3;
        public int borderrightlayout = 3;
        public int borderbottomlayout = 3;
        public int closebtnlayout = 3;
        public int rollbtnlayout = 3;
        public int minbtnlayout = 3;
        public int rightcornerlayout = 3;
        public int leftcornerlayout = 3;
        // Late entry: need to fix window code to include this
        public int bottomleftcornerlayout = 3;
        public int bottomrightcornerlayout = 3;
        public Color bottomleftcornercolour = Color.Gray;

        public Color bottomrightcornercolour = Color.Gray;

        public bool enablebordercorners = false;
        // settings
        public Size closebtnsize = new Size(22, 22);
        public Size rollbtnsize = new Size(22, 22);
        public Size minbtnsize = new Size(22, 22);
        public int titlebarheight = 30;
        public int titlebariconsize = 16;
        public int closebtnfromtop = 5;
        public int closebtnfromside = 2;
        public int rollbtnfromtop = 5;
        public int rollbtnfromside = 26;
        public int minbtnfromtop = 5;
        public int minbtnfromside = 52;
        public int borderwidth = 2;
        public bool enablecorners = false;
        public int titlebarcornerwidth = 5;
        public int titleiconfromside = 4;
        public int titleiconfromtop = 4;
        //colours
        public Color titlebarcolour = Color.Gray;
        public Color borderleftcolour = Color.Gray;
        public Color borderrightcolour = Color.Gray;
        public Color borderbottomcolour = Color.Gray;
        public Color closebtncolour = Color.Black;
        public Color closebtnhovercolour = Color.Black;
        public Color closebtnclickcolour = Color.Black;
        public Color rollbtncolour = Color.Black;
        public Color rollbtnhovercolour = Color.Black;
        public Color rollbtnclickcolour = Color.Black;
        public Color minbtncolour = Color.Black;
        public Color minbtnhovercolour = Color.Black;
        public Color minbtnclickcolour = Color.Black;
        public Color rightcornercolour = Color.Gray;
        public Color leftcornercolour = Color.Gray;
        // Text
        public string titletextfontfamily = "Microsoft Sans Serif";
        public int titletextfontsize = 10;
        public FontStyle titletextfontstyle = FontStyle.Bold;
        public string titletextpos = "Left";
        public int titletextfromtop = 3;
        public int titletextfromside = 24;

        public Color titletextcolour = Color.White;

        #endregion
    }

    public class DefaultSkin : Skin
    {
        
    }
}
