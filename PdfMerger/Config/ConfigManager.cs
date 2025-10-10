using System.Text.Json;

namespace PdfMerger.Config
{
    public static class ConfigManager
    {
        private static JsonSerializerOptions serialierOptions = new JsonSerializerOptions { WriteIndented = true };


        public static AppConfig Config { get; private set; } = new();

        public static void Load()
        {
            var path = GetConfigPath();
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                Config = JsonSerializer.Deserialize<AppConfig>(json) ?? new AppConfig();
            }
        }

        public static void Save()
        {
            var path = GetConfigPath();
            var dirName = Path.GetDirectoryName(path);
            if (!string.IsNullOrWhiteSpace(dirName))
            {
                Directory.CreateDirectory(dirName);
            }

            var json = JsonSerializer.Serialize(Config, serialierOptions);
            File.WriteAllText(path, json);
        }



        private static string GetConfigPath()
        {
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(appdata, "PDFMergerApp", "config.json");
        }
    }
}
