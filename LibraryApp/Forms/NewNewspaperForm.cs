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
    public partial class NewNewspaperForm : Form,IAddNewspaperView
    {
        public NewNewspaperForm(Library library)
        {
            InitializeComponent();
            new AddNewspaperPresenter(this, library);
        }

        GroupBox IAddNewspaperView.Authors
        {
            get
            {
                return authorsGroupBox;
            }
        }

        GroupBox IAddNewspaperView.Genres
        {
            get
            {
                return genreGroupBox;
            }
        }

        TextBox IAddNewspaperView.Number
        {
            get
            {
                return issueNumbertextBox;
            }
        }

        TextBox IAddNewspaperView.Title
        {
            get
            {
                return titleTextBox;
            }
        }

        TextBox IAddNewspaperView.Year
        {
            get
            {
                return yearTextBox;
            }
        }

        public event EventHandler AddNewspaper;

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewspaper(sender, e);
        }
    }
}
