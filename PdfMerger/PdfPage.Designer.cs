namespace PdfMerger
{
    partial class PdfPage
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
            pictureBox = new PictureBox();
            pictureBoxDot = new PictureBox();
            labelTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDot).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.Enabled = false;
            pictureBox.Location = new Point(7, 50);
            pictureBox.Margin = new Padding(4, 5, 4, 5);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(829, 927);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // pictureBoxDot
            // 
            pictureBoxDot.Enabled = false;
            pictureBoxDot.Location = new Point(11, 13);
            pictureBoxDot.Margin = new Padding(4, 5, 4, 5);
            pictureBoxDot.Name = "pictureBoxDot";
            pictureBoxDot.Size = new Size(23, 27);
            pictureBoxDot.TabIndex = 1;
            pictureBoxDot.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(57, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(41, 25);
            labelTitle.TabIndex = 2;
            labelTitle.Text = "title";
            // 
            // PdfPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(labelTitle);
            Controls.Add(pictureBoxDot);
            Controls.Add(pictureBox);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            Margin = new Padding(7, 8, 7, 8);
            Name = "PdfPage";
            Padding = new Padding(7, 8, 7, 8);
            Size = new Size(843, 985);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDot).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private PictureBox pictureBoxDot;
        private Label labelTitle;
    }
}
