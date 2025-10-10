namespace PdfMerger;

public partial class MainForm : Form
{
    private readonly List<PageItem> pages = new();

    private MyPdfRenderer m_renderer = new MyPdfRenderer()
    {
        MaxWidth = 250,
        MaxHeight = 350,
        AddBorder = true,
    };


    private PictureBox? draggedBox = null;
    private PictureBox? selectedBox = null;
    private bool isDragging = false;
    private Point dragStartPoint;
    private const int DragThreshold = 5;

    public MainForm()
    {
        InitializeComponent();
        splitContainer1.SplitterDistance = splitContainer1.Width - 200;
        trackBarPreviewSize.Value = m_renderer.MaxWidth;
    }


    private void MainForm_DragEnter(object? sender, DragEventArgs e)
    {
        if(e.Data is null)
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
        if(e.Data is null)
        {
            return;
        }

        var isFileDrop = e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false;
        if (!isFileDrop)
        {
            return;
        }

        var data = e.Data?.GetData(DataFormats.FileDrop);
        if(data is null)
        {
            return;
        }
        var files = data as string[];
        if(files is null)
        {
            return;
        }

        foreach (var file in files)
        {
            if (Path.GetExtension(file).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                LoadPdfPages(file); // Your method to add thumbnails
            }
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
        if (sender is TrackBar trackBar)
        {
            m_renderer.MaxWidth = trackBar.Value;
            m_renderer.MaxHeight = (int)(trackBar.Value * 1.4); // maintain aspect ratio

            ResizeThumbnails();
        }
    }


    private void ResizeThumbnails()
    {
        foreach (Control ctrl in mainPanel.Controls)
        {
            if (ctrl is PictureBox pb && pb.Tag is PageItem page)
            {
                // Re-render the page at new size

                var t = new PDFiumSharp.PdfDocument(page.FilePath).Pages[page.PageIndex];
                var bmp = m_renderer.RenderPage(t);

                pb.Image?.Dispose();
                pb.Image = bmp;
                pb.Width = m_renderer.MaxWidth;
                pb.Height = m_renderer.MaxHeight;
            }
        }
    }


    private void DeleteSelectedPage(object? sender, EventArgs e)
    {
        if (selectedBox == null)
        {
            return;
        }


        DeleteSelectedPage();
        if (selectedBox.Tag is PageItem page)
        {
            pages.Remove(page);  // Remove from pages list
        }

        mainPanel.Controls.Remove(selectedBox);  // Remove PictureBox from panel
        selectedBox.Dispose();               // Free resources
        selectedBox = null;
    }





    private void LoadPdfPages(string filePath)
    {
        using var doc = new PDFiumSharp.PdfDocument(filePath);

        for (int i = 0; i < doc.Pages.Count; i++)
        {
            var bmp = m_renderer.RenderPage(doc.Pages[i]);

            var pb = new PictureBox
            {
                Width = m_renderer.MaxWidth,
                Height = m_renderer.MaxHeight,
                Image = bmp,
                SizeMode = PictureBoxSizeMode.Zoom,
                Tag = new PageItem { FilePath = filePath, PageIndex = i },
                BorderStyle = BorderStyle.FixedSingle
            };

            pb.MouseDown += Pb_MouseDown;
            pb.MouseMove += Pb_MouseMove;
            //pb.Paint += (s, e) =>
            //{
            //    if (pb == selectedBox)
            //    {
            //        using var pen = new Pen(Color.Red, 4);
            //        e.Graphics.DrawRectangle(pen, 0, 0, pb.Width - 1, pb.Height - 1);
            //    }
            //};

            mainPanel.Controls.Add(pb);
            pages.Add((PageItem)pb.Tag);
        }
    }


    private void Pb_MouseDown(object? sender, MouseEventArgs e)
    {
        if (sender is PictureBox pb && e.Button == MouseButtons.Left)
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

    private void SelectPictureBox(PictureBox pb)
    {
        if (selectedBox != null && !selectedBox.IsDisposed)
        {
            selectedBox.Padding = new Padding(0);
            selectedBox.BackColor = Color.Transparent;
            // Remove previous highlight
            selectedBox.BorderStyle = BorderStyle.FixedSingle;
        }

        selectedBox = pb;
        selectedBox.BorderStyle = BorderStyle.Fixed3D; // highlight

        selectedBox.Padding = new Padding(2);        // thickness of border
        selectedBox.BackColor = Color.Red;
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
        else if (e.Data.GetDataPresent(typeof(PictureBox)))
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
        else if (e.Data.GetDataPresent(typeof(PictureBox)))
        {

            if (draggedBox is null)
            {
                return;
            }

            var pos = mainPanel.PointToClient(new Point(e.X, e.Y));
            var target = mainPanel.Controls
                .OfType<PictureBox>()
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


    private void AddPdfFiles()
    {
        using var ofd = new OpenFileDialog { Filter = "PDF files|*.pdf", Multiselect = true };
        if (ofd.ShowDialog() != DialogResult.OK) return;

        foreach (var file in ofd.FileNames)
            LoadPdfPages(file);
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
        if (selectedBox == null) return;

        if (selectedBox.Tag is PageItem page)
            pages.Remove(page);

        mainPanel.Controls.Remove(selectedBox);
        selectedBox.Dispose();
        selectedBox = null;
    }
}

