using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryApp.Abstract;

namespace LibraryApp
{
    class EditFormPresenter
    {
        private Library _library;
        private IEditFormView _form;
        private LibraryDataManager _dataManager;

        public EditFormPresenter(IEditFormView form, Type publicationType, Library library)
        {
            _form = form;
            _library = library;
            _dataManager = new LibraryDataManager(publicationType, _library);
            LoadData();
            _form.Delete += Form_Delete;
            _form.Update += Form_Update;
            _form.Back += Form_Back;
            _dataManager.UpdateData();
            _dataManager.DeleteData();
        }

        private void Form_Back(object sender, EventArgs e)
        {
            ((Form)_form).Close();
        }

        private void Form_Update(object sender, EventArgs e)
        {
            _dataManager.Update();
        }

        private void Form_Delete(object sender, EventArgs e)
        {
            _dataManager.Delete(_form.PublicationsDataGridView.CurrentCell.RowIndex);
        }

        void LoadData()
        {
            _form.PublicationsDataGridView.DataSource = _dataManager.GetData();
        }




    }
}
