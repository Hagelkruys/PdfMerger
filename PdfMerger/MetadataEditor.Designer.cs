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
            label1 = new Label();
            textBoxTitel = new TextBox();
            textBoxAuthor = new TextBox();
            label2 = new Label();
            textBoxSubject = new TextBox();
            labelSubject = new Label();
            label3 = new Label();
            textBoxCreator = new TextBox();
            label4 = new Label();
            flowLayoutPanelTitel = new FlowLayoutPanel();
            listView1 = new ListView();
            listView2 = new ListView();
            button1 = new Button();
            button2 = new Button();
            flowLayoutPanelAuthor = new FlowLayoutPanel();
            flowLayoutPanelCreator = new FlowLayoutPanel();
            flowLayoutPanelSubject = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(629, 583);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(159, 29);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save and Close";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(529, 583);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 2;
            label1.Text = "Titel:";
            // 
            // textBoxTitel
            // 
            textBoxTitel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTitel.Location = new Point(99, 12);
            textBoxTitel.Name = "textBoxTitel";
            textBoxTitel.Size = new Size(689, 27);
            textBoxTitel.TabIndex = 3;
            // 
            // textBoxAuthor
            // 
            textBoxAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAuthor.Location = new Point(99, 90);
            textBoxAuthor.Name = "textBoxAuthor";
            textBoxAuthor.Size = new Size(689, 27);
            textBoxAuthor.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 93);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 4;
            label2.Text = "Author:";
            // 
            // textBoxSubject
            // 
            textBoxSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSubject.Location = new Point(99, 184);
            textBoxSubject.Name = "textBoxSubject";
            textBoxSubject.Size = new Size(689, 27);
            textBoxSubject.TabIndex = 7;
            // 
            // labelSubject
            // 
            labelSubject.AutoSize = true;
            labelSubject.Location = new Point(12, 187);
            labelSubject.Name = "labelSubject";
            labelSubject.Size = new Size(61, 20);
            labelSubject.TabIndex = 6;
            labelSubject.Text = "Subject:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 265);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 8;
            label3.Text = "Creator:";
            // 
            // textBoxCreator
            // 
            textBoxCreator.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCreator.Location = new Point(99, 262);
            textBoxCreator.Name = "textBoxCreator";
            textBoxCreator.Size = new Size(689, 27);
            textBoxCreator.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 329);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 10;
            label4.Text = "Keywords:";
            // 
            // flowLayoutPanelTitel
            // 
            flowLayoutPanelTitel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelTitel.AutoScroll = true;
            flowLayoutPanelTitel.Location = new Point(99, 45);
            flowLayoutPanelTitel.Name = "flowLayoutPanelTitel";
            flowLayoutPanelTitel.Size = new Size(689, 30);
            flowLayoutPanelTitel.TabIndex = 11;
            // 
            // listView1
            // 
            listView1.Location = new Point(94, 329);
            listView1.Name = "listView1";
            listView1.Size = new Size(208, 224);
            listView1.TabIndex = 12;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            listView2.Location = new Point(415, 329);
            listView2.Name = "listView2";
            listView2.Size = new Size(208, 224);
            listView2.TabIndex = 13;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            button1.Location = new Point(308, 329);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 14;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(308, 364);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 15;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelAuthor
            // 
            flowLayoutPanelAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelAuthor.AutoScroll = true;
            flowLayoutPanelAuthor.Location = new Point(99, 123);
            flowLayoutPanelAuthor.Name = "flowLayoutPanelAuthor";
            flowLayoutPanelAuthor.Size = new Size(689, 30);
            flowLayoutPanelAuthor.TabIndex = 12;
            // 
            // flowLayoutPanelCreator
            // 
            flowLayoutPanelCreator.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelCreator.AutoScroll = true;
            flowLayoutPanelCreator.Location = new Point(99, 295);
            flowLayoutPanelCreator.Name = "flowLayoutPanelCreator";
            flowLayoutPanelCreator.Size = new Size(689, 30);
            flowLayoutPanelCreator.TabIndex = 13;
            // 
            // flowLayoutPanelSubject
            // 
            flowLayoutPanelSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelSubject.AutoScroll = true;
            flowLayoutPanelSubject.Location = new Point(99, 217);
            flowLayoutPanelSubject.Name = "flowLayoutPanelSubject";
            flowLayoutPanelSubject.Size = new Size(689, 30);
            flowLayoutPanelSubject.TabIndex = 14;
            // 
            // MetadataEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 624);
            Controls.Add(flowLayoutPanelSubject);
            Controls.Add(flowLayoutPanelCreator);
            Controls.Add(flowLayoutPanelAuthor);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(flowLayoutPanelTitel);
            Controls.Add(label4);
            Controls.Add(textBoxCreator);
            Controls.Add(label3);
            Controls.Add(textBoxSubject);
            Controls.Add(labelSubject);
            Controls.Add(textBoxAuthor);
            Controls.Add(label2);
            Controls.Add(textBoxTitel);
            Controls.Add(label1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MetadataEditor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PDF metadata editor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSave;
        private Button buttonCancel;
        private Label label1;
        private TextBox textBoxTitel;
        private TextBox textBoxAuthor;
        private Label label2;
        private TextBox textBoxSubject;
        private Label labelSubject;
        private Label label3;
        private TextBox textBoxCreator;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanelTitel;
        private ListView listView1;
        private ListView listView2;
        private Button button1;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanelAuthor;
        private FlowLayoutPanel flowLayoutPanelCreator;
        private FlowLayoutPanel flowLayoutPanelSubject;
    }
}