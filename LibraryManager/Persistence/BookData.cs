using System;
using LibraryManager.Models;

namespace LibraryManager.Persistence
{
    public class BookData
    {
        public BookData()
        {

        }

        public BookData(Book book, string isbn)
        {
            ISBN = isbn;
            Title = book.Title;
            Author = book.Author;
            LastModificationDate = book.LastModificationDate;

        }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastModificationDate { get; set; }
    }
}
