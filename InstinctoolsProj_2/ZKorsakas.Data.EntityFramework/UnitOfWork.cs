using System;
using System.Data.Entity;

namespace ZKorsakas.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected bool _disposed;
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
           this._context?.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_disposed)
                {
                    _context.Dispose();
                    _disposed = true;
                }
            }
        }

        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
