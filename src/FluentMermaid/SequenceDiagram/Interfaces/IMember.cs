using FluentMermaid.SequenceDiagram.Enum;

namespace FluentMermaid.SequenceDiagram.Interfaces;

public interface IMember : INode
{
    string Name { get; }
    
    MemberType Type { get; }

    void AddLink(string label, Uri url);
}