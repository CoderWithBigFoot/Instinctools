using System.Collections.Generic;
using ZKorsakas.Data.EntityFramework;

namespace BookStore.Data.Entities
{
    public class Author : Entity
    {
        public string Name { set; get; }
        public string Surname { set; get; }

        public virtual ICollection<Book> Books { set; get; } = new List<Book>();
    }
}
