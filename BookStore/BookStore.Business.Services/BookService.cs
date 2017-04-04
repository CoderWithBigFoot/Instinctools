using System;
using System.Collections.Generic;
using BookStore.Data.EntityFramework;
using BookStore.Data.EntityFramework.Entities;
using BookStore.Data.EntityFramework.Contexts;

namespace BookStore.Business.Services
{
    public class BookService : IBookService
    {
        protected BookStoreUow _bookStoreUow;

        public BookService(string connectionString)
        {
            _bookStoreUow = new BookStoreUow(new BookStoreContext(connectionString));
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookStoreUow.BookRepository.GetAll();
        }

        public IEnumerable<Book> FindBooksBy(Func<Book, bool> predicate)
        {
            return _bookStoreUow.BookRepository.FindBy(predicate);
        }

        public Book FindBookById(int id)
        {
            return _bookStoreUow.BookRepository.GetElementById(id);
        }
    }
}
