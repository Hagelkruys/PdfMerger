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
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDot).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.Enabled = false;
            pictureBox.Location = new Point(5, 30);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(580, 556);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // pictureBoxDot
            // 
            pictureBoxDot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxDot.Enabled = false;
            pictureBoxDot.Location = new Point(566, 8);
            pictureBoxDot.Name = "pictureBoxDot";
            pictureBoxDot.Size = new Size(16, 16);
            pictureBoxDot.TabIndex = 1;
            pictureBoxDot.TabStop = false;
            // 
            // PdfPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(pictureBoxDot);
            Controls.Add(pictureBox);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            Margin = new Padding(5);
            Name = "PdfPage";
            Padding = new Padding(5);
            Size = new Size(590, 591);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDot).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
        private PictureBox pictureBoxDot;
    }
}
