using System.Text;
using FluentMermaid.SequenceDiagram.Enum;
using FluentMermaid.SequenceDiagram.Extensions;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram.Actions;

internal readonly struct Message : IAction
{
    public Message(
        IMember from,
        IMember to,
        string text,
        MessageType type)
    {
        From = from;
        To = to;
        Text = text;
        Type = type;
    }

    public IMember From { get; }

    public IMember To { get; }

    public string Text { get; }

    public MessageType Type { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder
            .Append(From.Id)
            .Append(Type.Render())
            .Append(To.Id)
            .Append(": ")
            .AppendLine(Text);
    }
}