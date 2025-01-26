namespace Eventify.DTOs.Venues.Input
{
    public class CreateVenueDTO
    {
       
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public string ContactInfo { get; set; }
        public int? EventId { get; set; }
    }
}
