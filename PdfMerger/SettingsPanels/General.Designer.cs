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
            SuspendLayout();
            // 
            // checkBoxShowFilenameExtension
            // 
            checkBoxShowFilenameExtension.AutoSize = true;
            checkBoxShowFilenameExtension.Location = new Point(3, 16);
            checkBoxShowFilenameExtension.Margin = new Padding(3, 4, 3, 4);
            checkBoxShowFilenameExtension.Name = "checkBoxShowFilenameExtension";
            checkBoxShowFilenameExtension.Size = new Size(281, 24);
            checkBoxShowFilenameExtension.TabIndex = 1;
            checkBoxShowFilenameExtension.Text = "Show filename extension in page tiles";
            checkBoxShowFilenameExtension.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveAsBundle
            // 
            checkBoxSaveAsBundle.AutoSize = true;
            checkBoxSaveAsBundle.Location = new Point(3, 49);
            checkBoxSaveAsBundle.Margin = new Padding(3, 4, 3, 4);
            checkBoxSaveAsBundle.Name = "checkBoxSaveAsBundle";
            checkBoxSaveAsBundle.Size = new Size(416, 24);
            checkBoxSaveAsBundle.TabIndex = 2;
            checkBoxSaveAsBundle.Text = "Save project as Bundle (inkl. all pdf files in the project file)";
            checkBoxSaveAsBundle.UseVisualStyleBackColor = true;
            // 
            // checkBoxLoadEveryPage
            // 
            checkBoxLoadEveryPage.AutoSize = true;
            checkBoxLoadEveryPage.Location = new Point(3, 83);
            checkBoxLoadEveryPage.Margin = new Padding(3, 4, 3, 4);
            checkBoxLoadEveryPage.Name = "checkBoxLoadEveryPage";
            checkBoxLoadEveryPage.Size = new Size(295, 24);
            checkBoxLoadEveryPage.TabIndex = 3;
            checkBoxLoadEveryPage.Text = "Load every page when adding a pdf file";
            checkBoxLoadEveryPage.UseVisualStyleBackColor = true;
            // 
            // checkBoxClearProducer
            // 
            checkBoxClearProducer.AutoSize = true;
            checkBoxClearProducer.Location = new Point(3, 115);
            checkBoxClearProducer.Margin = new Padding(3, 4, 3, 4);
            checkBoxClearProducer.Name = "checkBoxClearProducer";
            checkBoxClearProducer.Size = new Size(289, 24);
            checkBoxClearProducer.TabIndex = 4;
            checkBoxClearProducer.Text = "Clear the Producer field on pdf export?";
            checkBoxClearProducer.UseVisualStyleBackColor = true;
            // 
            // General
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkBoxClearProducer);
            Controls.Add(checkBoxLoadEveryPage);
            Controls.Add(checkBoxSaveAsBundle);
            Controls.Add(checkBoxShowFilenameExtension);
            Margin = new Padding(3, 4, 3, 4);
            Name = "General";
            Size = new Size(838, 724);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBoxShowFilenameExtension;
        private CheckBox checkBoxSaveAsBundle;
        private CheckBox checkBoxLoadEveryPage;
        private CheckBox checkBoxClearProducer;
    }
}
