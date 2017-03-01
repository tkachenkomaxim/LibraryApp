using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LibraryApp
{
    public class Book : Publication
    { 
        public Book() { }

        public Book(string title, List<Genre> genres, int publicationYear, params string[] authors) : base(title, genres, publicationYear,authors)
        {
            
        }
    }
}
