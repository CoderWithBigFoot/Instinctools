using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using System.Data.Entity;

namespace BookStore.Data.Database
{
    public class BookStoreDbManagerContext : BookStoreContext
    {
        // before applying migrations need to set up the connection string in the BookStore.Data
        public BookStoreDbManagerContext() : base("name=BookStoreDb") { /*Database.Initialize(true);*/ }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
