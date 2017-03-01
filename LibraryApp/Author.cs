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
        public List<Publication> Publications { get; set; }

        public Author() { }

        public Author(string name, Publication publication)
        {
            Name = name;
            Publications = new List<Publication>();
            Publications.Add(publication);
        }
    }
}
