using FluentMermaid.Enums;
using FluentMermaid.Flowchart.Enum;

namespace FluentMermaid.Flowchart.Interfaces;

public interface IAdvancedGraph : IGraph
{
    INode TextNode(string content, string shapeAlias);

    INode IconNode(
        string icon,
        string? label = null,
        string? form = null,
        string? position = null,
        int? height = null);

    INode ImageNode(
        Uri imageUrl,
        string? label = null,
        string? position = null,
        int? width = null,
        int? height = null,
        bool? constraint = null);

    IAdvancedSubGraph AdvancedSubGraph(string title, Orientation orientation);

    IAdvancedSubGraph AdvancedSubGraph(string id, string title, Orientation orientation);

    void Link(
        INode from,
        INode to,
        string edgeId,
        Link link,
        string text,
        int length = 1);
}
