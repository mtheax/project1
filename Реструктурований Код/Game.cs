using RefactoredCommandSystem.Interfaces;
using RefactoredCommandSystem.Services;

namespace RefactoredCommandSystem
{
    /// <summary>

    /// </summary>
    public class Game
    {
        private readonly ICommandLoader _loader;
        private readonly CommandExecutor _executor;

        public Game(ICommandLoader loader, CommandExecutor executor)
        {
            _loader = loader;
            _executor = executor;
        }

        /// <summary>

        /// </summary>
        public void Start()
        {
            var commands = _loader.LoadCommands();
            _executor.SetCommands(commands);

            System.Console.WriteLine("Loaded commands:");
            foreach(var c in commands)
                System.Console.WriteLine($" - {c.Name} (type: {c.GetType().Name})");

            System.Console.WriteLine();
            System.Console.WriteLine("Executing all commands via executor:"); 
            _executor.ExecuteAll();

            System.Console.WriteLine();
            System.Console.WriteLine("Executing command by name 'print_hello':"); 
            _executor.ExecuteByName("print_hello");
        }
    }
}