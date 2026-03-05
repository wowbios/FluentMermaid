using FluentMermaid.ClassDiagram;
using FluentMermaid.ClassDiagram.Enums;
using FluentMermaid.ClassDiagram.Nodes;
using FluentMermaid.Enums;
using ClassDiagramBuilder = FluentMermaid.ClassDiagram.ClassDiagram;

namespace FluentMermaid.Tests;

public class ClassDiagramRenderingTests
{
    [Fact]
    public void LegacyApi_SmokeRender_Works()
    {
        var diagram = ClassDiagramBuilder.Create(Orientation.LeftToRight);
        var person = diagram.AddClass(new TypeName("Person", null), null, null);
        person.AddProperty("name", new TypeName("string", null), Visibility.Public);
        person.AddFunction("GetName", new TypeName("string", null), Visibility.Public);

        string rendered = Normalize(diagram.Render());

        Assert.Contains("classDiagram", rendered);
        Assert.Contains("direction LR", rendered);
        Assert.Contains("class Person {", rendered);
    }

    [Fact]
    public void AdvancedApi_RendersNamespaceNoteAndClassDef()
    {
        var diagram = ClassDiagramBuilder.CreateAdvanced(Orientation.TopToBottom);
        var invoice = diagram.AddClassInNamespace("Billing", new TypeName("Invoice", null), "entity", "domain");
        invoice.AddProperty("number", new TypeName("string", null), Visibility.Public);

        diagram.AddNote("General note");
        diagram.AddNoteFor(invoice, "Invoice note");
        diagram.AddClassDef("domain", "fill:#f9f,stroke:#333;");
        diagram.AddCssClass("Invoice", "domain");

        string rendered = Normalize(diagram.Render());

        Assert.Contains("namespace Billing {", rendered);
        Assert.Contains("class Invoice {", rendered);
        Assert.Contains("note \"General note\"", rendered);
        Assert.Contains("note for Invoice \"Invoice note\"", rendered);
        Assert.Contains("classDef domain fill:#f9f,stroke:#333;", rendered);
        Assert.Contains("cssClass \"Invoice\" domain", rendered);
    }

    [Fact]
    public void AdvancedApi_RendersFixedVisibilityArgumentsAndIds()
    {
        var diagram = ClassDiagramBuilder.CreateAdvanced(Orientation.LeftToRight);
        var service = diagram.AddClass(new TypeName("User.Service", null), null, null);
        service.AddFunction(
            "Process",
            new TypeName("string", null),
            Visibility.Abstract,
            new FunctionArgument("id", new TypeName("int", null)),
            new FunctionArgument("name", new TypeName("string", null)));
        service.AddFunction("Get", null, Visibility.Public);
        service.AddProperty("Version", new TypeName("string", null), Visibility.Static);
        service.SetCallback("onClick", "Open");
        service.SetLink(new Uri("https://example.com"), "Go");

        string rendered = Normalize(diagram.Render());

        Assert.Contains("Process(int id, string name) string*", rendered);
        Assert.Contains("+Get()", rendered);
        Assert.Contains("string Version$", rendered);
        Assert.Contains("callback User_Service \"onClick\" \"Open\"", rendered);
        Assert.Contains("link User_Service \"https://example.com/\" \"Go\"", rendered);
    }

    private static string Normalize(string input) => input.Replace("\r\n", "\n");
}
