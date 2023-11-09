using System;
using System.IO;
using LibraryManager.Persistence;
using LibraryManager.Serializers;

namespace LibraryManager.FileManagement;

public class LibraryJSONFileManager : ILibraryFileManager
{
    public LibraryData LoadFile(string path)
    {
        var text = File.ReadAllText(path);
        var serializer = new LibraryJSONSerializer();
        var library = serializer.ParseJSON(text);
        if (library != null)
            Console.WriteLine("Könyvtár sikeresen betöltve");
        return library;
    }

    public void SaveFile(LibraryData library, string path)
    {
        var serializer = new LibraryJSONSerializer();
        var text = serializer.StringigyToJSON(library);
        File.WriteAllText(path, text);
        Console.WriteLine($"Adatok mentve ide: '{path}'");
        return;
    }
}