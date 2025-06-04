using System.Text;
using FluentMermaid.EntityRelationship.Enums;

namespace FluentMermaid.EntityRelationship.Interfaces;

public interface IRelation : IRenderTo<StringBuilder>
{
    IEntity From { get; }
    IEntity To { get; }
    Cardinality FromCardinality { get; }
    Cardinality ToCardinality { get; }
    RelationType RelationType { get; }
    string? Label { get; }
}
