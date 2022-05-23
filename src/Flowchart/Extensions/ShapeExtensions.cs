using FluentMermaid.Flowchart.Enum;

namespace FluentMermaid.Flowchart.Extensions;

internal static class ShapeExtensions
{
    public static string RenderStart(this Shape shape)
        => shape switch
        {
            Shape.RoundEdges => "(",
            Shape.Stadium => "([",
            Shape.Subroutine => "[[",
            Shape.Cylinder => "[(",
            Shape.Circle => "((",
            Shape.Asymmetric => ">",
            Shape.Rhombus => "{",
            Shape.Hexagon => "{{",
            Shape.Parallelogram => "[/",
            Shape.ParallelogramAlt => "[\\",
            Shape.Trapezoid => "[/",
            Shape.TrapezoidAlt => "[\\",
            Shape.DoubleCircle => "(((",
            _ => throw new ArgumentOutOfRangeException(nameof(shape), shape, null)
        };

    public static string RenderEnd(this Shape shape)
        => shape switch
        {
            Shape.RoundEdges => ")",
            Shape.Stadium => "])",
            Shape.Subroutine => "]]",
            Shape.Cylinder => ")]",
            Shape.Circle => "))",
            Shape.Asymmetric => "]",
            Shape.Rhombus => "}",
            Shape.Hexagon => "}}",
            Shape.Parallelogram => "/]",
            Shape.ParallelogramAlt => "\\]",
            Shape.Trapezoid => "\\]",
            Shape.TrapezoidAlt => "/]",
            Shape.DoubleCircle => ")))",
            _ => throw new ArgumentOutOfRangeException(nameof(shape), shape, null)
        };

}