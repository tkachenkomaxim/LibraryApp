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
        public int Year { get; set; }
        [XmlIgnore]
        public List<Publication> Publications { get; set; }

        public Author() { }

        public Author(string name, int year, Publication publication): this(name,year)
        {
            Publications = new List<Publication>();
            Publications.Add(publication);
        }

        public Author(string name, int year)
        {
            Name = name;
            Year = year;
        }
    }
}
