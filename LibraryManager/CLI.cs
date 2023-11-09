using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    public class CLI
    {
        private readonly CommandContextManager commandContextManager = new CommandContextManager();
        public void Start()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            while (true)
            {
                Console.Write(">> ");
                var userCommandText = Console.ReadLine();
                var words = ParseUserCommandText(userCommandText);
                if (words.Length == 0)
                    continue;

                switch (words[0])
                {
                    case WORD_HELP:
                        {
                            WriteHelpToConsole();
                            break;
                        }
                    case WORD_QUIT:
                        {
                            return;
                        }
                    case WORD_SAVE:
                        {
                            if (words.Length < 2)
                                Console.WriteLine("Hibás parancs");
                            else
                            {
                                var path = CollectUserCommandWords(words.Skip(1));
                                commandContextManager.Save(path);
                            }
                            break;
                        }
                    case WORD_LOAD:
                        {
                           

                            if (words.Length < 2)
                                Console.WriteLine("Hibás parancs");
                            else
                            {
                                var path = CollectUserCommandWords(words.Skip(1));

                                commandContextManager.Load(path);
                            }
                            break;
                        }

                    case WORD_NEW_BOOK:
                        {
                          

                            if (words.Length != 2)
                                Console.WriteLine("Hibás parancs");
                            else
                            {
                                var isbn = words[1];
                                commandContextManager.CreateNewBook(isbn);
                            }

                            break;
                        }
                    case WORD_BOOKS:
                    {

                        commandContextManager.PrintBooks();
                            break;
                        }
                    case WORD_EDIT:
                        {
                           
                            if (words.Length == 1)
                            {
                                Console.WriteLine("Hibás parancs");
                                break;
                            }

                            var isbn = words[1];

                            if (words.Length > 2)
                            {
                                if (words[2] == WORD_TITLE)
                                {
                                    if (words.Length < 4)
                                    {
                                        Console.WriteLine("Hibás parancs");
                                        break;
                                    }

                                    var title = CollectUserCommandWords(words.Skip(3));

                                    commandContextManager.UpdateTitleOfBook(isbn, title);
                                    break;
                                }

                                if (words[2] == WORD_AUTHOR)
                                {
                                    if (words.Length < 4)
                                    {
                                        Console.WriteLine("Hibás parancs");
                                        break;
                                    }

                                    var author = CollectUserCommandWords(words.Skip(3));

                                    commandContextManager.UpdateAuthorOfBook(isbn, author);
                                    break;
                                }

                                Console.WriteLine("Hibás parancs");
                                break;
                            }
                            else
                            {
                                commandContextManager.StartEditingBook(isbn);
                            }

                            break;
                        }
                    case WORD_TITLE:
                        {
                           

                            if (words.Length < 2)
                            {
                                Console.WriteLine("Hibás parancs");
                                break;
                            }

                            var title = CollectUserCommandWords(words.Skip(1));

                            commandContextManager.UpdateEditedBookTitle(title);
                            break;
                        }

                    case WORD_AUTHOR:
                        {
                          

                            if (words.Length < 2)
                            {
                                Console.WriteLine("Hibás parancs");
                                break;
                            }


                            var author = CollectUserCommandWords(words.Skip(1));

                            commandContextManager.UpdateEditedBookAuthor(author);
                            break;
                        }
                    case WORD_BACK:
                    {
                        commandContextManager.FinishEditingBook();
                          
                            break;
                        }
                    case WORD_DELETE_BOOK:
                        {
                            if (words.Length != 2)
                            {
                                Console.WriteLine("Hibás parancs");
                                break;
                            }

                            var isbn = words[1];

                            commandContextManager.DeleteBook(isbn);
                            break;
                        }
                    case WORD_SHOW_LOG:
                    {
                        commandContextManager.ShowLogs();
                            break;
                        }
                    case WORD_UNDO:
                    {
                        commandContextManager.Undo();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Hibás parancs");
                            break;
                        }
                }
            }
        }



        private const string WORD_SAVE = "ment";
        private const string WORD_BOOKS = "lista";
        private const string WORD_LOAD = "betölt";
        private const string WORD_QUIT = "kilép";
        private const string WORD_HELP = "súgó";
        private const string WORD_EDIT = "szerkeszt";
        private const string WORD_NEW_BOOK = "új";
        private const string WORD_TITLE = "cím";
        private const string WORD_AUTHOR = "szerző";
        private const string WORD_BACK = "befejez";
        private const string WORD_DELETE_BOOK = "töröl";
        private const string WORD_SHOW_LOG = "log";
        private const string WORD_UNDO = "visszavon";

        

        private void WriteHelpToConsole()
        {
            Console.WriteLine($@"
Segítség a program használatához:
 * {WORD_HELP}: súgó megjelenítése
 * {WORD_SAVE} <fájlnév>: adatbázis mentése fájlba - TODO
 * {WORD_LOAD} <fájlnév>: adatbázis betöltése fájlból - TODO
 * {WORD_NEW_BOOK} <ISBN>: új könyv létrehozása a megadott ISBN számmal
 * {WORD_EDIT} <ISBN>: adott ISBN számú könyv szerkesztésének megkezdése - TODO
  * {WORD_TITLE} <új_cím>: az aktuálisan szerkesztett könyv címének megváltoztatása - TODO
  * {WORD_AUTHOR} <új_szerző_lista>: az aktuálisan szerkesztett könyv szerzőinek módosítása - TODO
  * {WORD_BACK}: az aktuális szerkesztés jóváhagyása - TODO
  * {WORD_UNDO}: az utolsó parancs visszavonása - TODO
 * {WORD_EDIT} <ISBN> {WORD_TITLE} <új_cím>: egy könyv címének megváltoztatása
 * {WORD_EDIT} <ISBN> {WORD_AUTHOR} <új_szerező>: egy könyv szerzőjéek megváltoztatása 
 * {WORD_QUIT}: kilépés a programoból
 * {WORD_BOOKS}: az adatbázisban tárolt könyvek megjelenítése
 * {WORD_DELETE_BOOK} <ISBN>: az adott ISBN számú könyv törlése
 * {WORD_SHOW_LOG}: kiírja az adatbázis adatainak történetét
 * {WORD_UNDO}: az utolsó parancs visszavonása - TODO

Megjegyzések: 
 * az ISBN szám csak számokat és '-'-eket tartalmazhat
 * A szerzőlistában a szerzőket ','-vel kell elválasztani
");
        }

        private string[] ParseUserCommandText(string text)
        {
            return text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string CollectUserCommandWords(IEnumerable<string> words)
        {
            return string.Join(" ", words);
        }
    }
}

