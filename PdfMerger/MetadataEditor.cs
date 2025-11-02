using PdfMerger.Classes;
using Serilog;

namespace PdfMerger
{
    public partial class MetadataEditor : Form
    {
        private MetaData m_MetaData;

        public MetadataEditor(MetaData metaData)
        {
            Log.Information("start MetadataEditor");
            m_MetaData = metaData;
            InitializeComponent();

            textBoxAuthor.Text = m_MetaData.Author;
            textBoxCreator.Text = m_MetaData.Creator;
            textBoxTitel.Text = m_MetaData.Title;
            textBoxSubject.Text = m_MetaData.Subject;

            foreach (string k in m_MetaData.Keywords)
            {
                lvKeywords.Items.Add(k);
            }


            lvKeywords.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvKeywords.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvKeywordsFromDocs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvKeywordsFromDocs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            m_MetaData.Keywords.ForEach(keyword =>
            {
                lvKeywords.Items.Add(keyword);
            });



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


            m_MetaData.GetListOfKeywords().ForEach(keyword =>
            {
                lvKeywordsFromDocs.Items.Add(keyword);
            });
        }

        private void buttonCancel_Click(object sender, EventArgs e) => this.Close();

        private void buttonSave_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem k in lvKeywords.SelectedItems)
            {
                m_MetaData.Keywords.Add(k.Text);
            }

            m_MetaData.Author = textBoxAuthor.Text;
            m_MetaData.Creator = textBoxCreator.Text;
            m_MetaData.Title = textBoxTitel.Text;
            m_MetaData.Subject = textBoxSubject.Text;
            this.Close();
        }


        private Button CreateButtonForFlowPanel(string text)
        {
            var btn = new Button
            {
                Text = text,
                AutoSize = true,
                Padding = new Padding(4, 2, 4, 2),
                Margin = new Padding(2),
                FlatStyle = FlatStyle.System,
                Cursor = Cursors.Hand,
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.FromArgb(60, 60, 60),
            };


            btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);

            return btn;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            var toRemove = new List<ListViewItem>();
            foreach (ListViewItem k in lvKeywordsFromDocs.SelectedItems)
            {
                toRemove.Add(k);
                lvKeywords.Items.Add(k.Text);
            }

            foreach (var k in toRemove)
            {
                lvKeywordsFromDocs.Items.Remove(k);
            }
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            var toRemove = new List<ListViewItem>();
            foreach (ListViewItem k in lvKeywords.SelectedItems)
            {
                toRemove.Add(k);
                lvKeywordsFromDocs.Items.Add(k.Text);
            }

            foreach (var k in toRemove)
            {
                lvKeywords.Items.Remove(k);
            }
        }

        private void buttonAddKeyword_Click(object sender, EventArgs e)
        {
            var t = tbNewKeyword.Text;
            if (!string.IsNullOrWhiteSpace(t))
            {
                lvKeywords.Items.Add(t);
            }
        }
    }
}
