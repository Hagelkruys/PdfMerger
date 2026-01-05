

namespace PdfMerger.Classes;

public static class TempDirectory
{
    public static string TempPath { get; private set; } = string.Empty;

    public static void Init()
    {
        TempPath = System.IO.Path.Combine(
            System.IO.Path.GetTempPath(),
            "pdfmerger_" + Guid.NewGuid().ToString("N")
        );

        Directory.CreateDirectory(TempPath);

        Log.Information($"Temp Dir={TempPath}");

        AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
    }


    private static void OnProcessExit(object? sender, EventArgs e)
    {
        CleanUp();
        AppDomain.CurrentDomain.ProcessExit -= OnProcessExit;
    }


    public static void CleanUp(bool exit = true)
    {
        try
        {
            if (Directory.Exists(TempPath))
            {
                Directory.Delete(TempPath, recursive: true);
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "exception");
        }

        if(exit)
        {
            AppDomain.CurrentDomain.ProcessExit -= OnProcessExit;
        }
    }


    public static string GetTempFile(string filename) 
        => Path.Combine(TempPath, filename);


    public static string GetTempFile(string filename, string ext)
    => Path.Combine(TempPath, $"{filename}{ext}");

    public static string GetTempPath(string subpath, bool appendGuid = false)
    {
        var p = TempPath;

        if (appendGuid)
        {
            p = Path.Combine(TempPath, $"{subpath}_{Guid.NewGuid().ToString("N")}");
        }
        else
        {
            p = Path.Combine(TempPath, subpath);
        }
        Directory.CreateDirectory(p);
        return p;
    }
}

