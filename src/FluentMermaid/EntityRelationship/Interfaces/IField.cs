using System.Text;

namespace FluentMermaid.EntityRelationship.Interfaces;

public interface IField : IRenderTo<StringBuilder>
{
    string Type { get; }
    string Name { get; }
    string? Modifier { get; }
}
