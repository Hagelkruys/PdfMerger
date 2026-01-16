using PdfMerger.Classes;
using PdfMerger.Config;
using PdfMerger.CustomUI;
using PdfMerger.DocumentInfo;

namespace PdfMerger;


public partial class Page : UserControl
{
    private static readonly Color BorderColor = Color.LightGray;
    private static readonly Color SelectedBorderColor = Color.FromArgb(50, 120, 220);
    private static readonly Color HoverColor = Color.FromArgb(50, Color.LightSkyBlue);
    const int BorderThickness = 2;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int PageNumber { get; set; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string FilePath { get; set; } = string.Empty;
    private bool m_selected;
    private bool m_hovered;
    private ContextMenuStrip m_contextMenu = new ContextMenuStrip();
    private PageInfoForm? m_infoForm = null;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public bool Selected
    {
        get => m_selected;
        set
        {
            m_selected = value;
            Invalidate(); // trigger repaint
        }
    }

    public bool IsOnePager
    {
        get
        {
            if (DocumentRegistry.TryGet(FilePath, out var doc) && null != doc)
            {
                return (1 == doc.PageCount);
            }

            return false; 
        }
    }

    public bool IsStack => (!IsOnePager && (PageNumber < 0));
    private int _cornerRadius = 8;

    [System.ComponentModel.Category("Appearance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int CornerRadius
    {
        get => _cornerRadius;
        set
        {
            _cornerRadius = Math.Max(0, value);
            UpdateRegion();
            Invalidate();
        }
    }

    public eDocumentType DocumentType { get; private set; }


    public event EventHandler<EventArgs>? RequestDelete;
    public event EventHandler<EventArgs>? RequestExpand;
    public event EventHandler<EventArgs>? RequestCollapse;


    public Page(string filePath, int pageNumber, eDocumentType documentType)
    {
        InitializeComponent();

        DocumentType = documentType;
        this.Tag = pageNumber;
        this.PageNumber = pageNumber;
        this.FilePath = filePath;
        this.Width = MyPdfRenderer.MaxWidth;
        this.Height = MyPdfRenderer.MaxHeight;


        if (ConfigManager.Config.ShowFilenameExtension)
        {
            labelTitle.Text = Path.GetFileName(filePath);
        }
        else
        {
            labelTitle.Text = Path.GetFileNameWithoutExtension(filePath);
        }


        DocumentRegistry.TryGet(filePath, out var doc);
        labelInfo.Text = "";


        if(IsOnePager)
        {
            labelInfo.Text = Properties.Strings.SinglePage;
        }
        else if (IsStack)
        {
            if (doc is not null)
            {
                labelInfo.Text = Properties.Strings.StackOfPages
                    .Replace("#num#",doc.PageCount.ToString());
            }
        }
        else
        {
            if (doc is not null)
            {
                labelInfo.Text = Properties.Strings.PageXofY
                    .Replace("#x#", PageNumber.ToString())
                    .Replace("#y#", doc.PageCount.ToString());
            }
        }

        pictureBoxDot.Image = ColorList.GetDotForFile(filePath, pictureBoxDot.Width);

        SetStyle(ControlStyles.AllPaintingInWmPaint
           | ControlStyles.OptimizedDoubleBuffer
           | ControlStyles.ResizeRedraw
           | ControlStyles.UserPaint, true);

        Redraw();

        UpdateRegion();

        InitializeContextMenu();

        MouseEnter += MyPage_MouseEnter;
        MouseLeave += MyPage_MouseLeave;
        MouseUp += BubbleMouseUp;
        RegisterMouseHandlers(this);

        m_contextMenu.Closing += ContextMenu_Closing;
    }

    private void ContextMenu_Closing(object? sender, ToolStripDropDownClosingEventArgs e)
    {
        m_infoForm?.Close();
        m_infoForm = null;
    }

    private void InitializeContextMenu()
    {
        if (!IsOnePager)
        {
            if (IsStack)
            {
                m_contextMenu.Items.Add(
                    Properties.Strings.ExpandStack, 
                    null, 
                    (sender,e) =>
                    {
                        RequestExpand?.Invoke(this, EventArgs.Empty);
                    });
            }
            else
            {
                m_contextMenu.Items.Add(
                    Properties.Strings.CollapseStack,
                    null,
                    (sender, e) =>
                    {
                        RequestCollapse?.Invoke(this, EventArgs.Empty);
                    });
            }
        }

        m_contextMenu.Items.Add(
            Properties.Strings.Delete,
            null,
            (sender, e) =>
            {
                RequestDelete?.Invoke(this, EventArgs.Empty);
            });
    }


    private void ShowExtraInfo(Point location)
    {
        m_infoForm = new PageInfoForm();
        m_infoForm.Location = new Point(
            Cursor.Position.X - (m_infoForm.Width/2),
            Cursor.Position.Y - 10 - m_infoForm.Height);
        m_infoForm.Show();


        // Example: tooltip
        ToolTip tt = new ToolTip();
        tt.Show("Additional information about this control",
                this,
                location,
                2000);
    }


    private void RegisterMouseHandlers(Control parent)
    {
        parent.MouseUp += MyPage_MouseUp;

        foreach (Control child in parent.Controls)
            RegisterMouseHandlers(child);
    }

    private void BubbleMouseUp(object? sender, MouseEventArgs e)
    {
        if (sender is Control c && c != this)
        {
            MyPage_MouseUp(this, e);
        }
    }


    private void MyPage_MouseUp(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            ShowExtraInfo(e.Location);
            m_contextMenu.Show(this, e.Location);
        }
    }


    private void MyPage_MouseLeave(object? sender, EventArgs e)
    {
        m_hovered = false;
        Invalidate();
        //m_ToolTip.Hide(this);
    }

    private void MyPage_MouseEnter(object? sender, EventArgs e)
    {
        m_hovered = true;
        Invalidate();

        //string tipText = $"{labelTitle.Text}\nPage Number: {pageNumber}\n";
        //m_ToolTip.SetToolTip(this, tipText);
    }

    protected override void OnSizeChanged(System.EventArgs e)
    {
        base.OnSizeChanged(e);

        UpdateRegion();
    }


    private void UpdateRegion()
    {
        using var path = GetRoundRectPath(ClientRectangle, _cornerRadius);
        Region = new Region(path);
    }

    private static GraphicsPath GetRoundRectPath(Rectangle rect, int radius)
    {
        int diameter = radius * 2;
        GraphicsPath path = new GraphicsPath();

        if (radius == 0)
        {
            path.AddRectangle(rect);
            return path;
        }

        Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

        // Top left arc
        path.AddArc(arcRect, 180, 90);

        // Top right arc
        arcRect.X = rect.Right - diameter;
        path.AddArc(arcRect, 270, 90);

        // Bottom right arc
        arcRect.Y = rect.Bottom - diameter;
        path.AddArc(arcRect, 0, 90);

        // Bottom left arc
        arcRect.X = rect.Left;
        path.AddArc(arcRect, 90, 90);

        path.CloseFigure();
        return path;
    }

    private void SetImage(Bitmap newImage)
    {
        var old = pictureBox.Image;
        pictureBox.Image = newImage;
        old?.Dispose();
    }


    public void Redraw()
    {
        if (eDocumentType.image == DocumentType)
        {
            //var bmp = new Bitmap(Image.FromFile(FilePath));
            //this.SetImage(bmp);

            // to have the correct image as it will be inserted into the pdf we
            // 1. generate a pdf from the image 
            // 2. generate a image from the pdf page


            var tempPdf = PdfFromImage.CreateTempPdf(FilePath);
            if(!string.IsNullOrWhiteSpace(tempPdf))
            {
                RenderPdfToImageControl(tempPdf);
            }
            else
            {
                //fallback 
                var bmp = new Bitmap(Image.FromFile(FilePath));
                this.SetImage(bmp);
            }
        }
        else if (eDocumentType.pdf == DocumentType)
        {
            RenderPdfToImageControl(FilePath);
        }
    }

    private void RenderPdfToImageControl(string path)
    {
        using var doc = new PDFiumSharp.PdfDocument(path);

        int pageToRender = PageNumber;
        pageToRender = Math.Max(0, pageToRender);
        pageToRender = Math.Min(pageToRender, doc.Pages.Count - 1);
        using var t = doc.Pages[pageToRender];


        int stackCount = 0;
        if (IsStack)
        {
            stackCount = ImageStackSizeIndicator.GetStackSize(doc.Pages.Count);
        }
        var bmp = MyPdfRenderer.RenderPage(t, stackCount);
        this.SetImage(bmp);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var graphics = e.Graphics;

        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Draw background
        using (var brush = new SolidBrush(BackColor))
        using (var path = GetRoundRectPath(ClientRectangle, _cornerRadius))
        {
            graphics.FillPath(brush, path);
        }


        // Draw shadow (optional subtle glow)
        if (Selected)
        {
            var rect = ClientRectangle;
            rect.Inflate(-1, -1);

            using (var shadowPath = GetRoundRectPath(new Rectangle(rect.X + 2, rect.Y + 2, rect.Width, rect.Height), _cornerRadius))
            using (var shadowBrush = new SolidBrush(Color.FromArgb(60, SelectedBorderColor)))
            {
                graphics.FillPath(shadowBrush, shadowPath);
            }
        }

        // Draw main border
        var borderBolor = Selected ? SelectedBorderColor : BorderColor;
        using (var pen = new Pen(borderBolor, BorderThickness))
        using (var path = GetRoundRectPath(ClientRectangle, _cornerRadius))
        {
            graphics.DrawPath(pen, path);


            // Hover overlay
            if (m_hovered)
            {
                using (SolidBrush hover = new SolidBrush(HoverColor))
                    graphics.FillPath(hover, path);
            }
        }


    }
}
