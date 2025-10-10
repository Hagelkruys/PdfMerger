using PdfMerger.classes;
using PdfMerger.Classes;
using PdfMerger.Config;

using FormsTimer = System.Windows.Forms.Timer;

namespace PdfMerger;

public partial class MainForm : Form
{
    private readonly List<PdfPage> pages = new();

    private PdfPage? draggedBox = null;
    private PdfPage? selectedBox = null;
    private bool isDragging = false;
    private Point dragStartPoint;
    private const int DragThreshold = 5;

    private FormsTimer saveConfigTimer = new() { Interval = 500 };
    private FormsTimer redrawConfigTimer = new() { Interval = 100 };

    public MainForm()
    {
        InitializeComponent();
        splitContainer1.SplitterDistance = splitContainer1.Width - 200;
        trackBarPreviewSize.Value = MyPdfRenderer.MaxWidth;

        saveConfigTimer.Tick += SaveConfigTimer_Tick;
        redrawConfigTimer.Tick += RedrawConfigTimer_Tick;


        pdfDocList.SmallImageList = ColorList.GetImageList();
        pdfDocList.Columns.Add("", 32);
        pdfDocList.Columns.Add("PDF File", 300);
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

            LoadPdfPages(file); // Your method to add thumbnails
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
        if (selectedBox == null)
        {
            return;
        }


        DeleteSelectedPage();
        if (selectedBox is PdfPage)
        {
            pages.Remove(selectedBox);  // Remove from pages list
        }

        mainPanel.Controls.Remove(selectedBox);  // Remove PdfPage from panel
        selectedBox.Dispose(); // Free resources
        selectedBox = null;
    }





    private void LoadPdfPages(string filePath)
    {
        using var doc = new PDFiumSharp.PdfDocument(filePath);

        for (int i = 0; i < doc.Pages.Count; i++)
        {
            var pb = new PdfPage(i, filePath);
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
            draggedBox = pb;
            dragStartPoint = e.Location;
            isDragging = false; // not dragging yet
            pb.DoDragDrop(pb, DragDropEffects.Move);
            SelectPictureBox(pb);
        }
    }


    private void Pb_MouseMove(object? sender, MouseEventArgs e)
    {
        if (draggedBox is not null && e.Button == MouseButtons.Left)
        {
            // start dragging only if mouse moved more than a threshold
            if (!isDragging && (Math.Abs(e.X - dragStartPoint.X) > 5 || Math.Abs(e.Y - dragStartPoint.Y) > 5))
            {
                isDragging = true;
                draggedBox.DoDragDrop(draggedBox, DragDropEffects.Move);
            }
        }
    }

    private void SelectPictureBox(PdfPage pb)
    {
        if (selectedBox != null && !selectedBox.IsDisposed)
        {
            selectedBox.Selected = false;
        }

        selectedBox = pb;
        selectedBox.Selected = true;
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

            if (draggedBox is null)
            {
                return;
            }

            var pos = mainPanel.PointToClient(new Point(e.X, e.Y));
            var target = mainPanel.Controls
                .OfType<PdfPage>()
                .FirstOrDefault(pb => pb.Bounds.Contains(pos));

            if (target is null || target == draggedBox)
            {
                return;
            }

            int oldIndex = mainPanel.Controls.GetChildIndex(draggedBox);
            int newIndex = mainPanel.Controls.GetChildIndex(target);

            mainPanel.Controls.SetChildIndex(draggedBox, newIndex);
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
        if (selectedBox == null)
        {
            return;
        }

        if (selectedBox is PdfPage)
            pages.Remove(selectedBox);

        mainPanel.Controls.Remove(selectedBox);
        selectedBox.Dispose();
        selectedBox = null;
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
}

