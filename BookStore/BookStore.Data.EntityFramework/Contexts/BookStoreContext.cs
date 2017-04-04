using System.Data.Entity;
using BookStore.Data.EntityFramework.Entities;

namespace BookStore.Data.EntityFramework.Contexts
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext() :base() { }
        public BookStoreContext(string connectionString = "name=BookStoreDb") : base(connectionString) { }

        public DbSet<Book> Books { set; get; }
        public DbSet<Author> Authors { set; get; }
    }
}
