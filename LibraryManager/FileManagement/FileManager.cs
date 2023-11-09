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
        public void StoreLibrary(LibraryData library, string path)
        {
            var extension = Path.GetExtension(path).TrimStart('.');
            if (extension == "xml")
            {
                var serializer = new LibraryXmlSerializer();
                var text = serializer.GenerateXml(library);
                File.WriteAllText(path, text);
                Console.WriteLine($"Adatok mentve ide: '{path}'");
                return;
            }


            Console.WriteLine("Nem támogatott file típus");
        }

        /// <summary>
        /// Betölti egy fájlból a könyvtár tartalmát
        /// </summary>
        public LibraryData LoadLibrary(string path)
        {
            var extension = Path.GetExtension(path).TrimStart('.');
            if (extension == "xml")
            {
                var text = File.ReadAllText(path);
                var serializer = new LibraryXmlSerializer();
                var library = serializer.LoadFromXml(text);
                if (library != null)
                    Console.WriteLine("Könyvtár sikeresen betöltve");
                return library;
            }

            Console.WriteLine($"Nem támogatott file típus, jelenleg csak ezeket a fájlokat támogatjuk: xml");
            return null;
        }
    }
}

