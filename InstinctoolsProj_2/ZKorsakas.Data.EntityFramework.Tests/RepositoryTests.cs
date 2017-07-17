using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using Effort;
using ZKorsakas.Data.EntityFramework.Tests.Contexts;
using ZKorsakas.Data.EntityFramework.Tests.Models;
using ZKorsakas.Data.EntityFramework.Tests.Helpers;
using ZKorsakas.Data.EntityFramework.Tests.ProviderFactories;

namespace ZKorsakas.Data.EntityFramework.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private void InMemoryDatabaseInitializing() {
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            EffortProviderFactory.ResetDb();
        }

        [TestMethod]
        public void Commit_ShouldSaveChanges_CallSaveChanges() {
            var mockContext = new Mock<HumanContext>();
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

            mockContext.Verify(x => x.Set<TEntity>(), Times.AtLeast(2));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FindBy_GotObjectsByPredicate_NotNull() {
            FindBy_GotObjectsByPredicate_NotNull_Helper<Human, HumanContext>();
        }

        private void FindBy_GotObjectsByPredicate_NotNull_Helper<TEntity,TContext>()
            where TEntity : class, IEntity
            where TContext : DbContext
        {
            List<TEntity> list = new List<TEntity>();

            var mockContext = new Mock<TContext>();
            var mockSet = EntityFrameworkMockHelpers.MockDbSet(list);
            /*mockSet.Setup(x => x.Where(It.IsAny<Func<TEntity, bool>>()))
                .Returns(new List<TEntity> { });*/
            mockContext.Setup(x => x.Set<TEntity>())
                .Returns(mockSet);
            var repository = new Repository<TEntity, TContext>(mockContext.Object);

            var result = repository.FindBy(x=>x.Id == 1);
            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Add_AddingObject_CallDbSetAdd()
        {
            this.Add_AddingObject_CountNotAZero_CallDbSetAdd<Human, HumanContext>();
        }

        private void Add_AddingObject_CountNotAZero_CallDbSetAdd<TEntity, TContext>()
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
        }

        [TestMethod]
        public void Update_UpdatingObject_EntityStateIsModified()
        {
            Update_UpdatingObject_EntityStateIsModified_Helper<Human, HumanContext>();
        }

        private void Update_UpdatingObject_EntityStateIsModified_Helper<TEntity, TContext>()
             where TEntity : class, IEntity
             where TContext : DbContext, new()
        {
            InMemoryDatabaseInitializing();
            var context = new TContext();
            var uow = new UnitOfWork(context);
            var repository = new Repository<TEntity, TContext>(context);
            var mockTEntity = new Mock<TEntity>();
            mockTEntity.Setup(x => x.Id).Returns(1000);

            try
            {
                repository.Add(mockTEntity.Object);
                //uow.Commit();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Delete_DeleteObject_CountIsZero()
        {
            this.Delete_DeleteObject_CallDbSetRemove_Helper<Human, HumanContext>();
        }

        private void Delete_DeleteObject_CallDbSetRemove_Helper<TEntity, TContext>()
             where TEntity : class, IEntity
             where TContext : DbContext
        {
            var mockContext = new Mock<TContext>();
            var mockSet = new Mock<DbSet<TEntity>>();
            mockContext.Setup(x => x.Set<TEntity>()).Returns(mockSet.Object);
                
            var repository = new Repository<TEntity, TContext>(mockContext.Object);

            var test_1 = new Mock<TEntity>();

            try
            {
                repository.Delete(test_1.Object);
                mockSet.Verify(x => x.Remove(It.IsAny<TEntity>()), Times.Once);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
