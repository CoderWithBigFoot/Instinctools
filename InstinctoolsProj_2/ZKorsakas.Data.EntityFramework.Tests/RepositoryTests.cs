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
        [TestMethod]
        public void Commit_ShouldSaveChanges_CallSaveChanges() {
            var mockContext = new Mock<HumanContext>();
            mockContext.Setup(x => x.SaveChanges());
            var uow = new UnitOfWork(mockContext.Object);

            uow.Commit();

            mockContext.Verify(x => x.SaveChanges(),Times.AtLeast(1));
        }
        
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

        [TestMethod]
        public void Add_AddingObject_CountNotAZero()
        {
            this.Add_AddingObject_CountNotAZero_Helper<Human, HumanContext>();
        }

        private void Add_AddingObject_CountNotAZero_Helper<TEntity, TContext>()
            where TEntity : class, IEntity
            where TContext : DbContext
        {
            var mockContext = new Mock<TContext>();
            var mockDbSet = new Mock<DbSet<TEntity>>();
            mockContext.Setup(x => x.Set<TEntity>())
                .Returns(mockDbSet.Object);      
            var repository = new Repository<TEntity, TContext>(mockContext.Object);
            
            var test_1 = new Mock<TEntity>();

            try
            {
                repository.Add(test_1.Object);
                mockDbSet.Verify(x => x.Add(It.IsAny<TEntity>()), Times.Once);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            //Assert.AreNotEqual(mockContext.Object.Set<TEntity>().Count(), 0);
        }

        [TestMethod]
        public void Update_UpdatingObject_EntityStateIsModified()
        {
            Update_UpdatingObject_EntityStateIsModified_Helper<Human, HumanContext>();
        }

        private void Update_UpdatingObject_EntityStateIsModified_Helper<TEntity,TContext>()
             where TEntity :  class, IEntity
             where TContext : DbContext
        {
            var mockContext = new Mock<TContext>();
            mockContext.Setup(x => x.Set<TEntity>())
                .Returns(Mock.Of<DbSet<TEntity>>);
            mockContext.Setup(x => x.SaveChanges());

            var repository = new Repository<TEntity, TContext>(mockContext.Object);

            var test_1 = new Mock<TEntity>();
            test_1.Setup(x => x.Id).Returns(123);

            try
            {


            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Delete_DeleteObject_CountIsZero()
        {
            this.Delete_DeleteObject_CountIsZero_Helper<Human, HumanContext>();
        }

        private void Delete_DeleteObject_CountIsZero_Helper<TEntity, TContext>()
             where TEntity : class, IEntity
             where TContext : DbContext
        {
            var mockContext = new Mock<TContext>();
            mockContext.Setup(x => x.Set<TEntity>()).Returns(Mock.Of<DbSet<TEntity>>());
                
            var repository = new Repository<TEntity, TContext>(mockContext.Object);

            var test_1 = new Mock<TEntity>();

            try
            {
                repository.Delete(test_1.Object);         
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}
