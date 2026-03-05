using System.Text;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class ClassDefNode : IClassDiagramStatement
{
    public ClassDefNode(string className, string styles)
    {
        if (string.IsNullOrWhiteSpace(className))
        {
            throw new ArgumentException("ClassDef class name should not be null or empty", nameof(className));
        }

        if (string.IsNullOrWhiteSpace(styles))
        {
            throw new ArgumentException("ClassDef styles should not be null or empty", nameof(styles));
        }

        ClassName = className;
        Styles = styles;
    }

    public string ClassName { get; }

    public string Styles { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("classDef ")
            .Append(ClassName)
            .Append(' ')
            .AppendLine(Styles);
    }
}
