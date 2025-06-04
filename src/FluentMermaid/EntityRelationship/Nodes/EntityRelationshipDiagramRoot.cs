using System.Text;
using FluentMermaid.EntityRelationship.Enums;
using FluentMermaid.EntityRelationship.Interfaces;

namespace FluentMermaid.EntityRelationship.Nodes;

internal class EntityRelationshipDiagramRoot : IEntityRelationshipDiagram
{
    private readonly List<IEntity> _entities = new();
    private readonly List<IRelation> _relations = new();

    public IEntity AddEntity(string name)
    {
        var entity = new EntityNode(name);
        _entities.Add(entity);
        return entity;
    }

    public IRelation Relation(IEntity from, IEntity to, Cardinality fromCardinality, Cardinality toCardinality, RelationType relationType, string? label)
    {
        var relation = new RelationNode(from, to, fromCardinality, toCardinality, relationType, label);
        _relations.Add(relation);
        return relation;
    }

    public string Render()
    {
        var builder = new StringBuilder();
        builder.AppendLine("erDiagram");
        foreach (IEntity entity in _entities)
            entity.RenderTo(builder);
        foreach (IRelation relation in _relations)
            relation.RenderTo(builder);
        return builder.ToString();
    }
}
