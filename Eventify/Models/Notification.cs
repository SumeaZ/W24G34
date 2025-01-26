using System;

namespace Eventify.Models
{
    public class Notification
    {
        public int Id { get; set; } 
        public string Message { get; set; } 
        public int UserId { get; set; } 
        public int? EventId { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public string Type { get; set; } // Type of notification (Reminder, Update, Announcement)
    }
}
