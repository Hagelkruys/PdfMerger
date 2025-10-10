using PdfSharp.Pdf.IO;

namespace PdfMerger
{
    internal static class MyMerger
    {


        public static bool WriteMergedPdf(List<PdfPage> pages, string outputPath)
        {

            if (string.IsNullOrWhiteSpace(outputPath))
            {
                return false;
            }

            try
            {
                using var outputDoc = new PdfSharp.Pdf.PdfDocument();
                foreach (var page in pages)
                {
                    using var inputDoc = PdfReader.Open(page.FilePath, PdfDocumentOpenMode.Import);
                    outputDoc.AddPage(inputDoc.Pages[page.PageNumber]);
                }

                outputDoc.Save(outputPath);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
