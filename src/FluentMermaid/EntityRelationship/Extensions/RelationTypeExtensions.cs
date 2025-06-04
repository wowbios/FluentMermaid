using FluentMermaid.EntityRelationship.Enums;

namespace FluentMermaid.EntityRelationship.Extensions;

internal static class RelationTypeExtensions
{
    public static string Render(this RelationType type)
        => type switch
        {
            RelationType.Identifying => "--",
            RelationType.NonIdentifying => "..",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}
