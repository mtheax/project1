using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoredCommandSystem.Models
{
    public class CompositeElement : TextElement
    {
        protected readonly List<TextElement> _children = new List<TextElement>();

        public override void AddChild(TextElement child) => _children.Add(child);
        public override void RemoveChild(TextElement child) => _children.Remove(child);
        public override IReadOnlyList<TextElement> GetChildren() => _children.AsReadOnly();

        public override void Accept(IRenderer renderer, StringBuilder output)
        {
            renderer.RenderCompositeStart(this, output);
            foreach (var c in _children) c.Accept(renderer, output);
            renderer.RenderCompositeEnd(this, output);
        }
    }
}
