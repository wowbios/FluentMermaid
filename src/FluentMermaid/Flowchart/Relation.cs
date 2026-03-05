using System.Text;
using FluentMermaid.Extensions;
using FluentMermaid.Flowchart.Enum;
using FluentMermaid.Flowchart.Extensions;

namespace FluentMermaid.Flowchart;

internal record Relation : IRenderTo<StringBuilder>
{
    internal Relation(
        INode @from,
        INode to,
        Link link,
        string text,
        int length,
        string? edgeId = null)
    {
        From = @from;
        To = to;
        Text = text;
        Length = length;
        Link = link;
        EdgeId = edgeId;
    }

    public INode From { get; }
    
    public INode To { get; }
    
    public Link Link { get; }
    
    public string Text { get; }

    public int Length { get; }

    public string? EdgeId { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append(From.Id)
            .Append(' ');

        if (!string.IsNullOrWhiteSpace(EdgeId))
            builder.Append(EdgeId).Append('@');

        Link.RenderTo(builder, Length);
        builder.Append(' ');

        if (!string.IsNullOrEmpty(Text))
        {
            builder
                .Append("|\"")
                .WriteEscaped(Text)
                .Append("\"|")
                .Append(' ');
        }
        builder.AppendLine(To.Id);
    }
}