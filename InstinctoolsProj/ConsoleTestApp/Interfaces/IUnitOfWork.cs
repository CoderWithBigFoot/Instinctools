using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using Instinctools.Data.Abstractions;
using ConsoleTestApp.Contexts;
namespace ConsoleTestApp.Interfaces
{
   public interface IUnitOfWork
    {
        GenericRepository<Worker, WorkerContext> Worker { get; }
        void Save();
    }
}
