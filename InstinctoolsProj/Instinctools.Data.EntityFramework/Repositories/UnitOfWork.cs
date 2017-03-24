using System;
using System.Data.Entity;
using System.Collections.Generic;
using ZhenyaKorsakas.Data;
using ZhenyaKorsakas.Data.Entities;
namespace ZhenyaKorsakas.Data.EntityFramework.Repositories
{
    public class UnitOfWork : IUnitOfWork,IDisposable {

        private DbContext context;

        public UnitOfWork(DbContext context) {
            this.context = context;
        }

        public DbContext Context {
            get { return this.context; }
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
