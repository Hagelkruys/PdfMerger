namespace PdfMerger
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            splitContainer1 = new SplitContainer();
            listCategories = new ListBox();
            panelContent = new Panel();
            buttonSave = new Button();
            buttonCancel = new Button();
            buttonSaveAndClose = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listCategories);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelContent);
            splitContainer1.Size = new Size(800, 459);
            splitContainer1.SplitterDistance = 217;
            splitContainer1.TabIndex = 0;
            // 
            // listCategories
            // 
            listCategories.BorderStyle = BorderStyle.None;
            listCategories.Dock = DockStyle.Fill;
            listCategories.FormattingEnabled = true;
            listCategories.Location = new Point(0, 0);
            listCategories.Name = "listCategories";
            listCategories.Size = new Size(217, 459);
            listCategories.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(20);
            panelContent.Size = new Size(579, 459);
            panelContent.TabIndex = 0;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(597, 465);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(516, 465);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSaveAndClose
            // 
            buttonSaveAndClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSaveAndClose.Location = new Point(678, 466);
            buttonSaveAndClose.Name = "buttonSaveAndClose";
            buttonSaveAndClose.Size = new Size(110, 23);
            buttonSaveAndClose.TabIndex = 3;
            buttonSaveAndClose.Text = "Save and Close";
            buttonSaveAndClose.UseVisualStyleBackColor = true;
            buttonSaveAndClose.Click += buttonSaveAndClose_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 491);
            Controls.Add(buttonSaveAndClose);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ListBox listCategories;
        private Panel panelContent;
        private Button buttonSave;
        private Button buttonCancel;
        private Button buttonSaveAndClose;
    }
}