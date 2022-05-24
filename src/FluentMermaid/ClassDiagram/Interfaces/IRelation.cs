using System.Text;
using FluentMermaid.ClassDiagram.Enums;

namespace FluentMermaid.ClassDiagram.Interfaces;

public interface IRelation : IRenderTo<StringBuilder>
{
    IClass From { get; }
    
    IClass To { get; }
    
    Relationship? FromRelation { get; }
    
    Link Link { get; }
    
    Relationship? ToRelation { get; }
    
    string? Label { get; }
}