using System.Text;

namespace RefactoredCommandSystem.Models
{
    public class TextRun : TextElement
    {
        public string Text { get; }
        public TextRun(string text) => Text = text;

        public override void Accept(IRenderer renderer, StringBuilder output)
        {
            renderer.RenderText(this, output);
        }
    }

    public class Paragraph : CompositeElement
    {
        public override void Accept(IRenderer renderer, StringBuilder output)
        {
            renderer.RenderParagraphStart(this, output);
            base.Accept(renderer, output);
            renderer.RenderParagraphEnd(this, output);
        }
    }

    public class Document : CompositeElement
    {
        public string Title { get; set; }
        public Document(string title = null) => Title = title;
        public override void Accept(IRenderer renderer, StringBuilder output)
        {
            renderer.RenderDocumentStart(this, output);
            base.Accept(renderer, output);
            renderer.RenderDocumentEnd(this, output);
        }
    }

    public class ListElement : CompositeElement
    {
        public bool Ordered { get; }
        public ListElement(bool ordered = false) => Ordered = ordered;

        public override void Accept(IRenderer renderer, StringBuilder output)
        {
            renderer.RenderListStart(this, output);
            base.Accept(renderer, output);
            renderer.RenderListEnd(this, output);
        }
    }

    public class ListItem : CompositeElement
    {
        public override void Accept(IRenderer renderer, StringBuilder output)
        {
            renderer.RenderListItemStart(this, output);
            base.Accept(renderer, output);
            renderer.RenderListItemEnd(this, output);
        }
    }
}
