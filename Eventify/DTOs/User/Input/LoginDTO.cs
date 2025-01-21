using System.ComponentModel.DataAnnotations;

namespace Eventify.DTOs.User.Input
{
    public class LoginDTO
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
