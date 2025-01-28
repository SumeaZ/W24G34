using System.ComponentModel.DataAnnotations;

namespace Eventify.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name should be at least 2 characters")]
        [MaxLength(20, ErrorMessage = "Name cannot be over 20 characters")]
        public string Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Description should be at least 2 characters")]
        [MaxLength(200, ErrorMessage = "Description cannot be over 20 characters")]
        public string Description { get; set; }
    }
}


