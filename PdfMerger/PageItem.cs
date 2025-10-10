namespace PdfMerger
{
    public class PageItem
    {
        public string FilePath { get; set; } = "";
        public int PageIndex { get; set; } // 0-based
        public override string ToString() => $"{Path.GetFileName(FilePath)} — Seite {PageIndex + 1}";
    }
}
