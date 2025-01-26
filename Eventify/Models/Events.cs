using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventify.Models
{
    public class Events
    {
        [Key]
        public int EventsId { get; set; } // Primary key

        [Required]
        [MinLength(2, ErrorMessage = "Event name should be at least 2 characters")]
        [MaxLength(20, ErrorMessage = "Event name cannot be over 20 characters")]
        public string? EventName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Location should be at least 2 characters")]
        [MaxLength(20, ErrorMessage = "Location cannot be over 20 characters")]
        public string? Location { get; set; }

        // Navigation property for FeedBacks
        public virtual ICollection<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();
    }
}



 

