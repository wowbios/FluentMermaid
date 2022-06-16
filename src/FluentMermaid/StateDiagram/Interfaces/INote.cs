using System.Text;
using FluentMermaid.StateDiagram.Enum;

namespace FluentMermaid.StateDiagram.Interfaces;

public interface INote : IRenderTo<StringBuilder>
{
    IState RelatedState { get; }
    
    NoteLocation Location { get; }
    
    string Text { get; }
}