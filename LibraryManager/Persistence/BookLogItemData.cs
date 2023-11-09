using System;
using LibraryManager.Models;

namespace LibraryManager.Persistence
{
    public class BookLogItemData
    {
        public BookLogItemData()
        {

        }

        public BookLogItemData(BookLogItem logItem, string isbn)
        {
            Date = logItem.Date;
            ISBN = isbn;
            Message = logItem.Message;
        }

        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string ISBN { get; set; }
    }
}
