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
    
    private ILink? Link { get; set; }
    
    private ICallback? Callback { get; set; }

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

    public ICallback SetCallback(string function, string? tooltip)
    {
        var callback = new Callback(this, function, tooltip);
        Callback = callback;
        return callback;
    }

    public ILink SetLink(Uri url, string? tooltip)
    {
        var link = new Link(this, url, tooltip);
        Link = link;
        return link;
    }

    public void RenderTo(StringBuilder builder)
    {
       RenderClass(builder);
       RenderAnnotation(builder);
       Link?.RenderTo(builder);
       Callback?.RenderTo(builder);
    }

    private void RenderClass(StringBuilder builder)
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

    private void RenderAnnotation(StringBuilder builder)
    {
        if (string.IsNullOrWhiteSpace(Annotation))
            return;
        
        builder
            .Append("<<")
            .Append(Annotation)
            .Append(">> ");
            
        Name.RenderTo(builder);
        builder.AppendLine();
    }
}