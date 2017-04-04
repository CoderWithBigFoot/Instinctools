using System;
using System.Collections.Generic;
using BookStore.Data.EntityFramework;
using BookStore.Data.EntityFramework.Entities;
using BookStore.Data.EntityFramework.Contexts;

namespace BookStore.Business.Services
{
    public class AuthorService : IAuthorService
    {
        protected BookStoreUow _bookStoreUow;

        public AuthorService(string connectionString)
        {
            _bookStoreUow = new BookStoreUow(new BookStoreContext(connectionString));
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _bookStoreUow.AuthorRepository.GetAll();
        }

        public IEnumerable<Author> FindAuthorsBy(Func<Author, bool> predicate)
        {
            return _bookStoreUow.AuthorRepository.FindBy(predicate);
        }

        public Author FindAuthorById(int id)
        {
            return _bookStoreUow.AuthorRepository.GetElementById(id);
        }
    }
}
