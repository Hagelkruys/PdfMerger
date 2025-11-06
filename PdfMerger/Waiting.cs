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
    public partial class Waiting : Form
    {
        public Waiting()
        {
            InitializeComponent();
        }

        public void SetStatus(string message)
        {
            labelStatus.Text = message;
            labelStatus.Refresh();
        }

        public void CenterTo(Form parent)
        {
            if(parent is null)
            {
                return;
            }

            var x = parent.Left + (parent.Width - this.Width) / 2;
            var y = parent.Top + (parent.Height - this.Height) / 2;
            this.Location = new Point(Math.Max(0, x), Math.Max(0, y));
        }
    }
}
