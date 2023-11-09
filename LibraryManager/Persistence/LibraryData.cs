using System.Collections.Generic;

namespace LibraryManager.Persistence
{
    /// <summary>
    /// Egy könyvtár adatait tárolja exportálható formában
    /// </summary>
    public class LibraryData
    {
        public LibraryData()
        {
        }

        public LibraryData(List<BookData> books, List<BookLogItemData> logs)
        {
            this.Books = books;
            this.Logs = logs;
        }

        public List<BookData> Books { get; set; }
        public List<BookLogItemData> Logs { get; set; }
    }
}
