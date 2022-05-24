using FluentMermaid.ClassDiagram.Enums;

namespace FluentMermaid.ClassDiagram.Extensions;

internal static class VisibilityExtensions
{
    private static readonly Array VisibilityValues = Enum.GetValues(typeof(Visibility)); 
    
    public static char Render(this Visibility visibility, bool beforeMemberDefinition)
    {
        Visibility checkType = beforeMemberDefinition
            ? Visibility.Public | Visibility.Private | Visibility.Protected | Visibility.Internal
            : Visibility.Abstract | Visibility.Static;

        foreach (Visibility visibilityValue in VisibilityValues)
        {
            if ((visibility & checkType) != visibilityValue)
                continue;
            
            return visibilityValue switch
            {
                Visibility.Public => '+',
                Visibility.Private => '-',
                Visibility.Protected => '#',
                Visibility.Internal => '~',
                Visibility.Abstract => '*',
                Visibility.Static => '$',
                _ => throw new ArgumentOutOfRangeException(nameof(visibility), visibility, null)
            };
        }

        return ' ';
    }
}