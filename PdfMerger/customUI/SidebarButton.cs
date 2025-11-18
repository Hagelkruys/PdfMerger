
namespace PdfMerger;

public partial class SidebarButton : UserControl
{

    private bool expanded = true;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string HeaderText
    {
        get => button1.Text;
        set => button1.Text = value;
    }


    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Control? ContentControl { get; set; }


    public SidebarButton()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        expanded = !expanded;
        UpdateState();
    }



    private void UpdateState()
    {
        if (expanded)
        {
            button1.Image = Properties.Resources.arrow_up;
            if (ContentControl is not null)
            {
                ContentControl.Visible = true;
            }
            expanded = true;
        }
        else
        {
            button1.Image = Properties.Resources.arrow_down;
            if (ContentControl is not null)
            {
                ContentControl.Visible = false;
            }
            expanded = false;

        }

        if (Parent is not null)
        {
            Parent.Update();
        }
    }


    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public bool Expanded
    {
        get => expanded;
        set
        {
            expanded = value;
            UpdateState();
        }
    }

}
