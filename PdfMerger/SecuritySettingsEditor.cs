using PdfMerger.Classes;

namespace PdfMerger;

public partial class SecuritySettingsEditor : Form
{
    private SecuritySettings m_SecuritySettings;
    public SecuritySettingsEditor(SecuritySettings SecuritySettings)
    {
        Log.Information("start SecuritySettingsEditor");
        InitializeComponent();
        m_SecuritySettings = SecuritySettings;

        cbPermitAnnotations.Checked = m_SecuritySettings.PermitAnnotations;
        cbPermitAssembleDocument.Checked = m_SecuritySettings.PermitAssembleDocument;
        cbPermitExtractContent.Checked = m_SecuritySettings.PermitExtractContent;
        cbPermitFormsFill.Checked = m_SecuritySettings.PermitFormsFill;
        cbPermitFullQualityPrint.Checked = m_SecuritySettings.PermitFullQualityPrint;
        cbPermitModifyDocument.Checked = m_SecuritySettings.PermitModifyDocument;
        cbPermitPrinting.Checked = m_SecuritySettings.PermitPrint;
    }


    private void buttonCancel_Click(object sender, EventArgs e) => this.Close();

    private void buttonSave_Click(object sender, EventArgs e)
    {
        m_SecuritySettings.PermitAnnotations = cbPermitAnnotations.Checked;
        m_SecuritySettings.PermitAssembleDocument = cbPermitAssembleDocument.Checked;
        m_SecuritySettings.PermitExtractContent = cbPermitExtractContent.Checked;
        m_SecuritySettings.PermitFormsFill = cbPermitFormsFill.Checked;
        m_SecuritySettings.PermitFullQualityPrint = cbPermitFullQualityPrint.Checked;
        m_SecuritySettings.PermitModifyDocument = cbPermitModifyDocument.Checked;
        m_SecuritySettings.PermitPrint = cbPermitPrinting.Checked;
        this.Close();
    }
}
