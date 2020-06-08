using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpUlamSpiralFunction
{
    class UlamSpiral
    {
        private Panel pnlUlamSpiral;
        private int spiralSize;
        private int trf;
        private int labelSize;

        public UlamSpiral(Panel pnlUS, int gridSize)
        {
            pnlUlamSpiral = pnlUS;
            spiralSize = gridSize;
            trf = gridSize / 2;
            labelSize = pnlUlamSpiral.Width / spiralSize;
            CreateSprial();

        }

        private void CreateSprial()
        {

            for (int i = 0; i < spiralSize * spiralSize; i++)
            {
                Point coor = UlamSpiral.UlamSpiralCoordinate(i);

                Label lbl = new Label();
                lbl.Size = new Size(labelSize, labelSize);
                lbl.Location = new Point((coor.X + trf) * labelSize, (coor.Y + trf) * labelSize);
                lbl.BackColor = Color.Red;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Text = i.ToString();
                lbl.Font = new Font("New Courier", labelSize / 4);
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Name = $"N{i}";
                lbl.Tag = $"{(coor.X + trf)}|{coor.Y + trf}";
                lbl.Click += Lbl_Click;
                pnlUlamSpiral.Controls.Add(lbl);
            }

        }

        private void Lbl_Click(object sender, EventArgs e)
        {
            Label ABC = (Label)sender;
            ABC.BackColor = Color.Yellow;
        }

        public static Point UlamSpiralCoordinate(int n)
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
                case 0: xAC = 1; xB = 0; yAC = 0; yB = -1; break;
                case 1: xAC = 0; xB = 1; yAC = 1; yB = 0; break;
                case 2: xAC = -1; xB = 0; yAC = 0; yB = 1; break;
                case 3: xAC = 0; xB = -1; yAC = -1; yB = 0; break;
            }
            xyCoor.X = (xAC * (A - C)) + (xB * (B));
            xyCoor.Y = (yAC * (A - C)) + (yB * (B));
            return xyCoor;
        }

    }

}

