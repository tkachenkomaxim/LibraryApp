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
    public partial class NewNewspaperForm : Form
    {
        private Library library;
        public NewNewspaperForm(Library library)
        {
            this.library = library;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Genre> genre = new List<Genre>();
            int number = Convert.ToInt32(issueNumbertextBox.Text);
            string[] authors = authorTextBox.Text.Split(',');
            string title = titleTextBox.Text;
            int year = Convert.ToInt32(yearTextBox.Text);

            for (int i = 0; i < genreGroupBox.Controls.Count; i++)
            {
                CheckBox checkBox = genreGroupBox.Controls[i] as CheckBox;
                if (checkBox.Checked)
                {
                    genre.Add((Genre)Enum.Parse(typeof(Genre), checkBox.Text));
                }
            }
            Newspaper newspaper = new Newspaper(title, number, genre, year, authors);
            library.AddNewspaperToDatabase(newspaper);
            MessageBox.Show("New newspaper add!", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
