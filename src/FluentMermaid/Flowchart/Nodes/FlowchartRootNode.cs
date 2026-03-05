using System.Text;
using FluentMermaid.Enums;
using FluentMermaid.Extensions;
using FluentMermaid.Flowchart.Enum;
using FluentMermaid.Flowchart.Interfaces;
using FluentMermaid.Flowchart.Interfaces.Styling;
using FluentMermaid.Flowchart.Nodes.Interaction;

namespace FluentMermaid.Flowchart.Nodes;

internal class FlowchartRootNode : IFlowChartAdvanced
{
    internal FlowchartRootNode(Orientation orientation)
    {
        Orientation = orientation;
    }
    
    public Orientation Orientation { get; }

    public IInteraction Interaction { get; } = new InteractionNode("interactions");

    public IStyling Styling { get; } = new Styling.Styling("styling");

    public IEdgeStyling EdgeStyling { get; } = new EdgeStylingNode();

    private List<INode> Nodes { get; } = new();

    private List<Relation> Relations { get; } = new();

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

    public IAdvancedSubGraph AdvancedSubGraph(string title, Orientation orientation)
    {
        var subgraph = new SubGraphNode(CreateNodeId(), title, orientation);
        Nodes.Add(subgraph);
        return subgraph;
    }

    public IAdvancedSubGraph AdvancedSubGraph(string id, string title, Orientation orientation)
    {
        var subgraph = new SubGraphNode(id, title, orientation);
        Nodes.Add(subgraph);
        return subgraph;
    }

    public void Link(
        INode from,
        INode to,
        Link link,
        string text,
        int length = 1)
        => AddRelation(from, to, link, text, length);

    public void Link(
        INode from,
        INode to,
        string edgeId,
        Link link,
        string text,
        int length = 1)
        => AddRelation(from, to, link, text, length, edgeId);

    public INode TextNode(string content, string shapeAlias)
    {
        if (string.IsNullOrWhiteSpace(shapeAlias))
            throw new ArgumentException("Shape alias should not be null or empty", nameof(shapeAlias));

        AdvancedTextNode textNode = new(
            this,
            CreateNodeId(),
            new AdvancedTextNode.NodeAttribute("shape", shapeAlias),
            new AdvancedTextNode.NodeAttribute("label", content, true));

        Nodes.Add(textNode);
        return textNode;
    }

    public INode IconNode(string icon, string? label = null, string? form = null, string? position = null, int? height = null)
    {
        if (string.IsNullOrWhiteSpace(icon))
            throw new ArgumentException("Icon should not be null or empty", nameof(icon));

        var attrs = new List<AdvancedTextNode.NodeAttribute>
        {
            new("icon", icon, true)
        };
        if (!string.IsNullOrWhiteSpace(form))
            attrs.Add(new("form", form!, true));
        if (!string.IsNullOrWhiteSpace(label))
            attrs.Add(new("label", label!, true));
        if (!string.IsNullOrWhiteSpace(position))
            attrs.Add(new("pos", position!, true));
        if (height.HasValue)
            attrs.Add(AdvancedTextNode.NodeAttribute.FromInt("h", height.Value));

        AdvancedTextNode node = new(this, CreateNodeId(), attrs.ToArray());
        Nodes.Add(node);
        return node;
    }

    public INode ImageNode(
        Uri imageUrl,
        string? label = null,
        string? position = null,
        int? width = null,
        int? height = null,
        bool? constraint = null)
    {
        if (imageUrl is null)
            throw new ArgumentNullException(nameof(imageUrl));

        var attrs = new List<AdvancedTextNode.NodeAttribute>
        {
            new("img", imageUrl.ToString(), true)
        };
        if (!string.IsNullOrWhiteSpace(label))
            attrs.Add(new("label", label!, true));
        if (!string.IsNullOrWhiteSpace(position))
            attrs.Add(new("pos", position!, true));
        if (width.HasValue)
            attrs.Add(AdvancedTextNode.NodeAttribute.FromInt("w", width.Value));
        if (height.HasValue)
            attrs.Add(AdvancedTextNode.NodeAttribute.FromInt("h", height.Value));
        if (constraint.HasValue)
            attrs.Add(new("constraint", constraint.Value ? "on" : "off", true));

        AdvancedTextNode node = new(this, CreateNodeId(), attrs.ToArray());
        Nodes.Add(node);
        return node;
    }

    public string Render()
    {
        StringBuilder builder = new();
        builder.Append("flowchart ");
        builder.AppendLine(Orientation.Render());

        foreach (INode node in Nodes)
            node.RenderTo(builder);

        foreach (Relation relation in Relations)
            relation.RenderTo(builder);
        
        Interaction.RenderTo(builder);
        Styling.RenderTo(builder);
        EdgeStyling.RenderTo(builder);

        return builder.ToString();
    }

    private string CreateNodeId() => "id" + Nodes.Count;

    private void AddRelation(
        INode from,
        INode to,
        Link link,
        string text,
        int length,
        string? edgeId = null)
    {
        if (length < 1)
            throw new ArgumentException("Link length should be more or equal 1", nameof(length));
        if (edgeId is not null && string.IsNullOrWhiteSpace(edgeId))
            throw new ArgumentException("Edge id should not be empty", nameof(edgeId));

        Relation relation = new(from, to, link, text, length, edgeId);
        Relations.Add(relation);
    }
}
