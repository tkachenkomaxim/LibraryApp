using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibraryApp
{
   class Presenter
    {
        private MainForm form;
        private LibraryForm form1;
        private Library lib;

        public Presenter(Library library)
        {
            lib = library;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new MainForm();
            form1 = new LibraryForm(library);
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
                    form.ShowAllLibraryBox.Text += string.Format("Genre: {0} \r\n", lib.GetGenresString(magazine));
                    form.ShowAllLibraryBox.Text += string.Format("Year: {0} \r\n", magazine.PublicationYear);
                    form.ShowAllLibraryBox.Text += Environment.NewLine;
                }
                if (item is Book)
                {
                    Book book = (Book)item;
                    form.ShowAllLibraryBox.Text += string.Format("Book title: «{0}» \r\n ", book.Title);
                    form.ShowAllLibraryBox.Text += string.Format("Author: {0} \r\n", lib.GetAuthorsString(book));
                    form.ShowAllLibraryBox.Text += string.Format("Genre: {0} \r\n", lib.GetGenresString(book));
                    form.ShowAllLibraryBox.Text += string.Format("Year: {0} \r\n", book.PublicationYear);
                    form.ShowAllLibraryBox.Text += Environment.NewLine;
                }
                if (item is Newspaper)
                {
                    Newspaper newspaper = (Newspaper)item;
                    form.ShowAllLibraryBox.Text += string.Format("Newspaper title: «{0}» \r\n ", newspaper.Title);
                    form.ShowAllLibraryBox.Text += string.Format("Issue number: {0} \r\n", newspaper.Number);
                    form.ShowAllLibraryBox.Text += string.Format("Genre: {0} \r\n", lib.GetGenresString(newspaper));
                    form.ShowAllLibraryBox.Text += string.Format("Year: {0} \r\n", newspaper.PublicationYear);
                    form.ShowAllLibraryBox.Text += Environment.NewLine;
                }
            }
            Application.Run(form1);
        }
    }
}
