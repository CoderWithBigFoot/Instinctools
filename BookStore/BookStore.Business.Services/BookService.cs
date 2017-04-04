using System;
using System.Collections.Generic;
using BookStore.Data.EntityFramework;
using BookStore.Data.EntityFramework.Entities;
using BookStore.Data.EntityFramework.Contexts;

namespace BookStore.Business.Services
{
    public class BookService : IBookService<Book>
    {
        protected BookStoreUow _bookStoreUow;

        public BookService(string connectionString)
        {
            _bookStoreUow = new BookStoreUow(new BookStoreContext(connectionString));
        }

        public IEnumerable<Book> GetAllElements()
        {
            return _bookStoreUow.BookRepository.GetAll();
        }

        public IEnumerable<Book> FindElementsBy(Func<Book, bool> predicate)
        {
            return _bookStoreUow.BookRepository.FindBy(predicate);
        }
    }
}
