using System.Text;
using FluentMermaid.ClassDiagram.Enums;
using FluentMermaid.ClassDiagram.Interfaces;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;
using FluentMermaid.ClassDiagram.Nodes;
using FluentMermaid.Enums;
using FluentMermaid.Extensions;

namespace FluentMermaid.ClassDiagram;

internal class ClassDiagramRoot : IClassDiagram
{
    private readonly List<IClass> _classes = new();
    private readonly List<IRelation> _relations = new();
    
    public ClassDiagramRoot(Orientation orientation)
    {
        Orientation = orientation;
    }

    public Orientation Orientation { get; }

    public IClass AddClass(ITypeName typeName, string? annotation)
    {
        _ = typeName ?? throw new ArgumentNullException(nameof(typeName));
        
        var @class = new ClassNode(typeName, annotation);
        _classes.Add(@class);
        return @class;
    }

    public IRelation Relation(
        IClass from,
        IClass to,
        Relationship? relationshipFrom,
        Cardinality? cardinalityFrom,
        Relationship? relationshipTo,
        Cardinality? cardinalityTo,
        Link link,
        string? label)
    {
        var relation = new RelationNode(
            from,
            to,
            relationshipFrom,
            cardinalityFrom,
            link,
            cardinalityTo,
            relationshipTo,
            label);
        _relations.Add(relation);
        return relation;
    }

    public string Render()
    {
        StringBuilder builder = new();
        builder.AppendLine("classDiagram");
        builder.Append("direction ").AppendLine(Orientation.Render());
        
        _relations.ForEach(r => r.RenderTo(builder));
        _classes.ForEach(c => c.RenderTo(builder));

        return builder.ToString();
    }
}