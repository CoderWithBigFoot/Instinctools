using System;
using ZhenyaKorsakas.Data;
using ZhenyaKorsakas.Data.EntityFramework.Entities;
using ZhenyaKorsakas.Data.EntityFramework.Contexts;
namespace ZhenyaKorsakas.Data.EntityFramework.Repositories
{
    public class UnitOfWork : IUnitOfWork {

        private SomeContext context;
        private GenericRepository<TestEntity, SomeContext> testEntities;

        public UnitOfWork(SomeContext context) {
            this.context = context;
        }

        public SomeContext Context {
            get { return this.context; }
        }

        public GenericRepository<TestEntity,SomeContext> TestEntities {
            get {
                return this.testEntities ?? (this.testEntities = new GenericRepository<TestEntity, SomeContext>(this.context));
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
