namespace Analogy.LogViewer.JsonParser
{
    public enum FileFormat
    {
        Unknown,
        JsonFormatPerLine,
        JsonFormatFile,
    }

    public enum FileFormatDetection
    {
        Automatic,
        Manual,
    }
}