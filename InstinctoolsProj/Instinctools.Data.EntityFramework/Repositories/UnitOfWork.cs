using System;
using ZhenyaKorsakas.Data.EntityFramework.Entities;
using ZhenyaKorsakas.Data.EntityFramework.Contexts;
using System.Data.Entity;
namespace ZhenyaKorsakas.Data.EntityFramework.Repositories
{
    public class UnitOfWork : IUnitOfWork,IDisposable {

        private DbContext context;
        private GenericRepository<TestEntity, DbContext> testEntities;

        /*public UnitOfWork(string connectionString) {
            this.context = new DbContext(connectionString);
        }*/

        public UnitOfWork(DbContext context) {
            this.context = context;
        }

        public UnitOfWork() { }



        public DbContext Context {
            get { return this.context; }
        }

        public GenericRepository<TestEntity,DbContext> TestEntities {
            get {
                return this.testEntities ?? (this.testEntities = new GenericRepository<TestEntity, DbContext>(this.context));
            }
        }
        
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
        
        public void Save() {
            this.context.SaveChanges();
        }

    }
    
}
