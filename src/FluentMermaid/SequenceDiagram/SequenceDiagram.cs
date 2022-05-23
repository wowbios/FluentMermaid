﻿using System.Drawing;
using System.Text;
using FluentMermaid.SequenceDiagram.Actions;
using FluentMermaid.SequenceDiagram.Enum;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.SequenceDiagram;

public sealed class SequenceDiagram : ISequenceDiagram
{
    private readonly bool _autoNumber;
    private readonly List<Member> _members = new();
    private readonly List<MemberLink> _memberLinks = new();
    private readonly List<IAction> _actions = new();

    public SequenceDiagram(bool autoNumber = false)
    {
        _autoNumber = autoNumber;
    }
    
    public IMember AddMember(string name, MemberType type)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name should not be null or empty", nameof(name));
        
        var member = new Member(CreateMemberId(), name, type);
        _members.Add(member);
        return member;
    }

    public void Message(IMember from, IMember to, string text, MessageType type)
    {
        _ = @from ?? throw new ArgumentNullException(nameof(@from));
        _ = to ?? throw new ArgumentNullException(nameof(to));

        var message = new Message(from, to, text, type);
        _actions.Add(message);
    }

    public void Activate(IMember member, Action<ISequenceDiagram> action)
    {
        _ = member ?? throw new ArgumentNullException(nameof(member));
        _ = action ?? throw new ArgumentNullException(nameof(action));

        _actions.Add(new Activate(member));
        action(this);
        _actions.Add(new Deactivate(member));
    }

    public void Loop(string? title, Action<ISequenceDiagram> action)
    {
         _ = action ?? throw new ArgumentNullException(nameof(action));

         _actions.Add(new StartLoop(title));
        action(this);
        _actions.Add(new End());
    }

    public void AltOr(string? altTitle, Action<ISequenceDiagram> altAction, string? orTitle, Action<ISequenceDiagram> orAction)
    {
        _ = altAction ?? throw new ArgumentNullException(nameof(altAction));
        _ = orAction ?? throw new ArgumentNullException(nameof(orAction));

        _actions.Add(new AltStart(altTitle));
        altAction(this);
        _actions.Add(new OrStart(orTitle));
        orAction(this);
        _actions.Add(new End());
    }

    public void Optional(string? title, Action<ISequenceDiagram> action)
    {
        _ = action ?? throw new ArgumentNullException(nameof(action));
        
        _actions.Add(new OptStart(title));
        action(this);
        _actions.Add(new End());
    }

    public void Note(IMember member, NoteLocation location, string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Text should not be null or empty", nameof(text));

        _actions.Add(new Note(member, location, text));
    }

    public void NoteOver(string text, params IMember[] members)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Text should not be null or empty", nameof(text));
        
        _actions.Add(new NoteOver(members, text));
    }

    public void Parallel(IEnumerable<(string? title, Action<ISequenceDiagram>? action)> blocks)
    {
        _ = blocks ?? throw new ArgumentNullException(nameof(blocks));

        bool isFirst = true;
        foreach ((string? title, Action<ISequenceDiagram>? action) in blocks)
        {
            _actions.Add(new ParallelStart(title, isFirst));
            
            action?.Invoke(this);

            isFirst = false;
        }
        _actions.Add(new End());
    }

    public void Parallel(params (string? title, Action<ISequenceDiagram>? action)[] blocks)
        => Parallel(blocks.AsEnumerable());

    public void Rect(Color color, Action<ISequenceDiagram> action)
    {
        _ = action ?? throw new ArgumentNullException(nameof(action));

        _actions.Add(new Rect(color));
        action(this);
        _actions.Add(new End());
    }

    public string Render()
    {
        StringBuilder builder = new();
        builder.AppendLine("sequenceDiagram");
        if (_autoNumber)
            builder.AppendLine("autonumber");

        foreach (Member member in _members)
            member.RenderTo(builder);

        foreach (Member member in _members)
        {
            if (member.Links.Count <= 0) continue;

            builder
                .Append("links ")
                .Append(member.Id)
                .Append(": {");

            bool first = true;
            foreach (MemberLink memberLink in member.Links)
            {
                if (!first)
                    builder.Append(", ");

                memberLink.RenderTo(builder);
                first = false;
            }
            builder.AppendLine("}");
        }

        _actions.ForEach(a => a.RenderTo(builder));

        return builder.ToString();
    }

    private string CreateMemberId() => "member" + _members.Count;
}