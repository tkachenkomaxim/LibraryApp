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
    public partial class EditMagazinesForm : Form, IEditFormView
    {
        public event EventHandler Back;
        public event EventHandler Delete;
        public event EventHandler Update;

        public DataGridView PublicationsDataGridView
        {
            get
            {
                return magazinesDataGridView;
            }
        }
        public EditMagazinesForm(Library library)
        {
            InitializeComponent();
            new EditFormPresenter(this, typeof(Magazine), library);
            magazinesDataGridView.CellEnter += MagazinesDataGridView_CellEnter;
            magazinesDataGridView.UserDeletingRow += MagazinesDataGridView_UserDeletingRow;
        }

        private void MagazinesDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Delete(sender, e);
        }

        private void MagazinesDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Update(sender, e);
        }

        private void deleteMagazinebutton_Click(object sender, EventArgs e)
        {
            Delete(sender, e);
        }

        private void EditMagazinebutton_Click(object sender, EventArgs e)
        {
            Update(sender, e);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Back(sender, e);
        }
    }
}
