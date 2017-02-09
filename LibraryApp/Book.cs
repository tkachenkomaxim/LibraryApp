using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LibraryApp
{
    public class Book : Publication
    { 
        public List<Author> Authors { get; set; }

        public Book() { }

        public Book(string title, Genre genre, int publicationYear, params string[] authors) : base(title, genre, publicationYear)
        {
            Authors = new List<Author>();
            foreach (string name in authors)
            {
                if (ListOfAuthors.Contains(name))
                {
                    Authors.Add(ListOfAuthors.GetAuthor(name));
                    ListOfAuthors.AddBookFromAuthor(name, this);
                }
                if (!ListOfAuthors.Contains(name))
                {
                    ListOfAuthors.AddNewAuthor(name, this);
                    Authors.Add(ListOfAuthors.GetAuthor(name));
                }
            }
        }
    }
}
