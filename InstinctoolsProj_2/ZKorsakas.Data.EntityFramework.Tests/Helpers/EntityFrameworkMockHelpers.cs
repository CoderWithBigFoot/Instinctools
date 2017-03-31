using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Data.Entity;

namespace ZKorsakas.Data.EntityFramework.Tests.Helpers
{
    public static class EntityFrameworkMockHelpers
    {
        public static DbSet<TEntity> MockDbSet<TEntity>(List<TEntity> collection)
            where TEntity : class, IEntity
        {
            var dbSet =new Mock<DbSet<TEntity>>(MockBehavior.Strict);

            dbSet.As<IQueryable<TEntity>>().Setup(x => x.Provider).Returns(() => collection.AsQueryable().Provider);
            dbSet.As<IQueryable<TEntity>>().Setup(q => q.Expression).Returns(() => collection.AsQueryable().Expression);
            dbSet.As<IQueryable<TEntity>>().Setup(q => q.ElementType).Returns(() => collection.AsQueryable().ElementType);
            dbSet.As<IQueryable<TEntity>>().Setup(q => q.GetEnumerator()).Returns(() => collection.AsQueryable().GetEnumerator());

            return dbSet.Object;
        }
    }
}
