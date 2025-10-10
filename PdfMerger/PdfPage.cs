using PdfMerger.classes;
using PdfMerger.Classes;
using System.Drawing.Drawing2D;

namespace PdfMerger
{
    public partial class PdfPage : UserControl
    {
        private static readonly Color BorderColor = Color.LightGray;
        private static readonly Color SelectedBorderColor = Color.FromArgb(50, 120, 220);
        const int BorderThickness = 2;
        const int CornerRadius = 8;


        public int PageNumber { get; set; }
        public string FilePath { get; set; } = string.Empty;


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



        public PdfPage(int pageNumber, string filePath)
        {
            InitializeComponent();

            this.Tag = pageNumber;
            this.PageNumber = pageNumber;
            this.FilePath = filePath;
            this.Width = MyPdfRenderer.MaxWidth;
            this.Height = MyPdfRenderer.MaxHeight;

            pictureBoxDot.Image = ColorList.GetDotForPdf(filePath);
            Redraw();
        }


        public void SetImage(Bitmap newImage)
        {
            var old = pictureBox.Image;
            pictureBox.Image = newImage;
            old?.Dispose();
        }

        public void SetSelected(bool selected)
        {
            //TODO: !
            //Invalidate(); // triggers repaint
        }

        public void Redraw()
        {
            var t = new PDFiumSharp.PdfDocument(FilePath).Pages[PageNumber];
            var bmp = MyPdfRenderer.RenderPage(t);
            this.SetImage(bmp);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw background
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(brush, RoundedRect(ClientRectangle, CornerRadius));
            }

            // Draw shadow (optional subtle glow)
            if (Selected)
            {
                using (Pen glow = new Pen(Color.FromArgb(60, SelectedBorderColor), BorderThickness * 3))
                {
                    e.Graphics.DrawPath(glow, RoundedRect(ClientRectangle, CornerRadius + 1));
                }
            }

            // Draw main border
            using (Pen pen = new Pen(Selected ? SelectedBorderColor : BorderColor, BorderThickness))
            {
                e.Graphics.DrawPath(pen, RoundedRect(ClientRectangle, CornerRadius));
            }
        }


        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

    }
}
