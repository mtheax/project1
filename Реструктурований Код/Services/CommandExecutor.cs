using RefactoredCommandSystem.Models;
namespace RefactoredCommandSystem.Services
{
    /// <summary>
    /// Responsible for executing commands. Does not know about persistence.
    /// </summary>
    public class CommandExecutor
    {
        private List<Command> _commands = new();

        public void SetCommands(IEnumerable<Command> commands)
        {
            _commands = commands.ToList();
        }

        public void ExecuteAll()
        {
            foreach(var c in _commands)
                c.Execute();
        }

        public void ExecuteByName(string name)
        {
            var cmd = _commands.FirstOrDefault(c => c.Name == name);
            if (cmd == null)
            {
                System.Console.WriteLine($"Command with name '{name}' not found.");
                return;
            }
            cmd.Execute();
        }
    }
}