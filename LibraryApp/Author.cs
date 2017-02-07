using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryApp
{
    public class Author
    {
        public string Name { get; set; }
        [XmlIgnore]
        public List<Book> Books { get; set; }

        public Author() { }

        public Author(string name, Book book)
        {
            Name = name;
            Books = new List<Book>();
            Books.Add(book);
        }
    }
}
