using System.Diagnostics;
using FluentMermaid.SequenceDiagram;
using FluentMermaid.SequenceDiagram.Enum;
using FluentMermaid.SequenceDiagram.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MermaidAspNetMvc.Models;

namespace MermaidAspNetMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string sequenceDiagram = CreateSequenceDiagram();
        ViewData["diagram"] = sequenceDiagram;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
