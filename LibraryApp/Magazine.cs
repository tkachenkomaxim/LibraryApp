using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryApp
{
    public class Magazine : Publication
    {
        public int IssueNumber { get; set; }

        public Magazine() { }

        public Magazine(string title, int issueNumber, Genre genre, int publicationYear) : base(title, genre, publicationYear)
        {
            IssueNumber = issueNumber;
        }
    }
}
