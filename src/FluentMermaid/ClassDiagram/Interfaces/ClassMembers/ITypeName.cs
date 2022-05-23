using System.Text;

namespace FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

public interface ITypeName : IRenderTo<StringBuilder>
{
    string Name { get; }
    
    string? GenericType { get; }
}