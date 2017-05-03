using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Abstract;

namespace LibraryApp
{
    class LibraryFormPresenter
    {
        private Library _library;
        private ILibraryFormView _form;
        private LibraryDataManager _booksDataManager;
        private LibraryDataManager _magazinesDataManager;
        private LibraryDataManager _newspapersDataManager;

        public LibraryFormPresenter(ILibraryFormView form, Library library)
        {
            _form = form;
            _library = library;
            _booksDataManager = new LibraryDataManager(typeof(Book), _library);
            _magazinesDataManager = new LibraryDataManager(typeof(Magazine), _library);
            _newspapersDataManager = new LibraryDataManager(typeof(Newspaper), _library);
            LoadLibary();
            _form.Search += Form_Search;
            _form.Back += Form_Back;
            _form.NewBook += Form_NewBook;
            _form.EditBook += Form_EditBook;
            _form.NewMagazine += Form_NewMagazine;
            _form.EditMagazines += Form_EditMagazines;
            _form.NewNewspaper += Form_NewNewspaper;
            _form.EditNewspapers += Form_EditNewspapers;
        }

        private void Form_EditNewspapers(object sender, EventArgs e)
        {
            EditNewspapersForm form = new EditNewspapersForm(_library);
            form.Show();
        }

        private void Form_NewNewspaper(object sender, EventArgs e)
        {
            NewNewspaperForm form = new NewNewspaperForm(_library);
            form.Show();
        }

        private void Form_EditMagazines(object sender, EventArgs e)
        {
            EditMagazinesForm form = new EditMagazinesForm(_library);
            form.Show();
        }

        private void Form_NewMagazine(object sender, EventArgs e)
        {
            NewMagazineForm form = new NewMagazineForm(_library);
            form.FormClosing += NewMagazine_FormClosing;
            form.Show();
        }

        private void NewMagazine_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            LoadMagazines();
        }

        private void Form_EditBook(object sender, EventArgs e)
        {
            EditBooksForm form = new EditBooksForm(_library);
            form.Show();
        }

        private void Form_NewBook(object sender, EventArgs e)
        {
            NewBookForm form = new NewBookForm(_library);
            form.FormClosed += NewBook_FormClosed;
            form.Show();
        }

        private void NewBook_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            LoadBooks();
        }

        private void Form_Back(object sender, EventArgs e)
        {
            LoadLibary();
        }

        private void Form_Search(object sender, EventArgs e)
        {
            string authorName = _form.SearchTextBox.Text;

            _booksDataManager.SearchByAuthor(authorName);
            _form.BooksDataGridView.Update();

            _magazinesDataManager.SearchByAuthor(authorName);
            _form.MagazinesDataGridView.Update();

            _newspapersDataManager.SearchByAuthor(authorName);
            _form.NewspapersDataGridView.Update();
        }

        void LoadLibary()
        {
            LoadBooks();
            LoadMagazines();
            LoadNewspapers();
        }

        void LoadBooks()
        {
            _form.BooksDataGridView.DataSource = _booksDataManager.GetData();
        }

        void LoadMagazines()
        {
            _form.MagazinesDataGridView.DataSource = _magazinesDataManager.GetData();
        }

        void LoadNewspapers()
        {
            _form.NewspapersDataGridView.DataSource = _newspapersDataManager.GetData();
        }
    }
}
