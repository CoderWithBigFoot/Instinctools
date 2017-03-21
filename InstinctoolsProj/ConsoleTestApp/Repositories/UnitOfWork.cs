using System;
using ConsoleTestApp.Contexts;

namespace ConsoleTestApp.Repositories
{
    public class UnitOfWork: IDisposable {

        private WorkerContext context;
        private WorkerRepository workers;
       // private GenericRepository<Worker, WorkerContext> workersViaGeneric;

        public UnitOfWork(WorkerContext context) {
            this.context = context;
        }

        public WorkerRepository Workers {
            get {
                return this.workers ?? (this.workers = new WorkerRepository(this.context));
            }
        }

      /*  public GenericRepository<Worker, WorkerContext> WorkersViaGeneric {
            get {
                return this.workersViaGeneric ?? (this.workersViaGeneric = new GenericRepository<Worker, WorkerContext>(this.context));
            }
        }
        */
        private bool disposed = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposed) {
                if (disposing) {
                    this.context.Dispose();
                    this.disposed = true;
                }
            }
        }

        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
    
    
}
