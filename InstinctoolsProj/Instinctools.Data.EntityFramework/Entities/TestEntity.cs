using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ZhenyaKorsakas.Data.EntityFramework.Entities
{
   public class TestEntity
    {
        [Key,Required]
        public int Id { set; get; }

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
