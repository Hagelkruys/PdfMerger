using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO.Compression;

namespace PdfMerger.Config
{
    public static class ProjectConfigManager
    {
        private static JsonSerializerOptions SerialierOptions = new(){ 
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };


        public static bool Save(string name, 
            DateTime created,
            List<PdfPage> pages,
            string outputPath,
            bool zip = false)
        {
            string baseDir = Path.GetDirectoryName(outputPath) ?? "";


            var config = new ProjectConfig()
            {
                Created = created,
                ProjectName = name,
                PdfFiles = new List<ProjectConfigPdfEntry>()
            };


            


            if (zip)
            {
                string tempDir = Path.Combine(Path.GetTempPath(), "PdfProject_" + Guid.NewGuid());
                Directory.CreateDirectory(tempDir);

                // Copy PDFs into the temp folder
                foreach (var entry in pages)
                {
                    string destFile = Path.Combine(tempDir, Path.GetFileName(entry.FilePath));
                    File.Copy(entry.FilePath, destFile, true);
                    var fileName = Path.GetFileName(entry.FilePath); // store only filename in bundle

                    config.PdfFiles.Add(new ProjectConfigPdfEntry()
                    {
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

                ZipFile.CreateFromDirectory(tempDir, outputPath, 
                    CompressionLevel.NoCompression, 
                    includeBaseDirectory: false);

                Directory.Delete(tempDir, true);
            }
            else
            {
                foreach (var pdf in pages)
                {
                    if (Path.IsPathRooted(pdf.FilePath))
                    {
                        config.PdfFiles.Add(new ProjectConfigPdfEntry()
                        {
                            FilePathAbsolute = pdf.FilePath,
                            FilePathRelative = Path.GetRelativePath(baseDir, pdf.FilePath)
                        });
                    }
                    else
                    {
                        config.PdfFiles.Add(new ProjectConfigPdfEntry()
                        {
                            FilePathAbsolute = Path.GetFullPath(pdf.FilePath),
                            FilePathRelative = pdf.FilePath
                        });
                    }
                }



                string json = JsonSerializer.Serialize(config, SerialierOptions);
                File.WriteAllText(outputPath, json);
            }
            return true; 
        }


        public static (ProjectConfig, string) Load(string filePath)
        {
            if (IsZipFile(filePath))
            {
                string extractDir = Path.Combine(Path.GetTempPath(), "PdfBundle_" + Guid.NewGuid());
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
            else
            {
                string baseDir = Path.GetDirectoryName(filePath) ?? "";
                string json = File.ReadAllText(filePath);
                var project = JsonSerializer.Deserialize<ProjectConfig>(json, SerialierOptions)!;

                return (project, baseDir);
            }
        }


        private static bool IsZipFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            byte[] signature = new byte[4];
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                fs.Read(signature, 0, 4);
            }

            // Local ZIP header: 0x50 0x4B 0x03 0x04
            if(signature[0] == 0x50 &&  signature[1] == 0x4B && signature[2] == 0x03 && signature[3] == 0x04)
            {
                return true; 
            }

            // Empty Archive ZIP header: 0x50 0x4B 0x05 0x06
            if (signature[0] == 0x50 && signature[1] == 0x4B && signature[2] == 0x05 && signature[3] == 0x06)
            {
                return true;
            }

            // Spanned/slit Archive ZIP header: 0x50 0x4B 0x07 0x08
            //if (signature[0] == 0x50 && signature[1] == 0x4B && signature[2] == 0x05 && signature[3] == 0x06)
            //{
            //    return true;
            //}

            return false; 
        }
    }
}
