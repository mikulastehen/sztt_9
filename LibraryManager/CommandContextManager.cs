using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Commands;

namespace LibraryManager
{
    /// <summary>
    /// Magasabb szintű szolgáltatás a könyvtáradatok kezelésére.
    /// A kiinduló megoldásban egy LibraryManager-t csomagol be, annak továbbítja 
    /// a kéréseket.
    /// </summary>
    public class CommandContextManager
    {
        private readonly CommandProcessor commandProcessor = new CommandProcessor();

        private readonly LibraryManager libraryManager = new LibraryManager();

        private EditBookCommand editBookCommand = null;
        
        #region utasítások
        public void Save(string path)
        {
            if (!checkIfInNormalMode()) return;

            libraryManager.Save(path);
        }
        
        private bool checkIfInNormalMode()
        {
            if (IsInEditBookMode)
            {
                Console.WriteLine("Előbb fejezd be az aktuális könyv szerkesztését");
                return false;
            }
            return true;
        }


        public void Load(string path)
        {
            if (!checkIfInNormalMode()) return;

            libraryManager.Load(path);
        }

        public void CreateNewBook(string isbn)
        {
            if (!checkIfInNormalMode()) return;

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

            //libraryManager.CreateNewBook(isbn);
            commandProcessor.AddAndExecute(new CreateBookCommand(libraryManager, isbn));

        }

        public void DeleteBook(string isbn)
        {
            if (!checkIfInNormalMode()) return;

            if (!libraryManager.IsISBNInLibrary(isbn))
            {
                Console.WriteLine("Nincs ilyen ISBN számú könyv az adatbázisban");
                return;
            }

            //libraryManager.DeleteBook(isbn);
            commandProcessor.AddAndExecute(new DeleteBookCommand(libraryManager, isbn));

        }

        public void UpdateTitleOfBook(string isbn, string title)
        {
            if (!checkIfInNormalMode()) return;

            if (!libraryManager.IsISBNInLibrary(isbn))
            {
                Console.WriteLine("Ilyen ISBN számú könyv nincs az adatbázisban");
                return;
            }
            
            //libraryManager.UpdateTitleOfBook(isbn, title);
            commandProcessor.AddAndExecute(new UpdateTitleCommand(libraryManager, isbn, title));

        }

        public void UpdateAuthorOfBook(string isbn, string author)
        {
            if (!checkIfInNormalMode()) return;

            if (!libraryManager.IsISBNInLibrary(isbn))
            {
                Console.WriteLine("Ilyen ISBN számú könyv nincs az adatbázisban");
                return;
            }

            //libraryManager.UpdateAuthorOfBook(isbn, author);
            commandProcessor.AddAndExecute(new UpdateAuthorCommand(libraryManager, isbn,
                author));

        }

        public void ShowLogs()
        {

            libraryManager.ShowLogs();
        }

        public void Undo()
        { 
            //TODO
            commandProcessor.Undo();

        }

        public void PrintBooks()
        {
            libraryManager.PrintBooks();
        }

        #endregion

        #region Összetett szerkesztés utasítások

        public void StartEditingBook(string isbn)
        {
            if (!checkIfInNormalMode()) return;

            //TODO

            
            
            if (!libraryManager.IsISBNInLibrary(isbn))
            {
                Console.WriteLine("Ilyen ISBN számú könyv nincs az adatbázisban");
                return;
            }
            editedISBN = isbn;
            editBookCommand = new EditBookCommand(libraryManager, editedISBN);
            
        }

        public void UpdateEditedBookTitle(string title)
        {
            //TODO
            if (!checkIfInEditMode()) return;
            //libraryManager.UpdateTitleOfBook(editedISBN, title);
            //commandProcessor.AddAndExecute(new UpdateTitleCommand(libraryManager, editedISBN, title));
            editBookCommand.AddCommand(new UpdateTitleCommand(libraryManager, editedISBN, title));

        }

        public void UpdateEditedBookAuthor(string author)
        {
            //TODO
            if (!checkIfInEditMode()) return;
            //libraryManager.UpdateAuthorOfBook(editedISBN, author);
            //commandProcessor.AddAndExecute(new UpdateAuthorCommand(libraryManager, editedISBN, author));
            editBookCommand.AddCommand(new UpdateAuthorCommand(libraryManager, editedISBN, author));
        }

        public void FinishEditingBook()
        {
            //TODO
            if (!checkIfInEditMode()) return;
            
            commandProcessor.AddAndExecute(editBookCommand);
            
            
            editedISBN = null;
            editBookCommand = null;
            
        }
        
        private bool checkIfInEditMode()
        {
            if (!IsInEditBookMode)
            {
                Console.WriteLine("Előbb válassz ki egy könyvet szerkesztésre");
                return false;
            }
            return true;
        }


        #endregion
        
        private string editedISBN = null;
        private bool IsInEditBookMode
        {
            get { return !string.IsNullOrEmpty(editedISBN); }
        }
    }
}
