using System.Collections.Generic;

namespace bookstor.modle.Reposiories
{
    public interface ibookStore<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update( int id,TEntity entity);
        void Delete(int id);

    }
}
