using System.Text;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct OptionStart : IAction
{
    public OptionStart(string? title)
    {
        Title = title;
    }

    public string? Title { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder.Append("option");
        if (!string.IsNullOrWhiteSpace(Title))
            builder.Append(' ').Append(Title);

        builder.AppendLine();
    }
}
