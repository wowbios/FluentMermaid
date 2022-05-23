using FluentMermaid.Flowchart.Enum;

namespace FluentMermaid.Flowchart.Interfaces;

public interface ISubGraph : INode, IGraph
{
    string Title { get; }
    
    Orientation Orientation { get; }
}