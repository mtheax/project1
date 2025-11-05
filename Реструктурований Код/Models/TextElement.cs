using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoredCommandSystem.Models
{
    // Абстракція — базовий елемент тексту
    public abstract class TextElement
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        // Композит підтримує дітей — реалізація може ігнорувати.
        public virtual void AddChild(TextElement child) => throw new NotSupportedException();
        public virtual void RemoveChild(TextElement child) => throw new NotSupportedException();
        public virtual IReadOnlyList<TextElement> GetChildren() => Array.Empty<TextElement>();

        // Поліморфний метод для відвідування/рендерингу
        public abstract void Accept(IRenderer renderer, StringBuilder output);
    }
}
