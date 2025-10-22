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
            listView1 = new ListView();
            listView2 = new ListView();
            button1 = new Button();
            button2 = new Button();
            flowLayoutPanelAuthor = new FlowLayoutPanel();
            flowLayoutPanelCreator = new FlowLayoutPanel();
            flowLayoutPanelSubject = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(609, 636);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(139, 22);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save and Close";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(522, 636);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(82, 22);
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
            // listView1
            // 
            listView1.GridLines = true;
            listView1.Location = new Point(6, 21);
            listView1.Margin = new Padding(3, 2, 3, 2);
            listView1.Name = "listView1";
            listView1.Size = new Size(184, 149);
            listView1.TabIndex = 12;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // listView2
            // 
            listView2.AccessibleRole = AccessibleRole.MenuBar;
            listView2.GridLines = true;
            listView2.Location = new Point(307, 21);
            listView2.Margin = new Padding(3, 2, 3, 2);
            listView2.Name = "listView2";
            listView2.Size = new Size(182, 149);
            listView2.TabIndex = 13;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.List;
            // 
            // button1
            // 
            button1.Location = new Point(196, 21);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 14;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(196, 47);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(82, 22);
            button2.TabIndex = 15;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
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
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(textBoxTitel);
            groupBox1.Controls.Add(flowLayoutPanelTitel);
            groupBox1.Location = new Point(9, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(740, 91);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Titel";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(textBoxAuthor);
            groupBox2.Controls.Add(flowLayoutPanelAuthor);
            groupBox2.Location = new Point(10, 105);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(739, 99);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Author";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxSubject);
            groupBox3.Controls.Add(flowLayoutPanelSubject);
            groupBox3.Location = new Point(10, 210);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(739, 100);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            groupBox3.Text = "Subject";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBoxCreator);
            groupBox4.Controls.Add(flowLayoutPanelCreator);
            groupBox4.Location = new Point(10, 316);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(739, 103);
            groupBox4.TabIndex = 19;
            groupBox4.TabStop = false;
            groupBox4.Text = "Creator";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(listView1);
            groupBox5.Controls.Add(listView2);
            groupBox5.Controls.Add(button1);
            groupBox5.Controls.Add(button2);
            groupBox5.Location = new Point(10, 425);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(739, 179);
            groupBox5.TabIndex = 20;
            groupBox5.TabStop = false;
            groupBox5.Text = "Keywords";
            // 
            // MetadataEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 667);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "MetadataEditor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PDF metadata editor";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
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
        private ListView listView1;
        private ListView listView2;
        private Button button1;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanelAuthor;
        private FlowLayoutPanel flowLayoutPanelCreator;
        private FlowLayoutPanel flowLayoutPanelSubject;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
    }
}