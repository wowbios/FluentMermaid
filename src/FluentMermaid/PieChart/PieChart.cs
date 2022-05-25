using FluentMermaid.PieChart.Interfaces;

namespace FluentMermaid.PieChart;

public static class PieChart
{
    public static IPieChart Create(string? title, bool showData) => new PieChartRoot(title, showData);
}