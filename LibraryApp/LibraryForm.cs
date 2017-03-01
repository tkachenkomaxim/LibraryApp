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
    public partial class LibraryForm : Form
    {
        private Library library;
        private LibraryDataManager booksDataManager;
        private LibraryDataManager magazinesDataManager;
        private LibraryDataManager newspapersDataManager;

        private SqlDataAdapter booksDataAdapter;
        private SqlDataAdapter magazinesDataAdapter;
        private SqlDataAdapter newspapersDataAdapter;

        private DataTable booksTable;
        private DataTable magazinesTable;
        private DataTable newspapersTable;

        private BindingSource booksBindingSource;
        private BindingSource magazinesBindingSource;
        private BindingSource newspapersBindingSource;

        public LibraryForm(Library library)
        {
            booksDataAdapter = new SqlDataAdapter();
            magazinesDataAdapter = new SqlDataAdapter();
            newspapersDataAdapter = new SqlDataAdapter();
            booksTable = new DataTable();
            magazinesTable = new DataTable();
            newspapersTable = new DataTable();
            booksBindingSource = new BindingSource();
            magazinesBindingSource = new BindingSource();
            newspapersBindingSource = new BindingSource();
            this.library = library;
            booksDataManager = new LibraryDataManager(typeof(Book), library,booksBindingSource,booksDataAdapter,booksTable);
            magazinesDataManager = new LibraryDataManager(typeof(Magazine), library, magazinesBindingSource, magazinesDataAdapter, magazinesTable);
            newspapersDataManager = new LibraryDataManager(typeof(Newspaper), library, newspapersBindingSource,newspapersDataAdapter,newspapersTable);
            InitializeComponent();
        }

        private void LibraryForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadMagazines();
            LoadNewspapers();
        }

        private void LoadBooks()
        {
            booksDataGridView.DataSource = booksBindingSource;
            booksDataManager.GetData();
        }

        private void LoadMagazines()
        {
            magazinesDataGridView.DataSource = magazinesBindingSource;
            magazinesDataManager.GetData();
        }

        private void LoadNewspapers()
        {
            newspapersDataGridView.DataSource = newspapersBindingSource;
            newspapersDataManager.GetData();
        }
        
        private void editBooksButton_Click(object sender, EventArgs e)
        {
            EditBooksForm form = new EditBooksForm(library,booksDataManager,booksDataAdapter,booksBindingSource,booksTable);
            form.Show();
        }

        private void newBookButton_Click(object sender, EventArgs e)
        {
            NewBookForm form = new NewBookForm(library);
            form.FormClosed += NewBookForm_FormClosed;
            form.Show();
        }

        private void NewBookForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadBooks();
        }

        private void editMagazinesButton_Click(object sender, EventArgs e)
        {
            EditMagazinesForm form = new EditMagazinesForm(library, magazinesDataManager, magazinesDataAdapter, magazinesBindingSource, magazinesTable);
            form.Show();
        }

        private void newMagazineButton_Click(object sender, EventArgs e)
        {
            NewMagazineForm form = new NewMagazineForm(library);
            form.FormClosing += NewMagazineForm_FormClosing;
            form.Show();
        }

        private void NewMagazineForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadMagazines();
        }

        private void newNewspaperbutton_Click(object sender, EventArgs e)
        {
            NewNewspaperForm form = new NewNewspaperForm(library);
            form.FormClosing += NewNewspaperForm_FormClosing;
            form.Show();
        }

        private void NewNewspaperForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadNewspapers();
        }

        private void editNewspapersbutton_Click(object sender, EventArgs e)
        {
            EditNewspapersForm form = new EditNewspapersForm(library, newspapersDataManager, newspapersDataAdapter,newspapersBindingSource,newspapersTable);
            form.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string authorName = searchTextBox.Text;
            booksDataManager.SearchByAuthor(authorName);
            booksDataGridView.DataSource = booksBindingSource;
            booksDataGridView.Update();

            magazinesDataManager.SearchByAuthor(authorName);
            magazinesDataGridView.DataSource = magazinesBindingSource;
            magazinesDataGridView.Update();

            newspapersDataManager.SearchByAuthor(authorName);
            newspapersDataGridView.DataSource = newspapersBindingSource;
            newspapersDataGridView.Update();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LoadBooks();
            LoadMagazines();
            LoadNewspapers();
        }
    }
}
