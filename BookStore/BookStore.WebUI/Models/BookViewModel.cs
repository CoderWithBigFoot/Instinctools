using System.ComponentModel.DataAnnotations;

namespace BookStore.WebUI.Models
{
    public class BookViewModel
    {
        [Required]
        public int Id { set; get; }
        
        [Required]
        [MinLength(2),MaxLength(50)]
        public string Name { set; get; }

        [Required]
        [Range(1,int.MaxValue)]
        public int Pages { set; get; }
    }
}