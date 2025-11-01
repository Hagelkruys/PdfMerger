namespace PdfMerger.SettingsPanels
{
    partial class RenderSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbAddBorder = new CheckBox();
            cbWhiteBackground = new CheckBox();
            label1 = new Label();
            numBorderWidth = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numBorderWidth).BeginInit();
            SuspendLayout();
            // 
            // cbAddBorder
            // 
            cbAddBorder.AutoSize = true;
            cbAddBorder.Checked = true;
            cbAddBorder.CheckState = CheckState.Checked;
            cbAddBorder.Location = new Point(16, 20);
            cbAddBorder.Name = "cbAddBorder";
            cbAddBorder.Size = new Size(222, 19);
            cbAddBorder.TabIndex = 0;
            cbAddBorder.Text = "Show a border arround the PDF-page";
            cbAddBorder.UseVisualStyleBackColor = true;
            // 
            // cbWhiteBackground
            // 
            cbWhiteBackground.AutoSize = true;
            cbWhiteBackground.Checked = true;
            cbWhiteBackground.CheckState = CheckState.Checked;
            cbWhiteBackground.Location = new Point(16, 84);
            cbWhiteBackground.Name = "cbWhiteBackground";
            cbWhiteBackground.Size = new Size(293, 19);
            cbWhiteBackground.TabIndex = 1;
            cbWhiteBackground.Text = "Add a white background to the rendered PDF page";
            cbWhiteBackground.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 47);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 2;
            label1.Text = "Border width:";
            // 
            // numBorderWidth
            // 
            numBorderWidth.Location = new Point(127, 45);
            numBorderWidth.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numBorderWidth.Name = "numBorderWidth";
            numBorderWidth.Size = new Size(47, 23);
            numBorderWidth.TabIndex = 3;
            // 
            // RenderSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numBorderWidth);
            Controls.Add(label1);
            Controls.Add(cbWhiteBackground);
            Controls.Add(cbAddBorder);
            Name = "RenderSettings";
            Size = new Size(670, 377);
            ((System.ComponentModel.ISupportInitialize)numBorderWidth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbAddBorder;
        private CheckBox cbWhiteBackground;
        private Label label1;
        private NumericUpDown numBorderWidth;
    }
}
