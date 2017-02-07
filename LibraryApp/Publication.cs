using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public abstract class Publication
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public int PublicationYear { get; set; }

        public Publication() { }

        protected Publication(string title, Genre genre, int publicationYear)
        {
            Title = title;
            Genre = genre;
            PublicationYear = publicationYear;
        }
    }
}
