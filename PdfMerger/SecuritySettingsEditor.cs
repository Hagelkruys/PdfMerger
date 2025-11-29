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


        //i18n
        this.Text = Properties.Strings.TitleSecuritySettingsEditor;
        buttonCancel.Text = Properties.Strings.ButtonCancel;
        buttonSave.Text = Properties.Strings.ButtonSaveAndClose;

        cbPermitPrinting.Text = Properties.Strings.CBPermitPrinting;
        labelPermitPrinting.Text = Properties.Strings.LabelPermitPrinting;

        cbPermitFullQualityPrint.Text = Properties.Strings.CBPermitFullQualityPrint;
        labelPermitFullQualityPrint.Text = Properties.Strings.LabelPermitFullQualityPrint;

        cbPermitModifyDocument.Text = Properties.Strings.CBPermitModifyDocument;
        labelPermitModifyDocument.Text = Properties.Strings.LabelPermitModifyDocument;

        cbPermitExtractContent.Text = Properties.Strings.CBPermitExtractContent;
        labelPermitExtractContent.Text = Properties.Strings.LabelPermitExtractContent;

        cbPermitAnnotations.Text = Properties.Strings.CBPermitAnnotations;
        labelPermitAnnotations.Text = Properties.Strings.LabelPermitAnnotations;


        cbPermitFormsFill.Text = Properties.Strings.CBPermitFormsFill;
        labelPermitFormsFill.Text = Properties.Strings.LabelPermitFormsFill;


        cbPermitAssembleDocument.Text = Properties.Strings.CBPermitAssembleDocument;
        labelPermitAssembleDocument.Text = Properties.Strings.LabelPermitAssembleDocument;

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
