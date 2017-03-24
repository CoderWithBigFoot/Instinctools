using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ZhenyaKorsakas.Data.Entities;
using ZhenyaKorsakas.Data.Interfaces;

namespace ZhenyaKorsakas.Data.Models
{
    [Table("Humans")]
   public class Human: BaseEntity,IHuman
    {
        [Required]
        [MinLength(2),MaxLength(10)]
        public string Name { set; get; }

        [Required]
        public string Surname { set; get; }
    }
}
