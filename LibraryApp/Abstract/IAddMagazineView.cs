using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp.Abstract
{
    interface IAddMagazineView
    {
        TextBox Title { get; }
        TextBox Year { get; }
        TextBox Number { get; }

        GroupBox Genres { get; }
        GroupBox Authors { get; }

        event EventHandler AddMagazine;
    }
}
