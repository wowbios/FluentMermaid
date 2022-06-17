using System.Text;
using FluentMermaid.Enums;
using FluentMermaid.Extensions;

namespace FluentMermaid.StateDiagram.Nodes;

internal sealed class StateDiagramRoot : StateDiagram
{
    public StateDiagramRoot(Orientation orientation) : base(orientation)
    {
    }

    public override string Render()
    {
        var builder = new StringBuilder();
        builder
            .AppendLine("stateDiagram-v2")
            .Append("direction ")
            .AppendLine(Orientation.Render());

        base.RenderNodes(builder);

        return builder.ToString();
    }
}