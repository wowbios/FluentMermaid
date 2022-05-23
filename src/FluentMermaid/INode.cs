using System.Text;

namespace FluentMermaid;

public interface INode : IRenderTo<StringBuilder>
{
    string Id { get; }
}