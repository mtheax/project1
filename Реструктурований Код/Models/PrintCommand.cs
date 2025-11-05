namespace RefactoredCommandSystem.Models
{
    /// <summary>
    /// Simple command that prints a message.
    /// </summary>
    public class PrintCommand : Command
    {
        public string Message { get; private set; }

        public PrintCommand(string name, string message) : base(name)
        {
            Message = message;
        }

        public override void Execute()
        {
            System.Console.WriteLine($"[PrintCommand:{Name}] {Message}");
        }
    }
}