using System.Text;
using FluentMermaid.Flowchart.Enum;
using FluentMermaid.Flowchart.Extensions;
using FluentMermaid.Flowchart.Interfaces;

namespace FluentMermaid.Flowchart.Nodes.Interaction;

internal record InteractionNode : IInteraction
{
    private readonly List<Callback> _callbacks = new();
    private readonly List<CallbackCall> _callbackCalls = new();
    private readonly List<Hyperlink> _hyperlinks = new();

    public InteractionNode(string id)
    {
        Id = id;
    }

    public string Id { get; }

    public void RenderTo(StringBuilder builder)
    {
        _callbacks.ForEach(cb => cb.RenderTo(builder));
        _callbackCalls.ForEach(cbc => cbc.RenderTo(builder));
        _hyperlinks.ForEach(hl => hl.RenderTo(builder));
    }

    public void OnClick(INode node, string functionName, string tooltip)
        => _callbacks.Add(new Callback(node.Id, functionName, tooltip));

    public void OnClickCall(INode node, string functionCall, string tooltip)
        => _callbackCalls.Add(new CallbackCall(node.Id, functionCall, tooltip));

    public void Hyperlink(INode node, Uri url, string tooltip, HyperlinkTarget target)
        => _hyperlinks.Add(new Hyperlink(node.Id, url, tooltip, target));

    public void Deconstruct(out string Id)
    {
        Id = this.Id;
    }
}