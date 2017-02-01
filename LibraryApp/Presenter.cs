using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
   static class Presenter
    {
        public static void ShowLibrary(List<Book> library)
        {
            foreach (Book book in library)
            {
                Console.WriteLine("Author: {0}", book.Author);
                Console.WriteLine("Title: {0}",book.Title);
                Console.WriteLine("Genre: {0}",book.Genre);
                Console.WriteLine("Year: {0}",book.PublicationYear);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
