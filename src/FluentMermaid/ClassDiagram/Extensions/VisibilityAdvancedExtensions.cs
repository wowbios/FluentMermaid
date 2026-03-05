using FluentMermaid.ClassDiagram.Enums;

namespace FluentMermaid.ClassDiagram.Extensions;

internal static class VisibilityAdvancedExtensions
{
    public static char RenderPrefix(this Visibility visibility)
        => visibility switch
        {
            Visibility.Public => '+',
            Visibility.Private => '-',
            Visibility.Protected => '#',
            Visibility.Internal => '~',
            _ => ' '
        };

    public static char RenderSuffix(this Visibility visibility)
        => visibility switch
        {
            Visibility.Abstract => '*',
            Visibility.Static => '$',
            _ => ' '
        };
}
