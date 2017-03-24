using System;
using System.Collections.Generic;
using System.Linq;
using ZhenyaKorsakas.Data.Entities;

namespace ZhenyaKorsakas.Services.Interfaces
{
   public interface IEntityService<TEntity>: IService 
        where TEntity: BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Find(Func<TEntity, bool> predicate);

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        void SortBy(Func<TEntity, object> field);
    }
}
