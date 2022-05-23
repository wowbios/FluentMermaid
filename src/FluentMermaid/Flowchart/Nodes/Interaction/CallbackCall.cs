using System.Text;
using FluentMermaid.Extensions;

namespace FluentMermaid.Flowchart.Nodes.Interaction;

internal readonly struct CallbackCall : IRenderTo<StringBuilder>
{
    public readonly string NodeId;
    public readonly string FunctionCall;
    public readonly string Tooltip;

    public CallbackCall(string nodeId, string functionCall, string tooltip)
    {
        if (string.IsNullOrWhiteSpace(functionCall))
            throw new ArgumentException("Function call should not be null or empty", nameof(functionCall));

        NodeId = nodeId;
        FunctionCall = functionCall;
        Tooltip = tooltip;
    }

    public void RenderTo(StringBuilder builder)
    {
        builder.Append("click ")
            .Append(NodeId)
            .Append(' ')
            .Append("call ")
            .Append(FunctionCall)
            .Append(" \"")
            .WriteEscaped(Tooltip)
            .Append('\"')
            .AppendLine();
    }
}