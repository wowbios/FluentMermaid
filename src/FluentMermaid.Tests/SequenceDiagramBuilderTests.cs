using System;
using FluentMermaid.SequenceDiagram;
using FluentMermaid.SequenceDiagram.Enum;
using Xunit;

namespace FluentMermaid.Tests;

public class SequenceDiagramBuilderTests
{
    [Fact]
    public void AddMember_ShouldThrow_WhenNameIsNullOrWhitespace()
    {
        var builder = new SequenceDiagramBuilder();

        Assert.Throws<ArgumentException>(() => builder.AddMember(null!, MemberType.Participant));
        Assert.Throws<ArgumentException>(() => builder.AddMember(string.Empty, MemberType.Participant));
        Assert.Throws<ArgumentException>(() => builder.AddMember(" ", MemberType.Participant));
    }

    [Fact]
    public void Build_ShouldReturnExpectedDiagram()
    {
        var builder = new SequenceDiagramBuilder(autoNumber: true);
        var alice = builder.AddMember("Alice", MemberType.Participant);
        var bob = builder.AddMember("Bob", MemberType.Actor);

        builder.Message(alice, bob, "Hi", MessageType.SolidArrow);

        var newline = Environment.NewLine;
        var expected =
            "sequenceDiagram" + newline +
            "autonumber" + newline +
            "participant member0 as Alice" + newline +
            "actor member1 as Bob" + newline +
            "member0->>member1: Hi" + newline;

        Assert.Equal(expected, builder.Build());
    }
}
