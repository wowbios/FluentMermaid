using System.Text;
using FluentMermaid.ClassDiagram.Enums;
using FluentMermaid.ClassDiagram.Extensions;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class ClassMemberFunctionNode : IClassMemberFunction
{
    public ClassMemberFunctionNode(
        string function,
        FunctionArgument[]? arguments,
        ITypeName? returnType,
        Visibility? visibility)
    {
        if (string.IsNullOrWhiteSpace(function))
            throw new ArgumentException("Function name should not be null or empty", nameof(function));

        Function = function;
        ReturnType = returnType;
        Arguments = arguments;
        Visibility = visibility;
    }
    
    public Visibility? Visibility { get; }
    
    public string Function { get; }
    
    public FunctionArgument[]? Arguments { get; }

    public ITypeName? ReturnType { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append(Visibility?.Render(true))
            .AppendValidName(Function)
            .Append('(');
        
        if (Arguments is not null)
            foreach (FunctionArgument functionArgument in Arguments)
                functionArgument.RenderTo(builder);

        builder
            .Append(")")
            .Append(Visibility?.Render(false))
            .Append(' ');

        ReturnType?.RenderTo(builder);

        builder.AppendLine();
    }
}