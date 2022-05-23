using System.Text;

namespace FluentMermaid.Extensions;

public static class StringBuilderExtensions
{
    public static StringBuilder AppendJoin(this StringBuilder builder, char separator, IEnumerable<string> values)
    {
        bool first = true;
        foreach (string value in values)
        {
            if (!first)
                builder.Append(separator);

            builder.Append(value);
            first = false;
        }
        
        return builder;
    }
}