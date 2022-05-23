using System.Text;
using FluentMermaid.Flowchart.Enum;
using FluentMermaid.Flowchart.Extensions;
using FluentMermaid.Flowchart.Interfaces;

namespace FluentMermaid.Flowchart.Nodes;

internal sealed record TextNode : Node
{
    public TextNode(
        IGraph graph,
        string id,
        string text,
        Shape shape) 
        : base(graph, id)
    {
        Text = text;
        Shape = shape;
    }

    public string Text { get; }

    public Shape Shape { get; }

    public override void RenderTo(StringBuilder target)
        => target
            .Append(Id)
            .Append(Shape.RenderStart())
            .Append('"')
            .WriteEscaped(Text)
            .Append('"')
            .AppendLine(Shape.RenderEnd());
}