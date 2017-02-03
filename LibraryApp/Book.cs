using System;

namespace LibraryApp
{
    class Book : Publication
    {
        public string Author { get; set; }

        public Book(string author,string title, Genre genre, int publicationYear) : base(title, genre, publicationYear)
        {
            Author = author;
        }
    }
}
