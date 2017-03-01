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
    public partial class EditNewspapersForm : Form
    {
        private BindingSource bindingSource;
        private SqlDataAdapter dataAdapter;
        private DataTable table;
        private LibraryDataManager dataManager;

        public EditNewspapersForm(Library library, LibraryDataManager dataManager, SqlDataAdapter dataAdapter, BindingSource bindingSource, DataTable table)
        {
            InitializeComponent();
            this.dataManager = dataManager;
            this.dataAdapter = dataAdapter;
            this.bindingSource = bindingSource;
            this.table = table;
            dataManager.UpdateData();
            dataManager.DeleteData();
            newspapersDataGridView.CellEnter += NewspapersDataGridView_CellEnter;
            newspapersDataGridView.UserDeletingRow += NewspapersDataGridView_UserDeletingRow;
        }

        private void NewspapersDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            editNewspaperbutton_Click(sender, e);
        }

        private void NewspapersDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            deleteNewspaperbutton_Click(sender, e);
        }

        private void EditNewspapersForm_Load(object sender, EventArgs e)
        {
            newspapersDataGridView.DataSource = bindingSource;
            dataManager.GetData();
        }

        private void deleteNewspaperbutton_Click(object sender, EventArgs e)
        {
            table.Rows[newspapersDataGridView.CurrentCell.RowIndex].Delete();
            dataAdapter.Update((DataTable)bindingSource.DataSource);
        }

        private void editNewspaperbutton_Click(object sender, EventArgs e)
        {
            dataAdapter.Update((DataTable)bindingSource.DataSource);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
