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

namespace LibraryApp
{
    public partial class EditBooksForm : Form
    {
        private BindingSource bindingSource ;
        private SqlDataAdapter dataAdapter;
        private DataTable table;
        private LibraryDataManager dataManager;

        public EditBooksForm(Library library, LibraryDataManager dataManager, SqlDataAdapter dataAdapter, BindingSource bindingSource, DataTable table)
        {
            InitializeComponent();
            this.dataManager = dataManager;
            this.dataAdapter = dataAdapter;
            this.bindingSource = bindingSource;
            this.table = table;
            dataManager.UpdateData();
            dataManager.DeleteData();
            booksDataGridView.CellEnter += BooksDataGridView_CellEnter;
            booksDataGridView.UserDeletingRow += BooksDataGridView_UserDeletingRow;
        }

        private void BooksDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DeleteButton_Click(sender, e);
        }

        private void BooksDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            EditButton_Click(sender, e);
        }

        private void EditBooksForm_Load(object sender, EventArgs e)
        { 
            booksDataGridView.DataSource = bindingSource;
            dataManager.GetData();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            table.Rows[booksDataGridView.CurrentCell.RowIndex].Delete();
            dataAdapter.Update((DataTable)bindingSource.DataSource);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            dataAdapter.Update((DataTable)bindingSource.DataSource);
        }

        private void beckButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
