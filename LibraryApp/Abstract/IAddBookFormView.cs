using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp.Abstract
{
    interface IAddBookView
    {
        TextBox Title { get; }
        TextBox Year { get; }

        GroupBox Genres { get; }
        GroupBox Authors { get; }

        event EventHandler AddBook;
    }
}
