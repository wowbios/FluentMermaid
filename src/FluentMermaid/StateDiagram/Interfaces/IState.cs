namespace FluentMermaid.StateDiagram.Interfaces;

public interface IState : INode
{
    string Description { get; }
}