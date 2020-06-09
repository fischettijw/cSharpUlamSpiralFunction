using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpUlamSpiralFunction
{
    enum Status
    {
        NoSymptoms,
        SymptomsNotTested,
        TestedPositive,
        TestedNegitive,
        ImmunityConfirmed,
        Dead
    }
    class UlamSpiral
    {
        static Dictionary<Status, Color> StatusColor = new Dictionary<Status, Color>()
        {
            {Status.NoSymptoms,Color.White},
            {Status.SymptomsNotTested,Color.LightPink},
            {Status.TestedPositive,Color.Red},
            {Status.TestedNegitive,Color.Green},
            {Status.ImmunityConfirmed,Color.Yellow},
            {Status.Dead,Color.Gray}
         };

        private Form spiralForm;
        private Panel pnlUlamSpiral;
        private int spiralSize;
        private int trf;
        private int labelSize;
        private Random rnd = new Random();
        private int panelSize = 500;

        public UlamSpiral(Form sForm, int gridSize)
        {
            spiralForm = sForm;
            spiralSize = gridSize;
            trf = gridSize / 2;
            CreateNewFormAndPanel();
            CreateSpiral();

        }

        private void CreateNewFormAndPanel()
        {
            spiralForm = new Form();
            spiralForm.Text = "Ulam Spiral";
            pnlUlamSpiral = new Panel();
            pnlUlamSpiral.Dock = DockStyle.Fill;
            pnlUlamSpiral.Size = new Size(panelSize, panelSize);
            pnlUlamSpiral.BorderStyle = BorderStyle.FixedSingle;
            labelSize = pnlUlamSpiral.Width / spiralSize;
            spiralForm.ClientSize = new Size(labelSize * spiralSize, labelSize * spiralSize);
            spiralForm.Location = new Point(100, 100);
            spiralForm.Controls.Add(pnlUlamSpiral);
            spiralForm.Show();
        }

        private void CreateSpiral()
        {
            for (int i = 0; i < spiralSize * spiralSize; i++)
            {
                Point coor = UlamSpiral.UlamSpiralCoordinate(i);

                Label lbl = new Label();
                lbl.Size = new Size(labelSize, labelSize);
                lbl.Location = new Point((coor.X + trf) * labelSize, (coor.Y + trf) * labelSize);
                lbl.BackColor = StatusColor[(Status)rnd.Next(Enum.GetNames(typeof(Status)).Length)];
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
            Label cell = (Label)sender;
            //cell.BackColor = StatusColor[(Status)rnd.Next(Enum.GetNames(typeof(Status)).Length)];
            cell.BackColor = StatusColor[Status.TestedNegitive];
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

