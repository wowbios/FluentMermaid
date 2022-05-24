using System.Text;

namespace FluentMermaid.ClassDiagram.Interfaces;

public interface ICallback : IRenderTo<StringBuilder>
{
    IClass Class { get; }
    
    string Function { get; }
    
    string? Tooltip { get; }
}