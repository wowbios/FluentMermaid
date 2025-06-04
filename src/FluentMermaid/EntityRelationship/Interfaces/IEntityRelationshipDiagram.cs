using FluentMermaid.EntityRelationship.Enums;

namespace FluentMermaid.EntityRelationship.Interfaces;

public interface IEntityRelationshipDiagram
{
    IEntity AddEntity(string name);
    IRelation Relation(IEntity from, IEntity to, Cardinality fromCardinality, Cardinality toCardinality, RelationType relationType, string? label);
    string Render();
}
