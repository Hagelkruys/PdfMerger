namespace PdfMerger.Classes;

public sealed class SecuritySettings
{
    public string UserPassword { get; set; } = "";  // empty user password → open without password
    public string OwnerPassword { get; set; } = ""; // owner password can remain non-empty
    public bool PermitPrint { get; set; } = true;
    public bool PermitModifyDocument { get; set; } = true;
    public bool PermitExtractContent { get; set; } = true;
    public bool PermitAnnotations { get; set; } = true;
    public bool PermitFormsFill { get; set; } = true;
    public bool PermitAssembleDocument { get; set; } = true;
    public bool PermitFullQualityPrint { get; set; } = true;


    [JsonIgnore]
    public bool IsDocumentRestricted => !PermitPrint &
        !PermitModifyDocument |
        !PermitExtractContent |
        !PermitAnnotations |
        !PermitFormsFill |
        !PermitAssembleDocument |
        !PermitFullQualityPrint;

}
