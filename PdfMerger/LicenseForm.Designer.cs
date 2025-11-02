namespace PdfMerger
{
    partial class LicenseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseForm));
            splitContainer1 = new SplitContainer();
            panelContent = new Panel();
            tbLicense = new TextBox();
            buttonClose = new Button();
            panel1 = new Panel();
            listOfLicenses = new ListBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelContent.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelContent);
            splitContainer1.Size = new Size(762, 440);
            splitContainer1.SplitterDistance = 206;
            splitContainer1.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(tbLicense);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(5);
            panelContent.Size = new Size(552, 440);
            panelContent.TabIndex = 0;
            // 
            // tbLicense
            // 
            tbLicense.Dock = DockStyle.Fill;
            tbLicense.Location = new Point(5, 5);
            tbLicense.Multiline = true;
            tbLicense.Name = "tbLicense";
            tbLicense.ReadOnly = true;
            tbLicense.ScrollBars = ScrollBars.Both;
            tbLicense.Size = new Size(542, 430);
            tbLicense.TabIndex = 0;
            tbLicense.WordWrap = false;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClose.Location = new Point(675, 448);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 3;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonCancel_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(listOfLicenses);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(206, 440);
            panel1.TabIndex = 1;
            // 
            // listOfLicenses
            // 
            listOfLicenses.BorderStyle = BorderStyle.None;
            listOfLicenses.Dock = DockStyle.Fill;
            listOfLicenses.FormattingEnabled = true;
            listOfLicenses.Location = new Point(5, 5);
            listOfLicenses.Name = "listOfLicenses";
            listOfLicenses.Size = new Size(196, 430);
            listOfLicenses.TabIndex = 1;
            // 
            // LicenseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 483);
            Controls.Add(buttonClose);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LicenseForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Licenses";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panelContent;
        private Button buttonClose;
        private TextBox tbLicense;
        private Panel panel1;
        private ListBox listOfLicenses;
    }
}