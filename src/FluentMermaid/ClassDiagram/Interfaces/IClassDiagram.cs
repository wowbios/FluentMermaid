using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

namespace FluentMermaid.ClassDiagram.Interfaces;

public interface IClassDiagram
{
    IClass AddClass(ITypeName typeName);
    
    string Render();
}