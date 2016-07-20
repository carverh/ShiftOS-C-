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
    public partial class BitnoteConverter : Form
    {
        /// <summary>
        /// GUI for the Bitnote Converter package.
        /// </summary>
        public BitnoteConverter()
        {
            InitializeComponent();
        }

        private decimal BitnotesToAdd = 0;

        private void txtcodepoints_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int cp = Convert.ToInt16(txtcodepoints.Text);
                if(cp > API.CurrentSave.codepoints)
                {
                    txtcodepoints.Text = API.CurrentSave.codepoints.ToString();
                }
                string decstr = ((decimal)cp / 24).ToString("#.#####");
                
                
                lbstatus.Text = "> " + decstr + " BTN";
                BitnotesToAdd = Convert.ToDecimal(decstr);
            }
            catch
            {
                BitnotesToAdd = 0;
            }
        }

        private void btnconvert_Click(object sender, EventArgs e)
        {
            if(BitnotesToAdd > 0)
            {
                API.RemoveCodepoints((int)(BitnotesToAdd * 24));
                API.BitnoteAddress.Bitnotes += BitnotesToAdd;
                API.CreateInfoboxSession("Bitnote Converter", "Your codepoints have been converted to Bitnotes successfully.", infobox.InfoboxMode.Info);
            }
            else
            {
                API.CreateInfoboxSession("Bitnote Converter", "An invalid ammount of Codepoints was entered. We couldn't convert them.", infobox.InfoboxMode.Info);
            }
        }

        private void BitnoteConverter_Load(object sender, EventArgs e)
        {

        }
    }
}
