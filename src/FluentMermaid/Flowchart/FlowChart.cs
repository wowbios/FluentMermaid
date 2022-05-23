using FluentMermaid.Flowchart.Enum;
using FluentMermaid.Flowchart.Interfaces;
using FluentMermaid.Flowchart.Nodes;

namespace FluentMermaid.Flowchart;

public static class FlowChart
{
    public static IFlowChart Create(Orientation orientation) => new FlowchartRootNode(orientation);
}