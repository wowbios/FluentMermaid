using FluentMermaid.EntityRelationship.Enums;

namespace FluentMermaid.EntityRelationship.Extensions;

internal static class CardinalityExtensions
{
    public static string Render(this Cardinality cardinality, bool left)
        => cardinality switch
        {
            Cardinality.ZeroOrOne => left ? "o|" : "|o",
            Cardinality.OnlyOne => "||",
            Cardinality.ZeroOrMany => left ? "}o" : "o{",
            Cardinality.OneOrMany => left ? "}|" : "|{",
            _ => throw new ArgumentOutOfRangeException(nameof(cardinality), cardinality, null)
        };
}
