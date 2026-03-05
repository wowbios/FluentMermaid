using System.Text;

namespace FluentMermaid.ClassDiagram.Nodes;

internal class NoteNode : IClassDiagramStatement
{
    private readonly ClassNodeAdvanced? _class;

    public NoteNode(string text, ClassNodeAdvanced? @class = null)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Note text should not be null or empty", nameof(text));
        }

        Text = text;
        _class = @class;
    }

    public string Text { get; }

    public void RenderTo(StringBuilder builder)
    {
        if (_class is null)
        {
            builder
                .Append("note \"")
                .Append(Escape(Text))
                .AppendLine("\"");
            return;
        }

        builder
            .Append("note for ")
            .Append(_class.ClassNameId)
            .Append(" \"")
            .Append(Escape(Text))
            .AppendLine("\"");
    }

    private static string Escape(string text) => text.Replace("\"", "\\\"");
}
