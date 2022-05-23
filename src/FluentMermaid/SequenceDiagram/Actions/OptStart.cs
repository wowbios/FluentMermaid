using System.Text;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal record OptStart : IAction
{
    public OptStart(string? Title)
    {
        this.Title = Title;
    }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("opt ")
            .AppendLine(Title);
    }

    public string? Title { get; }

    public void Deconstruct(out string? Title)
    {
        Title = this.Title;
    }
}