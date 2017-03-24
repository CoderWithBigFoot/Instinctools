namespace ZhenyaKorsakas.Data.Interfaces
{
   public interface IBaseEntity<T>
    {
        T Id { set; get; }
    }
}
