using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibraryApp.Abstract;

namespace LibraryApp
{
    public partial class EditBooksForm : Form, IEditFormView
    {
        public event EventHandler Back;
        public event EventHandler Delete;
        public event EventHandler Update;

        public DataGridView PublicationsDataGridView
        {
            get
            {
                return booksDataGridView;
            }
        }

        public EditBooksForm(Library library)
        {
            InitializeComponent();
            new EditFormPresenter(this, typeof(Book), library);
            //dataManager.UpdateData();
            //dataManager.DeleteData();
            booksDataGridView.CellEnter += BooksDataGridView_CellEnter;
            booksDataGridView.UserDeletingRow += BooksDataGridView_UserDeletingRow;
        }

        private void BooksDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Delete(sender, e);
        }

        private void BooksDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Update(sender, e);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Delete(sender, e);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Update(sender, e);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Back(sender, e);
        }
    }
}
