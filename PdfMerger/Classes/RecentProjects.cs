namespace PdfMerger.Classes;

public class RecentProjects
{
    private const int MaxItems = 10;
    private readonly string m_filePath;

    public List<string> Items { get; private set; } = new();

    public RecentProjects()
    {
        string appDataFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "PdfMerger");

        if (!Directory.Exists(appDataFolder))
        {
            Directory.CreateDirectory(appDataFolder);
        }

        m_filePath = Path.Combine(appDataFolder, "recent_projects.json");
        Load();
    }

    public void Add(string path)
    {
        path = Path.GetFullPath(path);

        // Remove if already exists
        Items.RemoveAll(p => string.Equals(p, path, StringComparison.OrdinalIgnoreCase));

        // Insert at top
        Items.Insert(0, path);

        // Limit size
        if (Items.Count > MaxItems)
            Items.RemoveRange(MaxItems, Items.Count - MaxItems);

        Save();
    }

    public void Load()
    {
        if (!File.Exists(m_filePath))
            return;

        try
        {
            var json = File.ReadAllText(m_filePath);
            Items = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
        }
        catch
        {
            Items = new List<string>();
        }
    }

    public void Save()
    {
        try
        {
            var json = JsonSerializer.Serialize(Items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(m_filePath, json);
        }
        catch { }
    }
}
