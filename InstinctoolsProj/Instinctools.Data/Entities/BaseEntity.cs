using ZhenyaKorsakas.Data.Interfaces;
namespace ZhenyaKorsakas.Data.Entities
{
   public abstract class BaseEntity<T>: IBaseEntity<T>
    {
        public virtual T Id { set; get; }
    }
}
