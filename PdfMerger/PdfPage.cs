using PdfMerger.classes;
using PdfMerger.Classes;
using PdfMerger.Config;
using System.Drawing.Drawing2D;

namespace PdfMerger
{

    public partial class PdfPage : UserControl
    {
        private static readonly Color BorderColor = Color.LightGray;
        private static readonly Color SelectedBorderColor = Color.FromArgb(50, 120, 220);
        const int BorderThickness = 2;
        const int CornerRadius = 8;
        const int IMAGEKEY_EXPAND = 1;
        const int IMAGEKEY_COLLAPSE = 0;
        private ToolTip m_ToolTip = new ToolTip
        {
            AutoPopDelay = 5000,      // how long the tooltip stays visible
            InitialDelay = 500,       // delay before showing
            ReshowDelay = 200,        // delay between re-shows
            ShowAlways = true,        // show even if form not active
            BackColor = Color.WhiteSmoke,
            ForeColor = Color.Black,
            ToolTipIcon = ToolTipIcon.Info
        };

        public int PageNumber { get; set; }
        public string FilePath { get; set; } = string.Empty;

        public event EventHandler? CollapseTiles;
        public event EventHandler? ExpandTiles;

        private bool m_selected;
        public bool Selected
        {
            get => m_selected;
            set
            {
                m_selected = value;
                Invalidate(); // trigger repaint
            }
        }


        public bool IsStack => (PageNumber < 0);

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


            if (IsStack)
            {
                ShowExpandButton();
            }
            else
            {
                labelTitle.Text += $" #{PageNumber}";
                ShowCollapseButton();
            }

            pictureBoxDot.Image = ColorList.GetDotForPdf(filePath, pictureBoxDot.Width);
            Redraw();
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
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                graphics.FillPath(brush, RoundedRect(ClientRectangle, CornerRadius));
            }

            // Draw shadow (optional subtle glow)
            if (Selected)
            {
                using (Pen glow = new Pen(Color.FromArgb(60, SelectedBorderColor), BorderThickness * 3))
                {
                    graphics.DrawPath(glow, RoundedRect(ClientRectangle, CornerRadius + 1));
                }
            }

            // Draw main border
            using (Pen pen = new Pen(Selected ? SelectedBorderColor : BorderColor, BorderThickness))
            {
                graphics.DrawPath(pen, RoundedRect(ClientRectangle, CornerRadius));
            }


        }


        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void buttonExpandCollapse_Click(object sender, EventArgs e)
        {
            if (IsStack)
            {
                ExpandTiles?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                CollapseTiles?.Invoke(this, EventArgs.Empty);
            }
        }


        private void ShowExpandButton()
        {
            buttonExpandCollapse.ImageIndex = IMAGEKEY_EXPAND;
            m_ToolTip.SetToolTip(buttonExpandCollapse, "Show every page of this PDF file as single tile.");
        }

        private void ShowCollapseButton()
        {
            buttonExpandCollapse.ImageIndex = IMAGEKEY_COLLAPSE;
            m_ToolTip.SetToolTip(buttonExpandCollapse, "Reduce the pages to on tile placed at the current position of this page.");
        }
    }
}
