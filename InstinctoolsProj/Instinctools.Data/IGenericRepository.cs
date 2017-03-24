using System;
using System.Linq;
using ZhenyaKorsakas.Data.Entities;
using System.Collections.Generic;
namespace ZhenyaKorsakas.Data
{
   public interface IGenericRepository<TEntity,TKey> where TEntity: BaseEntity<TKey>
    {
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(Func<TEntity, bool> predicate);

        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
        void Sort(Func<TEntity, object> field);
    }
}
