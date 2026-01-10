using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using PdfMerger.Config;



namespace PdfMerger.Classes;

public static class PdfFromImage
{
    private static readonly PageSize A4 = PageSize.A4;

    public static string? AppendImage(string imagePath, PdfDocument outputPdf)
    {
        eImagePlacementMode mode = (eImagePlacementMode)ConfigManager.Config.ImagePlacementMode;

        try
        {

            if (mode == eImagePlacementMode.Original)
            {
                if (!CreatePageSizeBasedOnImage(outputPdf, imagePath))
                {
                    return null;
                }
            }
            else
            {
                if (!CreateA4PageWithImage(outputPdf, imagePath, mode))
                {
                    return null;
                }
            }
        }
        catch (Exception e)
        {
            Log.Error(e, "exception");
        }
        return null;
    }


    private static bool CreateA4PageWithImage(PdfDocument pdf, string imagePath, eImagePlacementMode mode)
    {
        try
        {
            var imgData = ImageDataFactory.Create(imagePath);
            float imgWidth = imgData.GetWidth();
            float imgHeight = imgData.GetHeight();

            PageSize pageSize = A4;

            // 🔄 Seite an Bildausrichtung anpassen
            if (ConfigManager.Config.RotatePageToImage)
            {
                bool imageIsLandscape = imgWidth > imgHeight;
                bool pageIsLandscape = pageSize.GetWidth() > pageSize.GetHeight();

                if (imageIsLandscape && !pageIsLandscape)
                {
                    pageSize = pageSize.Rotate();
                }
            }

            var page = pdf.AddNewPage(pageSize);
            var canvas = new PdfCanvas(page);

            var img = new iText.Layout.Element.Image(imgData);

            float scale;

            if (mode == eImagePlacementMode.Fill)
            {
                scale = Math.Max(
                    pageSize.GetWidth() / imgWidth,
                    pageSize.GetHeight() / imgHeight
                );
            }
            else // Fit
            {
                scale = Math.Min(
                    pageSize.GetWidth() / imgWidth,
                    pageSize.GetHeight() / imgHeight
                );
            }

            float drawWidth = imgWidth * scale;
            float drawHeight = imgHeight * scale;

            float x = (pageSize.GetWidth() - drawWidth) / 2;
            float y = (pageSize.GetHeight() - drawHeight) / 2;

            // 🔑 THIS is the correct call
            canvas.AddImageWithTransformationMatrix(
                imgData,
                drawWidth, 0,
                0, drawHeight,
                x, y
            );
        }
        catch (Exception e)
        {
            Log.Error(e, "exception");
            return false;
        }

        return true;
    }



    private static bool CreatePageSizeBasedOnImage(
        PdfDocument pdf,
        string imagePath)
    {
        try
        {
            var imgData = ImageDataFactory.Create(imagePath);

            float imgWidth = imgData.GetWidth();
            float imgHeight = imgData.GetHeight();

            PageSize pageSize = new PageSize(imgWidth, imgHeight);
            PdfPage page = pdf.AddNewPage(pageSize);

            PdfCanvas canvas = new PdfCanvas(page);

            // Draw image 1:1 at (0,0)
            canvas.AddImageWithTransformationMatrix(
                imgData,
                imgWidth, 0,
                0, imgHeight,
                0, 0
            );
        }
        catch (Exception e)
        {
            Log.Error(e, "exception");
            return false;
        }

        return true;
    }



}
