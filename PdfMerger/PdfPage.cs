using PdfMerger.classes;
using PdfMerger.Classes;

namespace PdfMerger
{
    public partial class PdfPage : UserControl
    {
        public int PageNumber { get; set; }
        public string FilePath { get; set; } = string.Empty;

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
    }
}
