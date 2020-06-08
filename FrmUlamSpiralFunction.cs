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



            //ListBoxPrint p = new ListBoxPrint(LbxOutput);

            //for (int i = 0; i < (sz * sz); i++)
            //{
            //    Point c = UlamSpiral.UlamSpiralCoordinate(i);
            //    p.Print($" {i.RJ(3, '0')}  n={i.RJ(3, ' ')} ({(c.X).RJ(3, ' ')},{(c.Y).RJ(3, ' ')})  ({(c.X + ss).RJ(3, ' ')},{(c.Y + ss).RJ(3, ' ')})");
            //}


        }
    }
}