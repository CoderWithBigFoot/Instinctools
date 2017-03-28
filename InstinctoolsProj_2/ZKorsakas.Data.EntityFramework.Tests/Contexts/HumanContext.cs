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
