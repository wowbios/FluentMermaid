using System.Text;
using FluentMermaid.Flowchart.Enum;

namespace FluentMermaid.Flowchart.Extensions;

internal static class LinkExtensions
{
    public static void RenderTo(
        this Link link,
        StringBuilder builder,
        int length)
    {
        switch (link)
        {
            case Link.Arrow:
                RenderSingle('-', "->");
                break;
            case Link.Open:
                RenderSingle('-', "--");
                break;
            case Link.Dotted:
                RenderDouble("-.", '.', "-");
                break;
            case Link.Thick:
                RenderSingle('=', "==");
                break;
            case Link.Circle:
                RenderSingle('-', "-o");
                break;
            case Link.Cross:
                RenderSingle('-', "-x");
                break;
            case Link.CircleDouble:
                RenderDouble("o", '-', "-o");
                break;
            case Link.ArrowDouble:
                RenderDouble("<", '-', "->");
                break;
            case Link.CrossDouble:
                RenderDouble("x", '-', "-x");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(link), link, null);
        }
        
        void RenderSingle(char paddingChar, string end)
        {
            for (var i = 0; i < length; i++)
                builder.Append(paddingChar);

            builder.Append(end);
        }

        void RenderDouble(string start, char paddingChar, string end)
        {
            builder.Append(start);
            
            for (var i = 0; i < length; i++)
                builder.Append(paddingChar);

            builder.Append(end);
        }
    }
}