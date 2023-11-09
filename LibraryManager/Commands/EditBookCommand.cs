using System.Collections.Generic;

namespace LibraryManager.Commands;

public class EditBookCommand : BookCommand
{
    private List<ICommand> commands = new List<ICommand>();
    public EditBookCommand(LibraryManager library, string isbn) : base(library, isbn)
    {
    }

    public override void Execute()
    {
        base.Execute();
        foreach (var command in commands)
        {
            command.Execute();
        }
    }

    public void AddCommand(ICommand command)
    {
        commands.Add(command);
    }
    
}