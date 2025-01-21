using System.ComponentModel.DataAnnotations;

namespace Eventify.Models
{
    public class RefreshToken
    {
        [Key]
        public int TokenId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Associated user is required.")]
        public virtual User User { get; set; }
    }
}
