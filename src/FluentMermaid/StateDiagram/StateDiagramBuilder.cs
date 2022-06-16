using FluentMermaid.Enums;
using FluentMermaid.StateDiagram.Interfaces;
using FluentMermaid.StateDiagram.Nodes;

namespace FluentMermaid.StateDiagram;

public static class StateDiagramBuilder
{
    public static IStateDiagram Create(Orientation orientation) => new StateDiagramRoot(orientation);
}