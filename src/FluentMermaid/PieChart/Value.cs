using System.Text;
using FluentMermaid.PieChart.Interfaces;

namespace FluentMermaid.PieChart;

internal class Value : IValue
{
    public Value(string title, double value)
        : this(title)
    {
        if (value < 0)
            ValueIsNegative();

        DoubleValue = value;
    }
    
    public Value(string title, int value)
        : this(title)
    {
        if (value < 0)
            ValueIsNegative();

        IntValue = value;
    }
    
    public Value(string title, decimal value)
        : this(title)
    {
        if (value < 0)
            ValueIsNegative();

        DecimalValue = value;
    }
    
    public Value(string title, float value)
        : this(title)
    {
        if (value < 0)
            ValueIsNegative();

        FloatValue = value;
    }
    
    private Value(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Value title should not be null or empty", nameof(title));

        Title = title;
    }

    public string Title { get; }
    
    public double? DoubleValue { get; }
    
    public float? FloatValue { get; }
    
    public int? IntValue { get; }
    
    public decimal? DecimalValue { get; }

    private static void ValueIsNegative()
        => throw new ArgumentException(
            "Value should be 0 or positive",
            // ReSharper disable once NotResolvedInText
            "value");

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append('"')
            .Append(Title)
            .Append("\" : ")
            .AppendLine(RenderValue());
    }

    private string RenderValue()
        => DoubleValue?.ToString()
           ?? IntValue?.ToString()
           ?? FloatValue?.ToString()
           ?? DecimalValue?.ToString()
           ?? "0";
}