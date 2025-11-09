namespace PdfMerger
{
    partial class MetadataEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetadataEditor));
            buttonSave = new Button();
            buttonCancel = new Button();
            textBoxTitel = new TextBox();
            textBoxAuthor = new TextBox();
            textBoxSubject = new TextBox();
            textBoxCreator = new TextBox();
            flowLayoutPanelTitel = new FlowLayoutPanel();
            lvKeywords = new ListView();
            columnHeader2 = new ColumnHeader();
            lvKeywordsFromDocs = new ListView();
            columnHeader1 = new ColumnHeader();
            buttonLeft = new Button();
            buttonRight = new Button();
            flowLayoutPanelAuthor = new FlowLayoutPanel();
            flowLayoutPanelCreator = new FlowLayoutPanel();
            flowLayoutPanelSubject = new FlowLayoutPanel();
            groupBoxTitle = new GroupBox();
            groupBoxAuthor = new GroupBox();
            groupBoxSubject = new GroupBox();
            groupBoxCreator = new GroupBox();
            groupBoxKeywords = new GroupBox();
            buttonAddKeyword = new Button();
            tbNewKeyword = new TextBox();
            labelAddNewKeyword = new Label();
            groupBoxTitle.SuspendLayout();
            groupBoxAuthor.SuspendLayout();
            groupBoxSubject.SuspendLayout();
            groupBoxCreator.SuspendLayout();
            groupBoxKeywords.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(545, 636);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(203, 22);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save and Close";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(407, 636);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(132, 22);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBoxTitel
            // 
            textBoxTitel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTitel.Location = new Point(7, 20);
            textBoxTitel.Margin = new Padding(3, 2, 3, 2);
            textBoxTitel.Name = "textBoxTitel";
            textBoxTitel.Size = new Size(728, 23);
            textBoxTitel.TabIndex = 3;
            // 
            // textBoxAuthor
            // 
            textBoxAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAuthor.Location = new Point(6, 21);
            textBoxAuthor.Margin = new Padding(3, 2, 3, 2);
            textBoxAuthor.Name = "textBoxAuthor";
            textBoxAuthor.Size = new Size(727, 23);
            textBoxAuthor.TabIndex = 5;
            // 
            // textBoxSubject
            // 
            textBoxSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSubject.Location = new Point(6, 21);
            textBoxSubject.Margin = new Padding(3, 2, 3, 2);
            textBoxSubject.Name = "textBoxSubject";
            textBoxSubject.Size = new Size(727, 23);
            textBoxSubject.TabIndex = 7;
            // 
            // textBoxCreator
            // 
            textBoxCreator.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCreator.Location = new Point(6, 21);
            textBoxCreator.Margin = new Padding(3, 2, 3, 2);
            textBoxCreator.Name = "textBoxCreator";
            textBoxCreator.Size = new Size(726, 23);
            textBoxCreator.TabIndex = 9;
            // 
            // flowLayoutPanelTitel
            // 
            flowLayoutPanelTitel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelTitel.AutoScroll = true;
            flowLayoutPanelTitel.Location = new Point(7, 44);
            flowLayoutPanelTitel.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanelTitel.Name = "flowLayoutPanelTitel";
            flowLayoutPanelTitel.Size = new Size(727, 40);
            flowLayoutPanelTitel.TabIndex = 11;
            // 
            // lvKeywords
            // 
            lvKeywords.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lvKeywords.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            lvKeywords.FullRowSelect = true;
            lvKeywords.GridLines = true;
            lvKeywords.Location = new Point(6, 21);
            lvKeywords.Margin = new Padding(3, 2, 3, 2);
            lvKeywords.Name = "lvKeywords";
            lvKeywords.Size = new Size(200, 176);
            lvKeywords.TabIndex = 12;
            lvKeywords.UseCompatibleStateImageBehavior = false;
            lvKeywords.View = View.Details;
            lvKeywords.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Keyword";
            columnHeader2.Width = 195;
            // 
            // lvKeywordsFromDocs
            // 
            lvKeywordsFromDocs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lvKeywordsFromDocs.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            lvKeywordsFromDocs.FullRowSelect = true;
            lvKeywordsFromDocs.GridLines = true;
            lvKeywordsFromDocs.Location = new Point(248, 21);
            lvKeywordsFromDocs.Margin = new Padding(3, 2, 3, 2);
            lvKeywordsFromDocs.Name = "lvKeywordsFromDocs";
            lvKeywordsFromDocs.Size = new Size(200, 176);
            lvKeywordsFromDocs.TabIndex = 13;
            lvKeywordsFromDocs.UseCompatibleStateImageBehavior = false;
            lvKeywordsFromDocs.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Unused keywords";
            columnHeader1.Width = 195;
            // 
            // buttonLeft
            // 
            buttonLeft.Image = Properties.Resources.arrow_left;
            buttonLeft.Location = new Point(212, 21);
            buttonLeft.Margin = new Padding(3, 2, 3, 2);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(30, 30);
            buttonLeft.TabIndex = 14;
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += buttonLeft_Click;
            // 
            // buttonRight
            // 
            buttonRight.Image = Properties.Resources.arrow_right;
            buttonRight.Location = new Point(212, 55);
            buttonRight.Margin = new Padding(3, 2, 3, 2);
            buttonRight.Name = "buttonRight";
            buttonRight.Size = new Size(30, 30);
            buttonRight.TabIndex = 15;
            buttonRight.UseVisualStyleBackColor = true;
            buttonRight.Click += buttonRight_Click;
            // 
            // flowLayoutPanelAuthor
            // 
            flowLayoutPanelAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelAuthor.AutoScroll = true;
            flowLayoutPanelAuthor.Location = new Point(6, 48);
            flowLayoutPanelAuthor.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanelAuthor.Name = "flowLayoutPanelAuthor";
            flowLayoutPanelAuthor.Size = new Size(727, 40);
            flowLayoutPanelAuthor.TabIndex = 12;
            // 
            // flowLayoutPanelCreator
            // 
            flowLayoutPanelCreator.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelCreator.AutoScroll = true;
            flowLayoutPanelCreator.Location = new Point(6, 48);
            flowLayoutPanelCreator.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanelCreator.Name = "flowLayoutPanelCreator";
            flowLayoutPanelCreator.Size = new Size(726, 40);
            flowLayoutPanelCreator.TabIndex = 13;
            // 
            // flowLayoutPanelSubject
            // 
            flowLayoutPanelSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelSubject.AutoScroll = true;
            flowLayoutPanelSubject.Location = new Point(6, 48);
            flowLayoutPanelSubject.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanelSubject.Name = "flowLayoutPanelSubject";
            flowLayoutPanelSubject.Size = new Size(726, 40);
            flowLayoutPanelSubject.TabIndex = 14;
            // 
            // groupBoxTitle
            // 
            groupBoxTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxTitle.Controls.Add(textBoxTitel);
            groupBoxTitle.Controls.Add(flowLayoutPanelTitel);
            groupBoxTitle.Location = new Point(9, 9);
            groupBoxTitle.Margin = new Padding(3, 2, 3, 2);
            groupBoxTitle.Name = "groupBoxTitle";
            groupBoxTitle.Padding = new Padding(3, 2, 3, 2);
            groupBoxTitle.Size = new Size(740, 91);
            groupBoxTitle.TabIndex = 16;
            groupBoxTitle.TabStop = false;
            groupBoxTitle.Text = "Titel";
            // 
            // groupBoxAuthor
            // 
            groupBoxAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxAuthor.Controls.Add(textBoxAuthor);
            groupBoxAuthor.Controls.Add(flowLayoutPanelAuthor);
            groupBoxAuthor.Location = new Point(10, 105);
            groupBoxAuthor.Name = "groupBoxAuthor";
            groupBoxAuthor.Size = new Size(739, 99);
            groupBoxAuthor.TabIndex = 17;
            groupBoxAuthor.TabStop = false;
            groupBoxAuthor.Text = "Author";
            // 
            // groupBoxSubject
            // 
            groupBoxSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSubject.Controls.Add(textBoxSubject);
            groupBoxSubject.Controls.Add(flowLayoutPanelSubject);
            groupBoxSubject.Location = new Point(10, 210);
            groupBoxSubject.Name = "groupBoxSubject";
            groupBoxSubject.Size = new Size(739, 100);
            groupBoxSubject.TabIndex = 18;
            groupBoxSubject.TabStop = false;
            groupBoxSubject.Text = "Subject";
            // 
            // groupBoxCreator
            // 
            groupBoxCreator.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxCreator.Controls.Add(textBoxCreator);
            groupBoxCreator.Controls.Add(flowLayoutPanelCreator);
            groupBoxCreator.Location = new Point(10, 316);
            groupBoxCreator.Name = "groupBoxCreator";
            groupBoxCreator.Size = new Size(739, 103);
            groupBoxCreator.TabIndex = 19;
            groupBoxCreator.TabStop = false;
            groupBoxCreator.Text = "Creator";
            // 
            // groupBoxKeywords
            // 
            groupBoxKeywords.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxKeywords.Controls.Add(buttonAddKeyword);
            groupBoxKeywords.Controls.Add(tbNewKeyword);
            groupBoxKeywords.Controls.Add(labelAddNewKeyword);
            groupBoxKeywords.Controls.Add(lvKeywords);
            groupBoxKeywords.Controls.Add(lvKeywordsFromDocs);
            groupBoxKeywords.Controls.Add(buttonLeft);
            groupBoxKeywords.Controls.Add(buttonRight);
            groupBoxKeywords.Location = new Point(10, 425);
            groupBoxKeywords.Name = "groupBoxKeywords";
            groupBoxKeywords.Size = new Size(739, 206);
            groupBoxKeywords.TabIndex = 20;
            groupBoxKeywords.TabStop = false;
            groupBoxKeywords.Text = "Keywords";
            // 
            // buttonAddKeyword
            // 
            buttonAddKeyword.Location = new Point(472, 74);
            buttonAddKeyword.Name = "buttonAddKeyword";
            buttonAddKeyword.Size = new Size(260, 23);
            buttonAddKeyword.TabIndex = 18;
            buttonAddKeyword.Text = "Add keyword";
            buttonAddKeyword.UseVisualStyleBackColor = true;
            buttonAddKeyword.Click += buttonAddKeyword_Click;
            // 
            // tbNewKeyword
            // 
            tbNewKeyword.Location = new Point(472, 45);
            tbNewKeyword.Name = "tbNewKeyword";
            tbNewKeyword.Size = new Size(260, 23);
            tbNewKeyword.TabIndex = 17;
            // 
            // labelAddNewKeyword
            // 
            labelAddNewKeyword.AutoSize = true;
            labelAddNewKeyword.Location = new Point(472, 27);
            labelAddNewKeyword.Name = "labelAddNewKeyword";
            labelAddNewKeyword.Size = new Size(105, 15);
            labelAddNewKeyword.TabIndex = 16;
            labelAddNewKeyword.Text = "Add new keyword:";
            // 
            // MetadataEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 667);
            Controls.Add(groupBoxKeywords);
            Controls.Add(groupBoxCreator);
            Controls.Add(groupBoxSubject);
            Controls.Add(groupBoxAuthor);
            Controls.Add(groupBoxTitle);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "MetadataEditor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PDF metadata editor";
            groupBoxTitle.ResumeLayout(false);
            groupBoxTitle.PerformLayout();
            groupBoxAuthor.ResumeLayout(false);
            groupBoxAuthor.PerformLayout();
            groupBoxSubject.ResumeLayout(false);
            groupBoxSubject.PerformLayout();
            groupBoxCreator.ResumeLayout(false);
            groupBoxCreator.PerformLayout();
            groupBoxKeywords.ResumeLayout(false);
            groupBoxKeywords.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSave;
        private Button buttonCancel;
        private TextBox textBoxTitel;
        private TextBox textBoxAuthor;
        private TextBox textBoxSubject;
        private TextBox textBoxCreator;
        private FlowLayoutPanel flowLayoutPanelTitel;
        private ListView lvKeywords;
        private ListView lvKeywordsFromDocs;
        private Button buttonLeft;
        private Button buttonRight;
        private FlowLayoutPanel flowLayoutPanelAuthor;
        private FlowLayoutPanel flowLayoutPanelCreator;
        private FlowLayoutPanel flowLayoutPanelSubject;
        private GroupBox groupBoxTitle;
        private GroupBox groupBoxAuthor;
        private GroupBox groupBoxSubject;
        private GroupBox groupBoxCreator;
        private GroupBox groupBoxKeywords;
        private ColumnHeader columnHeader2;
        internal ColumnHeader columnHeader1;
        private Button buttonAddKeyword;
        private TextBox tbNewKeyword;
        private Label labelAddNewKeyword;
    }
}