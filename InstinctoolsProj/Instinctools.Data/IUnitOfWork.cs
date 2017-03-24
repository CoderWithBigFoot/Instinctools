using System.Data.Entity;

namespace ZhenyaKorsakas.Data
{
   public interface IUnitOfWork
    {
        DbContext Context { get; }
        void Save();
    }
}
