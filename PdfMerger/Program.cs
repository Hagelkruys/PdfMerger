using PdfMerger.classes;
using PdfMerger.Config;

namespace PdfMerger;

static class Program
{
    [STAThread]
    static void Main()
    {
        ConfigManager.Load();
        MyPdfRenderer.Init();

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(true);
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        ApplicationConfiguration.Initialize();

        var mainForm = new MainForm();


        var x = ConfigManager.Config.WindowX;
        var y = ConfigManager.Config.WindowY;
        if (x is not null && y is not null)
        {
            mainForm.StartPosition = FormStartPosition.Manual;
            mainForm.Location = new Point(x.Value, y.Value);
        }

        if (ConfigManager.Config.WindowWidth > 100 && ConfigManager.Config.WindowHeight > 100)
        {
            mainForm.Size = new Size(ConfigManager.Config.WindowWidth, ConfigManager.Config.WindowHeight);
        }

        Application.Run(mainForm);
    }
}