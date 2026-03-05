using System.Text;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class NamespaceNode : IClassDiagramStatement
{
    public NamespaceNode(string name, IReadOnlyCollection<ClassNodeAdvanced> classes)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Namespace name should not be null or empty", nameof(name));
        }

        Name = name;
        Classes = classes ?? throw new ArgumentNullException(nameof(classes));
    }

    public string Name { get; }

    public IReadOnlyCollection<ClassNodeAdvanced> Classes { get; }

    public void RenderTo(StringBuilder builder)
    {
        if (Classes.Count == 0)
        {
            return;
        }

        builder
            .Append("namespace ")
            .Append(Name)
            .AppendLine(" {");

        foreach (ClassNodeAdvanced @class in Classes)
        {
            @class.RenderDeclarationTo(builder, "  ");
        }

        builder.AppendLine("}");
    }
}
