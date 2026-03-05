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
            MessageType.SolidBidirectionalArrow => "<<->>",
            MessageType.DottedBidirectionalArrow => "<<-->>",
            MessageType.SolidTopHalfArrow => "-|\\",
            MessageType.DottedTopHalfArrow => "--|\\",
            MessageType.SolidBottomHalfArrow => "-|/",
            MessageType.DottedBottomHalfArrow => "--|/",
            MessageType.SolidReverseTopHalfArrow => "/|-",
            MessageType.DottedReverseTopHalfArrow => "/|--",
            MessageType.SolidReverseBottomHalfArrow => "\\|-",
            MessageType.DottedReverseBottomHalfArrow => "\\|--",
            MessageType.SolidTopStickHalfArrow => "-\\\\",
            MessageType.DottedTopStickHalfArrow => "--\\\\",
            MessageType.SolidBottomStickHalfArrow => "-//",
            MessageType.DottedBottomStickHalfArrow => "--//",
            MessageType.SolidReverseTopStickHalfArrow => "//-",
            MessageType.DottedReverseTopStickHalfArrow => "//--",
            MessageType.SolidReverseBottomStickHalfArrow => "\\\\-",
            MessageType.DottedReverseBottomStickHalfArrow => "\\\\--",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}