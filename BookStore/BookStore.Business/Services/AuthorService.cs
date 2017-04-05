using System;
using System.Collections.Generic;
using BookStore.Business.Dto;
using BookStore.Data;
using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using AutoMapper;

namespace BookStore.Business.Services
{
    public class AuthorService : IAuthorService
    {
        protected BookStoreUow _bookStoreUow;

        public AuthorService(string connectionString)
        {
            _bookStoreUow = new BookStoreUow(new BookStoreContext(connectionString));
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        { 
            return Mapper.Map<IEnumerable<AuthorDto>>(_bookStoreUow.AuthorRepository.GetAll());
        }

        public IEnumerable<AuthorDto> FindAuthorsBy(Func<AuthorDto, bool> predicate)
        {
            var authorPredicate = Mapper.Map<Func<Author, bool>>(predicate);
            return Mapper.Map<IEnumerable<AuthorDto>>(_bookStoreUow.AuthorRepository.FindBy(authorPredicate));
        }

        public AuthorDto FindAuthorById(int id)
        {
            var author = _bookStoreUow.AuthorRepository.GetElementById(id);
            return Mapper.Map<AuthorDto>(author);
        }
    }
}
