using System.Text;
using FluentMermaid.ClassDiagram.Interfaces;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class Link : ILink
{
    public Link(IClass @class, Uri url, string? tooltip)
    {
        Class = @class;
        Url = url;
        Tooltip = tooltip;
    }

    public IClass Class { get; }
    
    public Uri Url { get; }
    
    public string? Tooltip { get; }
    
    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("link ")
            .Append(Class.Name.Name)
            .Append(" \"")
            .Append(Url)
            .Append('"');

        if (!string.IsNullOrWhiteSpace(Tooltip))
        {
            builder
                .Append(" \"")
                .Append(Tooltip)
                .Append('"');
        }

        builder.AppendLine();
    }
}