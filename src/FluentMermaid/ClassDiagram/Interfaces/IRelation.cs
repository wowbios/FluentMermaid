using System.Text;
using FluentMermaid.ClassDiagram.Enums;

namespace FluentMermaid.ClassDiagram.Interfaces;

public interface IRelation : IRenderTo<StringBuilder>
{
    IClass From { get; }
    
    IClass To { get; }
    
    Cardinality? FromCardinality { get; }
    
    Relationship? FromRelation { get; }
    
    RelationLink RelationLink { get; }
    
    Relationship? ToRelation { get; }
    
    Cardinality? ToCardinality { get; }
    
    string? Label { get; }
}