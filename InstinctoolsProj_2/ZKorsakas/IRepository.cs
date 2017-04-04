using System;
using System.Linq;

namespace ZKorsakas.Data
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(Func<TEntity,bool> predicate);

        TEntity GetElementById(int id);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
