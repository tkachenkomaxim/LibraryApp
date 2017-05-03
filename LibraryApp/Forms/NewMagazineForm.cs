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
    public partial class NewMagazineForm : Form, IAddMagazineView
    {
        public NewMagazineForm(Library library)
        {
            InitializeComponent();
            new AddMagazinePresenter(this, library);
        }

        GroupBox IAddMagazineView.Authors
        {
            get
            {
                return authorsGroupBox;
            }
        }

        GroupBox IAddMagazineView.Genres
        {
            get
            {
                return genreGroupBox;
            }
        }

        TextBox IAddMagazineView.Number
        {
            get
            {
                return issueNumbertextBox;
            }
        }

        TextBox IAddMagazineView.Title
        {
            get
            {
                return titleTextBox;
            }
        }

        TextBox IAddMagazineView.Year
        {
            get
            {
                return yearTextBox;
            }
        }

        public event EventHandler AddMagazine;

        private void button1_Click(object sender, EventArgs e)
        {
            AddMagazine(sender, e);
        }
    }
}
