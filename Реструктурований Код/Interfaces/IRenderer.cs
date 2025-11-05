using System.Text;
using RefactoredCommandSystem.Models;

namespace RefactoredCommandSystem.Interfaces
{
    // Strategy: різні рендерери реалізують рендеринг
    public interface IRenderer
    {
        void RenderDocumentStart(Document doc, StringBuilder output);
        void RenderDocumentEnd(Document doc, StringBuilder output);

        void RenderParagraphStart(Paragraph p, StringBuilder output);
        void RenderParagraphEnd(Paragraph p, StringBuilder output);

        void RenderListStart(ListElement list, StringBuilder output);
        void RenderListEnd(ListElement list, StringBuilder output);

        void RenderListItemStart(ListItem item, StringBuilder output);
        void RenderListItemEnd(ListItem item, StringBuilder output);

        void RenderCompositeStart(CompositeElement composite, StringBuilder output);
        void RenderCompositeEnd(CompositeElement composite, StringBuilder output);

        void RenderText(TextRun text, StringBuilder output);
    }
}
