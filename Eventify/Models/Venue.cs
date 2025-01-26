using System.ComponentModel.DataAnnotations;

namespace Eventify.Models
{
    public class Venue
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        public int Capacity { get; set; }
        public string ContactInfo { get; set; }
        public int? EventId { get; set; }  
    }
}
