using System;
using System.Collections.Generic;
using BookStore.Data.EntityFramework;
using BookStore.Data.EntityFramework.Entities;
using BookStore.Data.EntityFramework.Contexts;


namespace BookStore.Business.Services
{
    public class AuthorService : IAuthorService<Author>
    {
        protected BookStoreUow _bookStoreUow;

        public AuthorService(string connectionString)
        {
            _bookStoreUow = new BookStoreUow(new BookStoreContext(connectionString));
        }

        public IEnumerable<Author> GetAllElements()
        {
            return _bookStoreUow.AuthorRepository.GetAll();
        }

        public IEnumerable<Author> FindElementsBy(Func<Author, bool> predicate)
        {
            return _bookStoreUow.AuthorRepository.FindBy(predicate);
        }
    }
}
