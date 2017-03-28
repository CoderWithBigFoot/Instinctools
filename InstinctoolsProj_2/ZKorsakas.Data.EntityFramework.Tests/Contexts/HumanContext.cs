using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ZKorsakas.Data.EntityFramework.Tests.Models;

namespace ZKorsakas.Data.EntityFramework.Tests.Contexts
{
    public class HumanContext : DbContext
    {
        public HumanContext(string connectionString) : base(connectionString) { }
        public HumanContext() { }

        public virtual DbSet<Human> Humans { set; get; }
    }
}
