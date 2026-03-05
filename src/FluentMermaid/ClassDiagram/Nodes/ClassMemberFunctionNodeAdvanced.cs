using System.Text;
using FluentMermaid.ClassDiagram.Enums;
using FluentMermaid.ClassDiagram.Extensions;
using FluentMermaid.ClassDiagram.Interfaces.ClassMembers;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class ClassMemberFunctionNodeAdvanced : IClassMemberFunction
{
    public ClassMemberFunctionNodeAdvanced(
        string function,
        FunctionArgument[]? arguments,
        ITypeName? returnType,
        Visibility? visibility)
    {
        if (string.IsNullOrWhiteSpace(function))
        {
            throw new ArgumentException("Function name should not be null or empty", nameof(function));
        }

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
        char prefix = Visibility.HasValue ? Visibility.Value.RenderPrefix() : ' ';
        char suffix = Visibility.HasValue ? Visibility.Value.RenderSuffix() : ' ';

        if (prefix != ' ')
        {
            builder.Append(prefix);
        }

        builder
            .AppendValidName(Function)
            .Append('(');

        if (Arguments is { Length: > 0 })
        {
            for (var i = 0; i < Arguments.Length; i++)
            {
                if (i > 0)
                {
                    builder.Append(", ");
                }

                Arguments[i].RenderTo(builder);
            }
        }

        builder.Append(')');

        if (ReturnType is not null)
        {
            builder.Append(' ');
            ReturnType.RenderTo(builder);
        }

        if (suffix != ' ')
        {
            builder.Append(suffix);
        }

        builder.AppendLine();
    }
}
