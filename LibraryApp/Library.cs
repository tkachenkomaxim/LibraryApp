using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;
using System.Data.SqlClient;

namespace LibraryApp
{
    class Library
    {
        private List<Publication> _library;
        private Presenter _presenter;
        private XmlSerializer _formatter;
        private SqlConnection _connection;
        private StreamWriter _writer;

        public Library()
        {
            _presenter = new Presenter();
            _library = new List<Publication>();
            _formatter = new XmlSerializer(typeof(List<Book>));
            CreateLibrary();
            SaveLibrary();
            _presenter.ShowLibrary(_library);
        }

        private void CreateLibrary()
        {
            _library.Add(new Book("Flowers for Algernon", Genre.Fiction | Genre.Horror | Genre.Fantasy, 1966, "Daniel Keyes"));
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

        private List<T> GetPublications<T>() where T : Publication
        {
            List<T> publications = new List<T>();
            foreach (Publication item in _library)
            {
                if (item is T)
                {
                    publications.Add((T)item);
                }
            }
            return publications;
        }

        private void SaveLibrary()
        {
            SaveNewspapersToTextFile(GetPublications<Newspaper>());
            SaveMagazinesToDatabase(GetPublications<Magazine>());
            SaveBooksToXml(GetPublications<Book>());
        }

        private void SaveBooksToXml(List<Book> books)
        {
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

        private void SaveMagazinesToDatabase(List<Magazine> magazines)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnection"].ConnectionString;
            using (_connection = new SqlConnection(connectionString))
            {
                _connection.Open();
                foreach (Magazine magazine in magazines)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Magazines (IssueNumber, Title, Genre, Year) VALUES (@IssueNumber, @Title, @Genre, @Year)", _connection);
                    command.Parameters.AddWithValue("IssueNumber", magazine.IssueNumber);
                    command.Parameters.AddWithValue("Title",magazine.Title);
                    command.Parameters.AddWithValue("Genre",magazine.Genre.ToString());
                    command.Parameters.AddWithValue("Year",magazine.PublicationYear);
                    command.ExecuteNonQuery();
                }
            } 
        }

        private void SaveNewspapersToTextFile( List<Newspaper> newspapers)
        {
            using (_writer = File.CreateText("Newspapers.txt"))
            {
                foreach (Newspaper newspaper in newspapers)
                {
                    _writer.WriteLine("Newspaper title: «{0}»", newspaper.Title);
                    _writer.WriteLine("Issue number: {0}", newspaper.Number);
                    _writer.WriteLine("Genre: {0}", newspaper.Genre);
                    _writer.WriteLine("Year: {0}", newspaper.PublicationYear);
                    _writer.WriteLine();
                }
            }
        }
    }

    }

