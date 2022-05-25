using System.Drawing;
using FluentMermaid.SequenceDiagram.Enum;

namespace FluentMermaid.SequenceDiagram.Interfaces;

public interface ISequenceDiagram
{
    IMember AddMember(string name, MemberType type);

    ISequenceDiagram Message(IMember from, IMember to, string text, MessageType type);

    IMessaging Messaging(IMember from, IMember to);

    ISequenceDiagram Activate(IMember member, Action<ISequenceDiagram> action);

    ISequenceDiagram Loop(string? title, Action<ISequenceDiagram> action);

    ISequenceDiagram AltOr(string? altTitle, Action<ISequenceDiagram> altAction, string? orTitle, Action<ISequenceDiagram> orAction);

    ISequenceDiagram Optional(string? title, Action<ISequenceDiagram> action);

    ISequenceDiagram Note(IMember member, NoteLocation location, string text);

    ISequenceDiagram NoteOver(string text, params IMember[] members);

    ISequenceDiagram Parallel(IEnumerable<(string? title, Action<ISequenceDiagram>? action)> blocks);

    ISequenceDiagram Parallel(params (string? title, Action<ISequenceDiagram>? action)[] blocks);

    ISequenceDiagram Rect(Color color, Action<ISequenceDiagram> action);

    string Build();
}