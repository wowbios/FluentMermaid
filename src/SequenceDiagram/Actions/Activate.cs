using System.Text;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct Activate : IAction
{
    public Activate(IMember member)
    {
        Member = member;
    }

    public IMember Member { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("activate ")
            .AppendLine(Member.Id);
    }
}