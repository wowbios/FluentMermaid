using FluentMermaid.SequenceDiagram.Enum;

namespace FluentMermaid.SequenceDiagram.Extensions;

public static class MessageTypeExtensions
{
    public static string Render(this MessageType type)
        => type switch
        {
            MessageType.Solid => "->",
            MessageType.Dotted => "-->",
            MessageType.SolidArrow => "->>",
            MessageType.DottedArrow => "-->>",
            MessageType.SolidCross => "-x",
            MessageType.DottedCross => "--x",
            MessageType.SolidOpenArrow => "-)",
            MessageType.DottedOpenArrow => "--)",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}