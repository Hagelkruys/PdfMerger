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
        editMetadataForMergedPDFToolStripMenuItem = new ToolStripMenuItem();
        helpToolStripMenuItem = new ToolStripMenuItem();
        aboutToolStripMenuItem = new ToolStripMenuItem();
        splitContainer1 = new SplitContainer();
        sidebarPanel1 = new PdfMerger.customUI.SidebarPanel();
        panelPreviewSize = new Panel();
        trackBarPreviewSize = new TrackBar();
        sbPreviewSize = new SidebarButton();
        panelListOfDocs = new Panel();
        pdfDocList = new ListView();
        sbListOfDocs = new SidebarButton();
        panelActionButton = new Panel();
        buttonSavePdf = new Button();
        buttonRemovePdf = new Button();
        buttonAddPdf = new Button();
        sbAction = new SidebarButton();
        panelProject = new Panel();
        button1 = new Button();
        labelCreated = new Label();
        textBoxProjectName = new TextBox();
        label1 = new Label();
        sbProject = new SidebarButton();
        panelSideBar = new Panel();
        mainPanel = new FlowLayoutPanel();
        statusStrip1 = new StatusStrip();
        toolStripStatusLabelFirst = new ToolStripStatusLabel();
        toolStripStatusLabelVersion = new ToolStripStatusLabel();
        menuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        sidebarPanel1.SuspendLayout();
        panelPreviewSize.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)trackBarPreviewSize).BeginInit();
        panelListOfDocs.SuspendLayout();
        panelActionButton.SuspendLayout();
        panelProject.SuspendLayout();
        statusStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(20, 20);
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, projectToolStripMenuItem, helpToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1293, 24);
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
        newProjectToolStripMenuItem.Size = new Size(175, 22);
        newProjectToolStripMenuItem.Text = "New project";
        newProjectToolStripMenuItem.Click += newProjectToolStripMenuItem_Click;
        // 
        // loadProjectToolStripMenuItem
        // 
        loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
        loadProjectToolStripMenuItem.Size = new Size(175, 22);
        loadProjectToolStripMenuItem.Text = "Load project";
        loadProjectToolStripMenuItem.Click += loadProjectToolStripMenuItem_Click;
        // 
        // saveProjectToolStripMenuItem
        // 
        saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
        saveProjectToolStripMenuItem.Size = new Size(175, 22);
        saveProjectToolStripMenuItem.Text = "Save project";
        saveProjectToolStripMenuItem.Click += saveProjectToolStripMenuItem_Click;
        // 
        // saveProjectAsToolStripMenuItem
        // 
        saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
        saveProjectAsToolStripMenuItem.Size = new Size(175, 22);
        saveProjectAsToolStripMenuItem.Text = "Save project as ...";
        saveProjectAsToolStripMenuItem.Click += saveProjectAsToolStripMenuItem_Click;
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(172, 6);
        // 
        // saveMergedPDFToolStripMenuItem1
        // 
        saveMergedPDFToolStripMenuItem1.Name = "saveMergedPDFToolStripMenuItem1";
        saveMergedPDFToolStripMenuItem1.Size = new Size(175, 22);
        saveMergedPDFToolStripMenuItem1.Text = "Export merged PDF";
        saveMergedPDFToolStripMenuItem1.Click += saveMergedPDFToolStripMenuItem1_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(172, 6);
        // 
        // settingsToolStripMenuItem
        // 
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        settingsToolStripMenuItem.Size = new Size(175, 22);
        settingsToolStripMenuItem.Text = "Settings";
        settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
        // 
        // toolStripSeparator3
        // 
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new Size(172, 6);
        // 
        // closeToolStripMenuItem
        // 
        closeToolStripMenuItem.Name = "closeToolStripMenuItem";
        closeToolStripMenuItem.Size = new Size(175, 22);
        closeToolStripMenuItem.Text = "Close";
        closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
        // 
        // projectToolStripMenuItem
        // 
        projectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadPDFFileToolStripMenuItem, removeSelectedPDFToolStripMenuItem, saveMergedPDFToolStripMenuItem, editMetadataForMergedPDFToolStripMenuItem });
        projectToolStripMenuItem.Name = "projectToolStripMenuItem";
        projectToolStripMenuItem.Size = new Size(56, 20);
        projectToolStripMenuItem.Text = "Project";
        // 
        // loadPDFFileToolStripMenuItem
        // 
        loadPDFFileToolStripMenuItem.Name = "loadPDFFileToolStripMenuItem";
        loadPDFFileToolStripMenuItem.Size = new Size(236, 22);
        loadPDFFileToolStripMenuItem.Text = "Add PDF";
        loadPDFFileToolStripMenuItem.Click += loadPDFFileToolStripMenuItem_Click;
        // 
        // removeSelectedPDFToolStripMenuItem
        // 
        removeSelectedPDFToolStripMenuItem.Name = "removeSelectedPDFToolStripMenuItem";
        removeSelectedPDFToolStripMenuItem.Size = new Size(236, 22);
        removeSelectedPDFToolStripMenuItem.Text = "Remove selected page/PDF";
        removeSelectedPDFToolStripMenuItem.Click += removeSelectedPDFToolStripMenuItem_Click;
        // 
        // saveMergedPDFToolStripMenuItem
        // 
        saveMergedPDFToolStripMenuItem.Name = "saveMergedPDFToolStripMenuItem";
        saveMergedPDFToolStripMenuItem.Size = new Size(236, 22);
        saveMergedPDFToolStripMenuItem.Text = "Export merged PDF";
        saveMergedPDFToolStripMenuItem.Click += saveMergedPDFToolStripMenuItem_Click;
        // 
        // editMetadataForMergedPDFToolStripMenuItem
        // 
        editMetadataForMergedPDFToolStripMenuItem.Name = "editMetadataForMergedPDFToolStripMenuItem";
        editMetadataForMergedPDFToolStripMenuItem.Size = new Size(236, 22);
        editMetadataForMergedPDFToolStripMenuItem.Text = "Edit metadata for merged PDF ";
        editMetadataForMergedPDFToolStripMenuItem.Click += editMetadataForMergedPDFToolStripMenuItem_Click;
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
        splitContainer1.Panel1.AutoScroll = true;
        splitContainer1.Panel1.Controls.Add(sidebarPanel1);
        splitContainer1.Panel1.Controls.Add(panelSideBar);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(mainPanel);
        splitContainer1.Size = new Size(1293, 793);
        splitContainer1.SplitterDistance = 254;
        splitContainer1.TabIndex = 1;
        // 
        // sidebarPanel1
        // 
        sidebarPanel1.AutoSize = true;
        sidebarPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        sidebarPanel1.BackColor = SystemColors.Control;
        sidebarPanel1.Controls.Add(panelPreviewSize);
        sidebarPanel1.Controls.Add(sbPreviewSize);
        sidebarPanel1.Controls.Add(panelListOfDocs);
        sidebarPanel1.Controls.Add(sbListOfDocs);
        sidebarPanel1.Controls.Add(panelActionButton);
        sidebarPanel1.Controls.Add(sbAction);
        sidebarPanel1.Controls.Add(panelProject);
        sidebarPanel1.Controls.Add(sbProject);
        sidebarPanel1.Dock = DockStyle.Fill;
        sidebarPanel1.Location = new Point(0, 0);
        sidebarPanel1.Name = "sidebarPanel1";
        sidebarPanel1.Size = new Size(254, 793);
        sidebarPanel1.TabIndex = 15;
        // 
        // panelPreviewSize
        // 
        panelPreviewSize.Controls.Add(trackBarPreviewSize);
        panelPreviewSize.Dock = DockStyle.Top;
        panelPreviewSize.Location = new Point(0, 493);
        panelPreviewSize.Name = "panelPreviewSize";
        panelPreviewSize.Size = new Size(254, 45);
        panelPreviewSize.TabIndex = 6;
        // 
        // trackBarPreviewSize
        // 
        trackBarPreviewSize.Dock = DockStyle.Top;
        trackBarPreviewSize.Location = new Point(0, 0);
        trackBarPreviewSize.Maximum = 500;
        trackBarPreviewSize.Minimum = 100;
        trackBarPreviewSize.Name = "trackBarPreviewSize";
        trackBarPreviewSize.Size = new Size(254, 45);
        trackBarPreviewSize.TabIndex = 4;
        trackBarPreviewSize.TickFrequency = 50;
        trackBarPreviewSize.Value = 100;
        // 
        // sbPreviewSize
        // 
        sbPreviewSize.ContentControl = panelPreviewSize;
        sbPreviewSize.Dock = DockStyle.Top;
        sbPreviewSize.Expanded = true;
        sbPreviewSize.HeaderText = "Preview size";
        sbPreviewSize.Location = new Point(0, 461);
        sbPreviewSize.Name = "sbPreviewSize";
        sbPreviewSize.Size = new Size(254, 32);
        sbPreviewSize.TabIndex = 5;
        // 
        // panelListOfDocs
        // 
        panelListOfDocs.Controls.Add(pdfDocList);
        panelListOfDocs.Dock = DockStyle.Top;
        panelListOfDocs.Location = new Point(0, 291);
        panelListOfDocs.Name = "panelListOfDocs";
        panelListOfDocs.Size = new Size(254, 170);
        panelListOfDocs.TabIndex = 4;
        // 
        // pdfDocList
        // 
        pdfDocList.AccessibleRole = AccessibleRole.None;
        pdfDocList.Dock = DockStyle.Top;
        pdfDocList.FullRowSelect = true;
        pdfDocList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
        pdfDocList.Location = new Point(0, 0);
        pdfDocList.Name = "pdfDocList";
        pdfDocList.Size = new Size(254, 164);
        pdfDocList.TabIndex = 8;
        pdfDocList.UseCompatibleStateImageBehavior = false;
        pdfDocList.View = View.Details;
        // 
        // sbListOfDocs
        // 
        sbListOfDocs.ContentControl = panelListOfDocs;
        sbListOfDocs.Dock = DockStyle.Top;
        sbListOfDocs.Expanded = true;
        sbListOfDocs.HeaderText = "List of Documents";
        sbListOfDocs.Location = new Point(0, 259);
        sbListOfDocs.Name = "sbListOfDocs";
        sbListOfDocs.Size = new Size(254, 32);
        sbListOfDocs.TabIndex = 3;
        // 
        // panelActionButton
        // 
        panelActionButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        panelActionButton.Controls.Add(buttonSavePdf);
        panelActionButton.Controls.Add(buttonRemovePdf);
        panelActionButton.Controls.Add(buttonAddPdf);
        panelActionButton.Dock = DockStyle.Top;
        panelActionButton.Location = new Point(0, 181);
        panelActionButton.Name = "panelActionButton";
        panelActionButton.Size = new Size(254, 78);
        panelActionButton.TabIndex = 2;
        // 
        // buttonSavePdf
        // 
        buttonSavePdf.Dock = DockStyle.Top;
        buttonSavePdf.Location = new Point(0, 46);
        buttonSavePdf.Name = "buttonSavePdf";
        buttonSavePdf.Size = new Size(254, 23);
        buttonSavePdf.TabIndex = 3;
        buttonSavePdf.Text = "Save merged PDF";
        buttonSavePdf.UseVisualStyleBackColor = true;
        // 
        // buttonRemovePdf
        // 
        buttonRemovePdf.Dock = DockStyle.Top;
        buttonRemovePdf.Location = new Point(0, 23);
        buttonRemovePdf.Name = "buttonRemovePdf";
        buttonRemovePdf.Size = new Size(254, 23);
        buttonRemovePdf.TabIndex = 2;
        buttonRemovePdf.Text = "Remove selected page/PDF";
        buttonRemovePdf.UseVisualStyleBackColor = true;
        // 
        // buttonAddPdf
        // 
        buttonAddPdf.Dock = DockStyle.Top;
        buttonAddPdf.Location = new Point(0, 0);
        buttonAddPdf.Name = "buttonAddPdf";
        buttonAddPdf.Size = new Size(254, 23);
        buttonAddPdf.TabIndex = 1;
        buttonAddPdf.Text = "Add PDF";
        buttonAddPdf.UseVisualStyleBackColor = true;
        // 
        // sbAction
        // 
        sbAction.ContentControl = panelActionButton;
        sbAction.Dock = DockStyle.Top;
        sbAction.Expanded = true;
        sbAction.HeaderText = "Action Buttons";
        sbAction.Location = new Point(0, 149);
        sbAction.Name = "sbAction";
        sbAction.Size = new Size(254, 32);
        sbAction.TabIndex = 1;
        // 
        // panelProject
        // 
        panelProject.Controls.Add(button1);
        panelProject.Controls.Add(labelCreated);
        panelProject.Controls.Add(textBoxProjectName);
        panelProject.Controls.Add(label1);
        panelProject.Dock = DockStyle.Top;
        panelProject.Location = new Point(0, 32);
        panelProject.Name = "panelProject";
        panelProject.Size = new Size(254, 117);
        panelProject.TabIndex = 8;
        // 
        // button1
        // 
        button1.Dock = DockStyle.Top;
        button1.Location = new Point(0, 83);
        button1.Name = "button1";
        button1.Size = new Size(254, 23);
        button1.TabIndex = 3;
        button1.Text = "Save project";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // labelCreated
        // 
        labelCreated.AutoSize = true;
        labelCreated.Dock = DockStyle.Top;
        labelCreated.Location = new Point(0, 48);
        labelCreated.Name = "labelCreated";
        labelCreated.Padding = new Padding(0, 10, 0, 10);
        labelCreated.Size = new Size(51, 35);
        labelCreated.TabIndex = 2;
        labelCreated.Text = "Created:";
        // 
        // textBoxProjectName
        // 
        textBoxProjectName.Dock = DockStyle.Top;
        textBoxProjectName.Location = new Point(0, 25);
        textBoxProjectName.Name = "textBoxProjectName";
        textBoxProjectName.Size = new Size(254, 23);
        textBoxProjectName.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Dock = DockStyle.Top;
        label1.Location = new Point(0, 0);
        label1.Name = "label1";
        label1.Padding = new Padding(0, 10, 0, 0);
        label1.Size = new Size(42, 25);
        label1.TabIndex = 0;
        label1.Text = "Name:";
        // 
        // sbProject
        // 
        sbProject.ContentControl = panelProject;
        sbProject.Dock = DockStyle.Top;
        sbProject.Expanded = true;
        sbProject.HeaderText = "Project";
        sbProject.Location = new Point(0, 0);
        sbProject.Name = "sbProject";
        sbProject.Size = new Size(254, 32);
        sbProject.TabIndex = 7;
        // 
        // panelSideBar
        // 
        panelSideBar.AutoSize = true;
        panelSideBar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        panelSideBar.BackColor = SystemColors.MenuHighlight;
        panelSideBar.Dock = DockStyle.Top;
        panelSideBar.Location = new Point(0, 0);
        panelSideBar.Name = "panelSideBar";
        panelSideBar.Size = new Size(254, 0);
        panelSideBar.TabIndex = 14;
        // 
        // mainPanel
        // 
        mainPanel.AllowDrop = true;
        mainPanel.AutoScroll = true;
        mainPanel.Dock = DockStyle.Fill;
        mainPanel.Location = new Point(0, 0);
        mainPanel.Name = "mainPanel";
        mainPanel.Size = new Size(1035, 793);
        mainPanel.TabIndex = 0;
        mainPanel.DragDrop += Panel_DragDrop;
        mainPanel.DragEnter += Panel_DragEnter;
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new Size(20, 20);
        statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelFirst, toolStripStatusLabelVersion });
        statusStrip1.Location = new Point(0, 795);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(1293, 22);
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
        toolStripStatusLabelVersion.Size = new Size(1160, 17);
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
        ClientSize = new Size(1293, 817);
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
        splitContainer1.Panel1.PerformLayout();
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        sidebarPanel1.ResumeLayout(false);
        panelPreviewSize.ResumeLayout(false);
        panelPreviewSize.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)trackBarPreviewSize).EndInit();
        panelListOfDocs.ResumeLayout(false);
        panelActionButton.ResumeLayout(false);
        panelProject.ResumeLayout(false);
        panelProject.PerformLayout();
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
    private FlowLayoutPanel mainPanel;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private ToolStripMenuItem newProjectToolStripMenuItem;
    private ToolStripMenuItem loadProjectToolStripMenuItem;
    private ToolStripMenuItem saveProjectToolStripMenuItem;
    private ToolStripMenuItem saveProjectAsToolStripMenuItem;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabelVersion;
    private ToolStripStatusLabel toolStripStatusLabelFirst;
    private ToolStripMenuItem projectToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem saveMergedPDFToolStripMenuItem1;
    private ToolStripMenuItem settingsToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem editMetadataForMergedPDFToolStripMenuItem;
    private Panel panelSideBar;
    private customUI.SidebarPanel sidebarPanel1;
    private Panel panelListOfDocs;
    private SidebarButton sbListOfDocs;
    private Panel panelActionButton;
    private SidebarButton sbAction;
    private Panel panelPreviewSize;
    private TrackBar trackBarPreviewSize;
    private SidebarButton sbPreviewSize;
    private ListView pdfDocList;
    private Button buttonSavePdf;
    private Button buttonRemovePdf;
    private Button buttonAddPdf;
    private Panel panelProject;
    private TextBox textBoxProjectName;
    private Label label1;
    private SidebarButton sbProject;
    private Button button1;
    private Label labelCreated;
}
