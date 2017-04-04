using System;
using System.Collections.Generic;
using ZKorsakas.Data.EntityFramework;

namespace BookStore.Business
{
    public interface IService<TEntity>
        where TEntity : Entity
    {
        IEnumerable<TEntity> GetAllElements();
        IEnumerable<TEntity> FindElementsBy(Func<TEntity,bool> predicate);

        TEntity FindById(int id);
    }
}
