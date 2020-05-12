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
            Point test = UlamSpiralCoordinates(73);
        }

        public Point UlamSpiralCoordinates(int n)
        {
            Point xyCoor = new Point();
            int p = Convert.ToInt32(Math.Floor(Math.Sqrt((4 * n) + 1)));
            int q = n - Convert.ToInt32(Convert.ToDouble(p * p) / 4);
            int A = q;
            int B = Convert.ToInt32(Math.Floor(Convert.ToDouble((p + 2) / 4)));
            int C = Convert.ToInt32(Math.Floor(Convert.ToDouble((p + 1) / 4)));
            int P = p % 4;

            int xAC = 0; int xB = 0; int yAC = 0; int yB = 0 ;

            switch (P)
            {
                case 0: //4   x=-1   y=-1    A=0  B=1  C=1
                    xAC = 1;
                    xB = 0;
                    yAC = 0;
                    yB = -1;
                    break;
                case 1: //2381   x=24   y=5    A=29  B=24  C=24
                    xAC = 0;
                    xB = 1;
                    yAC = 1;
                    yB = 0;
                    break;
                case 2: //364    x=6    y=10    A=3  B=10  C=9    
                    xAC = -1;
                    xB = 0;
                    yAC = 0;
                    yB = 1;
                    break;
                case 3: //1000    x=-16   y=8    A=8  B=16  C=16 
                    xAC = 0;
                    xB = -1;
                    yAC = -1;
                    yB = 0;
                    break;
            }
            xyCoor.X = (xAC * (A - C)) + (xB * (B));
            xyCoor.Y = (yAC * (A - C)) + (yB * (B));
            return xyCoor;
        }
    }
}
