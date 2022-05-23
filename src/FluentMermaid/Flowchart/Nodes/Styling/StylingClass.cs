using System.Text;
using FluentMermaid.Flowchart.Interfaces.Styling;

namespace FluentMermaid.Flowchart.Nodes.Styling;

public record StylingClass : IStylingClass
{
    public StylingClass(string Id, string Style)
    {
        this.Id = Id;
        this.Style = Style;
    }

    public void RenderTo(StringBuilder builder)
    {
        builder.Append("classDef ")
            .Append(Id)
            .Append(' ')
            .Append(Style)
            .AppendLine(";");
    }

    public string Id { get; }
    public string Style { get; }

    public void Deconstruct(out string Id, out string Style)
    {
        Id = this.Id;
        Style = this.Style;
    }
}