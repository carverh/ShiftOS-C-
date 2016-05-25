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
    public partial class ListViewEx : UserControl
    {
        private List<Item> items = null;
        private List<Column> columns = null;

        public ListViewEx()
        {
            InitializeComponent();
            items = new List<Item>();
            columns = new List<Column>();
        }

        private Color _item_color = Color.Gray;

        public Color ItemSelectedColor
        {
            get { return _item_color; }
            set
            {
                _item_color = value;
            }
        }

        private void setup_ui()
        {
            
        }
    }

    public class Item
    {
        public Item(string text)
        {
            Text = text;
            SubItems = new List<Item>();
        }

        public string Text { get; set; }
        public List<Item> SubItems { get; set; }
        public object Tag { get; set; }
    }

    public class Column
    {
        public Column(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }

}
