using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Eventify.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [MaxLength(100)]
        public string? Speaker { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

           public Event Event { get; set; }
    }
}
