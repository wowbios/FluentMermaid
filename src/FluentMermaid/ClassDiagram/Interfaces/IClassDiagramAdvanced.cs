using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

namespace FluentMermaid.ClassDiagram.Interfaces;

public interface IClassDiagramAdvanced : IClassDiagram
{
    IClass AddClassInNamespace(string @namespace, ITypeName typeName, string? annotation, string? cssClass);

    IClassDiagramAdvanced AddNote(string text);

    IClassDiagramAdvanced AddNoteFor(IClass @class, string text);

    IClassDiagramAdvanced AddClassDef(string className, string styles);

    IClassDiagramAdvanced AddCssClass(string classIds, string className);
}
