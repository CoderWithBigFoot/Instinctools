using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ZKorsakas.Data.EntityFramework.Models.Contexts
{
    public class HumanContext : DbContext
    {
        public HumanContext(string connectionString) : base(connectionString) { }

        public virtual DbSet<Human> Humans { set; get; }
    }
}
