using System.Collections.Generic;
using System.Linq;

namespace bookstor.modle.Reposiories
{
    public class BookRepository : ibookStore<Book>

    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book
                {
                    id=1, Description="no description",title="c# book",Author=new Author()
                },
                 new Book
                {
                    id=2, Description="no data",title="java book",Author=new Author()
                },
                  new Book
                {
                    id=3, Description="nothing",title="python book",Author=new Author()
                },
            };
        }
        public void Add(Book entity)
        {
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(b => b.id == id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update( int id,Book newBook)
        {
            var book = Find(id);
            book.title = newBook.title;
            book.Author = newBook.Author;
            book.Description = newBook.Description;
        }
    }
}
