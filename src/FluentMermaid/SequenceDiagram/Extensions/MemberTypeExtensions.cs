using FluentMermaid.SequenceDiagram.Enum;

namespace FluentMermaid.SequenceDiagram.Extensions;

public static class MemberTypeExtensions
{
    public static string Render(this MemberType type)
        => type switch
        {
            MemberType.Actor => "actor",
            MemberType.Participant => "participant",
            MemberType.Boundary => "boundary",
            MemberType.Control => "control",
            MemberType.Entity => "entity",
            MemberType.Database => "database",
            MemberType.Collections => "collections",
            MemberType.Queue => "queue",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}