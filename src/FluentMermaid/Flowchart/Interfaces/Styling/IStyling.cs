namespace FluentMermaid.Flowchart.Interfaces.Styling;

public interface IStyling : INode
{
    void Set(INode node, string css);

    void SetClass(INode node, IStylingClass stylingClass);

    void SetClass(INode node, string className);
    
    string? DefaultStyle { get; set; }

    IStylingClass AddClass(string css);
}