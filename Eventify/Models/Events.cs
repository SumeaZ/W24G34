using Microsoft.Identity.Client;

namespace Eventify.Models
{
    public class Events
    {
        public int EventsId { get; set; }
        public string? EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
    }
}
