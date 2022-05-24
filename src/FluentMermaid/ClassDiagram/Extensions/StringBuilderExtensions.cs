using System.Text;

namespace FluentMermaid.ClassDiagram.Extensions;

internal static class StringBuilderExtensions
{
    public static StringBuilder AppendValidName(this StringBuilder builder, string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return builder;

        foreach (char ch in name!)
        {
            builder.Append(CorrectSymbol(ch) ? ch : '_');
        }

        return builder;

        static bool CorrectSymbol(char ch)
            => char.IsLetterOrDigit(ch)
               || ch is '[' or ']';
    }
}