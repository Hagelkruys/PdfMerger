using PdfMerger.Config;
using PdfMerger.SettingsPanels;

namespace PdfMerger;

public partial class SettingsForm : Form
{

    private static Dictionary<string, SettingsUserControl> Settings = new()
    {
        { Properties.Strings.General, new SettingsPanels.General() },
        { Properties.Strings.RenderSettings, new SettingsPanels.RenderSettings() },
        { Properties.Strings.ImageSettings, new SettingsPanels.ImageSettings() },
    };



    public SettingsForm()
    {
        Log.Information("start SettingsForm");
        InitializeComponent();
        listCategories.Items.AddRange(Settings.Select(r => r.Key).ToArray());
        listCategories.SelectedIndexChanged += ListCategories_SelectedIndexChanged;
        listCategories.SelectedIndex = 0;
        listCategories.MeasureItem += listCategories_MeasureItem;
        listCategories.DrawItem += listCategories_DrawItem;


        foreach (var value in Settings.Select(r => r.Value))
        {
            panelContent.Controls.Add(value);
            value.Visible = false;
        }

        ShowPanel(Settings.First().Value);

        this.Text = Properties.Strings.FileMenuSettings;
        buttonCancel.Text = Properties.Strings.ButtonCancel;
        buttonSave.Text = Properties.Strings.ButtonSave;
        buttonSaveAndClose.Text = Properties.Strings.ButtonSaveAndClose;
    }

    private void listCategories_DrawItem(object? sender, DrawItemEventArgs e)
    {
        if(sender is null)
        {
            return;
        }

        if (e.Index < 0)
        {
            return;
        }

        if(e.Font is null)
        {
            return;
        }

        // Draw background
        e.DrawBackground();


        // Draw text
        string text = ((ListBox)sender).Items[e.Index]?.ToString() ?? "";
        using (Brush textBrush = new SolidBrush(e.ForeColor))
        {
            e.Graphics.DrawString(text, e.Font, textBrush, e.Bounds.Left + 10, e.Bounds.Top + 8);
        }

        // Draw focus rectangle
        e.DrawFocusRectangle();
    }

    private void listCategories_MeasureItem(object? sender, MeasureItemEventArgs e)
    {
        e.ItemHeight = 40;
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
        if (close)
        {
            this.Close();
        }
    }

    private void buttonCancel_Click(object sender, EventArgs e) => this.Close();
    private void buttonSaveAndClose_Click(object sender, EventArgs e) => SaveConfig(close: true);
}
