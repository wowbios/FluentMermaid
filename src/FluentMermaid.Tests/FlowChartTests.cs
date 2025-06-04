using System;
using FluentMermaid.Enums;
using FluentMermaid.Flowchart;
using FluentMermaid.Flowchart.Enum;
using Xunit;

namespace FluentMermaid.Tests;

public class FlowChartTests
{
    [Fact]
    public void Render_ShouldReturnExpectedDiagram()
    {
        var chart = FlowChart.Create(Orientation.LeftToRight);
        var a = chart.TextNode("A", Shape.Circle);
        var b = chart.TextNode("B", Shape.Circle);
        chart.Link(a, b, Link.Arrow, "hello");

        var newline = Environment.NewLine;
        var expected =
            "flowchart LR" + newline +
            "id0((\"A\"))" + newline +
            "id1((\"B\"))" + newline +
            "id0 --> |\"hello\"| id1" + newline;

        Assert.Equal(expected, chart.Render());
    }
}
