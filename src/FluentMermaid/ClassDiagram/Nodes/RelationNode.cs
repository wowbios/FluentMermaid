using System.Text;
using FluentMermaid.ClassDiagram.Enums;
using FluentMermaid.ClassDiagram.Extensions;
using FluentMermaid.ClassDiagram.Interfaces;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class RelationNode : IRelation
{
    public RelationNode(
        IClass @from,
        IClass to,
        Relationship? fromRelation,
        Cardinality? fromCardinality,
        Link link,
        Cardinality? toCardinality,
        Relationship? toRelation,
        string? label)
    {
        From = @from;
        To = to;
        FromRelation = fromRelation;
        FromCardinality = fromCardinality;
        Link = link;
        ToCardinality = toCardinality;
        ToRelation = toRelation;
        Label = label;
    }

    public IClass From { get; }
    
    public IClass To { get; }
    
    public Cardinality? FromCardinality { get; }

    public Relationship? FromRelation { get; }
    
    public Link Link { get; }
    
    public Relationship? ToRelation { get; }
    
    public Cardinality? ToCardinality { get; }

    public string? Label { get; }

    public void RenderTo(StringBuilder builder)
    {
        From.Name.RenderTo(builder);
        builder.Append(' ');

        if (FromCardinality is not null)
        {
            builder
                .Append('"')
                .Append(FromCardinality.Value.Render())
                .Append('"');
        }
        
        builder
            .Append(' ')
            .Append(FromRelation?.Render(true))
            .Append(Link.Render())
            .Append(ToRelation?.Render(false))
            .Append(' ');
        
        if (ToCardinality is not null)
        {
            builder
                .Append('"')
                .Append(ToCardinality.Value.Render())
                .Append('"');
        }

        To.Name.RenderTo(builder);

        if (!string.IsNullOrWhiteSpace(Label))
            builder
                .Append(" : ")
                .Append(Label);
        
        builder.AppendLine();
    }
}