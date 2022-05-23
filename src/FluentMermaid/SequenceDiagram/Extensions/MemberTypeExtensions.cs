using FluentMermaid.SequenceDiagram.Enum;

namespace FluentMermaid.SequenceDiagram.Extensions;

public static class MemberTypeExtensions
{
    public static string Render(this MemberType type)
        => type switch
        {
            MemberType.Actor => "actor",
            MemberType.Participant => "participant",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}