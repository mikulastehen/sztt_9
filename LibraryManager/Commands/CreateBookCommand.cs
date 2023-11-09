using LibraryManager.Memento;

namespace LibraryManager.Commands;

public class CreateBookCommand : BookCommand
{
    protected BookMemento memento;

    protected LibraryManager library;
    protected string isbn;
    public CreateBookCommand(LibraryManager library, string isbn) : base(library, isbn)
    {
    }
    public override void Execute()
    {
        base.Execute();
        library.CreateNewBook(isbn);
    }
    public void UnExecute()
    {
        library.RestoreBookFromMemento(memento);
    }
}
