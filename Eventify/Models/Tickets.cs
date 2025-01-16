using Microsoft.Identity.Client;

namespace Eventify.Models
{
    public class Tickets
    {
        public int TicketsId { get; set; }
        public string? Type { get; set; } //"VIP", "Normal"\
        public double Price { get; set; }
        public User? userId { get; set; } // one-to-many
        public Events? eventsId { get; set; } // one-to-many
    }
}
