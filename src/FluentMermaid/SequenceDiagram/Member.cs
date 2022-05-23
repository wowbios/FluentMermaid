using System.Text;
using FluentMermaid.SequenceDiagram.Enum;
using FluentMermaid.SequenceDiagram.Extensions;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram;

internal readonly struct Member : IMember
{
    public Member(
        string id,
        string name,
        MemberType type)
    {
        Id = id;
        Name = name;
        Type = type;
    }

    public List<MemberLink> Links { get; } = new();
    
    public string Id { get; }
    
    public string Name { get; }
    
    public MemberType Type { get; }

    public void RenderTo(StringBuilder builder)
    {
        builder.Append(Type.Render())
            .Append(' ')
            .Append(Id)
            .Append(" as ")
            .AppendLine(Name);
    }

    public void AddLink(string label, Uri url)
    {
        if (Type != MemberType.Participant)
            throw new InvalidOperationException("Links can be attached only to participants");
        
        Links.Add(new MemberLink(this, label, url));
    }
}