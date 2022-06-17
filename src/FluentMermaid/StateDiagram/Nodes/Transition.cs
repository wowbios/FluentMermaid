using System.Text;
using FluentMermaid.StateDiagram.Interfaces;

namespace FluentMermaid.StateDiagram.Nodes;

internal sealed class Transition : ITransition
{
    public Transition(
        IState @from,
        IState to,
        string? description)
    {
        From = @from;
        To = to;
        Description = description;
    }
    
    public IState From { get; }
    
    public IState To { get; }
    
    public string? Description { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append(From.Id)
            .Append(" --> ")
            .Append(To.Id);

        if (!string.IsNullOrWhiteSpace(Description))
            builder
                .Append(" : ")
                .Append(Description);

        builder.AppendLine();
    }
}