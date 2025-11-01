using PdfMerger.classes;
using PdfMerger.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
