using System.Text;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct CriticalStart : IAction
{
    public CriticalStart(string? title)
    {
        Title = title;
    }

    public string? Title { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder.Append("critical");
        if (!string.IsNullOrWhiteSpace(Title))
            builder.Append(' ').Append(Title);

        builder.AppendLine();
    }
}
