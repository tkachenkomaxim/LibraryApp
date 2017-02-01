using System;
using System.Collections.Generic;

namespace LibraryApp
{
    class Library
    {
        private List<Book> _library;

        public Library()
        {
            _library = new List<Book>();
            CreateLibrary();
            Presenter.ShowLibrary(_library);
        }

        private void CreateLibrary()
        {
            _library.Add(new Book("Daniel Keyes", "Flowers for Algernon", Genre.ScienceFiction, 1966));
            _library.Add(new Book("Harper Lee", "To Kill a Mockingbird", Genre.Bildungsroman, 1960));
            _library.Add(new Book("Mario Puzo", "The Godfather", Genre.Crime, 1969));
            _library.Add(new Book("Jeffrey Richter", "CLR Via C#", Genre.Technical, 2006));
            _library.Add(new Book("Oscar Wilde", "The Picture of Dorian Gray", Genre.Philosophical, 1890));
            _library.Add(new Book("Stephen King", "11/22/63", Genre.Alternative, 2011));
        }

    }
}
