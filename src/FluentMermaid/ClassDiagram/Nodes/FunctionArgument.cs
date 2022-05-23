using System.Text;
using FluentMermaid.ClassDiagram.Extensions;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

namespace FluentMermaid.ClassDiagram.Nodes;

public class FunctionArgument : IRenderTo<StringBuilder>
{
    public FunctionArgument(string name, ITypeName type)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Function argument name should not be null or empty", nameof(name));
        
        Name = name;
        Type = type;
    }
    
    public string Name { get; }
    
    public ITypeName Type { get; }
    
    public void RenderTo(StringBuilder builder)
    {
        Type.RenderTo(builder);
        builder
            .Append(' ')
            .AppendValidName(Name);
    }
}