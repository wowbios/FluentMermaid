using FluentMermaid.Flowchart.Enum;

namespace FluentMermaid.Flowchart.Extensions;

internal static class EdgeCurveExtensions
{
    public static string Render(this EdgeCurve curve)
        => curve switch
        {
            EdgeCurve.Basis => "basis",
            EdgeCurve.BumpX => "bumpX",
            EdgeCurve.BumpY => "bumpY",
            EdgeCurve.Cardinal => "cardinal",
            EdgeCurve.CatmullRom => "catmullRom",
            EdgeCurve.Linear => "linear",
            EdgeCurve.MonotoneX => "monotoneX",
            EdgeCurve.MonotoneY => "monotoneY",
            EdgeCurve.Natural => "natural",
            EdgeCurve.Step => "step",
            EdgeCurve.StepAfter => "stepAfter",
            EdgeCurve.StepBefore => "stepBefore",
            _ => throw new ArgumentOutOfRangeException(nameof(curve), curve, null)
        };
}
