namespace FluentMermaid.PieChart.Interfaces;

public interface IPieChart
{
    string? Title { get; }

    bool ShowData { get; }

    IValue Add(string name, double value);

    IValue Add(string name, float value);

    IValue Add(string name, int value);

    IValue Add(string name, decimal value);

    string Render();
}