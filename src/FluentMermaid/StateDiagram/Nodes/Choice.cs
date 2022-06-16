using System.Text;
using FluentMermaid.StateDiagram.Interfaces;

namespace FluentMermaid.StateDiagram.Nodes;

internal sealed class Choice : IChoice
{
    public Choice(string id)
    {
        Id = id;
    }

    public string Id { get; }

    public string Description { get; } = string.Empty;

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append("state ")
            .Append(Id)
            .AppendLine(" <<choice>>");
    }
}