using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventify.Models
{
    public class FeedBack
    {
        [Key]
        public int FeedBackId { get; set; }

        [Required]
        public int EventId { get; set; } // Foreign key to Events

        [Required]
        public int Rating { get; set; }

        [MaxLength(500)]
        public string? Comments { get; set; }

        [Required]
        public string? UserId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation property for Events
        [ForeignKey("EventId")]
        public virtual Events Event { get; set; }
    }
}
