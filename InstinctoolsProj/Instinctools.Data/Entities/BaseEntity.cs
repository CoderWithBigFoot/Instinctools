using System.ComponentModel.DataAnnotations;

namespace ZhenyaKorsakas.Data.Entities
{
   public abstract class BaseEntity
    {
        [Key,Required]  
        public int Id { set; get; }
    }
}
