using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZhenyaKorsakas.Data.EntityFramework.Entities;
using ZhenyaKorsakas.Data.EntityFramework.Contexts;
using ZhenyaKorsakas.Data.EntityFramework.Repositories;
using Moq;
using System.Data.Entity;
namespace ZhekaKorsakas.Data.EntityFramework.Tests
{
    // Use mock object here insted of UnitOfWork object.

    [TestClass]
    public class CheckingGenericRepositoryAsAPartOfUnitOfWorkTests
    {
        [TestMethod]
        public void fields_NullChecking_NotNull()
        {
            UnitOfWork uow = new UnitOfWork(new SomeContext("name=Instinctools.Connection_1"));

        
            Assert.IsNotNull(uow);
            Assert.IsNotNull(uow.Context);
        }

        [TestMethod]
        public void add_AddingNewElement_Added() {
            /*UnitOfWork uow = new UnitOfWork(new SomeContext("name=Instinctools.Connection_1"));
             TestEntity test_1 = new TestEntity { Name = "Smes", Sername = "Korsakas"};*/
            /* TestEntity test_2 = new TestEntity { Name = "1", Sername = "Korsakas" };
             TestEntity test_3 = new TestEntity { Name = "sdasdasdk;m;l"};
             */
            
                      /*  try
                        {
                            uow.TestEntities.Add(test_1);
                            uow.Save();
                            uow.TestEntities.Delete(test_1);
                            uow.Save();
                        }
                        catch (Exception ex) {
                            Assert.Fail(ex.Message);
                        }
                        */

            
            var mockContext = new Mock<SomeContext>();
            var mockCollection = new Mock<DbSet<TestEntity>>();
            mockContext.Setup(x => x.TestEntities).Returns(mockCollection.Object);
            var test_1 = new TestEntity { Name = "m", Sername = "MockSername" };
            var uow = new UnitOfWork(mockContext.Object);

            try
            {
                uow.TestEntities.Add(test_1);
                uow.Save();
            }
            catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
            
            //Assert.AreEqual(uow.TestEntities._dbSet, null);
           

            
        }


        [TestMethod]
        public void getAll_GettingAllElements_Got() {
            UnitOfWork uow = new UnitOfWork(new SomeContext("name=Instinctools.Connection_1"));
            IEnumerable<TestEntity> result = null;

            result = uow.TestEntities.GetAll();
            string lastId = result.Select(prop => prop.Id.ToString()).First();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void delete_RemovingElement_Removed() {
            UnitOfWork uow = new UnitOfWork(new SomeContext("name=Instinctools.Connection_1"));
            TestEntity test_1 = new TestEntity { Name = "UniqueName", Sername = "Removable korsakas" };
            
            try
            {
                uow.TestEntities.Add(test_1);
                uow.Save();
                uow.TestEntities.Delete(test_1);
                uow.Save();
            }
            catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void edit_ElementEditing_Edited() {
            UnitOfWork uow = new UnitOfWork(new SomeContext("name=Instinctools.Connection_1"));
            string sourceSername = "Kononovich";
            string endSername = "Changed sername";
            TestEntity test_1 = new TestEntity { Name = "Sergey", Sername = sourceSername };

            uow.TestEntities.Add(test_1);
            uow.Save();

            test_1.Sername = endSername;
            uow.TestEntities.Edit(test_1);
            uow.Save();

            Assert.AreNotEqual(test_1.Sername, "Kononovich");
            uow.TestEntities.Delete(test_1);
        }
    }
  }

