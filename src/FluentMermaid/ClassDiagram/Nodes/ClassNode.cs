using System.Text;
using FluentMermaid.ClassDiagram.Interfaces;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class ClassNode : IClass
{
    private readonly List<IClassMember> _members = new();
    
    public ClassNode(ITypeName typeName)
    {
        Name = typeName ?? throw new ArgumentNullException(nameof(typeName));
    }
    
    public ITypeName Name { get; }

    public IClassMemberFunction AddFunction(string name, ITypeName? returnType, params FunctionArgument[] arguments)
    {
        var member = new ClassMemberFunctionNode(name, arguments, returnType);
        _members.Add(member);
        return member;
    }

    public IClassMemberProperty AddProperty(string name, ITypeName? type)
    {
        var member = new ClassMemberPropertyNode(name, type);
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
    }
}