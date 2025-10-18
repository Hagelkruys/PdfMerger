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
    public partial class General : UserControl
    {
        public General()
        {
            InitializeComponent();

            checkBoxShowFilenameExtension.Checked = ConfigManager.Config.ShowFilenameExtension;
        }

        private void checkBoxShowFilenameExtension_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.ShowFilenameExtension = checkBoxShowFilenameExtension.Checked;
        }
    }
}
