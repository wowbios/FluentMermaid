using System.Text;
using FluentMermaid.SequenceDiagram.Enum;
using FluentMermaid.SequenceDiagram.Extensions;
using FluentMermaid.SequenceDiagram.Interfaces;
using FluentMermaid.Extensions;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct NoteOver : IAction
{
    public NoteOver(IMember[] members, string text)
    {
        Members = members;
        Text = text;
    }

    public IMember[] Members { get; }

    public string Text { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("Note ")
            .Append(NoteLocation.Over.Render())
            .Append(' ')
            .AppendJoin(',', Members.Select(m => m.Id))
            .Append(':')
            .AppendLine(Text);
    }
}