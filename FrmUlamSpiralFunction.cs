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
            int[] x = new int[14] { 9, 6, -16, 2, 4, -1, 1, -1, 1, 0, -1, 1, 24,-16 };
            int[] y = new int[14] { 9, 10, 8, 3, -3, -1, 1, 1, -1, 2, 0, 0, 5 , -8};

            string checkOK;

            for (int i = 0; i < n.Length; i++)
            {
                Point coord = UlamSpiralCoordinates(n[i]);
                //    LbxOutput.Items.Add($"n={n[i]}  x={coord.X}    y={coord.Y}");

                if (x[i]== coord.X && y[i]== coord.Y)
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

        public Point UlamSpiralCoordinates(int n)
        {
            Point xyCoor = new Point();
            int p = Convert.ToInt32(Math.Floor(Math.Sqrt((4 * n) + 1)));
            int q = n - Convert.ToInt32(Convert.ToDouble(p * p) / 4);
            int A = q;
            int B = Convert.ToInt32(Math.Floor(Convert.ToDouble((p + 2) / 4)));
            int C = Convert.ToInt32(Math.Floor(Convert.ToDouble((p + 1) / 4)));
            int P = p % 4;

            int xAC = 0; int xB = 0; int yAC = 0; int yB = 0;

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

    public static class StringFormatting
    {
        public static string LJ(this string str, int width, char chr)
        {
            return str.PadRight(width, chr);
        }

        public static string RJ(this string str, int width, char chr, int rightSpaces = 0)
        {
            return str.PadLeft(width, chr) + "".PadLeft(rightSpaces);
        }

        public static string LJ(this int num, int width, char chr)
        {
            //return num.ToString().PadRight(width);
            return num.ToString().LJ(width, chr);
        }

        public static string RJ(this int num, int width, char chr, int rightSpaces = 0)
        {
            //return num.ToString().PadLeft(width) + "".PadLeft(rightSpaces);
            return num.ToString().RJ(width, chr, rightSpaces);
        }

    }

}