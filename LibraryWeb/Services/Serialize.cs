using LibraryWeb.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LibraryWeb.Services
{
    public class Serialize : ISerialize
    {
        private IPathProvider _pathProvider;
        private const string _fileName = "\\XML\\Books.xml";
        private const string _xmlRootAttribute = "Books";

        public Serialize(IPathProvider pathProvider)
        {
            _pathProvider = pathProvider;
        }

        public void GetSerialize(List<book> ObjectToXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToXml.GetType(), new XmlRootAttribute(_xmlRootAttribute));
            using (TextWriter textWriter = new StreamWriter(_pathProvider.FilePath(_fileName)))
            {
                xmlSerializer.Serialize(textWriter, ObjectToXml);
                textWriter.Close();
            }
        }
    }
}