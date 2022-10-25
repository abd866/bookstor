namespace bookstor.modle
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
    }
}
