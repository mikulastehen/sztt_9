namespace LibraryManager.Commands;

public class DeleteBookCommand : BookCommand
{
    public DeleteBookCommand(LibraryManager library, string isbn) : base(library, isbn)
    {
    }
    public override void Execute()
    {
        base.Execute();
        library.DeleteBook(isbn);
    }
}