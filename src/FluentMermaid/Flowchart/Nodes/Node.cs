using System.Text;
using FluentMermaid.Flowchart.Enum;
using FluentMermaid.Flowchart.Interfaces;

namespace FluentMermaid.Flowchart.Nodes;

internal abstract record Node : INode
{
    internal Node(IGraph chart, string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Id should be not empty", nameof(id));

        Graph = chart ?? throw new ArgumentNullException(nameof(chart));
        Id = id;
    }
    
    public IGraph Graph { get; }
    
    public string Id { get; }
    
    public INode LinkTo(string text = "", int length = 1, Link linkType = Link.Arrow, params INode[] nodes)
    {
        foreach (INode other in nodes)
            Graph.Link(this, other, linkType, text, length);
        
        return this;
    }

    public INode LinkFrom(string text = "", int length = 1, Link linkType = Link.Arrow, params INode[] nodes)
    {
        foreach (INode other in nodes)
            Graph.Link(other, this, linkType, text, length);
        
        return this;
    }

    public abstract void RenderTo(StringBuilder builder);
}