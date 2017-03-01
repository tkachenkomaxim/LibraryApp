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
    public partial class EditMagazinesForm : Form
    {
        private BindingSource bindingSource;
        private SqlDataAdapter dataAdapter;
        private DataTable table;
        private LibraryDataManager dataManager;

        public EditMagazinesForm(Library library, LibraryDataManager dataManager, SqlDataAdapter dataAdapter, BindingSource bindingSource, DataTable table)
        {
            InitializeComponent();
            this.dataManager = dataManager;
            this.dataAdapter = dataAdapter;
            this.bindingSource = bindingSource;
            this.table = table;
            dataManager.UpdateData();
            dataManager.DeleteData();
            magazinesDataGridView.CellEnter += MagazinesDataGridView_CellEnter;
            magazinesDataGridView.UserDeletingRow += MagazinesDataGridView_UserDeletingRow;
        }

        private void MagazinesDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            deleteMagazinebutton_Click(sender, e);
        }

        private void MagazinesDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            EditMagazinebutton_Click(sender, e);
        }

        private void EditMagazinesForm_Load(object sender, EventArgs e)
        {
            magazinesDataGridView.DataSource = bindingSource;
            dataManager.GetData();
        }

        private void deleteMagazinebutton_Click(object sender, EventArgs e)
        {
            table.Rows[magazinesDataGridView.CurrentCell.RowIndex].Delete();
            dataAdapter.Update((DataTable)bindingSource.DataSource);
        }

        private void EditMagazinebutton_Click(object sender, EventArgs e)
        {
            dataAdapter.Update((DataTable)bindingSource.DataSource);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
