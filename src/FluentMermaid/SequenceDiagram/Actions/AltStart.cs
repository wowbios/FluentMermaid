using System.Text;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct AltStart : IAction
{
    public AltStart(string? title)
    {
        Title = title;
    }

    public string? Title { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("alt ")
            .AppendLine(Title);
    }
}