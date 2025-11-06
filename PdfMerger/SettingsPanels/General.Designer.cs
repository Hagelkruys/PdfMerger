namespace PdfMerger.SettingsPanels
{
    partial class General
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
            checkBoxShowFilenameExtension = new CheckBox();
            checkBoxSaveAsBundle = new CheckBox();
            checkBoxLoadEveryPage = new CheckBox();
            checkBoxClearProducer = new CheckBox();
            label1 = new Label();
            comboBoxCompressionLevel = new ComboBox();
            label2 = new Label();
            cbColorMode = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // checkBoxShowFilenameExtension
            // 
            checkBoxShowFilenameExtension.AutoSize = true;
            checkBoxShowFilenameExtension.Location = new Point(3, 12);
            checkBoxShowFilenameExtension.Name = "checkBoxShowFilenameExtension";
            checkBoxShowFilenameExtension.Size = new Size(223, 19);
            checkBoxShowFilenameExtension.TabIndex = 1;
            checkBoxShowFilenameExtension.Text = "Show filename extension in page tiles";
            checkBoxShowFilenameExtension.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveAsBundle
            // 
            checkBoxSaveAsBundle.AutoSize = true;
            checkBoxSaveAsBundle.Location = new Point(3, 37);
            checkBoxSaveAsBundle.Name = "checkBoxSaveAsBundle";
            checkBoxSaveAsBundle.Size = new Size(329, 19);
            checkBoxSaveAsBundle.TabIndex = 2;
            checkBoxSaveAsBundle.Text = "Save project as Bundle (inkl. all pdf files in the project file)";
            checkBoxSaveAsBundle.UseVisualStyleBackColor = true;
            // 
            // checkBoxLoadEveryPage
            // 
            checkBoxLoadEveryPage.AutoSize = true;
            checkBoxLoadEveryPage.Location = new Point(3, 62);
            checkBoxLoadEveryPage.Name = "checkBoxLoadEveryPage";
            checkBoxLoadEveryPage.Size = new Size(233, 19);
            checkBoxLoadEveryPage.TabIndex = 3;
            checkBoxLoadEveryPage.Text = "Load every page when adding a pdf file";
            checkBoxLoadEveryPage.UseVisualStyleBackColor = true;
            // 
            // checkBoxClearProducer
            // 
            checkBoxClearProducer.AutoSize = true;
            checkBoxClearProducer.Location = new Point(3, 86);
            checkBoxClearProducer.Name = "checkBoxClearProducer";
            checkBoxClearProducer.Size = new Size(229, 19);
            checkBoxClearProducer.TabIndex = 4;
            checkBoxClearProducer.Text = "Clear the Producer field on pdf export?";
            checkBoxClearProducer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 119);
            label1.Name = "label1";
            label1.Size = new Size(270, 15);
            label1.TabIndex = 5;
            label1.Text = "Compression level when saving project as bundle:";
            // 
            // comboBoxCompressionLevel
            // 
            comboBoxCompressionLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCompressionLevel.FormattingEnabled = true;
            comboBoxCompressionLevel.Location = new Point(281, 116);
            comboBoxCompressionLevel.Name = "comboBoxCompressionLevel";
            comboBoxCompressionLevel.Size = new Size(150, 23);
            comboBoxCompressionLevel.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 153);
            label2.Name = "label2";
            label2.Size = new Size(208, 15);
            label2.TabIndex = 7;
            label2.Text = "Applcation color mode (experimental)";
            // 
            // cbColorMode
            // 
            cbColorMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColorMode.FormattingEnabled = true;
            cbColorMode.Location = new Point(281, 150);
            cbColorMode.Name = "cbColorMode";
            cbColorMode.Size = new Size(150, 23);
            cbColorMode.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(437, 153);
            label3.Name = "label3";
            label3.Size = new Size(212, 15);
            label3.TabIndex = 9;
            label3.Text = "(changes apply after a program restart)";
            // 
            // General
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(cbColorMode);
            Controls.Add(label2);
            Controls.Add(comboBoxCompressionLevel);
            Controls.Add(label1);
            Controls.Add(checkBoxClearProducer);
            Controls.Add(checkBoxLoadEveryPage);
            Controls.Add(checkBoxSaveAsBundle);
            Controls.Add(checkBoxShowFilenameExtension);
            Name = "General";
            Size = new Size(733, 543);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBoxShowFilenameExtension;
        private CheckBox checkBoxSaveAsBundle;
        private CheckBox checkBoxLoadEveryPage;
        private CheckBox checkBoxClearProducer;
        private Label label1;
        private ComboBox comboBoxCompressionLevel;
        private Label label2;
        private ComboBox cbColorMode;
        private Label label3;
    }
}
