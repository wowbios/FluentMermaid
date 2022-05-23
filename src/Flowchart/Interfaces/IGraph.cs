using FluentMermaid.Flowchart.Enum;

namespace FluentMermaid.Flowchart.Interfaces;

public interface IGraph
{
    INode TextNode(string content, Shape shape);
    
    ISubGraph SubGraph(string title, Orientation orientation);
    
    void Link(
        INode from,
        INode to,
        Link link,
        string text,
        int length = 1);
}