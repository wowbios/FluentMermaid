using System.Text;
using FluentMermaid.ClassDiagram.Enums;
using FluentMermaid.ClassDiagram.Interfaces;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class ClassNode : IClass
{
    private readonly List<IClassMember> _members = new();
    
    public ClassNode(ITypeName typeName, string? annotation)
    {
        Name = typeName ?? throw new ArgumentNullException(nameof(typeName));
        Annotation = annotation;
    }
    
    public ITypeName Name { get; }

    public string? Annotation { get; }

    public IClassMemberFunction AddFunction(string name, ITypeName? returnType, Visibility? visibility, params FunctionArgument[] arguments)
    {
        var member = new ClassMemberFunctionNode(name, arguments, returnType, visibility);
        _members.Add(member);
        return member;
    }

    public IClassMemberProperty AddProperty(string name, ITypeName? type, Visibility? visibility)
    {
        var member = new ClassMemberPropertyNode(name, type, visibility);
        _members.Add(member);
        return member;
    }

    public void RenderTo(StringBuilder builder)
    {
        builder.Append("class ");
        Name.RenderTo(builder);

        if (_members.Count > 0)
        {
            builder.AppendLine(" {");
            
            foreach (IClassMember member in _members)
                member.RenderTo(builder);
            
            builder.Append("}");
        }

        builder.AppendLine();

        if (!string.IsNullOrWhiteSpace(Annotation))
        {
            builder
                .Append("<<")
                .Append(Annotation)
                .Append(">> ");
            
            Name.RenderTo(builder);
            builder.AppendLine();
        }
    }
}