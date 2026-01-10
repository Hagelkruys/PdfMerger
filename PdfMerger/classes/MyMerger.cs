using iText.Kernel.Crypto;
using iText.Kernel.Pdf;
using PdfMerger.DocumentInfo;
using System.Text;

namespace PdfMerger.Classes;

internal static class MyMerger
{


    public static (bool, string) WriteMergedPdf(IEnumerable<Page> pages, 
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

            var writerProps = new WriterProperties();

            SetSecuritySettings(securitySettings, writerProps);


            using var writer = new PdfWriter(tempFile, writerProps);
            using var outputPdf = new PdfDocument(writer);

            SetMetaData(metaData, outputPdf);


            foreach (var page in pages)
            {
                Log.Debug("- add doc '{@doc}' page {@page}", page.FilePath, page.PageNumber);


                if(eDocumentType.pdf == page.DocumentType)
                {

                    using var inputPdf = new PdfDocument(new iText.Kernel.Pdf.PdfReader(page.FilePath));

                    if (page.PageNumber < 0)
                    {
                        inputPdf.CopyPagesTo(
                            1,
                            inputPdf.GetNumberOfPages(),
                            outputPdf);
                    }
                    else
                    {
                        inputPdf.CopyPagesTo(
                            page.PageNumber + 1,   // iText is 1-based
                            page.PageNumber + 1,
                            outputPdf
                        );
                    }
                }
                else if (eDocumentType.image == page.DocumentType)
                {
                    PdfFromImage.AppendImage(page.FilePath, outputPdf);
                }
                else
                {
                    Log.Error($"unknown document type {page.DocumentType}");
                    return (false, "unknown document type");
                }
            }


            outputPdf.Close();
            Log.Debug("- finished");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "exception in write merged pdf");
            return (false, "Exception: " + ex.Message);
        }


        File.Move(tempFile, outputPath, true);
        Log.Information("pdf successfully exported to {@outputPath}", outputPath);
        return (true, "");
    }

    private static void SetSecuritySettings(SecuritySettings securitySettings, WriterProperties writerProps)
    {
        if (!securitySettings.IsDocumentRestricted)
        {
            return;
        }

        byte[]? userPwd = null;
        if(!string.IsNullOrWhiteSpace(securitySettings.UserPassword))
        {
            userPwd = Encoding.UTF8.GetBytes(securitySettings.UserPassword);
        }

        byte[] ownerPwd = [];
        if (!string.IsNullOrWhiteSpace(securitySettings.OwnerPassword))
        {
            ownerPwd = Encoding.UTF8.GetBytes(securitySettings.OwnerPassword);
        }
        else
        {
            ownerPwd = Encoding.UTF8.GetBytes(RandomPassword.Generate(32));
        }

        int permissions = 0;
        if (securitySettings.PermitPrint) 
            permissions |= EncryptionConstants.ALLOW_PRINTING;
        if (securitySettings.PermitModifyDocument) 
            permissions |= EncryptionConstants.ALLOW_MODIFY_CONTENTS;
        if (securitySettings.PermitExtractContent) 
            permissions |= EncryptionConstants.ALLOW_COPY;
        if (securitySettings.PermitAnnotations) 
            permissions |= EncryptionConstants.ALLOW_MODIFY_ANNOTATIONS;
        if (securitySettings.PermitFormsFill) 
            permissions |= EncryptionConstants.ALLOW_FILL_IN;
        if (securitySettings.PermitAssembleDocument) 
            permissions |= EncryptionConstants.ALLOW_ASSEMBLY;
        if (securitySettings.PermitFullQualityPrint) 
            permissions |= EncryptionConstants.ALLOW_DEGRADED_PRINTING;

        writerProps.SetStandardEncryption(
            userPwd,
            ownerPwd,
            permissions,
            EncryptionConstants.ENCRYPTION_AES_256
        );
    }

    private static void SetMetaData(MetaData metaData, PdfDocument outputPdf)
    {
        Log.Debug("- write metadata");

        var info = outputPdf.GetDocumentInfo();

        info.SetTitle(metaData.Title);
        info.SetAuthor(metaData.Author);
        info.SetSubject(metaData.Subject);
        info.SetKeywords(metaData.GetKeywords());
        info.SetCreator(metaData.Creator);
        //info.SetCreationDate(DateTime.Now);
        //info.SetModDate(DateTime.Now);
    }
}
