using System.Text;
using FluentMermaid.ClassDiagram.Interfaces;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;
using FluentMermaid.ClassDiagram.Nodes;
using FluentMermaid.Enums;
using FluentMermaid.Extensions;

namespace FluentMermaid.ClassDiagram;

internal class ClassDiagramRoot : IClassDiagram
{
    private readonly List<IClass> _classes = new();
    
    public ClassDiagramRoot(Orientation orientation)
    {
        Orientation = orientation;
    }

    public Orientation Orientation { get; }

    public IClass AddClass(ITypeName typeName)
    {
        _ = typeName ?? throw new ArgumentNullException(nameof(typeName));
        
        var @class = new ClassNode(typeName);
        _classes.Add(@class);
        return @class;
    }

    public string Render()
    {
        StringBuilder builder = new();
        builder.AppendLine("classDiagram");
        builder.Append("direction ").AppendLine(Orientation.Render());

        _classes.ForEach(c => c.RenderTo(builder));

        return builder.ToString();
    }
}