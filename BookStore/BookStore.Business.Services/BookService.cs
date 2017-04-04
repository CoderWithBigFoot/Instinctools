using System;
using System.Collections.Generic;
using BookStore.Data.EntityFramework;
using BookStore.Data.EntityFramework.Entities;
using BookStore.Data.EntityFramework.Contexts;
using BookStore.Business.Dto;
using AutoMapper;

namespace BookStore.Business.Services
{
    public class BookService : IBookService
    {
        protected BookStoreUow _bookStoreUow;

        public BookService(string connectionString)
        {
            _bookStoreUow = new BookStoreUow(new BookStoreContext(connectionString));
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            return Mapper.Map<IEnumerable<BookDto>>(_bookStoreUow.BookRepository.GetAll());
        }

        public IEnumerable<BookDto> FindBooksBy(Func<BookDto, bool> predicate)
        {
            var bookPredicate = Mapper.Map<Func<Book, bool>>(predicate);
            return Mapper.Map<IEnumerable<BookDto>>(_bookStoreUow.BookRepository.FindBy(bookPredicate));
        }

        public BookDto FindBookById(int id)
        {
            return Mapper.Map<BookDto>(_bookStoreUow.BookRepository.GetElementById(id));
        }
    }
}
