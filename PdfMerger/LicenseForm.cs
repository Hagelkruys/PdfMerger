using PdfMerger.Properties;
using Serilog;
using System.Data;

namespace PdfMerger
{
    public partial class LicenseForm : Form
    {
        private static Dictionary<string, string> Licenses = new()
        {
            { "PDF Merger License", Resources.PdfMergerLicense },
            { "PDFium License", Resources.PDFiumLicense },
            { "PDFiumSharp License", Resources.PdfiumSharpLicense },
            { "PDfsharp License", Resources.PdfsharpLicense },
            { "SerialLog License", Resources.SerialLogLicense },
        };



        public LicenseForm()
        {
            Log.Information("start LicenseForm");
            InitializeComponent();

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
}
