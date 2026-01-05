
using PdfMerger.Classes;

namespace PdfMerger.Config;

public static class ProjectConfigManager
{
    private static JsonSerializerOptions SerialierOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };


    public static bool Save(string name,
        DateTime created,
        IEnumerable<PdfPage> pages,
        string outputPath)
    {
        string baseDir = Path.GetDirectoryName(outputPath) ?? "";


        var config = new ProjectConfig()
        {
            Created = created,
            ProjectName = name,
            PdfFiles = new List<ProjectConfigPdfEntry>()
        };



        string tempDir = TempDirectory.GetTempPath("PdfProject", true);


        // Copy PDFs into the temp folder
        var files = pages.Select(r => r.FilePath).Distinct();
        foreach (var entry in files)
        {
            string destFile = Path.Combine(tempDir, Path.GetFileName(entry));
            File.Copy(entry, destFile, true);
        }

        foreach (var entry in pages)
        {
            var fileName = Path.GetFileName(entry.FilePath); // store only filename in bundle

            config.PdfFiles.Add(new ProjectConfigPdfEntry()
            {
                PageNumber = entry.PageNumber,
                FilePathRelative = fileName
            });
        }

        string jsonPath = Path.Combine(tempDir, "project.json");
        string json = JsonSerializer.Serialize(config, SerialierOptions);
        File.WriteAllText(jsonPath, json);

        if (File.Exists(outputPath))
        {
            File.Delete(outputPath);
        }

        CompressionLevel l = (CompressionLevel)ConfigManager.Config.BundleCompressionLevel;

        ZipFile.CreateFromDirectory(tempDir, outputPath,
            l,
            includeBaseDirectory: false);

        Directory.Delete(tempDir, true);
       
        return true;
    }


    public static (ProjectConfig?, string) Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return (null, string.Empty);
        }

        string extractDir = TempDirectory.GetTempPath("PdfBundle", true);
        ZipFile.ExtractToDirectory(filePath, extractDir);

        string jsonPath = Path.Combine(extractDir, "project.json");
        string json = File.ReadAllText(jsonPath);
        var project = JsonSerializer.Deserialize<ProjectConfig>(json, SerialierOptions)!;

        foreach (var pdf in project.PdfFiles)
        {
            pdf.FilePathAbsolute = Path.Combine(extractDir, pdf.FilePathRelative);
        }
        return (project, extractDir);

    }
}
