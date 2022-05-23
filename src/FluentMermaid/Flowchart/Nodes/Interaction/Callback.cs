using System.Text;
using FluentMermaid.Extensions;

namespace FluentMermaid.Flowchart.Nodes.Interaction;

internal readonly struct Callback : IRenderTo<StringBuilder>
{
    public readonly string NodeId;
    public readonly string FunctionName;
    public readonly string Tooltip;

    public Callback(string nodeId, string functionName, string tooltip)
    {
        if (string.IsNullOrWhiteSpace(functionName))
            throw new ArgumentException("Function name should not be null or empty", nameof(functionName));

        NodeId = nodeId;
        FunctionName = functionName;
        Tooltip = tooltip;
    }

    public void RenderTo(StringBuilder builder)
    {
        builder.Append("click ")
            .Append(NodeId)
            .Append(' ')
            .Append(FunctionName)
            .Append(" \"")
            .WriteEscaped(Tooltip)
            .Append('\"')
            .AppendLine();
    }
}