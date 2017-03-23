using System.ComponentModel.DataAnnotations;
using ZhenyaKorsakas.Data.Entities;
namespace ZhenyaKorsakas.Data.EntityFramework.Entities
{
   public class TestEntity: BaseEntity
    {
        [MinLength(4)]
        [MaxLength(10)]
        public string Name { set; get; }

        
        public string Sername { set; get; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name}";

        }
    }
}
