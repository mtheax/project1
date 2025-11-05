using System.Text.Json;
using RefactoredCommandSystem.Interfaces;
using RefactoredCommandSystem.Models;

namespace RefactoredCommandSystem.Loaders
{
    /// <summary>
    /// Loads commands from a JSON file. If file is missing, returns a default sample set.
    /// Keeps its responsibility to map persisted data into Command objects.
    /// </summary>
    public class JsonCommandLoader : ICommandLoader
    {
        private readonly string _filePath;

        public JsonCommandLoader(string filePath)
        {
            _filePath = filePath;
        }

        public List<Command> LoadCommands()
        {
            if (!File.Exists(_filePath))
            {
                // Provide default commands to make the demo runnable
                return new List<Command>
                {
                    new PrintCommand("print_hello", "Hello from refactored system!"),
                    new PrintCommand("print_bye", "Goodbye!")
                };
            }

            var json = File.ReadAllText(_filePath);
            var dto = JsonSerializer.Deserialize<List<SimpleCommandDto>>(json) ?? new List<SimpleCommandDto>();
            var result = new List<Command>();
            foreach(var d in dto)
            {
                result.Add(new PrintCommand(d.Name ?? "unnamed", d.Message ?? string.Empty));
            }
            return result;
        }

        public void SaveCommand(Command command)
        {
            var list = new List<SimpleCommandDto>();
            if (File.Exists(_filePath))
            {
                var existing = JsonSerializer.Deserialize<List<SimpleCommandDto>>(File.ReadAllText(_filePath));
                if (existing != null) list.AddRange(existing);
            }

            if (command is PrintCommand pc)
            {
                list.Add(new SimpleCommandDto { Name = pc.Name, Message = pc.Message });
            }

            File.WriteAllText(_filePath, JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true }));
        }

        private class SimpleCommandDto
        {
            public string? Name { get; set; }
            public string? Message { get; set; }
        }
    }
}