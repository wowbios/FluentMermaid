using System.Text;

namespace FluentMermaid.ClassDiagram.Extensions;

internal static class StringExtensions
{
    public static string ToValidClassName(this string self)
    {
        // maybe use span
        return new StringBuilder().AppendValidName(self).ToString();
    }
}