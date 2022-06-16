using System.Text;
using FluentMermaid.StateDiagram.Enum;
using FluentMermaid.StateDiagram.Extensions;
using FluentMermaid.StateDiagram.Interfaces;

namespace FluentMermaid.StateDiagram.Nodes;

internal sealed class Note : INote
{
    public Note(IState relatedState, NoteLocation location, string text)
    {
        RelatedState = relatedState;
        Location = location;
        Text = text;
    }

    public IState RelatedState { get; }

    public NoteLocation Location { get; }

    public string Text { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("note ")
            .Append(Location.Render())
            .Append(' ')
            .AppendLine(RelatedState.Id)
            .AppendLine(Text)
            .AppendLine("end note");
    }
}