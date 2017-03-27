using System;
using System.Linq;

namespace ZhenyaKorsakas.Data
{
   public interface IRepository<TEntity>
        where TEntity: IEntity
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(Func<TEntity, bool> predicate);

        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
    }
}