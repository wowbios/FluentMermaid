using System.Text;
using FluentMermaid.SequenceDiagram.Enum;
using FluentMermaid.SequenceDiagram.Extensions;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct Note : IAction
{
    public Note(
        IMember member,
        NoteLocation location,
        string text)
    {
        Member = member;
        Location = location;
        Text = text;
    }

    public IMember Member { get; }

    public NoteLocation Location { get; }

    public string Text { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("Note ")
            .Append(Location.Render())
            .Append(' ')
            .Append(Member.Id)
            .Append(':')
            .AppendLine(Text);
    }
}