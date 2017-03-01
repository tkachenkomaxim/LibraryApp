using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Newspaper : Publication
    {
        public int Number { get; set; }

        public Newspaper() { }

        public Newspaper(string title, int number, List<Genre> genres, int publicationYear, params string[] authors) : base(title, genres, publicationYear,authors)
        {
            Number = number;
        }
    }
}
