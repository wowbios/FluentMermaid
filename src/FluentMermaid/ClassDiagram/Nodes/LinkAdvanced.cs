using System.Text;
using FluentMermaid.ClassDiagram.Interfaces;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class LinkAdvanced : ILink
{
    private readonly ClassNodeAdvanced _class;

    public LinkAdvanced(ClassNodeAdvanced @class, Uri url, string? tooltip)
    {
        _class = @class ?? throw new ArgumentNullException(nameof(@class));
        Url = url ?? throw new ArgumentNullException(nameof(url));
        Tooltip = tooltip;
    }

    public IClass Class => _class;

    public Uri Url { get; }

    public string? Tooltip { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("link ")
            .Append(_class.ClassNameId)
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
