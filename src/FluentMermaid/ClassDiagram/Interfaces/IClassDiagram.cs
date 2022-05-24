using FluentMermaid.ClassDiagram.Enums;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

namespace FluentMermaid.ClassDiagram.Interfaces;

public interface IClassDiagram
{
    IClass AddClass(ITypeName typeName);

    IRelation Relation(
        IClass from,
        IClass to,
        Relationship? relationshipFrom,
        Cardinality? cardinalityFrom,
        Relationship? relationshipTo,
        Cardinality? cardinalityTo,
        Link link,
        string? label);

    string Render();
}