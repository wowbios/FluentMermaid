using System.Text;
using FluentMermaid.EntityRelationship.Interfaces;

namespace FluentMermaid.EntityRelationship.Nodes;

internal class EntityNode : IEntity
{
    private readonly List<IField> _fields = new();

    public EntityNode(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; }

    public IField AddField(string type, string name, string? modifier)
    {
        var field = new FieldNode(type, name, modifier);
        _fields.Add(field);
        return field;
    }

    public void RenderTo(StringBuilder builder)
    {
        builder.AppendLine($"{Name} {{");
        foreach (IField field in _fields)
            field.RenderTo(builder);
        builder.AppendLine("}");
    }
}
