using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using ConsoleTestApp.Entity.Entities;
namespace ConsoleTestApp.Entity.Contexts
{
   public class CarContext: DbContext
    {
        public CarContext(string connectionString = "name=Instinctools.WorkersDatabaseConnection") : base(connectionString) { }
        public CarContext() { }

        public virtual DbSet<Worker> Workers { set; get; }
    }
}
