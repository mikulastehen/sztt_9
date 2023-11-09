using System;
using LibraryManager.Persistence;

namespace LibraryManager.Models
{

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastModificationDate { get; set; }

        public Book(DateTime lastModificationDate)
        {
            LastModificationDate = lastModificationDate;
        }

        public Book(BookData info)
        {
            Title = info.Title;
            Author = info.Author;
            LastModificationDate = info.LastModificationDate;
        }

        public Book Clone()
        {
            var clone = new Book(this.LastModificationDate);
            clone.Title = Title;
            clone.Author = Author;
            return clone;
        }

    }


}
