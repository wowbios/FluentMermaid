using System.Text;

namespace FluentMermaid.StateDiagram.Interfaces;

public interface ITransition : IRenderTo<StringBuilder>
{
    IState From { get; }
    
    IState To { get; }
    
    string? Description { get; }
}