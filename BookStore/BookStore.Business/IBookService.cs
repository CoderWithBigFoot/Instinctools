using BookStore.Data.EntityFramework.Entities;

namespace BookStore.Business
{
    public interface IBookService<TEntity> : IService<TEntity>
        where TEntity : Book
    {
        
    }
}
