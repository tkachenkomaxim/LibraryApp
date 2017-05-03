using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Abstract;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LibraryApp
{
    class AddMagazinePresenter
    {
        private IAddMagazineView _form;
        private Library _library;

        public AddMagazinePresenter(IAddMagazineView form, Library library)
        {
            _form = form;
            _library = library;
            _form.AddMagazine += Form_AddBook;
        }

        private void Form_AddBook(object sender, EventArgs e)
        {
            List<Author> authorsTemp = new List<Author>();
            List<Genre> genre = new List<Genre>();
            string title = _form.Title.Text;
            int number = Convert.ToInt32(_form.Number.Text);
            int year = Convert.ToInt32(_form.Year.Text);

            for (int i = 0; i < _form.Genres.Controls.Count; i++)
            {
                CheckBox checkBox = _form.Genres.Controls[i] as CheckBox;
                if (checkBox.Checked)
                {
                    genre.Add((Genre)Enum.Parse(typeof(Genre), checkBox.Text));
                }
            }
            Regex regex = new Regex(@"^authorTextBox\d$");
            for (int i = 0; i < _form.Authors.Controls.Count; i++)
            {
                if (regex.IsMatch(_form.Authors.Controls[i].Name))
                {
                    if (_form.Authors.Controls[i].Text != "")
                    {
                        string name = _form.Authors.Controls[i].Text;
                        int authorYear = Convert.ToInt32(_form.Authors.Controls[string.Format("{0}Year", _form.Authors.Controls[i].Name)].Text);
                        authorsTemp.Add(new Author(name, authorYear));
                    }
                }
            }
            Author[] authors = new Author[authorsTemp.Count];
            authorsTemp.CopyTo(authors);
            Magazine magazine = new Magazine(title,number,genre,year,authors);

            _library.connection.Open();
            _library.AddNewMagazineToDatabase(magazine);
            _library.connection.Close();

            MessageBox.Show("New magazine add!", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ((Form)_form).Close();
        }
    }
}
