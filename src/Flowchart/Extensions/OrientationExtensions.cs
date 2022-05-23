using FluentMermaid.Flowchart.Enum;

namespace FluentMermaid.Flowchart.Extensions;

internal static class OrientationExtensions
{
    public static string Render(this Orientation orientation)
        => orientation switch
        {
            Orientation.TopToBottom => "TB",
            Orientation.BottomToTop => "BT",
            Orientation.RightToLeft => "RL",
            Orientation.LeftToRight => "LR",
            _ => throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null)
        };
}