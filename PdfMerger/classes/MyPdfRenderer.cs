using PDFiumSharp.Enums;
using PdfMerger.Config;

namespace PdfMerger.Classes;

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
