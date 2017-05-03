using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp.Abstract
{
     interface ILibraryFormView
    {
        DataGridView BooksDataGridView { get;}
        DataGridView MagazinesDataGridView { get;}
        DataGridView NewspapersDataGridView { get;}

        TextBox SearchTextBox { get;}

        event EventHandler Search;
        event EventHandler Back;

        event EventHandler NewBook;
        event EventHandler EditBook;

        event EventHandler NewMagazine;
        event EventHandler EditMagazines;

        event EventHandler NewNewspaper;
        event EventHandler EditNewspapers;
    }
}
