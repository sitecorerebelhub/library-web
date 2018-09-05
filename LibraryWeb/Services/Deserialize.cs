using LibraryWeb.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LibraryWeb.Services
{
    public class Deserialize : IDeserialize
    {
        private IPathProvider _pathProvider;
        private const string _fileName = "\\XML\\Books.xml";
        private const string _xmlRootAttribute = "Books";

        public Deserialize(IPathProvider pathProvider)
        {
            _pathProvider = pathProvider;
        }

        public List<book> GetDeserialize()
        {    
            string xmlString = System.IO.File.ReadAllText(_pathProvider.FilePath(_fileName));

            XmlSerializer serializer = new XmlSerializer(typeof(List<book>), new XmlRootAttribute(_xmlRootAttribute));
            using (StringReader sr = new StringReader(xmlString))
            {
                return (List<book>)serializer.Deserialize(sr);
            }
        }
    }
}