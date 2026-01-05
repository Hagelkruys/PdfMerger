namespace PdfMerger.Classes;

public sealed class ComboBoxItem
{
    public string Text { get; set; } = string.Empty;
    public string? Value { get; set; } = null;
    public int IntValue { get; set; }


    public ComboBoxItem()
    {

    }

    public ComboBoxItem(string text, string? value)
    {
        Text = text;
        Value = value;
    }

    public ComboBoxItem(string text, int value)
    {
        Text = text;
        IntValue = value;
    }

    // Optional: This defines what shows up in the ComboBox list
    public override string ToString()
    {
        return Text;
    }
}
