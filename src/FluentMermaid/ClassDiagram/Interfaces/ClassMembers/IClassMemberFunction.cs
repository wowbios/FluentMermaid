using FluentMermaid.ClassDiagram.Nodes;

namespace FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

public interface IClassMemberFunction : IClassMember 
{
    string Function { get; }
    
    FunctionArgument[]? Arguments { get; }
    
    ITypeName? ReturnType { get; }
}