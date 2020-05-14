﻿using System;
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
            int[] n = new int[13] { 360, 364, 1000, 25, 73, 4, 8, 2, 6, 10, 3, 7, 2381 };
            LbxOutput.Items.Clear();
            for (int i = 0; i < n.Length; i++)
            {
                Point coord = UlamSpiralCoordinates(n[i]);
                //LbxOutput.Items.Add($"   n={n[i]} x={coord.X} y={coord.Y}");
                LbxOutput.Items.Add($" {i.RJ(3, '0')}   n={n[i].RJ(6, ' ', 5)} x={coord.X.RJ(4, ' ' ,5)} y={coord.Y.RJ(4, ' ')}");
            }
        }

        private Point UlamSpiralCoordinates(int n)
        {
            Point xyCoor = new Point();
            int p = (Int32)(Math.Floor(Math.Sqrt((4 * n) + 1)));
            int q = (Int32)((Double)(p * p) / 4);
            int A = q;
            int B = (Int32)(Math.Floor((Double)((p + 2) / 4)));
            int C = (Int32)(Math.Floor((Double)((p + 1) / 4)));
            int P = p % 4;

            int xAC = 0; int xB = 0; int yAC = 0; int yB = 0;

            switch (P)
            {
                case 0:
                    xAC = 1; xB = 0; yAC = 0; yB = -1;
                    break;
                case 1:
                    xAC = 0; xB = 1; yAC = 1; yB = 0;
                    break;
                case 2:
                    xAC = -1; xB = 0; yAC = 0; yB = 1;
                    break;
                case 3:
                    xAC = 0; xB = -1; yAC = -1; yB = 0;
                    break;
            }
            xyCoor.X = (xAC * (A - C)) + (xB * (B));
            xyCoor.Y = (yAC * (A - C)) + (yB * (B));
            return xyCoor;
        }
    }

    public static class StringFormatting
    {
        public static string LJ(this string str, int width, char chr )
        {
            return str.PadRight(width, chr);
        }

        public static string RJ(this string str, int width, char chr , int rightSpaces = 0)
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
            return num.ToString().RJ(width, chr ,rightSpaces);
        }

    }

}
