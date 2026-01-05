using PdfMerger.Config;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace PdfMerger.Classes;

public static class PdfFromImage
{
    private static readonly XUnit a4Width = XUnit.FromMillimeter(210);
    private static readonly XUnit a4Height = XUnit.FromMillimeter(297);


    public static string? Create(string imagePath)
    {
        eImagePlacementMode mode = (eImagePlacementMode)ConfigManager.Config.ImagePlacementMode;

        try
        {
            using var document = new PdfDocument();


            if (eImagePlacementMode.Original == mode)
            {
                if (!CreatePageSizeBasedOnImage(document, imagePath))
                {
                    return null;
                }
            }
            else
            {
                if (!CreateA4PageWithImage(document, imagePath, mode))
                {
                    return null;
                }
            }



            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath);
            string extension = Path.GetExtension(imagePath);

            var tempFile = TempDirectory.GetTempFile(fileNameWithoutExtension,extension);
            int counter = 0;

            while (Path.Exists(tempFile))
            {
                counter++;
                tempFile = TempDirectory.GetTempFile($"{fileNameWithoutExtension}_{counter}",extension);
            }

            document.Save(tempFile);
            return tempFile;
        }
        catch (Exception e)
        {
            Log.Error(e, "exception");
        }
        return null;
    }


    private static bool CreateA4PageWithImage(PdfDocument document, string imagePath, eImagePlacementMode mode)
    {
        try
        {
            using var img = XImage.FromFile(imagePath);
            var page = document.AddPage();
            page.Width = a4Width;
            page.Height = a4Height;


            // Bildgröße in Punkten
            double imgWidth = img.PointWidth;
            double imgHeight = img.PointHeight;

            if (ConfigManager.Config.RotatePageToImage)
            {
                bool imageIsLandscape = imgWidth > imgHeight;
                bool pageIsLandscape = page.Width.Point > page.Height.Point;

                if (imageIsLandscape && !pageIsLandscape)
                {
                    page.Orientation = PageOrientation.Landscape;
                }

                imgWidth = img.PointWidth;
                imgHeight = img.PointHeight;
            }


            using var gfx = XGraphics.FromPdfPage(page);
            double scale = 1.0;

            if (eImagePlacementMode.Fill == mode)
            {
                // Skalierungsfaktor (FIT)
                scale = Math.Max(
                    page.Width.Point / imgWidth,
                    page.Height.Point / imgHeight
                );
            }
            else if (eImagePlacementMode.Fit == mode)
            {
                scale = Math.Min(
                    page.Width.Point / imgWidth,
                    page.Height.Point / imgHeight
                );
            }


            double drawWidth = imgWidth * scale;
            double drawHeight = imgHeight * scale;

            // Zentrieren
            double x = (page.Width.Point - drawWidth) / 2;
            double y = (page.Height.Point - drawHeight) / 2;

            gfx.DrawImage(img, x, y, drawWidth, drawHeight);
        }
        catch (Exception e)
        {
            Log.Error(e, "exception");
            return false;
        }
        return true;
    }



    private static bool CreatePageSizeBasedOnImage(PdfDocument document, string imagePath)
    {
        try
        {
            using var img = XImage.FromFile(imagePath);
            var page = document.AddPage();
            page.Width = XUnit.FromPoint(img.PointWidth);
            page.Height = XUnit.FromPoint(img.PointHeight);
            using var gfx = XGraphics.FromPdfPage(page);
            gfx.DrawImage(img, 0, 0, img.PointWidth, img.PointHeight);
        }
        catch(Exception e)
        {
            Log.Error(e, "exception");
            return false;
        }
        return true;
    }



}
