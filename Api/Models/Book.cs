using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book name is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author name is required.")]
        public string Author { get; set; }

        [Range(0.01, 100000, ErrorMessage = "Price must be between 0.01 and 100000.")]
        public decimal Price { get; set; }
    }
}
