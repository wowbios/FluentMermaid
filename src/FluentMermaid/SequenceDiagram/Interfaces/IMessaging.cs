using FluentMermaid.SequenceDiagram.Enum;

namespace FluentMermaid.SequenceDiagram.Interfaces;

public interface IMessaging
{
    IMember From { get; }
    
    IMember To { get; }

    IMessaging Request(string text, MessageType type);

    IMessaging Response(string text, MessageType type);

    ISequenceDiagram End();
}