using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Contexts;

namespace BookStore.Data.Database
{
    public class BookStoreContextInit : BookStoreContext
    {
        public BookStoreContextInit() : base("name = BookStoreDb") { }
        public BookStoreContextInit(string connectionString) : base(connectionString){ }
    }
}
