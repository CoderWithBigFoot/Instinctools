using System;
using System.Data.Entity;
using ZKorsakas.Data.EntityFramework.Models;
using ZKorsakas.Data.EntityFramework.Abstractions;

namespace ZKorsakas.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected bool _disposed;
        private DbContext _context;
        private IRepository<Human> _humans;

        public UnitOfWork(DbContext context)
        {
            this._context = context;
        }
    
        public IRepository<Human> Humans
        {
            get
            {
                return _humans ?? (_humans = new Repository<Human,DbContext>(_context));
            }
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
