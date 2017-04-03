using System.Data.Entity;
using System.Data.Common;
using ZKorsakas.Data.EntityFramework.Tests.Models;

namespace ZKorsakas.Data.EntityFramework.Tests.Contexts
{
    public class HumanContext : DbContext
    {
        public HumanContext(string connectionString) : base(connectionString) { }
        public HumanContext(DbConnection connection) : base(connection,true) { }
        //      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
        public HumanContext() { }

        public virtual DbSet<Human> Humans { set; get; }
    }
}
