using FluentMermaid.EntityRelationship.Interfaces;
using FluentMermaid.EntityRelationship.Nodes;

namespace FluentMermaid.EntityRelationship;

public static class EntityRelationshipDiagram
{
    public static IEntityRelationshipDiagram Create() => new EntityRelationshipDiagramRoot();
}
