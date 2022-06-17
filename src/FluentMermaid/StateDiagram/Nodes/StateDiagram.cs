using System.Text;
using FluentMermaid.Enums;
using FluentMermaid.StateDiagram.Enum;
using FluentMermaid.StateDiagram.Extensions;
using FluentMermaid.StateDiagram.Interfaces;

namespace FluentMermaid.StateDiagram.Nodes;

internal abstract class StateDiagram : IStateDiagram
{
    private readonly List<IState> _states = new ();
    private readonly List<ITransition> _transitions = new ();
    private readonly List<INote> _notes = new ();

    public StateDiagram(Orientation orientation)
    {
        Orientation = orientation;
    }

    public Orientation Orientation { get; }

    public IState AddState(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("State description must be set");
        
        State state = new (GenerateStateId(), description);
        _states.Add(state);
        return state;
    }

    public ICompositeState AddCompositeState(string description)
        => AddCompositeState(description, Orientation);

    public ICompositeState AddCompositeState(string description, Orientation orientation)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description must be set");

        description = description.ToValidId();
        
        var composition = new StateDiagramComposite(description, description, orientation);
        _states.Add(composition);
        return composition;
    }

    public IChoice AddChoice()
    {
        var choice = new Choice(GenerateStateId());
        _states.Add(choice);
        return choice;
    }

    public IFork AddFork()
    {
        var fork = new Fork(GenerateStateId());
        _states.Add(fork);
        return fork;
    }

    public INote AddNote(IState state,  NoteLocation location, string text)
    {
        _ = state ?? throw new ArgumentNullException(nameof(state));
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Note text must be set");

        var note = new Note(state, location, text);
        _notes.Add(note);
        return note;
    }

    public ITransition StartTo(IState state)
        => Transition(CornerState.Instance, state, null);

    public ITransition StartTo(IState state, string? description)
        => Transition(CornerState.Instance, state, description);

    public ITransition ToEnd(IState state)
        => Transition(state, CornerState.Instance, null);

    public ITransition ToEnd(IState state, string? description)
        => Transition(state, CornerState.Instance, description);

    public ITransition Transition(IState from, IState to)
        => Transition(from, to, null);

    public ITransition Transition(IState from, IState to, string? description)
    {
        _ = from ?? throw new ArgumentNullException(nameof(from));
        _ = to ?? throw new ArgumentNullException(nameof(to));

        var transition = new Transition(from, to, description);
        _transitions.Add(transition);

        return transition;
    }

    public abstract string Render();
    
    protected void RenderNodes(StringBuilder builder)
    {
        _states.ForEach(state => state.RenderTo(builder));
        _transitions.ForEach(transition => transition.RenderTo(builder));
        _notes.ForEach(note => note.RenderTo(builder));
    }

    protected virtual string GenerateStateId() => "s" + _states.Count;
}