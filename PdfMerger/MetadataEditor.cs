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

            m_MetaData.GetListOfAuthors().ForEach(author =>
            {
                var btn = CreateButtonForFlowPanel(author);
                btn.Click += (s, e) => textBoxAuthor.Text = author;
                flowLayoutPanelAuthor.Controls.Add(btn);
            });


            m_MetaData.GetListOfCreators().ForEach(creator =>
            {
                var btn = CreateButtonForFlowPanel(creator);
                btn.Click += (s, e) => textBoxCreator.Text = creator;
                flowLayoutPanelCreator.Controls.Add(btn);
            });



            m_MetaData.GetListOfSubjects().ForEach(subject =>
            {
                var btn = CreateButtonForFlowPanel(subject);
                btn.Click += (s, e) => textBoxSubject.Text = subject;
                flowLayoutPanelSubject.Controls.Add(btn);
            });


            m_MetaData.GetListOfTitles().ForEach(title =>
            {
                var btn = CreateButtonForFlowPanel(title);
                btn.Click += (s, e) => textBoxTitel.Text = title;
                flowLayoutPanelTitel.Controls.Add(btn);
            });
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


        private Button CreateButtonForFlowPanel(string text)
        {
            return new Button
            {
                Text = text,
                AutoSize = true,
                Padding = new Padding(4, 2, 4, 2),
                Margin = new Padding(2),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
            };
        }
    }
}
