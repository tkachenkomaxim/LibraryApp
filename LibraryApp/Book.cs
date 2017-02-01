using System;

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
