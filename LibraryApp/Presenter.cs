using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibraryApp
{
   class Presenter
    {
        private MainForm form;

        public Presenter()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new MainForm();
        }
     
       public void ShowLibrary(List<Publication> library)
        {
            foreach (Publication item in library)
            {
                if(item is Magazine)
                {
                    Magazine magazine = (Magazine)item;
                    form.ShowAllLibraryBox.Text += string.Format("Magazine title: «{0}» \r\n ", magazine.Title);
                    form.ShowAllLibraryBox.Text += string.Format("Issue number: {0} \r\n", magazine.IssueNumber);
                    form.ShowAllLibraryBox.Text += string.Format("Genre: {0} \r\n", magazine.Genre);
                    form.ShowAllLibraryBox.Text += string.Format("Year: {0} \r\n", magazine.PublicationYear);
                    form.ShowAllLibraryBox.Text += Environment.NewLine;
                }
                if (item is Book)
                {
                    Book book = (Book)item;
                    form.ShowAllLibraryBox.Text += string.Format("Book title: «{0}» \r\n ", book.Title);
                    if (book.Authors.Count == 1)
                    {
                        form.ShowAllLibraryBox.Text += string.Format("Author: {0} \r\n", book.Authors[0]);
                    }
                    if(book.Authors.Count > 1)
                    {
                        string authors = string.Format("Authors: {0}",book.Authors[0]);
                        for (int i = 1; i < book.Authors.Count; i++)
                        {
                            authors += ", " + book.Authors[i];
                        }
                        authors += "\r\n";
                        form.ShowAllLibraryBox.Text += authors;
                    }
                    form.ShowAllLibraryBox.Text += string.Format("Genre: {0} \r\n", book.Genre);
                    form.ShowAllLibraryBox.Text += string.Format("Year: {0} \r\n", book.PublicationYear);
                    form.ShowAllLibraryBox.Text += Environment.NewLine;
                }
                if (item is Newspaper)
                {
                    Newspaper newspaper = (Newspaper)item;
                    form.ShowAllLibraryBox.Text += string.Format("Newspaper title: «{0}» \r\n ", newspaper.Title);
                    form.ShowAllLibraryBox.Text += string.Format("Issue number: {0} \r\n", newspaper.Number);
                    form.ShowAllLibraryBox.Text += string.Format("Genre: {0} \r\n", newspaper.Genre);
                    form.ShowAllLibraryBox.Text += string.Format("Year: {0} \r\n", newspaper.PublicationYear);
                    form.ShowAllLibraryBox.Text += Environment.NewLine;
                }
            }
            Application.Run(form);
        }
    }
}
