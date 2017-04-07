using System;
using System.Linq;
using System.Data.Entity;
using AutoMapper;

namespace ZKorsakas.Data.EntityFramework
{
    public class Repository<TEntity,TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected TContext _context;

        public Repository(TContext context) {
            if (context == null) { throw new ArgumentNullException("DbContext is null"); }
            this._context = context;
        }

        public IQueryable<TEntity> GetAll() {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> FindBy(Func<TEntity, bool> predicate) {
            return _context.Set<TEntity>().Where(x=>predicate(x));
        }

        public TEntity GetElementById(int id) {
            return _context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity) {
            this._context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity) {
            if (_context == null) { throw new Exception("DbContext is null"); }
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity) {
            this._context.Set<TEntity>()?.Remove(entity);
        }
    }
}
