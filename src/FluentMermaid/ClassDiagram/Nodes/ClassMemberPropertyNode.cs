using System.Text;
using FluentMermaid.ClassDiagram.Extensions;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class ClassMemberPropertyNode : IClassMemberProperty
{
    public ClassMemberPropertyNode(string name, ITypeName? type)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Property name should not be null or empty", nameof(name));

        Name = name;
        Type = type ?? throw new ArgumentNullException(nameof(type));
    }

    public string Name { get; }
    
    public ITypeName? Type { get; }
    
    public void RenderTo(StringBuilder builder)
    {
        if (Type is not null)
        {
            Type.RenderTo(builder);
            builder.Append(' ');
        }
        
        builder
            .AppendValidName(Name)
            .AppendLine();
    }
}