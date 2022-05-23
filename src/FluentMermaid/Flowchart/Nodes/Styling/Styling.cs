using System.Text;
using FluentMermaid.Flowchart.Interfaces;
using FluentMermaid.Flowchart.Interfaces.Styling;

namespace FluentMermaid.Flowchart.Nodes.Styling;

internal record Styling : IStyling
{
    private readonly List<(string id, string css)> _styles = new();
    private readonly List<IStylingClass> _classes = new();
    private readonly List<(string id, string classId)> _classNodes = new ();

    public Styling(string id)
    {
        Id = id;
    }

    public void RenderTo(StringBuilder builder)
    {
        if (!string.IsNullOrWhiteSpace(DefaultStyle))
            new StylingClass("default", DefaultStyle!).RenderTo(builder);

        _classes.ForEach(sc => sc.RenderTo(builder));

        foreach ((string id, string classId) in _classNodes)
        {
            builder
                .Append("class ")
                .Append(id)
                .Append(' ')
                .Append(classId)
                .AppendLine(";");
        }
        
        foreach ((string id, string css) in _styles)
        {
            builder
                .Append("style ")
                .Append(id)
                .Append(' ')
                .AppendLine(css);
        }
    }

    public void Set(INode node, string css)
        => _styles.Add((node.Id, css));

    public void SetClass(INode node, IStylingClass stylingClass)
        => _classNodes.Add((node.Id, stylingClass.Id));

    public void SetClass(INode node, string className)
        => _classNodes.Add((node.Id, className));

    public string? DefaultStyle { get; set; }
    public string Id { get; }

    public IStylingClass AddClass(string css)
    {
        var stylingClass = new StylingClass(CreateClassId(), css);
        _classes.Add(stylingClass);
        return stylingClass;
    }

    private string CreateClassId() => "classN" + _classes.Count;

    public void Deconstruct(out string Id)
    {
        Id = this.Id;
    }
}