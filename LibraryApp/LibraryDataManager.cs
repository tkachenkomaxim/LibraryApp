using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    public class LibraryDataManager
    {
        private Type _publicationType;
        private Library _library;
        private BindingSource _bindingSource;
        private SqlDataAdapter _dataAdapter;
        private DataTable _table;
        

        public LibraryDataManager(Type publicationType, Library library)
        {
            _library = library;
            _publicationType = publicationType;
            _bindingSource = new BindingSource();
            _dataAdapter = new SqlDataAdapter();
            _table = new DataTable();
        }

        public void Update()
        {
            _dataAdapter.Update((DataTable)_bindingSource.DataSource);
        }

        public void Delete(int rowIndex)
        {
            _table.Rows[rowIndex].Delete();
            _dataAdapter.Update((DataTable)_bindingSource.DataSource);
        }

        public void SearchByAuthor(string authorName)
        {
            SqlCommand command = null;
            _table.Clear();
            if (_publicationType == typeof(Book))
            {
                string commandText = string.Format(@"select books.id,dbo.GROUP_CONCAT_D(distinct authors.name,', ') as Authors ,
                                                     books.title,books.year, dbo.GROUP_CONCAT_D(distinct genres.genre,', ') as Genre 
                                                     from books left join m2m_books_genres on books.id = m2m_books_genres.book_id 
                                                     left join genres on m2m_books_genres.genre_id = genres.id  
                                                     left join m2m_books_authors on books.id = m2m_books_authors.book_id  
                                                     left join authors on authors.id = m2m_books_authors.author_id 
                                                     WHERE authors.name LIKE '%{0}%'
                                                     GROUP BY books.id, books.title,books.year;", authorName);
                command = new SqlCommand(commandText, _library.connection);
            }

            if (_publicationType == typeof(Magazine))
            {
                string commandText = string.Format(@"select magazines.id, dbo.GROUP_CONCAT_D(distinct authors.name,', ') as Authors ,
                                                     magazines.title, magazines.number, magazines.year, dbo.GROUP_CONCAT_D(distinct genres.genre,', ') as Genre
                                                     from magazines left join m2m_magazines_genres on magazines.id = m2m_magazines_genres.magazine_id 
                                                     left join genres on m2m_magazines_genres.genre_id = genres.id 
                                                     left join m2m_magazines_authors on magazines.id = m2m_magazines_authors.magazine_id 
                                                     left join authors on authors.id = m2m_magazines_authors.author_id 
                                                     WHERE authors.name LIKE '%{0}%'
                                                     GROUP BY magazines.id, magazines.title,magazines.number, magazines.year", authorName);
                command = new SqlCommand(commandText, _library.connection);
            }

            if (_publicationType == typeof(Newspaper))
            {
                string commandText = string.Format(@"select newspapers.id, dbo.GROUP_CONCAT_D(distinct authors.name,', ') as Authors ,
                                                     newspapers.title, newspapers.number, newspapers.year, dbo.GROUP_CONCAT_D(distinct genres.genre,', ') as Genre
                                                     from newspapers left join m2m_newspapers_genres on newspapers.id = m2m_newspapers_genres.newspaper_id 
                                                     left join genres on m2m_newspapers_genres.genre_id = genres.id 
                                                     left join m2m_newspapers_authors on newspapers.id = m2m_newspapers_authors.newspaper_id 
                                                     left join authors on authors.id = m2m_newspapers_authors.author_id 
                                                     WHERE authors.name LIKE '%{0}%'
                                                     GROUP BY newspapers.id, newspapers.title, newspapers.number, newspapers.year", authorName);
                command = new SqlCommand(commandText, _library.connection);
            }

            _dataAdapter = new SqlDataAdapter(command);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(_dataAdapter);
            _table.Locale = CultureInfo.InvariantCulture;
            _dataAdapter.Fill(_table);
            _bindingSource.DataSource = _table;
        }

        public BindingSource GetData()
        {
            _table.Clear();
            string selectCommand = null;
            if (_publicationType == typeof(Book))
            {
                selectCommand = @"select books.id,dbo.GROUP_CONCAT_D(distinct authors.name,', ') as Authors ,
                                  books.title,books.year, dbo.GROUP_CONCAT_D(distinct genres.genre,', ') as Genre
                                  from books left join m2m_books_genres on books.id = m2m_books_genres.book_id 
                                  left join genres on m2m_books_genres.genre_id = genres.id 
                                  left join m2m_books_authors on books.id = m2m_books_authors.book_id 
                                  left join authors on authors.id = m2m_books_authors.author_id 
                                  GROUP BY books.id, books.title,books.year";
            }
            if (_publicationType == typeof(Magazine))
            {
                selectCommand = @"select magazines.id, dbo.GROUP_CONCAT_D(distinct authors.name,', ') as Authors ,
                                  magazines.title, magazines.number, magazines.year, dbo.GROUP_CONCAT_D(distinct genres.genre, ', ') as Genre
                                  from magazines left join m2m_magazines_genres on magazines.id = m2m_magazines_genres.magazine_id
                                  left join genres on m2m_magazines_genres.genre_id = genres.id
                                  left join m2m_magazines_authors on magazines.id = m2m_magazines_authors.magazine_id
                                  left join authors on authors.id = m2m_magazines_authors.author_id
                                  GROUP BY magazines.id, magazines.title,magazines.number, magazines.year";
            }
            if (_publicationType == typeof(Newspaper))
            {
                selectCommand = @"select newspapers.id, dbo.GROUP_CONCAT_D(distinct authors.name,', ') as Authors ,
                                  newspapers.title, newspapers.number, newspapers.year, dbo.GROUP_CONCAT_D(distinct genres.genre,', ') as Genre
                                  from newspapers left join m2m_newspapers_genres on newspapers.id = m2m_newspapers_genres.newspaper_id 
                                  left join genres on m2m_newspapers_genres.genre_id = genres.id 
                                  left join m2m_newspapers_authors on newspapers.id = m2m_newspapers_authors.newspaper_id 
                                  left join authors on authors.id = m2m_newspapers_authors.author_id 
                                  GROUP BY newspapers.id, newspapers.title, newspapers.number, newspapers.year";
            }
            string connectionString = _library.connection.ConnectionString;
            _dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(_dataAdapter);
            _table.Locale = CultureInfo.InvariantCulture;
            _dataAdapter.Fill(_table);
            _bindingSource.DataSource = _table;
            return _bindingSource;
        }

        public void UpdateData()
        {
            SqlCommand command = null;
            if (_publicationType == typeof(Book))
            {
                command = new SqlCommand(
                "UPDATE books SET title = @title, year = @year WHERE ID = @oldID", _library.connection);

                command.Parameters.Add("@title", SqlDbType.NVarChar, 50, "title");
                command.Parameters.Add("@year", SqlDbType.Int, 5, "year");
            }

            if(_publicationType == typeof(Magazine))
            {
                command = new SqlCommand(
                "UPDATE magazines SET number = @number, title = @title, year = @year WHERE ID = @oldID", _library.connection);

                command.Parameters.Add("@number", SqlDbType.Int, 5, "number");
                command.Parameters.Add("@title", SqlDbType.NVarChar, 50, "title");
                command.Parameters.Add("@year", SqlDbType.Int, 5, "year");
            }
         
            if(_publicationType == typeof(Newspaper))
            {
                command = new SqlCommand(
                "UPDATE newspapers SET number = @number, title = @title, year = @year WHERE ID = @oldID", _library.connection);

                command.Parameters.Add("@number", SqlDbType.Int, 5, "number");
                command.Parameters.Add("@title", SqlDbType.NVarChar, 50, "title");
                command.Parameters.Add("@year", SqlDbType.Int, 5, "year");
            }
            SqlParameter parameter = command.Parameters.Add("@oldID", SqlDbType.Int, 5, "ID");
            parameter.SourceVersion = DataRowVersion.Original;
            _dataAdapter.UpdateCommand = command;
        }

        public void DeleteData()
        {
            SqlCommand command = null;
            if (_publicationType == typeof(Book))
            {
                command = new SqlCommand(@"DELETE FROM m2m_books_authors WHERE book_id = @ID; 
                                           DELETE FROM m2m_books_genres WHERE book_id = @ID;
                                           DELETE FROM books WHERE ID = @ID; ", _library.connection);
            }

            if (_publicationType == typeof(Magazine))
            {
                command = new SqlCommand(@"DELETE FROM m2m_magazines_authors WHERE magazine_id = @ID; 
                                           DELETE FROM m2m_magazines_genres WHERE magazine_id = @ID;
                                           DELETE FROM magazines WHERE ID = @ID", _library.connection);
            }

            if (_publicationType == typeof(Newspaper))
            {
                command = new SqlCommand(@"DELETE FROM m2m_newspapers_authors WHERE newspaper_id = @ID; 
                                           DELETE FROM m2m_newspapers_genres WHERE newspaper_id = @ID;
                                           DELETE FROM newspapers WHERE ID = @ID", _library.connection);
            }

            SqlParameter parameter = command.Parameters.Add("@ID", SqlDbType.NChar, 5, "ID");
            parameter.SourceVersion = DataRowVersion.Original;
            _dataAdapter.DeleteCommand = command;
        }
    }
}
