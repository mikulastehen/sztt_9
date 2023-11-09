using LibraryManager.Persistence;

namespace LibraryManager.FileManagement;

public interface ILibraryFileManager
{
    LibraryData LoadFile(string path);

    void SaveFile(LibraryData library, string path);

}