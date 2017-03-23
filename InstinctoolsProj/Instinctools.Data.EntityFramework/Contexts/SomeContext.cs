using System.Data.Entity;
using ZhenyaKorsakas.Data.EntityFramework.Entities;
namespace ZhenyaKorsakas.Data.EntityFramework.Contexts
{
    public class SomeContext: DbContext {

       // private string connectionString = "name=Instinctools.Connection_1";

        public SomeContext(string connectionString) : base(connectionString) { }
        public SomeContext() : base() { }

        public virtual DbSet<TestEntity> TestEntities { set; get; }
    }
    
    
}
