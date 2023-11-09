using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LibraryManager.Models;
using LibraryManager.Persistence;
using LibraryManager.Serializers;

namespace LibraryManager.FileManagement
{
    /// <summary>
    /// Könyvtárak fájlba írásáért és betöltéséért felel
    /// </summary>
    public class FileManager
    {
       /// <summary>
        /// Elment egy könyvtárat az elérési útvonalon található fájlba
        /// </summary>
       private readonly Dictionary<string, ILibraryFileManager> fileManagers = new Dictionary<string, ILibraryFileManager>();
       public FileManager()
       {
           fileManagers.Add("json", new LibraryJSONFileManager());
           fileManagers.Add("xml", new LibraryXMLFileManager());
       }

        public void StoreLibrary(LibraryData library, string path)
        {
            var extension = Path.GetExtension(path).TrimStart('.');
            if (fileManagers.ContainsKey(extension))
            {
                fileManagers[extension].SaveFile(library, path);
            }
            else
            {
                Console.WriteLine("Ismeretlen fájlformátum!");
            }
        }

        /// <summary>
        /// Betölti egy fájlból a könyvtár tartalmát
        /// </summary>
        public LibraryData LoadLibrary(string path)
        {
            var extension = Path.GetExtension(path).TrimStart('.');
            if (fileManagers.ContainsKey(extension))
            {
                return fileManagers[extension].LoadFile(path);
            }
            else
            {
                Console.WriteLine("Ismeretlen fájlformátum!");
            }

            return null;
        }
    }
}

