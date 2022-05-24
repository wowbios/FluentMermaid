using System.Text;
using FluentMermaid.ClassDiagram.Enums;
using FluentMermaid.ClassDiagram.Extensions;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class ClassMemberPropertyNode : IClassMemberProperty
{
    public ClassMemberPropertyNode(string name, ITypeName? type, Visibility? visibility)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Property name should not be null or empty", nameof(name));

        Name = name;
        Type = type ?? throw new ArgumentNullException(nameof(type));
        Visibility = visibility;
    }

    public Visibility? Visibility { get; }

    public string Name { get; }

    public ITypeName? Type { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder.Append(Visibility?.Render(true));
        if (Type is not null)
        {
            Type.RenderTo(builder);
            builder.Append(' ');
        }

        builder.AppendValidName(Name);

        if (Type is not null)
            builder.Append(Visibility?.Render(false));

        builder.AppendLine();
    }
}