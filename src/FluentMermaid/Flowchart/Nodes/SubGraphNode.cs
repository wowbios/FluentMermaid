using System.Text;
using FluentMermaid.Extensions;
using FluentMermaid.Flowchart.Enum;
using FluentMermaid.Flowchart.Extensions;
using FluentMermaid.Flowchart.Interfaces;

namespace FluentMermaid.Flowchart.Nodes;

internal record SubGraphNode : ISubGraph
{
    public SubGraphNode(
        string id,
        string title,
        Orientation orientation)
    {
        Id = id;
        Title = title;
        Orientation = orientation;
    }

    public string Id { get; }
    
    public string Title { get; }
    
    public Orientation Orientation { get; }

    private HashSet<INode> Nodes { get; } = new();

    private HashSet<Relation> Relations { get; } = new();
    
    public INode TextNode(string content, Shape shape)
    {
        TextNode textNode = new(this, CreateNodeId(), content, shape);
        Nodes.Add(textNode);
        return textNode;
    }

    public ISubGraph SubGraph(string title, Orientation orientation)
    {
        var subgraph = new SubGraphNode(CreateNodeId(), title, orientation);
        Nodes.Add(subgraph);
        return subgraph;
    }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("subgraph ")
            .Append(Id)
            .Append(' ')
            .Append("[\"")
            .WriteEscaped(Title)
            .AppendLine("\"]");

        builder
            .Append("direction ")
            .AppendLine(Orientation.Render());

        foreach (INode node in Nodes)
            node.RenderTo(builder);

        foreach (Relation relation in Relations)
            relation.RenderTo(builder);

        builder.AppendLine("end");
    }

    private string CreateNodeId() => Id + "Sub" + Nodes.Count;
    
    public void Link(INode @from, INode to, Link link, string text, int length = 1)
    {
        if (length < 1)
            throw new ArgumentException("Link length should be more or equal 1", nameof(length));

        Relation relation = new(from, to, link, text, length);
        Relations.Add(relation);
    }
}