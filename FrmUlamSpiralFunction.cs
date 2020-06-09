using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace cSharpUlamSpiralFunction
{
    public partial class FrmUlamSpiralFunction : Form
    {

        public FrmUlamSpiralFunction()
        {
            InitializeComponent();
        }

        private void FrmUlamSpiralFunction_Load(object sender, EventArgs e)
        {

            int sz = 15;
            int ss = sz / 2;
            UlamSpiral US = new UlamSpiral(PnlSpiral, sz);

        }
    }
}