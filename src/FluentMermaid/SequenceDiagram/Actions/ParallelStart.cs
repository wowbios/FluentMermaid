using System.Text;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct ParallelStart : IAction
{
    public ParallelStart(string? title, bool isFirst)
    {
        Title = title;
        IsFirst = isFirst;
    }

    public string? Title { get; }

    public bool IsFirst { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append(IsFirst ? "par " : "and ")
            .AppendLine(Title);
    }
}