using PdfMerger.classes;
using PdfMerger.Classes;
using PdfMerger.Config;
using PdfSharp.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace PdfMerger
{

    public partial class PdfPage : UserControl
    {
        private static readonly Color BorderColor = Color.LightGray;
        private static readonly Color SelectedBorderColor = Color.FromArgb(50, 120, 220);
        const int BorderThickness = 2;
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PageNumber { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FilePath { get; set; } = string.Empty;

        public event EventHandler? CollapseTiles;
        public event EventHandler? ExpandTiles;
        public event EventHandler? DeleteTile;

        private bool m_selected;

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

        public bool IsStack => (PageNumber < 0);

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
            
            SetStyle(ControlStyles.AllPaintingInWmPaint
               | ControlStyles.OptimizedDoubleBuffer
               | ControlStyles.ResizeRedraw
               | ControlStyles.UserPaint, true);

            Redraw();

            UpdateRegion();
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
                e.Graphics.FillPath(brush, path);
            }



            // Draw shadow (optional subtle glow)
            if (Selected)
            {
                var rect = ClientRectangle;
                rect.Inflate(-1, -1);

                using (var shadowPath = GetRoundRectPath(new Rectangle(rect.X + 2, rect.Y + 2, rect.Width, rect.Height), _cornerRadius))
                using (var shadowBrush = new SolidBrush(Color.FromArgb(60, SelectedBorderColor)))
                {
                    e.Graphics.FillPath(shadowBrush, shadowPath);
                }
            }

            // Draw main border
            var borderBolor = Selected ? SelectedBorderColor : BorderColor; 
            using (var pen = new Pen(borderBolor, BorderThickness))
            using (var path = GetRoundRectPath(ClientRectangle, _cornerRadius))
            {
                e.Graphics.DrawPath(pen, path);
            }


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
            buttonExpandCollapse.Image = Properties.Resources.expand;
            m_ToolTip.SetToolTip(buttonExpandCollapse, "Show every page of this PDF file as single tile.");
        }

        private void ShowCollapseButton()
        {
            buttonExpandCollapse.Image = Properties.Resources.collapse;
            m_ToolTip.SetToolTip(buttonExpandCollapse, "Reduce the pages to on tile placed at the current position of this page.");
        }

        private void button1_Click(object sender, EventArgs e) => DeleteTile?.Invoke(this, EventArgs.Empty);
    }
}
