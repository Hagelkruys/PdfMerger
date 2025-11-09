using PdfMerger.Config;
using System.Drawing;

namespace PdfMerger.SettingsPanels
{
    public partial class General : SettingsUserControl
    {
        public General()
        {
            InitializeComponent();

            checkBoxShowFilenameExtension.Checked = ConfigManager.Config.ShowFilenameExtension;
            checkBoxSaveAsBundle.Checked = ConfigManager.Config.SaveAsBundle;
            checkBoxLoadEveryPage.Checked = ConfigManager.Config.LoadEveryPageWhenAddingPdf;
            checkBoxClearProducer.Checked = ConfigManager.Config.ClearProducerMetadata;


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
            checkBoxSaveAsBundle.Text = Properties.Strings.CBSaveAsBundle;
            checkBoxLoadEveryPage.Text = Properties.Strings.CBLoadEveryPage;
            checkBoxClearProducer.Text = Properties.Strings.CBClearProducer;
        }



        public override void Save()
        {
            ConfigManager.Config.ShowFilenameExtension = checkBoxShowFilenameExtension.Checked;
            ConfigManager.Config.SaveAsBundle = checkBoxSaveAsBundle.Checked;
            ConfigManager.Config.LoadEveryPageWhenAddingPdf = checkBoxLoadEveryPage.Checked;
            ConfigManager.Config.ClearProducerMetadata = checkBoxClearProducer.Checked;
            ConfigManager.Config.BundleCompressionLevel = comboBoxCompressionLevel.SelectedIndex;
            ConfigManager.Config.AppColorMode = cbColorMode.SelectedIndex;
        }
    }
}
