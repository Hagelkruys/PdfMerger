using PDFiumSharp.Enums;

namespace PdfMerger.classes
{
    internal class MyPdfRenderer
    {
        public int MaxWidth = 250;
        public int MaxHeight = 350;
        public bool AddBorder = true;
        public bool AddWhiteBackground = true;
        public int borderWidth = 2;
        public Color borderColor = Color.Black;


        private (int thumbWidth, int thumbHeight) GetThumbnailSize(PDFiumSharp.PdfPage page)
        {
            // Get PDF page size
            float pdfWidth = (float)page.Width;
            float pdfHeight = (float)page.Height;

            float widthRatio = MaxWidth / pdfWidth;
            float heightRatio = MaxHeight / pdfHeight;

            // Use the smaller ratio to fit page within max dimensions
            float scale = Math.Min(widthRatio, heightRatio);

            int thumbWidth = (int)(pdfWidth * scale);
            int thumbHeight = (int)(pdfHeight * scale);

            return (thumbWidth, thumbHeight);
        }



        public Bitmap RenderPage(PDFiumSharp.PdfPage page)
        {
            var (thumbW, thumbH) = GetThumbnailSize(page);

            using var pdfBmp = new PDFiumSharp.PDFiumBitmap(thumbW, thumbH, true);

            var rect = (left: 0, top: 0, thumbW, thumbH);
            page.Render(pdfBmp, rect, PageOrientations.Normal, RenderingFlags.Annotations);

            var bmp = new Bitmap(pdfBmp.AsBmpStream());

            if (AddBorder || AddWhiteBackground)
            {
                return OptimizeImage(bmp);
            }
            return bmp;
        }


        private Bitmap OptimizeImage(Bitmap bmp)
        {
            var finalBmp = new Bitmap(bmp.Width, bmp.Height);
            using var g = Graphics.FromImage(finalBmp);

            if (AddWhiteBackground)
            {
                g.Clear(Color.White);
            }

            g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);

            if (AddBorder)
            {
                using var pen = new Pen(borderColor, borderWidth);
                g.DrawRectangle(pen, 0, 0, bmp.Width - 1, bmp.Height - 1);
            }
            return finalBmp;
        }
    }
}
