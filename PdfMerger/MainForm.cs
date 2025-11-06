using PdfMerger.classes;
using PdfMerger.Classes;
using PdfMerger.Config;
using PdfSharp.Pdf.IO;
using Serilog;
using System;
using System.IO;
using System.Reflection;
using FormsTimer = System.Windows.Forms.Timer;

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


    public MainForm()
    {
        Log.Information("start MainForm");
        InitializeComponent();
        trackBarPreviewSize.Value = MyPdfRenderer.MaxWidth;

        saveConfigTimer.Tick += SaveConfigTimer_Tick;
        redrawConfigTimer.Tick += RedrawConfigTimer_Tick;


        pdfDocList.SmallImageList = ColorList.GetImageList();
        pdfDocList.Columns.Add("", 32);
        pdfDocList.Columns.Add("PDF File", 300);

        SetCreated();
        textBoxProjectName.Text = "Untiteld";

        m_LastSaveWasBundle = ConfigManager.Config.SaveAsBundle;
        toolStripStatusLabelVersion.Text = $"Version: {GetVersion()}";
        SetStatus("");

        sbAction.Expanded = ConfigManager.Config.SidebarActionExpanded;
        sbListOfDocs.Expanded = ConfigManager.Config.SidebarListOfDocsExpanded;
        sbPreviewSize.Expanded = ConfigManager.Config.SidebarPreviewSizeExpanded;
        sbProject.Expanded = ConfigManager.Config.SidebarProjectExpanded;

        UpdateRecentProjectsMenu();
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
            loadingForm.Show(this);
            loadingForm.SetStatus("Waiting PDFs...");
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
                }

                LoadPdfPages(file, ConfigManager.Config.LoadEveryPageWhenAddingPdf, progressPdfPage);
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
        if (m_selectedBox == null)
        {
            return;
        }


        DeleteSelectedPage();
        mainPanel.Controls.Remove(m_selectedBox);  // Remove PdfPage from panel
        m_selectedBox?.Dispose(); // Free resources
        m_selectedBox = null;
    }





    private void LoadPdfPages(string filePath, bool loadEveryPage, IProgress<(PdfPage, int)> progressPdfPage, int index = -1)
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
    }


    private void Pb_MouseDown(object? sender, MouseEventArgs e)
    {
        if (sender is PdfPage pb && e.Button == MouseButtons.Left)
        {
            m_draggedBox = pb;
            dragStartPoint = e.Location;
            m_isDragging = false; // not dragging yet
            pb.DoDragDrop(pb, DragDropEffects.Move);
            SelectPictureBox(pb);
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

    private void SelectPictureBox(PdfPage pb)
    {
        if (m_selectedBox != null && !m_selectedBox.IsDisposed)
        {
            m_selectedBox.Selected = false;
        }

        m_selectedBox = pb;
        m_selectedBox.Selected = true;
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
            Filter = "PDF files|*.pdf",
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
            Filter = "PDF files|*.pdf|All files|*.*"
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
            loadingForm.SetStatus("Merging PDFs...");
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
            MessageBox.Show("PDFs merged successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Error merging or saving PDF file.\r\n" + msg, "Error merging/saving PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    private void DeleteSelectedPage()
    {
        if (m_selectedBox == null)
        {
            return;
        }

        if (m_selectedBox is PdfPage)
        {
            DeletePage(m_selectedBox);
        }
        m_selectedBox = null;
    }


    private void DeletePage(PdfPage page)
    {

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
        m_selectedBox = null;
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
    }

    private async void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog
        {
            Filter = "PDF Merger files|*.pdfmerger;*.zpdfmerger|All files|*.*",
            Multiselect = false
        };

        if (ofd.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        if (!File.Exists(ofd.FileName))
        {
            MessageBox.Show("Error loading project!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!await LoadProject(ofd.FileName))
        {
            MessageBox.Show("Error loading project!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    public async Task<bool> LoadProject(string path)
    {
        using (var loadingForm = new Waiting())
        {
            loadingForm.Show(this);
            loadingForm.SetStatus("Waiting project...");
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
            loadingForm.Close();
        }

        return true;
    }


    private PdfPage CreatePdfPage(string path, int pageNumber)
    {
        var pb = new PdfPage(path, pageNumber);
        pb.MouseDown += Pb_MouseDown;
        pb.MouseMove += Pb_MouseMove;
        pb.ExpandTiles += Pb_ExpandTiles;
        pb.CollapseTiles += Pb_CollapseTiles;
        pb.DeleteTile += Pb_DeleteTile;
        return pb;
    }

    private void Pb_CollapseTiles(object? sender, EventArgs e)
    {
        var page = sender as PdfPage;
        if (page is null)
        {
            return;
        }


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
    }


    private void Pb_DeleteTile(object? sender, EventArgs e)
    {
        var page = sender as PdfPage;
        if (page is null)
        {
            return;
        }

        DeletePage(page);
    }


    private void Pb_ExpandTiles(object? sender, EventArgs e)
    {
        var page = sender as PdfPage;
        if (page is null)
        {
            return;
        }

        int index = mainPanel.Controls.GetChildIndex(page);

        var progressMainPanel = new Progress<(PdfPage page, int index)>(item =>
        {
            mainPanel.Controls.Add(item.page);
            if (item.index >= 0)
            {
                mainPanel.Controls.SetChildIndex(item.page, item.index);
            }

        });

        LoadPdfPages(page.FilePath, true, progressMainPanel, index);

        mainPanel.Controls.Remove(page);
        page.Dispose();
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
                Filter = "PDF Merger|*.pdfmerger|PDF Merger Bundle|*.zpdfmerger|All files|*.*"
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
            waitingForm.SetStatus("Saving project...");
            waitingForm.CenterTo(this);
            waitingForm.Refresh();

            await Task.Run(() =>
            {
                res = ProjectConfigManager.Save(textBoxProjectName.Text, m_Created, pages, outputPath, saveAsBundle);
            });

            if(addToRecentProjects)
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
            MessageBox.Show("Project saved successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Error saving project!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e) => new SettingsForm().ShowDialog();

    private void editMetadataForMergedPDFToolStripMenuItem_Click(object sender, EventArgs e) => new MetadataEditor(m_MetaData).ShowDialog();

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        ConfigManager.Config.SidebarActionExpanded = sbAction.Expanded;
        ConfigManager.Config.SidebarListOfDocsExpanded = sbListOfDocs.Expanded;
        ConfigManager.Config.SidebarPreviewSizeExpanded = sbPreviewSize.Expanded;
        ConfigManager.Config.SidebarProjectExpanded = sbProject.Expanded;
        ConfigManager.Save();


        Log.Information("closing MainForm");
    }

    private void licensesToolStripMenuItem_Click(object sender, EventArgs e) => new LicenseForm().ShowDialog(this);

    private void buttonSaveProject_Click(object sender, EventArgs e) => SaveProject(false);

    private void UpdateRecentProjectsMenu()
    {
        recentProjectsToolStripMenuItem.DropDownItems.Clear();

        if (m_recentProjects.Items.Count == 0)
        {
            var emptyItem = new ToolStripMenuItem("No recent projects") 
            { 
                Enabled = false 
            };
            recentProjectsToolStripMenuItem.DropDownItems.Add(emptyItem);
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
                if(path is null)
                {
                    return;
                }

                if (File.Exists(path))
                {
                    await LoadProject(path);
                }
                else
                {
                    MessageBox.Show($"File not found: {path}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            recentProjectsToolStripMenuItem.DropDownItems.Add(item);

            recentProjectsToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            var clearItem = new ToolStripMenuItem("Clear Recent Projects");
            clearItem.Click += (s, e) =>
            {
                m_recentProjects.Items.Clear();
                m_recentProjects.Save();
                UpdateRecentProjectsMenu();
            };
            recentProjectsToolStripMenuItem.DropDownItems.Add(clearItem);

        }
    }
}

