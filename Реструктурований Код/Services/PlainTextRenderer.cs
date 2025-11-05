using System.Text;
using RefactoredCommandSystem.Interfaces;
using RefactoredCommandSystem.Models;
using System.Linq;

namespace RefactoredCommandSystem.Services
{
    public class PlainTextRenderer : IRenderer
    {
        private int _listDepth = 0;
        public void RenderDocumentStart(Document doc, StringBuilder output)
        {
            if (!string.IsNullOrEmpty(doc.Title))
            {
                output.AppendLine(doc.Title);
                output.AppendLine(new string('=', doc.Title.Length));
            }
        }
        public void RenderDocumentEnd(Document doc, StringBuilder output) { output.AppendLine(); }

        public void RenderParagraphStart(Paragraph p, StringBuilder output) { /* no-op */ }
        public void RenderParagraphEnd(Paragraph p, StringBuilder output) { output.AppendLine(); }

        public void RenderListStart(ListElement list, StringBuilder output) 
        { 
            _listDepth++;
        }
        public void RenderListEnd(ListElement list, StringBuilder output) 
        { 
            _listDepth = Math.Max(0, _listDepth - 1);
            output.AppendLine();
        }

        public void RenderListItemStart(ListItem item, StringBuilder output)
        {
            var indent = new string(' ', (_listDepth - 1) * 2);
            output.Append(indent);
            if (item.GetChildren().Any())
            {
                // marker will be appended by text runs; if ordered detection needed, would track index
            }
            output.Append("- ");
        }
        public void RenderListItemEnd(ListItem item, StringBuilder output)
        {
            output.AppendLine();
        }

        public void RenderCompositeStart(CompositeElement composite, StringBuilder output) { /* fallback */ }
        public void RenderCompositeEnd(CompositeElement composite, StringBuilder output) { /* fallback */ }

        public void RenderText(TextRun text, StringBuilder output)
        {
            output.Append(text.Text);
        }
    }
}
