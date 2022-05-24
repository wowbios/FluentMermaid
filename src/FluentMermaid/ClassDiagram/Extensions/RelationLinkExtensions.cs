using FluentMermaid.ClassDiagram.Enums;

namespace FluentMermaid.ClassDiagram.Extensions;

internal static class RelationLinkExtensions
{
    public static string Render(this RelationLink relationLink)
        => relationLink switch
        {
            RelationLink.Solid => "--",
            RelationLink.Dashed => "..",
            _ => throw new ArgumentOutOfRangeException(nameof(relationLink), relationLink, null)
        };
}