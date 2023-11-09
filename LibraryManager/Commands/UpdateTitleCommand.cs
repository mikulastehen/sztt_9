namespace LibraryManager.Commands;

class UpdateTitleCommand : BookCommand
{
    private string title;
    public UpdateTitleCommand(LibraryManager library, string isbn, string title) :
        base(library, isbn)
    {
        this.title = title;
    }
    public override void Execute()
    {
        base.Execute();
        library.UpdateTitleOfBook(isbn, title);
    }
}