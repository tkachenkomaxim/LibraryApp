﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Newspaper : Publication
    {
        public int Number { get; set; }

        public Newspaper(string title, int number, Genre genre, int publicationYear) : base(title, genre, publicationYear)
        {
            Number = number;
        }
    }
}
