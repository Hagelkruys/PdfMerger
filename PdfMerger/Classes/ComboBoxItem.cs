namespace PdfMerger.Classes;

public class ComboBoxItem
{
    public string Text { get; set; } = string.Empty;
    public string? Value { get; set; } = null;


    public ComboBoxItem()
    {

    }

    public ComboBoxItem(string text, string? value)
    {
        Text = text;
        Value = value;
    }

    // Optional: This defines what shows up in the ComboBox list
    public override string ToString()
    {
        return Text;
    }
}
