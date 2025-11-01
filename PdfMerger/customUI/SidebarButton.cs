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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string HeaderText
        {
            get => button1.Text;
            set => button1.Text = value;
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Control? ContentControl { get; set; }


        public SidebarButton()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (expanded)
            {
                if (ContentControl is not null)
                {
                    ContentControl.Visible = false;
                }
                expanded = false;
            }
            else
            {
                if (ContentControl is not null)
                {
                    ContentControl.Visible = true;
                }
                expanded = true;
            }
            UpdateLayout();


            if (Parent is not null)
            {
                Parent.Update();
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
