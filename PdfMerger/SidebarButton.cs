using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PdfMerger
{
    public partial class SidebarButton : UserControl
    {

        private bool expanded = true;

        public string HeaderText
        {
            get => button1.Text;
            set => button1.Text = value;
        }

        public event EventHandler? MyOnClick;

        public SidebarButton()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) => MyOnClick?.Invoke(sender, e);


        public bool Expanded
        {
            get => expanded;
            set
            {
                expanded = value;
                UpdateLayout();
            }
        }


        private void UpdateLayout()
        {
            if(expanded)
            {
                button1.ImageIndex = 1;
            }
            else
            {
                button1.ImageIndex = 0;
            }
        }
    }
}
