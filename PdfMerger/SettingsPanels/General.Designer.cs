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
            labelCompressionLevel = new Label();
            comboBoxCompressionLevel = new ComboBox();
            labelColorMode = new Label();
            cbColorMode = new ComboBox();
            labelColorModeRestart = new Label();
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
            // labelCompressionLevel
            // 
            labelCompressionLevel.AutoSize = true;
            labelCompressionLevel.Location = new Point(5, 119);
            labelCompressionLevel.Name = "labelCompressionLevel";
            labelCompressionLevel.Size = new Size(270, 15);
            labelCompressionLevel.TabIndex = 5;
            labelCompressionLevel.Text = "Compression level when saving project as bundle:";
            // 
            // comboBoxCompressionLevel
            // 
            comboBoxCompressionLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCompressionLevel.FormattingEnabled = true;
            comboBoxCompressionLevel.Location = new Point(53, 137);
            comboBoxCompressionLevel.Name = "comboBoxCompressionLevel";
            comboBoxCompressionLevel.Size = new Size(222, 23);
            comboBoxCompressionLevel.TabIndex = 6;
            // 
            // labelColorMode
            // 
            labelColorMode.AutoSize = true;
            labelColorMode.Location = new Point(5, 176);
            labelColorMode.Name = "labelColorMode";
            labelColorMode.Size = new Size(211, 15);
            labelColorMode.TabIndex = 7;
            labelColorMode.Text = "Application color mode (experimental)";
            // 
            // cbColorMode
            // 
            cbColorMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColorMode.FormattingEnabled = true;
            cbColorMode.Location = new Point(53, 194);
            cbColorMode.Name = "cbColorMode";
            cbColorMode.Size = new Size(222, 23);
            cbColorMode.TabIndex = 8;
            // 
            // labelColorModeRestart
            // 
            labelColorModeRestart.AutoSize = true;
            labelColorModeRestart.Location = new Point(53, 220);
            labelColorModeRestart.Name = "labelColorModeRestart";
            labelColorModeRestart.Size = new Size(212, 15);
            labelColorModeRestart.TabIndex = 9;
            labelColorModeRestart.Text = "(changes apply after a program restart)";
            // 
            // General
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelColorModeRestart);
            Controls.Add(cbColorMode);
            Controls.Add(labelColorMode);
            Controls.Add(comboBoxCompressionLevel);
            Controls.Add(labelCompressionLevel);
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
        private Label labelCompressionLevel;
        private ComboBox comboBoxCompressionLevel;
        private Label labelColorMode;
        private ComboBox cbColorMode;
        private Label labelColorModeRestart;
    }
}
