using FluentMermaid.ClassDiagram.Enums;

namespace FluentMermaid.ClassDiagram.Extensions;

internal static class LinkExtensions
{
    public static string Render(this Link link)
        => link switch
        {
            Link.Solid => "--",
            Link.Dashed => "..",
            _ => throw new ArgumentOutOfRangeException(nameof(link), link, null)
        };
}