using FluentMermaid.ClassDiagram.Enums;

namespace FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

public interface IClassMemberProperty : IClassMember
{
    Visibility? Visibility { get; }
    
    string Name { get; }
    
    ITypeName? Type { get; }
}