using ZhenyaKorsakas.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
namespace ZhenyaKorsakas.Data.Entities
{
   public abstract class BaseEntity: IBaseEntity
    {
        [Key]
        public virtual int Id { set; get; }
    }
}
