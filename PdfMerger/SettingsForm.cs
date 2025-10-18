using PdfMerger.Config;
using PdfMerger.SettingsPanels;
using System.Data;

namespace PdfMerger
{
    public partial class SettingsForm : Form
    {

        private static Dictionary<string, SettingsUserControl> Settings = new()
        {
            { "General", new SettingsPanels.General() },
        };



        public SettingsForm()
        {
            InitializeComponent();
            listCategories.Items.AddRange(Settings.Select(r => r.Key).ToArray());
            listCategories.SelectedIndexChanged += ListCategories_SelectedIndexChanged;
            listCategories.SelectedIndex = 0;

            foreach (var value in Settings.Select(r => r.Value))
            {
                panelContent.Controls.Add(value);
                value.Visible = false;
            }

            ShowPanel(Settings.First().Value);
        }

        private void ShowPanel(UserControl p)
        {
            foreach (var value in Settings.Select(r => r.Value))
            {
                value.Visible = false;
            }

            p.Visible = true;
            p.BringToFront();
        }

        private void ListCategories_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var key = listCategories.SelectedItem?.ToString() ?? "";

            if (!Settings.ContainsKey(key))
            {
                ShowPanel(Settings.First().Value);
            }
            else
            {
                ShowPanel(Settings[key]);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e) => SaveConfig(close: false);

        private void SaveConfig(bool close)
        {
            foreach (var value in Settings.Select(r => r.Value))
            {
                value.Save();
            }

            ConfigManager.Save();
            if(close)
            {
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e) => this.Close();
        private void buttonSaveAndClose_Click(object sender, EventArgs e) => SaveConfig(close: true);
    }
}
