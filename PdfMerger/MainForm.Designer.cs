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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        newProjectToolStripMenuItem = new ToolStripMenuItem();
        loadProjectToolStripMenuItem = new ToolStripMenuItem();
        saveProjectToolStripMenuItem = new ToolStripMenuItem();
        saveProjectAsToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator2 = new ToolStripSeparator();
        saveMergedPDFToolStripMenuItem1 = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        settingsToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator3 = new ToolStripSeparator();
        closeToolStripMenuItem = new ToolStripMenuItem();
        projectToolStripMenuItem = new ToolStripMenuItem();
        loadPDFFileToolStripMenuItem = new ToolStripMenuItem();
        removeSelectedPDFToolStripMenuItem = new ToolStripMenuItem();
        saveMergedPDFToolStripMenuItem = new ToolStripMenuItem();
        helpToolStripMenuItem = new ToolStripMenuItem();
        aboutToolStripMenuItem = new ToolStripMenuItem();
        splitContainer1 = new SplitContainer();
        groupBox2 = new GroupBox();
        labelCreated = new Label();
        button1 = new Button();
        label12 = new Label();
        label2 = new Label();
        checkBoxSaveAsBundle = new CheckBox();
        textBoxProjectName = new TextBox();
        label1 = new Label();
        groupBox1 = new GroupBox();
        pdfDocList = new ListView();
        groupBoxPreviewSize = new GroupBox();
        trackBarPreviewSize = new TrackBar();
        groupBoxAction = new GroupBox();
        buttonAddPdf = new Button();
        buttonRemovePdf = new Button();
        buttonSavePdf = new Button();
        mainPanel = new FlowLayoutPanel();
        statusStrip1 = new StatusStrip();
        toolStripStatusLabelFirst = new ToolStripStatusLabel();
        toolStripStatusLabelVersion = new ToolStripStatusLabel();
        menuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox1.SuspendLayout();
        groupBoxPreviewSize.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)trackBarPreviewSize).BeginInit();
        groupBoxAction.SuspendLayout();
        statusStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, projectToolStripMenuItem, helpToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1068, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newProjectToolStripMenuItem, loadProjectToolStripMenuItem, saveProjectToolStripMenuItem, saveProjectAsToolStripMenuItem, toolStripSeparator2, saveMergedPDFToolStripMenuItem1, toolStripSeparator1, settingsToolStripMenuItem, toolStripSeparator3, closeToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "File";
        // 
        // newProjectToolStripMenuItem
        // 
        newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
        newProjectToolStripMenuItem.Size = new Size(180, 22);
        newProjectToolStripMenuItem.Text = "New project";
        newProjectToolStripMenuItem.Click += newProjectToolStripMenuItem_Click;
        // 
        // loadProjectToolStripMenuItem
        // 
        loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
        loadProjectToolStripMenuItem.Size = new Size(180, 22);
        loadProjectToolStripMenuItem.Text = "Load project";
        loadProjectToolStripMenuItem.Click += loadProjectToolStripMenuItem_Click;
        // 
        // saveProjectToolStripMenuItem
        // 
        saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
        saveProjectToolStripMenuItem.Size = new Size(180, 22);
        saveProjectToolStripMenuItem.Text = "Save project";
        saveProjectToolStripMenuItem.Click += saveProjectToolStripMenuItem_Click;
        // 
        // saveProjectAsToolStripMenuItem
        // 
        saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
        saveProjectAsToolStripMenuItem.Size = new Size(180, 22);
        saveProjectAsToolStripMenuItem.Text = "Save project as ...";
        saveProjectAsToolStripMenuItem.Click += saveProjectAsToolStripMenuItem_Click;
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(177, 6);
        // 
        // saveMergedPDFToolStripMenuItem1
        // 
        saveMergedPDFToolStripMenuItem1.Name = "saveMergedPDFToolStripMenuItem1";
        saveMergedPDFToolStripMenuItem1.Size = new Size(180, 22);
        saveMergedPDFToolStripMenuItem1.Text = "Export merged PDF";
        saveMergedPDFToolStripMenuItem1.Click += saveMergedPDFToolStripMenuItem1_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(177, 6);
        // 
        // settingsToolStripMenuItem
        // 
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        settingsToolStripMenuItem.Size = new Size(180, 22);
        settingsToolStripMenuItem.Text = "Settings";
        settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
        // 
        // toolStripSeparator3
        // 
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new Size(177, 6);
        // 
        // closeToolStripMenuItem
        // 
        closeToolStripMenuItem.Name = "closeToolStripMenuItem";
        closeToolStripMenuItem.Size = new Size(180, 22);
        closeToolStripMenuItem.Text = "Close";
        closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
        // 
        // projectToolStripMenuItem
        // 
        projectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadPDFFileToolStripMenuItem, removeSelectedPDFToolStripMenuItem, saveMergedPDFToolStripMenuItem });
        projectToolStripMenuItem.Name = "projectToolStripMenuItem";
        projectToolStripMenuItem.Size = new Size(56, 20);
        projectToolStripMenuItem.Text = "Project";
        // 
        // loadPDFFileToolStripMenuItem
        // 
        loadPDFFileToolStripMenuItem.Name = "loadPDFFileToolStripMenuItem";
        loadPDFFileToolStripMenuItem.Size = new Size(218, 22);
        loadPDFFileToolStripMenuItem.Text = "Add PDF";
        loadPDFFileToolStripMenuItem.Click += loadPDFFileToolStripMenuItem_Click;
        // 
        // removeSelectedPDFToolStripMenuItem
        // 
        removeSelectedPDFToolStripMenuItem.Name = "removeSelectedPDFToolStripMenuItem";
        removeSelectedPDFToolStripMenuItem.Size = new Size(218, 22);
        removeSelectedPDFToolStripMenuItem.Text = "Remove selected page/PDF";
        removeSelectedPDFToolStripMenuItem.Click += removeSelectedPDFToolStripMenuItem_Click;
        // 
        // saveMergedPDFToolStripMenuItem
        // 
        saveMergedPDFToolStripMenuItem.Name = "saveMergedPDFToolStripMenuItem";
        saveMergedPDFToolStripMenuItem.Size = new Size(218, 22);
        saveMergedPDFToolStripMenuItem.Text = "Export merged PDF";
        saveMergedPDFToolStripMenuItem.Click += saveMergedPDFToolStripMenuItem_Click;
        // 
        // helpToolStripMenuItem
        // 
        helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
        helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        helpToolStripMenuItem.Size = new Size(44, 20);
        helpToolStripMenuItem.Text = "Help";
        // 
        // aboutToolStripMenuItem
        // 
        aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        aboutToolStripMenuItem.Size = new Size(107, 22);
        aboutToolStripMenuItem.Text = "About";
        aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 24);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(groupBox2);
        splitContainer1.Panel1.Controls.Add(groupBox1);
        splitContainer1.Panel1.Controls.Add(groupBoxPreviewSize);
        splitContainer1.Panel1.Controls.Add(groupBoxAction);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(mainPanel);
        splitContainer1.Size = new Size(1068, 707);
        splitContainer1.SplitterDistance = 211;
        splitContainer1.TabIndex = 1;
        // 
        // groupBox2
        // 
        groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupBox2.Controls.Add(labelCreated);
        groupBox2.Controls.Add(button1);
        groupBox2.Controls.Add(label12);
        groupBox2.Controls.Add(label2);
        groupBox2.Controls.Add(checkBoxSaveAsBundle);
        groupBox2.Controls.Add(textBoxProjectName);
        groupBox2.Controls.Add(label1);
        groupBox2.Location = new Point(3, 3);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(202, 157);
        groupBox2.TabIndex = 9;
        groupBox2.TabStop = false;
        groupBox2.Text = "Project";
        // 
        // labelCreated
        // 
        labelCreated.AutoSize = true;
        labelCreated.Location = new Point(59, 63);
        labelCreated.Name = "labelCreated";
        labelCreated.Size = new Size(51, 15);
        labelCreated.TabIndex = 5;
        labelCreated.Text = "Created:";
        // 
        // button1
        // 
        button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        button1.Location = new Point(6, 128);
        button1.Name = "button1";
        button1.Size = new Size(193, 23);
        button1.TabIndex = 3;
        button1.Text = "Save project";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label12
        // 
        label12.AutoSize = true;
        label12.Location = new Point(3, 63);
        label12.Name = "label12";
        label12.Size = new Size(51, 15);
        label12.TabIndex = 4;
        label12.Text = "Created:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(26, 103);
        label2.Name = "label2";
        label2.Size = new Size(125, 15);
        label2.TabIndex = 3;
        label2.Text = "(including all pdf files)";
        // 
        // checkBoxSaveAsBundle
        // 
        checkBoxSaveAsBundle.AutoSize = true;
        checkBoxSaveAsBundle.Location = new Point(6, 81);
        checkBoxSaveAsBundle.Name = "checkBoxSaveAsBundle";
        checkBoxSaveAsBundle.Size = new Size(104, 19);
        checkBoxSaveAsBundle.TabIndex = 2;
        checkBoxSaveAsBundle.Text = "Save as bundle";
        checkBoxSaveAsBundle.UseVisualStyleBackColor = true;
        // 
        // textBoxProjectName
        // 
        textBoxProjectName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        textBoxProjectName.Location = new Point(6, 37);
        textBoxProjectName.Name = "textBoxProjectName";
        textBoxProjectName.Size = new Size(190, 23);
        textBoxProjectName.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(3, 19);
        label1.Name = "label1";
        label1.Size = new Size(42, 15);
        label1.TabIndex = 0;
        label1.Text = "Name:";
        // 
        // groupBox1
        // 
        groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupBox1.Controls.Add(pdfDocList);
        groupBox1.Location = new Point(3, 368);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(202, 157);
        groupBox1.TabIndex = 8;
        groupBox1.TabStop = false;
        groupBox1.Text = "List of documents";
        // 
        // pdfDocList
        // 
        pdfDocList.AccessibleRole = AccessibleRole.None;
        pdfDocList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pdfDocList.FullRowSelect = true;
        pdfDocList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
        pdfDocList.Location = new Point(6, 22);
        pdfDocList.Name = "pdfDocList";
        pdfDocList.Size = new Size(190, 129);
        pdfDocList.TabIndex = 7;
        pdfDocList.UseCompatibleStateImageBehavior = false;
        pdfDocList.View = View.Details;
        // 
        // groupBoxPreviewSize
        // 
        groupBoxPreviewSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxPreviewSize.Controls.Add(trackBarPreviewSize);
        groupBoxPreviewSize.Location = new Point(3, 286);
        groupBoxPreviewSize.Name = "groupBoxPreviewSize";
        groupBoxPreviewSize.Size = new Size(202, 76);
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
        trackBarPreviewSize.Size = new Size(162, 45);
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
        groupBoxAction.Location = new Point(6, 166);
        groupBoxAction.Name = "groupBoxAction";
        groupBoxAction.Size = new Size(199, 114);
        groupBoxAction.TabIndex = 5;
        groupBoxAction.TabStop = false;
        groupBoxAction.Text = "Action";
        // 
        // buttonAddPdf
        // 
        buttonAddPdf.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonAddPdf.Location = new Point(6, 22);
        buttonAddPdf.Name = "buttonAddPdf";
        buttonAddPdf.Size = new Size(187, 23);
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
        buttonRemovePdf.Size = new Size(187, 23);
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
        buttonSavePdf.Size = new Size(187, 23);
        buttonSavePdf.TabIndex = 2;
        buttonSavePdf.Text = "Save merged PDF";
        buttonSavePdf.UseVisualStyleBackColor = true;
        buttonSavePdf.Click += buttonSavePdf_Click;
        // 
        // mainPanel
        // 
        mainPanel.AllowDrop = true;
        mainPanel.AutoScroll = true;
        mainPanel.Dock = DockStyle.Fill;
        mainPanel.Location = new Point(0, 0);
        mainPanel.Name = "mainPanel";
        mainPanel.Size = new Size(853, 707);
        mainPanel.TabIndex = 0;
        mainPanel.DragDrop += Panel_DragDrop;
        mainPanel.DragEnter += Panel_DragEnter;
        // 
        // statusStrip1
        // 
        statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelFirst, toolStripStatusLabelVersion });
        statusStrip1.Location = new Point(0, 709);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(1068, 22);
        statusStrip1.SizingGrip = false;
        statusStrip1.TabIndex = 2;
        statusStrip1.Text = "statusStrip1";
        // 
        // toolStripStatusLabelFirst
        // 
        toolStripStatusLabelFirst.Name = "toolStripStatusLabelFirst";
        toolStripStatusLabelFirst.Size = new Size(118, 17);
        toolStripStatusLabelFirst.Text = "toolStripStatusLabel1";
        // 
        // toolStripStatusLabelVersion
        // 
        toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
        toolStripStatusLabelVersion.Size = new Size(935, 17);
        toolStripStatusLabelVersion.Spring = true;
        toolStripStatusLabelVersion.Text = "Version";
        toolStripStatusLabelVersion.TextAlign = ContentAlignment.MiddleRight;
        toolStripStatusLabelVersion.Click += toolStripStatusLabel1_Click;
        // 
        // MainForm
        // 
        AllowDrop = true;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1068, 731);
        Controls.Add(statusStrip1);
        Controls.Add(splitContainer1);
        Controls.Add(menuStrip1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        KeyPreview = true;
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        Text = "PDF Merger";
        ResizeEnd += MainForm_ResizeEnd;
        LocationChanged += MainForm_LocationChanged;
        DragDrop += MainForm_DragDrop;
        DragEnter += MainForm_DragEnter;
        KeyDown += MainForm_KeyDown;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox1.ResumeLayout(false);
        groupBoxPreviewSize.ResumeLayout(false);
        groupBoxPreviewSize.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)trackBarPreviewSize).EndInit();
        groupBoxAction.ResumeLayout(false);
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
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
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private GroupBox groupBox1;
    private ListView pdfDocList;
    private ToolStripMenuItem newProjectToolStripMenuItem;
    private ToolStripMenuItem loadProjectToolStripMenuItem;
    private ToolStripMenuItem saveProjectToolStripMenuItem;
    private ToolStripMenuItem saveProjectAsToolStripMenuItem;
    private GroupBox groupBox2;
    private Button button1;
    private Label label12;
    private Label label2;
    private CheckBox checkBoxSaveAsBundle;
    private TextBox textBoxProjectName;
    private Label label1;
    private Label labelCreated;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabelVersion;
    private ToolStripStatusLabel toolStripStatusLabelFirst;
    private ToolStripMenuItem projectToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem saveMergedPDFToolStripMenuItem1;
    private ToolStripMenuItem settingsToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator3;
}
