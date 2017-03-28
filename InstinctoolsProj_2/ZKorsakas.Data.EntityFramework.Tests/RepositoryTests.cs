using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ZKorsakas.Data.EntityFramework.Tests.Contexts;
using ZKorsakas.Data.EntityFramework.Tests.Models;
using System.Data.Entity;

namespace ZKorsakas.Data.EntityFramework.Tests
{
    [TestClass]
    public class RepositoryTests
    {
       /* [TestMethod]
        public void Commit_ShouldSaveChanges_CallSaveChanges() {
            var mockContext = new Mock<HumanContext>();
            mockContext.Setup(x => x.SaveChanges());
            var uow = new UnitOfWork(mockContext.Object);

            uow.Commit();

            mockContext.Verify(x => x.SaveChanges(),Times.AtLeast(1));
        }
        */

        [TestMethod]
        public void GetAll_GetAllObjects_NotNull()
        {
            GetAll_GotAllObjects_NotNull_Helper<Human, HumanContext>();
        }

        private void GetAll_GotAllObjects_NotNull_Helper<TEntity,TContext>()
            where TContext : DbContext
            where TEntity : class, IEntity
        {
            var mockContext = new Mock<TContext>();
            mockContext.Setup(x => x.Set<TEntity>())
                .Returns(Mock.Of<DbSet<TEntity>>);
                
            var repository = new Repository<TEntity, TContext>(mockContext.Object);

            var result = repository.GetAll();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FindBy_GotObjectsByPredicate_NotNull() {
            FindBy_GotObjectsByPredicate_NotNull_Helper<Human, HumanContext>(x=>x.Id == 1);
        }

        private void FindBy_GotObjectsByPredicate_NotNull_Helper<TEntity,TContext>(Func<TEntity,bool> predicate)
            where TEntity : class, IEntity
            where TContext : DbContext
        {
            var mockContext = new Mock<TContext>();
            mockContext.Setup(x => x.Set<TEntity>())
                .Returns(Mock.Of<DbSet<TEntity>>);
            var repository = new Repository<TEntity, TContext>(mockContext.Object);

            var result = repository.FindBy(predicate);

            Assert.IsNotNull(result);
        }

    }
}
