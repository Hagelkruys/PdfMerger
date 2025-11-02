using PdfMerger.Classes;
using PdfMerger.Config;
using PdfSharp.Pdf.IO;
using Serilog;

namespace PdfMerger.classes
{
    internal static class MyMerger
    {


        public static (bool, string) WriteMergedPdf(IEnumerable<PdfPage> pages, string outputPath, MetaData metaData)
        {

            if (string.IsNullOrWhiteSpace(outputPath))
            {
                Log.Error("output path is invalid");
                return (false, "output path is invalid");
            }

            try
            {
                Log.Debug("Start output doc");
                using var outputDoc = new PdfSharp.Pdf.PdfDocument();
                foreach (var page in pages)
                {
                    Log.Debug("- add doc '{@doc}' page {@page}", page.FilePath, page.PageNumber);
                    using var inputDoc = PdfReader.Open(page.FilePath, PdfDocumentOpenMode.Import);
                    if (page.PageNumber < 0)
                    {
                        foreach (var p in inputDoc.Pages)
                        {
                            outputDoc.AddPage(p);
                        }
                    }
                    else
                    {
                        outputDoc.AddPage(inputDoc.Pages[page.PageNumber]);
                    }
                }


                Log.Debug("- write metadata");
                outputDoc.Info.Title = metaData.Title;
                outputDoc.Info.Author = metaData.Author;
                outputDoc.Info.Subject = metaData.Subject;
                outputDoc.Info.Keywords = metaData.GetKeywords();
                outputDoc.Info.Creator = metaData.Creator;
                outputDoc.Info.CreationDate = DateTime.Now;
                outputDoc.Info.ModificationDate = DateTime.Now;


                if (ConfigManager.Config.ClearProducerMetadata)
                {
                    Log.Debug("- ClearProducerMetadata");
                    using var ms = new MemoryStream();
                    outputDoc.Save(ms, false);
                    ClearProducerInStream(ms);
                    File.WriteAllBytes(outputPath, ms.ToArray());
                }
                else
                {
                    outputDoc.Save(outputPath);
                }
                Log.Debug("- finished");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "exception in write merged pdf");
                return (false, "Exception: " + ex.Message);
            }

            Log.Information("pdf successfully exported to {@outputPath}", outputPath);
            return (true, "");
        }



        private static readonly byte[] PATTER_PRODUCER = System.Text.Encoding.Latin1.GetBytes("/Producer (");

        private static void ClearProducerInStream(MemoryStream stream)
        {
            try
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

            }
            catch (Exception ex)
            {
                Log.Error(ex, "exception in ClearProducerInStream");
            }
            finally
            {
                stream.Position = 0;
            }
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
