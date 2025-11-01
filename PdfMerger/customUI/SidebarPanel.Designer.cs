namespace PdfMerger.customUI
{
    partial class SidebarPanel
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
            layout = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // layout
            // 
            layout.AutoScroll = true;
            layout.Dock = DockStyle.Fill;
            layout.FlowDirection = FlowDirection.TopDown;
            layout.Location = new Point(0, 0);
            layout.Margin = new Padding(0);
            layout.Name = "layout";
            layout.Size = new Size(639, 544);
            layout.TabIndex = 0;
            layout.WrapContents = false;
            // 
            // SidebarPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layout);
            Name = "SidebarPanel";
            Size = new Size(639, 544);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel layout;
    }
}
