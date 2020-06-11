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
            CheckForIllegalCrossThreadCalls = false;
        }

        private void FrmUlamSpiralFunction_Load(object sender, EventArgs e)
        {
            this.Location = new Point(600, 50);
            Form Spiral = new Form();
            int matrixSize = 25;
            int frmSize = 200;
            //int ss = sz / 2;
            UlamSpiral US = new UlamSpiral(Spiral, matrixSize, frmSize);
        }
    }
}