using System;
using System.ComponentModel.DataAnnotations;

namespace Eventify.DTOs.Events.Input
{
    public class CreateEventsDTO
    {
        [Required]
        [MinLength(2, ErrorMessage = "Event name should be at least 2 characters.")]
        [MaxLength(20, ErrorMessage = "Event name cannot be over 20 characters.")]
        public string EventName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Location should be at least 2 characters.")]
        [MaxLength(20, ErrorMessage = "Location cannot be over 20 characters.")]
        public string Location { get; set; }
    }
}

