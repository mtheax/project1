using RefactoredCommandSystem.Models;
namespace RefactoredCommandSystem.Interfaces
{
    /// <summary>
    /// Interface for loading and saving commands from storage.
    /// </summary>
    public interface ICommandLoader
    {
        /// <summary>
        /// Load commands from storage.
        /// </summary>
        /// <returns>List of commands (may be empty).</returns>
        List<Command> LoadCommands();

        /// <summary>
        /// Save a command into storage.
        /// </summary>
        void SaveCommand(Command command);
    }
}