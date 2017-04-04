using System;
using System.Collections.Generic;
using BookStore.Business.Dto;

namespace BookStore.Business
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks();
        IEnumerable<BookDto> FindBooksBy(Func<BookDto, bool> predicate);

        BookDto FindBookById(int id);       
    }
}
