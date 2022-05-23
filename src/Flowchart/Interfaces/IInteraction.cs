using FluentMermaid.Flowchart.Enum;

namespace FluentMermaid.Flowchart.Interfaces;

public interface IInteraction : INode
{
    void OnClick(INode node, string functionName, string tooltip);

    void OnClickCall(INode node, string functionCall, string tooltip);

    void Hyperlink(INode node, Uri url, string tooltip, HyperlinkTarget target);
}