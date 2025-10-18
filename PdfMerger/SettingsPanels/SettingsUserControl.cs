using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfMerger.SettingsPanels
{
    // virutal, should be abstract but with abstract keyword the design doesnt work
    public class SettingsUserControl: UserControl
    {
        public virtual void Save()
        {

        }
    }
}
