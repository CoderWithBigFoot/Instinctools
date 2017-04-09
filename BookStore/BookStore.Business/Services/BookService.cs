using System;
using System.Collections.Generic;
using BookStore.Business.Dto;
using BookStore.Data;
using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using AutoMapper;

namespace BookStore.Business.Services
{
    public class BookService : IBookService
    {
        protected BookStoreUow _bookStoreUow;

        public BookService(BookStoreContext context)
        {
            _bookStoreUow = new BookStoreUow(context);
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            var result = _bookStoreUow.BookRepository.GetAll();
            return Mapper.Map<IEnumerable<BookDto>>(result);
        }

        public IEnumerable<BookDto> FindBooksBy(Func<BookDto, bool> predicate)
        {
            var bookPredicate = Mapper.Map<Func<Book, bool>>(predicate);
            return Mapper.Map<IEnumerable<BookDto>>(_bookStoreUow.BookRepository.FindBy(bookPredicate));
        }

        public BookDto FindBookById(int id)
        {
            var book = _bookStoreUow.BookRepository.GetElementById(id);
            var result = Mapper.Map<BookDto>(book);
            return result;
        }
    }
}
