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
        ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
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
        recentProjectsToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator3 = new ToolStripSeparator();
        closeToolStripMenuItem = new ToolStripMenuItem();
        projectToolStripMenuItem = new ToolStripMenuItem();
        undoToolStripMenuItem = new ToolStripMenuItem();
        redoToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator4 = new ToolStripSeparator();
        loadPDFFileToolStripMenuItem = new ToolStripMenuItem();
        addImageToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator9 = new ToolStripSeparator();
        removeSelectedPDFToolStripMenuItem = new ToolStripMenuItem();
        saveMergedPDFToolStripMenuItem = new ToolStripMenuItem();
        editMetadataForMergedPDFToolStripMenuItem = new ToolStripMenuItem();
        editSecuritySettingsForMergedPDFToolStripMenuItem = new ToolStripMenuItem();
        helpToolStripMenuItem = new ToolStripMenuItem();
        aboutToolStripMenuItem = new ToolStripMenuItem();
        licensesToolStripMenuItem = new ToolStripMenuItem();
        checkForUpdateToolStripMenuItem = new ToolStripMenuItem();
        splitContainer1 = new SplitContainer();
        sidebarPanel1 = new PdfMerger.customUI.SidebarPanel();
        panelPreviewSize = new Panel();
        trackBarPreviewSize = new TrackBar();
        sbPreviewSize = new SidebarButton();
        panelListOfDocs = new Panel();
        pdfDocList = new ListView();
        sbListOfDocs = new SidebarButton();
        panelProject = new Panel();
        labelCreated = new Label();
        textBoxProjectName = new TextBox();
        labelName = new Label();
        sbProject = new SidebarButton();
        panelSideBar = new Panel();
        mainPanel = new FlowLayoutPanel();
        statusStrip1 = new StatusStrip();
        toolStripStatusLabelFirst = new ToolStripStatusLabel();
        toolStripStatusLabelVersion = new ToolStripStatusLabel();
        toolStrip1 = new ToolStrip();
        toolStripButtonNewProject = new ToolStripButton();
        toolStripButtonOpenProject = new ToolStripButton();
        toolStripButtonSaveProject = new ToolStripButton();
        toolStripButtonSaveProjectAs = new ToolStripButton();
        toolStripSeparator5 = new ToolStripSeparator();
        toolStripButtonExport = new ToolStripButton();
        toolStripButtonMetadata = new ToolStripButton();
        toolStripButtonSecuritySettings = new ToolStripButton();
        toolStripSeparator8 = new ToolStripSeparator();
        toolStripButtonAddPdf = new ToolStripButton();
        toolStripButtonDeletePdf = new ToolStripButton();
        toolStripButtonCollapse = new ToolStripButton();
        toolStripButtonExpand = new ToolStripButton();
        toolStripSeparator6 = new ToolStripSeparator();
        toolStripButtonUndo = new ToolStripButton();
        toolStripButtonRedo = new ToolStripButton();
        toolStripSeparator7 = new ToolStripSeparator();
        menuStrip1.SuspendLayout();
        ((ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        sidebarPanel1.SuspendLayout();
        panelPreviewSize.SuspendLayout();
        ((ISupportInitialize)trackBarPreviewSize).BeginInit();
        panelListOfDocs.SuspendLayout();
        panelProject.SuspendLayout();
        statusStrip1.SuspendLayout();
        toolStrip1.SuspendLayout();
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
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newProjectToolStripMenuItem, loadProjectToolStripMenuItem, saveProjectToolStripMenuItem, saveProjectAsToolStripMenuItem, toolStripSeparator2, saveMergedPDFToolStripMenuItem1, toolStripSeparator1, settingsToolStripMenuItem, recentProjectsToolStripMenuItem, toolStripSeparator3, closeToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "File";
        // 
        // newProjectToolStripMenuItem
        // 
        newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
        newProjectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
        newProjectToolStripMenuItem.Size = new Size(215, 22);
        newProjectToolStripMenuItem.Text = "New project";
        newProjectToolStripMenuItem.Click += newProjectToolStripMenuItem_Click;
        // 
        // loadProjectToolStripMenuItem
        // 
        loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
        loadProjectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
        loadProjectToolStripMenuItem.Size = new Size(215, 22);
        loadProjectToolStripMenuItem.Text = "Load project";
        loadProjectToolStripMenuItem.Click += loadProjectToolStripMenuItem_Click;
        // 
        // saveProjectToolStripMenuItem
        // 
        saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
        saveProjectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        saveProjectToolStripMenuItem.Size = new Size(215, 22);
        saveProjectToolStripMenuItem.Text = "Save project";
        saveProjectToolStripMenuItem.Click += SaveProjectToolStripMenuItem_Click;
        // 
        // saveProjectAsToolStripMenuItem
        // 
        saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
        saveProjectAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.U;
        saveProjectAsToolStripMenuItem.Size = new Size(215, 22);
        saveProjectAsToolStripMenuItem.Text = "Save project as ...";
        saveProjectAsToolStripMenuItem.Click += SaveProjectAsToolStripMenuItem_Click;
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(212, 6);
        // 
        // saveMergedPDFToolStripMenuItem1
        // 
        saveMergedPDFToolStripMenuItem1.Name = "saveMergedPDFToolStripMenuItem1";
        saveMergedPDFToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.E;
        saveMergedPDFToolStripMenuItem1.Size = new Size(215, 22);
        saveMergedPDFToolStripMenuItem1.Text = "Export merged PDF";
        saveMergedPDFToolStripMenuItem1.Click += SaveMergedPDFToolStripMenuItem1_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(212, 6);
        // 
        // settingsToolStripMenuItem
        // 
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        settingsToolStripMenuItem.Size = new Size(215, 22);
        settingsToolStripMenuItem.Text = "Settings";
        settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
        // 
        // recentProjectsToolStripMenuItem
        // 
        recentProjectsToolStripMenuItem.Name = "recentProjectsToolStripMenuItem";
        recentProjectsToolStripMenuItem.Size = new Size(215, 22);
        recentProjectsToolStripMenuItem.Text = "Recent projects...";
        // 
        // toolStripSeparator3
        // 
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new Size(212, 6);
        // 
        // closeToolStripMenuItem
        // 
        closeToolStripMenuItem.Name = "closeToolStripMenuItem";
        closeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
        closeToolStripMenuItem.Size = new Size(215, 22);
        closeToolStripMenuItem.Text = "Close";
        closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
        // 
        // projectToolStripMenuItem
        // 
        projectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator4, loadPDFFileToolStripMenuItem, addImageToolStripMenuItem, toolStripSeparator9, removeSelectedPDFToolStripMenuItem, saveMergedPDFToolStripMenuItem, editMetadataForMergedPDFToolStripMenuItem, editSecuritySettingsForMergedPDFToolStripMenuItem });
        projectToolStripMenuItem.Name = "projectToolStripMenuItem";
        projectToolStripMenuItem.Size = new Size(56, 20);
        projectToolStripMenuItem.Text = "Project";
        // 
        // undoToolStripMenuItem
        // 
        undoToolStripMenuItem.Name = "undoToolStripMenuItem";
        undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
        undoToolStripMenuItem.Size = new Size(268, 22);
        undoToolStripMenuItem.Text = "Undo";
        undoToolStripMenuItem.Click += UndoToolStripMenuItem_Click;
        // 
        // redoToolStripMenuItem
        // 
        redoToolStripMenuItem.Name = "redoToolStripMenuItem";
        redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
        redoToolStripMenuItem.Size = new Size(268, 22);
        redoToolStripMenuItem.Text = "Redo";
        redoToolStripMenuItem.Click += RedoToolStripMenuItem_Click;
        // 
        // toolStripSeparator4
        // 
        toolStripSeparator4.Name = "toolStripSeparator4";
        toolStripSeparator4.Size = new Size(265, 6);
        // 
        // loadPDFFileToolStripMenuItem
        // 
        loadPDFFileToolStripMenuItem.Name = "loadPDFFileToolStripMenuItem";
        loadPDFFileToolStripMenuItem.Size = new Size(268, 22);
        loadPDFFileToolStripMenuItem.Text = "Add PDF";
        loadPDFFileToolStripMenuItem.Click += LoadPDFFileToolStripMenuItem_Click;
        // 
        // addImageToolStripMenuItem
        // 
        addImageToolStripMenuItem.Name = "addImageToolStripMenuItem";
        addImageToolStripMenuItem.Size = new Size(268, 22);
        addImageToolStripMenuItem.Text = "Add Image";
        addImageToolStripMenuItem.Click += AddImageToolStripMenuItem_Click;
        // 
        // toolStripSeparator9
        // 
        toolStripSeparator9.Name = "toolStripSeparator9";
        toolStripSeparator9.Size = new Size(265, 6);
        // 
        // removeSelectedPDFToolStripMenuItem
        // 
        removeSelectedPDFToolStripMenuItem.Name = "removeSelectedPDFToolStripMenuItem";
        removeSelectedPDFToolStripMenuItem.Size = new Size(268, 22);
        removeSelectedPDFToolStripMenuItem.Text = "Remove selected page/PDF";
        removeSelectedPDFToolStripMenuItem.Click += RemoveSelectedPDFToolStripMenuItem_Click;
        // 
        // saveMergedPDFToolStripMenuItem
        // 
        saveMergedPDFToolStripMenuItem.Name = "saveMergedPDFToolStripMenuItem";
        saveMergedPDFToolStripMenuItem.Size = new Size(268, 22);
        saveMergedPDFToolStripMenuItem.Text = "Export merged PDF";
        saveMergedPDFToolStripMenuItem.Click += SaveMergedPDFToolStripMenuItem_Click;
        // 
        // editMetadataForMergedPDFToolStripMenuItem
        // 
        editMetadataForMergedPDFToolStripMenuItem.Name = "editMetadataForMergedPDFToolStripMenuItem";
        editMetadataForMergedPDFToolStripMenuItem.Size = new Size(268, 22);
        editMetadataForMergedPDFToolStripMenuItem.Text = "Edit metadata for merged PDF ";
        editMetadataForMergedPDFToolStripMenuItem.Click += editMetadataForMergedPDFToolStripMenuItem_Click;
        // 
        // editSecuritySettingsForMergedPDFToolStripMenuItem
        // 
        editSecuritySettingsForMergedPDFToolStripMenuItem.Name = "editSecuritySettingsForMergedPDFToolStripMenuItem";
        editSecuritySettingsForMergedPDFToolStripMenuItem.Size = new Size(268, 22);
        editSecuritySettingsForMergedPDFToolStripMenuItem.Text = "Edit security settings for merged PDF";
        editSecuritySettingsForMergedPDFToolStripMenuItem.Click += ToolStripButtonSecuritySettings_Click;
        // 
        // helpToolStripMenuItem
        // 
        helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, licensesToolStripMenuItem, checkForUpdateToolStripMenuItem });
        helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        helpToolStripMenuItem.Size = new Size(44, 20);
        helpToolStripMenuItem.Text = "Help";
        // 
        // aboutToolStripMenuItem
        // 
        aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        aboutToolStripMenuItem.Size = new Size(165, 22);
        aboutToolStripMenuItem.Text = "About";
        aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
        // 
        // licensesToolStripMenuItem
        // 
        licensesToolStripMenuItem.Name = "licensesToolStripMenuItem";
        licensesToolStripMenuItem.Size = new Size(165, 22);
        licensesToolStripMenuItem.Text = "Licenses";
        licensesToolStripMenuItem.Click += licensesToolStripMenuItem_Click;
        // 
        // checkForUpdateToolStripMenuItem
        // 
        checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
        checkForUpdateToolStripMenuItem.Size = new Size(165, 22);
        checkForUpdateToolStripMenuItem.Text = "Check for update";
        checkForUpdateToolStripMenuItem.Click += CheckForUpdateToolStripMenuItem_Click;
        // 
        // splitContainer1
        // 
        splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        splitContainer1.Location = new Point(0, 58);
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
        splitContainer1.Size = new Size(1293, 759);
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
        sidebarPanel1.Controls.Add(panelProject);
        sidebarPanel1.Controls.Add(sbProject);
        sidebarPanel1.Dock = DockStyle.Fill;
        sidebarPanel1.Location = new Point(0, 0);
        sidebarPanel1.Name = "sidebarPanel1";
        sidebarPanel1.Size = new Size(254, 759);
        sidebarPanel1.TabIndex = 15;
        // 
        // panelPreviewSize
        // 
        panelPreviewSize.Controls.Add(trackBarPreviewSize);
        panelPreviewSize.Dock = DockStyle.Top;
        panelPreviewSize.Location = new Point(0, 430);
        panelPreviewSize.Name = "panelPreviewSize";
        panelPreviewSize.Padding = new Padding(5);
        panelPreviewSize.Size = new Size(254, 45);
        panelPreviewSize.TabIndex = 6;
        // 
        // trackBarPreviewSize
        // 
        trackBarPreviewSize.Dock = DockStyle.Top;
        trackBarPreviewSize.Location = new Point(5, 5);
        trackBarPreviewSize.Maximum = 600;
        trackBarPreviewSize.Minimum = 200;
        trackBarPreviewSize.Name = "trackBarPreviewSize";
        trackBarPreviewSize.Size = new Size(244, 45);
        trackBarPreviewSize.TabIndex = 4;
        trackBarPreviewSize.TickFrequency = 50;
        trackBarPreviewSize.Value = 200;
        trackBarPreviewSize.Scroll += Slider_Scroll;
        // 
        // sbPreviewSize
        // 
        sbPreviewSize.ContentControl = panelPreviewSize;
        sbPreviewSize.Dock = DockStyle.Top;
        sbPreviewSize.Expanded = true;
        sbPreviewSize.HeaderText = "Preview size";
        sbPreviewSize.Location = new Point(0, 398);
        sbPreviewSize.Name = "sbPreviewSize";
        sbPreviewSize.Size = new Size(254, 32);
        sbPreviewSize.TabIndex = 5;
        // 
        // panelListOfDocs
        // 
        panelListOfDocs.Controls.Add(pdfDocList);
        panelListOfDocs.Dock = DockStyle.Top;
        panelListOfDocs.Location = new Point(0, 146);
        panelListOfDocs.Name = "panelListOfDocs";
        panelListOfDocs.Padding = new Padding(5);
        panelListOfDocs.Size = new Size(254, 252);
        panelListOfDocs.TabIndex = 4;
        // 
        // pdfDocList
        // 
        pdfDocList.AccessibleRole = AccessibleRole.None;
        pdfDocList.Dock = DockStyle.Top;
        pdfDocList.FullRowSelect = true;
        pdfDocList.GridLines = true;
        pdfDocList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
        pdfDocList.Location = new Point(5, 5);
        pdfDocList.Name = "pdfDocList";
        pdfDocList.Size = new Size(244, 241);
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
        sbListOfDocs.Location = new Point(0, 114);
        sbListOfDocs.Name = "sbListOfDocs";
        sbListOfDocs.Size = new Size(254, 32);
        sbListOfDocs.TabIndex = 3;
        // 
        // panelProject
        // 
        panelProject.Controls.Add(labelCreated);
        panelProject.Controls.Add(textBoxProjectName);
        panelProject.Controls.Add(labelName);
        panelProject.Dock = DockStyle.Top;
        panelProject.Location = new Point(0, 32);
        panelProject.Name = "panelProject";
        panelProject.Padding = new Padding(5);
        panelProject.Size = new Size(254, 82);
        panelProject.TabIndex = 8;
        // 
        // labelCreated
        // 
        labelCreated.AutoSize = true;
        labelCreated.Dock = DockStyle.Top;
        labelCreated.Location = new Point(5, 43);
        labelCreated.Name = "labelCreated";
        labelCreated.Padding = new Padding(0, 10, 0, 10);
        labelCreated.Size = new Size(51, 35);
        labelCreated.TabIndex = 2;
        labelCreated.Text = "Created:";
        // 
        // textBoxProjectName
        // 
        textBoxProjectName.Dock = DockStyle.Top;
        textBoxProjectName.Location = new Point(5, 20);
        textBoxProjectName.Name = "textBoxProjectName";
        textBoxProjectName.Size = new Size(244, 23);
        textBoxProjectName.TabIndex = 1;
        // 
        // labelName
        // 
        labelName.AutoSize = true;
        labelName.Dock = DockStyle.Top;
        labelName.Location = new Point(5, 5);
        labelName.Name = "labelName";
        labelName.Size = new Size(42, 15);
        labelName.TabIndex = 0;
        labelName.Text = "Name:";
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
        mainPanel.BackColor = SystemColors.AppWorkspace;
        mainPanel.Dock = DockStyle.Fill;
        mainPanel.Location = new Point(0, 0);
        mainPanel.Name = "mainPanel";
        mainPanel.Size = new Size(1035, 759);
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
        // toolStrip1
        // 
        toolStrip1.ImageScalingSize = new Size(24, 24);
        toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonNewProject, toolStripButtonOpenProject, toolStripButtonSaveProject, toolStripButtonSaveProjectAs, toolStripSeparator5, toolStripButtonExport, toolStripButtonMetadata, toolStripButtonSecuritySettings, toolStripSeparator8, toolStripButtonAddPdf, toolStripButtonDeletePdf, toolStripButtonCollapse, toolStripButtonExpand, toolStripSeparator6, toolStripButtonUndo, toolStripButtonRedo, toolStripSeparator7 });
        toolStrip1.Location = new Point(0, 24);
        toolStrip1.Name = "toolStrip1";
        toolStrip1.Size = new Size(1293, 31);
        toolStrip1.TabIndex = 3;
        toolStrip1.Text = "toolStrip1";
        // 
        // toolStripButtonNewProject
        // 
        toolStripButtonNewProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButtonNewProject.Image = Properties.Resources._new;
        toolStripButtonNewProject.ImageTransparentColor = Color.Magenta;
        toolStripButtonNewProject.Name = "toolStripButtonNewProject";
        toolStripButtonNewProject.Size = new Size(28, 28);
        toolStripButtonNewProject.Text = "toolStripButton1";
        toolStripButtonNewProject.Click += newProjectToolStripMenuItem_Click;
        // 
        // toolStripButtonOpenProject
        // 
        toolStripButtonOpenProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButtonOpenProject.Image = Properties.Resources.open;
        toolStripButtonOpenProject.ImageTransparentColor = Color.Magenta;
        toolStripButtonOpenProject.Name = "toolStripButtonOpenProject";
        toolStripButtonOpenProject.Size = new Size(28, 28);
        toolStripButtonOpenProject.Text = "toolStripButton1";
        toolStripButtonOpenProject.Click += loadProjectToolStripMenuItem_Click;
        // 
        // toolStripButtonSaveProject
        // 
        toolStripButtonSaveProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButtonSaveProject.Image = Properties.Resources.save;
        toolStripButtonSaveProject.ImageTransparentColor = Color.Magenta;
        toolStripButtonSaveProject.Name = "toolStripButtonSaveProject";
        toolStripButtonSaveProject.Size = new Size(28, 28);
        toolStripButtonSaveProject.Text = "toolStripButton2";
        toolStripButtonSaveProject.Click += SaveProjectToolStripMenuItem_Click;
        // 
        // toolStripButtonSaveProjectAs
        // 
        toolStripButtonSaveProjectAs.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButtonSaveProjectAs.Image = Properties.Resources.save_as;
        toolStripButtonSaveProjectAs.ImageTransparentColor = Color.Magenta;
        toolStripButtonSaveProjectAs.Name = "toolStripButtonSaveProjectAs";
        toolStripButtonSaveProjectAs.Size = new Size(28, 28);
        toolStripButtonSaveProjectAs.Text = "toolStripButton3";
        toolStripButtonSaveProjectAs.Click += SaveProjectAsToolStripMenuItem_Click;
        // 
        // toolStripSeparator5
        // 
        toolStripSeparator5.Name = "toolStripSeparator5";
        toolStripSeparator5.Size = new Size(6, 31);
        // 
        // toolStripButtonExport
        // 
        toolStripButtonExport.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButtonExport.Image = Properties.Resources.export;
        toolStripButtonExport.ImageTransparentColor = Color.Magenta;
        toolStripButtonExport.Name = "toolStripButtonExport";
        toolStripButtonExport.Size = new Size(28, 28);
        toolStripButtonExport.Text = "toolStripButton1";
        toolStripButtonExport.Click += SaveMergedPDFToolStripMenuItem1_Click;
        // 
        // toolStripButtonMetadata
        // 
        toolStripButtonMetadata.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButtonMetadata.Image = Properties.Resources.metadata;
        toolStripButtonMetadata.ImageTransparentColor = Color.Magenta;
        toolStripButtonMetadata.Name = "toolStripButtonMetadata";
        toolStripButtonMetadata.Size = new Size(28, 28);
        toolStripButtonMetadata.Text = "toolStripButton2";
        toolStripButtonMetadata.Click += editMetadataForMergedPDFToolStripMenuItem_Click;
        // 
        // toolStripButtonSecuritySettings
        // 
        toolStripButtonSecuritySettings.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButtonSecuritySettings.Image = Properties.Resources.security;
        toolStripButtonSecuritySettings.ImageTransparentColor = Color.Magenta;
        toolStripButtonSecuritySettings.Name = "toolStripButtonSecuritySettings";
        toolStripButtonSecuritySettings.Size = new Size(28, 28);
        toolStripButtonSecuritySettings.Text = "toolStripButton1";
        toolStripButtonSecuritySettings.Click += ToolStripButtonSecuritySettings_Click;
        // 
        // toolStripSeparator8
        // 
        toolStripSeparator8.Name = "toolStripSeparator8";
        toolStripSeparator8.Size = new Size(6, 31);
        // 
        // toolStripButtonAddPdf
        // 
        toolStripButtonAddPdf.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButtonAddPdf.Image = Properties.Resources.add;
        toolStripButtonAddPdf.ImageTransparentColor = Color.Magenta;
        toolStripButtonAddPdf.Name = "toolStripButtonAddPdf";
        toolStripButtonAddPdf.Size = new Size(28, 28);
        toolStripButtonAddPdf.Text = "toolStripButton1";
        toolStripButtonAddPdf.Click += ButtonAddPdf_Click;
        // 
        // toolStripButtonDeletePdf
        // 
        toolStripButtonDeletePdf.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButtonDeletePdf.Image = Properties.Resources.delete;
        toolStripButtonDeletePdf.ImageTransparentColor = Color.Magenta;
        toolStripButtonDeletePdf.Name = "toolStripButtonDeletePdf";
        toolStripButtonDeletePdf.Size = new Size(28, 28);
        toolStripButtonDeletePdf.Text = "toolStripButton2";
        toolStripButtonDeletePdf.Click += ButtonRemovePdf_Click;
        // 
        // toolStripButtonCollapse
        // 
        toolStripButtonCollapse.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButtonCollapse.Image = Properties.Resources.collapse;
        toolStripButtonCollapse.ImageTransparentColor = Color.Magenta;
        toolStripButtonCollapse.Name = "toolStripButtonCollapse";
        toolStripButtonCollapse.Size = new Size(28, 28);
        toolStripButtonCollapse.Text = "toolStripButton4";
        toolStripButtonCollapse.Click += ToolStripButtonCollapse_Click;
        // 
        // toolStripButtonExpand
        // 
        toolStripButtonExpand.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButtonExpand.Image = Properties.Resources.expand;
        toolStripButtonExpand.ImageTransparentColor = Color.Magenta;
        toolStripButtonExpand.Name = "toolStripButtonExpand";
        toolStripButtonExpand.Size = new Size(28, 28);
        toolStripButtonExpand.Text = "toolStripButton3";
        toolStripButtonExpand.Click += ToolStripButtonExpand_Click;
        // 
        // toolStripSeparator6
        // 
        toolStripSeparator6.Name = "toolStripSeparator6";
        toolStripSeparator6.Size = new Size(6, 31);
        // 
        // toolStripButtonUndo
        // 
        toolStripButtonUndo.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButtonUndo.Image = Properties.Resources.undo;
        toolStripButtonUndo.ImageTransparentColor = Color.Magenta;
        toolStripButtonUndo.Name = "toolStripButtonUndo";
        toolStripButtonUndo.Size = new Size(28, 28);
        toolStripButtonUndo.Text = "toolStripButton5";
        toolStripButtonUndo.Click += UndoToolStripMenuItem_Click;
        // 
        // toolStripButtonRedo
        // 
        toolStripButtonRedo.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButtonRedo.Image = Properties.Resources.redo;
        toolStripButtonRedo.ImageTransparentColor = Color.Magenta;
        toolStripButtonRedo.Name = "toolStripButtonRedo";
        toolStripButtonRedo.Size = new Size(28, 28);
        toolStripButtonRedo.Text = "toolStripButton6";
        toolStripButtonRedo.Click += RedoToolStripMenuItem_Click;
        // 
        // toolStripSeparator7
        // 
        toolStripSeparator7.Name = "toolStripSeparator7";
        toolStripSeparator7.Size = new Size(6, 31);
        // 
        // MainForm
        // 
        AllowDrop = true;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1293, 817);
        Controls.Add(toolStrip1);
        Controls.Add(statusStrip1);
        Controls.Add(splitContainer1);
        Controls.Add(menuStrip1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        KeyPreview = true;
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        Text = "PDF Merger";
        FormClosing += MainForm_FormClosing;
        Shown += MainForm_Shown;
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
        ((ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        sidebarPanel1.ResumeLayout(false);
        panelPreviewSize.ResumeLayout(false);
        panelPreviewSize.PerformLayout();
        ((ISupportInitialize)trackBarPreviewSize).EndInit();
        panelListOfDocs.ResumeLayout(false);
        panelProject.ResumeLayout(false);
        panelProject.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        toolStrip1.ResumeLayout(false);
        toolStrip1.PerformLayout();
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
    private Panel panelPreviewSize;
    private TrackBar trackBarPreviewSize;
    private SidebarButton sbPreviewSize;
    private ListView pdfDocList;
    private Panel panelProject;
    private TextBox textBoxProjectName;
    private Label labelName;
    private SidebarButton sbProject;
    private Label labelCreated;
    private ToolStripMenuItem licensesToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripMenuItem recentProjectsToolStripMenuItem;
    private ToolStripMenuItem undoToolStripMenuItem;
    private ToolStripMenuItem redoToolStripMenuItem;
    private ToolStripMenuItem checkForUpdateToolStripMenuItem;
    private ToolStrip toolStrip1;
    private ToolStripButton toolStripButtonNewProject;
    private ToolStripButton toolStripButtonOpenProject;
    private ToolStripButton toolStripButtonSaveProject;
    private ToolStripButton toolStripButtonSaveProjectAs;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripButton toolStripButtonAddPdf;
    private ToolStripButton toolStripButtonDeletePdf;
    private ToolStripButton toolStripButtonExpand;
    private ToolStripButton toolStripButtonCollapse;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripButton toolStripButtonUndo;
    private ToolStripButton toolStripButtonRedo;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripButton toolStripButtonExport;
    private ToolStripButton toolStripButtonMetadata;
    private ToolStripSeparator toolStripSeparator8;
    private ToolStripButton toolStripButtonSecuritySettings;
    private ToolStripMenuItem editSecuritySettingsForMergedPDFToolStripMenuItem;
    private ToolStripMenuItem addImageToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator9;
}
