using PDFiumSharp.Enums;
using PdfMerger.Config;
using System.Drawing.Drawing2D;

namespace PdfMerger.classes
{
    public static class MyPdfRenderer
    {
        public static int MaxWidth { get; private set; } = 250;
        public static int MaxHeight { get; private set; } = 350;
        public static bool AddBorder { get; set; } = true;
        public static bool AddWhiteBackground { get; set; } = true;
        public static int BorderWidth { get; set; } = 2;
        public static Color BorderColor { get; set; } = Color.Black;

        public static void Init()
        {
            MaxWidth = ConfigManager.Config.PdfRenderMaxWidth;
            MaxHeight = ConfigManager.Config.PdfRenderMaxHeight;
            AddBorder = ConfigManager.Config.PdfRenderAddBorder;
            AddWhiteBackground = ConfigManager.Config.PdfRenderAddWhiteBackground;
            BorderWidth = ConfigManager.Config.PdfRenderAddBorderWidth;
        }

        private static (int thumbWidth, int thumbHeight) GetThumbnailSize(PDFiumSharp.PdfPage page)
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



        public static Bitmap RenderPage(PDFiumSharp.PdfPage page, int stackSize = 0)
        {
            var (thumbW, thumbH) = GetThumbnailSize(page);

            using var pdfBmp = new PDFiumSharp.PDFiumBitmap(thumbW, thumbH, true);

            var rect = (left: 0, top: 0, thumbW, thumbH);
            page.Render(pdfBmp, rect, PageOrientations.Normal, RenderingFlags.Annotations);

            var bmp = new Bitmap(pdfBmp.AsBmpStream());

            if (AddBorder || AddWhiteBackground)
            {
                bmp = OptimizeImage(bmp);
            }

            if (stackSize > 0)
            {
                bmp = AddStack(bmp, stackSize);
            }

            return bmp;
        }

        static readonly Color PaperEdges = Color.FromArgb(100, Color.Gray);
        static readonly Color RightEdgeStart = Color.FromArgb(50, Color.Black);
        static readonly Color RightEdgeEnd = Color.FromArgb(100, Color.Black);
        static readonly Color BottomEdgeStart = Color.FromArgb(50, Color.Black);
        static readonly Color BottomEdgeEnd = Color.FromArgb(100, Color.Black);
        static readonly Color TopEdgeStart = Color.FromArgb(80, Color.White);
        static readonly Color TopEdgeEnd = Color.FromArgb(40, Color.White);
        static readonly Color BasePaperFill = Color.FromArgb(255, 250, 250, 250);


        private static Bitmap AddStack(Bitmap original, int stackSize)
        {
            int layers = Math.Min(stackSize, 5);
            int pixelOffsetPerLayer = 3;

            int newImageWidth = original.Width + pixelOffsetPerLayer * layers;
            int newImageHeight = original.Height + pixelOffsetPerLayer * layers;

            var bmp = new Bitmap(newImageWidth, newImageHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.Clear(Color.Transparent);

                // Draw the same image multiple times with small offsets
                for (int i = layers; i >= 1; i--)
                {
                    int offset = i * pixelOffsetPerLayer;
                    g.DrawImage(original, offset, offset, original.Width, original.Height);
                }

                // Draw the main image on top
                g.DrawImage(original, 0, 0, original.Width, original.Height);

                // Optional: draw a visible outline for clarity
                using (var pen = new Pen(Color.FromArgb(180, Color.Black), 1))
                {
                    g.DrawRectangle(pen, 0, 0, original.Width - 1, original.Height - 1);
                }
            }

            return bmp;
        }

        private static Bitmap AddStack2(Bitmap original, int stackSize)
        {
            int layers = Math.Min(stackSize, 5);
            int pixelOffsetPerLayer = 4;

            int newImageWidth = original.Width + pixelOffsetPerLayer * layers;
            int newImageHeight = original.Height + pixelOffsetPerLayer * layers;

            var bmp = new Bitmap(newImageWidth, newImageHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);


                // Draw stacked layers (faint rectangles behind)
                for (int i = layers; i >= 1; i--)
                {
                    Rectangle sheetRect = new Rectangle(i * pixelOffsetPerLayer, i * pixelOffsetPerLayer, original.Width, original.Height);

                    // Base paper fill (slightly off-white)
                    using (Brush paperBrush = new SolidBrush(BasePaperFill))
                    {
                        g.FillRectangle(paperBrush, sheetRect);
                    }


                    // Edge tint to simulate thickness and depth
                    using (var topEdge = new LinearGradientBrush(
                        new Rectangle(sheetRect.X, sheetRect.Y, sheetRect.Width, 6),
                        TopEdgeStart,
                        TopEdgeEnd,
                        90f))
                    {
                        g.FillRectangle(topEdge, sheetRect.X, sheetRect.Y, sheetRect.Width, 6);
                    }

                    using (var bottomEdge = new LinearGradientBrush(
                        new Rectangle(sheetRect.X, sheetRect.Bottom - 6, sheetRect.Width, 6),
                        BottomEdgeStart,
                        BottomEdgeEnd,
                        90f))
                    {
                        g.FillRectangle(bottomEdge, sheetRect.X, sheetRect.Bottom - 6, sheetRect.Width, 6);
                    }

                    using (var rightEdge = new LinearGradientBrush(
                        new Rectangle(sheetRect.Right - 6, sheetRect.Y, 6, sheetRect.Height),
                        RightEdgeStart,
                        RightEdgeEnd,
                        0f))
                    {
                        g.FillRectangle(rightEdge, sheetRect.Right - 6, sheetRect.Y, 6, sheetRect.Height);
                    }

                    // Thin outline to define paper edges
                    using (Pen outlinePen = new Pen(PaperEdges))
                    {
                        g.DrawRectangle(outlinePen, sheetRect);
                    }

                }

                // Draw the main visible page on top
                var mainRect = new Rectangle(0, 0, original.Width, original.Height);
                g.FillRectangle(Brushes.White, mainRect);
                g.DrawImage(original, 0, 0, original.Width, original.Height);

                // Thin border for the top sheet
                using (Pen mainOutline = new Pen(Color.FromArgb(150, Color.DarkGray)))
                {
                    g.DrawRectangle(mainOutline, mainRect);
                }
            }

            return bmp;
        }


        private static Bitmap OptimizeImage(Bitmap bmp)
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
                using var pen = new Pen(BorderColor, BorderWidth);
                g.DrawRectangle(pen, 0, 0, bmp.Width - 1, bmp.Height - 1);
            }
            return finalBmp;
        }


        public static void SetNewWidth(int width)
        {
            MaxWidth = width;
            MaxHeight = (int)(width * 1.4);

            ConfigManager.Config.PdfRenderMaxWidth = MaxWidth;
            ConfigManager.Config.PdfRenderMaxHeight = MaxHeight;
        }
    }
}
