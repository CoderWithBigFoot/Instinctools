﻿using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using ZhenyaKorsakas.Data.Entities;

namespace ZhenyaKorsakas.Data.EntityFramework.Repositories
{
    public class GenericRepository<TEntity,TContext>: IGenericRepository<TEntity>
        where TEntity: BaseEntity,new()
        where TContext: DbContext
    {

        private TContext context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(TContext context) {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public TContext Context {
            get { return this.context; }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet;
        }

        public virtual IQueryable<TEntity> FindBy(Func<TEntity, bool> predicate)
        {
            IQueryable<TEntity> result = dbSet.Where(x => predicate(x));
            return result;
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

        public virtual IOrderedQueryable<TEntity> Sort(Func<TEntity, object> field)
        {
           return this.dbSet.OrderBy(x => field(x));
        }
    }
}
