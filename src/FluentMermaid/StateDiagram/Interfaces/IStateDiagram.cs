using FluentMermaid.Enums;
using FluentMermaid.StateDiagram.Enum;

namespace FluentMermaid.StateDiagram.Interfaces;

public interface IStateDiagram
{
    Orientation Orientation { get; }
    
    IState AddState(string description);

    ICompositeState AddCompositeState(string description);

    ICompositeState AddCompositeState(string description, Orientation orientation);

    IChoice AddChoice();

    IFork AddFork();

    INote AddNote(IState state, NoteLocation location, string text);

    ITransition StartTo(IState state);

    ITransition StartTo(IState state, string? description);

    ITransition ToEnd(IState state);
    
    ITransition ToEnd(IState state, string? description);

    ITransition Transition(IState from, IState to);

    ITransition Transition(IState from, IState to, string? description);

    string Render();
}