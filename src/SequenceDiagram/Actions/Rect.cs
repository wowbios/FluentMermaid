using System.Drawing;
using System.Text;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct Rect : IAction
{
    public Rect(Color color)
    {
        Color = color;
    }

    public Color Color { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("rect rgb(")
            .Append(Color.R)
            .Append(", ")
            .Append(Color.G)
            .Append(", ")
            .Append(Color.B)
            .AppendLine(")");
    }
}