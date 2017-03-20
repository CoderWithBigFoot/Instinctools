using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instinctools.Data.Interfaces;
using System.Data.Entity;
namespace Instinctools.Data.Abstractions
{
    public abstract class GenericRepository<TEntity, CContext> : IGenericRepository<TEntity> 
        where TEntity : class
        where CContext : DbContext, new() {

        private CContext context;
        // also it's possible to create private DbSet<TEntity> dbSet;
        public GenericRepository(CContext context) {
            this.context = context;
        }

        public CContext Context {
            set { this.context = value; }
            get { return this.context; }
        }


        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public virtual void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        public virtual void Edit(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public virtual IQueryable<TEntity> FindBy(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().Where(x => predicate(x));
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }
        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
    
    
}
