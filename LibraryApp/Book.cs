using System;
using System.Collections.Generic;

namespace LibraryApp
{
    class Book : Publication
    {
        public List<string> Authors { get; set; }

        public Book(string title, Genre genre, int publicationYear, params string[] authors) : base(title, genre, publicationYear)
        {
            Authors = new List<string>();
            foreach (string author in authors)
            {
                Authors.Add(author);
            }
        }
    }
}
