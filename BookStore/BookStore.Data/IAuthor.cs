using ZKorsakas.Data;

namespace BookStore.Data
{
    public interface IAuthor : IEntity
    {
        string Name { set; get; }
        string Surname { set; get; }
    }
}
