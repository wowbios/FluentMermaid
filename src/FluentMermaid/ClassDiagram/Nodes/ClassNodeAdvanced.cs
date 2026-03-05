using System.Text;
using FluentMermaid.ClassDiagram.Enums;
using FluentMermaid.ClassDiagram.Extensions;
using FluentMermaid.ClassDiagram.Interfaces;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class ClassNodeAdvanced : IClass
{
    private readonly List<IClassMember> _members = new();

    public ClassNodeAdvanced(ITypeName typeName, string? annotation, string? cssClass)
    {
        Name = typeName ?? throw new ArgumentNullException(nameof(typeName));
        Annotation = annotation;
        CssClass = cssClass;
    }

    public ITypeName Name { get; }

    public string? Annotation { get; }

    public string? CssClass { get; }

    private LinkAdvanced? Link { get; set; }

    private CallbackAdvanced? Callback { get; set; }

    public IClassMemberFunction AddFunction(string name, ITypeName? returnType, Visibility? visibility, params FunctionArgument[] arguments)
    {
        var member = new ClassMemberFunctionNodeAdvanced(name, arguments, returnType, visibility);
        _members.Add(member);
        return member;
    }

    public IClassMemberProperty AddProperty(string name, ITypeName? type, Visibility? visibility)
    {
        var member = new ClassMemberPropertyNodeAdvanced(name, type, visibility);
        _members.Add(member);
        return member;
    }

    public ICallback SetCallback(string function, string? tooltip)
    {
        var callback = new CallbackAdvanced(this, function, tooltip);
        Callback = callback;
        return callback;
    }

    public ILink SetLink(Uri url, string? tooltip)
    {
        var link = new LinkAdvanced(this, url, tooltip);
        Link = link;
        return link;
    }

    public void RenderTo(StringBuilder builder)
    {
        RenderDeclarationTo(builder, null);
        RenderMetadataTo(builder);
    }

    public void RenderDeclarationTo(StringBuilder builder, string? indent)
    {
        if (!string.IsNullOrEmpty(indent))
        {
            builder.Append(indent);
        }

        builder.Append("class ");
        Name.RenderTo(builder);

        if (_members.Count > 0)
        {
            builder.AppendLine(" {");

            foreach (IClassMember member in _members)
            {
                if (!string.IsNullOrEmpty(indent))
                {
                    builder.Append(indent);
                }

                builder.Append("  ");
                member.RenderTo(builder);
            }

            if (!string.IsNullOrEmpty(indent))
            {
                builder.Append(indent);
            }

            builder.Append("}");
        }

        builder.AppendLine();
    }

    public void RenderMetadataTo(StringBuilder builder)
    {
        if (!string.IsNullOrWhiteSpace(Annotation))
        {
            builder
                .Append("<<")
                .Append(Annotation)
                .Append(">> ");
            Name.RenderTo(builder);
            builder.AppendLine();
        }

        Link?.RenderTo(builder);
        Callback?.RenderTo(builder);

        if (!string.IsNullOrWhiteSpace(CssClass))
        {
            builder
                .Append("cssClass \"")
                .Append(ClassNameId)
                .Append("\" ")
                .AppendLine(CssClass);
        }
    }

    internal string ClassNameId => Name.Name.ToValidClassName();
}
