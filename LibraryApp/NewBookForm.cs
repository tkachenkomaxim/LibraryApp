using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class NewBookForm : Form
    {
        private Library library;
        public NewBookForm(Library library)
        {
            this.library = library;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Genre> genre = new List<Genre>();
            string[] authors = authorTextBox.Text.Split(',');
            string title = titleTextBox.Text;
            int year = Convert.ToInt32(yearTextBox.Text);
            
            for (int i = 0; i < genreGroupBox.Controls.Count; i++)
            {
                CheckBox checkBox = genreGroupBox.Controls[i] as CheckBox;
                if (checkBox.Checked)
                {
                   genre.Add((Genre) Enum.Parse(typeof(Genre), checkBox.Text));
                }
            }
            Book book = new Book(title, genre, year, authors);
            library.AddNewBookToDatabase(book);
            MessageBox.Show("New book add!","OK!",MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
