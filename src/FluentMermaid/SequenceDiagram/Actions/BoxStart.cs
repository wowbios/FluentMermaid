using System.Text;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct BoxStart : IAction
{
    public BoxStart(string? color, string? label)
    {
        Color = color;
        Label = label;
    }

    public string? Color { get; }

    public string? Label { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder.Append("box");

        if (!string.IsNullOrWhiteSpace(Color))
            builder.Append(' ').Append(Color);

        if (!string.IsNullOrWhiteSpace(Label))
            builder.Append(' ').Append(Label);

        builder.AppendLine();
    }
}
