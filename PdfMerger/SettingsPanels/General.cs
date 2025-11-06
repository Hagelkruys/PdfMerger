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


            comboBoxCompressionLevel.Items.Add("optimal");
            comboBoxCompressionLevel.Items.Add("fastest");
            comboBoxCompressionLevel.Items.Add("no compression");
            comboBoxCompressionLevel.Items.Add("smallest size");
            comboBoxCompressionLevel.SelectedIndex = ConfigManager.Config.BundleCompressionLevel;


            cbColorMode.Items.Add("Classic");
            cbColorMode.Items.Add("System");
            cbColorMode.Items.Add("Dark");
            cbColorMode.SelectedIndex = ConfigManager.Config.AppColorMode;
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
