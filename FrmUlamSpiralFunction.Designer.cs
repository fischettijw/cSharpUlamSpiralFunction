namespace cSharpUlamSpiralFunction
{
    partial class FrmUlamSpiralFunction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LbxOutput = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LbxOutput
            // 
            this.LbxOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbxOutput.FormattingEnabled = true;
            this.LbxOutput.ItemHeight = 24;
            this.LbxOutput.Location = new System.Drawing.Point(158, 21);
            this.LbxOutput.Name = "LbxOutput";
            this.LbxOutput.Size = new System.Drawing.Size(448, 412);
            this.LbxOutput.TabIndex = 0;
            // 
            // FrmUlamSpiralFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LbxOutput);
            this.Name = "FrmUlamSpiralFunction";
            this.Text = "Ulam Spiral Function";
            this.Load += new System.EventHandler(this.FrmUlamSpiralFunction_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LbxOutput;
    }
}

