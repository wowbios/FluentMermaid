using FluentMermaid.ClassDiagram.Enums;
using FluentMermaid.ClassDiagram.Nodes;

namespace FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

public interface IClassMemberFunction : IClassMember 
{
    Visibility? Visibility { get; }
    
    string Function { get; }
    
    FunctionArgument[]? Arguments { get; }
    
    ITypeName? ReturnType { get; }
}