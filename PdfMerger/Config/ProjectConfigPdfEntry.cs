namespace PdfMerger.Config
{
    public class ProjectConfigPdfEntry
    {
        public string FilePathAbsolute { get; set; } = string.Empty;
        public string FilePathRelative { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 0;
    }
}
