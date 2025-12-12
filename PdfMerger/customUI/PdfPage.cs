using PdfMerger.Classes;
using PdfMerger.Config;
using PdfMerger.DocumentInfo;

namespace PdfMerger;


public partial class PdfPage : UserControl
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


    public PdfPage(string filePath, int pageNumber)
    {
        InitializeComponent();

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
            // TODO: singel page ??? 
            labelInfo.Text = Properties.Strings.PageXofY
                    .Replace("#x#", "1")
                    .Replace("#y#", "1");

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

        pictureBoxDot.Image = ColorList.GetDotForPdf(filePath, pictureBoxDot.Width);

        SetStyle(ControlStyles.AllPaintingInWmPaint
           | ControlStyles.OptimizedDoubleBuffer
           | ControlStyles.ResizeRedraw
           | ControlStyles.UserPaint, true);

        Redraw();

        UpdateRegion();

        MouseEnter += PdfPage_MouseEnter;
        MouseLeave += PdfPage_MouseLeave;
    }

    private void PdfPage_MouseLeave(object? sender, EventArgs e)
    {
        m_hovered = false;
        Invalidate();
        //m_ToolTip.Hide(this);
    }

    private void PdfPage_MouseEnter(object? sender, EventArgs e)
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
        using var doc = new PDFiumSharp.PdfDocument(FilePath);

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
