using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ZhenyaKorsakas.Data.EntityFramework.Entities;
namespace ZhenyaKorsakas.Data.EntityFramework.Contexts
{
    public class SomeContext: DbContext {

        public SomeContext(string connectionString) : base(connectionString) { }
        public SomeContext() : base() { }

        public virtual DbSet<TestEntity> TestEntities { set; get; }
    }
    
    
}
