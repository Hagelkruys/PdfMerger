using PdfMerger.Config;

namespace PdfMerger.Classes;

public static class Updater
{
    private const string RepoOwner = "Hagelkruys";
    private const string RepoName = "PdfMerger";
    private const string GitHubApiUrl = $"https://api.github.com/repos/{RepoOwner}/{RepoName}/releases/latest";
    private const int UpdateCheckerFrequency = 7;


    public static bool ShouldCheckForUpdate()
    {
        var diff = DateTime.UtcNow - ConfigManager.Config.GetLastUpdateCheck();
        if (diff.TotalDays > UpdateCheckerFrequency)
        {
            return true;
        }
        return false; 
    }


    public static async Task CheckForUpdateAsync(bool showDialog)
    {
        ConfigManager.Config.SetLastUpdateCheck();
        using var client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.ParseAdd("PdfMergerApp/1.0");

        var json = await client.GetStringAsync(GitHubApiUrl);
        using var doc = JsonDocument.Parse(json);

        var latestTag = doc.RootElement.GetProperty("tag_name").GetString(); // e.g. "v1.3.0"
        if(latestTag is null)
        {
            return;
        }

        var htmlUrl = doc.RootElement.GetProperty("html_url").GetString();

        var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
        if (Version.TryParse(latestTag.TrimStart('v'), out var latestVersion))
        {
            if (latestVersion > currentVersion)
            {
                var res = MessageBox.Show(
                    Properties.Strings.UpdateMsg.Replace("#version#", latestVersion.ToString()),
                    Properties.Strings.UpdateTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (DialogResult.Yes == res)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = htmlUrl,
                        UseShellExecute = true
                    });
                }
            }
            else if (showDialog)
            {
                MessageBox.Show(
                    Properties.Strings.NoUpdateMsg,
                    Properties.Strings.NoUpdateTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }

}
