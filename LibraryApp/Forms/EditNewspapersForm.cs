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
    public partial class EditNewspapersForm : Form, IEditFormView
    {
        public event EventHandler Back;
        public event EventHandler Delete;
        public event EventHandler Update;

        public DataGridView PublicationsDataGridView
        {
            get
            {
                return newspapersDataGridView;
            }
        }

        public EditNewspapersForm(Library library)
        {
            InitializeComponent();
            new EditFormPresenter(this, typeof(Newspaper), library);
            newspapersDataGridView.CellEnter += NewspapersDataGridView_CellEnter;
            newspapersDataGridView.UserDeletingRow += NewspapersDataGridView_UserDeletingRow;
        }

        private void NewspapersDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Update(sender, e);
        }

        private void NewspapersDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Delete(sender, e);
        }

        private void deleteNewspaperbutton_Click(object sender, EventArgs e)
        {
            Delete(sender, e);
        }

        private void editNewspaperbutton_Click(object sender, EventArgs e)
        {
            Update(sender, e);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Back(sender, e);
        }
    }
}
