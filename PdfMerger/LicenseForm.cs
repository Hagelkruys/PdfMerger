using PdfMerger.Properties;

namespace PdfMerger;

public partial class LicenseForm : Form
{
    private static Dictionary<string, string> Licenses = new()
    {
        { Properties.Strings.PDFMergerLicense, Resources.PdfMergerLicense },
        { Properties.Strings.PDFiumLicense, Resources.PDFiumLicense },
        { Properties.Strings.PDFiumSharpLicense, Resources.PdfiumSharpLicense },
        { Properties.Strings.PDfsharpLicense, Resources.PdfsharpLicense },
        { Properties.Strings.SerialLogLicense, Resources.SerialLogLicense },
    };



    public LicenseForm()
    {
        Log.Information("start LicenseForm");
        InitializeComponent();

        this.Text = Properties.Strings.License;
        buttonClose.Text = Properties.Strings.ButtonClose;

        listOfLicenses.Items.AddRange(Licenses.Select(r => r.Key).ToArray());
        listOfLicenses.SelectedIndexChanged += ListCategories_SelectedIndexChanged;
        listOfLicenses.SelectedIndex = 0;


        ShowLicense(Licenses.First().Value);
    }


    private void ListCategories_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var key = listOfLicenses.SelectedItem?.ToString() ?? "";

        if (!Licenses.ContainsKey(key))
        {
            ShowLicense(Licenses.First().Value);
        }
        else
        {
            ShowLicense(Licenses[key]);
        }
    }


    private void ShowLicense(string p)
    {
        tbLicense.Text = p;
    }

    private void buttonCancel_Click(object sender, EventArgs e) => this.Close();
}
