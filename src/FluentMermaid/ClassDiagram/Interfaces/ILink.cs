using System.Text;

namespace FluentMermaid.ClassDiagram.Interfaces;

public interface ILink : IRenderTo<StringBuilder>
{
    IClass Class { get; }
    
    Uri Url { get; }
    
    string? Tooltip { get; }
}