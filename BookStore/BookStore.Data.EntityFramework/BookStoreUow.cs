using System.Data.Entity;
using ZKorsakas.Data.EntityFramework;
using BookStore.Data.EntityFramework.Entities;

namespace BookStore.Data.EntityFramework
{
    public class BookStoreUow : UnitOfWork
    {
        protected DbContext _context;

        protected Repository<Book, DbContext> _booksRepository;
        protected Repository<Author, DbContext> _authorRepository;

        public BookStoreUow(DbContext context) : base(context)
        {
            _context = context;
        }

        public Repository<Book, DbContext> BookRepository => _booksRepository ?? (_booksRepository = new Repository<Book, DbContext>(_context));

        public Repository<Author, DbContext> AuthorRepository => _authorRepository ?? (_authorRepository = new Repository<Author, DbContext>(_context));
        

    }
}
