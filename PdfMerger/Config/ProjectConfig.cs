using PdfMerger.Classes;

namespace PdfMerger.Config;

public class ProjectConfig
{
    public int Version { get; set; } = 1;
    public string ProjectName { get; set; } = "Untitled";

    [JsonConverter(typeof(DateTimeToLongConverter))]
    public DateTime Created { get; set; } = DateTime.Now;
    public List<ProjectConfigPdfEntry> PdfFiles { get; set; } = new();
    public MetaData MetaData { get; set; } = new();
    public SecuritySettings SecuritySettings { get; set; } = new();
}
