using System;
using System.Linq;
using System.Data.Entity;
using ZhenyaKorsakas.Data;

namespace ZhenyaKorsakas.Data.EntityFramework.Repositories
{
    public class GenericRepository<TEntity,CContext>: IGenericRepository<TEntity>
        where TEntity: class,new()
        where CContext: DbContext
    {

        private CContext context;
        private DbSet<TEntity> dbSet;

        public GenericRepository(CContext context) {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public CContext Context {
            get { return this.context; }
        }
        public DbSet<TEntity> _dbSet {
            get { return this.dbSet; }
        }

        public virtual IQueryable<TEntity> FindBy(Func<TEntity, bool> predicate)
        {
            IQueryable<TEntity> result = dbSet.Where(x => predicate(x));
            return result;
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }


        public virtual TEntity GetSingle(Func<TEntity,bool> predicate) {
            return dbSet.FirstOrDefault(x => predicate(x));
        }


        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Edit(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }
      
    }
    
    
}
