using System.Data.Entity;
using BookStore.Data.Entities;

namespace BookStore.Data.Contexts
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(string connectionString) : base(connectionString) { }
       
        public DbSet<Book> Books { set; get; }
        public DbSet<Author> Authors { set; get; }
    }
}
