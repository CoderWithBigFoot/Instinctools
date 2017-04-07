using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Contexts;

namespace BookStore.Data.Database
{
    public class BookStoreDbManagerContext : BookStoreContext
    {
        public BookStoreDbManagerContext() : base("name = BookStoreDb") { }
        public BookStoreDbManagerContext(string connectionString) : base(connectionString){ }
    }
}
