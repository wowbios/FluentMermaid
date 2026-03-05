using System.Globalization;
using System.Text;
using FluentMermaid.Extensions;
using FluentMermaid.Flowchart.Interfaces;

namespace FluentMermaid.Flowchart.Nodes;

internal sealed record AdvancedTextNode : Node
{
    private readonly List<NodeAttribute> _attributes = new();

    public AdvancedTextNode(
        IGraph graph,
        string id,
        params NodeAttribute[] attributes)
        : base(graph, id)
    {
        _attributes.AddRange(attributes);
    }

    public override void RenderTo(StringBuilder builder)
    {
        builder.Append(Id).Append("@{ ");

        var hasWrittenAttribute = false;
        foreach (NodeAttribute attribute in _attributes)
        {
            if (hasWrittenAttribute)
                builder.Append(", ");

            builder.Append(attribute.Key).Append(": ");
            if (attribute.QuoteValue)
            {
                builder.Append('"');
                builder.WriteEscaped(attribute.Value);
                builder.Append('"');
            }
            else
            {
                builder.Append(attribute.Value);
            }

            hasWrittenAttribute = true;
        }

        builder.AppendLine(" }");
    }

    internal readonly struct NodeAttribute
    {
        public NodeAttribute(string key, string value, bool quoteValue = false)
        {
            Key = key;
            Value = value;
            QuoteValue = quoteValue;
        }

        public string Key { get; }

        public string Value { get; }

        public bool QuoteValue { get; }

        public static NodeAttribute FromBool(string key, bool value)
            => new(key, value ? "true" : "false");

        public static NodeAttribute FromInt(string key, int value)
            => new(key, value.ToString(CultureInfo.InvariantCulture));
    }
}
