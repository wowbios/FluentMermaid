using System.Drawing;
using FluentMermaid.SequenceDiagram.Enum;

namespace FluentMermaid.SequenceDiagram.Interfaces;

public interface ISequenceDiagram
{
    IMember AddMember(string name, MemberType type);

    void Message(IMember from, IMember to, string text, MessageType type);

    void Activate(IMember member, Action<ISequenceDiagram> action);

    void Loop(string? title, Action<ISequenceDiagram> action);

    void AltOr(string? altTitle, Action<ISequenceDiagram> altAction, string? orTitle, Action<ISequenceDiagram> orAction);

    void Optional(string? title, Action<ISequenceDiagram> action);

    void Note(IMember member, NoteLocation location, string text);

    void NoteOver(string text, params IMember[] members);

    void Parallel(IEnumerable<(string? title, Action<ISequenceDiagram>? action)> blocks);

    void Parallel(params (string? title, Action<ISequenceDiagram>? action)[] blocks);

    void Rect(Color color, Action<ISequenceDiagram> action);

    string Render();
}