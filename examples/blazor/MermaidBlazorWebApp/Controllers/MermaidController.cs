using FluentMermaid.SequenceDiagram;
using FluentMermaid.SequenceDiagram.Enum;
using FluentMermaid.SequenceDiagram.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MermaidBlazorWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MermaidController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        string diagram = CreateSequenceDiagram();
        Console.WriteLine(diagram);
        return diagram;
    }
    
    private static string CreateSequenceDiagram()
    {
        var builder = new SequenceDiagramBuilder(autoNumber: true);
        
        IMember alice = builder.AddMember("Alice", MemberType.Participant);
        alice.AddLink("Dashboard", new Uri("https://dashboard.contoso.com/alice"));
        alice.AddLink("Wiki", new Uri("https://wiki.contoso.com/alice"));
        
        IMember bob = builder.AddMember("Bob", MemberType.Participant);
        bob.AddLink("Wiki", new Uri("https://wiki.contoso.com/alice"));
        IMember kitchen = builder.AddMember("KitchenService", MemberType.Control);
        IMember pantryDb = builder.AddMember("PantryDb", MemberType.Database);
    
        builder.AltOr(
            "Alice hungry",
            diagram => diagram.Message(alice, bob, "Wait Bob, I need something to eat", MessageType.Solid),
            "Alice not hungry",
            diagram => diagram.Message(alice, bob, "Ok, let`s go", MessageType.Solid));

        builder.Create(pantryDb);
        builder.Box("Aqua", "Dinner prep", diagram =>
        {
            diagram.Critical(
                "Order snack",
                critical => critical.Message(kitchen, pantryDb, "Reserve ingredients", MessageType.SolidArrow),
                ("Kitchen timeout", option => option.Break("Abort dinner", aborted => aborted.NoteOver("Order cancelled", alice, bob))),
                ("Kitchen available", option => option.NoteOver("Snack is ready", alice, bob)));
        });
        builder.Destroy(pantryDb);
    
        builder.NoteOver("Teenagers", alice, bob);

        builder.Messaging(alice, bob)
            .Request("Hi Bob!", MessageType.SolidArrow)
            .Response("Hello Alice!", MessageType.SolidArrow)
            .Request("How are you?", MessageType.SolidArrow)
            .Response("Well ..", MessageType.DottedArrow)
            .Response("Done", MessageType.SolidArrow)
            .End();
        
        return builder.Build();
    }
}