using System.Text;
using FluentMermaid.Flowchart.Enum;
using FluentMermaid.Flowchart.Extensions;
using FluentMermaid.Flowchart.Interfaces;

namespace FluentMermaid.Flowchart.Nodes.Interaction;

internal readonly struct Hyperlink : IRenderTo<StringBuilder>
{
    public readonly string NodeId;
    public readonly Uri Uri;
    public readonly string Tooltip;
    public readonly HyperlinkTarget Target;

    public Hyperlink(string nodeId, Uri uri, string tooltip, HyperlinkTarget target)
    {
        NodeId = nodeId;
        Uri = uri;
        Tooltip = tooltip;
        Target = target;
    }

    public void RenderTo(StringBuilder builder)
    {
        builder.Append("click ")
            .Append(NodeId)
            .Append(" href \"")
            .Append(Uri)
            .Append("\" \"")
            .WriteEscaped(Tooltip)
            .Append("\" ")
            .AppendLine(Target.Render());
    }
}