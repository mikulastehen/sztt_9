namespace LibraryManager.Commands;

public interface ICommand
{
    void Execute();
    void UnExecute();
}
