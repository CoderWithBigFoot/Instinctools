namespace ZKorsakas.Data
{
    public interface IUnitOfWork
    {
       // IRepository<IEntity> Humans { get; }
        void Commit();
    }
}
