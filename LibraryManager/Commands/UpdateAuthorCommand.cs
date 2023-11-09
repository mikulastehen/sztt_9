namespace LibraryManager.Commands;

class UpdateAuthorCommand : BookCommand
{
    private string author;
    public UpdateAuthorCommand(LibraryManager library, string isbn, string author) :
        base(library, isbn)
    {
        this.author = author;
    }
    public override void Execute()
    {
        base.Execute();
        library.UpdateAuthorOfBook(isbn, author);
    }
}