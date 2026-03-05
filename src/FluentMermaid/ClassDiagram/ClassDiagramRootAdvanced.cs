using System.Text;
using FluentMermaid.ClassDiagram.Enums;
using FluentMermaid.ClassDiagram.Interfaces;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;
using FluentMermaid.ClassDiagram.Nodes;
using FluentMermaid.Enums;
using FluentMermaid.Extensions;

namespace FluentMermaid.ClassDiagram;

internal class ClassDiagramRootAdvanced : IClassDiagramAdvanced
{
    private readonly List<ClassNodeAdvanced> _classes = new();
    private readonly List<IRelation> _relations = new();
    private readonly List<IClassDiagramStatement> _statements = new();
    private readonly Dictionary<string, List<ClassNodeAdvanced>> _namespaces = new(StringComparer.Ordinal);
    private readonly List<string> _namespaceOrder = new();

    public ClassDiagramRootAdvanced(Orientation orientation)
    {
        Orientation = orientation;
    }

    public Orientation Orientation { get; }

    public IClass AddClass(ITypeName typeName, string? annotation, string? cssClass)
    {
        _ = typeName ?? throw new ArgumentNullException(nameof(typeName));

        var @class = new ClassNodeAdvanced(typeName, annotation, cssClass);
        _classes.Add(@class);
        return @class;
    }

    public IClass AddClassInNamespace(string @namespace, ITypeName typeName, string? annotation, string? cssClass)
    {
        if (string.IsNullOrWhiteSpace(@namespace))
        {
            throw new ArgumentException("Namespace should not be null or empty", nameof(@namespace));
        }

        var @class = (ClassNodeAdvanced)AddClass(typeName, annotation, cssClass);

        if (!_namespaces.TryGetValue(@namespace, out List<ClassNodeAdvanced>? classes))
        {
            classes = new List<ClassNodeAdvanced>();
            _namespaces[@namespace] = classes;
            _namespaceOrder.Add(@namespace);
        }

        classes.Add(@class);
        return @class;
    }

    public IRelation Relation(
        IClass from,
        IClass to,
        Relationship? relationshipFrom,
        Cardinality? cardinalityFrom,
        Relationship? relationshipTo,
        Cardinality? cardinalityTo,
        RelationLink relationLink,
        string? label)
    {
        var relation = new RelationNode(
            from,
            to,
            relationshipFrom,
            cardinalityFrom,
            relationLink,
            cardinalityTo,
            relationshipTo,
            label);
        _relations.Add(relation);
        return relation;
    }

    public IClassDiagramAdvanced AddNote(string text)
    {
        _statements.Add(new NoteNode(text));
        return this;
    }

    public IClassDiagramAdvanced AddNoteFor(IClass @class, string text)
    {
        if (@class is not ClassNodeAdvanced classNode)
        {
            throw new ArgumentException("Note target should be created by advanced class diagram API", nameof(@class));
        }

        _statements.Add(new NoteNode(text, classNode));
        return this;
    }

    public IClassDiagramAdvanced AddClassDef(string className, string styles)
    {
        _statements.Add(new ClassDefNode(className, styles));
        return this;
    }

    public IClassDiagramAdvanced AddCssClass(string classIds, string className)
    {
        _statements.Add(new CssClassNode(classIds, className));
        return this;
    }

    public string Render()
    {
        StringBuilder builder = new();
        builder.AppendLine("classDiagram");
        builder.Append("direction ").AppendLine(Orientation.Render());

        _relations.ForEach(r => r.RenderTo(builder));

        HashSet<ClassNodeAdvanced> namespaceClasses = new();
        foreach (string namespaceName in _namespaceOrder)
        {
            List<ClassNodeAdvanced> classes = _namespaces[namespaceName];
            new NamespaceNode(namespaceName, classes).RenderTo(builder);
            foreach (ClassNodeAdvanced @class in classes)
            {
                namespaceClasses.Add(@class);
            }
        }

        foreach (ClassNodeAdvanced @class in _classes)
        {
            if (!namespaceClasses.Contains(@class))
            {
                @class.RenderDeclarationTo(builder, null);
            }
        }

        foreach (IClassDiagramStatement statement in _statements)
        {
            statement.RenderTo(builder);
        }

        foreach (ClassNodeAdvanced @class in _classes)
        {
            @class.RenderMetadataTo(builder);
        }

        return builder.ToString();
    }
}
