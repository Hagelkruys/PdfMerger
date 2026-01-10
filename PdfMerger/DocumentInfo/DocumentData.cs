namespace PdfMerger.DocumentInfo;
internal sealed class DocumentData
{
    public string FilePath { get; set; } = string.Empty;
    public string FileName => System.IO.Path.GetFileName(FilePath);
    public int PageCount { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Creator { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime LastModified { get; set; }
    public DateTime CreationTime { get; set; }
    public eDocumentType DocumentType { get; set; } = eDocumentType.pdf;

    public override string ToString() => $"{FileName} ({PageCount} pages)";
}
