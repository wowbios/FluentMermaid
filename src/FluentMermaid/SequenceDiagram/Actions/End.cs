using System.Text;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct End : IAction
{
    public void RenderTo(StringBuilder builder)
        => builder.AppendLine("end");
}