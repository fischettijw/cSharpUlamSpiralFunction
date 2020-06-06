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

            int[] n = new int[14] { 360, 364, 1000, 25, 73, 4, 8, 2, 6, 10, 3, 7, 2381, 1000 };
            int[] x = new int[14] { 9, 6, -16, 2, 4, -1, 1, -1, 1, 0, -1, 1, 24, -16 };
            int[] y = new int[14] { 9, 10, 8, 3, -3, -1, 1, 1, -1, 2, 0, 0, 5, -8 };

            string checkOK;

            for (int i = 0; i < n.Length; i++)
            {
                Point coord = MyMethods.UlamSpiralCoordinates(n[i]);

                if (x[i] == coord.X && y[i] == coord.Y)
                {
                    checkOK = "OK";
                }
                else
                {
                    checkOK = $"Error:  {x[i]}, {y[i]} ";
                }


                LbxOutput.Items.Add($" {i.RJ(3, '0')}   n={n[i].RJ(6, ' ', 5)} x={coord.X.RJ(4, ' ', 5)} y={coord.Y.RJ(4, ' ')}    {checkOK}   ");
            }
        }
    }
}