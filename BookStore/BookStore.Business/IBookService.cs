using System;
using System.Collections.Generic;
using BookStore.Data.EntityFramework.Entities;

namespace BookStore.Business
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> FindBooksBy(Func<Book, bool> predicate);

        Book FindBookById(int id);       
    }
}
