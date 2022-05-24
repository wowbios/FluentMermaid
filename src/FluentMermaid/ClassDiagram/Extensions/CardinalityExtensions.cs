using FluentMermaid.ClassDiagram.Enums;

namespace FluentMermaid.ClassDiagram.Extensions;

public static class CardinalityExtensions
{
    public static string Render(this Cardinality cardinality)
        => cardinality switch
        {
            Cardinality.OnlyOne => "1",
            Cardinality.ZeroOrOne => "0..1",
            Cardinality.OneOrMore => "1..*",
            Cardinality.Many => "*",
            Cardinality.N => "n",
            Cardinality.ZeroToN => "0..n",
            Cardinality.OneToN => "1..n",
            _ => throw new ArgumentOutOfRangeException(nameof(cardinality), cardinality, null)
        };
}