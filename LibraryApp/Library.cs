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
            CreateDatabase();
            //SaveLibrary();
            SaveLibraryToDatabase();
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

        private void SaveLibraryToDatabase()
        {
            SaveMagazinesToDatabase(GetPublications<Magazine>());
            SaveBooksToDatabase(GetPublications<Book>());
            SaveNewspapersToDatabase(GetPublications<Newspaper>());
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

        private void CreateDatabase()
        {
            string dbDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(dbDirectory))
            {
                Directory.CreateDirectory(dbDirectory);
            }
            string dbName = "library.mdf";
            string fullDBFilePath = Path.Combine(dbDirectory, dbName);
            if (!File.Exists(fullDBFilePath))
            {
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Integrated security=true; ");
                string command = "CREATE DATABASE Library ON PRIMARY" +
                      "(NAME = Libraty_data, " +
                      "FILENAME = '" + fullDBFilePath + "'," +
                      "SIZE = 2MB, MAXSIZE = 20MB, FILEGROWTH = 10%) ";

                SqlCommand createDBCommand = new SqlCommand(command, connection);
                connection.Open();
                createDBCommand.ExecuteNonQuery();
                connection.Close();
                CreateTables(fullDBFilePath);
            }
            if (File.Exists(fullDBFilePath))
            {
                string connectionString = string.Format("Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename='{0}';Integrated Security=True", fullDBFilePath);
                _connection = new SqlConnection(connectionString);
            }
        }

        private void CreateTables(string dbFilePath)
        {
            string connectionString = string.Format("Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename='{0}';Integrated Security=True",dbFilePath);
            _connection = new SqlConnection(connectionString);

            SqlCommand createMagazinescommand = new SqlCommand("CREATE TABLE [dbo].[Magazines] (IssueNumber INT NOT NULL, Title NVARCHAR(50) NOT NULL, Genre NVARCHAR(50) NOT NULL, Year INT NOT NULL)",_connection);
            SqlCommand createBookscommand = new SqlCommand("CREATE TABLE[dbo].[Books] (Authors NVARCHAR(50) NOT NULL, Title NVARCHAR(50) NOT NULL, Genre NVARCHAR(50) NOT NULL, Year INT NOT NULL)", _connection);
            SqlCommand createNewspaperscommand = new SqlCommand("CREATE TABLE[dbo].[Newspapers] (Number INT NOT NULL, Title NVARCHAR(50) NOT NULL, Genre NVARCHAR(50) NOT NULL, Year INT NOT NULL)", _connection);
            _connection.Open();
            createMagazinescommand.ExecuteNonQuery();
            createBookscommand.ExecuteNonQuery();
            createNewspaperscommand.ExecuteNonQuery();
            _connection.Close();
        }

        private void SaveMagazinesToDatabase(List<Magazine> magazines)
        {
            _connection.Open();
            foreach (Magazine magazine in magazines)
            {
                SqlCommand command = new SqlCommand("INSERT INTO Magazines (IssueNumber, Title, Genre, Year) VALUES (@IssueNumber, @Title, @Genre, @Year)", _connection);
                command.Parameters.AddWithValue("IssueNumber", magazine.IssueNumber);
                command.Parameters.AddWithValue("Title", magazine.Title);
                command.Parameters.AddWithValue("Genre", magazine.Genre.ToString());
                command.Parameters.AddWithValue("Year", magazine.PublicationYear);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        private void SaveBooksToDatabase(List<Book> books)
        {
            _connection.Open();
            foreach (Book book in books)
            {
                string authors = book.Authors[0].Name;
                for (int i = 1; i < book.Authors.Count; i++)
                {
                    authors += ", " + book.Authors[i].Name;
                }
                SqlCommand command = new SqlCommand("INSERT INTO Books (Authors, Title, Genre, Year) VALUES (@Authors, @Title, @Genre, @Year)", _connection);
                command.Parameters.AddWithValue("Authors", authors);
                command.Parameters.AddWithValue("Title", book.Title);
                command.Parameters.AddWithValue("Genre", book.Genre.ToString());
                command.Parameters.AddWithValue("Year", book.PublicationYear);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        private void SaveNewspapersToDatabase(List<Newspaper> newspapers)
        {
            _connection.Open();
            foreach (Newspaper newspaper in newspapers)
            {
                SqlCommand command = new SqlCommand("INSERT INTO Newspapers (Number, Title, Genre, Year) VALUES (@Number, @Title, @Genre, @Year)", _connection);
                command.Parameters.AddWithValue("Number", newspaper.Number);
                command.Parameters.AddWithValue("Title", newspaper.Title);
                command.Parameters.AddWithValue("Genre", newspaper.Genre.ToString());
                command.Parameters.AddWithValue("Year", newspaper.PublicationYear);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
    }

    }

