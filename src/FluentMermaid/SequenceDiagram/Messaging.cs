using FluentMermaid.SequenceDiagram.Enum;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram;

internal class Messaging : IMessaging
{
    public Messaging(IMember @from, IMember to, ISequenceDiagram diagram)
    {
        From = @from ?? throw new ArgumentNullException(nameof(@from));
        To = to ?? throw new ArgumentNullException(nameof(to));
        Diagram = diagram ?? throw new ArgumentNullException(nameof(diagram));
    }

    public IMember From { get; }
    
    public IMember To { get; }
    public ISequenceDiagram Diagram { get; }

    public IMessaging Request(string text, MessageType type)
    {
        Diagram.Message(From, To, text, type);
        return this;
    }
    
    public IMessaging Response(string text, MessageType type)
    {
        Diagram.Message(To, From, text, type);
        return this;
    }

    public ISequenceDiagram End() => Diagram;
}