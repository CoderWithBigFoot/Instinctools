using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZhenyaKorsakas.Data.EntityFramework.Entities;
using ZhenyaKorsakas.Data.EntityFramework.Contexts;
using ZhenyaKorsakas.Data.EntityFramework.Repositories;
using Moq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace ZhekaKorsakas.Data.EntityFramework.Tests
{
    [TestClass]
    public class CheckingGenericRepositoryAsAPartOfUnitOfWorkTests
    {
        [TestMethod]
        public void NullChecking()
        {
            UnitOfWork uow = new UnitOfWork(new SomeContext("name=Instinctools.Connection_1"));


            Assert.IsNotNull(uow);
            Assert.IsNotNull(uow.Context);
        }

        [TestMethod]
        public void AddChecking() {
            UnitOfWork uow = new UnitOfWork(new SomeContext("name=Instinctools.Connection_1"));
            TestEntity test_1 = new TestEntity { Name = "Somename", Sername = "Korsakas"};
           /* TestEntity test_2 = new TestEntity { Name = "1", Sername = "Korsakas" };
            TestEntity test_3 = new TestEntity { Name = "sdasdasdk;m;l"};
            */

            try
            {
                uow.TestEntities.Add(test_1);
               /* uow.TestEntities.Add(test_2);
                uow.TestEntities.Add(test_3);*/

                uow.Save();

                uow.TestEntities.Delete(test_1);
                /*uow.TestEntities.Delete(test_2);
                uow.TestEntities.Delete(test_3);*/
                uow.Save();
            }
            catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetSingleChecking() {
           UnitOfWork uow = new UnitOfWork(new SomeContext("name=Instinctools.Connection_1"));
            TestEntity test_1 = new TestEntity { Name = "Somename", Sername = "somesername" };
            IQueryable<TestEntity> result;

            try
            {
                uow.TestEntities.Add(test_1);
                uow.Save();
                result = uow.TestEntities.FindBy(x => x.Name == "Somename");

                Assert.IsTrue(uow.TestEntities.FindBy(x => x.Name == "Somename")
                    .Contains(test_1),
                    "Collection doesn's contains entity");

                uow.TestEntities.Delete(test_1);
                uow.Save();
            }
            catch (Exception ex) {
                Assert.Fail(ex.Message);
            }

           


        }

      

    }
}
