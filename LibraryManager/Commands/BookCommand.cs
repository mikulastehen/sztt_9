using LibraryManager.Memento;

namespace LibraryManager.Commands;

public abstract class BookCommand : ICommand
{
    protected BookMemento memento;
    protected LibraryManager library;
    protected string isbn;
    protected BookCommand(LibraryManager library, string isbn)
    {
        this.library = library;
        this.isbn = isbn;
    }
    public virtual void Execute()
    {
        memento = library.CreateBookMemento(isbn);
    }
    public virtual void UnExecute()
    {
        library.RestoreBookFromMemento(memento);
    }
}