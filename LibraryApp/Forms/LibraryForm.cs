using LibraryApp.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class LibraryForm : Form, ILibraryFormView
    {
        private Library _library;

        public event EventHandler Search;
        public event EventHandler Back;
        public event EventHandler NewBook;
        public event EventHandler EditBook;
        public event EventHandler NewMagazine;
        public event EventHandler EditMagazines;
        public event EventHandler NewNewspaper;
        public event EventHandler EditNewspapers;

        DataGridView ILibraryFormView.BooksDataGridView
        {
            get
            {
                return booksDataGridView;
            }
        }

        DataGridView ILibraryFormView.MagazinesDataGridView
        {
            get
            {
                return magazinesDataGridView;
            }
        }

        DataGridView ILibraryFormView.NewspapersDataGridView
        {
            get
            {
                return newspapersDataGridView;
            }
        }

        public TextBox SearchTextBox
        {
            get
            {
                return searchTextBox;
            }
        }

        public LibraryForm(Library library)
        {
            _library = library;
            InitializeComponent();
            new LibraryFormPresenter(this, _library);
        }

        private void editBooksButton_Click(object sender, EventArgs e)
        {
            EditBook(sender, e);
        }

        private void newBookButton_Click(object sender, EventArgs e)
        {
            NewBook(sender, e);
        }

        private void editMagazinesButton_Click(object sender, EventArgs e)
        {
            EditMagazines(sender, e);
        }

        private void newMagazineButton_Click(object sender, EventArgs e)
        {
            NewMagazine(sender, e);
        }

        private void newNewspaperbutton_Click(object sender, EventArgs e)
        {
            NewNewspaper(sender, e);
        }

        private void editNewspapersbutton_Click(object sender, EventArgs e)
        {
            EditNewspapers(sender, e);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Search(sender, e);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Back(sender, e);
        }
    }
}
