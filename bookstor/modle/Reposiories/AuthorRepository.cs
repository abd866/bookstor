using System.Collections.Generic;
using System.Linq;

namespace bookstor.modle.Reposiories
{
    

    
    public class AuthorRepository : ibookStore<Author>

    {
        IList<Author> authors;

        public AuthorRepository()
        {
            authors = new List<Author>() { 
            
             new Author{id=1,fullname="Eldosoqy"},
             new Author{id=2,fullname="KHalid ELsaadni"},
             new Author{id=3,fullname="EL zero"},

            };
        }
        public void Add(Author entity)
        {
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(a => a.id == id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public void Update(int id, Author newAuthor)
        {
            var author = Find(id);
            author.fullname = newAuthor.fullname;
        }
    }
}
