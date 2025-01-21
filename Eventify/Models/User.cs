using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Eventify.Models
{
    public class User : IdentityUser
    {

        //public int UserId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "First name should be at least 2 characters")]
        [MaxLength(20, ErrorMessage = "First name cannot be over 20 characters")]
        public string? FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "First name should be at least 2 characters")]
        [MaxLength(20, ErrorMessage = "First name cannot be over 20 characters")]
        public string? LastName { get; set; }
        

    }
}
