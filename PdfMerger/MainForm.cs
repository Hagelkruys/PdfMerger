using PdfMerger.classes;
using PdfMerger.Classes;
using PdfMerger.Config;
using System.Reflection;
using FormsTimer = System.Windows.Forms.Timer;

namespace PdfMerger;

public partial class MainForm : Form
{
    private readonly List<PdfPage> pages = new();

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


    public MainForm()
    {
        InitializeComponent();
        trackBarPreviewSize.Value = MyPdfRenderer.MaxWidth;

        saveConfigTimer.Tick += SaveConfigTimer_Tick;
        redrawConfigTimer.Tick += RedrawConfigTimer_Tick;


        pdfDocList.SmallImageList = ColorList.GetImageList();
        pdfDocList.Columns.Add("", 32);
        pdfDocList.Columns.Add("PDF File", 300);

        labelCreated.Text = m_Created.ToLocalTime().ToString();
        textBoxProjectName.Text = "Untiteld";

        m_LastSaveWasBundle = ConfigManager.Config.SaveAsBundle;
        toolStripStatusLabelVersion.Text = $"Version: {GetVersion()}";
        SetStatus("");
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


    private void AddFiles(string[] files)
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
            pdfDocList.Items.Add(item);

            LoadPdfPages(file);
        }
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
        if (m_selectedBox is PdfPage)
        {
            pages.Remove(m_selectedBox);  // Remove from pages list
        }

        mainPanel.Controls.Remove(m_selectedBox);  // Remove PdfPage from panel
        m_selectedBox?.Dispose(); // Free resources
        m_selectedBox = null;
    }





    private void LoadPdfPages(string filePath, bool loadAllPages = false)
    {
        if (loadAllPages)
        {

            using var doc = new PDFiumSharp.PdfDocument(filePath);

            for (int i = 0; i < doc.Pages.Count; i++)
            {
                var pb = new PdfPage(filePath, i);
                pb.MouseDown += Pb_MouseDown;
                pb.MouseMove += Pb_MouseMove;
                mainPanel.Controls.Add(pb);
                pages.Add(pb);
            }
        }
        else
        {
            var pb = new PdfPage(filePath, -1);
            pb.MouseDown += Pb_MouseDown;
            pb.MouseMove += Pb_MouseMove;
            mainPanel.Controls.Add(pb);
            pages.Add(pb);
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

            // Update pages list to match new order
            var movedPage = pages[oldIndex];
            pages.RemoveAt(oldIndex);
            pages.Insert(newIndex, movedPage);
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


    private void MergePdfs()
    {
        using var sfd = new SaveFileDialog
        {
            Filter = "PDF files|*.pdf|All files|*.*"
        };

        if (sfd.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        MyMerger.WriteMergedPdf(pages, sfd.FileName);

        MessageBox.Show("PDFs merged successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


    private void DeleteSelectedPage()
    {
        if (m_selectedBox == null)
        {
            return;
        }

        if (m_selectedBox is PdfPage)
        {
            pages.Remove(m_selectedBox);
        }

        mainPanel.Controls.Remove(m_selectedBox);
        m_selectedBox.Dispose();
        m_selectedBox = null;
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
        foreach (var p in pages)
        {
            p?.Dispose();
        }
        pages.Clear();
        pdfDocList.Clear();
        m_LastOutputPath = "";
        m_LastSaveWasBundle = ConfigManager.Config.SaveAsBundle;

        // set new values
        m_Created = DateTime.UtcNow;
        textBoxProjectName.Text = "Untiteld";
        labelCreated.Text = m_Created.ToLocalTime().ToString();
    }

    private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
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

        if (!LoadProject(ofd.FileName))
        {
            MessageBox.Show("Error loading project!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    public bool LoadProject(string path)
    {
        (var proj, var baseDir) = ProjectConfigManager.Load(path);

        if (proj is null)
        {
            return false;
        }

        NewProject();
        m_Created = proj.Created;
        textBoxProjectName.Text = proj.ProjectName;
        labelCreated.Text = m_Created.ToLocalTime().ToString();

        List<string> missingFiles = new();
        foreach (var entry in proj.PdfFiles)
        {
            if (!File.Exists(entry.FilePathAbsolute))
            {
                entry.FilePathAbsolute = Path.GetFullPath(Path.Combine(baseDir, entry.FilePathRelative));
            }
        }


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
            pdfDocList.Items.Add(item);
        }


        foreach (var entry in proj.PdfFiles)
        {
            var pb = new PdfPage(entry.FilePathAbsolute, entry.PageNumber);
            pb.MouseDown += Pb_MouseDown;
            pb.MouseMove += Pb_MouseMove;
            mainPanel.Controls.Add(pb);
            pages.Add(pb);
        }

        return true;
    }

    private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e) => SaveProject(false);
    private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e) => SaveProject(true);
    private void SaveProject(bool forceNewFile)
    {
        string outputPath = m_LastOutputPath;
        bool saveAsBundle = m_LastSaveWasBundle;
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
        }



        if (ProjectConfigManager.Save(textBoxProjectName.Text, m_Created, pages, outputPath, saveAsBundle))
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

    private void button1_Click(object sender, EventArgs e) => SaveProject(false);


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
}

