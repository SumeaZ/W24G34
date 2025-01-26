using System;
using System.ComponentModel.DataAnnotations;

namespace Eventify.DTOs.Notifications.Input
{
    public class UpdateNotificationDTO
    {
        [Required]
        public string Message { get; set; }
        [Required]
        public int UserId { get; set; } 
        public int? EventId { get; set; } 
        public string Type { get; set; } 
    }
}
