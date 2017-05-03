using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryApp
{
    public class Library
    {
        private List<Publication> _library;
        private XmlSerializer _formatter;
        public SqlConnection connection;
        private StreamWriter _writer;

        public Library()
        {
            _library = new List<Publication>();
            _formatter = new XmlSerializer(typeof(List<Book>));
            CreateLibrary();
            CreateDatabase();
            //SaveLibrary();
            //SaveLibraryToDatabase();
            RunMainForm();
        }

        public void RunMainForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LibraryForm form1 = new LibraryForm(this);
            Application.Run(form1);
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

        public string GetGenresString(Publication publication)
        {
            string genres = publication.Genres[0].ToString();
            for (int i = 1; i < publication.Genres.Count; i++)
            {
                genres += ", " + publication.Genres[i].ToString();
            }
            return genres;
        }

        public string GetAuthorsString(Publication publication)
        {
            string authors = "";
            if (publication.Authors.Count > 0)
            {
                authors = publication.Authors[0].Name;
                for (int i = 1; i < publication.Authors.Count; i++)
                {
                    authors += ", " + publication.Authors[i].Name;
                }
            }
            return authors;
        }

        public List<Genre> GenresBuilder(params Genre[] genre)
        {
            List<Genre> genres = new List<Genre>();
            foreach (Genre item in genre)
            {
                genres.Add(item);
            }
            return genres;
        }

        private void CreateLibrary()
        {
            _library.Add(new Book("Flowers for Algernon", GenresBuilder(Genre.Fiction, Genre.Horror , Genre.Fantasy), 1966, new Author("Daniel Keyes",1900)));
            _library.Add(new Book("To Kill a Mockingbird", GenresBuilder(Genre.Bildungsroman), 1960, new Author("Harper Lee",1890)));
            _library.Add(new Book("The Godfather", GenresBuilder(Genre.Crime), 1969, new Author("Mario Puzo",1900)));
            _library.Add(new Book("CLR Via C#", GenresBuilder(Genre.Technical), 2006, new Author("Jeffrey Richter",1890)));
            _library.Add(new Book("The Picture of Dorian Gray", GenresBuilder(Genre.Philosophical), 1890, new Author("Oscar Wilde",1900)));
            _library.Add(new Book("11/22/63", GenresBuilder(Genre.Alternative), 2011, new Author("Stephen King",1920)));
            _library.Add(new Book("C# 6.0 in a Nutshell", GenresBuilder(Genre.Technical), 2016, new Author("Joseph Albahari", 1950), new Author("Ben Albahari",1961)));

            _library.Add(new Magazine("Esquire", 33, GenresBuilder(Genre.Fashion), 2017));
            _library.Add(new Magazine("National Geographic", 208, GenresBuilder(Genre.Nature), 2017));
            _library.Add(new Magazine("Business Journal", 11, GenresBuilder(Genre.Economic), 2017));
            _library.Add(new Magazine("Ecliva", 107, GenresBuilder(Genre.Electronic), 2016));
            _library.Add(new Magazine("IJECCT", 71, GenresBuilder(Genre.Technical), 2017));
            _library.Add(new Magazine("J.UCS", 25, GenresBuilder(Genre.Technical), 2015));

            _library.Add(new Newspaper("The Guardian", 505, GenresBuilder(Genre.Politic), 2017));
            _library.Add(new Newspaper("The Washington Post", 1407, GenresBuilder(Genre.News), 2017));
            _library.Add(new Newspaper("The Independent", 706, GenresBuilder(Genre.Jurisprudence), 2017));

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

        private void SaveNewspapersToTextFile(List<Newspaper> newspapers)
        {
            using (_writer = File.CreateText("Newspapers.txt"))
            {
                foreach (Newspaper newspaper in newspapers)
                {
                    _writer.WriteLine("Newspaper title: «{0}»", newspaper.Title);
                    _writer.WriteLine("Issue number: {0}", newspaper.Number);
                    _writer.WriteLine("Genre: {0}", GetGenresString(newspaper));
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
            string dbName = "library6.mdf";
            string fullDBFilePath = Path.Combine(dbDirectory, dbName);
            if (!File.Exists(fullDBFilePath))
            {
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Integrated security=true; ");
                string command = "CREATE DATABASE Libraryv22 ON PRIMARY" +
                      "(NAME = Libraty_data3, " +
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
               // CreateTables(fullDBFilePath);
                string connectionString = string.Format("Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename='{0}';Integrated Security=True", fullDBFilePath);
                connection = new SqlConnection(connectionString);
            }
        }

        private void CreateTables(string dbFilePath)
        {
            string connectionString = string.Format("Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename='{0}';Integrated Security=True", dbFilePath);
            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand createBookscommand = new SqlCommand(@"CREATE TABLE [dbo].[books] (
                                                             [Id] INT  IDENTITY(1, 1) NOT NULL,
                                                             [title] NVARCHAR(150) NOT NULL,
                                                             [year]  INT            NOT NULL,
                                                             PRIMARY KEY CLUSTERED([Id] ASC));", connection);

            SqlCommand createMagazinescommand = new SqlCommand(@"CREATE TABLE [dbo].[magazines] (
                                                                 [id]     INT            IDENTITY(1, 1) NOT NULL,
                                                                 [title]  NVARCHAR(150) NOT NULL,
                                                                 [number] INT            NOT NULL,
                                                                 [year]   INT            NOT NULL,
                                                                 PRIMARY KEY CLUSTERED([id] ASC));", connection);

            SqlCommand createNewspaperscommand = new SqlCommand(@"CREATE TABLE [dbo].[newspapers] (
                                                                  [id]     INT            IDENTITY (1, 1) NOT NULL,
                                                                  [title]  NVARCHAR (150) NOT NULL,
                                                                  [number] INT            NOT NULL,
                                                                  [year]   INT            NOT NULL,
                                                                  PRIMARY KEY CLUSTERED ([id] ASC));", connection);

            SqlCommand createAuthorscommand = new SqlCommand(@"CREATE TABLE [dbo].[authors] (
                                                               [id]   INT           IDENTITY (1, 1) NOT NULL,
                                                               [name] NVARCHAR (50) NOT NULL,
                                                               [year] INT           NOT NULL,
                                                               PRIMARY KEY CLUSTERED ([id] ASC));", connection);

            SqlCommand createGenrescommand = new SqlCommand(@"CREATE TABLE [dbo].[Genres] (
                                                              [Id]    INT           IDENTITY (1, 1) NOT NULL,
                                                              [Genre] NVARCHAR (50) NOT NULL,
                                                              PRIMARY KEY CLUSTERED ([Id] ASC));",connection);

            SqlCommand createM2MBooksGenres = new SqlCommand(@"CREATE TABLE [dbo].[m2m_books_genres] (
                                                               [Id]       INT IDENTITY (1, 1) NOT NULL,
                                                               [book_id]  INT NOT NULL,
                                                               [genre_id] INT NOT NULL,
                                                               PRIMARY KEY CLUSTERED ([Id] ASC),
                                                               CONSTRAINT [FK_m2m_books_genres_ToGenre] FOREIGN KEY ([genre_id]) REFERENCES [dbo].[Genres] ([Id]),
                                                               CONSTRAINT [FK_m2m_books_genres_ToBooks] FOREIGN KEY ([book_id]) REFERENCES [dbo].[books] ([Id]));", connection);

            SqlCommand createM2MBooksAuthors = new SqlCommand(@"CREATE TABLE [dbo].[m2m_books_authors] (
                                                                [Id]        INT IDENTITY (1, 1) NOT NULL,
                                                                [author_id] INT NOT NULL,
                                                                [book_id]   INT NOT NULL,
                                                                PRIMARY KEY CLUSTERED ([Id] ASC),
                                                                CONSTRAINT [FK_m2m_books_authors_ToAuthor] FOREIGN KEY ([author_id]) REFERENCES [dbo].[authors] ([id]),
                                                                CONSTRAINT [FK_m2m_books_authors_ToBooks] FOREIGN KEY ([book_id]) REFERENCES [dbo].[books] ([Id]));", connection);

            SqlCommand createM2MMagazinesGenres = new SqlCommand(@"CREATE TABLE [dbo].[m2m_magazines_genres] (
                                                                   [Id]          INT IDENTITY (1, 1) NOT NULL,
                                                                   [magazine_id] INT NOT NULL,
                                                                   [genre_id]    INT NOT NULL,
                                                                   PRIMARY KEY CLUSTERED ([Id] ASC),
                                                                   CONSTRAINT [FK_m2m_magazines_genres_ToGenre] FOREIGN KEY ([genre_id]) REFERENCES [dbo].[Genres] ([Id]),
                                                                   CONSTRAINT [FK_m2m_magazines_genres_ToBooks] FOREIGN KEY ([magazine_id]) REFERENCES [dbo].[magazines] ([id]));", connection);

            SqlCommand createM2MMagazinesAuthors = new SqlCommand(@"CREATE TABLE [dbo].[m2m_magazines_authors] (
                                                                    [Id]          INT IDENTITY (1, 1) NOT NULL,
                                                                    [author_id]   INT NOT NULL,
                                                                    [magazine_id] INT NOT NULL,
                                                                    PRIMARY KEY CLUSTERED ([Id] ASC),
                                                                    CONSTRAINT [FK_m2m_magazines_authors_ToAuthor] FOREIGN KEY ([author_id]) REFERENCES [dbo].[authors] ([id]),
                                                                    CONSTRAINT [FK_m2m_magazines_authors_ToMagazine] FOREIGN KEY ([magazine_id]) REFERENCES [dbo].[magazines] ([id]));", connection);

            SqlCommand createM2MNewspapersGenres = new SqlCommand(@"CREATE TABLE [dbo].[m2m_newspapers_genres] (
                                                                    [Id]           INT IDENTITY (1, 1) NOT NULL,
                                                                    [newspaper_id] INT NOT NULL,
                                                                    [genre_id]     INT NOT NULL,
                                                                    PRIMARY KEY CLUSTERED ([Id] ASC),
                                                                    CONSTRAINT [FK_m2m_newspapers_genres_ToGenre] FOREIGN KEY ([genre_id]) REFERENCES [dbo].[Genres] ([Id]),
                                                                    CONSTRAINT [FK_m2m_newspapers_genres_ToNewspaper] FOREIGN KEY ([newspaper_id]) REFERENCES [dbo].[newspapers] ([id]));", connection);

            SqlCommand createM2MNewspapersAuthors = new SqlCommand(@"CREATE TABLE [dbo].[m2m_newspapers_authors] (
                                                                     [Id]           INT IDENTITY (1, 1) NOT NULL,
                                                                     [author_id]    INT NOT NULL,
                                                                     [newspaper_id] INT NOT NULL,
                                                                     PRIMARY KEY CLUSTERED ([Id] ASC),
                                                                     CONSTRAINT [FK_m2m_newspapers_authors_ToAuthor] FOREIGN KEY ([author_id]) REFERENCES [dbo].[authors] ([id]),
                                                                     CONSTRAINT [FK_m2m_newspapers_authors_ToNewspaper] FOREIGN KEY ([newspaper_id]) REFERENCES [dbo].[magazines] ([id]));", connection);

            createBookscommand.ExecuteNonQuery();
            createMagazinescommand.ExecuteNonQuery();
            createNewspaperscommand.ExecuteNonQuery();
            createAuthorscommand.ExecuteNonQuery();
            createGenrescommand.ExecuteNonQuery();
            createM2MBooksGenres.ExecuteNonQuery();
            createM2MBooksAuthors.ExecuteNonQuery();
            createM2MMagazinesGenres.ExecuteNonQuery();
            createM2MMagazinesAuthors.ExecuteNonQuery();
            createM2MNewspapersGenres.ExecuteNonQuery();
            createM2MNewspapersAuthors.ExecuteNonQuery();

            connection.Close();

            AddGenresToDatabase();
        }

        private void AddGenresToDatabase()
        {
            connection.Open();
            int firstGenreNumber = (int) Genre.Fiction;
            int lastGenreNumber = (int) Genre.Jurisprudence;
            for (int i = firstGenreNumber ; i <= lastGenreNumber; i++)
            {
                SqlCommand command = new SqlCommand("INSERT INTO genres (Genre) VALUES (@Genre)", connection);
                command.Parameters.AddWithValue("Genre", ((Genre)i).ToString());
                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        private int? GetAuthorID(Author author)
        {
            string commandText = string.Format("SELECT id FROM authors WHERE authors.name = '{0}' AND authors.year = {1}", author.Name, author.Year);
            SqlCommand command = new SqlCommand(commandText, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int id = reader.GetInt32(0);
                reader.Close();
                return id;
            }
            reader.Close();
            return null;
        }

        private void SaveMagazinesToDatabase(List<Magazine> magazines)
        {
            connection.Open();
            foreach (Magazine magazine in magazines)
            {
                AddNewMagazineToDatabase(magazine);
            }
            connection.Close();
        }

        private void SaveBooksToDatabase(List<Book> books)
        {
            connection.Open();
            foreach (Book book in books)
            {
                AddNewBookToDatabase(book);
            }
            connection.Close();
        }

        private void SaveNewspapersToDatabase(List<Newspaper> newspapers)
        {
            connection.Open();
            foreach (Newspaper newspaper in newspapers)
            {
                AddNewspaperToDatabase(newspaper);
            }
            connection.Close();
        }

        public void AddNewBookToDatabase(Book book)
        {
            SqlCommand commandInsertBook = new SqlCommand("INSERT INTO books (title,year) VALUES (@title, @year)", connection);
            commandInsertBook.Parameters.AddWithValue("title", book.Title);
            commandInsertBook.Parameters.AddWithValue("year", book.PublicationYear);
            commandInsertBook.ExecuteNonQuery();

            string commandText = string.Format("SELECT id FROM books WHERE books.title = '{0}' AND books.year = {1}", book.Title, book.PublicationYear);
            SqlCommand commandSelectBook = new SqlCommand(commandText, connection);
            SqlDataReader readerBook = commandSelectBook.ExecuteReader();
            readerBook.Read();
            int bookId = readerBook.GetInt32(0);
            readerBook.Close();

            foreach (var genre in book.Genres)
            {
                SqlCommand commandInsertM2MBooksGenres = new SqlCommand("INSERT INTO m2m_books_genres (book_id,genre_id)  VALUES (@book_id, @genre_id)", connection);
                commandInsertM2MBooksGenres.Parameters.AddWithValue("book_id", bookId);
                commandInsertM2MBooksGenres.Parameters.AddWithValue("genre_id", (int)genre);
                commandInsertM2MBooksGenres.ExecuteNonQuery();
            }

            foreach (var author in book.Authors)
            {
                if (GetAuthorID(author) == null)
                {
                    SqlCommand commandInsertAuthor = new SqlCommand("INSERT INTO authors (name, year) VALUES (@name, @year)", connection);
                    commandInsertAuthor.Parameters.AddWithValue("name", author.Name);
                    commandInsertAuthor.Parameters.AddWithValue("year", author.Year);
                    commandInsertAuthor.ExecuteNonQuery();
                }
                if (GetAuthorID(author) != null)
                {
                    SqlCommand commandInsertM2MBooksAuthors = new SqlCommand("INSERT INTO m2m_books_authors (book_id,author_id)  VALUES (@book_id, @author_id)", connection);
                    commandInsertM2MBooksAuthors.Parameters.AddWithValue("book_id", bookId);
                    commandInsertM2MBooksAuthors.Parameters.AddWithValue("author_id", GetAuthorID(author));
                    commandInsertM2MBooksAuthors.ExecuteNonQuery();
                }
            }
        }
        
        public void AddNewMagazineToDatabase(Magazine magazine)
        {
            SqlCommand commandInsertMagazine = new SqlCommand("INSERT INTO magazines (title,number,year) VALUES (@title, @number, @year)", connection);
            commandInsertMagazine.Parameters.AddWithValue("title", magazine.Title);
            commandInsertMagazine.Parameters.AddWithValue("number", magazine.IssueNumber);
            commandInsertMagazine.Parameters.AddWithValue("year", magazine.PublicationYear);
            commandInsertMagazine.ExecuteNonQuery();

            string commandText = string.Format("SELECT id FROM magazines WHERE magazines.title = '{0}' AND magazines.number = {1} AND magazines.year = {2}", magazine.Title, magazine.IssueNumber, magazine.PublicationYear);
            SqlCommand commandSelectMagazine = new SqlCommand(commandText, connection);
            SqlDataReader readerMagazine = commandSelectMagazine.ExecuteReader();
            readerMagazine.Read();
            int magazineId = readerMagazine.GetInt32(0);
            readerMagazine.Close();

            foreach (var genre in magazine.Genres)
            {
                SqlCommand commandInsertM2MMagazinesGenres = new SqlCommand("INSERT INTO m2m_magazines_genres (magazine_id,genre_id)  VALUES (@magazine_id, @genre_id)", connection);
                commandInsertM2MMagazinesGenres.Parameters.AddWithValue("magazine_id", magazineId);
                commandInsertM2MMagazinesGenres.Parameters.AddWithValue("genre_id", (int)genre);
                commandInsertM2MMagazinesGenres.ExecuteNonQuery();
            }

            foreach (var author in magazine.Authors)
            {
                if (GetAuthorID(author) == null)
                {
                    SqlCommand commandInsertAuthor = new SqlCommand("INSERT INTO authors (name, year) VALUES (@name, @year)", connection);
                    commandInsertAuthor.Parameters.AddWithValue("name", author.Name);
                    commandInsertAuthor.Parameters.AddWithValue("year", author.Year);
                    commandInsertAuthor.ExecuteNonQuery();
                }
                if (GetAuthorID(author) != null)
                {
                    SqlCommand commandInsertM2MMagazinesAuthors = new SqlCommand("INSERT INTO m2m_magazines_authors (magazine_id,author_id)  VALUES (@magazine_id, @author_id)", connection);
                    commandInsertM2MMagazinesAuthors.Parameters.AddWithValue("magazine_id", magazineId);
                    commandInsertM2MMagazinesAuthors.Parameters.AddWithValue("author_id", GetAuthorID(author));
                    commandInsertM2MMagazinesAuthors.ExecuteNonQuery();
                }
            }
        }

        public void AddNewspaperToDatabase(Newspaper newspaper)
        {
            SqlCommand commandInsertNewspaper = new SqlCommand("INSERT INTO newspapers (title,number,year) VALUES (@title, @number, @year)", connection);
            commandInsertNewspaper.Parameters.AddWithValue("title", newspaper.Title);
            commandInsertNewspaper.Parameters.AddWithValue("number", newspaper.Number);
            commandInsertNewspaper.Parameters.AddWithValue("year", newspaper.PublicationYear);
            commandInsertNewspaper.ExecuteNonQuery();

            string commandText = string.Format("SELECT id FROM newspapers WHERE newspapers.title = '{0}' AND newspapers.number = {1} AND newspapers.year = {2}", newspaper.Title, newspaper.Number, newspaper.PublicationYear);
            SqlCommand commandSelectNewspaper = new SqlCommand(commandText, connection);
            SqlDataReader readerNewspaper = commandSelectNewspaper.ExecuteReader();
            readerNewspaper.Read();
            int newspaperId = readerNewspaper.GetInt32(0);
            readerNewspaper.Close();

            foreach (var genre in newspaper.Genres)
            {
                SqlCommand commandInsertM2MNewspapersGenres = new SqlCommand("INSERT INTO m2m_newspapers_genres (newspaper_id,genre_id)  VALUES (@newspaper_id, @genre_id)", connection);
                commandInsertM2MNewspapersGenres.Parameters.AddWithValue("newspaper_id", newspaperId);
                commandInsertM2MNewspapersGenres.Parameters.AddWithValue("genre_id", (int)genre);
                commandInsertM2MNewspapersGenres.ExecuteNonQuery();
            }

            foreach (var author in newspaper.Authors)
            {
                if (GetAuthorID(author) == null)
                {
                    SqlCommand commandInsertAuthor = new SqlCommand("INSERT INTO authors (name, year) VALUES (@name, @year)", connection);
                    commandInsertAuthor.Parameters.AddWithValue("name", author.Name);
                    commandInsertAuthor.Parameters.AddWithValue("year", author.Year);
                    commandInsertAuthor.ExecuteNonQuery();
                }
                if (GetAuthorID(author) != null)
                {
                    SqlCommand commandInsertM2MNewspapersAuthors = new SqlCommand("INSERT INTO m2m_newspapers_authors (newspaper_id,author_id)  VALUES (@newspaper_id, @author_id)", connection);
                    commandInsertM2MNewspapersAuthors.Parameters.AddWithValue("newspaper_id", newspaperId);
                    commandInsertM2MNewspapersAuthors.Parameters.AddWithValue("author_id", GetAuthorID(author));
                    commandInsertM2MNewspapersAuthors.ExecuteNonQuery();
                }
            }
        }
    }

}

