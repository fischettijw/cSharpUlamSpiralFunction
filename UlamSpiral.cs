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
        private Panel pnlUSl;
        private int spiralSize;
        private int trf;
        private int lblSize;

        public UlamSpiral(Panel pnlUlamSpiral, int gridSize)
        {
            pnlUSl = pnlUlamSpiral;
            spiralSize = gridSize;
            trf = gridSize / 2;
            lblSize = pnlUlamSpiral.Width / spiralSize;
            CreateSprial();
        }

        private void CreateSprial()
        {

            for (int i = 0; i < spiralSize * spiralSize; i++)
            {
                Label lbl = new Label();
                Point coor = UlamSpiral.UlamSpiralCoordinate(i);
                lbl.Location = new Point((coor.X + trf) * lblSize, (coor.Y + trf) * lblSize);
                lbl.Size = new Size(lblSize, lblSize);
                lbl.BackColor = Color.Red;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                //lbl.Text = i.ToString();
                //lbl.Font = new Font("New Courier", 14);
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                pnlUSl.Controls.Add(lbl);
            }
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
