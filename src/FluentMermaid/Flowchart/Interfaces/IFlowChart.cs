using FluentMermaid.Enums;
using FluentMermaid.Flowchart.Interfaces.Styling;

namespace FluentMermaid.Flowchart.Interfaces;

public interface IFlowChart : IGraph
{
    Orientation Orientation { get; }
    
    IInteraction Interaction { get; }
    
    IStyling Styling { get; }

    string Render();
}