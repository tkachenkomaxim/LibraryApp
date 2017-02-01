using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public int PublicationYear { get; set; }

        public Book(string author, string title, Genre genre, int publicationYear)
        {
            Author = author;
            Title = title;
            Genre = genre;
            PublicationYear = publicationYear;
        }
    }
}
