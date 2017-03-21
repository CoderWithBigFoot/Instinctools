using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instinctools.Data.Abstractions;
using ConsoleTestApp.Contexts;
using ConsoleTestApp.Entities;
namespace ConsoleTestApp.Repositories
{
    // We can define the GenericRepository as non-abstract and use it just like IGenericRepository<SomeModel> someModelRepository;
    public class WorkerRepository: GenericRepository<Worker, WorkerContext>,IDisposable {
        public WorkerRepository(WorkerContext context) : base(context) { }
    }
    


}
