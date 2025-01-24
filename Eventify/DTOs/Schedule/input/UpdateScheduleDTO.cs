namespace Eventify.DTOs
{
    public class UpdateScheduleDTO
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
     
    }
}
