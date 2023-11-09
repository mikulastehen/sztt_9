using System;
using LibraryManager.Persistence;

namespace LibraryManager.Models
{
    public class BookLogItem
    {
        public readonly DateTime Date;
        public readonly string Message;

        public BookLogItem(DateTime date, string message)
        {
            Date = date;
            Message = message;
        }

        public BookLogItem(BookLogItemData info)
        {
            Date = info.Date;
            Message = info.Message;
        }
    }



}
