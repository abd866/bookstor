using bookstor.modle;
using System.Collections.Generic;

namespace bookstor.viewmodles
{
    public class BookAuthorViewModle
    {
        public int BookID { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public int AuhtorID { get; set; }
        public List<Author>authors { get; set; }
    }
}
