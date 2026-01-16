namespace PdfMerger.CustomUI;

public partial class PageInfoForm : Form
{
    public PageInfoForm()
    {
        InitializeComponent();
    }

    protected override CreateParams CreateParams
    {
        get
        {
            const int CS_DROPSHADOW = 0x00020000;
            const int WS_THICKFRAME = 0x00040000;
            const int WS_MAXIMIZEBOX = 0x00010000;

            var cp = base.CreateParams;
            cp.ClassStyle |= CS_DROPSHADOW;

            // Remove resize + maximize
            cp.Style &= ~WS_THICKFRAME;
            cp.Style &= ~WS_MAXIMIZEBOX;

            return cp;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        FormBorderStyle = FormBorderStyle.None;
        this.MinimumSize = this.Size;
        this.MaximumSize = this.Size;

        var radius = 8;
        var path = new GraphicsPath();
        path.AddArc(0, 0, radius, radius, 180, 90);
        path.AddArc(Width - radius, 0, radius, radius, 270, 90);
        path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
        path.AddArc(0, Height - radius, radius, radius, 90, 90);
        path.CloseFigure();

        this.Region = new Region(path);
    }

    //private void PageInfoForm_Click(object sender, EventArgs e)
    //{
    //    this.Close();
    //}

    //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    //{
    //    if (keyData == Keys.Escape)
    //    {
    //        Close();
    //        return true;
    //    }
    //    return base.ProcessCmdKey(ref msg, keyData);
    //}

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        int radius = 8;
        int borderThickness = 1;
        Color borderColor = Color.Gray;

        using (GraphicsPath path = new GraphicsPath())
        using (Pen pen = new Pen(borderColor, borderThickness))
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(Width - radius - 1, Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, Height - radius - 1, radius, radius, 90, 90);
            path.CloseFigure();

            e.Graphics.DrawPath(pen, path);
        }
    }
}
