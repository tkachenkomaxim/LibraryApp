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
        private Type publicationType;
        private Library library;
        private BindingSource bindingSource;
        private SqlDataAdapter dataAdapter;
        private DataTable table;

        public LibraryDataManager(Type publicationType, Library library, BindingSource bindingSource, SqlDataAdapter dataAdapter, DataTable table)
        {
            this.library = library;
            this.publicationType = publicationType;
            this.bindingSource = bindingSource;
            this.dataAdapter = dataAdapter;
            this.table = table;
        }

        public void SearchByAuthor(string authorName)
        {
            SqlCommand command = null;
            table.Clear();
            if (publicationType == typeof(Book))
            {
                string commandText = string.Format("SELECT * FROM Books WHERE Authors LIKE '%{0}%'",authorName);
                command = new SqlCommand(commandText, library._connection);
            }

            if (publicationType == typeof(Magazine))
            {
                string commandText = string.Format("SELECT * FROM Magazines WHERE Authors LIKE '%{0}%'", authorName);
                command = new SqlCommand(commandText, library._connection);
            }

            if (publicationType == typeof(Newspaper))
            {
                string commandText = string.Format("SELECT * FROM Newspapers WHERE Authors LIKE '%{0}%'", authorName);
                command = new SqlCommand(commandText, library._connection);
            }

            dataAdapter = new SqlDataAdapter(command);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            table.Locale = CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            bindingSource.DataSource = table;
        }

        public void GetData()
        {
            table.Clear();
            string selectCommand = null;
            if (publicationType == typeof(Book))
            {
                selectCommand = "SELECT * FROM Books";
            }
            if (publicationType == typeof(Magazine))
            {
                selectCommand = "SELECT * FROM Magazines";
            }
            if (publicationType == typeof(Newspaper))
            {
                selectCommand = "SELECT * FROM Newspapers";
            }
            string connectionString = library._connection.ConnectionString;
            dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            table.Locale = CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            bindingSource.DataSource = table;
        }

        public void UpdateData()
        {
            SqlCommand command = new SqlCommand();
            if (publicationType == typeof(Book))
            {
                command = new SqlCommand(
                "UPDATE Books SET Authors = @Authors, Title = @Title, Genre = @Genre, Year = @Year WHERE ID = @oldID", library._connection);

                command.Parameters.Add("@Authors", SqlDbType.NVarChar, 50, "Authors");
                command.Parameters.Add("@Title", SqlDbType.NVarChar, 50, "Title");
                command.Parameters.Add("@Genre", SqlDbType.NVarChar, 50, "Genre");
                command.Parameters.Add("@Year", SqlDbType.Int, 5, "Year");
            }

            if(publicationType == typeof(Magazine))
            {

                command = new SqlCommand(
                "UPDATE Magazines SET IssueNumber = @IssueNumber, Title = @Title, Genre = @Genre, Year = @Year, Authors = @Authors WHERE ID = @oldID", library._connection);

                command.Parameters.Add("@IssueNumber", SqlDbType.Int, 5, "IssueNumber");
                command.Parameters.Add("@Title", SqlDbType.NVarChar, 50, "Title");
                command.Parameters.Add("@Genre", SqlDbType.NVarChar, 50, "Genre");
                command.Parameters.Add("@Year", SqlDbType.Int, 5, "Year");
                command.Parameters.Add("@Authors", SqlDbType.NVarChar, 50, "Authors");
            }
         
            if(publicationType == typeof(Newspaper))
            {
                command = new SqlCommand(
                "UPDATE Magazines SET Number = @Number, Title = @Title, Genre = @Genre, Year = @Year, Authors = @Authors WHERE ID = @oldID", library._connection);

                command.Parameters.Add("@Number", SqlDbType.Int, 5, "Number");
                command.Parameters.Add("@Title", SqlDbType.NVarChar, 50, "Title");
                command.Parameters.Add("@Genre", SqlDbType.NVarChar, 50, "Genre");
                command.Parameters.Add("@Year", SqlDbType.Int, 5, "Year");
                command.Parameters.Add("@Authors", SqlDbType.NVarChar, 50, "Authors");
            }
            SqlParameter parameter = command.Parameters.Add("@oldID", SqlDbType.Int, 5, "ID");
            parameter.SourceVersion = DataRowVersion.Original;
            dataAdapter.UpdateCommand = command;
        }

        public void DeleteData()
        {
            SqlCommand command = new SqlCommand();
            if (publicationType == typeof(Book))
            {
                command = new SqlCommand("DELETE FROM Books WHERE ID = @ID", library._connection);
            }

            if (publicationType == typeof(Magazine))
            {
                command = new SqlCommand("DELETE FROM Magazines WHERE ID = @ID", library._connection);
            }

            if (publicationType == typeof(Newspaper))
            {
                command = new SqlCommand("DELETE FROM Newspapers WHERE ID = @ID", library._connection);
            }

            SqlParameter parameter = command.Parameters.Add("@ID", SqlDbType.NChar, 5, "ID");
            parameter.SourceVersion = DataRowVersion.Original;
            dataAdapter.DeleteCommand = command;

        }
    }
}
