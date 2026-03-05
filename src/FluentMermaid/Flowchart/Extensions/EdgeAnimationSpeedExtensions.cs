using FluentMermaid.Flowchart.Enum;

namespace FluentMermaid.Flowchart.Extensions;

internal static class EdgeAnimationSpeedExtensions
{
    public static string Render(this EdgeAnimationSpeed speed)
        => speed switch
        {
            EdgeAnimationSpeed.Fast => "fast",
            EdgeAnimationSpeed.Slow => "slow",
            _ => throw new ArgumentOutOfRangeException(nameof(speed), speed, null)
        };
}
