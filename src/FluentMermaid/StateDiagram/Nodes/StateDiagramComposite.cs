using System.Text;
using FluentMermaid.Enums;
using FluentMermaid.Extensions;
using FluentMermaid.StateDiagram.Interfaces;

namespace FluentMermaid.StateDiagram.Nodes;

internal sealed class StateDiagramComposite : StateDiagram, ICompositeState
{
    public StateDiagramComposite(string id, string description, Orientation orientation)
        : base(orientation)
    {
        Id = id;
        Description = description;
    }

    public string Id { get; }

    public string Description { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("state ")
            .Append(Description)
            .AppendLine(" {")
            .Append("direction ")
            .AppendLine(Orientation.Render());
        
        RenderNodes(builder);

        builder.AppendLine("}");
    }

    protected override string GenerateStateId()
        => Id + "_" + base.GenerateStateId();

    public override string Render()
    {
        var builder = new StringBuilder();
        RenderTo(builder);
        return builder.ToString();
    }
}