using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using PdfMerger.Config;



namespace PdfMerger.Classes;

public static class PdfFromImage
{
    private static readonly PageSize A4 = PageSize.A4;


    public static string? Create(string imagePath)
    {
        eImagePlacementMode mode = (eImagePlacementMode)ConfigManager.Config.ImagePlacementMode;

        try
        {
            var tempFile = GetTempFileName(imagePath);

            using var writer = new PdfWriter(tempFile);
            using var pdf = new PdfDocument(writer);

            if (mode == eImagePlacementMode.Original)
            {
                if (!CreatePageSizeBasedOnImage(pdf, imagePath))
                {
                    return null;
                }
            }
            else
            {
                if (!CreateA4PageWithImage(pdf, imagePath, mode))
                {
                    return null;
                }
            }

            pdf.Close();
            return tempFile;
        }
        catch (Exception e)
        {
            Log.Error(e, "exception");
        }
        return null;
    }

    private static string GetTempFileName(string imagePath)
    {

        var fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(imagePath);
        var extension = System.IO.Path.GetExtension(imagePath);
        var tempFile = TempDirectory.GetTempFile(fileNameWithoutExtension, extension);
        var counter = 0;
        while (System.IO.Path.Exists(tempFile))
        {
            counter++;
            tempFile = TempDirectory.GetTempFile($"{fileNameWithoutExtension}_{counter}", extension);
        }

        return tempFile;
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
            using var doc = new Document(pdf);

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

            img.Scale(imgWidth * scale, imgHeight * scale);

            // Zentrieren
            float x = (pageSize.GetWidth() - img.GetImageScaledWidth()) / 2;
            float y = (pageSize.GetHeight() - img.GetImageScaledHeight()) / 2;

            img.SetFixedPosition(x,y);

            doc.Add(img);
            doc.Flush();
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

            var pageSize = new PageSize(
                imgData.GetWidth(),
                imgData.GetHeight()
            );

            var page = pdf.AddNewPage(pageSize);
            using var doc = new Document(pdf);

            var img = new iText.Layout.Element.Image(imgData);
            img.SetFixedPosition(0,0);

            doc.Add(img);
            doc.Flush();
        }
        catch (Exception e)
        {
            Log.Error(e, "exception");
            return false;
        }

        return true;
    }



}
