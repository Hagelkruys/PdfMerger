using PdfMerger.Classes;
using PdfMerger.Config;

namespace PdfMerger.SettingsPanels;

public partial class RenderSettings : SettingsUserControl
{
    public RenderSettings()
    {
        InitializeComponent();
        cbAddBorder.Checked = ConfigManager.Config.PdfRenderAddBorder;
        cbWhiteBackground.Checked = ConfigManager.Config.PdfRenderAddWhiteBackground;
        numBorderWidth.Value = ConfigManager.Config.PdfRenderAddBorderWidth;


        cbAddBorder.Text = Properties.Strings.CBAddBorder; 
        labelBorderWidth.Text = Properties.Strings.BorderWidth +":";
        cbWhiteBackground.Text = Properties.Strings.CBWhiteBackground;
    }



    public override void Save()
    {
        ConfigManager.Config.PdfRenderAddBorder = cbAddBorder.Checked;
        ConfigManager.Config.PdfRenderAddWhiteBackground = cbWhiteBackground.Checked;
        ConfigManager.Config.PdfRenderAddBorderWidth = (int)numBorderWidth.Value;

        MyPdfRenderer.Init();
    }
}
