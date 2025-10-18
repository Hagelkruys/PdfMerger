using PdfMerger.Config;

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
        }



        public override void Save()
        {
            ConfigManager.Config.ShowFilenameExtension = checkBoxShowFilenameExtension.Checked;
            ConfigManager.Config.SaveAsBundle = checkBoxSaveAsBundle.Checked;
            ConfigManager.Config.LoadEveryPageWhenAddingPdf = checkBoxLoadEveryPage.Checked;
        }
    }
}
