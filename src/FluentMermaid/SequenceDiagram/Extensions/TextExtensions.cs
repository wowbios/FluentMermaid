namespace FluentMermaid.SequenceDiagram.Extensions;

internal static class TextExtensions
{
    public static string RenderText(this string text)
        => text
            .Replace("\r\n", "<br/>")
            .Replace("\n", "<br/>");
}
