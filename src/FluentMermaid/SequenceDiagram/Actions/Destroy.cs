using System.Text;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct Destroy : IAction
{
    public Destroy(IMember member)
    {
        Member = member;
    }

    public IMember Member { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("destroy ")
            .AppendLine(Member.Id);
    }
}
