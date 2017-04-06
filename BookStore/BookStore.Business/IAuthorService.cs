using System;
using System.Collections.Generic;
using BookStore.Business.Dto;
namespace BookStore.Business
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDto> GetAllAuthors();
        IEnumerable<AuthorDto> FindAuthorsBy(Func<AuthorDto, bool> predicate);

        AuthorDto FindAuthorById(int id);
    }
}
