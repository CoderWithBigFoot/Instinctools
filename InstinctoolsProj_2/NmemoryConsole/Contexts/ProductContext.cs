using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMemoryConsole.Entities;
using System.Data.Entity;
namespace NMemoryConsole.Contexts
{
    public class ProductContext: DbContext
    {
        public ProductContext() { }
        public DbSet<Product> Products { set;get; }
    }
}
