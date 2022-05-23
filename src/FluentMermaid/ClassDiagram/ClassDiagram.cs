using FluentMermaid.ClassDiagram.Interfaces;
using FluentMermaid.Enums;

namespace FluentMermaid.ClassDiagram;

public static class ClassDiagram
{
    public static IClassDiagram Create(Orientation orientation)
        => new ClassDiagramRoot(orientation);
}