using System.Text;
using FluentMermaid.ClassDiagram.Extensions;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

namespace FluentMermaid.ClassDiagram.Nodes;

public class TypeName : ITypeName
{
    public TypeName(string name, string? genericType)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name should not be null or empty", nameof(name));
        
        Name = name;
        GenericType = genericType;
    }

    public string Name { get; }
    
    public string? GenericType { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder.AppendValidName(Name);
        if (!string.IsNullOrWhiteSpace(GenericType))
        {
            builder
                .Append('~')
                .AppendValidName(GenericType)
                .Append('~');
        }
    }
}