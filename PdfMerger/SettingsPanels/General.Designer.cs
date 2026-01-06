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
            checkBoxLoadEveryPage = new CheckBox();
            labelCompressionLevel = new Label();
            comboBoxCompressionLevel = new ComboBox();
            labelColorMode = new Label();
            cbColorMode = new ComboBox();
            labelColorModeRestart = new Label();
            labelLanguage = new Label();
            comboBoxLanguage = new ComboBox();
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
            // checkBoxLoadEveryPage
            // 
            checkBoxLoadEveryPage.AutoSize = true;
            checkBoxLoadEveryPage.Location = new Point(3, 37);
            checkBoxLoadEveryPage.Name = "checkBoxLoadEveryPage";
            checkBoxLoadEveryPage.Size = new Size(233, 19);
            checkBoxLoadEveryPage.TabIndex = 3;
            checkBoxLoadEveryPage.Text = "Load every page when adding a pdf file";
            checkBoxLoadEveryPage.UseVisualStyleBackColor = true;
            // 
            // labelCompressionLevel
            // 
            labelCompressionLevel.AutoSize = true;
            labelCompressionLevel.Location = new Point(5, 67);
            labelCompressionLevel.Name = "labelCompressionLevel";
            labelCompressionLevel.Size = new Size(270, 15);
            labelCompressionLevel.TabIndex = 5;
            labelCompressionLevel.Text = "Compression level when saving project as bundle:";
            // 
            // comboBoxCompressionLevel
            // 
            comboBoxCompressionLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCompressionLevel.FormattingEnabled = true;
            comboBoxCompressionLevel.Location = new Point(53, 85);
            comboBoxCompressionLevel.Name = "comboBoxCompressionLevel";
            comboBoxCompressionLevel.Size = new Size(222, 23);
            comboBoxCompressionLevel.TabIndex = 6;
            // 
            // labelColorMode
            // 
            labelColorMode.AutoSize = true;
            labelColorMode.Location = new Point(5, 124);
            labelColorMode.Name = "labelColorMode";
            labelColorMode.Size = new Size(211, 15);
            labelColorMode.TabIndex = 7;
            labelColorMode.Text = "Application color mode (experimental)";
            // 
            // cbColorMode
            // 
            cbColorMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColorMode.FormattingEnabled = true;
            cbColorMode.Location = new Point(53, 142);
            cbColorMode.Name = "cbColorMode";
            cbColorMode.Size = new Size(222, 23);
            cbColorMode.TabIndex = 8;
            // 
            // labelColorModeRestart
            // 
            labelColorModeRestart.AutoSize = true;
            labelColorModeRestart.Location = new Point(53, 168);
            labelColorModeRestart.Name = "labelColorModeRestart";
            labelColorModeRestart.Size = new Size(212, 15);
            labelColorModeRestart.TabIndex = 9;
            labelColorModeRestart.Text = "(changes apply after a program restart)";
            // 
            // labelLanguage
            // 
            labelLanguage.AutoSize = true;
            labelLanguage.Location = new Point(5, 202);
            labelLanguage.Name = "labelLanguage";
            labelLanguage.Size = new Size(59, 15);
            labelLanguage.TabIndex = 10;
            labelLanguage.Text = "Language";
            // 
            // comboBoxLanguage
            // 
            comboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLanguage.FormattingEnabled = true;
            comboBoxLanguage.Location = new Point(53, 220);
            comboBoxLanguage.Name = "comboBoxLanguage";
            comboBoxLanguage.Size = new Size(222, 23);
            comboBoxLanguage.TabIndex = 11;
            // 
            // General
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBoxLanguage);
            Controls.Add(labelLanguage);
            Controls.Add(labelColorModeRestart);
            Controls.Add(cbColorMode);
            Controls.Add(labelColorMode);
            Controls.Add(comboBoxCompressionLevel);
            Controls.Add(labelCompressionLevel);
            Controls.Add(checkBoxLoadEveryPage);
            Controls.Add(checkBoxShowFilenameExtension);
            Name = "General";
            Size = new Size(733, 543);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBoxShowFilenameExtension;
        private CheckBox checkBoxLoadEveryPage;
        private Label labelCompressionLevel;
        private ComboBox comboBoxCompressionLevel;
        private Label labelColorMode;
        private ComboBox cbColorMode;
        private Label labelColorModeRestart;
        private Label labelLanguage;
        private ComboBox comboBoxLanguage;
    }
}
