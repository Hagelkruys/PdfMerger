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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfPage));
            pictureBox = new PictureBox();
            pictureBoxDot = new PictureBox();
            labelTitle = new Label();
            button1 = new Button();
            imageList1 = new ImageList(components);
            buttonExpandCollapse = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDot).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.Enabled = false;
            pictureBox.Location = new Point(5, 35);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(580, 548);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // pictureBoxDot
            // 
            pictureBoxDot.Enabled = false;
            pictureBoxDot.Location = new Point(8, 9);
            pictureBoxDot.Name = "pictureBoxDot";
            pictureBoxDot.Size = new Size(16, 16);
            pictureBoxDot.TabIndex = 1;
            pictureBoxDot.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(29, 10);
            labelTitle.Margin = new Padding(2, 0, 2, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(27, 15);
            labelTitle.TabIndex = 2;
            labelTitle.Text = "title";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.ImageIndex = 2;
            button1.ImageList = imageList1;
            button1.Location = new Point(555, 5);
            button1.Name = "button1";
            button1.Size = new Size(30, 24);
            button1.TabIndex = 4;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "collapse.png");
            imageList1.Images.SetKeyName(1, "expand.png");
            imageList1.Images.SetKeyName(2, "delete.png");
            // 
            // buttonExpandCollapse
            // 
            buttonExpandCollapse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExpandCollapse.ImageIndex = 0;
            buttonExpandCollapse.ImageList = imageList1;
            buttonExpandCollapse.Location = new Point(519, 5);
            buttonExpandCollapse.Name = "buttonExpandCollapse";
            buttonExpandCollapse.Size = new Size(30, 24);
            buttonExpandCollapse.TabIndex = 3;
            buttonExpandCollapse.UseVisualStyleBackColor = true;
            buttonExpandCollapse.Click += buttonExpandCollapse_Click;
            // 
            // PdfPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(button1);
            Controls.Add(buttonExpandCollapse);
            Controls.Add(labelTitle);
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
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private PictureBox pictureBoxDot;
        private Label labelTitle;
        private Button button1;
        private ImageList imageList1;
        private Button buttonExpandCollapse;
    }
}
