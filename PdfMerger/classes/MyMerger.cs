using PdfMerger.Classes;
using PdfMerger.Config;
using PdfSharp.Pdf.IO;
using System;
using System.IO;
using System.Text;

namespace PdfMerger.classes
{
    internal static class MyMerger
    {


        public static bool WriteMergedPdf(List<PdfPage> pages, string outputPath, MetaData metaData)
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


                outputDoc.Info.Title = metaData.Title;
                outputDoc.Info.Author = metaData.Author;
                outputDoc.Info.Subject = metaData.Subject;
                outputDoc.Info.Keywords = metaData.GetKeywords();
                outputDoc.Info.Creator = metaData.Creator;
                outputDoc.Info.CreationDate = DateTime.Now;
                outputDoc.Info.ModificationDate = DateTime.Now;


                if (ConfigManager.Config.ClearProducerMetadata)
                {
                    using var ms = new MemoryStream();
                    outputDoc.Save(ms, false);
                    ClearProducerInStream(ms);
                    File.WriteAllBytes(outputPath, ms.ToArray());
                }
                else 
                {
                    outputDoc.Save(outputPath);
                }

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }



        private static readonly byte[] PATTER_PRODUCER = System.Text.Encoding.Latin1.GetBytes("/Producer (");

        private static void ClearProducerInStream(MemoryStream stream)
        {
            byte[] buffer = stream.GetBuffer();

            // locate the start of the producer field
            int index = FindBytes(buffer, PATTER_PRODUCER);
            if (index < 0)
            {
                return;
            }

            int start = index + PATTER_PRODUCER.Length;
            int end = Array.IndexOf(buffer, (byte)')', start);
            if (end <= start)
            {
                return;
            }

            int length = end - start;

            // overwrite with spaces (same byte count)
            for (int i = 0; i < length; i++)
            {
                buffer[start + i] = (byte)' ';
            }

            stream.Position = 0;
        }

        private static int FindBytes(byte[] byteBuffer, byte[] pattern)
        {
            for (int i = 0; i <= byteBuffer.Length - pattern.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (byteBuffer[i + j] != pattern[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
