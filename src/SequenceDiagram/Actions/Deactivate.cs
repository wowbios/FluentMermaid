using System.Text;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct Deactivate : IAction
{
    public Deactivate(IMember member)
    {
        Member = member;
    }

    public IMember Member { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("deactivate ")
            .AppendLine(Member.Id);
    }
}