using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp.Abstract
{
    interface IEditFormView
    {
        DataGridView PublicationsDataGridView { get; }

        event EventHandler Back;
        event EventHandler Delete;
        event EventHandler Update;
    }
}
