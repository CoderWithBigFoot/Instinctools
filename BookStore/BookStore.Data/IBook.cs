using ZKorsakas.Data;

namespace BookStore.Data
{
    public interface IBook : IEntity
    {
        string Name { set; get; }
        int Pages { set; get; }
    }
}
