using PdfMerger.Classes;
using PdfMerger.Config;
using System.Drawing;

namespace PdfMerger.SettingsPanels;

public partial class General : SettingsUserControl
{

    private static readonly Dictionary<string, string?> LangToCode = new()
    {
        { Properties.Strings.LanguageDE, "DE" },
        { Properties.Strings.LanguageEN, "EN" },
        { Properties.Strings.LanguageAuto, null }
    };

    public General()
    {
        InitializeComponent();

        checkBoxShowFilenameExtension.Checked = ConfigManager.Config.ShowFilenameExtension;
        checkBoxLoadEveryPage.Checked = ConfigManager.Config.LoadEveryPageWhenAddingPdf;


        comboBoxCompressionLevel.Items.Add(Properties.Strings.ZipCompressionOptimal);
        comboBoxCompressionLevel.Items.Add(Properties.Strings.ZipCompressionFastest);
        comboBoxCompressionLevel.Items.Add(Properties.Strings.ZipCompressionNoCompression);
        comboBoxCompressionLevel.Items.Add(Properties.Strings.ZipCompressionSmallestSize);
        comboBoxCompressionLevel.SelectedIndex = ConfigManager.Config.BundleCompressionLevel;


        cbColorMode.Items.Add(Properties.Strings.ColorModeClassic);
        cbColorMode.Items.Add(Properties.Strings.ColorModeSystem);
        cbColorMode.Items.Add(Properties.Strings.ColorModeDark);
        cbColorMode.SelectedIndex = ConfigManager.Config.AppColorMode;

        labelCompressionLevel.Text = Properties.Strings.CompressionLevelText;
        labelColorMode.Text = Properties.Strings.ColorMode;
        labelColorModeRestart.Text = Properties.Strings.ColorModeRestart;
        checkBoxShowFilenameExtension.Text = Properties.Strings.CBShowFilenameExtension;
        checkBoxLoadEveryPage.Text = Properties.Strings.CBLoadEveryPage;
        labelLanguage.Text = Properties.Strings.Language;



        comboBoxLanguage.Items.Add(new ComboBoxItem(Properties.Strings.LanguageAuto, null));
        comboBoxLanguage.Items.Add(new ComboBoxItem(Properties.Strings.LanguageEN,"EN"));
        comboBoxLanguage.Items.Add(new ComboBoxItem(Properties.Strings.LanguageDE,"DE"));
        comboBoxLanguage.SelectedIndex = 0;

        if (ConfigManager.Config.Language is not null)
        {
            if(0 == string.Compare(ConfigManager.Config.Language,"EN",true))
            {
                comboBoxLanguage.SelectedIndex = 1;
            }
            else if (0 == string.Compare(ConfigManager.Config.Language, "DE", true))
            {
                comboBoxLanguage.SelectedIndex = 2;
            }
        }
    }



    public override void Save()
    {
        ConfigManager.Config.ShowFilenameExtension = checkBoxShowFilenameExtension.Checked;
        ConfigManager.Config.LoadEveryPageWhenAddingPdf = checkBoxLoadEveryPage.Checked;
        ConfigManager.Config.BundleCompressionLevel = comboBoxCompressionLevel.SelectedIndex;
        ConfigManager.Config.AppColorMode = cbColorMode.SelectedIndex;
        ConfigManager.Config.Language = (comboBoxLanguage.SelectedItem as ComboBoxItem)?.Value;
    }
}
