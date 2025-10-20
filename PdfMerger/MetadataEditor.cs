using PdfMerger.Classes;
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
        private MetaData m_MetaData;

        public MetadataEditor(MetaData metaData)
        {
            m_MetaData = metaData;
            InitializeComponent();

            textBoxAuthor.Text = m_MetaData.Author;
            textBoxCreator.Text = m_MetaData.Creator;
            textBoxTitel.Text = m_MetaData.Title;
            textBoxSubject.Text = m_MetaData.Subject;

            //TODO: Keywords
        }

        private void buttonCancel_Click(object sender, EventArgs e) => this.Close();

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //TODO: !!


            m_MetaData.Author = textBoxAuthor.Text;
            m_MetaData.Creator = textBoxCreator.Text;
            m_MetaData.Title = textBoxTitel.Text;
            m_MetaData.Subject = textBoxSubject.Text;
            this.Close();
        }
    }
}
