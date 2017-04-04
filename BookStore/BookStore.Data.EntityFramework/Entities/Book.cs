using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZKorsakas.Data.EntityFramework;

namespace BookStore.Data.EntityFramework.Entities
{
    [Table("Book")]
    public class Book : Entity, IBook
    {
        [Required]
        [MinLength(2),MaxLength(100)]
        public string Name { set; get; }

        [Required]
        [Range(1,int.MaxValue)]
        public int Pages { set; get; }
        
        public int AuthorId { protected set; get; }

        [Required]
        [ForeignKey("AuthorId")]
        public virtual Author Author { set; get; }
    }
}
