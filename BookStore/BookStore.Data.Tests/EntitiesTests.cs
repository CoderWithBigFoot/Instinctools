using BookStore.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStore.Data.Tests
{
    [TestClass]
    public class EntitiesTests
    {
        private void CheckProperty(string propertyName, Type baseType, Type propertyType)
        {
            Assert.AreEqual(baseType.GetProperty(propertyName).PropertyType, propertyType);
        }

        [TestMethod]
        public void AuthorEntity_HasNeededPopertiesWithPublicSetGet()
        {
            var authorType = typeof(Author);
            var propertyList = authorType.GetProperties();
            var propertyNames = authorType.GetProperties().Select(x => x.Name);

            foreach(var current in propertyList)
            {
                Assert.IsTrue(current.CanRead);
                Assert.IsTrue(current.CanWrite);
            }

            CheckProperty("Id", authorType, typeof(int));
            CheckProperty("Name", authorType, typeof(string));
            CheckProperty("Surname", authorType, typeof(string));
            CheckProperty("Books", authorType, typeof(ICollection<Book>));
        }

        [TestMethod]
        public void BookEntity_SetGetArePublic()
        {
            var bookType = typeof(Book);

            foreach(var current in bookType.GetProperties())
            {
                Assert.IsTrue(current.CanRead);
                Assert.IsTrue(current.CanWrite);
            }

            CheckProperty("Id", bookType, typeof(int));
            CheckProperty("Name", bookType, typeof(string));
            CheckProperty("Pages", bookType, typeof(int));
            CheckProperty("AuthorId", bookType, typeof(int));
            CheckProperty("Author", bookType, typeof(Author));
        }
    }
}
