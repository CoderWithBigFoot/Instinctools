using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsoleTestApp.Entities;
namespace ConsoleTestApp.Contexts
{
   public class WorkerContext : DbContext
    {
        public WorkerContext(string connectionStirng = "name=Instinctools.WorkersDatabaseConnection") : base(connectionStirng) { }
        public WorkerContext() : base("name=Instinctools.WorkersDatabaseConnection") { }

        public DbSet<Worker> Workers { set; get; }
    }
}
