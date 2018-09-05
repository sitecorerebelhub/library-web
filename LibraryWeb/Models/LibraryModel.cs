using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LibraryWeb.Models
{
    public class Books
    {
        public List<book> books { get; set; }
    }
    public class book
    {
        public int id { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
        public string price { get; set; }
        public string publish_date { get; set; }
        public string description { get; set; }
        public string user { get; set; }
        public string Borrowed { get; set; }
        public string colorstyle { get; set; }
        public string baText { get; set; }
        public string baParam { get; set; }
        public string baClass { get; set; }
    }
}