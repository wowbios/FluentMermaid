namespace FluentMermaid.StateDiagram.Extensions;

internal static class StringExtensions
{
    public static string ToValidId(this string self)
        => new string(self.Select(ch => char.IsLetterOrDigit(ch) ? ch : '_').ToArray());
}