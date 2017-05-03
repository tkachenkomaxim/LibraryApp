using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryApp.Abstract;

namespace LibraryApp
{
    public partial class NewBookForm : Form, IAddBookView
    {
        public NewBookForm(Library library)
        {
            InitializeComponent();
            new AddBookPresenter(this, library);
        }

        GroupBox IAddBookView.Authors
        {
            get
            {
                return authorsGroupBox;
            }
        }

        GroupBox IAddBookView.Genres
        {
            get
            {
                return genreGroupBox;
            }
        }

        TextBox IAddBookView.Title
        {
            get
            {
                return titleTextBox;
            }
        }

        TextBox IAddBookView.Year
        {
            get
            {
                return yearTextBox;
            }
        }

        public event EventHandler AddBook;

        private void button1_Click(object sender, EventArgs e)
        {
            AddBook(sender, e);
        }
    }
}
