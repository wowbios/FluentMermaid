using FluentMermaid.ClassDiagram.Enums;

namespace FluentMermaid.ClassDiagram.Extensions;

internal static class RelationshipExtensions
{
    public static string Render(this Relationship relationship, bool from)
        => relationship switch
        {
            Relationship.Inheritance => from ? "<|" : "|>",
            Relationship.Composition => "*",
            Relationship.Aggregation => "o",
            Relationship.Association => from ? "<" : ">",
            _ => throw new ArgumentOutOfRangeException(nameof(relationship), relationship, null)
        };
}