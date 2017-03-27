using System;
using System.Linq;
using System.Data.Entity;

namespace ZKorsakas.Data.EntityFramework
{
    public class Repository<TEntity,TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected TContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(TContext context) {
            this._context = context;
        }

        public IQueryable<TEntity> GetAll() {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> FindBy(Func<TEntity, bool> predicate) {
            return _context.Set<TEntity>();
        }

        public void Add(TEntity entity) {
            this._context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity) {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity) {
            this._context.Set<TEntity>().Remove(entity);
        }
    }
}
