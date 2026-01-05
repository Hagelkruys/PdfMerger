namespace PdfMerger.SettingsPanels
{
    partial class ImageSettings
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
            comboBoxImagePlacementMethod = new ComboBox();
            labelImagePlacementMethod = new Label();
            checkBoxRotatePageToImage = new CheckBox();
            SuspendLayout();
            // 
            // comboBoxImagePlacementMethod
            // 
            comboBoxImagePlacementMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxImagePlacementMethod.FormattingEnabled = true;
            comboBoxImagePlacementMethod.Location = new Point(53, 62);
            comboBoxImagePlacementMethod.Name = "comboBoxImagePlacementMethod";
            comboBoxImagePlacementMethod.Size = new Size(222, 23);
            comboBoxImagePlacementMethod.TabIndex = 9;
            // 
            // labelImagePlacementMethod
            // 
            labelImagePlacementMethod.AutoSize = true;
            labelImagePlacementMethod.Location = new Point(5, 44);
            labelImagePlacementMethod.Name = "labelImagePlacementMethod";
            labelImagePlacementMethod.Size = new Size(144, 15);
            labelImagePlacementMethod.TabIndex = 8;
            labelImagePlacementMethod.Text = "Image placement method";
            labelImagePlacementMethod.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBoxRotatePageToImage
            // 
            checkBoxRotatePageToImage.AutoSize = true;
            checkBoxRotatePageToImage.Location = new Point(5, 12);
            checkBoxRotatePageToImage.Name = "checkBoxRotatePageToImage";
            checkBoxRotatePageToImage.Size = new Size(200, 19);
            checkBoxRotatePageToImage.TabIndex = 7;
            checkBoxRotatePageToImage.Text = "Rotate page to image orientation";
            checkBoxRotatePageToImage.UseVisualStyleBackColor = true;
            // 
            // ImageSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBoxImagePlacementMethod);
            Controls.Add(labelImagePlacementMethod);
            Controls.Add(checkBoxRotatePageToImage);
            Name = "ImageSettings";
            Size = new Size(560, 359);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxImagePlacementMethod;
        private Label labelImagePlacementMethod;
        private CheckBox checkBoxRotatePageToImage;
    }
}
