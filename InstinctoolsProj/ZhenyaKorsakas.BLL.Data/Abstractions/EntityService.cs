using System;
using System.Collections.Generic;
using System.Linq;
using ZhenyaKorsakas.Data;
using ZhenyaKorsakas.BLL.Interfaces;

namespace ZhenyaKorsakas.BLL.Abstractions
{
    public abstract class EntityService<TEntity> : IEntityService<TEntity>
        where TEntity : Entity
    {
        private IUnitOfWork uow;
        private readonly IRepository<TEntity> repository;

        public EntityService(IUnitOfWork uow, IGenericRepository<TEntity> repository)
        {
            this.uow = uow;
            this.repository = repository;
        }


        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.repository.GetAll();
        }

        public virtual IQueryable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return this.repository.FindBy(x => predicate(x));
        }

        public virtual void Create(TEntity entity)
        {
            if (entity == null) { throw new Exception("entity"); }

            this.repository.Add(entity);
            this.uow.Save();
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null) { throw new Exception("entity"); }

            this.repository.Delete(entity);
            this.uow.Save();
        }

        public virtual void SortBy(Func<TEntity, object> field)
        {
            repository.Sort(field);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null) { throw new Exception("entity"); }

            repository.Edit(entity);
            uow.Save();
        }
    }
}
