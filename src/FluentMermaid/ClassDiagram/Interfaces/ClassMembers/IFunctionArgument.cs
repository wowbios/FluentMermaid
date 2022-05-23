using System.Text;

namespace FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

public interface IFunctionArgument : IRenderTo<StringBuilder>
{
    ITypeName Type { get; }
    
    string Name { get; }
}