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

        public Magazine(string title, int issueNumber, List<Genre> genres, int publicationYear, params string[] authors) : base(title, genres, publicationYear,authors)
        {
            IssueNumber = issueNumber;
        }
    }
}
