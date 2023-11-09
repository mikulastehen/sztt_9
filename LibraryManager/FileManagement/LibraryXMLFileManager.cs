using System;
using System.IO;
using LibraryManager.Persistence;
using LibraryManager.Serializers;

namespace LibraryManager.FileManagement;

public class LibraryXMLFileManager : ILibraryFileManager
{
    public LibraryData LoadFile(string path)
    {
        var text = File.ReadAllText(path);
        var serializer = new LibraryXmlSerializer();
        var library = serializer.LoadFromXml(text);
        if (library != null)
            Console.WriteLine("Könyvtár sikeresen betöltve");
        return library;
    }

    public void SaveFile(LibraryData library, string path)
    {
        var serializer = new LibraryXmlSerializer();
        var text = serializer.GenerateXml(library);
        File.WriteAllText(path, text);
        Console.WriteLine($"Adatok mentve ide: '{path}'");
        return;
    }
}