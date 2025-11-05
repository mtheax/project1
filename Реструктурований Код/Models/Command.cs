namespace RefactoredCommandSystem.Models
{
    /// <summary>
    /// Base class for all commands.
    /// Contains Name and Execute contract.
    /// </summary>
    public abstract class Command
    {
        public string Name { get; protected set; }

        protected Command(string name)
        {
            Name = name;
        }

        public abstract void Execute();
    }
}