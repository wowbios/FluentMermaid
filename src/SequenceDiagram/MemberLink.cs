using System.Text;
using FluentMermaid.Flowchart.Extensions;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram;

internal readonly struct MemberLink : IRenderTo<StringBuilder>
{
    public MemberLink(Member member, string label, Uri url)
    {
        if (string.IsNullOrWhiteSpace(label))
            throw new ArgumentException("Label should not be null or empty", nameof(label));

        Member = member;
        Label = label;
        Url = url;
    }

    public Member Member { get; }

    public string Label { get; }

    public Uri Url { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append('\"')
            .WriteEscaped(Label)
            .Append("\": \"")
            .Append(Url)
            .Append('\"');
    }
}