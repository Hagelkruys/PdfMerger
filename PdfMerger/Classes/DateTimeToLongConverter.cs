namespace PdfMerger.Classes;

public sealed class DateTimeToLongConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        long seconds = reader.GetInt64();
        return DateTimeOffset.FromUnixTimeSeconds(seconds).UtcDateTime;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        long seconds = new DateTimeOffset(value.ToUniversalTime()).ToUnixTimeSeconds();
        writer.WriteNumberValue(seconds);
    }
}
