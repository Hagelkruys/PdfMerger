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
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(629, 409);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(159, 29);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save and Close";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(529, 409);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // MetadataEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MetadataEditor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PDF metadata editor";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSave;
        private Button buttonCancel;
    }
}