using System.Text;
using FluentMermaid.StateDiagram.Interfaces;

namespace FluentMermaid.StateDiagram.Nodes;

internal sealed class CornerState : IState
{
    public static CornerState Instance { get; } = new ();

    public void RenderTo(StringBuilder builder)
    {
    }

    public string Id { get; } = "[*]";
    public string Description { get; } = string.Empty;
}