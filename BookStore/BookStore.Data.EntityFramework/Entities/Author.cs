using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZKorsakas.Data.EntityFramework;

namespace BookStore.Data.EntityFramework.Entities
{
    [Table("Author")]
    public class Author : Entity, IAuthor
    {
        [Required]
        [MinLength(2), MaxLength(100)]
        public string Name { set; get; }

        [Required]
        [MinLength(2), MaxLength(100)]
        public string Surname { set; get; }

        public virtual ICollection<Book> Books { set; get; } = new List<Book>();
    }
}
