using System;
using System.Collections.Generic;

namespace LibraryApp
{
    class Library
    {
        private List<Publication> _library;
        private Presenter _presenter;

        public Library()
        {
            _presenter = new Presenter();
            _library = new List<Publication>();
            CreateLibrary();
            _presenter.ShowLibrary(_library);
        }

        private void CreateLibrary()
        {
            _library.Add(new Book("Daniel Keyes", "Flowers for Algernon", Genre.ScienceFiction, 1966));
            _library.Add(new Book("Harper Lee", "To Kill a Mockingbird", Genre.Bildungsroman, 1960));
            _library.Add(new Book("Mario Puzo", "The Godfather", Genre.Crime, 1969));
            _library.Add(new Book("Jeffrey Richter", "CLR Via C#", Genre.Technical, 2006));
            _library.Add(new Book("Oscar Wilde", "The Picture of Dorian Gray", Genre.Philosophical, 1890));
            _library.Add(new Book("Stephen King", "11/22/63", Genre.Alternative, 2011));

            _library.Add(new Magazine("Esquire", 33, Genre.Fashion, 2017));
            _library.Add(new Magazine("National Geographic", 208, Genre.Nature, 2017));
            _library.Add(new Magazine("Business Journal", 11, Genre.Economic, 2017));
            _library.Add(new Magazine("Ecliva", 107, Genre.Electronic, 2016));
            _library.Add(new Magazine("ІJECСТ", 71, Genre.Electronic, 2017));
            _library.Add(new Magazine("J.UCS", 25, Genre.Technical, 2015));
            
        }

    }
}
