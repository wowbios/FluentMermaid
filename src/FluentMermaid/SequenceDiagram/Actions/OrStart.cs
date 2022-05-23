using System.Text;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct OrStart : IAction
{
    public OrStart(string? title)
    {
        Title = title;
    }

    public string? Title { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("else ")
            .AppendLine(Title);
    }
}