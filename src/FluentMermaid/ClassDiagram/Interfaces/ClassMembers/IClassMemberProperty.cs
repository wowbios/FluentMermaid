namespace FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

public interface IClassMemberProperty : IClassMember
{
    string Name { get; }
    
    ITypeName? Type { get; }
}