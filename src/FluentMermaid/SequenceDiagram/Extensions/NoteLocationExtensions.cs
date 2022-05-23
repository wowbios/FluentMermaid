using FluentMermaid.SequenceDiagram.Enum;

namespace FluentMermaid.SequenceDiagram.Extensions;

public static class NoteLocationExtensions
{
    public static string Render(this NoteLocation location)
        => location switch
        {
            NoteLocation.RightOf => "right of",
            NoteLocation.LeftOf => "left of",
            NoteLocation.Over => "over",
            _ => throw new ArgumentOutOfRangeException(nameof(location), location, null)
        };
}