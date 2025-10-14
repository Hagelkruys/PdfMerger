namespace PdfMerger.Config
{
    public class ProjectConfig
    {
        public int Version { get; set; } = 1;
        public string ProjectName { get; set; } = "Untitled";
        public DateTime Created { get; set; } = DateTime.Now;
        public List<ProjectConfigPdfEntry> PdfFiles { get; set; } = new();
    }
}
