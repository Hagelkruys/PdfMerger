namespace PdfMerger;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        loadPDFFileToolStripMenuItem = new ToolStripMenuItem();
        saveMergedPDFToolStripMenuItem = new ToolStripMenuItem();
        removeSelectedPDFToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        closeToolStripMenuItem = new ToolStripMenuItem();
        splitContainer1 = new SplitContainer();
        mainPanel = new FlowLayoutPanel();
        groupBoxPreviewSize = new GroupBox();
        trackBarPreviewSize = new TrackBar();
        groupBoxAction = new GroupBox();
        buttonAddPdf = new Button();
        buttonRemovePdf = new Button();
        buttonSavePdf = new Button();
        menuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        groupBoxPreviewSize.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)trackBarPreviewSize).BeginInit();
        groupBoxAction.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1008, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadPDFFileToolStripMenuItem, saveMergedPDFToolStripMenuItem, removeSelectedPDFToolStripMenuItem, toolStripSeparator1, closeToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "File";
        // 
        // loadPDFFileToolStripMenuItem
        // 
        loadPDFFileToolStripMenuItem.Name = "loadPDFFileToolStripMenuItem";
        loadPDFFileToolStripMenuItem.Size = new Size(218, 22);
        loadPDFFileToolStripMenuItem.Text = "Add PDF";
        loadPDFFileToolStripMenuItem.Click += loadPDFFileToolStripMenuItem_Click;
        // 
        // saveMergedPDFToolStripMenuItem
        // 
        saveMergedPDFToolStripMenuItem.Name = "saveMergedPDFToolStripMenuItem";
        saveMergedPDFToolStripMenuItem.Size = new Size(218, 22);
        saveMergedPDFToolStripMenuItem.Text = "Save merged PDF";
        saveMergedPDFToolStripMenuItem.Click += saveMergedPDFToolStripMenuItem_Click;
        // 
        // removeSelectedPDFToolStripMenuItem
        // 
        removeSelectedPDFToolStripMenuItem.Name = "removeSelectedPDFToolStripMenuItem";
        removeSelectedPDFToolStripMenuItem.Size = new Size(218, 22);
        removeSelectedPDFToolStripMenuItem.Text = "Remove selected page/PDF";
        removeSelectedPDFToolStripMenuItem.Click += removeSelectedPDFToolStripMenuItem_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(215, 6);
        // 
        // closeToolStripMenuItem
        // 
        closeToolStripMenuItem.Name = "closeToolStripMenuItem";
        closeToolStripMenuItem.Size = new Size(218, 22);
        closeToolStripMenuItem.Text = "Close";
        closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 24);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(mainPanel);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(groupBoxPreviewSize);
        splitContainer1.Panel2.Controls.Add(groupBoxAction);
        splitContainer1.Size = new Size(1008, 737);
        splitContainer1.SplitterDistance = 769;
        splitContainer1.TabIndex = 1;
        // 
        // mainPanel
        // 
        mainPanel.AllowDrop = true;
        mainPanel.AutoScroll = true;
        mainPanel.Dock = DockStyle.Fill;
        mainPanel.Location = new Point(0, 0);
        mainPanel.Name = "mainPanel";
        mainPanel.Size = new Size(769, 737);
        mainPanel.TabIndex = 0;
        mainPanel.DragDrop += Panel_DragDrop;
        mainPanel.DragEnter += Panel_DragEnter;
        // 
        // groupBoxPreviewSize
        // 
        groupBoxPreviewSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxPreviewSize.Controls.Add(trackBarPreviewSize);
        groupBoxPreviewSize.Location = new Point(3, 123);
        groupBoxPreviewSize.Name = "groupBoxPreviewSize";
        groupBoxPreviewSize.Size = new Size(229, 76);
        groupBoxPreviewSize.TabIndex = 6;
        groupBoxPreviewSize.TabStop = false;
        groupBoxPreviewSize.Text = "Preview size";
        // 
        // trackBarPreviewSize
        // 
        trackBarPreviewSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        trackBarPreviewSize.Location = new Point(6, 22);
        trackBarPreviewSize.Maximum = 500;
        trackBarPreviewSize.Minimum = 100;
        trackBarPreviewSize.Name = "trackBarPreviewSize";
        trackBarPreviewSize.Size = new Size(214, 45);
        trackBarPreviewSize.TabIndex = 3;
        trackBarPreviewSize.TickFrequency = 50;
        trackBarPreviewSize.Value = 100;
        trackBarPreviewSize.Scroll += Slider_Scroll;
        // 
        // groupBoxAction
        // 
        groupBoxAction.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxAction.Controls.Add(buttonAddPdf);
        groupBoxAction.Controls.Add(buttonRemovePdf);
        groupBoxAction.Controls.Add(buttonSavePdf);
        groupBoxAction.Location = new Point(3, 3);
        groupBoxAction.Name = "groupBoxAction";
        groupBoxAction.Size = new Size(229, 114);
        groupBoxAction.TabIndex = 5;
        groupBoxAction.TabStop = false;
        groupBoxAction.Text = "Action";
        // 
        // buttonAddPdf
        // 
        buttonAddPdf.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonAddPdf.Location = new Point(6, 22);
        buttonAddPdf.Name = "buttonAddPdf";
        buttonAddPdf.Size = new Size(217, 23);
        buttonAddPdf.TabIndex = 0;
        buttonAddPdf.Text = "Add PDF";
        buttonAddPdf.UseVisualStyleBackColor = true;
        buttonAddPdf.Click += buttonAddPdf_Click;
        // 
        // buttonRemovePdf
        // 
        buttonRemovePdf.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonRemovePdf.Location = new Point(6, 51);
        buttonRemovePdf.Name = "buttonRemovePdf";
        buttonRemovePdf.Size = new Size(217, 23);
        buttonRemovePdf.TabIndex = 1;
        buttonRemovePdf.Text = "Remove selected page/PDF";
        buttonRemovePdf.UseVisualStyleBackColor = true;
        buttonRemovePdf.Click += buttonRemovePdf_Click;
        // 
        // buttonSavePdf
        // 
        buttonSavePdf.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonSavePdf.Location = new Point(6, 80);
        buttonSavePdf.Name = "buttonSavePdf";
        buttonSavePdf.Size = new Size(217, 23);
        buttonSavePdf.TabIndex = 2;
        buttonSavePdf.Text = "Save merged PDF";
        buttonSavePdf.UseVisualStyleBackColor = true;
        buttonSavePdf.Click += buttonSavePdf_Click;
        // 
        // MainForm
        // 
        AllowDrop = true;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1008, 761);
        Controls.Add(splitContainer1);
        Controls.Add(menuStrip1);
        KeyPreview = true;
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        Text = "PDF Merger";
        DragDrop += MainForm_DragDrop;
        DragEnter += MainForm_DragEnter;
        KeyDown += MainForm_KeyDown;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        groupBoxPreviewSize.ResumeLayout(false);
        groupBoxPreviewSize.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)trackBarPreviewSize).EndInit();
        groupBoxAction.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem closeToolStripMenuItem;
    private ToolStripMenuItem loadPDFFileToolStripMenuItem;
    private ToolStripMenuItem saveMergedPDFToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem removeSelectedPDFToolStripMenuItem;
    private SplitContainer splitContainer1;
    private Button buttonRemovePdf;
    private Button buttonAddPdf;
    private Button buttonSavePdf;
    private FlowLayoutPanel mainPanel;
    private TrackBar trackBarPreviewSize;
    private GroupBox groupBoxPreviewSize;
    private GroupBox groupBoxAction;
}
