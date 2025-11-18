using PdfMerger.Classes;
using PdfMerger.Config;
using PdfMerger.DocumentInfo;
using PdfMerger.UndoRedo;
using PdfSharp.Pdf.IO;
using System.Runtime.CompilerServices;

namespace PdfMerger;

public partial class MainForm : Form
{

    private PdfPage? m_draggedBox = null;
    private PdfPage? m_selectedBox = null;
    private bool m_isDragging = false;
    private Point dragStartPoint;
    private const int DragThreshold = 5;

    private FormsTimer saveConfigTimer = new() { Interval = 500 };
    private FormsTimer redrawConfigTimer = new() { Interval = 100 };

    private DateTime m_Created = DateTime.UtcNow;
    private string m_LastOutputPath = string.Empty;
    private bool m_LastSaveWasBundle = false;
    private MetaData m_MetaData = new();
    private RecentProjects m_recentProjects = new();
    private UndoRedoManager m_history = new();
    private PdfProjectState m_currentState = new();
    private ToolStripMenuItem m_ClearItem = new ToolStripMenuItem(Properties.Strings.ClearRecentProjects);
    private ToolStripMenuItem m_EmptyItem = new ToolStripMenuItem(Properties.Strings.NoRecentProjects)
    {
        Enabled = false
    };

    public MainForm()
    {
        Log.Information("start MainForm");
        InitializeComponent();

        if (MyPdfRenderer.MaxWidth > trackBarPreviewSize.Minimum && MyPdfRenderer.MaxWidth < trackBarPreviewSize.Maximum)
        {
            trackBarPreviewSize.Value = MyPdfRenderer.MaxWidth;
        }

        saveConfigTimer.Tick += SaveConfigTimer_Tick;
        redrawConfigTimer.Tick += RedrawConfigTimer_Tick;


        pdfDocList.SmallImageList = ColorList.GetImageList();
        pdfDocList.Columns.Add("", 32);
        pdfDocList.Columns.Add(Properties.Strings.PdfFile, 300);

        SetCreated();
        textBoxProjectName.Text = "Untitled";

        m_LastSaveWasBundle = ConfigManager.Config.SaveAsBundle;
        toolStripStatusLabelVersion.Text = $"Version: {GetVersion()}";
        SetStatus("");

        sbListOfDocs.Expanded = ConfigManager.Config.SidebarListOfDocsExpanded;
        sbPreviewSize.Expanded = ConfigManager.Config.SidebarPreviewSizeExpanded;
        sbProject.Expanded = ConfigManager.Config.SidebarProjectExpanded;

        m_ClearItem.Click += ClearItem_Click;
        UpdateRecentProjectsMenu();
        ReloadUIStrings();
        UpdateMenuStripButtons();

        KeyPreview = true;
    }

    private void ClearItem_Click(object? sender, EventArgs e)
    {
        m_recentProjects.Items.Clear();
        m_recentProjects.Save();
        UpdateRecentProjectsMenu();
    }

    private void UpdateMenuStripButtons()
    {
        undoToolStripMenuItem.Enabled = m_history.CanUndo;
        redoToolStripMenuItem.Enabled = m_history.CanRedo;

        toolStripButtonExpand.Enabled = false;
        toolStripButtonCollapse.Enabled = false;
        toolStripButtonDeletePdf.Enabled = false; 

        if (m_selectedBox is not null)
        {
            toolStripButtonDeletePdf.Enabled = true;
            if (m_selectedBox.IsStack)
            {
                toolStripButtonExpand.Enabled = true;
            }
            else
            {
                toolStripButtonCollapse.Enabled = true;
            }
        }

    }

    private void SetCreated()
    {
        labelCreated.Text = "Created: " + m_Created.ToLocalTime().ToString();
    }

    private void RedrawConfigTimer_Tick(object? sender, EventArgs e)
    {
        foreach (Control ctrl in mainPanel.Controls)
        {
            if (ctrl is PdfPage pb)
            {
                // Re-render the page at new size
                pb.Width = MyPdfRenderer.MaxWidth;
                pb.Height = MyPdfRenderer.MaxHeight;
                pb.Redraw();
            }
        }
    }

    private void SaveConfigTimer_Tick(object? sender, EventArgs e)
    {
        saveConfigTimer.Stop();
        ConfigManager.Save();
    }

    private void MainForm_DragEnter(object? sender, DragEventArgs e)
    {
        if (e.Data is null)
        {
            return;
        }

        if (e.Data.GetDataPresent(DataFormats.FileDrop)) // Check if the dragged item is a file
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop)!;
            // Only allow if at least one PDF
            if (files.Any(f => Path.GetExtension(f).Equals(".pdf", StringComparison.OrdinalIgnoreCase)))
            {
                e.Effect = DragDropEffects.Copy;
                return;
            }
        }

        e.Effect = DragDropEffects.None;
    }


    private void MainForm_DragDrop(object? sender, DragEventArgs e)
    {
        if (e.Data is null)
        {
            return;
        }

        var isFileDrop = e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false;
        if (!isFileDrop)
        {
            return;
        }

        var data = e.Data?.GetData(DataFormats.FileDrop);
        if (data is null)
        {
            return;
        }
        var files = data as string[];
        if (files is null)
        {
            return;
        }

        AddFiles(files);
    }


    private async void AddFiles(string[] files)
    {
        using (var loadingForm = new Waiting())
        {
            SaveCurrentState();
            loadingForm.Show(this);
            loadingForm.SetStatus(Properties.Strings.WaitingPdfs);
            loadingForm.CenterTo(this);
            loadingForm.Refresh();

            var progressDocList = new Progress<ListViewItem>(item =>
            {
                pdfDocList.Items.Add(item);
            });

            var progressMainPanel = new Progress<(PdfPage page, int index)>(item =>
            {
                mainPanel.Controls.Add(item.page);
                if (item.index >= 0)
                {
                    mainPanel.Controls.SetChildIndex(item.page, item.index);
                }

            });

            await AddFilesAsync(files, progressDocList, progressMainPanel);


            UpdateProjectStateFromUI();
            loadingForm.Close();
        }
    }


    private async Task AddFilesAsync(string[] files, IProgress<ListViewItem> progressDocList, IProgress<(PdfPage, int)> progressPdfPage)
    {
        await Task.Run(() =>
        {
            foreach (var file in files)
            {
                if (!Path.GetExtension(file).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var idx = ColorList.GetColorIndexForPdf(file);
                string pdfName = Path.GetFileName(file);
                var item = new ListViewItem()
                {
                    ImageIndex = idx,
                };
                item.SubItems.Add(pdfName);
                item.Tag = file;
                progressDocList.Report(item);



                using var doc = PdfReader.Open(file, PdfDocumentOpenMode.Import);
                {
                    m_MetaData.AddAuhtorFromDocument(doc.Info.Author);
                    m_MetaData.AddTitleFromDocument(doc.Info.Title);
                    m_MetaData.AddCreatorFromDocument(doc.Info.Creator);
                    m_MetaData.AddSubjectFromDocument(doc.Info.Subject);
                    m_MetaData.AddKeywordsFromDocument(doc.Info.Keywords);

                    var docInfo = new DocumentData
                    {
                        FilePath = file,
                        PageCount = doc.PageCount,
                        Title = doc.Info.Title,
                        Creator = doc.Info.Creator,
                        Author = doc.Info.Author,
                        LastModified = System.IO.File.GetLastWriteTime(file),
                        CreationTime = System.IO.File.GetCreationTime(file)
                    };
                    DocumentRegistry.AddOrUpdate(docInfo);
                }

                LoadPdfPages(file, 
                    ConfigManager.Config.LoadEveryPageWhenAddingPdf, 
                    progressPdfPage);
            }
        });
    }


    private void MainForm_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            DeleteSelectedPage(sender, EventArgs.Empty);
            e.Handled = true;
        }
        else if (e.Control && e.KeyCode == Keys.Z)
        {
            undoToolStripMenuItem.PerformClick();
        }
        else if (e.Control && e.KeyCode == Keys.Y)
        {
            redoToolStripMenuItem.PerformClick();
        }
        else if (e.Control && e.KeyCode == Keys.N)
        {
            newProjectToolStripMenuItem.PerformClick();
        }
        else if (e.Control && e.KeyCode == Keys.O)
        {
            loadProjectToolStripMenuItem.PerformClick();
        }
        else if (e.Control && e.KeyCode == Keys.S)
        {
            saveProjectToolStripMenuItem.PerformClick();
        }
        else if (e.Control && e.KeyCode == Keys.U)
        {
            saveProjectAsToolStripMenuItem.PerformClick();
        }
        else if (e.Control && e.KeyCode == Keys.E)
        {
            saveMergedPDFToolStripMenuItem1.PerformClick();
        }
        else if (e.Control && e.KeyCode == Keys.Q)
        {
            closeToolStripMenuItem.PerformClick();
        }
    }

    private void Slider_Scroll(object? sender, EventArgs e)
    {
        if (sender is System.Windows.Forms.TrackBar trackBar)
        {
            MyPdfRenderer.SetNewWidth(trackBar.Value);
            saveConfigTimer.Stop();
            saveConfigTimer.Start();

            redrawConfigTimer.Stop();
            redrawConfigTimer.Start();
        }
    }

    private void DeleteSelectedPage(object? sender, EventArgs e)
    {
        if (m_selectedBox is null)
        {
            return;
        }

        SaveCurrentState();

        DeleteSelectedPage();
        mainPanel.Controls.Remove(m_selectedBox);  // Remove PdfPage from panel
        m_selectedBox?.Dispose(); // Free resources
        SelectPage(null);

        UpdateProjectStateFromUI();
    }





    private void LoadPdfPages(string filePath, bool loadEveryPage, 
        IProgress<(PdfPage, int)> progressPdfPage,
        IProgress<bool>? progressFinished= null,
        int index = -1)
    {
        if (loadEveryPage)
        {
            using var doc = new PDFiumSharp.PdfDocument(filePath);

            for (int i = 0; i < doc.Pages.Count; i++)
            {
                var pb = CreatePdfPage(filePath, i);
                progressPdfPage.Report((pb, index));

                if (index >= 0)
                {
                    index++;
                }
            }
        }
        else
        {
            var pb = CreatePdfPage(filePath, -1);
            progressPdfPage.Report((pb, index));
        }

        progressFinished?.Report(true);
    }


    private void Pb_MouseDown(object? sender, MouseEventArgs e)
    {
        if (sender is PdfPage pb && e.Button == MouseButtons.Left)
        {
            m_draggedBox = pb;
            dragStartPoint = e.Location;
            m_isDragging = false; // not dragging yet
            pb.DoDragDrop(pb, DragDropEffects.Move);
            SelectPage(pb);
        }
    }


    private bool ReachedDragThreshold(MouseEventArgs e)
    {
        if (Math.Abs(e.X - dragStartPoint.X) > DragThreshold)
        {
            return true;
        }


        if (Math.Abs(e.Y - dragStartPoint.Y) > DragThreshold)
        {
            return true;
        }

        return false;
    }

    private void Pb_MouseMove(object? sender, MouseEventArgs e)
    {
        if (m_draggedBox is not null && e.Button == MouseButtons.Left)
        {
            // start dragging only if mouse moved more than a threshold
            if (!m_isDragging && ReachedDragThreshold(e))
            {
                m_isDragging = true;
                m_draggedBox.DoDragDrop(m_draggedBox, DragDropEffects.Move);
            }
        }
    }

    private void SelectPage(PdfPage? pb)
    {
        if (m_selectedBox != null && !m_selectedBox.IsDisposed)
        {
            m_selectedBox.Selected = false;
        }
        
        m_selectedBox = pb;
        if (m_selectedBox is not null)
        {
            m_selectedBox.Selected = true;
        }


        UpdateMenuStripButtons();
    }

    private void Panel_DragEnter(object? sender, DragEventArgs e)
    {
        if (e.Data is null)
        {
            return;
        }
        else if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            MainForm_DragEnter(sender, e);
        }
        else if (e.Data.GetDataPresent(typeof(PdfPage)))
        {
            // internal drag (PictureBox)
            e.Effect = DragDropEffects.Move; // internal reorder
        }
        else
        {
            e.Effect = DragDropEffects.None;
        }
    }


    private void Panel_DragDrop(object? sender, DragEventArgs e)
    {
        if (e.Data is null)
        {
            return;
        }
        else if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            MainForm_DragDrop(sender, e);
        }
        else if (e.Data.GetDataPresent(typeof(PdfPage)))
        {

            if (m_draggedBox is null)
            {
                return;
            }

            SaveCurrentState();
            var pos = mainPanel.PointToClient(new Point(e.X, e.Y));
            var target = mainPanel.Controls
                .OfType<PdfPage>()
                .FirstOrDefault(pb => pb.Bounds.Contains(pos));

            if (target is null || target == m_draggedBox)
            {
                return;
            }

            int oldIndex = mainPanel.Controls.GetChildIndex(m_draggedBox);
            int newIndex = mainPanel.Controls.GetChildIndex(target);

            mainPanel.Controls.SetChildIndex(m_draggedBox, newIndex);
            mainPanel.Invalidate();

            UpdateProjectStateFromUI();
        }
    }



    private void loadPDFFileToolStripMenuItem_Click(object sender, EventArgs e) => AddPdfFiles();

    private void saveMergedPDFToolStripMenuItem_Click(object sender, EventArgs e) => MergePdfs();

    private void closeToolStripMenuItem_Click(object sender, EventArgs e) => Close();

    private void removeSelectedPDFToolStripMenuItem_Click(object sender, EventArgs e) => DeleteSelectedPage();
    private void buttonAddPdf_Click(object sender, EventArgs e) => AddPdfFiles();

    private void buttonRemovePdf_Click(object sender, EventArgs e) => DeleteSelectedPage();

    private void buttonSavePdf_Click(object sender, EventArgs e) => MergePdfs();
    private void saveMergedPDFToolStripMenuItem1_Click(object sender, EventArgs e) => MergePdfs();
    private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => new AboutBox().ShowDialog();


    private void AddPdfFiles()
    {
        using var ofd = new OpenFileDialog
        {
            Filter = Properties.Strings.PdfFiles + "|*.pdf",
            Multiselect = true
        };

        if (ofd.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        AddFiles(ofd.FileNames);
    }


    private async void MergePdfs()
    {
        using var sfd = new SaveFileDialog
        {
            Filter = $"{Properties.Strings.PdfFiles}|*.pdf|{Properties.Strings.AllFiles}|*.*"
        };

        if (sfd.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        bool res = false;
        string msg = "";

        using (var loadingForm = new Waiting())
        {
            loadingForm.Show(this);
            loadingForm.SetStatus(Properties.Strings.MergingPdfs);
            loadingForm.CenterTo(this);
            loadingForm.Refresh();

            var pages = mainPanel.Controls
                .OfType<PdfPage>();

            await Task.Run(() =>
            {
                (res, msg) = MyMerger.WriteMergedPdf(pages, sfd.FileName, m_MetaData);
            });
            loadingForm.Close();
        }

        if (res)
        {
            MessageBox.Show(Properties.Strings.PDFMergedSuccess,
                Properties.Strings.Done,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show($"{Properties.Strings.ErrorMergingPdfMsg}\r\n{msg}",
                Properties.Strings.ErrorMergingPdf,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }


    private void DeleteSelectedPage()
    {
        if (m_selectedBox is null)
        {
            return;
        }

        if (m_selectedBox is PdfPage)
        {
            DeletePage(m_selectedBox);
        }
        SelectPage(null);
    }


    private void DeletePage(PdfPage page)
    {

        SaveCurrentState();
        if (page.IsStack)
        {
            ListViewItem? toRemove = null;
            foreach (ListViewItem i in pdfDocList.Items)
            {
                if (0 == string.Compare(i.Tag as string, page.FilePath, true))
                {
                    toRemove = i;
                    break;
                }
            }
            if (null != toRemove)
            {
                pdfDocList.Items.Remove(toRemove);
            }
        }

        mainPanel.Controls.Remove(page);
        page.Dispose();

        UpdateProjectStateFromUI();
    }


    private void MainForm_LocationChanged(object sender, EventArgs e)
    {
        ConfigManager.Config.WindowX = this.Left;
        ConfigManager.Config.WindowY = this.Top;
        saveConfigTimer.Stop();
        saveConfigTimer.Start();
    }

    private void MainForm_ResizeEnd(object sender, EventArgs e)
    {
        ConfigManager.Config.WindowWidth = this.Width;
        ConfigManager.Config.WindowHeight = this.Height;
        saveConfigTimer.Stop();
        saveConfigTimer.Start();
    }

    private void newProjectToolStripMenuItem_Click(object sender, EventArgs e) => NewProject();

    private void NewProject()
    {
        m_draggedBox = null;
        SelectPage(null);
        m_isDragging = false;
        mainPanel.Controls.Clear();
        pdfDocList.Clear();
        m_LastOutputPath = "";
        m_LastSaveWasBundle = ConfigManager.Config.SaveAsBundle;

        // set new values
        m_Created = DateTime.UtcNow;
        textBoxProjectName.Text = "Untiteld";
        SetCreated();
        m_MetaData = new();


        m_history = new();
        m_currentState = new();
        DocumentRegistry.Clear();
        UpdateMenuStripButtons();
    }

    private async void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog
        {
            Filter = $"{Properties.Strings.PDFMergerFiles}|*.pdfmerger;*.zpdfmerger|{Properties.Strings.AllFiles}|*.*",
            Multiselect = false
        };

        if (ofd.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        if (!File.Exists(ofd.FileName))
        {
            MessageBox.Show(Properties.Strings.ErrorLoadingProject,
                Properties.Strings.Error,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        if (!await LoadProject(ofd.FileName))
        {
            MessageBox.Show(Properties.Strings.ErrorLoadingProject,
                Properties.Strings.Error,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }


    public async Task<bool> LoadProject(string path)
    {
        using (var loadingForm = new Waiting())
        {
            loadingForm.Show(this);
            loadingForm.SetStatus(Properties.Strings.LoadingProject);
            loadingForm.CenterTo(this);
            loadingForm.Refresh();

            ProjectConfig? proj = null;
            string baseDir = "";

            await Task.Run(() =>
            {
                (proj, baseDir) = ProjectConfigManager.Load(path);
            });

            if (proj is null)
            {
                return false;
            }

            NewProject();
            m_Created = proj.Created;
            textBoxProjectName.Text = proj.ProjectName;
            SetCreated();


            List<string> missingFiles = new();
            foreach (var entry in proj.PdfFiles)
            {
                if (!File.Exists(entry.FilePathAbsolute))
                {
                    entry.FilePathAbsolute = Path.GetFullPath(Path.Combine(baseDir, entry.FilePathRelative));
                }
            }


            IProgress<ListViewItem> progressDocList = new Progress<ListViewItem>(item =>
            {
                pdfDocList.Items.Add(item);
            });

            IProgress<PdfPage> progressMainPanel = new Progress<PdfPage>(item =>
            {
                mainPanel.Controls.Add(item);
            });

            await Task.Run(() =>
            {

                foreach (var filePath in proj.PdfFiles
                .Select(r => r.FilePathAbsolute)
                .Distinct())
                {
                    if (!File.Exists(filePath))
                    {
                        missingFiles.Add(filePath);
                        continue;
                    }

                    var idx = ColorList.GetColorIndexForPdf(filePath);
                    string pdfName = Path.GetFileName(filePath);
                    var item = new ListViewItem()
                    {
                        ImageIndex = idx,
                    };
                    item.SubItems.Add(pdfName);
                    progressDocList.Report(item);
                }


                foreach (var entry in proj.PdfFiles)
                {
                    var pb = CreatePdfPage(entry.FilePathAbsolute, entry.PageNumber);
                    progressMainPanel.Report(pb);
                }
            });


            m_recentProjects.Add(path);
            UpdateRecentProjectsMenu();
            UpdateProjectStateFromUI();
            loadingForm.Close();
        }

        return true;
    }


    private PdfPage CreatePdfPage(string path, int pageNumber)
    {
        var pb = new PdfPage(path, pageNumber);
        pb.MouseDown += Pb_MouseDown;
        pb.MouseMove += Pb_MouseMove;
        return pb;
    }

    private void CollapseTiles(object? sender, EventArgs e)
    {
        var page = sender as PdfPage;
        if (page is null)
        {
            return;
        }

        SaveCurrentState();

        try
        {
            int index = mainPanel.Controls.GetChildIndex(page);
            var newPage = CreatePdfPage(page.FilePath, -1);

            // remove all panels
            var toRemoveList = mainPanel.Controls
                .OfType<PdfPage>()
                .Where(r => r.FilePath.Equals(page.FilePath)).ToArray();

            foreach (var p in toRemoveList)
            {
                mainPanel.Controls.Remove(p);
                p.Dispose();
            }


            mainPanel.Controls.Add(newPage);
            mainPanel.Controls.SetChildIndex(newPage, index);

            UpdateProjectStateFromUI();
            SelectPage(newPage);
        }
        catch(Exception ex)
        {
            Log.Error(ex, "excpetion in Pb_CollapseTiles");
        }
    }


    private void ExpandTiles(object? sender, EventArgs e)
    {
        var page = sender as PdfPage;
        if (page is null)
        {
            return;
        }

        try
        {
            SaveCurrentState();

            int index = mainPanel.Controls.GetChildIndex(page);

            var progressMainPanel = new Progress<(PdfPage page, int index)>(item =>
            {
                mainPanel.Controls.Add(item.page);
                if (item.index >= 0)
                {
                    mainPanel.Controls.SetChildIndex(item.page, item.index);
                }

            });

            var progressFinished = new Progress<bool>(item =>
            {
                UpdateProjectStateFromUI();
            });


            mainPanel.Controls.Remove(page);
            page.Dispose();

            LoadPdfPages(page.FilePath, true,
                progressMainPanel,
                progressFinished,
                index);


            SelectPage(null);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "excpetion in Pb_ExpandTiles");
        }
    }

    private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e) => SaveProject(false);
    private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e) => SaveProject(true);
    private async void SaveProject(bool forceNewFile)
    {
        string outputPath = m_LastOutputPath;
        bool saveAsBundle = m_LastSaveWasBundle;
        bool addToRecentProjects = false;
        if (string.IsNullOrWhiteSpace(outputPath) || forceNewFile)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = $"{Properties.Strings.PDFMergerFile}|*.pdfmerger|{Properties.Strings.PdfMergerBundleFile}|*.zpdfmerger|{Properties.Strings.AllFiles}|*.*"
            };

            if (saveAsBundle)
            {
                sfd.FilterIndex = 2;
            }

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            outputPath = sfd.FileName;
            saveAsBundle = (sfd.FilterIndex == 2);
            addToRecentProjects = true;
        }


        var pages = mainPanel.Controls
        .OfType<PdfPage>();


        bool res = false;

        using (var waitingForm = new Waiting())
        {
            waitingForm.Show(this);
            waitingForm.SetStatus(Properties.Strings.SavingProject);
            waitingForm.CenterTo(this);
            waitingForm.Refresh();

            await Task.Run(() =>
            {
                res = ProjectConfigManager.Save(textBoxProjectName.Text, m_Created, pages, outputPath, saveAsBundle);
            });

            if (addToRecentProjects)
            {
                m_recentProjects.Add(outputPath);
                UpdateRecentProjectsMenu();
            }
            waitingForm.Close();
        }


        if (res)
        {
            m_LastOutputPath = outputPath;
            m_LastSaveWasBundle = saveAsBundle;
            MessageBox.Show(Properties.Strings.ProjectSaveSuccess,
                Properties.Strings.Done,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show(Properties.Strings.ErrorSavingProject,
                Properties.Strings.Error,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }


    private static string GetVersion()
    {
        return Assembly.GetExecutingAssembly()
                    .GetName()
                    .Version?
                    .ToString() ?? "";
    }

    private void toolStripStatusLabel1_Click(object sender, EventArgs e) => new AboutBox().ShowDialog();

    public void SetStatus(string text)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action(() => SetStatus(text)));
            return;
        }
        toolStripStatusLabelFirst.Text = text;
    }

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var s = new SettingsForm();
        s.ShowDialog();


        if (null != ConfigManager.Config.Language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ConfigManager.Config.Language);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigManager.Config.Language);
        }
        else
        {
            Thread.CurrentThread.CurrentCulture = Program.DefaultCurrentCulture;
            Thread.CurrentThread.CurrentUICulture = Program.DefaultCurrentUICulture;
        }

        ReloadUIStrings();
    }

    private void editMetadataForMergedPDFToolStripMenuItem_Click(object sender, EventArgs e) => new MetadataEditor(m_MetaData).ShowDialog();

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        ConfigManager.Config.SidebarListOfDocsExpanded = sbListOfDocs.Expanded;
        ConfigManager.Config.SidebarPreviewSizeExpanded = sbPreviewSize.Expanded;
        ConfigManager.Config.SidebarProjectExpanded = sbProject.Expanded;
        ConfigManager.Save();


        Log.Information("closing MainForm");
    }

    private void licensesToolStripMenuItem_Click(object sender, EventArgs e) => new LicenseForm().ShowDialog(this);

    private void UpdateRecentProjectsMenu()
    {
        recentProjectsToolStripMenuItem.DropDownItems.Clear();

        if (m_recentProjects.Items.Count == 0)
        {
            recentProjectsToolStripMenuItem.DropDownItems.Add(m_EmptyItem);
            return;
        }

        foreach (var path in m_recentProjects.Items)
        {
            string fileName = Path.GetFileName(path);

            var item = new ToolStripMenuItem(fileName)
            {
                ToolTipText = path // show full path on hover
            };

            item.Click += async (s, e) =>
            {
                if (path is null)
                {
                    return;
                }

                if (File.Exists(path))
                {
                    await LoadProject(path);
                }
                else
                {
                    MessageBox.Show($"{Properties.Strings.ErrorFileNotFound}: {path}",
                        Properties.Strings.Error,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            };
            recentProjectsToolStripMenuItem.DropDownItems.Add(item);
            recentProjectsToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            recentProjectsToolStripMenuItem.DropDownItems.Add(m_ClearItem);
        }
    }


    private void ReloadUIStrings()
    {
        fileToolStripMenuItem.Text = Properties.Strings.FileMenu;
        newProjectToolStripMenuItem.Text = Properties.Strings.FileMenuNewProject;
        loadProjectToolStripMenuItem.Text = Properties.Strings.FileMenuLoadProject;
        saveProjectToolStripMenuItem.Text = Properties.Strings.FileMenuSaveProject;
        saveProjectAsToolStripMenuItem.Text = Properties.Strings.FileMenuSaveProjectAs;
        saveMergedPDFToolStripMenuItem1.Text = Properties.Strings.FileMenuExportMergedPdf;
        settingsToolStripMenuItem.Text = Properties.Strings.FileMenuSettings;
        recentProjectsToolStripMenuItem.Text = Properties.Strings.FileMenuRecentProjects;
        closeToolStripMenuItem.Text = Properties.Strings.FileMenuClose;
        projectToolStripMenuItem.Text = Properties.Strings.ProjectMenu;
        undoToolStripMenuItem.Text = Properties.Strings.ProjectMenuUndo;
        redoToolStripMenuItem.Text = Properties.Strings.ProjectMenuRedo;
        loadPDFFileToolStripMenuItem.Text = Properties.Strings.ProjectMenuAddPdf;
        removeSelectedPDFToolStripMenuItem.Text = Properties.Strings.ProjectMenuRemovePdf;
        saveMergedPDFToolStripMenuItem.Text = Properties.Strings.ProjectMenuExportPdf;
        editMetadataForMergedPDFToolStripMenuItem.Text = Properties.Strings.ProjectMenuEditMetadata;
        helpToolStripMenuItem.Text = Properties.Strings.ProjectHelp;
        aboutToolStripMenuItem.Text = Properties.Strings.ProjectHelpAbout;
        licensesToolStripMenuItem.Text = Properties.Strings.ProjectHelpLicenses;
        sbProject.Text = Properties.Strings.SidebarProject;
        sbListOfDocs.Text = Properties.Strings.SidebarListOfDocs;
        sbPreviewSize.Text = Properties.Strings.SidebarPreview;
        labelName.Text = Properties.Strings.LabelName + ":";
        labelCreated.Text = Properties.Strings.LabeCreated + ":";
        m_ClearItem.Text = Properties.Strings.ClearRecentProjects;
        m_EmptyItem.Text = Properties.Strings.NoRecentProjects;
        pdfDocList.Columns[1].Text = Properties.Strings.PdfFile;


        toolStripButtonNewProject.Text = Properties.Strings.FileMenuNewProject;
        toolStripButtonOpenProject.Text = Properties.Strings.FileMenuLoadProject;
        toolStripButtonSaveProject.Text = Properties.Strings.FileMenuSaveProject;
        toolStripButtonSaveProjectAs.Text = Properties.Strings.FileMenuSaveProjectAs;
        toolStripButtonAddPdf.Text = Properties.Strings.ProjectMenuAddPdf;
        toolStripButtonDeletePdf.Text = Properties.Strings.ProjectMenuRemovePdf;
        toolStripButtonUndo.Text = Properties.Strings.ProjectMenuUndo;
        toolStripButtonRedo.Text = Properties.Strings.ProjectMenuRedo;
        toolStripButtonMetadata.Text = Properties.Strings.ProjectMenuEditMetadata;
        toolStripButtonExport.Text = Properties.Strings.ButtonSavePdf;
        toolStripButtonExpand.Text = Properties.Strings.ButtonExpandPages;
        toolStripButtonCollapse.Text = Properties.Strings.ButtonCollapsePages;
    }


    private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        m_currentState = m_history.Undo(m_currentState);
        ApplyStateToUI();
        UpdateMenuStripButtons();
    }

    private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        m_currentState = m_history.Redo(m_currentState);
        ApplyStateToUI();
        UpdateMenuStripButtons();
    }

    private void SaveCurrentState()
    {
        m_history.SaveState(m_currentState);
        UpdateMenuStripButtons();
    }

    private void UpdateProjectStateFromUI()
    {
        m_currentState.PdfPages = mainPanel.Controls
            .OfType<PdfPage>()
            .Select(r => new PdfPageState { FilePath = r.FilePath, PageNumber = r.PageNumber })
            .ToList();

        m_currentState.Title = textBoxProjectName.Text;
    }

    private void ApplyStateToUI()
    {
        mainPanel.Controls.Clear();
        pdfDocList.Items.Clear();

        foreach (var filePath in m_currentState
            .PdfPages
            .Select(r => r.FilePath).Distinct())
        {
            var idx = ColorList.GetColorIndexForPdf(filePath);
            string pdfName = Path.GetFileName(filePath);
            var item = new ListViewItem()
            {
                ImageIndex = idx,
            };
            item.SubItems.Add(pdfName);
            pdfDocList.Items.Add(item);
        }

        foreach (var entry in m_currentState.PdfPages)
        {
            var pb = CreatePdfPage(entry.FilePath, entry.PageNumber);
            mainPanel.Controls.Add(pb);
        }
    }

    private async void MainForm_Shown(object sender, EventArgs e)
    {
        if (Updater.ShouldCheckForUpdate())
        {
            await Updater.CheckForUpdateAsync(false);
        }
    }

    private async void CheckForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
    {
        await Updater.CheckForUpdateAsync(true);
    }

    private void ToolStripButtonCollapse_Click(object sender, EventArgs e) => CollapseTiles(m_selectedBox, new EventArgs());

    private void ToolStripButtonExpand_Click(object sender, EventArgs e) => ExpandTiles(m_selectedBox, new EventArgs());
}

