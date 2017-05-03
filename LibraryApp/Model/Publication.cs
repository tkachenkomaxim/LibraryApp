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

        protected Publication(string title, List<Genre> genres, int publicationYear, params Author[] authors)
        {
            Title = title;
            Genres = genres;
            PublicationYear = publicationYear;
            Authors = new List<Author>();
            foreach (var author in authors)
            {
                if (ListOfAuthors.Contains(author.Name,author.Year))
                {
                    Authors.Add(ListOfAuthors.GetAuthor(author.Name, author.Year));
                    ListOfAuthors.AddPublicationFromAuthor(author.Name, author.Year, this);
                }
                if (!ListOfAuthors.Contains(author.Name, author.Year))
                {
                    ListOfAuthors.AddNewAuthor(author.Name, author.Year, this);
                    Authors.Add(ListOfAuthors.GetAuthor(author.Name, author.Year));
                }
            }
        }
    }
}
