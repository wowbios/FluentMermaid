using FluentMermaid.Enums;
using FluentMermaid.Flowchart;
using FluentMermaid.Flowchart.Enum;

namespace FluentMermaid.Tests;

public class FlowchartRenderingTests
{
    [Fact]
    public void LinkRendering_UsesCurrentMermaidLengthRules()
    {
        var chart = FlowChart.Create(Orientation.LeftToRight);
        var start = chart.TextNode("Start", Shape.Rectangle);
        var end = chart.TextNode("End", Shape.Rectangle);

        chart.Link(start, end, Link.Thick, "", 1);
        chart.Link(start, end, Link.Dotted, "", 2);

        string rendered = Normalize(chart.Render());

        Assert.Contains("id0 ==> id1", rendered);
        Assert.Contains("id0 -..- id1", rendered);
    }

    [Fact]
    public void LinkRendering_SupportsInvisibleAndDottedArrowLinks()
    {
        var chart = FlowChart.Create(Orientation.LeftToRight);
        var a = chart.TextNode("A", Shape.Rectangle);
        var b = chart.TextNode("B", Shape.Rectangle);

        chart.Link(a, b, Link.Invisible, "", 1);
        chart.Link(a, b, Link.DottedArrow, "", 1);

        string rendered = Normalize(chart.Render());

        Assert.Contains("id0 ~~~ id1", rendered);
        Assert.Contains("id0 -.-> id1", rendered);
    }

    [Fact]
    public void AdvancedApi_RendersExpandedShapeSyntax()
    {
        var chart = FlowChart.CreateAdvanced(Orientation.LeftToRight);
        chart.TextNode("Manual input", AdvancedShape.SlopedRectangle);

        string rendered = Normalize(chart.Render());

        Assert.Contains("id0@{ shape: sl-rect, label: \"Manual input\" }", rendered);
    }

    [Fact]
    public void AdvancedApi_RendersIconAndImageNodes()
    {
        var chart = FlowChart.CreateAdvanced(Orientation.LeftToRight);
        chart.IconNode("fa:user", "User Icon", "square", "t", 60);
        chart.ImageNode(new Uri("https://example.com/image.png"), "Image Label", "t", 60, 60, false);

        string rendered = Normalize(chart.Render());

        Assert.Contains("id0@{ icon: \"fa:user\", form: \"square\", label: \"User Icon\", pos: \"t\", h: 60 }", rendered);
        Assert.Contains("id1@{ img: \"https://example.com/image.png\", label: \"Image Label\", pos: \"t\", w: 60, h: 60, constraint: \"off\" }", rendered);
    }

    [Fact]
    public void AdvancedApi_RendersEdgeIdAndEdgeProperties()
    {
        var chart = FlowChart.CreateAdvanced(Orientation.LeftToRight);
        var a = chart.TextNode("A", Shape.Rectangle);
        var b = chart.TextNode("B", Shape.Rectangle);

        chart.Link(a, b, "e1", Link.Arrow, "", 1);
        chart.EdgeStyling.SetAnimated("e1");
        chart.EdgeStyling.SetAnimation("e1", EdgeAnimationSpeed.Fast);
        chart.EdgeStyling.SetCurve("e1", EdgeCurve.Linear);
        chart.EdgeStyling.SetClass("e1", "animate");
        chart.EdgeStyling.LinkStyle(0, "stroke:#ff3");
        chart.EdgeStyling.LinkStyleDefault("color:blue");

        string rendered = Normalize(chart.Render());

        Assert.Contains("id0 e1@--> id1", rendered);
        Assert.Contains("e1@{ animate: true, animation: fast, curve: linear }", rendered);
        Assert.Contains("class e1 animate", rendered);
        Assert.Contains("linkStyle 0 stroke:#ff3;", rendered);
        Assert.Contains("linkStyle default color:blue;", rendered);
    }

    private static string Normalize(string input) => input.Replace("\r\n", "\n");
}
