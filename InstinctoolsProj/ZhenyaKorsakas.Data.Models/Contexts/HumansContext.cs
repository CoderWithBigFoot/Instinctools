using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ZhenyaKorsakas.Data.Models.Contexts
{
   public class HumansContext: DbContext
    {
        public HumansContext(string connectionString = "name=Instinctools.Connection_1") 
            : base(connectionString) { }

        //public HumansContext() { }

        public virtual DbSet<Human> Humans { set; get; }

    }
}
