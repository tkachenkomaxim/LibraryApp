using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public static class ListOfAuthors
    {
        private static List<Author> _authors;

        static ListOfAuthors()
        {
            _authors = new List<Author>();
        }

        public static bool Contains(string name, int year)
        {
            foreach (Author author in _authors)
            {
                if (author.Name == name && author.Year == year)
                {
                    return true;
                }
            }
            return false;
        }

        public static Author GetAuthor(string name, int year)
        {
            foreach (Author author in _authors)
            {
                if (author.Name == name && author.Year == year)
                {
                    return author;
                }
            }
            return null;
        }

        public static void AddNewAuthor(string name, int year, Publication publication)
        {
            _authors.Add(new Author(name, year, publication));
        }

        public static void AddPublicationFromAuthor(string name, int year, Publication publication)
        {
            foreach (Author author in _authors)
            {
                if (author.Name == name && author.Year == year)
                {
                    author.Publications.Add(publication);
                }
            }
        }
    }
}
