using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace Eventify.Models
{
    public class Events
    {
        public int EventsId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Event name should be at least 2 characters")]
        [MaxLength(20, ErrorMessage = "Event name cannot be over 20 characters")]
        public string? EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Location should be at least 2 characters")]
        [MaxLength(20, ErrorMessage = "Location cannot be over 20 characters")]
        public string? Location { get; set; }
    }


    public class Feedback
    {
        internal int UserId;

        public int FeedbackId { get; set; }

        [Required]
        public int EventId { get; set; }  // Foreign Key

        [Required]
        [Range(1, 5, ErrorMessage = "Rating should be between 1 and 5")]
        public int Rating { get; set; }

        [MaxLength(500, ErrorMessage = "Comments cannot be more than 500 characters")]
        public string? Comments { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

       
        public Events? Event { get; set; }
        public DateTime UpdatedAt { get; internal set; }
    }
}
