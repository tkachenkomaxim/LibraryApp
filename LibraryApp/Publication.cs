using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public abstract class Publication
    {
        public List<Author> Authors { get; set; }
        public string Title { get; set; }
        public List<Genre> Genres { get; set; }
        public int PublicationYear { get; set; }

        public Publication() { }

        protected Publication(string title, List<Genre> genres, int publicationYear, params string[] authors)
        {
            Title = title;
            Genres = genres;
            PublicationYear = publicationYear;
            Authors = new List<Author>();
            foreach (string name in authors)
            {
                if (ListOfAuthors.Contains(name))
                {
                    Authors.Add(ListOfAuthors.GetAuthor(name));
                    ListOfAuthors.AddPublicationFromAuthor(name, this);
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
