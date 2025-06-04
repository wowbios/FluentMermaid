using System;
using FluentMermaid.Enums;
using FluentMermaid.StateDiagram;
using Xunit;

namespace FluentMermaid.Tests;

public class StateDiagramTests
{
    [Fact]
    public void Render_ShouldReturnExpectedDiagram()
    {
        var diagram = StateDiagramBuilder.Create(Orientation.LeftToRight);
        var idle = diagram.AddState("Idle");
        diagram.StartTo(idle);

        var newline = Environment.NewLine;
        var expected =
            "stateDiagram-v2" + newline +
            "direction LR" + newline +
            "s0 : Idle" + newline +
            "[*] --> s0" + newline;

        Assert.Equal(expected, diagram.Render());
    }
}
