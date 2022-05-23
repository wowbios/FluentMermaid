using System.Text;

namespace FluentMermaid.Extensions;

internal static class StringBuilderExtensions
{
    private static readonly Dictionary<char, string> EscapeCharacters = new()
    {
        { '\"', "#quot;" },
        { '#', "#35;" },
        { '<', "#lt;" },
        { '>', "#gt;" }
    };

    public static StringBuilder AppendJoin(this StringBuilder builder, char separator, IEnumerable<string>? values)
    {
        if (values is null)
            return builder;
        
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
    
    internal static StringBuilder WriteEscaped(this StringBuilder builder, IEnumerable<char>? text)
    {
        if (text is null)
            return builder;

        var isUnicodeExpectation = false;
        var unicodeBuffer = new List<char>(0);
        foreach (char ch in text)
        {
            if (isUnicodeExpectation)
            {
                unicodeBuffer.Add(ch);

                if (char.IsDigit(ch)) // unicode number
                    continue;

                isUnicodeExpectation = false;
                if (ch == ';') // unicode symbol end
                {
                    unicodeBuffer.ForEach(bufChar => builder.Append(bufChar));
                }
                else // unexpected unicode symbol end. Act as usual
                {
                    unicodeBuffer.ForEach(bufChar => builder.WriteWithReplacement(bufChar));
                }
                
                unicodeBuffer.Clear();
                continue;
            }
            
            if (ch == '#')
            {
                isUnicodeExpectation = true;
                unicodeBuffer = new List<char>() { ch };
                continue;
            }

            builder.WriteWithReplacement(ch);
        }

        return builder;
    }

    private static StringBuilder WriteWithReplacement(this StringBuilder builder, char ch)
    {
        if (EscapeCharacters.TryGetValue(ch, out string? replacement))
            builder.Append(replacement);
        else
            builder.Append(ch);

        return builder;
    }
}