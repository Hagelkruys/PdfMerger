using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfMerger
{
    public partial class MetadataEditor : Form
    {
        public MetadataEditor()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e) => this.Close();

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //TODO: !!


            this.Close();
        }
    }
}
