using System.Drawing;
using FluentMermaid.SequenceDiagram;
using FluentMermaid.SequenceDiagram.Enum;
using FluentMermaid.SequenceDiagram.Interfaces;

namespace FluentMermaid.Tests;

public class SequenceDiagramRenderingTests
{
    [Fact]
    public void BackwardCompatibleApi_RendersCoreSyntax()
    {
        var builder = new SequenceDiagramBuilder(autoNumber: true);

        IMember alice = builder.AddMember("Alice", MemberType.Participant);
        IMember bob = builder.AddMember("Bob", MemberType.Participant);

        builder.AltOr(
            "Alice hungry",
            d => d.Message(alice, bob, "Wait Bob, I need something to eat", MessageType.Solid),
            "Alice not hungry",
            d => d.Message(alice, bob, "Ok, let`s go", MessageType.Solid));

        builder.NoteOver("Teenagers", alice, bob);
        builder.Messaging(alice, bob)
            .Request("Hi Bob!", MessageType.SolidArrow)
            .Response("Hello Alice!", MessageType.SolidArrow)
            .End();

        string rendered = Normalize(builder.Build());

        Assert.Contains("sequenceDiagram", rendered);
        Assert.Contains("autonumber", rendered);
        Assert.Contains("participant member0 as Alice", rendered);
        Assert.Contains("participant member1 as Bob", rendered);
        Assert.Contains("alt Alice hungry", rendered);
        Assert.Contains("else Alice not hungry", rendered);
        Assert.Contains("member0->member1: Wait Bob, I need something to eat", rendered);
        Assert.Contains("Note over member0,member1:Teenagers", rendered);
        Assert.Contains("member0->>member1: Hi Bob!", rendered);
        Assert.Contains("member1->>member0: Hello Alice!", rendered);
    }

    [Theory]
    [InlineData(MessageType.SolidBidirectionalArrow, "<<->>")]
    [InlineData(MessageType.DottedBidirectionalArrow, "<<-->>")]
    [InlineData(MessageType.SolidTopHalfArrow, "-|\\")]
    [InlineData(MessageType.DottedTopHalfArrow, "--|\\")]
    [InlineData(MessageType.SolidBottomHalfArrow, "-|/")]
    [InlineData(MessageType.DottedBottomHalfArrow, "--|/")]
    [InlineData(MessageType.SolidReverseTopHalfArrow, "/|-")]
    [InlineData(MessageType.DottedReverseTopHalfArrow, "/|--")]
    [InlineData(MessageType.SolidReverseBottomHalfArrow, "\\|-")]
    [InlineData(MessageType.DottedReverseBottomHalfArrow, "\\|--")]
    [InlineData(MessageType.SolidTopStickHalfArrow, "-\\\\")]
    [InlineData(MessageType.DottedTopStickHalfArrow, "--\\\\")]
    [InlineData(MessageType.SolidBottomStickHalfArrow, "-//")]
    [InlineData(MessageType.DottedBottomStickHalfArrow, "--//")]
    [InlineData(MessageType.SolidReverseTopStickHalfArrow, "//-")]
    [InlineData(MessageType.DottedReverseTopStickHalfArrow, "//--")]
    [InlineData(MessageType.SolidReverseBottomStickHalfArrow, "\\\\-")]
    [InlineData(MessageType.DottedReverseBottomStickHalfArrow, "\\\\--")]
    public void MessageTypes_V11Arrows_AreRendered(MessageType messageType, string arrowToken)
    {
        var builder = new SequenceDiagramBuilder();
        IMember a = builder.AddMember("A", MemberType.Participant);
        IMember b = builder.AddMember("B", MemberType.Participant);

        builder.Message(a, b, "m", messageType);

        string rendered = Normalize(builder.Build());
        Assert.Contains($"member0{arrowToken}member1: m", rendered);
    }

    [Fact]
    public void MemberTypes_V11Participants_AreRendered()
    {
        var builder = new SequenceDiagramBuilder();
        builder.AddMember("P", MemberType.Participant);
        builder.AddMember("A", MemberType.Actor);
        builder.AddMember("Boundary", MemberType.Boundary);
        builder.AddMember("Control", MemberType.Control);
        builder.AddMember("Entity", MemberType.Entity);
        builder.AddMember("Database", MemberType.Database);
        builder.AddMember("Collections", MemberType.Collections);
        builder.AddMember("Queue", MemberType.Queue);

        string rendered = Normalize(builder.Build());

        Assert.Contains("participant member0 as P", rendered);
        Assert.Contains("actor member1 as A", rendered);
        Assert.Contains("boundary member2 as Boundary", rendered);
        Assert.Contains("control member3 as Control", rendered);
        Assert.Contains("entity member4 as Entity", rendered);
        Assert.Contains("database member5 as Database", rendered);
        Assert.Contains("collections member6 as Collections", rendered);
        Assert.Contains("queue member7 as Queue", rendered);
    }

    [Fact]
    public void AdvancedBlocks_AreRendered()
    {
        var builder = new SequenceDiagramBuilder();
        IMember service = builder.AddMember("Service", MemberType.Participant);
        IMember db = builder.AddMember("Db", MemberType.Database);

        builder.Create(db);
        builder.Box("Aqua", "Persistence", d =>
        {
            d.Critical("Must save", c => c.Message(service, db, "Save", MessageType.SolidArrow),
                ("Db timeout", o => o.Break("Abort", b => b.Note(service, NoteLocation.RightOf, "Cancelled"))),
                ("Ok", o => o.NoteOver("Committed", service, db)));
        });
        builder.Destroy(db);

        string rendered = Normalize(builder.Build());

        Assert.Contains("create participant member1", rendered);
        Assert.Contains("box Aqua Persistence", rendered);
        Assert.Contains("critical Must save", rendered);
        Assert.Contains("option Db timeout", rendered);
        Assert.Contains("break Abort", rendered);
        Assert.Contains("option Ok", rendered);
        Assert.Contains("destroy member1", rendered);
    }

    [Fact]
    public void Alt_WithMultipleElseBlocks_IsRendered()
    {
        var builder = new SequenceDiagramBuilder();
        IMember a = builder.AddMember("A", MemberType.Participant);
        IMember b = builder.AddMember("B", MemberType.Participant);

        builder.Alt(
            "path1",
            d => d.Message(a, b, "M1", MessageType.Solid),
            ("path2", d => d.Message(a, b, "M2", MessageType.Solid)),
            ("path3", d => d.Message(a, b, "M3", MessageType.Solid)));

        string rendered = Normalize(builder.Build());

        Assert.Contains("alt path1", rendered);
        Assert.Contains("else path2", rendered);
        Assert.Contains("else path3", rendered);
        Assert.Contains("member0->member1: M3", rendered);
    }

    [Fact]
    public void MultilineText_IsRenderedWithBrTag()
    {
        var builder = new SequenceDiagramBuilder();
        IMember a = builder.AddMember("A", MemberType.Participant);
        IMember b = builder.AddMember("B", MemberType.Participant);

        builder.Message(a, b, "line1\nline2", MessageType.SolidArrow);
        builder.Note(a, NoteLocation.RightOf, "note1\r\nnote2");

        string rendered = Normalize(builder.Build());

        Assert.Contains("member0->>member1: line1<br/>line2", rendered);
        Assert.Contains("Note right of member0:note1<br/>note2", rendered);
    }

    [Fact]
    public void Parallel_WithoutBlocks_ThrowsArgumentException()
    {
        var builder = new SequenceDiagramBuilder();

        Assert.Throws<ArgumentException>(() => builder.Parallel(Array.Empty<(string? title, Action<ISequenceDiagram>? action)>()));
    }

    private static string Normalize(string input) => input.Replace("\r\n", "\n");
}
