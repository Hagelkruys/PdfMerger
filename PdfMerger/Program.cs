using PdfMerger.classes;
using PdfMerger.Config;
using Serilog;
using System.Globalization;

namespace PdfMerger;

static class Program
{

    public static readonly CultureInfo DefaultCurrentCulture = CultureInfo.CurrentCulture;
    public static readonly CultureInfo DefaultCurrentUICulture = CultureInfo.CurrentUICulture;

    [STAThread]
    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

        string logDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "PdfMerger",
            "Logs"
        );
        Directory.CreateDirectory(logDirectory);
        string logPath = Path.Combine(logDirectory, "app-.log");

        // Configure Serilog with automatic file rotation
        Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .WriteTo.File(
                path: logPath,
                rollingInterval: RollingInterval.Day, // rotates daily
                retainedFileCountLimit: 7,            // keep 7 days
                fileSizeLimitBytes: 10_000_000,       // optional: 10 MB
                rollOnFileSizeLimit: true,            // rotate when size exceeded
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1)
            )
            .CreateLogger();


        Log.Information("Starting application");

        try
        {
            ConfigManager.Load();
            MyPdfRenderer.Init();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

#pragma warning disable WFO5001
            if ((int)SystemColorMode.Classic != ConfigManager.Config.AppColorMode)
            {
                Application.SetColorMode((SystemColorMode)ConfigManager.Config.AppColorMode);
            }
#pragma warning restore WFO5001
            ApplicationConfiguration.Initialize();


            if (null != ConfigManager.Config.Language)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(ConfigManager.Config.Language);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigManager.Config.Language);
            }

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

            if (args.Length > 0)
            {
                string filePath = args[0];
                if (System.IO.File.Exists(filePath))
                {
                    try
                    {
                        mainForm.Shown += async (s, e) =>
                        {
                            await mainForm.LoadProject(filePath);
                        };
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to open file:\n{ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }


        Log.Information("Ending application");
    }


    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        try
        {
            Exception ex = (Exception)e.ExceptionObject;
            string logDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "PdfMerger",
                "Logs"
            );
            Directory.CreateDirectory(logDir);
            string logPath = Path.Combine(logDir, "error.log");

            string message = $"[{DateTime.Now}] Unhandled exception: {ex.Message}\n{ex.StackTrace}\n";
            File.AppendAllText(logPath, message);

            // Optionally also show it or send elsewhere
            Console.WriteLine("An unhandled exception occurred. See error.log for details.");
        }
        finally
        {
            System.Environment.Exit(-1);
        }
    }
}