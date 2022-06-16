using System.Text;
using FluentMermaid.StateDiagram.Interfaces;

namespace FluentMermaid.StateDiagram.Nodes;

internal sealed class State : IState
{
    public State(string id, string description)
    {
        Id = id;
        Description = description;
    }

    public string Id { get; }
    
    public string Description { get; }
    
    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append(Id)
            .Append(" : ")
            .AppendLine(Description);
    }
}