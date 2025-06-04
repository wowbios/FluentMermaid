using System;
using FluentMermaid.PieChart;
using Xunit;

namespace FluentMermaid.Tests;

public class PieChartTests
{
    [Fact]
    public void Render_ShouldReturnExpectedDiagram()
    {
        var chart = PieChart.Create("Sales", true);
        chart.Add("A", 1);

        var newline = Environment.NewLine;
        var expected =
            "pie showData" + newline +
            "title Sales" + newline +
            "\"A\" : 1" + newline;

        Assert.Equal(expected, chart.Render());
    }
}
