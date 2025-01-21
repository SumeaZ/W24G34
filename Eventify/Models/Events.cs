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
}
