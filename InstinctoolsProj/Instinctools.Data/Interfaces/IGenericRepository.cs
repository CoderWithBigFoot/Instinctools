using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instinctools.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Func<T, bool> predicate);

        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
    
    
}
