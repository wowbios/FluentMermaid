using System.Text;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct BreakStart : IAction
{
    public BreakStart(string? title)
    {
        Title = title;
    }

    public string? Title { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder.Append("break");
        if (!string.IsNullOrWhiteSpace(Title))
            builder.Append(' ').Append(Title);

        builder.AppendLine();
    }
}
