using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZKorsakas.Data.EntityFramework.Abstractions.Abstractions;
using ZKorsakas.Data.EntityFramework.Abstractions;

namespace ZKorsakas.Data.EntityFramework.Models
{
    [Table("Human")]
    public class Human : Entity, IHuman
    {   
        [Required]
        public string Name { set; get; }

        [Required]
        public string Surname { set; get; }
    }
}
