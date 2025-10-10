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
    public partial class PdfPage : UserControl
    {
        public int PageNumber { get; set; }
        public string FilePath { get; set; } = string.Empty;

        public PdfPage(Image image, int pageNumber, string filePath)
        {
            InitializeComponent();

            pictureBox.Image = image;
            this.Tag = pageNumber;
            this.PageNumber = pageNumber;
            this.FilePath = filePath;
        }


        public void SetImage(Bitmap newImage)
        {
            var old = pictureBox.Image;
            pictureBox.Image = newImage;
            old?.Dispose();
        }

        public void SetSelected(bool selected)
        {
            //TODO: !
            //Invalidate(); // triggers repaint
        }
    }
}
