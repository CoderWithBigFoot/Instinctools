namespace BookStore.Business.Dto
{
    public class BookDto 
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Pages { set; get; }
        
        public int AuthorId { set; get; }
    }
}
