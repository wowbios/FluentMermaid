using FluentMermaid.Enums;

namespace FluentMermaid.StateDiagram.Interfaces;

public interface ICompositeState : IStateDiagram, IState
{
    Orientation Orientation { get; }
}