using System.Collections.Generic;
using LibraryManager.Models;

namespace LibraryManager.Memento;

public class BookMemento
{
    public BookMemento(Book book, List<BookLogItem> logItems, string isbn)
    {
        Book = book;
        LogItems = logItems;
        ISBN = isbn;
    }
    public Book Book { get;set; }
    public List<BookLogItem> LogItems { get; set; }
    public string ISBN { get;set; }
}