using System.Text;
using RefactoredCommandSystem.Interfaces;
using RefactoredCommandSystem.Models;

namespace RefactoredCommandSystem.Services
{
    // Уніфікований API: створення документу, побудова, вибір рендерера, отримання рядка
    public class StructuredTextBuilder
    {
        private readonly Document _document;
        private IRenderer _renderer;

        public StructuredTextBuilder(string title = null)
        {
            _document = new Document(title);
            // дефолтний рендерер
            _renderer = new PlainTextRenderer();
        }

        public Document Document => _document;

        public StructuredTextBuilder UseRenderer(IRenderer renderer)
        {
            _renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
            return this;
        }

        public StructuredTextBuilder AddParagraph(params string[] runs)
        {
            var p = new Paragraph();
            foreach (var r in runs) p.AddChild(new TextRun(r));
            _document.AddChild(p);
            return this;
        }

        public StructuredTextBuilder AddList(bool ordered, params (string[] itemRuns)[] items)
        {
            var list = new ListElement(ordered);
            foreach (var itemRuns in items)
            {
                var li = new ListItem();
                foreach (var run in itemRuns) li.AddChild(new TextRun(run));
                list.AddChild(li);
            }
            _document.AddChild(list);
            return this;
        }

        public string Build()
        {
            var sb = new StringBuilder();
            _document.Accept(_renderer, sb);
            return sb.ToString();
        }
    }
}
