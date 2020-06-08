using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;


namespace cSharpUlamSpiralFunction
{
    class UlamSpiral
    {
        private Panel pnlUlamSpiral;
        private int spiralSize;
        private int trf;
        private int cellSize;
        private int cellNum = 0;
        private System.Timers.Timer timTimer = new System.Timers.Timer();

        public UlamSpiral(int gridSize, Form frm)
        {
            pnlUlamSpiral = new Panel();
            pnlUlamSpiral.Location = new Point(23, 235);
            pnlUlamSpiral.Size = new Size(400, 400);
            pnlUlamSpiral.BorderStyle = BorderStyle.FixedSingle;
            frm.Controls.Add(pnlUlamSpiral);

            spiralSize = gridSize;
            trf = gridSize / 2;
            cellSize = pnlUlamSpiral.Width / spiralSize;

            timTimer.Interval = 500;
            timTimer.Elapsed += CreateCell;

            timTimer.AutoReset = false;
            timTimer.Enabled = true;
        }





        private void CreateCell(object sender, ElapsedEventArgs e)
        {

            Label lbl = new Label();
            Point coor = UlamSpiral.UlamSpiralCoordinate(cellNum);
            lbl.Location = new Point((coor.X + trf) * cellSize, (coor.Y + trf) * cellSize);
            lbl.Size = new Size(cellSize, cellSize);
            lbl.BackColor = Color.Red;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Text = cellNum.ToString();
            lbl.Font = new Font("New Courier", cellSize / 4);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            pnlUlamSpiral.Controls.Add(lbl);

            cellNum++;
            if (cellNum >= spiralSize) { timTimer.Stop(); }

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

