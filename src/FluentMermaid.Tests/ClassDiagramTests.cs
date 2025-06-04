using System;
using FluentMermaid.ClassDiagram;
using FluentMermaid.ClassDiagram.Nodes;
using FluentMermaid.Enums;
using Xunit;

namespace FluentMermaid.Tests;

public class ClassDiagramTests
{
    [Fact]
    public void Render_ShouldReturnExpectedDiagram()
    {
        var diagram = ClassDiagram.Create(Orientation.LeftToRight);
        diagram.AddClass(new TypeName("Person", null), null, null);

        var newline = Environment.NewLine;
        var expected =
            "classDiagram" + newline +
            "direction LR" + newline +
            "class Person" + newline;

        Assert.Equal(expected, diagram.Render());
    }
}
