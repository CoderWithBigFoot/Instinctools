using System.Data.Entity;
using BookStore.Data.Entities;

namespace BookStore.Data.Contexts
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasEntitySetName("Books")
                .HasKey(x => x.Id)
                .HasRequired(x => x.Author)
                .WithMany(x => x.Books);

            modelBuilder.Entity<Author>()
                .HasKey(x => x.Id)
                .HasEntitySetName("Authors");
        }
    }
}
