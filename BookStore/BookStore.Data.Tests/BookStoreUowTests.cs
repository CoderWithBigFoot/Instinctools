using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZKorsakas.Data.EntityFramework;
using BookStore.Data.Contexts;
using System.Data.Entity;
using Moq;

namespace BookStore.Data.Tests
{
    [TestClass]
    public class BookStoreUowTests
    {
        [TestMethod]
        public void BooksStoreUow_HasBookRepository()
        {
            var mockBookStoreUow = new Mock<BookStoreUow>();
            var mockDbContext = new Mock<BookStoreContext>();

            var type = typeof(BookStoreUow);
           
            foreach(var current in type.GetProperties())
            {
            }

            mockBookStoreUow.Setup(x => x.AuthorRepository).Returns(
                new Repository<Author, DbContext>(mockDbContext.Object));
            mockBookStoreUow.Setup(x => x.BookRepository).Returns(
                new Repository<Book, DbContext>(mockDbContext.Object));

            Assert.IsNotNull(mockBookStoreUow.Object.AuthorRepository);
            Assert.IsNotNull(mockBookStoreUow.Object.BookRepository);
        }

    }
}
