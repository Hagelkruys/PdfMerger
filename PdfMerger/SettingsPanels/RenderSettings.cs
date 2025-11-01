using PdfMerger.classes;
using PdfMerger.Config;

namespace PdfMerger.SettingsPanels
{
    public partial class RenderSettings : SettingsUserControl
    {
        public RenderSettings()
        {
            InitializeComponent();
            //checkBoxShowFilenameExtension.Checked = ConfigManager.Config.PdfRenderMaxWidth;
            //checkBoxSaveAsBundle.Checked = ConfigManager.Config.PdfRenderMaxHeight;
            cbAddBorder.Checked = ConfigManager.Config.PdfRenderAddBorder;
            cbWhiteBackground.Checked = ConfigManager.Config.PdfRenderAddWhiteBackground;
            numBorderWidth.Value = ConfigManager.Config.PdfRenderAddBorderWidth;
        }



        public override void Save()
        {
            //ConfigManager.Config.ShowFilenameExtension = checkBoxShowFilenameExtension.Checked;
            //ConfigManager.Config.SaveAsBundle = checkBoxSaveAsBundle.Checked;
            ConfigManager.Config.PdfRenderAddBorder = cbAddBorder.Checked;
            ConfigManager.Config.PdfRenderAddWhiteBackground = cbWhiteBackground.Checked;
            ConfigManager.Config.PdfRenderAddBorderWidth = (int)numBorderWidth.Value;

            MyPdfRenderer.Init();
        }
    }
}
