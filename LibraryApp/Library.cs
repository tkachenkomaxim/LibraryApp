using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LibraryApp
{
    class Library
    {
        private List<Publication> _library;
        private Presenter _presenter;
        private XmlSerializer _formatter;

        public Library()
        {
            _presenter = new Presenter();
            _library = new List<Publication>();
            _formatter = new XmlSerializer(typeof(List<Book>));
            CreateLibrary();
            SaveBooksToXml();
            _presenter.ShowLibrary(_library);
        }

        private void CreateLibrary()
        {
            _library.Add(new Book("Flowers for Algernon", Genre.ScienceFiction, 1966, "Daniel Keyes"));
            _library.Add(new Book("To Kill a Mockingbird", Genre.Bildungsroman, 1960, "Harper Lee"));
            _library.Add(new Book("The Godfather", Genre.Crime, 1969, "Mario Puzo"));
            _library.Add(new Book("CLR Via C#", Genre.Technical, 2006, "Jeffrey Richter"));
            _library.Add(new Book("The Picture of Dorian Gray", Genre.Philosophical, 1890, "Oscar Wilde"));
            _library.Add(new Book("11/22/63", Genre.Alternative, 2011, "Stephen King"));
            _library.Add(new Book("C# 6.0 in a Nutshell", Genre.Technical, 2016, "Joseph Albahari", "Ben Albahari"));

            _library.Add(new Magazine("Esquire", 33, Genre.Fashion, 2017));
            _library.Add(new Magazine("National Geographic", 208, Genre.Nature, 2017));
            _library.Add(new Magazine("Business Journal", 11, Genre.Economic, 2017));
            _library.Add(new Magazine("Ecliva", 107, Genre.Electronic, 2016));
            _library.Add(new Magazine("ІJECСТ", 71, Genre.Electronic, 2017));
            _library.Add(new Magazine("J.UCS", 25, Genre.Technical, 2015));

            _library.Add(new Newspaper("The Guardian", 505, Genre.Politic, 2017));
            _library.Add(new Newspaper("The Washington Post", 1407, Genre.News, 2017));
            _library.Add(new Newspaper("The Independent", 706, Genre.Jurisprudence, 2017));
            
        }

        private void SaveBooksToXml()
        {
            List<Book> books = new List<Book>();
            foreach (Publication item in _library)
            {
                if (item is Book)
                {
                    books.Add((Book)item);
                }
            }
            using (FileStream fileStream = new FileStream("books.xml", FileMode.Create, FileAccess.Write))
            {
                _formatter.Serialize(fileStream, books);
            }
        }

        private List<Book> ReadBooksFromXml()
        {
            List<Book> books = new List<Book>();
            using (FileStream fileStream = new FileStream("books.xml", FileMode.Open, FileAccess.Read))
            {
              books = _formatter.Deserialize(fileStream) as List<Book>;
            }
            return books;
        }
    }

    }

