using System.Text;
using FluentMermaid.SequenceDiagram.Enum;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct Create : IAction
{
    public Create(IMember member)
    {
        Member = member;
    }

    public IMember Member { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("create ")
            .Append(Member.Type == MemberType.Actor ? "actor" : "participant")
            .Append(' ')
            .AppendLine(Member.Id);
    }
}
