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

        public static bool Contains(string name)
        {
            foreach (Author author in _authors)
            {
                if (author.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public static Author GetAuthor(string name)
        {
            foreach (Author author in _authors)
            {
                if (author.Name == name)
                {
                    return author;
                }
            }
            return null;
        }

        public static void AddNewAuthor(string name,Book book)
        {
            _authors.Add(new Author(name, book));
        }

        public static void AddBookFromAuthor(string name,Book book)
        {
            foreach (Author author in _authors)
            {
                if (author.Name == name)
                {
                    author.Books.Add(book);
                }
            }
        }
    }
}
