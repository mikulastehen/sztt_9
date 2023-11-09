using System.IO;
using System.Xml.Serialization;
using LibraryManager.Models;
using LibraryManager.Persistence;

namespace LibraryManager.Serializers
{
    class LibraryXmlSerializer
    {
        public string GenerateXml(LibraryData library)
        {
            var serializer = new XmlSerializer(typeof(LibraryData));
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, library);
                return writer.ToString();
            }
        }

        public LibraryData LoadFromXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return new LibraryData();

            using (var reader = new StringReader(xml))
            {
                var books = new XmlSerializer(typeof(LibraryData)).Deserialize(reader) as LibraryData;
                return books;
            }
        }

    }
}
