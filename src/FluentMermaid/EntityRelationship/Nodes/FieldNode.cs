using System.Text;
using FluentMermaid.EntityRelationship.Interfaces;

namespace FluentMermaid.EntityRelationship.Nodes;

internal record FieldNode(string Type, string Name, string? Modifier) : IField
{
    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append(' ') // indentation
            .Append(Type)
            .Append(' ')
            .Append(Name);
        if (!string.IsNullOrWhiteSpace(Modifier))
            builder.Append(' ').Append(Modifier);
        builder.AppendLine();
    }
}
