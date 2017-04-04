using System;
using System.Collections.Generic;
using BookStore.Data.EntityFramework.Entities;

namespace BookStore.Business
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<Author> FindAuthorsBy(Func<Author, bool> predicate);

        Author FindAuthorById(int id);
    }
}
