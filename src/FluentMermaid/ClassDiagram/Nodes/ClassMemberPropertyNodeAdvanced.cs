using System.Text;
using FluentMermaid.ClassDiagram.Enums;
using FluentMermaid.ClassDiagram.Extensions;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class ClassMemberPropertyNodeAdvanced : IClassMemberProperty
{
    public ClassMemberPropertyNodeAdvanced(string name, ITypeName? type, Visibility? visibility)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Property name should not be null or empty", nameof(name));
        }

        Name = name;
        Type = type;
        Visibility = visibility;
    }

    public Visibility? Visibility { get; }

    public string Name { get; }

    public ITypeName? Type { get; }

    public void RenderTo(StringBuilder builder)
    {
        char prefix = Visibility.HasValue ? Visibility.Value.RenderPrefix() : ' ';
        char suffix = Visibility.HasValue ? Visibility.Value.RenderSuffix() : ' ';

        if (prefix != ' ')
        {
            builder.Append(prefix);
        }

        if (Type is not null)
        {
            Type.RenderTo(builder);
            builder.Append(' ');
        }

        builder.AppendValidName(Name);

        if (suffix != ' ')
        {
            builder.Append(suffix);
        }

        builder.AppendLine();
    }
}
