using System.Text;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class CssClassNode : IClassDiagramStatement
{
    public CssClassNode(string classIds, string className)
    {
        if (string.IsNullOrWhiteSpace(classIds))
        {
            throw new ArgumentException("Class ids should not be null or empty", nameof(classIds));
        }

        if (string.IsNullOrWhiteSpace(className))
        {
            throw new ArgumentException("Class name should not be null or empty", nameof(className));
        }

        ClassIds = classIds;
        ClassName = className;
    }

    public string ClassIds { get; }

    public string ClassName { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("cssClass \"")
            .Append(ClassIds)
            .Append("\" ")
            .AppendLine(ClassName);
    }
}
