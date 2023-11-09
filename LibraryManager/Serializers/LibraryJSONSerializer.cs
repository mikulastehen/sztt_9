using LibraryManager.Models;
using LibraryManager.Persistence;
using Newtonsoft.Json;

namespace LibraryManager.Serializers
{
    public class LibraryJSONSerializer
    {
        public LibraryData ParseJSON(string text) 
        {
            if (string.IsNullOrEmpty(text))
                return new LibraryData();

            return JsonConvert.DeserializeObject<LibraryData>(text);
        }

        public string StringigyToJSON(LibraryData library)
        {
            return JsonConvert.SerializeObject(library);
        }

    }
}
