using System.Text;

namespace FluentMermaid.PieChart.Interfaces;

public interface IValue : IRenderTo<StringBuilder>
{
    string Title { get; }
    
    double? DoubleValue { get; }
    
    float? FloatValue { get; }
    
    int? IntValue { get; }
    
    decimal? DecimalValue { get; }
}