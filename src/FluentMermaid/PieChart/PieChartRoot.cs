using System.Text;
using FluentMermaid.PieChart.Interfaces;

namespace FluentMermaid.PieChart;

internal class PieChartRoot : IPieChart
{
    private readonly List<IValue> _values = new();

    public PieChartRoot(string? title, bool showData)
    {
        Title = title;
        ShowData = showData;
    }

    public string? Title { get; }
    
    public bool ShowData { get; }

    public IValue Add(string name, double value)
    {
        var pieValue = new Value(name, value);
        _values.Add(pieValue);
        return pieValue;
    }

    public IValue Add(string name, float value)
    {
        var pieValue = new Value(name, value);
        _values.Add(pieValue);
        return pieValue;
    }

    public IValue Add(string name, int value)
    {
        var pieValue = new Value(name, value);
        _values.Add(pieValue);
        return pieValue;
    }

    public IValue Add(string name, decimal value)
    {
        var pieValue = new Value(name, value);
        _values.Add(pieValue);
        return pieValue;
    }

    public string Render()
    {
        var builder = new StringBuilder();

        builder.Append("pie ");
        builder.AppendLine(ShowData ? "showData" : null);

        if (!string.IsNullOrWhiteSpace(Title))
            builder
                .Append("title ")
                .AppendLine(Title);

        foreach (IValue value in _values)
            value.RenderTo(builder);

        return builder.ToString();
    }
}