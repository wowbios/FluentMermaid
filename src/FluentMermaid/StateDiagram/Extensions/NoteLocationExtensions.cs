using FluentMermaid.StateDiagram.Enum;

namespace FluentMermaid.StateDiagram.Extensions;

public static class NoteLocationExtensions
{
    public static string Render(this NoteLocation location)
        => location switch
        {
            NoteLocation.Right => "right of",
            NoteLocation.Left => "left of",
            _ => throw new ArgumentOutOfRangeException(nameof(location), location, null)
        };
}