namespace FluentMermaid.Flowchart.Interfaces;

public interface IFlowChartAdvanced : IFlowChart, IAdvancedGraph
{
    IEdgeStyling EdgeStyling { get; }
}
