using System.ComponentModel.DataAnnotations.Schema;
using ZKorsakas.Data.EntityFramework;

namespace BookStore.Data.Entities
{
    [Table("Book")]
    public class Book : Entity
    {
        public string Name { set; get; }   
        public int Pages { set; get; }
        
        public int AuthorId { protected set; get; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { set; get; }
    }
}
