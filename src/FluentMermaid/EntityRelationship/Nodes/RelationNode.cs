using System.Text;
using FluentMermaid.EntityRelationship.Enums;
using FluentMermaid.EntityRelationship.Extensions;
using FluentMermaid.EntityRelationship.Interfaces;

namespace FluentMermaid.EntityRelationship.Nodes;

internal class RelationNode : IRelation
{
    public RelationNode(IEntity from, IEntity to, Cardinality fromCardinality, Cardinality toCardinality, RelationType relationType, string? label)
    {
        From = from;
        To = to;
        FromCardinality = fromCardinality;
        ToCardinality = toCardinality;
        RelationType = relationType;
        Label = label;
    }

    public IEntity From { get; }
    public IEntity To { get; }
    public Cardinality FromCardinality { get; }
    public Cardinality ToCardinality { get; }
    public RelationType RelationType { get; }
    public string? Label { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append(From.Name)
            .Append(' ')
            .Append(FromCardinality.Render(true))
            .Append(RelationType.Render())
            .Append(ToCardinality.Render(false))
            .Append(' ')
            .Append(To.Name);
        if (!string.IsNullOrWhiteSpace(Label))
            builder.Append(" : ").Append(Label);
        builder.AppendLine();
    }
}
