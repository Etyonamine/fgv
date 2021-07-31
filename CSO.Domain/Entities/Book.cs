using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO.Domain.Entities
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Edition { get; set; }

        public Book()
        {

        }
        public Book(string title, string author, int edition)
        {
            Title = title;
            Author = author;
            Edition = edition;

        }
        
        
    }

}
