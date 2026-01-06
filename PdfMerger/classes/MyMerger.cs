using PdfMerger.Config;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System.Text;

namespace PdfMerger.Classes;

internal static class MyMerger
{


    public static (bool, string) WriteMergedPdf(IEnumerable<PdfPage> pages, 
        string outputPath, 
        MetaData metaData,
        SecuritySettings securitySettings)
    {

        if (string.IsNullOrWhiteSpace(outputPath))
        {
            Log.Error("output path is invalid");
            return (false, "output path is invalid");
        }

        var tempFile = TempDirectory.GetTempFile(Guid.NewGuid().ToString("N"), ".pdf");

        try
        {
            Log.Debug("Start output doc");
            using (var outputDoc = new PdfSharp.Pdf.PdfDocument())
            {

                SetMetaData(metaData, outputDoc);
                SetSecuritySettings(securitySettings, outputDoc);

                List<PdfSharp.Pdf.PdfDocument> listInputDocs = new List<PdfSharp.Pdf.PdfDocument>();
                foreach (var page in pages)
                {
                    Log.Debug("- add doc '{@doc}' page {@page}", page.FilePath, page.PageNumber);
                    var inputDoc = PdfReader.Open(page.FilePath, PdfDocumentOpenMode.Import);
                    listInputDocs.Add(inputDoc);
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

                outputDoc.Save(tempFile);
                outputDoc.Close();
                Log.Debug("- finished");

                foreach (var doc in listInputDocs)
                {
                    try
                    {
                        doc.Close();
                    }
                    catch { }

                    try 
                    { 
                        doc.Dispose();
                    }
                    catch { }
                }
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "exception in write merged pdf");
            return (false, "Exception: " + ex.Message);
        }


        var bytes = File.ReadAllBytes(tempFile);
        var text = Encoding.ASCII.GetString(bytes[^Math.Min(bytes.Length, 1024)..]);
        if (!text.Contains("%%EOF"))
        {
            Log.Error("PDF missing EOF marker");
        }


        File.Move(tempFile, outputPath, true);
        Log.Information("pdf successfully exported to {@outputPath}", outputPath);
        return (true, "");
    }

    private static void SetSecuritySettings(SecuritySettings securitySettings, PdfSharp.Pdf.PdfDocument outputDoc)
    {
        if (!securitySettings.IsDocumentRestricted)
        {
            return;
        }

        //security settings test 
        PdfSecuritySettings pdfSecurity = outputDoc.SecuritySettings;
        pdfSecurity.UserPassword = securitySettings.UserPassword;
        pdfSecurity.PermitPrint = securitySettings.PermitPrint;
        pdfSecurity.PermitModifyDocument = securitySettings.PermitModifyDocument;
        pdfSecurity.PermitExtractContent = securitySettings.PermitExtractContent;
        pdfSecurity.PermitAnnotations = securitySettings.PermitAnnotations;
        pdfSecurity.PermitFormsFill = securitySettings.PermitFormsFill;
        pdfSecurity.PermitAssembleDocument = securitySettings.PermitAssembleDocument;
        pdfSecurity.PermitFullQualityPrint = securitySettings.PermitFullQualityPrint;

        if (string.IsNullOrWhiteSpace(securitySettings.OwnerPassword))
        {
            pdfSecurity.OwnerPassword = RandomPassword.Generate(32);
        }
        else
        {

            pdfSecurity.OwnerPassword = securitySettings.OwnerPassword;
        }

        outputDoc.SecurityHandler.SetEncryption(PdfDefaultEncryption.V5);
    }

    private static void SetMetaData(MetaData metaData, PdfSharp.Pdf.PdfDocument outputDoc)
    {
        Log.Debug("- write metadata");
        outputDoc.Info.Title = metaData.Title;
        Log.Debug("-- Title: {@Title}", metaData.Title);
        outputDoc.Info.Author = metaData.Author;
        Log.Debug("-- Author: {@Author}", metaData.Author);
        outputDoc.Info.Subject = metaData.Subject;
        Log.Debug("-- Subject: {@Subject}", metaData.Subject);
        outputDoc.Info.Keywords = metaData.GetKeywords();
        Log.Debug("-- Keywords: {@Keywords}", outputDoc.Info.Keywords);
        outputDoc.Info.Creator = metaData.Creator;
        Log.Debug("-- Creator: {@Creator}", metaData.Creator);
        outputDoc.Info.CreationDate = DateTime.Now;
        outputDoc.Info.ModificationDate = DateTime.Now;
    }
}
