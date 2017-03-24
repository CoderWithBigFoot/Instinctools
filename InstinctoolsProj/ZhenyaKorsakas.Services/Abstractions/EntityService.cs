using System;
using System.Collections.Generic;
using System.Linq;
using ZhenyaKorsakas.Services.Interfaces;
using ZhenyaKorsakas.Data.Entities;
using ZhenyaKorsakas.Data;

namespace ZhenyaKorsakas.Services.Abstractions
{
    public abstract class EntityService<TEntity> : IEntityService<TEntity>
       where TEntity : BaseEntity
    {
       private IUnitOfWork uow;
       private readonly IGenericRepository<TEntity> repository;

        public EntityService(IUnitOfWork uow, IGenericRepository<TEntity> repository)
        {
            this.uow = uow;
            this.repository = repository;
        }

        public void Create(TEntity entity)
        {
            if (entity == null) { throw new Exception("entity"); }

            this.repository.Add(entity);
            this.uow.Save();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) { throw new Exception("entity"); }

            this.repository.Delete(entity);
            this.uow.Save();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.repository.GetAll();
        }

        public IQueryable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return this.repository.FindBy(x => predicate(x));
        }

        public void SortBy(Func<TEntity, object> field)
        {
            repository.Sort(field);
        }

        public void Update(TEntity entity)
        {
            if (entity == null) { throw new Exception("entity"); }

            repository.Edit(entity);
            uow.Save();
        }
    }
}
