using FluentMermaid.Flowchart.Enum;

namespace FluentMermaid.Flowchart.Extensions;

internal static class HyperlinkTargetExtensions
{
    public static string Render(this HyperlinkTarget target)
        => target switch
        {
            HyperlinkTarget.Self => "_self",
            HyperlinkTarget.Blank => "_blank",
            HyperlinkTarget.Parent => "_parent",
            HyperlinkTarget.Top => "_top",
            _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
        };
}