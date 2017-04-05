using System.ComponentModel.DataAnnotations;

namespace BookStore.WebUI.Models
{
    public class AuthorViewModel
    {
        [Required]
        public int Id { set; get; }

        [Required]
        [MinLength(2),MaxLength(100)]
        public string Name { set; get; }

        [Required]
        [MinLength(2),MaxLength(100)]
        public string Surname { set; get; }
    }
}