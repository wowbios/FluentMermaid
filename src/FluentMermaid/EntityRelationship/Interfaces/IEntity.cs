using System.Text;

namespace FluentMermaid.EntityRelationship.Interfaces;

public interface IEntity : IRenderTo<StringBuilder>
{
    string Name { get; }
    IField AddField(string type, string name, string? modifier);
}
