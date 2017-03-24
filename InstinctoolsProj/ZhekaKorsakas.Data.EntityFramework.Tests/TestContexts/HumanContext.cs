using System.Data.Entity;
using ZhenyaKorsakas.Data.EntityFramework.Tests.Entities; 

namespace ZhenyaKorsakas.Data.EntityFramework.Tests.TestContexts
{
   public class HumanContext: DbContext
    {
        public HumanContext(string connectionString = "name=Instinctools.Connection_1") : 
            base(connectionString) { }

        public HumanContext() { }

        public virtual DbSet<Human> Humans { set; get; }
    }
}
