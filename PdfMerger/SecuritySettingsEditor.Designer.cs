namespace PdfMerger
{
    partial class SecuritySettingsEditor
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(SecuritySettingsEditor));
            cbPermitPrinting = new CheckBox();
            cbPermitFullQualityPrint = new CheckBox();
            labelPermitFullQualityPrint = new Label();
            labelPermitPrinting = new Label();
            labelPermitModifyDocument = new Label();
            cbPermitModifyDocument = new CheckBox();
            labelPermitExtractContent = new Label();
            cbPermitExtractContent = new CheckBox();
            labelPermitAnnotations = new Label();
            cbPermitAnnotations = new CheckBox();
            labelPermitFormsFill = new Label();
            cbPermitFormsFill = new CheckBox();
            labelPermitAssembleDocument = new Label();
            cbPermitAssembleDocument = new CheckBox();
            buttonCancel = new Button();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // cbPermitPrinting
            // 
            cbPermitPrinting.AutoSize = true;
            cbPermitPrinting.Checked = true;
            cbPermitPrinting.CheckState = CheckState.Checked;
            cbPermitPrinting.Location = new Point(12, 12);
            cbPermitPrinting.Name = "cbPermitPrinting";
            cbPermitPrinting.Size = new Size(101, 19);
            cbPermitPrinting.TabIndex = 0;
            cbPermitPrinting.Text = "Allow printing";
            cbPermitPrinting.UseVisualStyleBackColor = true;
            // 
            // cbPermitFullQualityPrint
            // 
            cbPermitFullQualityPrint.AutoSize = true;
            cbPermitFullQualityPrint.Checked = true;
            cbPermitFullQualityPrint.CheckState = CheckState.Checked;
            cbPermitFullQualityPrint.Location = new Point(12, 70);
            cbPermitFullQualityPrint.Name = "cbPermitFullQualityPrint";
            cbPermitFullQualityPrint.Size = new Size(180, 19);
            cbPermitFullQualityPrint.TabIndex = 1;
            cbPermitFullQualityPrint.Text = "Allow printing in high quality";
            cbPermitFullQualityPrint.UseVisualStyleBackColor = true;
            // 
            // labelPermitFullQualityPrint
            // 
            labelPermitFullQualityPrint.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelPermitFullQualityPrint.AutoEllipsis = true;
            labelPermitFullQualityPrint.Location = new Point(30, 92);
            labelPermitFullQualityPrint.Name = "labelPermitFullQualityPrint";
            labelPermitFullQualityPrint.Size = new Size(663, 44);
            labelPermitFullQualityPrint.TabIndex = 2;
            labelPermitFullQualityPrint.Text = "Permits to print in high quality. insert, rotate, or delete pages and create bookmarks or thumbnail images even if document modification is not set.";
            // 
            // labelPermitPrinting
            // 
            labelPermitPrinting.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelPermitPrinting.AutoEllipsis = true;
            labelPermitPrinting.Location = new Point(30, 34);
            labelPermitPrinting.Name = "labelPermitPrinting";
            labelPermitPrinting.Size = new Size(663, 33);
            labelPermitPrinting.TabIndex = 3;
            labelPermitPrinting.Text = "Permits printing the document. Should be used in conjunction with \"Allow priting in high quality\"";
            // 
            // labelPermitModifyDocument
            // 
            labelPermitModifyDocument.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelPermitModifyDocument.AutoEllipsis = true;
            labelPermitModifyDocument.Location = new Point(30, 161);
            labelPermitModifyDocument.Name = "labelPermitModifyDocument";
            labelPermitModifyDocument.Size = new Size(663, 44);
            labelPermitModifyDocument.TabIndex = 5;
            labelPermitModifyDocument.Text = "Permits modifying the document.";
            // 
            // cbPermitModifyDocument
            // 
            cbPermitModifyDocument.AutoSize = true;
            cbPermitModifyDocument.Checked = true;
            cbPermitModifyDocument.CheckState = CheckState.Checked;
            cbPermitModifyDocument.Location = new Point(12, 139);
            cbPermitModifyDocument.Name = "cbPermitModifyDocument";
            cbPermitModifyDocument.Size = new Size(185, 19);
            cbPermitModifyDocument.TabIndex = 4;
            cbPermitModifyDocument.Text = "Allow document modification";
            cbPermitModifyDocument.UseVisualStyleBackColor = true;
            // 
            // labelPermitExtractContent
            // 
            labelPermitExtractContent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelPermitExtractContent.AutoEllipsis = true;
            labelPermitExtractContent.Location = new Point(30, 230);
            labelPermitExtractContent.Name = "labelPermitExtractContent";
            labelPermitExtractContent.Size = new Size(663, 44);
            labelPermitExtractContent.TabIndex = 7;
            labelPermitExtractContent.Text = "Permits content copying or extraction.";
            // 
            // cbPermitExtractContent
            // 
            cbPermitExtractContent.AutoSize = true;
            cbPermitExtractContent.Checked = true;
            cbPermitExtractContent.CheckState = CheckState.Checked;
            cbPermitExtractContent.Location = new Point(12, 208);
            cbPermitExtractContent.Name = "cbPermitExtractContent";
            cbPermitExtractContent.Size = new Size(155, 19);
            cbPermitExtractContent.TabIndex = 6;
            cbPermitExtractContent.Text = "Allow content extraction";
            cbPermitExtractContent.UseVisualStyleBackColor = true;
            // 
            // labelPermitAnnotations
            // 
            labelPermitAnnotations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelPermitAnnotations.AutoEllipsis = true;
            labelPermitAnnotations.Location = new Point(30, 299);
            labelPermitAnnotations.Name = "labelPermitAnnotations";
            labelPermitAnnotations.Size = new Size(663, 44);
            labelPermitAnnotations.TabIndex = 9;
            labelPermitAnnotations.Text = "Permits commenting the document.";
            // 
            // cbPermitAnnotations
            // 
            cbPermitAnnotations.AutoSize = true;
            cbPermitAnnotations.Checked = true;
            cbPermitAnnotations.CheckState = CheckState.Checked;
            cbPermitAnnotations.Location = new Point(12, 277);
            cbPermitAnnotations.Name = "cbPermitAnnotations";
            cbPermitAnnotations.Size = new Size(128, 19);
            cbPermitAnnotations.TabIndex = 8;
            cbPermitAnnotations.Text = "Allow commenting";
            cbPermitAnnotations.UseVisualStyleBackColor = true;
            // 
            // labelPermitFormsFill
            // 
            labelPermitFormsFill.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelPermitFormsFill.AutoEllipsis = true;
            labelPermitFormsFill.Location = new Point(30, 368);
            labelPermitFormsFill.Name = "labelPermitFormsFill";
            labelPermitFormsFill.Size = new Size(663, 44);
            labelPermitFormsFill.TabIndex = 11;
            labelPermitFormsFill.Text = "Permits filling of form fields.";
            // 
            // cbPermitFormsFill
            // 
            cbPermitFormsFill.AutoSize = true;
            cbPermitFormsFill.Checked = true;
            cbPermitFormsFill.CheckState = CheckState.Checked;
            cbPermitFormsFill.Location = new Point(12, 346);
            cbPermitFormsFill.Name = "cbPermitFormsFill";
            cbPermitFormsFill.Size = new Size(137, 19);
            cbPermitFormsFill.TabIndex = 10;
            cbPermitFormsFill.Text = "Allow filling of forms";
            cbPermitFormsFill.UseVisualStyleBackColor = true;
            // 
            // labelPermitAssembleDocument
            // 
            labelPermitAssembleDocument.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelPermitAssembleDocument.AutoEllipsis = true;
            labelPermitAssembleDocument.Location = new Point(30, 437);
            labelPermitAssembleDocument.Name = "labelPermitAssembleDocument";
            labelPermitAssembleDocument.Size = new Size(663, 44);
            labelPermitAssembleDocument.TabIndex = 13;
            labelPermitAssembleDocument.Text = "Permits to insert, rotate, or delete pages and create bookmarks or thumbnail images even if document modification is not set.";
            // 
            // cbPermitAssembleDocument
            // 
            cbPermitAssembleDocument.AutoSize = true;
            cbPermitAssembleDocument.Checked = true;
            cbPermitAssembleDocument.CheckState = CheckState.Checked;
            cbPermitAssembleDocument.Location = new Point(12, 415);
            cbPermitAssembleDocument.Name = "cbPermitAssembleDocument";
            cbPermitAssembleDocument.Size = new Size(211, 19);
            cbPermitAssembleDocument.TabIndex = 12;
            cbPermitAssembleDocument.Text = "Allow insert, rotate, delete of pages";
            cbPermitAssembleDocument.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(352, 527);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(132, 22);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(490, 527);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(203, 22);
            buttonSave.TabIndex = 14;
            buttonSave.Text = "Save and Close";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // SecuritySettingsEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 560);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(labelPermitAssembleDocument);
            Controls.Add(cbPermitAssembleDocument);
            Controls.Add(labelPermitFormsFill);
            Controls.Add(cbPermitFormsFill);
            Controls.Add(labelPermitAnnotations);
            Controls.Add(cbPermitAnnotations);
            Controls.Add(labelPermitExtractContent);
            Controls.Add(cbPermitExtractContent);
            Controls.Add(labelPermitModifyDocument);
            Controls.Add(cbPermitModifyDocument);
            Controls.Add(labelPermitPrinting);
            Controls.Add(labelPermitFullQualityPrint);
            Controls.Add(cbPermitFullQualityPrint);
            Controls.Add(cbPermitPrinting);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SecuritySettingsEditor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PDF security settings editor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbPermitPrinting;
        private CheckBox cbPermitFullQualityPrint;
        private Label labelPermitFullQualityPrint;
        private Label labelPermitPrinting;
        private Label labelPermitModifyDocument;
        private CheckBox cbPermitModifyDocument;
        private Label labelPermitExtractContent;
        private CheckBox cbPermitExtractContent;
        private Label labelPermitAnnotations;
        private CheckBox cbPermitAnnotations;
        private Label labelPermitFormsFill;
        private CheckBox cbPermitFormsFill;
        private Label labelPermitAssembleDocument;
        private CheckBox cbPermitAssembleDocument;
        private Button buttonCancel;
        private Button buttonSave;
    }
}