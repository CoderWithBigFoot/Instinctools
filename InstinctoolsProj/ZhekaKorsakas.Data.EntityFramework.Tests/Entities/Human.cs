using ZhenyaKorsakas.Data.Entities;
using ZhenyaKorsakas.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZhenyaKorsakas.Data.EntityFramework.Tests.Entities
{
   [Table("Humans")]
   public class Human: BaseEntity<int>, IHuman
    {
        [Required]
        [MinLength(2),MaxLength(10)]
        public string Name { set; get; }

        [Required]
        public string Surname { set; get; }
    }
}
