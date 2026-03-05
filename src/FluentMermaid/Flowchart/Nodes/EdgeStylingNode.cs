using System.Text;
using FluentMermaid.Flowchart.Enum;
using FluentMermaid.Flowchart.Extensions;
using FluentMermaid.Flowchart.Interfaces;

namespace FluentMermaid.Flowchart.Nodes;

internal sealed class EdgeStylingNode : IEdgeStyling
{
    private readonly Dictionary<string, EdgeProperties> _edgeProperties = new();
    private readonly List<string> _edgePropertiesOrder = new();
    private readonly List<(string edgeId, string className)> _edgeClasses = new();
    private readonly List<(string selector, string css)> _linkStyles = new();

    public string Id { get; } = "edgeStyling";

    public void SetAnimated(string edgeId, bool value = true)
        => GetOrCreate(edgeId).Animate = value;

    public void SetAnimation(string edgeId, EdgeAnimationSpeed speed)
        => GetOrCreate(edgeId).Animation = speed;

    public void SetCurve(string edgeId, EdgeCurve curve)
        => GetOrCreate(edgeId).Curve = curve;

    public void SetClass(string edgeId, string className)
    {
        EnsureEdgeId(edgeId);
        if (string.IsNullOrWhiteSpace(className))
            throw new ArgumentException("Class name should not be null or empty", nameof(className));

        _edgeClasses.Add((edgeId, className));
    }

    public void LinkStyle(int linkIndex, string css)
    {
        if (linkIndex < 0)
            throw new ArgumentException("Link index should be non-negative", nameof(linkIndex));
        EnsureCss(css);

        _linkStyles.Add((linkIndex.ToString(), css));
    }

    public void LinkStyle(IEnumerable<int> linkIndexes, string css)
    {
        if (linkIndexes is null)
            throw new ArgumentNullException(nameof(linkIndexes));
        EnsureCss(css);

        var indexes = linkIndexes.ToArray();
        if (indexes.Length == 0)
            throw new ArgumentException("At least one link index should be provided", nameof(linkIndexes));
        if (indexes.Any(i => i < 0))
            throw new ArgumentException("All link indexes should be non-negative", nameof(linkIndexes));

        _linkStyles.Add((string.Join(",", indexes), css));
    }

    public void LinkStyleDefault(string css)
    {
        EnsureCss(css);
        _linkStyles.Add(("default", css));
    }

    public void RenderTo(StringBuilder builder)
    {
        foreach (string edgeId in _edgePropertiesOrder)
        {
            EdgeProperties props = _edgeProperties[edgeId];
            var pairs = new List<string>(3);

            if (props.Animate.HasValue)
                pairs.Add($"animate: {(props.Animate.Value ? "true" : "false")}");
            if (props.Animation.HasValue)
                pairs.Add($"animation: {props.Animation.Value.Render()}");
            if (props.Curve.HasValue)
                pairs.Add($"curve: {props.Curve.Value.Render()}");

            if (pairs.Count == 0)
                continue;

            builder
                .Append(edgeId)
                .Append("@{ ")
                .Append(string.Join(", ", pairs))
                .AppendLine(" }");
        }

        foreach ((string edgeId, string className) in _edgeClasses)
        {
            builder
                .Append("class ")
                .Append(edgeId)
                .Append(' ')
                .AppendLine(className);
        }

        foreach ((string selector, string css) in _linkStyles)
        {
            builder
                .Append("linkStyle ")
                .Append(selector)
                .Append(' ')
                .Append(css)
                .AppendLine(";");
        }
    }

    private EdgeProperties GetOrCreate(string edgeId)
    {
        EnsureEdgeId(edgeId);

        if (_edgeProperties.TryGetValue(edgeId, out EdgeProperties? value))
            return value;

        var props = new EdgeProperties();
        _edgeProperties[edgeId] = props;
        _edgePropertiesOrder.Add(edgeId);
        return props;
    }

    private static void EnsureEdgeId(string edgeId)
    {
        if (string.IsNullOrWhiteSpace(edgeId))
            throw new ArgumentException("Edge id should not be null or empty", nameof(edgeId));
    }

    private static void EnsureCss(string css)
    {
        if (string.IsNullOrWhiteSpace(css))
            throw new ArgumentException("CSS should not be null or empty", nameof(css));
    }

    private sealed class EdgeProperties
    {
        public bool? Animate { get; set; }

        public EdgeAnimationSpeed? Animation { get; set; }

        public EdgeCurve? Curve { get; set; }
    }
}
