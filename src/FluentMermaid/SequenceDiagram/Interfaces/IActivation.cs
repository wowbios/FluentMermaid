namespace FluentMermaid.SequenceDiagram.Interfaces;

public interface IActivation : IDisposable
{
    IMember Member { get; }
}