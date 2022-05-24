using System.Text;
using FluentMermaid.ClassDiagram.Interfaces;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class Callback : ICallback
{
    public Callback(IClass @class, string function, string? tooltip)
    {
        if (string.IsNullOrWhiteSpace(function))
            throw new ArgumentException("Function name should not be null or empty", nameof(function));

        Class = @class ?? throw new ArgumentNullException(nameof(@class));
        Function = function;
        Tooltip = tooltip;
    }

    public IClass Class { get; }
    
    public string Function { get; }
    
    public string? Tooltip { get; }
    
    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("callback ")
            .Append(Class.Name.Name)
            .Append(" \"")
            .Append(Function)
            .Append('"');

        if (!string.IsNullOrWhiteSpace(Tooltip))
        {
            builder
                .Append(" \"")
                .Append(Tooltip)
                .Append('"');
        }

        builder.AppendLine();
    }
}