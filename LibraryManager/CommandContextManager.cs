using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    /// <summary>
    /// Magasabb szintű szolgáltatás a könyvtáradatok kezelésére.
    /// A kiinduló megoldásban egy LibraryManager-t csomagol be, annak továbbítja 
    /// a kéréseket.
    /// </summary>
    public class CommandContextManager
    {
        private readonly LibraryManager libraryManager = new LibraryManager();

        #region utasítások
        public void Save(string path)
        {
            libraryManager.Save(path);
        }

        public void Load(string path)
        {
            libraryManager.Load(path);
        }

        public void CreateNewBook(string isbn)
        {
            if (!libraryManager.ValidateISBN(isbn))
            {
                Console.WriteLine("Hibás ISBN szám");
                return;
            }

            if (libraryManager.IsISBNInLibrary(isbn))
            {
                Console.WriteLine("Ilyen ISBN számú könyv már van az adatbázisban");
                return;
            }

            libraryManager.CreateNewBook(isbn);
        }

        public void DeleteBook(string isbn)
        {
            if (!libraryManager.IsISBNInLibrary(isbn))
            {
                Console.WriteLine("Nincs ilyen ISBN számú könyv az adatbázisban");
                return;
            }

            libraryManager.DeleteBook(isbn);
        }

        public void UpdateTitleOfBook(string isbn, string title)
        {
            if (!libraryManager.IsISBNInLibrary(isbn))
            {
                Console.WriteLine("Ilyen ISBN számú könyv nincs az adatbázisban");
                return;
            }
            
            libraryManager.UpdateTitleOfBook(isbn, title);
        }

        public void UpdateAuthorOfBook(string isbn, string author)
        {
            if (!libraryManager.IsISBNInLibrary(isbn))
            {
                Console.WriteLine("Ilyen ISBN számú könyv nincs az adatbázisban");
                return;
            }

            libraryManager.UpdateAuthorOfBook(isbn, author);
        }

        public void ShowLogs()
        {

            libraryManager.ShowLogs();
        }

        public void Undo()
        {
            //TODO
        }

        public void PrintBooks()
        {
            libraryManager.PrintBooks();
        }

        #endregion

        #region Összetett szerkesztés utasítások

        public void StartEditingBook(string isbn)
        {
            //TODO
        }

        public void UpdateEditedBookTitle(string title)
        {
            //TODO
        }

        public void UpdateEditedBookAuthor(string author)
        {
            //TODO
        }

        public void FinishEditingBook()
        {
            //TODO
        }

        #endregion
    }
}
