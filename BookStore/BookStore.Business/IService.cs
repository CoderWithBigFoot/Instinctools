using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZKorsakas.Data.EntityFramework;

namespace BookStore.Business
{
    public interface IService<TEntity>
        where TEntity : Entity
    {
        IEnumerable<TEntity> GetAllElements();
        IEnumerable<TEntity> FindElementsBy(Func<TEntity,bool> predicate);
    }
}
